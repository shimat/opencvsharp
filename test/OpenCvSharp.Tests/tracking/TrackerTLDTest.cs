using System;
using System.Threading.Tasks;
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
        public async Task UpdateAsync()
        {
            using (var tracker = TrackerTLD.Create())
            {
                await UpdateBaseAsync(tracker).ConfigureAwait(false);
            }
        }
    }
}
