using System;
using System.Diagnostics;
using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc
{
    public class EdgeFilterTest : TestBase
    {
        [Fact]
        public void EnhanceByGuidedFilter()
        {
            using var image = Image("lenna.png", ImreadModes.Color);
            image.ConvertTo(image, MatType.CV_32F, 1.0 / 255.0);

            using var gf = GuidedFilter.Create(image, 16, 0.01);
            using var dst = new Mat();
            gf.Filter(image, dst);

            if (Debugger.IsAttached)
            {
                using var view = (image - dst) * 5 + dst;
                Window.ShowImages(image, dst, view);
            }
        }
    }
}
