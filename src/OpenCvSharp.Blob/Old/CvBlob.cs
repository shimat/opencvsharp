/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

using CvLabel = System.UInt32;

namespace OpenCvSharp.Blob.Old
{
    /// <summary>
    /// Struct that contain information about one blob.
    /// </summary>
    public class CvBlob : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init & Disposal
        /// <summary>
        /// Constructor
        /// </summary>
        public CvBlob()
        {
            this.ptr = CvBlobInvoke.CvBlob_construct();
            base.NotifyMemoryPressure(SizeOf);
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ptr">struct CvBlob*</param>
        public CvBlob(IntPtr ptr)
            : base(ptr)
        {
            IsDisposed = false;
        }
#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        try
                        {
                            CvBlobInvoke.CvBlob_destruct(ptr);
                        }
                        catch
                        {
                            // ひどいけど揉みつぶす。
                            // 二重deleteで怒られている？なんとかしたい・・・
                        }
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvBlob)
        /// </summary>
        public static readonly int SizeOf = CvBlobInvoke.CvBlob_sizeof();

		/// <summary>
        /// Label assigned to the blob
        /// </summary>
		public CvLabel Label
		{
			get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_label(ptr)); 
                }
            }
			set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_label(ptr)) = value;
                }
            }
		}    
		
		/// <summary>
        /// Area (moment 00)
        /// </summary>
		public uint Area
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_area(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_area(ptr)) = value; 
                }
            }
		}		
		/// <summary>
        /// Area (moment 00)
        /// </summary>
		public uint M00
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_m00(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_m00(ptr))  = value;
                }
            }
		}	

		/// <summary>
        /// X min
        /// </summary>
		public uint MinX
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_minx(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_minx(ptr))  = value;
                }
            }
		}	
		/// <summary>
        /// X max
        /// </summary>
		public uint MaxX
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_maxx(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_maxx(ptr)) = value;
                }
            }
		}	
		/// <summary>
        /// Y min
        /// </summary>
		public uint MinY
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_miny(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_miny(ptr)) = value;
                }
            }
		}	
		/// <summary>
        /// Y max
        /// </summary>
		public uint MaxY
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_maxy(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_maxy(ptr)) = value;
                }
            }
		}

        /// <summary>
        /// CvRect(MinX, MinY, MaxX - MinX, MaxY - MinY)
        /// </summary>
        public CvRect Rect
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                return new CvRect((int)MinX, (int)MinY, (int)(MaxX - MinX), (int)(MaxY - MinY));
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                MinX = (uint)value.Left;
                MinY = (uint)value.Top;
                MaxX = (uint)value.Right;
                MaxY = (uint)value.Bottom;
            }
        }

		/// <summary>
        /// Centroid
        /// </summary>
		public CvPoint2D64f Centroid
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_centroid(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_centroid(ptr)) = value;
                }
            }
		}	

		/// <summary>
        /// Moment 10
        /// </summary>
		public double M10
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_m10(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_m10(ptr)) = value;
                }
            }
		}
		/// <summary>
        /// Moment 01
        /// </summary>
		public double M01
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_m01(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_m01(ptr)) = value;
                }
            }
		}
		/// <summary>
        /// Moment 11
        /// </summary>
		public double M11
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_m11(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_m11(ptr)) = value;
                }
            }
		}
		/// <summary>
        /// Moment 20
        /// </summary>
		public double M20
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_m20(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_m20(ptr)) = value;
                }
            }
		}
		/// <summary>
        /// Moment 02
        /// </summary>
		public double M02
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_m02(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_m02(ptr)) = value;
                }
            }
		}
	    
		/// <summary>
        /// True if central moments are being calculated
        /// </summary>
		public bool CentralMoments
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_centralMoments(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_centralMoments(ptr)) = value;
                }
            }
		}
		/// <summary>
        /// Central moment 11
        /// </summary>
		public double U11
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_u11(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_u11(ptr)) = value;
                }
            }
		}
		/// <summary>
        /// Central moment 20
        /// </summary>
		public double U20
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_u20(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_u20(ptr)) = value;
                }
            }
		}
		/// <summary>
        /// Central moment 02
        /// </summary>
        public double U02
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    return *(CvBlobInvoke.CvBlob_u02(ptr));
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                unsafe
                {
                    *(CvBlobInvoke.CvBlob_u02(ptr)) = value;
                }
            }
        }

        /// <summary>
        /// Contour
        /// </summary>
        public CvContourChainCode Contour
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                IntPtr p = CvBlobInvoke.CvBlob_contour(ptr);
                return new CvContourChainCode(p);
            }
        }
        /// <summary>
        /// Internal contours
        /// </summary>
        public CvContoursChainCode InternalContours
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvBlob");
                IntPtr p = CvBlobInvoke.CvBlob_internalContours(ptr);
                return new CvContoursChainCode(p);
            }
        }
		#endregion

		#region Methods
        #region CalcCentroid
        /// <summary>
		/// Calculates centroid.
		/// Centroid will be returned and stored in the blob structure. (cvCentroid)
		/// </summary>
		/// <returns>Centroid.</returns>
		public CvPoint2D64f CalcCentroid()
		{
            if (IsDisposed)
                throw new ObjectDisposedException("CvBlob");

            return CvBlobLib.Centroid(this);
        }
        #endregion
        #region CalcCentralMoments
        /// <summary>
		/// Calculates central moment for a blob.
		/// Central moments will be stored in blob structure. (cvCentralMoments)
		/// </summary>
		/// <param name="img">Label image (depth=IPL_DEPTH_LABEL and num. channels=1).</param>
		public void CalcCentralMoments(IplImage img)
		{
            throw new NotImplementedException();
            /*
            if (IsDisposed)
                throw new ObjectDisposedException("CvBlob");
			if(img == null)
				throw new ArgumentNullException("img");

		    CvBlobLib.CentralMoments(this, img);*/
        }
        #endregion
        #region CalcAngle
        /// <summary>
		/// Calculates angle orientation of a blob.
		/// This function uses central moments so cvCentralMoments should have been called before for this blob. (cvAngle)
		/// </summary>
		/// <returns>Angle orientation in radians.</returns>
		public double CalcAngle()
		{
            if (IsDisposed)
                throw new ObjectDisposedException("CvBlob");

            return CvBlobLib.Angle(this);
        }
        #endregion
        /*
        #region GetContour
        /// <summary>
        /// Get the contour of a blob.
        /// Uses Theo Pavlidis' algorithm (see http://www.imageprocessingplace.com/downloads_V3/root_downloads/tutorials/contour_tracing_Abeer_George_Ghuneim/theo.html ).
        /// </summary>
        /// <param name="img">Label image.</param>
        /// <returns>Chain code contour.</returns>
        public CvContourChainCode GetContour(IplImage img)
        {
            return CvBlobLib.GetContour(this, img);
        }
        #endregion
        //*/
        #region MeanColor
        /// <summary>
        /// Calculates mean color of a blob in an image.
        /// </summary>
        /// <param name="imgLabel">Image of labels.</param>
        /// <param name="img">Original image.</param>
        /// <returns>Average color.</returns>
        public CvScalar MeanColor(IplImage imgLabel, IplImage img)
        {
            if (IsDisposed)
                throw new ObjectDisposedException("CvBlob");

            return CvBlobLib.BlobMeanColor(this, imgLabel, img);
        }
        #endregion
        #region Release
#if LANG_JP
        /// <summary>
        /// 領域を解放 (cvReleaseBlob).
        /// 基本的にはユーザは呼び出すべきではない.
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used (cvReleaseBlob).
        /// Usually users should not explicitly call this method.
        /// </summary>
#endif
        public void Release()
        {
            if (!disposed)
            {
                CvBlobInvoke.cvb_cvReleaseBlob(ptr);
                disposed = true;
            }
        }
        #endregion
        #region SetImageROItoBlob
        /// <summary>
        /// Set the ROI of an image to the bounding box of a blob.
        /// </summary>
        /// <param name="img">Image.</param>
        public void SetImageROIToBlob(IplImage img)
        {
            if (IsDisposed)
                throw new ObjectDisposedException("CvBlob");

            CvBlobLib.SetImageROItoBlob(img, this);
        }
        #endregion
		#endregion
    }
}
