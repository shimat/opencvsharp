using System;
using System.Threading.Tasks;
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
        public async Task UpdateAsync()
        {
            using (var tracker = TrackerBoosting.Create())
            {
                await UpdateBaseAsync(tracker).ConfigureAwait(false);
            }
        }
    }
}
