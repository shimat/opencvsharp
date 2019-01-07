using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using OpenCvSharp.Text;
using Xunit;

namespace OpenCvSharp.Tests.Text
{
    public class TextDetectorTest : TestBase
    {
        const string modelArch = "_data/text/textbox.prototxt";
        const string modelWeights = "TextBoxes_icdar13.caffemodel";
        const string modelWeightsUrl = "https://www.dropbox.com/s/g8pjzv2de9gty8g/TextBoxes_icdar13.caffemodel?dl=0";

        public TextDetectorTest()
        {
            if (!File.Exists(modelWeights))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(modelWeightsUrl, modelWeights);
                }
            }
        }

        [Fact]
        public void Create()
        {
            Assert.True(File.Exists(modelArch), $"modelArch '{modelArch}' not found");
            Assert.True(File.Exists(modelWeights), $"modelWeights '{modelWeights}' not found");

            using (var detector = TextDetectorCNN.Create(modelArch, modelWeights))
            {
                GC.KeepAlive(detector);
            }
        }
    }
}
