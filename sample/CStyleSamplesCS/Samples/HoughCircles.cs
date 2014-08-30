using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Circle detection using Hough algorithm
    /// </summary>
    class HoughCircles
    {
        public HoughCircles()
        {
            using (IplImage imgSrc = new IplImage(FilePath.Image.Walkman, LoadMode.Color))
            using (IplImage imgGray = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgHough = imgSrc.Clone())
            {
                Cv.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray);
                Cv.Smooth(imgGray, imgGray, SmoothType.Gaussian, 9);
                //Cv.Canny(imgGray, imgGray, 75, 150, ApertureSize.Size3);

                using (var storage = new CvMemStorage())
                {
                    CvSeq<CvCircleSegment> seq = imgGray.HoughCircles(storage, HoughCirclesMethod.Gradient, 1, 100, 150, 55, 0, 0);
                    foreach (CvCircleSegment item in seq)
                    {
                        imgHough.Circle(item.Center, (int)item.Radius, CvColor.Red, 3);
                    }
                }

                using (new CvWindow("gray", WindowMode.AutoSize, imgGray))
                using (new CvWindow("Hough circles", WindowMode.AutoSize, imgHough))
                {
                    CvWindow.WaitKey(0);
                }
            }
        }
    }
}
