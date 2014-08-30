using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Detect edges
    /// </summary>
    class Edge
    {        
        public Edge()
        {
            using (var src = new IplImage(FilePath.Image.Lenna, LoadMode.Color))
            using (var gray = new IplImage(src.Size, BitDepth.U8, 1))
            using (var temp = new IplImage(src.Size, BitDepth.S16, 1))
            using (var dstSobel = new IplImage(src.Size, BitDepth.U8, 1))
            using (var dstLaplace = new IplImage(src.Size, BitDepth.U8, 1))
            using (var dstCanny = new IplImage(src.Size, BitDepth.U8, 1))
            {
                //src.CvtColor(gray, ColorConversion.RgbToGray);
                src.CvtColor(gray, ColorConversion.BgrToGray);

                // Sobel
                Cv.Sobel(gray, temp, 1, 0, ApertureSize.Size3);
                Cv.ConvertScaleAbs(temp, dstSobel);

                // Laplace
                Cv.Laplace(gray, temp);
                Cv.ConvertScaleAbs(temp, dstLaplace);

                // Canny
                Cv.Canny(gray, dstCanny, 50, 200, ApertureSize.Size3);

                using (new CvWindow("src", src)) 
                using (new CvWindow("sobel", dstSobel))
                using (new CvWindow("laplace", dstLaplace)) 
                using (new CvWindow("canny", dstCanny))
                {
                    CvWindow.WaitKey();
                }

                dstSobel.SaveImage("sobel.png");
                dstLaplace.SaveImage("laplace.png");
                dstCanny.SaveImage("canny.png");
            }
        }
    }
}
