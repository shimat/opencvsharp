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
    /// Int32* を配列のようにアクセスできるようにするためのクラス
    /// </summary>
#else
    /// <summary>
    /// Managed wrapper of array pointer (Int32*)
    /// </summary>
#endif
    public unsafe class PointerAccessor1D_Int32 : IPointerAccessor1D<Int32>
    {
        /// <summary>
        /// Pointer
        /// </summary>
        private int* ptr;

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
        public PointerAccessor1D_Int32(IntPtr ptr)
            : this((int*)ptr)
        {
        }
#if LANG_JP
        /// <summary>
        /// Int32*で初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from Int32*
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public PointerAccessor1D_Int32(int* ptr)
        {
            if (ptr == IntPtr.Zero.ToPointer())
            {
                throw new ArgumentNullException("ptr");
            }
            this.ptr = ptr;
        }

#if LANG_JP
        /// <summary>
        /// 内部で保持しているポインタ (Int32*)
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Unmanaged pointer (Int32*)
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
        /// <param name="index">配列のインデックス</param>
        /// <returns>要素の値</returns>
#else
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">zero-based component of the element index </param>
        /// <returns>the particular array element</returns>
#endif
        public int this[int index]
        {
            get
            {
                return ptr[index];
            }
            set
            {
                ptr[index] = value;
            }
        }

#if LANG_JP
        /// <summary>
        /// 指定したインデックスの配列の要素を取得する
        /// </summary>
        /// <param name="index">配列のインデックス</param>
        /// <returns>要素の値</returns>
#else
        /// <summary>
        /// Return the particular element of array
        /// </summary>
        /// <param name="index">zero-based component of the element index </param>
        /// <returns>the particular array element</returns>
#endif
        public int Get(int index)
        {
            return ptr[index];
        }

#if LANG_JP
        /// <summary>
        /// 指定したインデックスの配列の要素を設定する
        /// </summary>
        /// <param name="index">配列のインデックス</param>
        /// <param name="value">割り当てる値</param>
#else
        /// <summary>
        /// Change the particular array element
        /// </summary>
        /// <param name="index">zero-based component of the element index </param>
        /// <param name="value">The assigned value </param>
#endif
        public void Set(int index, int value)
        {
            ptr[index] = value;
        }

#if LANG_JP
        /// <summary>
        /// マネージ配列に変換する
        /// </summary>
        /// <param name="length">変換後のマネージ配列の長さ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts this pointer into a managed array
        /// </summary>
        /// <param name="length">length of the result array</param>
        /// <returns></returns>
#endif
        public int[] ToArray(int length)
        {
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = ptr[i];
            }
            return result;
        }
    }
}
