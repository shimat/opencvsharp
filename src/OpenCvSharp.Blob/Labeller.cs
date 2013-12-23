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
    /// <summary>
    /// 
    /// </summary>
    internal static class Labeller
    {
	    private static readonly int[,,] MovesE= new int[4, 3, 4]{ 
            { { -1, -1, 3, CvBlobConst.CV_CHAINCODE_UP_LEFT }, { 0, -1, 0, CvBlobConst.CV_CHAINCODE_UP }, { 1, -1, 0, CvBlobConst.CV_CHAINCODE_UP_RIGHT } },
	        { { 1, -1, 0, CvBlobConst.CV_CHAINCODE_UP_RIGHT }, { 1, 0, 1, CvBlobConst.CV_CHAINCODE_RIGHT }, { 1, 1, 1, CvBlobConst.CV_CHAINCODE_DOWN_RIGHT } },
	        { { 1, 1, 1, CvBlobConst.CV_CHAINCODE_DOWN_RIGHT }, { 0, 1, 2, CvBlobConst.CV_CHAINCODE_DOWN }, { -1, 1, 2, CvBlobConst.CV_CHAINCODE_DOWN_LEFT } },
	        { { -1, 1, 2, CvBlobConst.CV_CHAINCODE_DOWN_LEFT }, { -1, 0, 3, CvBlobConst.CV_CHAINCODE_LEFT }, { -1, -1, 3, CvBlobConst.CV_CHAINCODE_UP_LEFT } }
	    };
        private static readonly int[,,] MovesI = new int[4, 3, 4]
        {
            {{1, -1, 3, CvBlobConst.CV_CHAINCODE_UP_RIGHT}, {0, -1, 0, CvBlobConst.CV_CHAINCODE_UP}, {-1, -1, 0, CvBlobConst.CV_CHAINCODE_UP_LEFT}},
            {{-1, -1, 0, CvBlobConst.CV_CHAINCODE_UP_LEFT}, {-1, 0, 1, CvBlobConst.CV_CHAINCODE_LEFT}, {-1, 1, 1, CvBlobConst.CV_CHAINCODE_DOWN_LEFT}},
            {{-1, 1, 1, CvBlobConst.CV_CHAINCODE_DOWN_LEFT}, {0, 1, 2, CvBlobConst.CV_CHAINCODE_DOWN}, {1, 1, 2, CvBlobConst.CV_CHAINCODE_DOWN_RIGHT}},
            {{1, 1, 2, CvBlobConst.CV_CHAINCODE_DOWN_RIGHT}, {1, 0, 3, CvBlobConst.CV_CHAINCODE_RIGHT}, {1, -1, 3, CvBlobConst.CV_CHAINCODE_UP_RIGHT}}
        };

        /// <summary>
        /// Value of invalid pixel.
        /// -1 == uint.MaxValue
        /// </summary>
        private const int MarkerValue = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="labels"></param>
        /// <param name="blobs"></param>
        /// <returns></returns>
        public static unsafe int Perform(IplImage img, int[,] labels, CvBlobs blobs)
	    {
            if(img == null)
                throw new ArgumentNullException("img");
            if(labels == null)
                throw new ArgumentNullException("labels");
            if(blobs == null)
                throw new ArgumentNullException("blobs");
            if(img.Depth != BitDepth.U8 || img.NChannels != 1)
                throw new ArgumentException("'img' must be a 1-channel U8 image.");

            int numPixels = 0;
			blobs.Clear();

			int step = img.WidthStep;
			int ox = img.ROI.X;
            int oy = img.ROI.Y;
            int w = img.ROI.Width;
            int h = img.ROI.Height;
            byte *imgIn = img.ImageDataPtr;

            if(labels.GetLength(0) != h || labels.GetLength(1) != w)
                throw new ArgumentException("img.Size != labels' size");

			int lastLabel = 0;
			CvBlob lastBlob = null;

			int label = 0;
            int xLimit = oy + img.ROI.Width;
            int yLimit = oy + img.ROI.Height;

            for (int y = oy; y < oy + yLimit; y++)
            {
                for (int x = ox; x < xLimit; x++)
                {
                    if (imgIn[x + y*step] == 0)
                        continue;

                    bool labeled = labels[y, x] != 0;
                    if (!labeled && ((y == 0) || (imgIn[x + (y - 1)*step] == 0)))
                    {
                        labeled = true;

                        // Label contour.
                        label++;
                        if (label == MarkerValue)
                            throw new Exception();

                        labels[y, x] = label;
                        numPixels++;

                        // XXX This is not necessary at all. I only do this for consistency.
                        if (y > 0)
                            labels[y - 1, x] = MarkerValue;

                        CvBlob blob = new CvBlob
                        {
                            Label = label,
                            Area = 1,
                            MinX = x,
                            MaxX = x,
                            MinY = y,
                            MaxY = y,
                            M10 = x,
                            M01 = y,
                            M11 = x*y,
                            M20 = x*x,
                            M02 = y*y,
                        };
                        blobs.Add(label, blob);
                        lastLabel = label;
                        lastBlob = blob;

                        blob.Contour.StartingPoint = new CvPoint(x, y);
                        int direction = 1;
                        int xx = x;
                        int yy = y;
                        bool contourEnd = false;

                        do
                        {
                            for (int numAttempts = 0; numAttempts < 3; numAttempts++)
                            {
                                bool found = false;
                                for (int i = 0; i < 3; i++)
                                {
                                    int nx = xx + MovesE[direction, i, 0];
                                    int ny = yy + MovesE[direction, i, 1];
                                    if ((nx < w) && (nx >= 0) && (ny < h) && (ny >= 0))
                                    {
                                        if (imgIn[nx + ny*step] != 0)
                                        {
                                            found = true;
                                            blob.Contour.ChainCode.Add((CvChainCode) MovesE[direction, i, 3]);
                                            xx = nx;
                                            yy = ny;
                                            direction = MovesE[direction, i, 2];
                                            break;
                                        }
                                        labels[ny, nx] = MarkerValue;
                                    }
                                }

                                if (!found)
                                    direction = (direction + 1)%4;
                                else
                                {
                                    if (labels[yy, xx] != label)
                                    {
                                        labels[yy, xx] = label;
                                        numPixels++;

                                        if (xx < blob.MinX) blob.MinX = xx;
                                        else if (xx > blob.MaxX) blob.MaxX = xx;
                                        if (yy < blob.MinY) blob.MinY = yy;
                                        else if (yy > blob.MaxY) blob.MaxY = yy;

                                        blob.Area++;
                                        blob.M10 += xx;
                                        blob.M01 += yy;
                                        blob.M11 += xx*yy;
                                        blob.M20 += xx*xx;
                                        blob.M02 += yy*yy;
                                    }
                                    break;
                                }

                                contourEnd = ((xx == x) && (yy == y) && (direction == 1));
                                if (contourEnd)
                                    break;
                            }
                        } while (!contourEnd);

                    }

                    if ((y + 1 < h) && (imgIn[x + (y + 1)*step] == 0) && (labels[y + 1, x] == 0))
                    {
                        labeled = true;

                        // Label internal contour
                        int l;
                        CvBlob blob;

                        if (labels[y, x] == 0)
                        {
                            l = labels[y, x - 1];
                            labels[y, x] = l;
                            numPixels++;

                            if (l == lastLabel)
                                blob = lastBlob;
                            else
                            {
                                blob = blobs[l];
                                lastLabel = l;
                                lastBlob = blob;
                            }
                            blob.Area++;
                            blob.M10 += x;
                            blob.M01 += y;
                            blob.M11 += x*y;
                            blob.M20 += x*x;
                            blob.M02 += y*y;
                        }
                        else
                        {
                            l = labels[y, x];
                            if (l == lastLabel)
                                blob = lastBlob;
                            else
                            {
                                blob = blobs[l];
                                lastLabel = l;
                                lastBlob = blob;
                            }
                        }

                        // XXX This is not necessary (I believe). I only do this for consistency.
                        labels[y + 1, x] = MarkerValue;
                        var contour = new CvContourChainCode
                        {
                            StartingPoint = new CvPoint(x, y)
                        };

                        int direction = 3;
                        int xx = x;
                        int yy = y;

                        do
                        {
                            for (int numAttempts = 0; numAttempts < 3; numAttempts++)
                            {
                                bool found = false;

                                for (int i = 0; i < 3; i++)
                                {
                                    int nx = xx + MovesI[direction, i, 0];
                                    int ny = yy + MovesI[direction, i, 1];
                                    if (imgIn[nx + ny*step] != 0)
                                    {
                                        found = true;
                                        contour.ChainCode.Add((CvChainCode) MovesI[direction, i, 3]);
                                        xx = nx;
                                        yy = ny;
                                        direction = MovesI[direction, i, 2];
                                        break;
                                    }
                                    labels[ny, nx] = MarkerValue;
                                }

                                if (!found)
                                    direction = (direction + 1)%4;
                                else
                                {
                                    if (labels[yy, xx] == 0)
                                    {
                                        labels[yy, xx] = l;
                                        numPixels++;

                                        blob.Area++;
                                        blob.M10 += xx;
                                        blob.M01 += yy;
                                        blob.M11 += xx*yy;
                                        blob.M20 += xx*xx;
                                        blob.M02 += yy*yy;
                                    }
                                    break;
                                }
                            }
                        } while (!(xx == x && yy == y));

                        blob.InternalContours.Add(contour);
                    }

                    //else if (!imageOut(x, y))
                    if (!labeled)
                    {
                        // Internal pixel
                        int l = labels[y, x - 1];
                        labels[y, x] = l;
                        numPixels++;

                        CvBlob blob;
                        if (l == lastLabel)
                            blob = lastBlob;
                        else
                        {
                            blob = blobs[l];
                            lastLabel = l;
                            lastBlob = blob;
                        }
                        blob.Area++;
                        blob.M10 += x;
                        blob.M01 += y;
                        blob.M11 += x*y;
                        blob.M20 += x*x;
                        blob.M02 += y*y;
                    }
                }
            }

            foreach (var kv in blobs)
            {
                CvBlob b = kv.Value;

                b.Centroid = new CvPoint2D64f(b.M10 / b.Area, b.M01 / b.Area);

                b.U11 = b.M11 - (b.M10 * b.M01) / b.M00;
                b.U20 = b.M20 - (b.M10 * b.M10) / b.M00;
                b.U02 = b.M02 - (b.M01 * b.M01) / b.M00;

                double m00_2 = b.M00 * b.M00;
                b.N11 = b.U11 / m00_2;
                b.N20 = b.U20 / m00_2;
                b.N02 = b.U02 / m00_2;

                b.P1 = b.N20 + b.N02;
                double nn = b.N20 - b.N02;
                b.P2 = nn * nn + 4.0 * (b.N11 * b.N11);
            }

            return numPixels;
	    }
    }
}
