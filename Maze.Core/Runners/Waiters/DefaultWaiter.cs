using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Maze.Core.Runners.Sleepers
{
    class DefaultWaiter : IWaiter
    {
        public void Wait(TimeSpan delay)
        {
            Thread.Sleep(delay);
        }
    }
}
