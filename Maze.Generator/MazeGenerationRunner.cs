using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Maze.Generator.Generators;
using Maze.Generator.Renderers;
using Maze.Generator.Results;

namespace Maze.Generator
{
    public class MazeGenerationRunner : MazeGenerationRunner<IMazeGenerator>
    {
        public MazeGenerationRunner(IMazeGenerator mazeGenerator, IMapRenderer mapRenderer, bool bulkRender, TimeSpan generatorMinCycleTime, TimeSpan rendererMinCycleTime) : base(mazeGenerator, mapRenderer, bulkRender, generatorMinCycleTime, rendererMinCycleTime)
        {
        }
    }

    public class MazeGenerationRunner<TMazeGenerator> : MazeGenerationRunner<TMazeGenerator, IMapRenderer>
        where TMazeGenerator : IMazeGenerator
    {
        public MazeGenerationRunner(TMazeGenerator mazeGenerator, IMapRenderer mapRenderer, bool bulkRender, TimeSpan generatorMinCycleTime, TimeSpan rendererMinCycleTime) : base(mazeGenerator, mapRenderer, bulkRender, generatorMinCycleTime, rendererMinCycleTime)
        {
        }
    }

    public class MazeGenerationRunner<TMazeGenerator, TMapRenderer>
        where TMazeGenerator: IMazeGenerator
        where TMapRenderer: IMapRenderer
    {
        public MazeGenerationRunner(TMazeGenerator mazeGenerator, TMapRenderer mapRenderer, bool bulkRender, TimeSpan generatorMinCycleTime, TimeSpan rendererMinCycleTime)
        {
            if (mazeGenerator == null)
            {
                throw new ArgumentNullException(nameof(mazeGenerator));
            }

            MazeGenerator = mazeGenerator;
            MapRenderer = mapRenderer;

            BulkRender = bulkRender;

            GeneratorMinCycleTime = generatorMinCycleTime;
            RendererMinCycleTime = rendererMinCycleTime;

            GeneratorStopwatch = new Stopwatch();
            RendererStopwatch = new Stopwatch();

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

        public bool GeneratorRunning { get; private set; }
        public bool RendererRunning { get; private set; }

        public bool BulkRender { get; set; }
        public TimeSpan GeneratorMinCycleTime { get; set; }
        public TimeSpan RendererMinCycleTime { get; set; }

        private Thread GeneratorThread { get; }
        private Thread RendererThread { get; }
        private object Synchro { get; }

        public Queue<MazeGenerationResults> ResultsQueue { get; set; }

        private void SmartSleep(TimeSpan delay)
        {
            var drift = TimeSpan.FromMilliseconds(10);
            // TODO: make it smart
            if (delay < drift.Add(TimeSpan.FromMilliseconds(1)))
            {
                var sw = new Stopwatch();
                sw.Start();
                while (sw.Elapsed < delay)
                {
                    // Wait.
                }
            }
            else
            {
                var sleepDelay = delay - drift;
                Thread.Sleep(sleepDelay);
            }
        }

        private void RunGenerator()
        {
            while (GeneratorRunning)
            {
                var remainingTime = GeneratorMinCycleTime - GeneratorStopwatch.Elapsed;
                if (remainingTime > TimeSpan.Zero)
                {
                    SmartSleep(remainingTime);
                }
                GeneratorStopwatch.Restart();

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
                    while (ResultsQueue.Count == 0)
                    {
                        Monitor.Wait(Synchro);
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
                    SmartSleep(remainingTime);
                }
                RendererStopwatch.Restart();

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
            MapRenderer.Render(results);
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
            if (wait)
            {
                RendererThread.Join();
            }
            RendererStopwatch.Stop();
        }


    }
}