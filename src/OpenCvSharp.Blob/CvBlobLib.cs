/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;

//#pragma warning disable 1591

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Functions of cvblob library
    /// </summary>
    static public class CvBlobLib
    {
        #region Constants
        /// <summary>
        /// Size of a label in bits.
        /// </summary>
        public const BitDepth DepthLabel = (BitDepth)(sizeof(UInt32) * 8);
        #endregion

        #region Public Methods
        #region Angle
        /// <summary>
        /// Calculates angle orientation of a blob.
        /// This function uses central moments so cvCentralMoments should have been called before for this blob. (cvAngle)
        /// </summary>
        /// <param name="blob">Blob.</param>
        /// <returns>Angle orientation in radians.</returns>
        public static double Angle(CvBlob blob)
        {
            if (blob == null)
                throw new ArgumentNullException("blob");
            return 0.5 * Math.Atan2(
                2.0 * blob.U11, 
                (blob.U20 - blob.U02)
            );
        }
        #endregion
        #region Centroid
        /// <summary>
        /// Calculates centroid.
        /// Centroid will be returned and stored in the blob structure. (cvCentroid)
        /// </summary>
        /// <param name="blob">Blob whose centroid will be calculated.</param>
        /// <returns>Centroid.</returns>
        public static CvPoint2D64f Centroid(CvBlob blob)
        {
            if (blob == null)
                throw new ArgumentNullException("blob");
            blob.Centroid = new CvPoint2D64f(blob.M10 / blob.Area, blob.M01 / blob.Area);
            return blob.Centroid;
        }
        #endregion
        #region ContourPolygonArea
        /// <summary>
        /// Calculates area of a polygonal contour. 
        /// </summary>
        /// <param name="p">Contour (polygon type).</param>
        /// <returns>Area of the contour.</returns>
        public static double ContourPolygonArea(CvContourPolygon p)
        {
            if (p == null)
                throw new ArgumentNullException("p");

            throw new NotImplementedException();
        }
        #endregion
        #region ContourPolygonPerimeter
        /// <summary>
        /// Calculates perimeter of a polygonal contour.
        /// </summary>
        /// <param name="p">Contour (polygon type).</param>
        /// <returns>Perimeter of the contour.</returns>
        public static double ContourPolygonPerimeter(CvContourPolygon p)
        {
            if (p == null)
                throw new ArgumentNullException("p");

            throw new NotImplementedException();
        }
        #endregion
        #region ConvertChainCodesToPolygon
        /// <summary>
        /// Convert a chain code contour to a polygon.
        /// </summary>
        /// <param name="cc">Chain code contour.</param>
        /// <returns>A polygon.</returns>
        public static CvContourPolygon ConvertChainCodesToPolygon(CvContourChainCode cc)
        {
            if (cc == null)
                throw new ArgumentNullException("cc");
            throw new NotImplementedException();
        }
        #endregion
        #region FilterByArea
        /// <summary>
        /// Filter blobs by area. 
        /// Those blobs whose areas are not in range will be erased from the input list of blobs. (cvFilterByArea)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="minArea">Minimun area.</param>
        /// <param name="maxArea">Maximun area.</param>
        public static void FilterByArea(CvBlobs blobs, uint minArea, uint maxArea)
        {
            if (blobs == null)
                throw new ArgumentNullException("blobs");

            foreach (int key in blobs.Keys)
            {
                int area = blobs[key].Area;
                if (area < minArea || area > maxArea)
                {
                    blobs.Remove(key);
                }
            }
        }
        #endregion
        #region FilterLabels
        /// <summary>
        /// Draw a binary image with the blobs that have been given. (cvFilterLabels)
        /// </summary>
        /// <param name="imgIn">Input image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
        /// <param name="imgOut">Output binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <param name="blobs">List of blobs to be drawn.</param>
        public static void FilterLabels(IplImage imgIn, IplImage imgOut, CvBlobs blobs)
        {
            if (imgIn == null)
                throw new ArgumentNullException("imgIn");
            if (imgOut == null)
                throw new ArgumentNullException("imgOut");
            if (blobs == null)
                throw new ArgumentNullException("blobs");

            throw new NotImplementedException();
        }
        #endregion   
        /*
        #region GetContour
        /// <summary>
        /// Get the contour of a blob.
        /// Uses Theo Pavlidis' algorithm (see http://www.imageprocessingplace.com/downloads_V3/root_downloads/tutorials/contour_tracing_Abeer_George_Ghuneim/theo.html ).
        /// </summary>
        /// <param name="blob">Blob.</param>
        /// <param name="img">Label image.</param>
        /// <returns>Chain code contour.</returns>
        public static CvContourChainCode GetContour(CvBlob blob, IplImage img)
        {
            if (blob == null)
                throw new ArgumentNullException("blob");
            if (img == null)
                throw new ArgumentNullException("img");

            IntPtr ptr = CvBlobInvoke.cvb_cvGetContour(blob.CvPtr, img.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvContourChainCode(ptr);
        }
        #endregion
        //*/
        #region GetLabel
        /// <summary>
        /// Get the label value from a labeled image.
        /// </summary>
        /// <param name="img">Label image.</param>
        /// <param name="x">X coordenate.</param>
        /// <param name="y">Y coordenate.</param>
        /// <returns>Label value.</returns>
        public static UInt32 GetLabel(IplImage img, uint x, uint y)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            throw new NotImplementedException();
        }
        #endregion
        #region GreaterBlob
        /// <summary>
        /// Find greater blob. (cvGreaterBlob)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <returns>Label of greater blob.</returns>
        public static int GreaterBlob(CvBlobs blobs)
        {
            return LargestBlob(blobs);
        }

        /// <summary>
        /// Find largest blob. (cvLargestBlob)
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <returns>Label of greater blob.</returns>
        public static int LargestBlob(CvBlobs blobs)
        {
            if (blobs == null)
                throw new ArgumentNullException("blobs");

            throw new NotImplementedException();
        }
        #endregion
        #region Label
        /// <summary>
        /// Label the connected parts of a binary image. (cvLabel)
        /// </summary>
        /// <param name="img">Input binary image (depth=IPL_DEPTH_8U and num. channels=1).</param>
        /// <param name="labels">Output Label values.</param>
        /// <param name="blobs">List of blobs.</param>
        /// <returns>Number of pixels that has been labeled.</returns>
        public static int Label(IplImage img, int[,] labels, CvBlobs blobs)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (blobs == null)
                throw new ArgumentNullException("blobs");

            return blobs.Label(img, labels);
        }
        #endregion
        #region BlobMeanColor
        /// <summary>
        /// Calculates mean color of a blob in an image.
        /// </summary>
        /// <param name="blob">Blob</param>
        /// <param name="imgLabel">Image of labels.</param>
        /// <param name="img">Original image.</param>
        /// <returns>Average color.</returns>
        public static CvScalar BlobMeanColor(CvBlob blob, IplImage imgLabel, IplImage img)
        {
            if (blob == null)
                throw new ArgumentNullException("blob");
            if (imgLabel == null)
                throw new ArgumentNullException("imgLabel");
            if (img == null)
                throw new ArgumentNullException("img");

            throw new NotImplementedException();
        }
        #endregion
        #region PolygonContourConvexHull
        /// <summary>
        /// Calculates convex hull of a contour.
        /// Uses the Melkman Algorithm. Code based on the version in http://w3.impa.br/~rdcastan/Cgeometry/.
        /// </summary>
        /// <param name="p">Contour (polygon type).</param>
        /// <returns>Convex hull.</returns>
        public static CvContourPolygon PolygonContourConvexHull(CvContourPolygon p)
        {
            if (p == null)
                throw new ArgumentNullException("p");

            throw new NotImplementedException();
        }
        #endregion
        #region RenderBlob
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public static void RenderBlob(int[,] labels, CvBlob blob, IplImage imgSource, IplImage imgDest)
        {
            RenderBlob(labels, blob, imgSource, imgDest, (RenderBlobsMode)0x000f, CvColor.White, 1.0);
        }
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public static void RenderBlob(int[,] labels, CvBlob blob, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode)
        {
            RenderBlob(labels, blob, imgSource, imgDest, mode, CvColor.White, 1.0);
        }
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="color">Color to render (if CV_BLOB_RENDER_COLOR is used).</param>
        public static void RenderBlob(int[,] labels, CvBlob blob, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, CvScalar color)
        {
            RenderBlob(labels, blob, imgSource, imgDest, mode, color, 1.0);
        }
        /// <summary>
        /// Draws or prints information about a blob.
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blob">Blob.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="color">Color to render (if CV_BLOB_RENDER_COLOR is used).</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public static void RenderBlob(int[,] labels, CvBlob blob, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, CvScalar color, double alpha)
        {
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (blob == null)
                throw new ArgumentNullException("blob");
            if (imgSource == null)
                throw new ArgumentNullException("imgSource");
            if (imgDest == null)
                throw new ArgumentNullException("imgDest");

            BlobRenderer.PerformOne(labels, blob, imgSource, imgDest, mode, color, alpha);
        }
        #endregion
        #region RenderBlobs
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public static void RenderBlobs(int[,] labels, CvBlobs blobs, IplImage imgSource, IplImage imgDest)
        {
            RenderBlobs(labels, blobs, imgSource, imgDest, (RenderBlobsMode)0x000f, 1.0);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        public static void RenderBlobs(int[,] labels, CvBlobs blobs, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode)
        {
            RenderBlobs(labels, blobs, imgSource, imgDest, mode, 1.0);
        }
        /// <summary>
        /// Draws or prints information about blobs. (cvRenderBlobs)
        /// </summary>
        /// <param name="labels">Label data.</param>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_BLOB_RENDER_COLOR|CV_BLOB_RENDER_CENTROID|CV_BLOB_RENDER_BOUNDING_BOX|CV_BLOB_RENDER_ANGLE.</param>
        /// <param name="alpha">If mode CV_BLOB_RENDER_COLOR is used. 1.0 indicates opaque and 0.0 translucent (1.0 by default).</param>
        public static void RenderBlobs(int[,] labels, CvBlobs blobs, IplImage imgSource, IplImage imgDest, RenderBlobsMode mode, double alpha)
        {
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (blobs == null)
                throw new ArgumentNullException("blobs");
            if (imgSource == null)
                throw new ArgumentNullException("imgSource");
            if (imgDest == null)
                throw new ArgumentNullException("imgDest");

            BlobRenderer.PerformMany(labels, blobs, imgSource, imgDest, mode, alpha);
        }
        #endregion
        #region RenderContourChainCode
        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="contour"> Chain code contour.</param>
        /// <param name="img">Image to draw on.</param>
        public static void RenderContourChainCode(CvContourChainCode contour, IplImage img)
        {
            RenderContourChainCode(contour, img, new CvScalar(255, 255, 255, 0));
        }
        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="contour"> Chain code contour.</param>
        /// <param name="img">Image to draw on.</param>
        /// <param name="color">Color to draw (default, white).</param>
        public static void RenderContourChainCode(CvContourChainCode contour, IplImage img, CvScalar color)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (img == null)
                throw new ArgumentNullException("img");

            throw new NotImplementedException();
        }
        #endregion
        #region RenderContourPolygon
        /// <summary>
        /// Draw a polygon.
        /// </summary>
        /// <param name="contour">Polygon contour.</param>
        /// <param name="img">Image to draw on.</param>
        public static void RenderContourPolygon(CvContourPolygon contour, IplImage img)
        {
            RenderContourPolygon(contour, img, new CvScalar(255, 255, 255, 0));
        }
        /// <summary>
        /// Draw a polygon.
        /// </summary>
        /// <param name="contour">Polygon contour.</param>
        /// <param name="img">Image to draw on.</param>
        /// <param name="color">Color to draw (default, white).</param>
        public static void RenderContourPolygon(CvContourPolygon contour, IplImage img, CvScalar color)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            if (img == null)
                throw new ArgumentNullException("img");

            throw new NotImplementedException();
        }
        #endregion
        #region RenderTracks
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        public static void RenderTracks(CvTracks tracks, IplImage imgSource, IplImage imgDest)
        {
            RenderTracks(tracks, imgSource, imgDest, RenderTracksMode.ID, null);
        }
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        public static void RenderTracks(CvTracks tracks, IplImage imgSource, IplImage imgDest, RenderTracksMode mode)
        {
            RenderTracks(tracks, imgSource, imgDest, mode, null);
        }
        /// <summary>
        /// Prints tracks information.
        /// </summary>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="imgSource">Input image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="imgDest">Output image (depth=IPL_DEPTH_8U and num. channels=3).</param>
        /// <param name="mode">Render mode. By default is CV_TRACK_RENDER_ID.</param>
        /// <param name="font">OpenCV font for print on the image.</param>
        public static void RenderTracks(CvTracks tracks, IplImage imgSource, IplImage imgDest, RenderTracksMode mode, CvFont font)
        {
            if (tracks == null)
                throw new ArgumentNullException("tracks");
            if (imgSource == null)
                throw new ArgumentNullException("imgSource");
            if (imgDest == null)
                throw new ArgumentNullException("imgDest");

            throw new NotImplementedException();
        }
        #endregion
        #region SetImageRoItoBlob
        /// <summary>
        /// Set the ROI of an image to the bounding box of a blob.
        /// </summary>
        /// <param name="img">Image.</param>
        /// <param name="blob">Blob.</param>
        public static void SetImageRoItoBlob(IplImage img, CvBlob blob)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (blob == null)
                throw new ArgumentNullException("blob");
            
            throw new NotImplementedException();
        }
        #endregion
        #region SimplifyPolygon
        /// <summary>
        /// Simplify a polygon reducing the number of vertex according the distance "delta". 
        /// Uses a version of the Ramer-Douglas-Peucker algorithm (http://en.wikipedia.org/wiki/Ramer-Douglas-Peucker_algorithm). 
        /// </summary>
        /// <param name="p">Contour (polygon type).</param>
        /// <returns>A simplify version of the original polygon.</returns>
        public static CvContourPolygon SimplifyPolygon(CvContourPolygon p)
        {
            return SimplifyPolygon(p, 1.0);
        }
        /// <summary>
        /// Simplify a polygon reducing the number of vertex according the distance "delta". 
        /// Uses a version of the Ramer-Douglas-Peucker algorithm (http://en.wikipedia.org/wiki/Ramer-Douglas-Peucker_algorithm). 
        /// </summary>
        /// <param name="p">Contour (polygon type).</param>
        /// <param name="delta">Minimun distance.</param>
        /// <returns>A simplify version of the original polygon.</returns>
        public static CvContourPolygon SimplifyPolygon(CvContourPolygon p, double delta)
        {
            if (p == null)
                throw new ArgumentNullException("p");

            throw new NotImplementedException();
        }
        #endregion
        #region UpdateTracks
        /// <summary>
        /// Updates list of tracks based on current blobs. 
        /// </summary>
        /// <param name="blobs">List of blobs.</param>
        /// <param name="tracks">List of tracks.</param>
        /// <param name="thDistance">Max distance to determine when a track and a blob match.</param>
        /// <param name="thInactive">Max number of frames a track can be inactive.</param>
        /// <remarks>
        /// Tracking based on:
        /// A. Senior, A. Hampapur, Y-L Tian, L. Brown, S. Pankanti, R. Bolle. Appearance Models for
        /// Occlusion Handling. Second International workshop on Performance Evaluation of Tracking and
        /// Surveillance Systems &amp; CVPR'01. December, 2001.
        /// (http://www.research.ibm.com/peoplevision/PETS2001.pdf)
        /// </remarks>
        public static void UpdateTracks(CvBlobs blobs, CvTracks tracks, double thDistance, uint thInactive)
        {
            if (blobs == null)
                throw new ArgumentNullException("blobs");
            if (tracks == null)
                throw new ArgumentNullException("tracks");

            throw new NotImplementedException();
        }
        #endregion
        #region WriteContourPolygonCSV
        /// <summary>
        /// Write a contour to a CSV (Comma-separated values) file.
        /// </summary>
        /// <param name="p">Polygon contour.</param>
        /// <param name="filename">File name.</param>
        public static void WriteContourPolygonCSV(CvContourPolygon p, string filename)
        {
            if (p == null)
                throw new ArgumentNullException("p");
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            throw new NotImplementedException();
        }
        #endregion
        #region WriteContourPolygonSVG
        /// <summary>
        /// Write a contour to a SVG file.
        /// </summary>
        /// <param name="p">Polygon contour.</param>
        /// <param name="filename">File name.</param>
        public static void WriteContourPolygonSVG(CvContourPolygon p, string filename)
        {
            WriteContourPolygonSVG(p, filename, CvColor.Black, CvColor.White);
        }
        /// <summary>
        /// Write a contour to a SVG file.
        /// </summary>
        /// <param name="p">Polygon contour.</param>
        /// <param name="filename">File name.</param>
        /// <param name="stroke">Stroke color (black by default).</param>
        /// <param name="fill">Fill color (white by default).</param>
        public static void WriteContourPolygonSVG(CvContourPolygon p, string filename, CvScalar stroke, CvScalar fill)
        {
            if (p == null)
                throw new ArgumentNullException("p");
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
