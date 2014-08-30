using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Line detection using Hough transform
    /// </summary>
    /// <remarks>http://opencv.jp/sample/special_transforms.html#hough_line</remarks>
    class HoughLines
    {
        public HoughLines()
        {
            SampleC();            
        }

        /// <summary>
        /// sample of C style wrapper 
        /// </summary>
        private void SampleC()
        {
            // cvHoughLines2

            using (IplImage srcImgGray = new IplImage(FilePath.Image.Goryokaku, LoadMode.GrayScale))
            using (IplImage srcImgStd = new IplImage(FilePath.Image.Goryokaku, LoadMode.Color))
            using (IplImage srcImgProb = srcImgStd.Clone())
            {
                Cv.Canny(srcImgGray, srcImgGray, 50, 200, ApertureSize.Size3);
                using (CvMemStorage storage = new CvMemStorage())
                {
                    // Standard algorithm
                    CvSeq lines = srcImgGray.HoughLines2(storage, HoughLinesMethod.Standard, 1, Math.PI / 180, 50, 0, 0);
                    // wrapper style
                    //CvLineSegmentPolar[] lines = src_img_gray.HoughLinesStandard(1, Math.PI / 180, 50, 0, 0);

                    int limit = Math.Min(lines.Total, 10);
                    for (int i = 0; i < limit; i++)
                    {
                        // native code style
                        /*
                        unsafe
                        {
                            float* line = (float*)lines.GetElem<IntPtr>(i).Value.ToPointer();
                            float rho = line[0];
                            float theta = line[1];
                        }
                        //*/

                        // wrapper style
                        CvLineSegmentPolar elem = lines.GetSeqElem<CvLineSegmentPolar>(i).Value;
                        float rho = elem.Rho;
                        float theta = elem.Theta;

                        double a = Math.Cos(theta);
                        double b = Math.Sin(theta);
                        double x0 = a * rho;
                        double y0 = b * rho;
                        CvPoint pt1 = new CvPoint { X = Cv.Round(x0 + 1000 * (-b)), Y = Cv.Round(y0 + 1000 * (a)) };
                        CvPoint pt2 = new CvPoint { X = Cv.Round(x0 - 1000 * (-b)), Y = Cv.Round(y0 - 1000 * (a)) };
                        srcImgStd.Line(pt1, pt2, CvColor.Red, 3, LineType.AntiAlias, 0);
                    }

                    // Probabilistic algorithm
                    lines = srcImgGray.HoughLines2(storage, HoughLinesMethod.Probabilistic, 1, Math.PI / 180, 50, 50, 10);
                    // wrapper style
                    //CvLineSegmentPoint[] lines = src_img_gray.HoughLinesProbabilistic(1, Math.PI / 180, 50, 0, 0);

                    for (int i = 0; i < lines.Total; i++)
                    {
                        // native code style
                        /*
                        unsafe
                        {
                            CvPoint* point = (CvPoint*)lines.GetElem<IntPtr>(i).Value.ToPointer();
                            src_img_prob.Line(point[0], point[1], CvColor.Red, 3, LineType.AntiAlias, 0);
                        }
                        //*/

                        // wrapper style
                        CvLineSegmentPoint elem = lines.GetSeqElem<CvLineSegmentPoint>(i).Value;
                        srcImgProb.Line(elem.P1, elem.P2, CvColor.Red, 3, LineType.AntiAlias, 0);
                    }
                }

                using (new CvWindow("Hough_line_standard", WindowMode.AutoSize, srcImgStd))
                using (new CvWindow("Hough_line_probabilistic", WindowMode.AutoSize, srcImgProb))
                {
                    CvWindow.WaitKey(0);
                }
            }
        }
    }
}
