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
    /// 構造体とポインタの変換やメモリの解放を自動的にやってくれるクラス
    /// </summary>
#else
    /// <summary>
    /// Class that converts structure into pointer and cleans up resources automatically 
    /// </summary>
#endif
    public class StructurePointer : IDisposable
    {
#if LANG_JP
        /// <summary>
        /// 実体ポインタ
        /// </summary>
#else
        /// <summary>
        /// Pointer
        /// </summary>
#endif

        public IntPtr Ptr { get; protected set; }
#if LANG_JP
        /// <summary>
        /// 初期化の際に渡された構造体オブジェクト
        /// </summary>
#else
        /// <summary>
        /// Structure
        /// </summary>
#endif
        public object SrcObj { get; protected set; }
#if LANG_JP
        /// <summary>
        /// 確保したメモリのバイトサイズ
        /// </summary>
#else
        /// <summary>
        /// Size of allocated memory
        /// </summary>
#endif
        public int Size { get; protected set; }

#if LANG_JP
        /// <summary>
        /// 構造体からポインタを作って初期化
        /// </summary>
        /// <param name="obj"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
#endif
        public StructurePointer(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            this.SrcObj = obj;
            this.Size = Marshal.SizeOf(obj.GetType());
            this.Ptr = Marshal.AllocHGlobal(this.Size);
            Marshal.StructureToPtr(obj, this.Ptr, false);
        }
#if LANG_JP
        /// <summary>
        /// デフォルトの初期化
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public StructurePointer()
        {
            this.SrcObj = null;
            this.Size = 0;
            this.Ptr = IntPtr.Zero;
        }

#if LANG_JP
        /// <summary>
        /// IntPtrへの暗黙の変換
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
        public static implicit operator IntPtr(StructurePointer self)
        {
            return self.Ptr;
        }

#if LANG_JP
        /// <summary>
        /// ポインタから構造体に変換して返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public virtual object ToStructure()
        {
            return Marshal.PtrToStructure(Ptr, SrcObj.GetType());
        }

#if LANG_JP
        /// <summary>
        /// 後始末
        /// </summary>
#else
        /// <summary>
        /// Clean up resources to be used
        /// </summary>
#endif
        public virtual void Dispose()
        {
            if (Ptr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(Ptr);
            }
        }
    }

#if LANG_JP
    /// <summary>
    /// 構造体とポインタの変換やメモリの解放を自動的にやってくれるクラス (ジェネリック版)
    /// </summary>
    /// <typeparam name="T"></typeparam>
#else
    /// <summary>
    /// Class that converts structure into pointer and cleans up resources automatically (generic version)
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    public class StructurePointer<T> : StructurePointer
    {
#if LANG_JP
        /// <summary>
        /// 指定した構造体オブジェクトをポインタに変換して初期化
        /// </summary>
        /// <param name="obj"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
#endif
        public StructurePointer(T obj)
        {
            this.SrcObj = obj;
            this.Size = Marshal.SizeOf(typeof(T));
            this.Ptr = Marshal.AllocHGlobal(this.Size);
            Marshal.StructureToPtr(obj, this.Ptr, false);
        }
#if LANG_JP
        /// <summary>
        /// T型のバイトサイズのポインタを生成して初期化
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public StructurePointer()
        {
            this.SrcObj = default(T);
            this.Size = Marshal.SizeOf(typeof(T));
            this.Ptr = Marshal.AllocHGlobal(this.Size);
        }

#if LANG_JP
        /// <summary>
        /// IntPtrへの暗黙の変換
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
        public static implicit operator IntPtr(StructurePointer<T> self)
        {
            return self.Ptr;
        }

#if LANG_JP
        /// <summary>
        /// ポインタから構造体に変換して返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public new T ToStructure()
        {
            return (T)Marshal.PtrToStructure(Ptr, typeof(T));
        }
    }
}