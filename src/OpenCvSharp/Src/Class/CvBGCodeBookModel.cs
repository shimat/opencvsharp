/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvBGCodeBookModel
    /// </summary>
#else
    /// <summary>
    /// CvBGCodeBookModel
    /// </summary>
#endif
    public class CvBGCodeBookModel : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvBGCodeBookModel*</param>
#else
        /// <summary>
        /// Initialize from pointer
        /// </summary>
        /// <param name="ptr">struct CvBGCodeBookModel*</param>
#endif
        public CvBGCodeBookModel(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// BGCodeBookModel 構造体の領域確保を行う
        /// </summary>
#else
        /// <summary>
        /// Allocates BGCodeBookModel structure
        /// </summary>
#endif
        public CvBGCodeBookModel()
        {
            ptr = CvInvoke.cvCreateBGCodeBookModel();
            NotifyMemoryPressure(SizeOf);
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
                        CvInvoke.cvReleaseBGCodeBookModel(ref ptr);
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
        /// sizeof(CvBGCodeBookModel) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvBGCodeBookModel));

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public CvSize Size
        {
            get
            {
                unsafe
                {
                    return ((WCvBGCodeBookModel*)ptr)->size;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvBGCodeBookModel*)ptr)->size = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int T
        {
            get
            {
                unsafe
                {
                    return ((WCvBGCodeBookModel*)ptr)->t;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvBGCodeBookModel*)ptr)->t = value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public byte[] CbBounds
        {
            get
            {
                unsafe
                {
                    byte* p = ((WCvBGCodeBookModel*)ptr)->cbBounds;
                    return new byte[] { p[0], p[1], p[2] };
                }
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length != 3)
                    throw new ArgumentException();

                unsafe
                {
                    byte* p = ((WCvBGCodeBookModel*)ptr)->cbBounds;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public byte[] ModMin
        {
            get
            {
                unsafe
                {
                    byte* p = ((WCvBGCodeBookModel*)ptr)->modMin;
                    return new byte[] { p[0], p[1], p[2] };
                }
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length != 3)
                    throw new ArgumentException();

                unsafe
                {
                    byte* p = ((WCvBGCodeBookModel*)ptr)->modMin;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public byte[] ModMax
        {
            get
            {
                unsafe
                {
                    byte* p = ((WCvBGCodeBookModel*)ptr)->modMax;
                    return new byte[] { p[0], p[1], p[2] };
                }
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length != 3)
                    throw new ArgumentException();

                unsafe
                {
                    byte* p = ((WCvBGCodeBookModel*)ptr)->modMax;
                    p[0] = value[0];
                    p[1] = value[1];
                    p[2] = value[2];
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr CbMap
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvBGCodeBookModel*)ptr)->cbmap);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public CvMemStorage Storage
        {
            get
            {
                unsafe
                {
                    WCvMemStorage* p = ((WCvBGCodeBookModel*)ptr)->storage;
                    if (p == null)
                        return null;
                    return new CvMemStorage(new IntPtr(p));
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr Freelist
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvBGCodeBookModel*)ptr)->freeList);
                }
            }
        }
        #endregion

        #region Methods
        #region ClearStale
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staleThresh"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staleThresh"></param>
#endif
        public void ClearStale(int staleThresh)
        {
            Cv.BGCodeBookClearStale(this, staleThresh);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
#endif
        public void ClearStale(int staleThresh, CvRect roi)
        {
            Cv.BGCodeBookClearStale(this, staleThresh, roi);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staleThresh"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#endif
        public void ClearStale(int staleThresh, CvRect roi, CvArr mask)
        {
            Cv.BGCodeBookClearStale(this, staleThresh, roi, mask);
        }
        #endregion
        #region Diff
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <returns></returns>
#endif
        public int Diff(CvArr image, CvArr fgmask)
        {
            return Cv.BGCodeBookDiff(this, image, fgmask);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="roi"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="roi"></param>
        /// <returns></returns>
#endif
        public int Diff(CvArr image, CvArr fgmask, CvRect roi)
        {
            return Cv.BGCodeBookDiff(this, image, fgmask, roi);
        }
        #endregion
        #region Update
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
#endif
        public void Update(CvArr image)
        {
            Cv.BGCodeBookUpdate(this, image);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="roi"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="roi"></param>
#endif
        public void Update(CvArr image, CvRect roi)
        {
            Cv.BGCodeBookUpdate(this, image, roi);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="roi"></param>
        /// <param name="mask"></param>
#endif
        public void Update(CvArr image, CvRect roi, CvArr mask)
        {
            Cv.BGCodeBookUpdate(this, image, roi, mask);
        }
        #endregion
        #endregion
    }
}