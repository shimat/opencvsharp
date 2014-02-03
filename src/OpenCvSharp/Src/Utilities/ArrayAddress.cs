/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Utilities
{
#if LANG_JP
    /// <summary>
    /// 1次元配列のアドレスを得るためのクラス
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    public class ArrayAddress1<T> : DisposableObject
    {
        private Array array;
        private GCHandle gch;

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="array"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
#endif
        public ArrayAddress1(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            this.array = array;
            this.gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="array"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
#endif
        public ArrayAddress1(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            this.array = array;
            this.gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        protected override void Dispose(bool disposing)
        {
            if (gch.IsAllocated)
            {
                gch.Free();
            }
            base.Dispose();
        }

#if LANG_JP
        /// <summary>
        /// ポインタを得る
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr Pointer
        {
            get { return gch.AddrOfPinnedObject(); }
        }
#if LANG_JP
        /// <summary>
        /// ポインタへの暗黙のキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator IntPtr(ArrayAddress1<T> self)
        {
            return self.Pointer;
        }
    }


#if LANG_JP
    /// <summary>
    /// 2次元ジャグ配列のアドレスを得るためのクラス
    /// </summary>
#else
    /// <summary>
    /// Class to get address of specified jagged array 
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    public class ArrayAddress2<T> : DisposableObject
    {
        private T[][] array;
        private readonly GCHandle[] gch;
        private readonly IntPtr[] ptr;

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="array">T[][]</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
#endif
        public ArrayAddress2(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            this.array = array;

            // T[][]をIntPtr[]に変換する
            ptr = new IntPtr[array.Length];
            gch = new GCHandle[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                T[] elem = array[i];
                if (elem == null || elem.Length == 0)
                {
                    throw new ArgumentException(string.Format("array[{0}] is not valid array object.", i));
                }
                // メモリ確保
                gch[i] = GCHandle.Alloc(elem, GCHandleType.Pinned);
                ptr[i] = gch[i].AddrOfPinnedObject();
            }
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        protected override void Dispose(bool disposing)
        {
            foreach (GCHandle h in gch)
            {
                if (h.IsAllocated)
                {
                    h.Free();
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// ポインタを得る
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr[] Pointer
        {
            get { return ptr; }
        }
#if LANG_JP
        /// <summary>
        /// ポインタへの暗黙のキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator IntPtr[](ArrayAddress2<T> self)
        {
            return self.Pointer;
        }
    }
}