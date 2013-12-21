/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// Single** を配列のようにアクセスできるようにするためのクラス
    /// </summary>
#else
    /// <summary>
    /// Managed wrapper of array pointer (Single**)
    /// </summary>
#endif
    public unsafe class PointerAccessor2D_Single : IPointerAccessor2D<Single>
    {
        /// <summary>
        /// pointer
        /// </summary>
        private float** ptr;

#if LANG_JP
        /// <summary>
        /// IntPtrで初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from IntPtr
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public PointerAccessor2D_Single(IntPtr ptr)
            : this((float**)ptr)
        {
        }
#if LANG_JP
        /// <summary>
        /// Single**で初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from Single**
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public PointerAccessor2D_Single(float** ptr)
        {
            if (ptr == IntPtr.Zero.ToPointer())
            {
                throw new ArgumentNullException("ptr");
            }
            this.ptr = ptr;
        }

#if LANG_JP
        /// <summary>
        /// 内部で保持しているポインタ (Single**)
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Unmanaged pointer (Single**)
        /// </summary>
        /// <returns></returns>
#endif
        public IntPtr Ptr
        {
            get { return new IntPtr(ptr); }
        }

#if LANG_JP
        /// <summary>
        /// 配列の要素にアクセスするインデクサ
        /// </summary>
        /// <param name="index1">配列の1次元目のインデックス</param>
        /// <param name="index2">配列の2次元目のインデックス</param>
        /// <returns>要素の値</returns>
#else
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index1">The first zero-based component of the element index </param>
        /// <param name="index2">The second zero-based component of the element index </param>
        /// <returns>the particular array element</returns>
#endif
        public float this[int index1, int index2]
        {
            get
            {
                return ptr[index1][index2];
            }
            set
            {
                ptr[index1][index2] = value;
            }
        }

#if LANG_JP
        /// <summary>
        /// 指定したインデックスの配列の要素を取得する
        /// </summary>
        /// <param name="index1">配列の1次元目のインデックス</param>
        /// <param name="index2">配列の2次元目のインデックス</param>
        /// <returns>要素の値</returns>
#else
        /// <summary>
        /// Return the particular element of array
        /// </summary>
        /// <param name="index1">The first zero-based component of the element index </param>
        /// <param name="index2">The second zero-based component of the element index </param>
        /// <returns>the particular array element</returns>
#endif
        public float Get(int index1, int index2)
        {
            return ptr[index1][index2];
        }

#if LANG_JP
        /// <summary>
        /// 指定したインデックスの配列の要素を設定する
        /// </summary>
        /// <param name="index1">配列の1次元目のインデックス</param>
        /// <param name="index2">配列の2次元目のインデックス</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="index1">The first zero-based component of the element index </param>
        /// <param name="index2">The second zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void Set(int index1, int index2, float value)
        {
            ptr[index1][index2] = value;
        }
    }

}
