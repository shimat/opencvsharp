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
    /// Int16* を配列のようにアクセスできるようにするためのクラス
    /// </summary>
#else
    /// <summary>
    /// Managed wrapper of array pointer (Int16*)
    /// </summary>
#endif
    public unsafe class PointerAccessor1D_Int16 : IPointerAccessor1D<Int16>
    {
        /// <summary>
        /// Pointer
        /// </summary>
        private short* ptr;

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
        public PointerAccessor1D_Int16(IntPtr ptr)
            : this((short*)ptr)
        {
        }
#if LANG_JP
        /// <summary>
        /// Int16*で初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from Int16*
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public PointerAccessor1D_Int16(short* ptr)
        {
            if (ptr == IntPtr.Zero.ToPointer())
            {
                throw new ArgumentNullException("ptr");
            }
            this.ptr = ptr;
        }

#if LANG_JP
        /// <summary>
        /// 内部で保持しているポインタ (Int16*)
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Unmanaged pointer (Int16*)
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
        public short this[int index]
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
        public short Get(int index)
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
        public void Set(int index, short value)
        {
            ptr[index] = value;
        }
    }

}
