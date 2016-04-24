using System;
using System.Diagnostics;
using System.Threading;

namespace Maze.Core.Runners.Sleepers
{
    sealed class PrecisionWaiter : DriftAwareWaiterBase
    {
        public PrecisionWaiter()
        {
            SyncDrift();
        }

        public override void Wait(TimeSpan delay)
        {
            var thereshold = TimeSpan.FromTicks(Drift.Ticks * 5).Add(TimeSpan.FromMilliseconds(1));
            if (delay > thereshold)
            {
                SleepWait(delay);
            }
            else
            {
                SpinWait(delay);
            }
        }

        public void SpinWait(TimeSpan delay)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.Elapsed < delay)
            {
                // Wait.
            }
        }

        public void SleepWait(TimeSpan delay)
        {
            var sleepDelay = delay - Drift;
            Thread.Sleep(sleepDelay);
        }
    }

}