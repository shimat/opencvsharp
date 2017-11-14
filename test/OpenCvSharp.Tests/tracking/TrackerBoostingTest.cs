using System;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    public class TrackerBoostingTest : TrackerTestBase
    {
        [Fact]
        public void Init()
        {
            using (var tracker = TrackerBoosting.Create())
            {
                InitBase(tracker);
            }
        }

        [Fact]
        public void Update()
        {
            using (var tracker = TrackerBoosting.Create())
            {
                UpdateBase(tracker);
            }
        }
    }
}
