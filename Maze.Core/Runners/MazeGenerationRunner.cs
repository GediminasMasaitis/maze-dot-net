using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Maze.Core.Generators;
using Maze.Core.Renderers;
using Maze.Core.Results;
using Maze.Core.Runners.Waiters;

namespace Maze.Core.Runners
{
    public class MazeGenerationRunner : MazeGenerationRunner<IMazeGenerator>
    {
        public MazeGenerationRunner(IMazeGenerator mazeGenerator, IFullMapRenderer mapRenderer, TimeSpan? generatorMinCycleTime = null, TimeSpan? rendererMinCycleTime = null, bool bulkRender = true) : base(mazeGenerator, mapRenderer, generatorMinCycleTime, rendererMinCycleTime, bulkRender)
        {
        }
    }

    public class MazeGenerationRunner<TMazeGenerator> : MazeGenerationRunner<TMazeGenerator, IFullMapRenderer>
        where TMazeGenerator : IMazeGenerator
    {
        public MazeGenerationRunner(TMazeGenerator mazeGenerator, IFullMapRenderer mapRenderer, TimeSpan? generatorMinCycleTime = null, TimeSpan? rendererMinCycleTime = null, bool bulkRender = true) : base(mazeGenerator, mapRenderer, generatorMinCycleTime, rendererMinCycleTime, bulkRender)
        {
        }
    }

    public class MazeGenerationRunner<TMazeGenerator, TMapRenderer>
        where TMazeGenerator: IMazeGenerator
        where TMapRenderer: IFullMapRenderer
    {
        public MazeGenerationRunner(TMazeGenerator mazeGenerator, TMapRenderer mapRenderer, TimeSpan? generatorMinCycleTime = null, TimeSpan? rendererMinCycleTime = null, bool bulkRender = true)
        {
            if (mazeGenerator == null)
            {
                throw new ArgumentNullException(nameof(mazeGenerator));
            }

            MazeGenerator = mazeGenerator;
            MapRenderer = mapRenderer;

            BulkRender = bulkRender;

            GeneratorMinCycleTime = generatorMinCycleTime ?? TimeSpan.FromMilliseconds(100);
            RendererMinCycleTime = rendererMinCycleTime ?? TimeSpan.FromMilliseconds(100);

            GeneratorStopwatch = new Stopwatch();
            RendererStopwatch = new Stopwatch();

            GeneratorWaiter = new AccumulatingWaiter();
            RendererWaiter = new AccumulatingWaiter();

            GeneratorThread = new Thread(RunGenerator);
            RendererThread = new Thread(RunRenderer);
            ResultsQueue = new Queue<MazeGenerationResults>();
            Synchro = new object();
        }

        public event Action BeforeGenerate;
        public event Action<MazeGenerationResults> AfterGenerate;
        public event Action<MazeGenerationResults> GeneratorCompleted;
        public event Action<MazeGenerationResults> BeforeRender;
        public event Action<MazeGenerationResults> AfterRender;

        public TMazeGenerator MazeGenerator { get; }
        public TMapRenderer MapRenderer { get; }

        private Stopwatch GeneratorStopwatch { get; }
        private Stopwatch RendererStopwatch { get; }

        private IWaiter GeneratorWaiter { get; }
        private IWaiter RendererWaiter { get; }

        public bool GeneratorRunning { get; private set; }
        public bool RendererRunning { get; private set; }

        public bool BulkRender { get; set; }
        public TimeSpan GeneratorMinCycleTime { get; set; }
        public TimeSpan RendererMinCycleTime { get; set; }

        private Thread GeneratorThread { get; }
        private Thread RendererThread { get; }
        private object Synchro { get; }

        public Queue<MazeGenerationResults> ResultsQueue { get; set; }

        private void RunGenerator()
        {
            while (GeneratorRunning)
            {
                var remainingTime = GeneratorMinCycleTime - GeneratorStopwatch.Elapsed;
                if (remainingTime > TimeSpan.Zero)
                {
                    GeneratorWaiter.Wait(remainingTime);
                }
                GeneratorStopwatch.Reset();
                GeneratorStopwatch.Start();

                BeforeGenerate?.Invoke();
                var results = Generate();
                lock (Synchro)
                {
                    ResultsQueue.Enqueue(results);
                    Monitor.Pulse(Synchro);
                }
                AfterGenerate?.Invoke(results);
                if (results.ResultsType == GenerationResultsType.GenerationCompleted)
                {
                    GeneratorCompleted?.Invoke(results);
                    StopGenerator(false);
                }
            }
        }

        public virtual MazeGenerationResults Generate()
        {
            var results = MazeGenerator.Generate();
            return results;
        }

        private void RunRenderer()
        {
            while (RendererRunning)
            {
                MazeGenerationResults results = null;
                Queue<MazeGenerationResults> bulkQueue = null;
                lock (Synchro)
                {
                    while (ResultsQueue.Count == 0 && RendererRunning)
                    {
                        Monitor.Wait(Synchro);
                    }
                    if (!RendererRunning)
                    {
                        return;
                    }
                    if (BulkRender)
                    {
                        bulkQueue = ResultsQueue;
                        ResultsQueue = new Queue<MazeGenerationResults>();
                    }
                    else
                    {
                        results = ResultsQueue.Dequeue();
                    }
                }

                var remainingTime = RendererMinCycleTime - RendererStopwatch.Elapsed;
                if (remainingTime > TimeSpan.Zero)
                {
                    RendererWaiter.Wait(remainingTime);
                }
                GeneratorStopwatch.Reset();
                GeneratorStopwatch.Start();

                if (BulkRender)
                {
                    results = MazeGenerationResults.Merge(bulkQueue, true);
                }

                BeforeRender?.Invoke(results);

                if (MapRenderer != null)
                {
                    Render(results);
                }

                AfterRender?.Invoke(results);
            }
        }

        public virtual void Render(MazeGenerationResults results)
        {
            MapRenderer.RenderStep(results);
        }

        public void Start()
        {
            StartGenerator();
            StartRenderer();
        }

        public void Stop()
        {
            StopGenerator(false);
            StopRenderer(false);
            GeneratorThread.Join();
            GeneratorThread.Join();
        }

        public void StartGenerator()
        {
            if (GeneratorRunning)
            {
                return;
            }
            GeneratorRunning = true;
            GeneratorStopwatch.Start();
            GeneratorThread.Start();
        }

        public void StopGenerator(bool wait = true)
        {
            if (!GeneratorRunning)
            {
                return;
            }
            GeneratorRunning = false;
            if (wait)
            {
                GeneratorThread.Join();
            }
            GeneratorStopwatch.Stop();
        }

        public void StartRenderer()
        {
            if (RendererRunning)
            {
                return;
            }
            RendererRunning = true;
            RendererStopwatch.Start();
            RendererThread.Start();
        }

        public void StopRenderer(bool wait = true)
        {
            if (!RendererRunning)
            {
                return;
            }
            RendererRunning = false;
            lock (Synchro)
            {
                Monitor.Pulse(Synchro);
            }
            if (wait)
            {
                RendererThread.Join();
            }
            RendererStopwatch.Stop();
        }


    }
}