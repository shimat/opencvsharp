using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Blob;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// cvConvextyDefects sample
    /// </summary>
    class ConvexityDefect
    {
        public ConvexityDefect()
        {
            using (IplImage imgSrc = new IplImage(Const.ImageHand, LoadMode.Color))
            using (IplImage imgHSV = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (IplImage imgH = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgS = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgV = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgBackProjection = new IplImage(imgSrc.Size, BitDepth.U8, 1))     
            using (IplImage imgFlesh = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgHull = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgDefect = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (IplImage imgContour = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (CvMemStorage storage = new CvMemStorage())
            {
                // RGB -> HSV
                Cv.CvtColor(imgSrc, imgHSV, ColorConversion.BgrToHsv);
                Cv.CvtPixToPlane(imgHSV, imgH, imgS, imgV, null);
                IplImage[] hsvPlanes = { imgH, imgS, imgV };

                // 肌色領域を求める
                RetrieveFleshRegion(imgSrc, hsvPlanes, imgBackProjection);
                // 最大の面積の領域を残す
                FilterByMaximalBlob(imgBackProjection, imgFlesh);
                Interpolate(imgFlesh);

                // 輪郭を求める
                CvSeq<CvPoint> contours = FindContours(imgFlesh, storage);
                if (contours != null)
                {
                    Cv.DrawContours(imgContour, contours, CvColor.Red, CvColor.Green, 0, 3, LineType.AntiAlias);

                    // 凸包を求める
                    int[] hull;
                    Cv.ConvexHull2(contours, out hull, ConvexHullOrientation.Clockwise);
                    Cv.Copy(imgFlesh, imgHull);
                    DrawConvexHull(contours, hull, imgHull);

                    // 凹状欠損を求める
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
        /// バックプロジェクションにより肌色領域を求める
        /// </summary>
        /// <param name="imgSrc"></param>
        /// <param name="hsvPlanes"></param>
        /// <param name="imgRender"></param>
        private void RetrieveFleshRegion(IplImage imgSrc, IplImage[] hsvPlanes, IplImage imgDst)
        {
            int[] histSize = new int[] { 30, 32 };
            float[] hRanges = { 0.0f, 20f };
            float[] sRanges = { 50f, 255f };
            float[][] ranges = { hRanges, sRanges };

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
        /// ラベリングにより最大の面積の領域を残す
        /// </summary>
        /// <param name="imgSrc"></param>
        /// <param name="imgRender"></param>
        private void FilterByMaximalBlob(IplImage imgSrc, IplImage imgDst)
        {
            using (CvBlobs blobs = new CvBlobs())
            using (IplImage imgLabelData = new IplImage(imgSrc.Size, CvBlobLib.DepthLabel, 1))
            {
                imgDst.Zero();
                blobs.Label(imgSrc, imgLabelData);
                CvBlob max = blobs[blobs.GreaterBlob()];
                if (max == null)
                {
                    return;
                }
                blobs.FilterByArea(max.Area, max.Area);
                blobs.FilterLabels(imgLabelData, imgDst);
            }
        }
        /// <summary>
        /// 欠損領域を補完する
        /// </summary>
        /// <param name="img"></param>
        private void Interpolate(IplImage img)
        {
            Cv.Dilate(img, img, null, 2);
            Cv.Erode(img, img, null, 2);
        }
        /// <summary>
        /// 輪郭を得る
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
