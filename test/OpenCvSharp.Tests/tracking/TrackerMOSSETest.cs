using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    public class TrackerMOSSETest : TrackerTestBase
    {
        [Fact]
        public void Init()
        {
            using (var tracker = TrackerMOSSE.Create())
            {
                InitBase(tracker);
            }
        }

        [Fact]
        public void Update()
        {
            using (var tracker = TrackerMOSSE.Create())
            {
                UpdateBase(tracker);
            }
        }
    }
}