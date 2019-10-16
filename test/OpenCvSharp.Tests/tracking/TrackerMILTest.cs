using System;
using System.Threading.Tasks;
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
        public async Task UpdateAsync()
        {
            using (var tracker = TrackerMIL.Create())
            {
                await UpdateBaseAsync(tracker).ConfigureAwait(false);
            }
        }
    }
}
