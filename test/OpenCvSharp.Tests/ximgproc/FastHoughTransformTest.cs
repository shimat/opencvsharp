using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp.XImgProc;

namespace OpenCvSharp.Tests.XImgProc
{
    [TestFixture]
    public class FastHoughTransformTest : TestBase
    {
        /// <remarks>
        /// https://github.com/opencv/opencv_contrib/blob/master/modules/ximgproc/samples/fast_hough_transform.cpp#L271
        /// </remarks>
        [Test]
        public void FastHoughTransform()
        {
            using (var image = Image("building.jpg", ImreadModes.GrayScale))
            using (var fht = new Mat())
            {
                CvXImgProc.FastHoughTransform(image, fht, MatType.CV_32SC1);

                double minv, maxv;
                Cv2.MinMaxLoc(fht, out minv, out maxv);

                Mat ucharFht = new Mat();
                fht.ConvertTo(ucharFht, MatType.CV_8UC1,
                  255.0 / (maxv + minv), minv / (maxv + minv));
                Rescale(ucharFht, ucharFht);

                //Cv2.ImShow("fast hough transform", ucharFht);
                //Cv2.WaitKey();
            }
        }

        private static void Rescale(Mat src, Mat dst,
                            int maxHeight = 500,
                            int maxWidth = 1000)
        {
            double scale = Math.Min(Math.Min((double)maxWidth / src.Cols,
                                   (double)maxHeight / src.Rows), 1.0);
            Cv2.Resize(src, dst, new Size(), scale, scale, InterpolationFlags.Linear);
        }
    }
}

