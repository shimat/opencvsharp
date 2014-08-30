using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Blob; // for blob
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// c# implementation of cvblob/test/test.cpp.
    /// cvblob : http://code.google.com/p/cvblob/
    /// </summary>
    internal class Blob
    {
        public Blob()
        {
            using (var imgSrc = new IplImage(FilePath.Image.Shapes, LoadMode.Color))
            using (var imgBinary = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (var imgRender = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (var imgContour = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            using (var imgPolygon = new IplImage(imgSrc.Size, BitDepth.U8, 3))
            {
                Cv.CvtColor(imgSrc, imgBinary, ColorConversion.BgrToGray);
                Cv.Threshold(imgBinary, imgBinary, 100, 255, ThresholdType.Binary);

                CvBlobs blobs = new CvBlobs();
                blobs.Label(imgBinary);

                foreach (KeyValuePair<int, CvBlob> item in blobs)
                {
                    CvBlob b = item.Value;
                    Console.WriteLine("{0} | Centroid:{1} Area:{2}", item.Key, b.Centroid, b.Area);

                    CvContourChainCode cc = b.Contour;
                    cc.Render(imgContour);

                    CvContourPolygon polygon = cc.ConvertToPolygon();
                    foreach (CvPoint p in polygon)
                    {
                        imgPolygon.Circle(p, 1, CvColor.Red, -1);
                    }

                    /*
                    CvPoint2D32f circleCenter;
                    float circleRadius;
                    GetEnclosingCircle(polygon, out circleCenter, out circleRadius);
                    imgPolygon.Circle(circleCenter, (int) circleRadius, CvColor.Green, 2);
                    */
                }

                blobs.RenderBlobs(imgSrc, imgRender);

                using (new CvWindow("render", imgRender))
                using (new CvWindow("contour", imgContour))
                using (new CvWindow("polygon vertices", imgPolygon))
                {
                    Cv.WaitKey(0);
                }
            }
        }

        private void GetEnclosingCircle(
            IEnumerable<CvPoint> points, out CvPoint2D32f center, out float radius)
        {
            var pointsArray = points.ToArray();
            using (var pointsMat = new CvMat(pointsArray.Length, 1, MatrixType.S32C2, pointsArray))
            {
                Cv.MinEnclosingCircle(pointsMat, out center, out radius);
            }
        }
    }
}
