using System;
using System.Collections.Generic;

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
    /// <summary>
    /// 
    /// </summary>
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
        public static void PerformOne(LabelData labels, CvBlob blob, Mat imgSrc, Mat imgDst,
            RenderBlobsModes mode, Scalar color, double alpha)
        {
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (blob == null)
                throw new ArgumentNullException(nameof(blob));
            if (imgSrc == null)
                throw new ArgumentNullException(nameof(imgSrc));
            if (imgDst == null)
                throw new ArgumentNullException(nameof(imgDst));
            if (imgDst.Type() != MatType.CV_8UC3)
                throw new ArgumentException("'img' must be a 3-channel U8 image.");

            if ((mode & RenderBlobsModes.Color) == RenderBlobsModes.Color)
            {
                var pSrc = imgSrc.GetGenericIndexer<Vec3b>();
                var pDst = imgDst.GetGenericIndexer<Vec3b>();

                for (int r = blob.MinY; r <= blob.MaxY; r++)
                {
                    for (int c = blob.MinX; c <= blob.MaxX; c++)
                    {
                        if (labels[r, c] == blob.Label)
                        {
                            byte v0 = (byte) ((1.0 - alpha)*pSrc[r, c].Item0 + alpha*color.Val0);
                            byte v1 = (byte) ((1.0 - alpha)*pSrc[r, c].Item1 + alpha*color.Val1);
                            byte v2 = (byte) ((1.0 - alpha)*pSrc[r, c].Item2 + alpha*color.Val2);
                            pDst[r, c] = new Vec3b(v0, v1, v2);
                        }
                    }
                }
            }

            if (mode != RenderBlobsModes.None)
            {
                if ((mode & RenderBlobsModes.BoundingBox) == RenderBlobsModes.BoundingBox)
                {
                    Cv2.Rectangle(
                        imgDst,
                        new Point(blob.MinX, blob.MinY),
                        new Point(blob.MaxX, blob.MaxY),
                        new Scalar(255, 0, 0));
                }
                if ((mode & RenderBlobsModes.Angle) == RenderBlobsModes.Angle)
                {
                    double angle = blob.Angle();
                    double lengthLine = Math.Max(blob.MaxX - blob.MinX, blob.MaxY - blob.MinY) / 2.0;
                    double x1 = blob.Centroid.X - lengthLine * Math.Cos(angle);
                    double y1 = blob.Centroid.Y - lengthLine * Math.Sin(angle);
                    double x2 = blob.Centroid.X + lengthLine * Math.Cos(angle);
                    double y2 = blob.Centroid.Y + lengthLine * Math.Sin(angle);
                    Cv2.Line(imgDst, new Point((int)x1, (int)y1), new Point((int)x2, (int)y2),
                        new Scalar(0, 255, 0));
                }
                if ((mode & RenderBlobsModes.Centroid) == RenderBlobsModes.Centroid)
                {
                    Cv2.Line(imgDst,
                        new Point((int)blob.Centroid.X - 3, (int)blob.Centroid.Y),
                        new Point((int)blob.Centroid.X + 3, (int)blob.Centroid.Y),
                        new Scalar(255, 0, 0));
                    Cv2.Line(imgDst,
                        new Point((int)blob.Centroid.X, (int)blob.Centroid.Y - 3),
                        new Point((int)blob.Centroid.X, (int)blob.Centroid.Y + 3),
                        new Scalar(255, 0, 0));
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
        public static void PerformMany(CvBlobs blobs, Mat imgSrc, Mat imgDst, RenderBlobsModes mode, double alpha)
        {
            if (blobs == null)
                throw new ArgumentNullException(nameof(blobs));
            if (imgSrc == null)
                throw new ArgumentNullException(nameof(imgSrc));
            if (imgDst == null)
                throw new ArgumentNullException(nameof(imgDst));
            if (imgDst.Type() != MatType.CV_8UC3)
                throw new ArgumentException("'img' must be a 3-channel U8 image.");
            if (blobs.Labels == null)
                throw new NotSupportedException("blobs.Labels == null");

            var palette = new Dictionary<int, Scalar>();
            if ((mode & RenderBlobsModes.Color) == RenderBlobsModes.Color)
            {
                int colorCount = 0;
                foreach (var kv in blobs)
                {
                    Hsv2Rgb((colorCount*77) % 360, 0.5, 1.0, out var r, out var g, out var b);
                    colorCount++;
                    palette[kv.Key] = new Scalar(b, g, r);
                }
            }

            foreach (var kv in blobs)
            {
                Scalar color = default;
                if (palette.ContainsKey(kv.Key))
                    color = palette[kv.Key];
                PerformOne(blobs.Labels, kv.Value, imgSrc, imgDst, mode, color, alpha);
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
