using System;
using System.Threading;

namespace Maze.Core.Runners.Sleepers
{
    sealed class AccumulatingWaiter : DriftAwareWaiterBase
    {
        public AccumulatingWaiter()
        {
            SyncDrift();
            Thereshold = TimeSpan.FromTicks(Drift.Ticks * 5).Add(TimeSpan.FromMilliseconds(1));
        }

        public TimeSpan Thereshold { get; set; }
        public TimeSpan AccumulatedTime { get; private set; }

        public override void Wait(TimeSpan delay)
        {
            AccumulatedTime += delay;
            if (AccumulatedTime > Thereshold)
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