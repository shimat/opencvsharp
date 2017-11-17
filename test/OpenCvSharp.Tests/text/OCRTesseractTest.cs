using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OpenCvSharp.Text;
using Xunit;

namespace OpenCvSharp.Tests.Text
{
    // ReSharper disable once InconsistentNaming
    
    public class OCRTesseractTest : TestBase
    {
        private const string TessData = @"_data\tessdata";

        [Fact]
        public void Create()
        {
            using (var tesseract = OCRTesseract.Create(TessData))
            {
                GC.KeepAlive(tesseract);
            }
        }

        [Fact]
        public void Run()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            using (var image = Image("alphabet.png"))
            using (var tesseract = OCRTesseract.Create(TessData))
            {
                tesseract.Run(image,
                    out var outputText, out var componentRects, out var componentTexts, out var componentConfidences);

                Console.WriteLine(outputText);
                Assert.NotEmpty(outputText);
            }
        }
    }
}
