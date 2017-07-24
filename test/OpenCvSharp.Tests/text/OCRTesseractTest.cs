using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenCvSharp.Text;

namespace OpenCvSharp.Tests.Text
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class OCRTesseractTest : TestBase
    {
        [Test]
        public void Create()
        {
            using (var tesseract = OCRTesseract.Create())
            {
            }
        }

        [Test]
        public void Run()
        {
            using (var image = Image("alphabet.png"))
            using (var tesseract = OCRTesseract.Create())
            {
                tesseract.Run(image,
                    out var outputText, out var componentRects, out var componentTexts, out var componentConfidences);

                Console.WriteLine(outputText);
                Assert.IsNotEmpty(outputText);
            }
        }
    }
}
