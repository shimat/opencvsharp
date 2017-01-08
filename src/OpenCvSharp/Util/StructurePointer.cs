using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Util
{
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
    public class StructurePointer<T>
        where T : struct
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
        public T SrcObj { get; protected set; }
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
            SrcObj = obj;
            Size = MarshalHelper.SizeOf<T>();
            Ptr = Marshal.AllocHGlobal(Size);
            Marshal.StructureToPtr(obj, Ptr, false);
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
            SrcObj = default(T);
            Size = MarshalHelper.SizeOf<T>();
            Ptr = Marshal.AllocHGlobal(Size);
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
        public T ToStructure()
        {
            return MarshalHelper.PtrToStructure<T>(Ptr);
        }
    }
}