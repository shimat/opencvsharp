using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp.XImgProc;
using Xunit;

namespace OpenCvSharp.Tests.XImgProc
{
    public class FastHoughTransformTest : TestBase
    {
        /// <remarks>
        /// https://github.com/opencv/opencv_contrib/blob/master/modules/ximgproc/samples/fast_hough_transform.cpp#L271
        /// </remarks>
        [Fact]
        public void FastHoughTransform()
        {
            using (var image = Image("building.jpg", ImreadModes.Grayscale))
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

        /// <summary>
        /// https://github.com/opencv/opencv_contrib/blob/master/modules/ximgproc/samples/fast_hough_transform.cpp
        /// </summary>
        [Fact]
        public void FHTSample()
        {
            const string imPath = @"_data/image/building.jpg";
            using (var image = new Mat(imPath, ImreadModes.Grayscale))
            using (var hough = new Mat())
            using (var canny = new Mat())
            {
                Cv2.Canny(image, canny, 50, 200, 3);

                CvXImgProc.FastHoughTransform(canny, hough, MatType.CV_32S/*C1*/, AngleRangeOption.ARO_315_135, HoughOP.FHT_ADD, HoughDeskewOption.DESKEW);

                var lines = new List<Vec4i>();
                GetLocalExtr(lines, canny, hough, 255f * 0.3f * Math.Min(canny.Rows, canny.Cols), 50);

                var cannyColor = new Mat();
                Cv2.CvtColor(canny, cannyColor, ColorConversionCodes.GRAY2BGR);
                for (var i = 0; i < lines.Count; i++)
                {
                    var line = lines[i];
                    Cv2.Line(cannyColor, new Point(line.Item0, line.Item1), new Point(line.Item2, line.Item3), Scalar.Red);
                }
                //cannyColor.SaveImage("cannycolor.png");

                ShowImagesWhenDebugMode(image, canny, cannyColor);
            }

            bool GetLocalExtr(List<Vec4i> lines, Mat src, Mat fht, float minWeight, int maxCount)
            {
                const int MAX_LEN = 10_000;
                var weightedPoints = new List<KeyValuePair<int, Point>>();
                for (var y = 0; y < fht.Rows; ++y)
                {
                    if (weightedPoints.Count > MAX_LEN)
                        break;

                    var fhtMat = new Mat<int>(fht);
                    var fhtIndexer = fhtMat.GetIndexer();

                    var pLineY = Math.Max(y - 1, 0);
                    var cLineY = y;
                    var nLineY = Math.Min(y + 1, fht.Rows - 1);

                    for (var x = 0; x < fht.Cols; ++x)
                    {
                        if (weightedPoints.Count > MAX_LEN)
                            break;

                        var value = fhtIndexer[cLineY, x];
                        if (value >= minWeight)
                        {
                            var isLocalMax = 0;
                            var start = Math.Max(x - 1, 0);
                            var end = Math.Min(x + 1, fht.Cols - 1);
                            for (var xx = start; xx < end; ++xx)
                            {
                                var pLine = fhtIndexer[pLineY, xx];
                                var cLine = fhtIndexer[cLineY, xx];
                                var nLine = fhtIndexer[nLineY, xx];
                                if (!incIfGreater(value, pLine, ref isLocalMax) ||
                                    !incIfGreater(value, cLine, ref isLocalMax) ||
                                    !incIfGreater(value, nLine, ref isLocalMax))
                                {
                                    isLocalMax = 0;
                                    break;
                                }
                            }
                            if (isLocalMax > 0)
                                weightedPoints.Add(new KeyValuePair<int, Point>(value, new Point(x, y)));
                        }
                    }
                }

                if (weightedPoints.Count == 0)
                    return true;

                // Sort WeightedPoints
                weightedPoints = weightedPoints.OrderByDescending(x => x.Key).ToList();
                weightedPoints = weightedPoints.Take(maxCount).ToList();

                for (var i = 0; i < weightedPoints.Count; i++)
                    lines.Add(CvXImgProc.HoughPoint2Line(weightedPoints[i].Value, src));

                return true;
            }

            bool incIfGreater(int a, int b, ref int value)
            {
                if (/*value == 0 || */a < b)
                    return false;
                if (a > b)
                    ++(value);
                return true;
            }
        }
    }
}

