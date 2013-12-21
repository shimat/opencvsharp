using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// SURF(Speeded Up Robust Features)による対応点検出        
    /// </summary>
    /// <remarks>samples/c/find_obj.cpp から改変</remarks>
    internal class SURFSample
    {
        public SURFSample()
        {
            // cvExtractSURF
            // SURFで対応点検出            


            // call cv::initModule_nonfree() before using SURF/SIFT.
            CvCpp.InitModule_NonFree();


            using (IplImage obj = Cv.LoadImage(Const.ImageSurfBox, LoadMode.GrayScale))
            using (IplImage image = Cv.LoadImage(Const.ImageSurfBoxinscene, LoadMode.GrayScale))
            using (IplImage objColor = Cv.CreateImage(obj.Size, BitDepth.U8, 3))
            using (IplImage correspond = Cv.CreateImage(new CvSize(image.Width, obj.Height + image.Height), BitDepth.U8, 1))
            {
                Cv.CvtColor(obj, objColor, ColorConversion.GrayToBgr);

                Cv.SetImageROI(correspond, new CvRect(0, 0, obj.Width, obj.Height));
                Cv.Copy(obj, correspond);
                Cv.SetImageROI(correspond, new CvRect(0, obj.Height, correspond.Width, correspond.Height));
                Cv.Copy(image, correspond);
                Cv.ResetImageROI(correspond);

                // SURFの処理
                CvSURFPoint[] objectKeypoints, imageKeypoints;
                float[][] objectDescriptors, imageDescriptors;
                Stopwatch watch = Stopwatch.StartNew();
                {
                    CvSURFParams param = new CvSURFParams(500, true);
                    Cv.ExtractSURF(obj, null, out objectKeypoints, out objectDescriptors, param);
                    Console.WriteLine("Object Descriptors: {0}", objectDescriptors.Length);
                    Cv.ExtractSURF(image, null, out imageKeypoints, out imageDescriptors, param);
                    Console.WriteLine("Image Descriptors: {0}", imageDescriptors.Length);
                }
                watch.Stop();
                Console.WriteLine("Extraction time = {0}ms", watch.ElapsedMilliseconds);
                watch.Reset();
                watch.Start();

                // シーン画像にある局所画像の領域を線で囲む
                CvPoint[] srcCorners = new CvPoint[4]
                    {
                        new CvPoint(0, 0), new CvPoint(obj.Width, 0), new CvPoint(obj.Width, obj.Height), new CvPoint(0, obj.Height)
                    };
                CvPoint[] dstCorners = LocatePlanarObject(objectKeypoints, objectDescriptors, imageKeypoints, imageDescriptors, srcCorners);
                if (dstCorners != null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        CvPoint r1 = dstCorners[i%4];
                        CvPoint r2 = dstCorners[(i + 1)%4];
                        Cv.Line(correspond, new CvPoint(r1.X, r1.Y + obj.Height), new CvPoint(r2.X, r2.Y + obj.Height), CvColor.White);
                    }
                }

                // 対応点同士を線で引く
                int[] ptPairs = FindPairs(objectKeypoints, objectDescriptors, imageKeypoints, imageDescriptors);
                for (int i = 0; i < ptPairs.Length; i += 2)
                {
                    CvSURFPoint r1 = objectKeypoints[ptPairs[i]];
                    CvSURFPoint r2 = imageKeypoints[ptPairs[i + 1]];
                    Cv.Line(correspond, r1.Pt, new CvPoint(Cv.Round(r2.Pt.X), Cv.Round(r2.Pt.Y + obj.Height)), CvColor.White);
                }

                // 特徴点の場所に円を描く
                for (int i = 0; i < objectKeypoints.Length; i++)
                {
                    CvSURFPoint r = objectKeypoints[i];
                    CvPoint center = new CvPoint(Cv.Round(r.Pt.X), Cv.Round(r.Pt.Y));
                    int radius = Cv.Round(r.Size*(1.2/9.0)*2);
                    Cv.Circle(objColor, center, radius, CvColor.Red, 1, LineType.AntiAlias, 0);
                }
                watch.Stop();
                Console.WriteLine("Drawing time = {0}ms", watch.ElapsedMilliseconds);

                // ウィンドウに表示
                using (CvWindow windowObject = new CvWindow("Object", WindowMode.AutoSize))
                using (CvWindow windowCorrespond = new CvWindow("Object Correspond", WindowMode.AutoSize))
                {
                    windowObject.ShowImage(correspond);
                    windowCorrespond.ShowImage(objColor);
                    Cv.WaitKey(0);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d1">Cではconst float*</param>
        /// <param name="d2">Cではconst float*</param>
        /// <param name="best"></param>
        /// <returns></returns>
        private static double CompareSurfDescriptors(float[] d1, float[] d2, double best)
        {
            Debug.Assert(d1.Length % 4 == 0);
            Debug.Assert(d1.Length == d2.Length);

            double totalCost = 0;

            for (int i = 0; i < d1.Length; i += 4)
            {
                double t0 = d1[i] - d2[i];
                double t1 = d1[i + 1] - d2[i + 1];
                double t2 = d1[i + 2] - d2[i + 2];
                double t3 = d1[i + 3] - d2[i + 3];
                totalCost += t0*t0 + t1*t1 + t2*t2 + t3*t3;
                if (totalCost > best)
                    break;
            }

            return totalCost;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec">Cではconst float*</param>
        /// <param name="laplacian"></param>
        /// <param name="modelKeypoints"></param>
        /// <param name="modelDescriptors"></param>
        /// <returns></returns>
        private static int NaiveNearestNeighbor(float[] vec, int laplacian, CvSURFPoint[] modelKeypoints, float[][] modelDescriptors)
        {
            int neighbor = -1;
            double dist1 = 1e6, dist2 = 1e6;

            for (int i = 0; i < modelDescriptors.Length; i++)
            {
                // const CvSURFPoint* kp = (const CvSURFPoint*)kreader.ptr;
                CvSURFPoint kp = modelKeypoints[i];

                if (laplacian != kp.Laplacian)
                    continue;

                double d = CompareSurfDescriptors(vec, modelDescriptors[i], dist2);
                if (d < dist1)
                {
                    dist2 = dist1;
                    dist1 = d;
                    neighbor = i;
                }
                else if (d < dist2)
                    dist2 = d;
            }
            if (dist1 < 0.6*dist2)
                return neighbor;
            else
                return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectKeypoints"></param>
        /// <param name="objectDescriptors"></param>
        /// <param name="imageKeypoints"></param>
        /// <param name="imageDescriptors"></param>
        /// <returns></returns>
        private static int[] FindPairs(CvSURFPoint[] objectKeypoints, float[][] objectDescriptors, CvSURFPoint[] imageKeypoints, float[][] imageDescriptors)
        {
            List<int> ptPairs = new List<int>();

            for (int i = 0; i < objectDescriptors.Length; i++)
            {
                CvSURFPoint kp = objectKeypoints[i];
                int nearestNeighbor = NaiveNearestNeighbor(objectDescriptors[i], kp.Laplacian, imageKeypoints, imageDescriptors);
                if (nearestNeighbor >= 0)
                {
                    ptPairs.Add(i);
                    ptPairs.Add(nearestNeighbor);
                }
            }
            return ptPairs.ToArray();
        }

        /// <summary>
        /// a rough implementation for object location
        /// </summary>
        /// <param name="objectKeypoints"></param>
        /// <param name="objectDescriptors"></param>
        /// <param name="imageKeypoints"></param>
        /// <param name="imageDescriptors"></param>
        /// <param name="srcCorners"></param>
        /// <returns></returns>
        private static CvPoint[] LocatePlanarObject(CvSURFPoint[] objectKeypoints,
                                                    float[][] objectDescriptors,
                                                    CvSURFPoint[] imageKeypoints,
                                                    float[][] imageDescriptors,
                                                    CvPoint[] srcCorners)
        {
            CvMat h = new CvMat(3, 3, MatrixType.F64C1);
            int[] ptpairs = FindPairs(objectKeypoints, objectDescriptors, imageKeypoints, imageDescriptors);
            int n = ptpairs.Length/2;
            if (n < 4)
                return null;

            CvPoint2D32f[] pt1 = new CvPoint2D32f[n];
            CvPoint2D32f[] pt2 = new CvPoint2D32f[n];
            for (int i = 0; i < n; i++)
            {
                pt1[i] = objectKeypoints[ptpairs[i*2]].Pt;
                pt2[i] = imageKeypoints[ptpairs[i*2 + 1]].Pt;
            }

            CvMat pt1Mat = new CvMat(1, n, MatrixType.F32C2, pt1);
            CvMat pt2Mat = new CvMat(1, n, MatrixType.F32C2, pt2);
            if (Cv.FindHomography(pt1Mat, pt2Mat, h, HomographyMethod.Ransac, 5) == 0)
                return null;

            CvPoint[] dstCorners = new CvPoint[4];
            for (int i = 0; i < 4; i++)
            {
                double x = srcCorners[i].X;
                double y = srcCorners[i].Y;
                double Z = 1.0/(h[6]*x + h[7]*y + h[8]);
                double X = (h[0]*x + h[1]*y + h[2])*Z;
                double Y = (h[3]*x + h[4]*y + h[5])*Z;
                dstCorners[i] = new CvPoint(Cv.Round(X), Cv.Round(Y));
            }

            return dstCorners;
        }

    }
}
