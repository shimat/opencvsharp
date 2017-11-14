using System;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    public class TrackerMedianFlowTest : TrackerTestBase
    {
        [Fact]
        public void Init()
        {
            using (var tracker = TrackerMedianFlow.Create())
            {
                InitBase(tracker);
            }
        }

        [Fact]
        public void Update()
        {
            using (var tracker = TrackerMedianFlow.Create())
            {
                UpdateBase(tracker);
            }
        }
    }
}
