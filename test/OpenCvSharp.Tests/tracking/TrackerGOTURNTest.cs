using System;
using System.Threading.Tasks;
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
        public async Task UpdateAsync()
        {
            using (var tracker = TrackerGOTURN.Create())
            {
                await UpdateBaseAsync(tracker).ConfigureAwait(false);
            }
        }
    }
}
