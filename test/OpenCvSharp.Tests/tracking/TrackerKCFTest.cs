using System;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    // ReSharper disable once InconsistentNaming

    public class TrackerKCFTest : TrackerTestBase
    {
        [Fact]
        public void Init()
        {
            using (var tracker = TrackerKCF.Create())
            {
                InitBase(tracker);
            }
        }

        [Fact]
        public void Update()
        {
            using (var tracker = TrackerKCF.Create())
            {
                UpdateBase(tracker);
            }
        }
    }
}
