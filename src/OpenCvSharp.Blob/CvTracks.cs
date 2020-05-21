using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// </summary>
    [Serializable]
#pragma warning disable CA1710 // suffix
#pragma warning disable CA2229 // Implement serialization constructors
    public class CvTracks : Dictionary<int, CvTrack>
#pragma warning restore CA2229 
#pragma warning restore CA1710
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
            Render(imgSource, imgDest, RenderTracksModes.Id, Scalar.Green);
        }

        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        public void Render(Mat imgSource, Mat imgDest, RenderTracksModes mode)
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
        public void Render(Mat imgSource, Mat imgDest, RenderTracksModes mode, Scalar textColor,
            HersheyFonts fontFace = HersheyFonts.HersheySimplex, double fontScale = 1d, int thickness = 1)
        {
            if (imgSource == null)
                throw new ArgumentNullException(nameof(imgSource));
            if (imgDest == null)
                throw new ArgumentNullException(nameof(imgDest));
            if (imgDest.Type() != MatType.CV_8UC3)
                throw new ArgumentException("imgDest.Depth != U8 || imgDest.NChannels != 3");

            if (mode != RenderTracksModes.None)
            {
                foreach (KeyValuePair<int, CvTrack> kv in this)
                {
                    int key = kv.Key;
                    CvTrack value = kv.Value;

                    if ((mode & RenderTracksModes.Id) == RenderTracksModes.Id)
                    {
                        if (value.Inactive == 0)
                        {
                            Cv2.PutText(imgDest, key.ToString(CultureInfo.InvariantCulture), (Point)value.Centroid,
                                fontFace, fontScale, textColor, thickness);
                        }
                    }
                    if ((mode & RenderTracksModes.BoundingBox) == RenderTracksModes.BoundingBox)
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

                builder.AppendLine($"Track {value}");
                if (value.Inactive > 0)
                    builder.AppendLine($" - Inactive for {value.Inactive} frames");
                else
                    builder.AppendLine($" - Associated with blobs {value.Label}");
                builder.AppendLine($" - Lifetime {value.LifeTime}");
                builder.AppendLine($" - Active {value.Active}");
                builder.AppendLine($" - Bounding box: ({value.MinX},{value.MinY}) - ({value.MaxX}, {value.MaxY})");
                builder.AppendLine($" - Centroid: ({value.Centroid.X}, {value.Centroid.Y})");
                builder.AppendLine();
            }
            return builder.ToString();
        }

        #endregion
    }
}