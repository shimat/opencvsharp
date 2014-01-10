using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Blob set
    /// </summary>
    public class CvBlobs : Dictionary<int, CvBlob>
    {
        /// <summary>
        /// Label values
        /// </summary>
        public LabelData Labels { get; protected set; }

        /// <summary>
        /// Constructor (init only)
        /// </summary>
        public CvBlobs()
        {
        }
        /// <summary>
        /// Constructor (init and cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        public CvBlobs(IplImage img)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (img.Depth != BitDepth.U8 || img.NChannels != 1)
                throw new ArgumentException("img.Depth == BitDepth.U8 && img.NChannels == 1");

            Label(img);
        }

        #region Methods
        #region BlobMeanColor

        /// <summary>
        /// Calculates mean color of a blob in an image. (cvBlobMeanColor)
        /// </summary>
        /// <param name="targetBlob">The target blob</param>
        /// <param name="originalImage">Original image.</param>
        public CvScalar BlobMeanColor(CvBlob targetBlob, IplImage originalImage)
        {
            if (targetBlob == null)
                throw new ArgumentNullException("targetBlob");
            if (originalImage == null)
                throw new ArgumentNullException("originalImage");
            if (originalImage.Depth != BitDepth.U8)
                throw new ArgumentException("imgOut.Depth != BitDepth.U8");
            if (originalImage.NChannels != 3)
                throw new ArgumentException("imgOut.NChannels != 3");
            if (Labels == null)
                throw new ArgumentException("blobs.Labels == null");

            throw new NotImplementedException();
        }
        #endregion
        #region Label
        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public int Label(IplImage img)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            Labels = new LabelData(img.Height, img.Width, img.ROI);
            return Labeller.Perform(img, this);
        }
        #endregion
        #region FilterLabels
        /// <summary>
        /// Draw a binary image with the blobs that have been given. (cvFilterLabels)
        /// </summary>
        /// <param name="imgOut">Output binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        public void FilterLabels(IplImage imgOut)
        {
            if (imgOut == null)
                throw new ArgumentNullException("imgOut");
            if (imgOut.Depth != BitDepth.U8)
                throw new ArgumentException("imgOut.Depth != BitDepth.U8");
            if (imgOut.NChannels != 1)
                throw new ArgumentException("imgOut.NChannels != 1");
            if (Labels == null)
                throw new ArgumentException("blobs.Labels == null");

            CvRect roi = Labels.Roi;
            int w = roi.Width;
            int h = roi.Height;

            int step = imgOut.WidthStep;
            int offset = 0;
            if (imgOut.ROIPointer != IntPtr.Zero)
            {
                IplROI r = imgOut.ROIValue;
                offset = r.xOffset + (r.yOffset * step);
            }

            unsafe
            {
                byte* imgData = imgOut.ImageDataPtr + offset;

                for (int r = 0; r < h; r++, imgData += step)
                {
                    for (int c = 0; c < w; c++)
                    {
                        int label = Labels[r, c];
                        if (label != 0)
                        {
                            if (ContainsKey(label))
                                imgData[c] = 0xff;
                            else
                                imgData[c] = 0x00;
                        }
                        else
                        {
                            imgData[c] = 0x00;
                        }
                    }
                }
            }
        }
        #endregion
        #region GreaterBlob
        /// <summary>
        /// Find greater blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>The greater blob.</returns>
        public CvBlob GreaterBlob()
        {
            return LargestBlob();
        }
        /// <summary>
        /// Find the largest blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>The largest blob.</returns>
        public CvBlob LargestBlob()
        {
            if (Count == 0)
                return null;

            var list = new List<KeyValuePair<int, CvBlob>>(this);
            // 降順ソート
            list.Sort((kv1, kv2) =>
                {
                    CvBlob b1 = kv1.Value;
                    CvBlob b2 = kv2.Value;
                    if (b1 == null)
                        return -1;
                    if (b2 == null)
                        return 1;
                    return b2.Area - b1.Area;
                });
            return list[0].Value;
        }
        #endregion
        #region GetLabel
        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public int GetLabel(int x, int y)
        {
            return Labels[y, x];
        }
        #endregion
        #region RenderBlobs
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest, RenderBlobsMode mode)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest, mode);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public void RenderBlobs(IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, Double alpha)
        {
            CvBlobLib.RenderBlobs(this, imgSource, imgDest, mode, alpha);
        }
        #endregion
        #region FilterByArea
        /// <summary>
        /// Filter blobs by area. 
        /// Those blobs whose areas are not in range will be erased from the input list of blobs. (cvFilterByArea)
        /// </summary>
        /// <param name="minArea">Minimun area.</param>
        /// <param name="maxArea">Maximun area.</param>
        public void FilterByArea(int minArea, int maxArea)
        {
            foreach (int key in Keys)
            {
                int area = this[key].Area;
                if (area < minArea || area > maxArea)
                {
                    Remove(key);
                }
            }
        }
        #endregion
        #endregion
    }
}
