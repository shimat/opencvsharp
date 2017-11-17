using System;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    // ReSharper disable once InconsistentNaming

    public class TrackerTLDTest : TrackerTestBase
    {
        [Fact]
        public void Init()
        {
            using (var tracker = TrackerTLD.Create())
            {
                InitBase(tracker);
            }
        }

        [Fact]
        public void Update()
        {
            using (var tracker = TrackerTLD.Create())
            {
                UpdateBase(tracker);
            }
        }
    }
}
