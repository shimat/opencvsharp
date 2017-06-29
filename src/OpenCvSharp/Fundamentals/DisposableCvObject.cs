using System;

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
    public abstract class DisposableCvObject : DisposableObject, ICvPtrHolder
    {
        /// <summary>
        /// Data pointer
        /// </summary>
        protected IntPtr ptr;

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

        /// <summary>
        /// releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            ptr = IntPtr.Zero;
            base.DisposeUnmanaged();
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
    }
}
