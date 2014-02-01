/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// リソースを解放すべきOpenCVのクラスに継承させる基本クラス
    /// </summary>
#else
    /// <summary>
    /// DisposableObject + ICvPtrHolder
    /// </summary>
#endif
    abstract public class DisposableCvObject : DisposableObject, ICvPtrHolder
    {
        /// <summary>
        /// Data pointer
        /// </summary>
        protected IntPtr ptr;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected DisposableCvObject()
            : this(true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
#endif
        protected DisposableCvObject(IntPtr ptr)
            : this(ptr, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        ///  
        /// </summary>
        /// <param name="isEnabledDispose"></param>
#endif
        protected DisposableCvObject(bool isEnabledDispose)
            : this(IntPtr.Zero, isEnabledDispose)
        {
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#endif
        protected DisposableCvObject(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    ptr = IntPtr.Zero;
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

#if LANG_JP
        /// <summary>
        /// OpenCVの構造体へのネイティブポインタ
        /// </summary>
#else
        /// <summary>
        /// Native pointer of OpenCV structure
        /// </summary>
#endif
        public IntPtr CvPtr
        {
            get
            {
                ThrowIfDisposed();
                return ptr;
            }
        }

        /// <summary>
        /// Get native pointer of OpenCV structure
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>IntPtr.Zero if obj==null, obj.CvPtr otherwise</returns>
        protected static IntPtr GetCvPtr(DisposableCvObject obj)
        {
            return (obj == null) ? IntPtr.Zero : obj.CvPtr;
        }
    }
}
