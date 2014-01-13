using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// 
    /// </summary>
    public class CvTracks : Dictionary<int, CvTrack>
    {
        public CvTracks()
        {
        }

        #region Render
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public void Render(IplImage imgSource, IplImage imgDest)
        {
            Render(imgSource, imgDest, RenderTracksMode.Id, null);
        }
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        public void Render(IplImage imgSource, IplImage imgDest, RenderTracksMode mode)
        {
            Render(imgSource, imgDest, mode, null);
        }

        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        /// <param name="font">OpenCV font for print on the image.</param>
        public void Render(IplImage imgSource, IplImage imgDest, RenderTracksMode mode, CvFont font)
        {
            if (imgSource == null)
                throw new ArgumentNullException("imgSource");
            if (imgDest == null)
                throw new ArgumentNullException("imgDest");
            if (imgDest.Depth != BitDepth.U8)
                throw new ArgumentException("imgDest.Depth != U8");
            if (imgDest.NChannels != 3)
                throw new ArgumentException("imgDest.NChannels != 3");

            if ((mode & RenderTracksMode.Id) == RenderTracksMode.Id && font == null)
            {
                font = new CvFont(FontFace.HersheyDuplex, 0.5, 0.5, 0, 1);
            }

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
                            Cv.PutText(imgDest, key.ToString(), value.Centroid, font, CvColor.Green);
                        }
                    }
                    if ((mode & RenderTracksMode.BoundingBox) == RenderTracksMode.BoundingBox)
                    {
                        if (value.Inactive > 0)
                            Cv.Rectangle(
                                imgDest, 
                                new CvPoint(value.MinX, value.MinY),
                                new CvPoint(value.MaxX - 1, value.MaxY - 1),
                                new CvColor(0, 0, 50));
                        else
                            Cv.Rectangle(
                                imgDest, 
                                new CvPoint(value.MinX, value.MinY),
                                new CvPoint(value.MaxX - 1, value.MaxY - 1), 
                                new CvColor(0, 0, 255));
                    }
                }
            }
        }

        #endregion

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
    }
}
