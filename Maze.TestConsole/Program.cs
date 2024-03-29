﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Maze.Core.Common;
using Maze.Core.Generators.Decorators;
using Maze.Core.Generators.GrowingTree;
using Maze.Core.Maps;
using Maze.Core.Maps.Decorators;
using Maze.Core.Renderers;
using Maze.Core.Renderers.Decorators;
using Maze.Core.Renderers.Text;
using Maze.Core.Results;
using Maze.Core.Runners;

namespace Maze.TestConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            User32Imports.Maximize();
            var track = false;
            Console.CursorVisible = false;

            var map = new FiniteMap2D(15,25);
            var finiteMap = new AsFiniteMapDecorator(map, map.Size ?? new Point(55,75));
            var map2D = new AsSmallerDimensionMapDecorator(map, new int[]{});
            IMap displayMap = finiteMap;
            var innerGenerator = new GrowingTreeMazeGenerator(map);

            var generator = new ActiveCellsMazeGeneratorDecorator(innerGenerator);

            var renderer = new ConsoleMapRenderer(displayMap, true, false);
            var fullRenderer = new InstantAsFullMapRendererDecorator(renderer, true);
            var generatorDelay = 100d;
            var rendererDelay = 1000d / 60d;
            var generatorDelaySpan = TimeSpan.FromTicks((long)(generatorDelay * TimeSpan.TicksPerMillisecond));
            var rendererDelaySpan = TimeSpan.FromTicks((long)(rendererDelay * TimeSpan.TicksPerMillisecond));
            var runner = new MazeGenerationRunner(generator, fullRenderer, generatorDelaySpan, rendererDelaySpan);

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
                    finiteMap.Offset = displayMap.Size/2 - results.Results[0].Point;
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
                        finiteMap.Offset[0]++;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.DownArrow:
                        finiteMap.Offset[0]--;
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.RightArrow:
                        finiteMap.Offset[1]--;
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.LeftArrow:
                        finiteMap.Offset[1]++;
                        break;
                    case ConsoleKey.NumPad5:
                        track = !track;
                        break;
                    case ConsoleKey.NumPad7:
                        finiteMap.Size -= 1;
                        break;
                    case ConsoleKey.NumPad9:
                        finiteMap.Size += 1;
                        break;
                    case ConsoleKey.NumPad3:
                        map2D.ExtraLayers[0] += 1;
                        break;
                    case ConsoleKey.NumPad1:
                        map2D.ExtraLayers[0] -= 1;
                        break;
                    case ConsoleKey.X:
                        runner.Stop();
                        return;
                }
            }
        }


    }
}
