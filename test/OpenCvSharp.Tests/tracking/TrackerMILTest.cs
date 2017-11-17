using System;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    // ReSharper disable once InconsistentNaming

    public class TrackerMILTest : TrackerTestBase
    {
        [Fact]
        public void Init()
        {
            using (var tracker = TrackerMIL.Create())
            {
                InitBase(tracker);
            }
        }

        [Fact]
        public void Update()
        {
            using (var tracker = TrackerMIL.Create())
            {
                UpdateBase(tracker);
            }
        }
    }
}
