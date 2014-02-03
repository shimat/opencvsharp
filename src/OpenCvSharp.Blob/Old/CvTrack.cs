/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Blob.Old
{
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    internal struct WCvTrack
    {
        /// <summary>
        /// Track identification number.
        /// </summary>
        public UInt32 id; 

        /// <summary>
        /// Label assigned to the blob related to this track.
        /// </summary>
        public UInt32 label;

        /// <summary>
        /// X min.
        /// </summary>
        public uint minx; 
        /// <summary>
        /// X max.
        /// </summary>
        public uint maxx; 
        /// <summary>
        /// Y min.
        /// </summary>
        public uint miny; 
        /// <summary>
        /// Y max.
        /// </summary>
        public uint maxy;

        /// <summary>
        /// Centroid.
        /// </summary>
        public CvPoint2D64f centroid; 

        /// <summary>
        /// Indicates number of frames that has been missing.
        /// </summary>
        public uint inactive;
    }

    /// <summary>
    /// Struct that contain information about one track.
    /// </summary>
    public class CvTrack : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init & Disposal
        /// <summary>
        /// Constructor
        /// </summary>
        public CvTrack()
        {
            ptr = CvBlobInvoke.CvBlob_construct();
            NotifyMemoryPressure(SizeOf);
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ptr">struct CvTrack*</param>
        public CvTrack(IntPtr ptr)
        {
            this.ptr = ptr;
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
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        CvBlobInvoke.CvTrack_destruct(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvTrack)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvTrack));

        /// <summary>
        /// Track identification number.
        /// </summary>
        public UInt32 ID
        {
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->id;
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->id = value;
                }
            }
        }	
		/// <summary>
        /// Label assigned to the blob
        /// </summary>
		public UInt32 Label
		{
			get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->label; 
                }
            }
			set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->label = value;
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
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->minx;
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->minx = value;
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
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->maxx;
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->maxx = value;
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
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->miny;
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->miny = value;
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
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->maxy;
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->maxy = value;
                }
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
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->centroid;
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->centroid = value;
                }
            }
		}	

		/// <summary>
        /// Indicates number of frames that has been missing.
        /// </summary>
        public uint Inactive
		{
            get
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    return ((WCvTrack*)ptr)->inactive;
                }
            }
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException("CvTrack");
                unsafe
                {
                    ((WCvTrack*)ptr)->inactive = value;
                }
            }
		}
		#endregion

		#region Methods
#if LANG_JP
        /// <summary>
        /// 領域を解放する (delete track).
        /// 基本的にはユーザは呼び出すべきではない.
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used (delete track).
        /// Usually users should not explicitly call this method.
        /// </summary>
#endif
        public void Release()
        {
            Dispose();
        }
		#endregion
    }
}
