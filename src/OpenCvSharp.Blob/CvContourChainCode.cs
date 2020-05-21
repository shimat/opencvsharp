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

using System;
using System.Collections.Generic;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CvContourChainCode
    {
        /// <summary>
        /// Point where contour begin.
        /// </summary>
        public Point StartingPoint { get; set; }

        /// <summary>
        /// Polygon description based on chain codes.
        /// </summary>
        public List<CvChainCode> ChainCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CvContourChainCode()
        {
            StartingPoint = default;
            ChainCode = new List<CvChainCode>();
        }

        /// <summary>
        /// Convert a chain code contour to a polygon.
        /// </summary>
        /// <returns>A polygon.</returns>
        public CvContourPolygon ConvertToPolygon()
        {
            CvContourPolygon contour = new CvContourPolygon();

            int x = StartingPoint.X;
            int y = StartingPoint.Y;
            contour.Add(new Point(x, y));

            if (ChainCode.Count > 0)
            {
                CvChainCode lastCode = ChainCode[0];
                x += CvBlobConst.ChainCodeMoves[(int) ChainCode[0]][0];
                y += CvBlobConst.ChainCodeMoves[(int) ChainCode[0]][1];
                for (int i = 1; i < ChainCode.Count; i++)
                {
                    if (lastCode != ChainCode[i])
                    {
                        contour.Add(new Point(x, y));
                        lastCode = ChainCode[i];
                    }
                    x += CvBlobConst.ChainCodeMoves[(int) ChainCode[i]][0];
                    y += CvBlobConst.ChainCodeMoves[(int) ChainCode[i]][1];
                }
            }

            return contour;
        }

        /// <summary>
        /// Calculates perimeter of a polygonal contour.
        /// </summary>
        /// <returns>Perimeter of the contour.</returns>
        public double Perimeter()
        {
            double perimeter = 0.0;
            foreach (CvChainCode cc in ChainCode)
            {
                int type = (int) cc;
                if (type%2 != 0)
                    perimeter += Math.Sqrt(1.0 + 1.0);
                else
                    perimeter += 1.0;
            }
            return perimeter;
        }

        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="img">Image to draw on.</param>
        public void Render(Mat img)
        {
            Render(img, new Scalar(255, 255, 255));
        }

        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="img">Image to draw on.</param>
        /// <param name="color">Color to draw (default, white).</param>
        public void Render(Mat img, Scalar color)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (img.Type() != MatType.CV_8UC3)
                throw new ArgumentException("Invalid img format (U8 3-channels)");

            var indexer = img.GetGenericIndexer<Vec3b>();
            int x = StartingPoint.X;
            int y = StartingPoint.Y;
            foreach (CvChainCode cc in ChainCode)
            {
                indexer[y, x] = new Vec3b((byte) color.Val0, (byte) color.Val1, (byte) color.Val2);
                x += CvBlobConst.ChainCodeMoves[(int) cc][0];
                y += CvBlobConst.ChainCodeMoves[(int) cc][1];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvContourChainCode Clone()
        {
            return new CvContourChainCode
            {
                ChainCode = new List<CvChainCode>(ChainCode),
                StartingPoint = StartingPoint,
            };
        }
    }
}
