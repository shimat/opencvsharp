using System;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.Blob;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// cvConvextyDefects sample
    /// </summary>
    class ConvexityDefect
    {
        public ConvexityDefect()
        {
            using (var imgSrc = new IplImage(FilePath.Image.Hand, LoadMode.Color))
            using (var imgHSV = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (var imgH = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (var imgS = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (var imgV = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (var imgBackProjection = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (var imgFlesh = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (var imgHull = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (var imgDefect = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (var imgContour = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (var storage = new CvMemStorage())
            {
                // RGB -> HSV
                Cv.CvtColor(imgSrc, imgHSV, ColorConversion.BgrToHsv);
                Cv.CvtPixToPlane(imgHSV, imgH, imgS, imgV, null);
                IplImage[] hsvPlanes = { imgH, imgS, imgV };

                // skin region
                RetrieveFleshRegion(imgSrc, hsvPlanes, imgBackProjection);
                // gets max blob
                FilterByMaximumBlob(imgBackProjection, imgFlesh);
                Interpolate(imgFlesh);

                // find contours of the max blob
                CvSeq<CvPoint> contours = FindContours(imgFlesh, storage);
                if (contours != null)
                {
                    Cv.DrawContours(imgContour, contours, CvColor.Red, CvColor.Green, 0, 3, LineType.AntiAlias);

                    // finds convex hull
                    int[] hull;
                    Cv.ConvexHull2(contours, out hull, ConvexHullOrientation.Clockwise);
                    Cv.Copy(imgFlesh, imgHull);
                    DrawConvexHull(contours, hull, imgHull);

                    // gets convexity defexts
                    Cv.Copy(imgContour, imgDefect);
                    CvSeq<CvConvexityDefect> defect = Cv.ConvexityDefects(contours, hull);
                    DrawDefects(imgDefect, defect);
                }

                using (new CvWindow("src", imgSrc))
                using (new CvWindow("back projection", imgBackProjection))
                using (new CvWindow("hull", imgHull))
                using (new CvWindow("defect", imgDefect))
                {
                    Cv.WaitKey();
                }
            }
        }

        /// <summary>
        /// Gets flesh regions by histogram back projection
        /// </summary>
        /// <param name="imgSrc"></param>
        /// <param name="hsvPlanes"></param>
        /// <param name="imgRender"></param>
        private void RetrieveFleshRegion(IplImage imgSrc, IplImage[] hsvPlanes, IplImage imgDst)
        {
            int[] histSize = new int[] {30, 32};
            float[] hRanges = {0.0f, 20f};
            float[] sRanges = {50f, 255f};
            float[][] ranges = {hRanges, sRanges};

            imgDst.Zero();
            using (CvHistogram hist = new CvHistogram(histSize, HistogramFormat.Array, ranges, true))
            {
                hist.Calc(hsvPlanes, false, null);
                float minValue, maxValue;
                hist.GetMinMaxValue(out minValue, out maxValue);
                hist.Normalize(imgSrc.Width * imgSrc.Height * 255 / maxValue);
                hist.CalcBackProject(hsvPlanes, imgDst);
            }
        }

        /// <summary>
        /// Gets the largest blob
        /// </summary>
        /// <param name="imgSrc"></param>
        /// <param name="imgRender"></param>
        private void FilterByMaximumBlob(IplImage imgSrc, IplImage imgDst)
        {
            CvBlobs blobs = new CvBlobs();

            imgDst.Zero();
            blobs.Label(imgSrc);
            CvBlob max = blobs.GreaterBlob();
            if (max == null)
                return;
            blobs.FilterByArea(max.Area, max.Area);
            blobs.FilterLabels(imgDst);
        }

        /// <summary>
        /// Opening
        /// </summary>
        /// <param name="img"></param>
        private void Interpolate(IplImage img)
        {
            Cv.Dilate(img, img, null, 2);
            Cv.Erode(img, img, null, 2);
        }

        /// <summary>
        /// Find contours
        /// </summary>
        /// <param name="img"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        private CvSeq<CvPoint> FindContours(IplImage img, CvMemStorage storage)
        {
            // 輪郭抽出
            CvSeq<CvPoint> contours;
            using (IplImage imgClone = img.Clone())
            {
                Cv.FindContours(imgClone, storage, out contours);
                if (contours == null)
                {
                    return null;
                }
                contours = Cv.ApproxPoly(contours, CvContour.SizeOf, storage, ApproxPolyMethod.DP, 3, true);
            }
            // 一番長そうな輪郭のみを得る
            CvSeq<CvPoint> max = contours;
            for (CvSeq<CvPoint> c = contours; c != null; c = c.HNext)
            {
                if (max.Total < c.Total)
                {
                    max = c;
                }
            }
            return max;
        }

        /// <summary>
        /// ConvexHullの描画
        /// </summary>
        /// <param name="contours"></param>
        /// <param name="hull"></param>
        /// <param name="img"></param>
        private void DrawConvexHull(CvSeq<CvPoint> contours, int[] hull, IplImage img)
        {
            CvPoint pt0 = contours[hull.Last()].Value;
            foreach (int idx in hull)
            {
                CvPoint pt = contours[idx].Value;
                Cv.Line(img, pt0, pt, new CvColor(255, 255, 255));
                pt0 = pt;
            }
        }

        /// <summary>
        /// ConvexityDefectsの描画
        /// </summary>
        /// <param name="img"></param>
        /// <param name="defect"></param>
        private void DrawDefects(IplImage img, CvSeq<CvConvexityDefect> defect)
        {
            int count = 0;
            foreach (CvConvexityDefect item in defect)
            {
                CvPoint p1 = item.Start, p2 = item.End;
                double dist = GetDistance(p1, p2);
                CvPoint2D64f mid = GetMidpoint(p1, p2);
                img.DrawLine(p1, p2, CvColor.White, 3);
                img.DrawCircle(item.DepthPoint, 10, CvColor.Green, -1);
                img.DrawLine(mid, item.DepthPoint, CvColor.White, 1);   
                Console.WriteLine("No:{0} Depth:{1} Dist:{2}", count, item.Depth, dist);
                count++;
            }
        }

        /// <summary>
        /// 2点間の距離を得る
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private double GetDistance(CvPoint p1, CvPoint p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        /// <summary>
        /// 2点の中点を得る
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private CvPoint2D64f GetMidpoint(CvPoint p1, CvPoint p2)
        {
            return new CvPoint2D64f
            {
                X = (p1.X + p2.X) / 2.0,
                Y = (p1.Y + p2.Y) / 2.0
            };
        }
    }
}
