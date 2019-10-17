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

        // https://github.com/shimat/opencvsharp/issues/459
        [Fact]
        public void Issue459()
        {
            var paras = new TrackerKCF.Params
            {
                CompressFeature = true,
                CompressedSize = 1,
                Resize = true,
                DescNpca = 1,
                DescPca = 1
            };

            using (var tracker = TrackerKCF.Create(paras))
            {
                GC.KeepAlive(tracker);
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
