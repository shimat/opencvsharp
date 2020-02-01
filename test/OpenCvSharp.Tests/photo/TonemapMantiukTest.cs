﻿using Xunit;

namespace OpenCvSharp.Tests.Photo
{
    public class TonemapMantiukTest : TestBase
    {
        [Fact]
        public void Process()
        {
            using var src = Image("lenna.png");
            using var dst = new Mat();
            using var tonemap = TonemapMantiuk.Create();

            // 8UC3 -> 32FC3
            using var src32f = new Mat();
            src.ConvertTo(src32f, MatType.CV_32FC3);

            tonemap.Process(src32f, dst);

            ShowImagesWhenDebugMode(dst);
        }

        [Fact]
        public void Properties()
        {
            using var tonemap = TonemapMantiuk.Create(2.2f, 1.5f, 1.8f);
            Assert.Equal(1.5f, tonemap.Scale, 3);
            Assert.Equal(1.8f, tonemap.Saturation, 3);
            
            tonemap.Scale = 0.5f;
            tonemap.Saturation = 0.8f;
            Assert.Equal(0.5f, tonemap.Scale, 3);
            Assert.Equal(0.8f, tonemap.Saturation, 3);
        }
    }
}