using System;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    // ReSharper disable once InconsistentNaming

    public class TrackerGOTURNTest : TrackerTestBase
    {
        [Fact(Skip = "fs.is_open(). Can't open \"goturn.prototxt\"")]
        public void Init()
        {
            using (var tracker = TrackerGOTURN.Create())
            {
                InitBase(tracker);
            }
        }

        [Fact(Skip = "fs.is_open(). Can't open \"goturn.prototxt\"")]
        public void Update()
        {
            using (var tracker = TrackerGOTURN.Create())
            {
                UpdateBase(tracker);
            }
        }
    }
}
