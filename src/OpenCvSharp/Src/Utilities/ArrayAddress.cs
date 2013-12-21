/*
 * (C) 2008-2013 Schima
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
    public class ArrayAddress1<T> : IDisposable
    {
        private Array _array;
        private GCHandle _gch;

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
            {
                throw new ArgumentNullException();
            }
            this._array = array;
            this._gch = GCHandle.Alloc(array, GCHandleType.Pinned);
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
            {
                throw new ArgumentNullException();
            }
            this._array = array;
            this._gch = GCHandle.Alloc(array, GCHandleType.Pinned);
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
        public void Dispose()
        {
            if (_gch.IsAllocated)
            {
                _gch.Free();
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
        public IntPtr Pointer
        {
            get { return _gch.AddrOfPinnedObject(); }
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
    public class ArrayAddress2<T> : IDisposable
    {
        private T[][] _array;
        private GCHandle[] _gch;
        private IntPtr[] _ptr;

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
            {
                throw new ArgumentNullException("array");
            }
            this._array = array;

            // T[][]をIntPtr[]に変換する
            this._ptr = new IntPtr[array.Length];
            this._gch = new GCHandle[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                T[] elem = array[i];
                if (elem == null || elem.Length == 0)
                {
                    throw new ArgumentException(string.Format("array[{0}] is not valid array object.", i));
                }
                // メモリ確保
                this._gch[i] = GCHandle.Alloc(elem, GCHandleType.Pinned);
                this._ptr[i] = this._gch[i].AddrOfPinnedObject();
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
        public void Dispose()
        {
            foreach (GCHandle h in _gch)
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
            get { return _ptr; }
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