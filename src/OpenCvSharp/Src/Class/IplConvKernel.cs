using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 膨張・収縮処理で用いる構造要素
    /// </summary>
#else
    /// <summary>
    /// The structure which can be used as a structuring element in the morphological operations.
    /// </summary>
#endif
    public class IplConvKernel : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and disposal
#if LANG_JP
        /// <summary>
        /// 膨張・収縮処理に用いる構造要素を生成する
        /// </summary>
        /// <param name="cols">構造要素の列数</param>
        /// <param name="rows">構造要素の行数</param>
        /// <param name="anchorX">構造要素の原点のx座標</param>
        /// <param name="anchorY">構造要素の原点のy座標</param>
        /// <param name="shape">構造要素の形状</param>
        /// <returns>構造要素</returns>
#else
        /// <summary>
        /// Allocates and fills the structure IplConvKernel, which can be used as a structuring element in the morphological operations.
        /// </summary>
        /// <param name="cols">Number of columns in the structuring element. </param>
        /// <param name="rows">Number of rows in the structuring element. </param>
        /// <param name="anchorX">Relative horizontal offset of the anchor point. </param>
        /// <param name="anchorY">Relative vertical offset of the anchor point. </param>
        /// <param name="shape">Shape of the structuring element.</param>
        /// <returns></returns>
#endif
	    public IplConvKernel(int cols, int rows, int anchorX, int anchorY, ElementShape shape)
            : this(cols, rows, anchorX, anchorY, shape, null)
	    {
	    }
#if LANG_JP
        /// <summary>
        /// 膨張・収縮処理に用いる構造要素を生成する
        /// </summary>
        /// <param name="cols">構造要素の列数</param>
        /// <param name="rows">構造要素の行数</param>
        /// <param name="anchorX">構造要素の原点のx座標</param>
        /// <param name="anchorY">構造要素の原点のy座標</param>
        /// <param name="shape">構造要素の形状</param>
        /// <param name="values">構造要素データへのポインタ。このパラメータは形状がCV_SHAPE_CUSTOMのときのみ有効</param>
        /// <returns>構造要素</returns>
#else
        /// <summary>
        /// Allocates and fills the structure IplConvKernel, which can be used as a structuring element in the morphological operations.
        /// </summary>
        /// <param name="cols">Number of columns in the structuring element. </param>
        /// <param name="rows">Number of rows in the structuring element. </param>
        /// <param name="anchorX">Relative horizontal offset of the anchor point. </param>
        /// <param name="anchorY">Relative vertical offset of the anchor point. </param>
        /// <param name="shape">Shape of the structuring element.</param>
        /// <param name="values">Pointer to the structuring element data, a plane array, representing row-by-row scanning of the element matrix. 
        /// Non-zero values indicate points that belong to the element. If the pointer is null, then all values are considered non-zero, 
        /// that is, the element is of a rectangular shape. This parameter is considered only if the shape is CV_SHAPE_CUSTOM . </param>
        /// <returns></returns>
#endif
	    public IplConvKernel(int cols, int rows, int anchorX, int anchorY, ElementShape shape, int[,] values)
	    {
		    ptr = NativeMethods.cvCreateStructuringElementEx(cols, rows, anchorX, anchorY, shape, values);
            if (ptr == null)
                throw new OpenCvSharpException("Failed to create IplConvKernel");
	    }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">IplConvKernel*</param>
#else
        /// <summary>
        /// Initialize by a native pointer (IplConvKernel*)
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public IplConvKernel(IntPtr ptr)
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
                        NativeMethods.cvReleaseStructuringElement(ref ptr);
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
        /// sizeof(IplConvKernel) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WIplConvKernel));


        /// <summary>
        /// 
        /// </summary>
        public int NCols
        {
            get
            {
                unsafe
                {
                    return ((WIplConvKernel*)ptr)->nCols;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NRows
        {
            get
            {
                unsafe
                {
                    return ((WIplConvKernel*)ptr)->nRows;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AnchorX
        {
            get
            {
                unsafe
                {
                    return ((WIplConvKernel*)ptr)->anchorX;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AnchorY
        {
            get
            {
                unsafe
                {
                    return ((WIplConvKernel*)ptr)->anchorY;
                }
            }
        }
        /// <summary>
        /// int*
        /// </summary>
        public IntPtr Values
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplConvKernel*)ptr)->values);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NShiftR
        {
            get
            {
                unsafe
                {
                    return ((WIplConvKernel*)ptr)->nShiftR;
                }
            }
        }
        #endregion
    }
}
