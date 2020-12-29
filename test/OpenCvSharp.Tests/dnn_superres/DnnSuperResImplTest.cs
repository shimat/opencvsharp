using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.DnnSuperres;
using OpenCvSharp.Tests.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.DnnSuperres
{
    public class DnnSuperResImplTest : TestBase
    {
        // https://github.com/opencv/opencv_contrib/tree/master/modules/dnn_superres#models
        // https://github.com/Saafke/EDSR_Tensorflow
        private const string ModelUrl = "https://github.com/Saafke/EDSR_Tensorflow/raw/master/models/EDSR_x2.pb";
        private const string ModelFileName = "EDSR_x2.pb";

        public DnnSuperResImplTest()
        {
            Console.WriteLine("Downloading EDSR Model...");
            ModelDownloader.DownloadAndSave(new Uri(ModelUrl), ModelFileName);
            Console.WriteLine("Done");
        }

        [Fact]
        public void New()
        {
            using var dnn = new DnnSuperResImpl();
        }
        
        [Fact]
        public void Upsample()
        {
            using var dnn = new DnnSuperResImpl("edsr", 2);
            dnn.ReadModel(ModelFileName);

            using var src = new Mat("_data/image/mandrill.png");
            using var dst = new Mat();
            dnn.Upsample(src, dst);

            Assert.False(dst.Empty());
            Assert.True(src.Rows < dst.Rows);
            Assert.True(src.Cols < dst.Cols);

            ShowImagesWhenDebugMode(src, dst);
        }

        [Theory]
        [InlineData("edsr")]
        [InlineData("espcn")]
        [InlineData("fsrcnn")]
        [InlineData("lapsrn")]
        public void GetAlgorithm(string algorithm)
        {
            using var dnn = new DnnSuperResImpl(algorithm, 2);
            Assert.Equal(algorithm, dnn.GetAlgorithm());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetScale(int scale)
        {
            using var dnn = new DnnSuperResImpl("edsr", scale);
            Assert.Equal(scale, dnn.GetScale());
        }
    }
}
