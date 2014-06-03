using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 構造体のポインタに対して配列のようにアクセスするためのクラス
    /// </summary>
#else
    /// <summary>
    /// A class to access a native pointer like array
    /// </summary>
#endif
    public unsafe class PointerAccessor1D<T> : IPointerAccessor1D<T>
    {
        /// <summary>
        /// pointer
        /// </summary>
        private IntPtr ptr;
        /// <summary>
        /// sizeof(T)
        /// </summary>
        private readonly int size;

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
        public PointerAccessor1D(IntPtr ptr)
        {
            this.ptr = ptr;
            this.size = Marshal.SizeOf(typeof(T));
        }
#if LANG_JP
        /// <summary>
        /// void*で初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from void*
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public PointerAccessor1D(void* ptr)
            : this(new IntPtr(ptr))
        {
        }

#if LANG_JP
        /// <summary>
        /// 内部で保持しているポインタ (T*)
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Unmanaged pointer (T*)
        /// </summary>
        /// <returns></returns>
#endif
        public IntPtr Ptr
        {
            get { return ptr; }
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
        public T this[int index]
        {
            get
            {
                return Get(index);
            }
            set
            {
                Set(index, value);
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
        public T Get(int index)
        {
            IntPtr dst = new IntPtr(ptr.ToInt64() + (size * index));
            return (T)Marshal.PtrToStructure(dst, typeof(T));
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
        public void Set(int index, T value)
        {
            using (StructurePointer<T> src = new StructurePointer<T>(value))
            {
                IntPtr dst = new IntPtr(ptr.ToInt64() + (size * index));
                Util.CopyMemory(dst, src, size);
            }
        }
    }
}