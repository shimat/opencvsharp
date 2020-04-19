using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// <summary>
    /// Polygon based contour.
    /// </summary>
#pragma warning disable CA1710 // suffix
    public class CvContourPolygon : List<Point>
#pragma warning restore CA1710 
    {
        /// <summary>
        /// 
        /// </summary>
        public CvContourPolygon()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public CvContourPolygon(IEnumerable<Point> list)
            : base(list)
        {
        }

        /// <summary>
        /// Converts this to CSV string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var p in this)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0},{1}", p.X, p.Y).AppendLine();
            }
            return sb.ToString();
        }

        #region Area

        /// <summary>
        /// Calculates area of a polygonal contour. 
        /// </summary>
        /// <returns>Area of the contour.</returns>
        public double Area()
        {
            if (Count <= 2)
                return 1.0;

            Point lastPoint = this[Count - 1];
            double area = 0.0;
            foreach (Point point in this)
            {
                area += lastPoint.X*point.Y - lastPoint.Y*point.X;
                lastPoint = point;
            }
            return area*0.5;
        }

        #endregion

        #region Circularity

        /// <summary>
        /// Calculates the circularity of a polygon (compactness measure).
        /// </summary>
        /// <returns>Circularity: a non-negative value, where 0 correspond with a circumference.</returns>
        public double Circularity()
        {
            double l = Perimeter();
            double c = (l*l/Area()) - 4.0*Math.PI;

            if (c >= 0.0)
                return c;
            // This could happen if the blob it's only a pixel: the perimeter will be 0. Another solution would be to force "cvContourPolygonPerimeter" to be 1 or greater.
            return 0.0;
        }

        #endregion

        #region ContourConvexHull

        /// <summary>
        /// Calculates convex hull of a contour.
        /// Uses the Melkman Algorithm. Code based on the version in http://w3.impa.br/~rdcastan/Cgeometry/.
        /// </summary>
        /// <returns>Convex hull.</returns>
        public CvContourPolygon ContourConvexHull()
        {
            if (Count <= 3)
                return new CvContourPolygon(this);

            var dq = new List<Point>(); // instead of std::deq...

            if (CrossProductPoints(this[0], this[1], this[2]) > 0)
            {
                dq.Add(this[0]);
                dq.Add(this[1]);
            }
            else
            {
                dq.Add(this[1]);
                dq.Add(this[0]);
            }

            dq.Add(this[2]);
            dq.Insert(0, this[2]);

            for (int i = 3; i < Count; i++)
            {
                int s = dq.Count;

                if ((CrossProductPoints(this[i], dq[0], dq[1]) >= 0) &&
                    (CrossProductPoints(dq[s - 2], dq[s - 1], this[i]) >= 0))
                    continue; // TODO Optimize.

                while (CrossProductPoints(dq[s - 2], dq[s - 1], this[i]) < 0)
                {
                    dq.RemoveAt(dq.Count - 1);
                    s = dq.Count;
                }

                dq.Add(this[i]);

                while (CrossProductPoints(this[i], dq[0], dq[1]) < 0)
                    dq.RemoveAt(0);

                dq.Insert(0, this[i]);
            }

            return new CvContourPolygon(dq);
        }

        private static double CrossProductPoints(Point a, Point b, Point c)
        {
            double abx = b.X - a.X;
            double aby = b.Y - a.Y;
            double acx = c.X - a.X;
            double acy = c.Y - a.Y;
            return abx*acy - aby*acx;
        }

        #endregion

        #region ContourPolygonPerimeter

        /// <summary>
        /// Calculates perimeter of a chain code contour.
        /// </summary>
        /// <returns>Perimeter of the contour.</returns>
        public double Perimeter()
        {
            double perimeter = DistancePointPoint(this[Count - 1], this[0]);
            for (int i = 0; i < Count - 1; i++)
            {
                perimeter += DistancePointPoint(this[i], this[i + 1]);
            }
            return perimeter;
        }

        private static double DistancePointPoint(Point a, Point b)
        {
            double abx = a.X - b.X;
            double aby = a.Y - b.Y;
            return Math.Sqrt(abx*abx + aby*aby);
        }

        #endregion

        #region Render

        /// <summary>
        /// Draw a polygon.
        /// </summary>
        /// <param name="img">Image to draw on.</param>
        public void Render(Mat img)
        {
            Render(img, new Scalar(255, 255, 255));
        }

        /// <summary>
        /// Draw a polygon.
        /// </summary>
        /// <param name="img">Image to draw on.</param>
        /// <param name="color">Color to draw (default, white).</param>
        public void Render(Mat img, Scalar color)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (img.Type() != MatType.CV_8UC3)
                throw new ArgumentException("Invalid img format (U8 3-channels)");

            if (Count == 0)
                return;

            int fx = this[Count - 1].X;
            int fy = this[Count - 1].Y;
            foreach (Point p in this)
            {
                Cv2.Line(img, fx, fy, p.X, p.Y, color);
                fx = p.X;
                fy = p.Y;
            }
        }

        #endregion

        #region SimplifyPolygon

        /// <summary>
        /// Simplify a polygon reducing the number of vertex according the distance "delta". 
        /// Uses a version of the Ramer-Douglas-Peucker algorithm (http://en.wikipedia.org/wiki/Ramer-Douglas-Peucker_algorithm). 
        /// </summary>
        /// <returns>A simplify version of the original polygon.</returns>
        public CvContourPolygon Simplify()
        {
            return Simplify(1.0);
        }

        /// <summary>
        /// Simplify a polygon reducing the number of vertex according the distance "delta". 
        /// Uses a version of the Ramer-Douglas-Peucker algorithm (http://en.wikipedia.org/wiki/Ramer-Douglas-Peucker_algorithm). 
        /// </summary>
        /// <param name="delta">Minimun distance.</param>
        /// <returns>A simplify version of the original polygon.</returns>
        public CvContourPolygon Simplify(double delta)
        {
            double furtherDistance = 0.0;
            int furtherIndex = 0;

            if (Count == 0)
                return new CvContourPolygon();

            for (int i = 1; i < Count; i++)
            {
                double d = DistancePointPoint(this[i], this[0]);
                if (d > furtherDistance)
                {
                    furtherDistance = d;
                    furtherIndex = i;
                }
            }

            if (furtherDistance < delta)
            {
                CvContourPolygon result = new CvContourPolygon();
                result.Add(this[0]);
                return result;
            }
            else
            {
                bool[] pnUseFlag = new bool[Count];
                for (int i = 1; i < Count; i++)
                    pnUseFlag[i] = false;

                pnUseFlag[0] = pnUseFlag[furtherIndex] = true;

                SimplifyPolygonRecursive(this, 0, furtherIndex, pnUseFlag, delta);
                SimplifyPolygonRecursive(this, furtherIndex, -1, pnUseFlag, delta);

                CvContourPolygon result = new CvContourPolygon();

                for (int i = 0; i < Count; i++)
                {
                    if (pnUseFlag[i])
                        result.Add(this[i]);
                }
                return result;
            }
        }

        private static void SimplifyPolygonRecursive(CvContourPolygon p, int i1, int i2, bool[] pnUseFlag, double delta)
        {
            int endIndex = (i2 < 0) ? p.Count : i2;

            if (Math.Abs(i1 - endIndex) <= 1)
                return;

            Point firstPoint = p[i1];
            Point lastPoint = (i2 < 0) ? p[0] : p[i2];

            double furtherDistance = 0.0;
            int furtherIndex = 0;

            for (int i = i1 + 1; i < endIndex; i++)
            {
                double d = DistanceLinePoint(firstPoint, lastPoint, p[i]);

                if ((d >= delta) && (d > furtherDistance))
                {
                    furtherDistance = d;
                    furtherIndex = i;
                }
            }

            if (furtherIndex > 0)
            {
                pnUseFlag[furtherIndex] = true;

                SimplifyPolygonRecursive(p, i1, furtherIndex, pnUseFlag, delta);
                SimplifyPolygonRecursive(p, furtherIndex, i2, pnUseFlag, delta);
            }
        }

        private static double DistanceLinePoint(Point a, Point b, Point c, bool isSegment = true)
        {
            if (isSegment)
            {
                double dot1 = DotProductPoints(a, b, c);
                if (dot1 > 0) return DistancePointPoint(b, c);

                double dot2 = DotProductPoints(b, a, c);
                if (dot2 > 0) return DistancePointPoint(a, c);
            }
            return Math.Abs(CrossProductPoints(a, b, c)/DistancePointPoint(a, b));
        }

        private static double DotProductPoints(Point a, Point b, Point c)
        {
            double abx = b.X - a.X;
            double aby = b.Y - a.Y;
            double bcx = c.X - b.X;
            double bcy = c.Y - b.Y;
            return abx*bcx + aby*bcy;
        }

        #endregion

        #region WriteAsCsv

        /// <summary>
        /// Write a contour to a CSV (Comma-separated values) file.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteAsCsv(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(ToString());
            }
        }

#endregion

#region WriteAsSvg

        /// <summary>
        /// Write a contour to a SVG file.
        /// </summary>
        /// <param name="fileName">File name</param>
        public void WriteAsSvg(string fileName)
        {
            WriteAsSvg(fileName, Scalar.Black, Scalar.White);
        }

        /// <summary>
        /// Write a contour to a SVG file.
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="stroke">Stroke color</param>
        /// <param name="fill">Fill color</param>
        public void WriteAsSvg(string fileName, Scalar stroke, Scalar fill)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(ToSvg(stroke, fill));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stroke"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public string ToSvg(Scalar stroke, Scalar fill)
        {
            int minx = int.MaxValue;
            int miny = int.MaxValue;
            int maxx = int.MinValue;
            int maxy = int.MinValue;

            var buffer = new StringBuilder();
            foreach (var p in this)
            {
                if (p.X > maxx)
                    maxx = p.X;
                if (p.X < minx)
                    minx = p.X;
                if (p.Y > maxy)
                    maxy = p.Y;
                if (p.Y < miny)
                    miny = p.Y;
                buffer.AppendFormat(CultureInfo.InvariantCulture, "{0},{1} ", p.X, p.Y);
            }

            var builder = new StringBuilder()
                .AppendLine("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"no\"?>")
                .AppendLine(
                    "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 20010904//EN\" \"http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd\">")
                .AppendFormat(
                    CultureInfo.InvariantCulture,
                    "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" xml:space=\"preserve\" " +
                    "width=\"{0}px\" height=\"{1}px\" viewBox=\"{2} {3} {4} {5}\" zoomAndPan=\"disable\" >",
                    maxx - minx, maxy - miny, minx, miny, maxx, maxy).AppendLine()
                .AppendFormat(
                    CultureInfo.InvariantCulture,
                    "<polygon fill=\"rgb({0},{1},{2})\" stroke=\"rgb({3},{4},{5})\" stroke-width=\"1\" points=\"{6}\"/>",
                    fill.Val0, fill.Val1, fill.Val2, stroke.Val0, stroke.Val1, stroke.Val2, buffer).AppendLine()
                .AppendLine("</svg>");
            return builder.ToString();
        }

#endregion
    }
}
