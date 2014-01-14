/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Struct that contain information about one blob.
    /// </summary>
    public class CvBlob
    {
        #region Init
        /// <summary>
        /// Constructor
        /// </summary>
        public CvBlob()
        {
            Contour = new CvContourChainCode();
            InternalContours = new List<CvContourChainCode>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal CvBlob(int label, int x, int y) : this()
        {
            Label = label;
            Area = 1;
            MinX = x;
            MaxX = x;
            MinY = y;
            MaxY = y;
            M10 = x;
            M01 = y;
            M11 = x * y;
            M20 = x * x;
            M02 = y * y;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Label assigned to the blob
        /// </summary>
        public int Label { get; set; }

        /// <summary>
        /// Area (moment 00)
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// Area (moment 00)
        /// </summary>
        public int M00
        {
            get { return Area; }
            set { Area = value; }
        }

		/// <summary>
        /// X min
        /// </summary>
        public int MinX { get; set; }	
		/// <summary>
        /// X max
        /// </summary>
        public int MaxX { get; set; }
		/// <summary>
        /// Y min
        /// </summary>
        public int MinY { get; set; }
		/// <summary>
        /// Y max
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// CvRect(MinX, MinY, MaxX - MinX, MaxY - MinY)
        /// </summary>
        public CvRect Rect
        {
            get
            {
                return new CvRect(MinX, MinY, MaxX - MinX, MaxY - MinY);
            }
            set
            {
                MinX = value.Left;
                MinY = value.Top;
                MaxX = value.Right;
                MaxY = value.Bottom;
            }
        }

		/// <summary>
        /// Centroid
        /// </summary>
        public CvPoint2D64f Centroid { get; internal set; }

		/// <summary>
        /// Moment 10
        /// </summary>
        public double M10 { get; set; }
		/// <summary>
        /// Moment 01
        /// </summary>
        public double M01 { get; set; }
		/// <summary>
        /// Moment 11
        /// </summary>
        public double M11 { get; set; }
		/// <summary>
        /// Moment 20
        /// </summary>
        public double M20 { get; set; }
		/// <summary>
        /// Moment 02
        /// </summary>
        public double M02 { get; set; }
	    
		/// <summary>
        /// True if central moments are being calculated
        /// </summary>
        public bool CentralMoments { get; set; }
		/// <summary>
        /// Central moment 11
        /// </summary>
        public double U11 { get; internal set; } 
		/// <summary>
        /// Central moment 20
        /// </summary>
        public double U20 { get; internal set; } 
		/// <summary>
        /// Central moment 02
        /// </summary>
        public double U02 { get; internal set; } 

        /// <summary>
        /// Normalized central moment 11.
        /// </summary>
        public double N11 { get; internal set; } 
        /// <summary>
        /// Normalized central moment 20.
        /// </summary>
        public double N20 { get; internal set; }
        /// <summary>
        /// Normalized central moment 02.
        /// </summary>
        public double N02 { get; internal set; }

        /// <summary>
        /// Hu moment 1.
        /// </summary>
        public double P1; 
        /// <summary>
        /// Hu moment 2.
        /// </summary>
        public double P2; 

        /// <summary>
        /// Contour
        /// </summary>
        public CvContourChainCode Contour { get; internal set; }
        /// <summary>
        /// Internal contours
        /// </summary>
        public List<CvContourChainCode> InternalContours { get; internal set; }
		#endregion

		#region Methods
        #region Angle
        /// <summary>
        /// Calculates angle orientation of a blob.
        /// This function uses central moments so cvCentralMoments should have been called before for this blob. (cvAngle)
        /// </summary>
        /// <returns>Angle orientation in radians.</returns>
        public double Angle()
        {
            return 0.5 * Math.Atan2(2.0 * U11, (U20 - U02));
        }
        #endregion
        #region CalcCentroid
        /// <summary>
		/// Calculates centroid.
		/// Centroid will be returned and stored in the blob structure. (cvCentroid)
		/// </summary>
		/// <returns>Centroid.</returns>
		public CvPoint2D64f CalcCentroid()
		{
            Centroid = new CvPoint2D64f(M10 / Area, M01 / Area);
            return Centroid;
        }
        #endregion
        #region SetImageROItoBlob
        /// <summary>
        /// Set the ROI of an image to the bounding box of a blob.
        /// </summary>
        /// <param name="img">Image.</param>
        public void SetImageRoiToBlob(IplImage img)
        {
            if(img == null)
                throw new ArgumentNullException("img");
            img.ROI = Rect;
        }
        #endregion
        #region SetMoments
        /// <summary>
        /// Set central/hu moments and centroid value from moment values (M**)
        /// </summary>
        public void SetMoments()
        {
            // 重心
            Centroid = new CvPoint2D64f(M10 / Area, M01 / Area);
            // 各モーメント
            U11 = M11 - (M10 * M01) / M00;
            U20 = M20 - (M10 * M10) / M00;
            U02 = M02 - (M01 * M01) / M00;

            double m00Pow2 = M00 * M00;
            N11 = U11 / m00Pow2;
            N20 = U20 / m00Pow2;
            N02 = U02 / m00Pow2;

            P1 = N20 + N02;
            double nn = N20 - N02;
            P2 = nn * nn + 4.0 * (N11 * N11);
        }
        #endregion
        #endregion
    }
}
