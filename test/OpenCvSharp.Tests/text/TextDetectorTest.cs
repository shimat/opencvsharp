using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OpenCvSharp.Text;
using Xunit;

namespace OpenCvSharp.Tests.Text
{
    public class TextDetectorTest : TestBase
    {
        const string modelArch = "_data/text/textbox.prototxt";
        const string moddelWeights = "TextBoxes_icdar13.caffemodel";
        const string moddelWeightsUrl = "https://www.dropbox.com/s/g8pjzv2de9gty8g/TextBoxes_icdar13.caffemodel?dl=0";

        public TextDetectorTest()
        {
            
        }

        [Fact]
        public void Create()
        {
            using (var detector = TextDetectorCNN.Create(modelArch, ""))
            {
                GC.KeepAlive(            using (var detector = TextDetectorCNN.Create(modelArch, ""))
                    );
            }
        }
    }
}
