using System;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public class TrackerCSRTTest : TrackerTestBase
    {
        [Fact]
        public void Init()
        {
            using var tracker = TrackerCSRT.Create();
            InitBase(tracker);
        }

        [Fact]
        public void Update()
        {
            using var tracker = TrackerCSRT.Create();
            UpdateBase(tracker);
        }
    }
}
