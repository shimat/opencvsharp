using System;
using System.Collections.Generic;
using System.Text;

// Copyright (C) 2007 by Cristóbal Carnero Liñán
// grendel.ccl@gmail.com
//
// This file is part of cvBlob.
//
// cvBlob is free software: you can redistribute it and/or modify
// it under the terms of the Lesser GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// cvBlob is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// Lesser GNU General Public License for more details.
//
// You should have received a copy of the Lesser GNU General Public License
// along with cvBlob.  If not, see <http://www.gnu.org/licenses/>.

namespace OpenCvSharp.Blob
{
    internal static class BlobRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="blob"></param>
        /// <param name="imgSrc"></param>
        /// <param name="imgDst"></param>
        /// <param name="mode"></param>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        public static unsafe void PerformOne(LabelData labels, CvBlob blob, IplImage imgSrc, IplImage imgDst,
            RenderBlobsMode mode, CvScalar color, double alpha)
        {
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (blob == null)
                throw new ArgumentNullException("blob");
            if (imgSrc == null)
                throw new ArgumentNullException("imgSrc");
            if (imgDst == null)
                throw new ArgumentNullException("imgDst");
            if (imgDst.Depth != BitDepth.U8 || imgDst.NChannels != 3)
                throw new ArgumentException("'img' must be a 3-channel U8 image.");

            if ((mode & RenderBlobsMode.Color) == RenderBlobsMode.Color)
            {
                int stepSrc = imgSrc.WidthStep;
                int stepDst = imgDst.WidthStep;
                int offsetSrc = 0;
                int offsetDst = 0;
                CvRect roiSrc = imgSrc.ROI;
                CvRect roiDst = imgDst.ROI;
                if (roiSrc.Size != imgSrc.Size)
                    offsetSrc = roiSrc.Y * stepSrc + roiSrc.X;
                if (roiDst.Size != imgDst.Size)
                    offsetDst = roiDst.Y * stepDst + roiDst.X;
                byte* pSrc = (byte*)imgSrc.ImageData + offsetSrc + (blob.MinY * stepSrc);
                byte* pDst = (byte*)imgDst.ImageData + offsetDst + (blob.MinY * stepDst);

                for (int r = blob.MinY; r < blob.MaxY; r++)
                {
                    for (int c = blob.MinX; c < blob.MaxX; c++)
                    {
                        if (labels[r, c] == blob.Label)
                        {
                            pDst[c*3 + 0] = (byte) ((1.0 - alpha)*pSrc[c + 0] + alpha*color.Val0);
                            pDst[c*3 + 1] = (byte) ((1.0 - alpha)*pSrc[c + 1] + alpha*color.Val1);
                            pDst[c*3 + 2] = (byte) ((1.0 - alpha)*pSrc[c + 2] + alpha*color.Val2);
                        }
                    }
                    pSrc += stepSrc;
                    pDst += stepDst;
                }
            }

            if (mode != RenderBlobsMode.None)
            {
                if ((mode & RenderBlobsMode.BoundingBox) == RenderBlobsMode.BoundingBox)
                {
                    Cv.Rectangle(
                        imgDst,
                        new CvPoint(blob.MinX, blob.MinY),
                        new CvPoint(blob.MaxX - 1, blob.MaxY - 1),
                        new CvColor(255, 0, 0));
                }
                if ((mode & RenderBlobsMode.Angle) == RenderBlobsMode.Angle)
                {
                    double angle = CvBlobLib.Angle(blob);
                    double lengthLine = Math.Max(blob.MaxX - blob.MinX, blob.MaxY - blob.MinY) / 2.0;
                    double x1 = blob.Centroid.X - lengthLine * Math.Cos(angle);
                    double y1 = blob.Centroid.Y - lengthLine * Math.Sin(angle);
                    double x2 = blob.Centroid.X + lengthLine * Math.Cos(angle);
                    double y2 = blob.Centroid.Y + lengthLine * Math.Sin(angle);
                    Cv.Line(imgDst, new CvPoint((int)x1, (int)y1), Cv.Point((int)x2, (int)y2),
                        new CvColor(0, 255, 0));
                }
                if ((mode & RenderBlobsMode.Centroid) == RenderBlobsMode.Centroid)
                {
                    Cv.Line(imgDst,
                        new CvPoint((int)blob.Centroid.X - 3, (int)blob.Centroid.Y),
                        new CvPoint((int)blob.Centroid.X + 3, (int)blob.Centroid.Y),
                        new CvColor(0, 0, 255));
                    Cv.Line(imgDst,
                        new CvPoint((int)blob.Centroid.X, (int)blob.Centroid.Y - 3),
                        new CvPoint((int)blob.Centroid.X, (int)blob.Centroid.Y + 3),
                        new CvColor(0, 0, 255));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blobs"></param>
        /// <param name="imgSrc"></param>
        /// <param name="imgDst"></param>
        /// <param name="mode"></param>
        /// <param name="alpha"></param>
        public static void PerformMany(CvBlobs blobs, IplImage imgSrc, IplImage imgDst, RenderBlobsMode mode, double alpha)
        {
            if (blobs == null)
                throw new ArgumentNullException("blobs");
            if (imgSrc == null)
                throw new ArgumentNullException("imgSrc");
            if (imgDst == null)
                throw new ArgumentNullException("imgDst");
            if (imgDst.Depth != BitDepth.U8 || imgDst.NChannels != 3)
                throw new ArgumentException("'img' must be a 3-channel U8 image.");

            var palette = new Dictionary<int, CvColor>();
            if ((mode & RenderBlobsMode.Color) == RenderBlobsMode.Color)
            {
                int colorCount = 0;
                foreach (var kv in blobs)
                {
                    double r, g, b;
                    Hsv2Rgb((colorCount*77) % 360, 0.5, 1.0, out r, out g, out b);
                    colorCount++;
                    palette[kv.Key] = new CvColor((int)r, (int)g, (int)b);
                }
            }

            foreach (var kv in blobs)
            {
                PerformOne(blobs.Labels, kv.Value, imgSrc, imgDst, mode, palette[kv.Key], alpha);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="v"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        private static void Hsv2Rgb(double h, double s, double v, out double r, out double g, out double b)
        {
            double hh = h / 60.0;
            int hf = (int)Math.Floor(hh);
            int hi = ((int)hh) % 6;
            double f = hh - hf;

            double p = v * (1.0 - s);
            double q = v * (1.0 - f * s);
            double t = v * (1.0 - (1.0 - f) * s);

            switch (hi)
            {
                case 0:
                    r = 255.0 * v;
                    g = 255.0 * t;
                    b = 255.0 * p;
                    break;
                case 1:
                    r = 255.0 * q;
                    g = 255.0 * v;
                    b = 255.0 * p;
                    break;
                case 2:
                    r = 255.0 * p;
                    g = 255.0 * v;
                    b = 255.0 * t;
                    break;
                case 3:
                    r = 255.0 * p;
                    g = 255.0 * q;
                    b = 255.0 * v;
                    break;
                case 4:
                    r = 255.0 * t;
                    g = 255.0 * p;
                    b = 255.0 * v;
                    break;
                case 5:
                    r = 255.0 * v;
                    g = 255.0 * p;
                    b = 255.0 * q;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
