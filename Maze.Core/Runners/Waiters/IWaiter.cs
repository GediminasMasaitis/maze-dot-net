using System;
using System.Diagnostics;

namespace Maze.Core.Runners.Sleepers
{
    interface IWaiter
    {
        void Wait(TimeSpan delay);
    }
}