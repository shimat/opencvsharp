using System;
using System.Threading.Tasks;
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
        public async Task UpdateAsync()
        {
            using (var tracker = TrackerMedianFlow.Create())
            {
                await UpdateBaseAsync(tracker).ConfigureAwait(false);
            }
        }
    }
}
