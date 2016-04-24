using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Maze.Core.Runners.Sleepers
{
    abstract class DriftAwareWaiterBase : IWaiter
    {
        public TimeSpan Drift { get; protected set; }

        public void SyncDrift()
        {
            Drift = CalculateDrift();
        }

        protected virtual TimeSpan CalculateDrift()
        {
            var sw = new Stopwatch();
            var runTimes = 10;
            var results = new List<long>(runTimes);
            var delay = 1;
            for (var i = 0; i < runTimes; i++)
            {
                sw.Start();
                Thread.Sleep(delay);
                sw.Stop();
                var drift = sw.Elapsed.Subtract(TimeSpan.FromMilliseconds(delay));
                results.Add(drift.Ticks);
                sw.Reset();
            }
            var avgTicks = (long)results.Average();
            var avg = TimeSpan.FromTicks(avgTicks);
            return avg;
        }

        public abstract void Wait(TimeSpan delay);
    }
}