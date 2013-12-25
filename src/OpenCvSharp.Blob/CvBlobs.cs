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
        public int[,] Labels { get; protected set; }

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

            var labels = new int[img.Height, img.Width];
            Label(img, labels);
        }
        /// <summary>
        /// Constructor (init and cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and nchannels=1).</param>
        /// <param name="labels">Output Label values.</param>
        public CvBlobs(IplImage img, int[,] labels)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            Label(img, labels);
        }

        #region Methods
        #region Label
        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <param name="labels">Output Label values.</param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public int Label(IplImage img, int[,] labels)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (labels == null)
                throw new ArgumentNullException("labels");

            Labels = labels;
            return Labeller.Perform(img, labels, this);
        }
        #endregion
        #region FilterLabels
        /// <summary>
        /// Draw a binary image with the blobs that have been given. (cvFilterLabels)
        /// </summary>
        /// <param name="imgIn">Input image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        /// <param name="imgOut">Output binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        public void FilterLabels(IplImage imgIn, IplImage imgOut)
        {
            CvBlobLib.FilterLabels(imgIn, imgOut, this);
        }
        #endregion
        #region GreaterBlob
        /// <summary>
        /// Find greater blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>Label of greater blob.</returns>
        public int GreaterBlob()
        {
            return CvBlobLib.GreaterBlob(this);
        }
        /// <summary>
        /// Find the largest blob. (cvGreaterBlob)
        /// </summary>
        /// <returns>Label of the largest blob.</returns>
        public int LargestBlob()
        {
            return CvBlobLib.GreaterBlob(this);
        }
        #endregion
        #region RenderBlobs
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public void RenderBlobs(int[,] labels, IplImage imgSource, IplImage imgDest)
        {
            CvBlobLib.RenderBlobs(labels, this, imgSource, imgDest);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public void RenderBlobs(int[,] labels, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode)
        {
            CvBlobLib.RenderBlobs(labels, this, imgSource, imgDest, mode);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public void RenderBlobs(int[,] labels, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, Double alpha)
        {
            CvBlobLib.RenderBlobs(labels, this, imgSource, imgDest, mode, alpha);
        }
        #endregion
        #region FilterByArea
        /// <summary>
        /// Filter blobs by area. 
        /// Those blobs whose areas are not in range will be erased from the input list of blobs. (cvFilterByArea)
        /// </summary>
        /// <param name="minArea">Minimun area.</param>
        /// <param name="maxArea">Maximun area.</param>
        public void FilterByArea(UInt32 minArea, UInt32 maxArea)
        {
            CvBlobLib.FilterByArea(this, minArea, maxArea);
        }
        #endregion
        #endregion
    }
}
