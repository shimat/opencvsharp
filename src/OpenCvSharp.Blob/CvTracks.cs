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
    public class CvTracks : Dictionary<int, CvTrack>
    {
        /// <summary>
        /// 
        /// </summary>
        public CvTracks()
        {
        }

        #region Render

        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public void Render(Mat imgSource, Mat imgDest)
        {
            Render(imgSource, imgDest, RenderTracksMode.Id, Scalar.Green);
        }

        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        public void Render(Mat imgSource, Mat imgDest, RenderTracksMode mode)
        {
            Render(imgSource, imgDest, mode, Scalar.Green);
        }

        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        /// <param name="textColor"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="thickness"></param>
        public void Render(Mat imgSource, Mat imgDest, RenderTracksMode mode, Scalar textColor,
            HersheyFonts fontFace = HersheyFonts.HersheySimplex, double fontScale = 1d, int thickness = 1)
        {
            if (imgSource == null)
                throw new ArgumentNullException(nameof(imgSource));
            if (imgDest == null)
                throw new ArgumentNullException(nameof(imgDest));
            if (imgDest.Type() != MatType.CV_8UC3)
                throw new ArgumentException("imgDest.Depth != U8 || imgDest.NChannels != 3");

            if (mode != RenderTracksMode.None)
            {
                foreach (KeyValuePair<int, CvTrack> kv in this)
                {
                    int key = kv.Key;
                    CvTrack value = kv.Value;

                    if ((mode & RenderTracksMode.Id) == RenderTracksMode.Id)
                    {
                        if (value.Inactive == 0)
                        {
                            Cv2.PutText(imgDest, key.ToString(), value.Centroid,
                                fontFace, fontScale, textColor, thickness);
                        }
                    }
                    if ((mode & RenderTracksMode.BoundingBox) == RenderTracksMode.BoundingBox)
                    {
                        if (value.Inactive > 0)
                            Cv2.Rectangle(
                                imgDest,
                                new Point(value.MinX, value.MinY),
                                new Point(value.MaxX - 1, value.MaxY - 1),
                                new Scalar(50, 0, 0));
                        else
                            Cv2.Rectangle(
                                imgDest,
                                new Point(value.MinX, value.MinY),
                                new Point(value.MaxX - 1, value.MaxY - 1),
                                new Scalar(255, 0, 0));
                    }
                }
            }
        }

        #endregion

        #region ToString

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<int, CvTrack> kv in this)
            {
                CvTrack value = kv.Value;

                builder.AppendFormat("Track {0}", value).AppendLine();
                if (value.Inactive > 0)
                    builder.AppendFormat(" - Inactive for {0} frames", value.Inactive).AppendLine();
                else
                    builder.AppendFormat(" - Associated with blobs {0}", value.Label).AppendLine();
                builder.AppendFormat(" - Lifetime {0}", value.LifeTime).AppendLine();
                builder.AppendFormat(" - Active {0}", value.Active).AppendLine();
                builder.AppendFormat(" - Bounding box: ({0},{1}) - ({2}, {3})",
                    value.MinX, value.MinY, value.MaxX, value.MaxY).AppendLine();
                builder.AppendFormat(" - Centroid: ({0}, {1})", value.Centroid.X, value.Centroid.Y).AppendLine();
                builder.AppendLine();
            }
            return builder.ToString();
        }

        #endregion
    }
}