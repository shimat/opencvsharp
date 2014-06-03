
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// OpenCVのネイティブポインタをもったクラスの基本クラス
    /// </summary>
#else
    /// <summary>
    /// A class which has a pointer of OpenCV structure
    /// </summary>
#endif
    abstract public class CvObject : ICvPtrHolder
    {
        /// <summary>
        /// Data pointer
        /// </summary>
        protected IntPtr ptr;


        #region Constructors
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected CvObject()
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
        protected CvObject(IntPtr ptr)
        {
            this.ptr = ptr;
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
            get { return ptr; }
        }
    }
}
