using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Maze.Generator;
using Maze.Generator.Generators;
using Maze.Generator.Generators.AldousBroder;
using Maze.Generator.Generators.Decorators;
using Maze.Generator.Generators.GrowingTree;
using Maze.Generator.Generators.Kruskal;
using Maze.Generator.Maps;
using Maze.Generator.Renderers;

namespace Maze.TestConsole
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        private static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }

        static void Main(string[] args)
        {
            Maximize();
            var track = false;
            //var map = new FiniteMap2D(55,75);
            var map = new FiniteMap2D(15,25);
            //var map = new InfiniteMap(2);
            var displayMap = new AsFiniteMapDecorator(map, map.Size ?? new Point(55,75));
            //var innerGenerator = new TestMazeGenerator(map);
            var innerGenerator = new KruskalMazeGenerator(map);
            //innerGenerator.GenerationParameters.Breadth = 1;
            var generator = new ActiveCellsMazeGeneratorDecorator(innerGenerator);
            //var generator = innerGenerator;
            Console.CursorVisible = false;
            var renderer = new ConsoleMapRenderer(map, true, true);
            var generatorDelay = 500d;
            var rendererDelay = 1000d / 60d;
            var generatorDelaySpan = TimeSpan.FromTicks((long)(generatorDelay * TimeSpan.TicksPerMillisecond));
            var rendererDelaySpan = TimeSpan.FromTicks((long)(rendererDelay * TimeSpan.TicksPerMillisecond));
            var runner = new MazeGenerationRunner(generator, renderer, true, generatorDelaySpan, rendererDelaySpan);
            var generatorSteps = 0;
            var rendererSteps = 0;
            runner.AfterGenerate += results =>
            {
                generatorSteps ++;
            };
            runner.BeforeRender += results =>
            {
                if (track && results.Results.Count > 0)
                {
                    displayMap.Offset = displayMap.Size/2 - results.Results[0].Point;
                }
            };
            runner.AfterRender += results =>
            {
                rendererSteps++;
                Console.WriteLine("Generated steps: " + generatorSteps);
                Console.WriteLine("Rendered steps: " + rendererSteps);
                if (results.ResultsType == GenerationResultsType.GenerationCompleted)
                {
                    Console.WriteLine("Completed!");
                }
            };
            runner.Start();

            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.UpArrow:
                        displayMap.Offset[0]++;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.DownArrow:
                        displayMap.Offset[0]--;
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.RightArrow:
                        displayMap.Offset[1]--;
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.LeftArrow:
                        displayMap.Offset[1]++;
                        break;
                    case ConsoleKey.NumPad5:
                        track = !track;
                        break;
                    case ConsoleKey.NumPad7:
                        displayMap.Size -= 1;
                        break;
                    case ConsoleKey.NumPad9:
                        displayMap.Size += 1;
                        break;
                }
            }

            /*var commandStr = string.Empty;
            while (true)
            {
                commandStr = Console.ReadLine();
                var commands = commandStr.Split(' ');
                switch (commands[0])
                {
                    case "exit":
                    case "quit":
                    case "stop":
                        return;
                }
            }*/
        }


    }
}
