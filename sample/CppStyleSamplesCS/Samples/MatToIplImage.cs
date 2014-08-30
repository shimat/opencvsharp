using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// Mat -> IplImage
    /// </summary>
    class MatToIplImage : ISample
    {
        public void Run()
        {
            Mat src = new Mat(FilePath.Image.Lenna511, LoadMode.Color);
            Mat src511 = new Mat(FilePath.Image.Lenna511, LoadMode.Color);

            IplImage ipl = (IplImage)src;
            IplImage ipl511 = (IplImage)src511;

            CvWindow.ShowImages(ipl, ipl511);
        }
    }
}