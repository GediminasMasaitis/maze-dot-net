using System;
using System.Threading;

namespace Maze.Core.Runners.Sleepers
{
    sealed class AccumulatingWaiter : DriftAwareWaiterBase
    {
        public AccumulatingWaiter()
        {
            SyncDrift();
            Tolerance = TimeSpan.FromTicks(Drift.Ticks * 5);
        }

        public TimeSpan Tolerance { get; set; }
        public TimeSpan AccumulatedTime { get; private set; }

        public override void Wait(TimeSpan delay)
        {
            AccumulatedTime += delay;
            if (AccumulatedTime > Tolerance)
            {
                WaitInner(AccumulatedTime);
                AccumulatedTime = TimeSpan.Zero;
            }
        }

        private void WaitInner(TimeSpan delay)
        {
            Thread.Sleep(delay - Drift);
        }
    }
}