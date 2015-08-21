using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utility
    {
        #region CopyMemory
#if LANG_JP
        /// <summary>
        /// 指定されたメモリブロックの内容を、他の場所へコピーします。
        /// </summary>
        /// <param name="outDest"></param>
        /// <param name="inSrc"></param>
        /// <param name="inNumOfBytes"></param>
        /// <remarks>
        /// Yanesdk.NET (http://yanesdkdotnet.sourceforge.jp/) の Screen2DGl.cs から借用させて頂きました。
        /// </remarks>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outDest"></param>
        /// <param name="inSrc"></param>
        /// <param name="inNumOfBytes"></param>
#endif
        public static unsafe void CopyMemory(void* outDest, void* inSrc, uint inNumOfBytes)
        {
            // 転送先をuint幅にalignする
            const uint align = sizeof(uint) - 1;
            uint offset = (uint)outDest & align;
            // ↑ポインタは32bitとは限らないので本来このキャストはuintではダメだが、
            // 今は下位2bitだけあればいいのでこれでOK。
            if (offset != 0)
                offset = align - offset;
            offset = Math.Min(offset, inNumOfBytes);

            // 先頭の余り部分をbyteでちまちまコピー
            byte* srcBytes = (byte*)inSrc;
            byte* dstBytes = (byte*)outDest;
            for (uint i = 0; i < offset; i++)
                dstBytes[i] = srcBytes[i];

            // uintで一気に転送
            uint* dst = (uint*)((byte*)outDest + offset);
            uint* src = (uint*)((byte*)inSrc + offset);
            uint numOfUInt = (inNumOfBytes - offset) / sizeof(uint);
            for (uint i = 0; i < numOfUInt; i++)
                dst[i] = src[i];

            // 末尾の余り部分をbyteでちまちまコピー
            for (uint i = offset + numOfUInt * sizeof(uint); i < inNumOfBytes; i++)
                dstBytes[i] = srcBytes[i];
        }
        public static unsafe void CopyMemory(void* outDest, void* inSrc, int inNumOfBytes)
        {
            CopyMemory(outDest, inSrc, (uint)inNumOfBytes);
        }
        public static unsafe void CopyMemory(IntPtr outDest, IntPtr inSrc, uint inNumOfBytes)
        {
            CopyMemory(outDest.ToPointer(), inSrc.ToPointer(), inNumOfBytes);
        }
        public static unsafe void CopyMemory(IntPtr outDest, IntPtr inSrc, int inNumOfBytes)
        {
            CopyMemory(outDest.ToPointer(), inSrc.ToPointer(), (uint)inNumOfBytes);
        }
        //[DllImport("kernel32")]
        //public static unsafe extern void CopyMemory(void* outDest, void* inSrc, [MarshalAs(UnmanagedType.U4)] int inNumOfBytes);
        //[DllImport("kernel32")]
        //public static extern void CopyMemory(IntPtr outDest, IntPtr inSrc, [MarshalAs(UnmanagedType.U4)] int inNumOfBytes);
        #endregion

        #region ZeroMemory
#if LANG_JP
        /// <summary>
        /// 指定されたメモリブロックの内容を、他の場所へコピーします。
        /// </summary>
        /// <param name="outDest"></param>
        /// <param name="inNumOfBytes"></param>
        /// <remarks>
        /// Yanesdk.NET (http://yanesdkdotnet.sourceforge.jp/) の Screen2DGl.cs から借用させて頂きました。
        /// </remarks>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outDest"></param>
        /// <param name="inNumOfBytes"></param>
#endif
        public static unsafe void ZeroMemory(void* outDest, uint inNumOfBytes)
        {
            // 転送先をuint幅にalignする
            const uint align = sizeof(uint) - 1;
            uint offset = (uint)outDest & align;
            // ↑ポインタは32bitとは限らないので本来このキャストはuintではダメだが、
            // 今は下位2bitだけあればいいのでこれでOK。
            if (offset != 0)
                offset = align - offset;
            offset = Math.Min(offset, inNumOfBytes);

            // 先頭の余り部分をbyteでちまちまコピー
            byte* dstBytes = (byte*)outDest;
            for (uint i = 0; i < offset; i++)
                dstBytes[i] = 0;

            // uintで一気に転送
            uint* dst = (uint*)((byte*)outDest + offset);
            uint numOfUInt = (inNumOfBytes - offset) / sizeof(uint);
            for (uint i = 0; i < numOfUInt; i++)
                dst[i] = 0;

            // 末尾の余り部分をbyteでちまちまコピー
            for (uint i = offset + numOfUInt * sizeof(uint); i < inNumOfBytes; i++)
                dstBytes[i] = 0;
        }
        public static unsafe void ZeroMemory(void* outDest, int inNumOfBytes)
        {
            ZeroMemory(outDest, (uint)inNumOfBytes);
        }
        public static unsafe void ZeroMemory(IntPtr outDest, uint inNumOfBytes)
        {
            ZeroMemory(outDest.ToPointer(), inNumOfBytes);
        }
        public static unsafe void ZeroMemory(IntPtr outDest, int inNumOfBytes)
        {
            ZeroMemory(outDest.ToPointer(), (uint)inNumOfBytes);
        }
        #endregion

        #region Type casing
#if LANG_JP
        /// <summary>
        /// void*からT型のオブジェクトに変換を試みる.
        /// TがOpenCVのオブジェクトの場合は、IntPtrを取るコンストラクタ呼び出しを試みる.
        /// </summary>
        /// <typeparam name="T">オブジェクトの型. プリミティブ型か、OpenCVのオブジェクト(ICvObject).</typeparam>
        /// <param name="p">変換するポインタ</param>
        /// <returns>T型に変換した結果</returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
#endif
        public static T Cast<T>(IntPtr p)
        {
            Type t = typeof(T);
            // OpenCVのオブジェクトであることを期待してポインタからのオブジェクト生成を試みる.
            ConstructorInfo info = t.GetConstructor(new Type[] { typeof(IntPtr), typeof(bool) });
            if (info != null)
            {
                return (T)info.Invoke(new object[] { p, false });
            }
            else
            {
                info = t.GetConstructor(new Type[] { typeof(IntPtr) });
                if (info == null)
                {
                    throw new OpenCvSharpException("{0} is invalid type for this method. Value type or OpenCV's class are valid.", t.Name);
                }
                return (T)info.Invoke(new object[] { p });
            }   
        }
#if LANG_JP
        /// <summary>
        /// ポインタから構造体にキャストを試みる
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static T ToObject<T>(IntPtr ptr) where T : struct
        {
            Type t = typeof(T);
            // IntPtrはそのまま返す
            if (t == typeof(IntPtr))
            {
                return (T)(object)ptr;
            }
            
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
        }

#if LANG_JP
        /// <summary>
        /// testとtargetが同じ型かどうかチェック
        /// </summary>
        /// <param name="test">source type</param>
        /// <param name="target">generic type</param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <param name="target"></param>
        /// <returns></returns>
#endif
        private static bool CheckType(Type test, Type target)
        {
            while (test != typeof(object))
            {
                if (test.IsGenericType)
                {
                    Type g = test.GetGenericTypeDefinition();
                    if (target == g)
                    {
                        return true;
                    }
                }
                test = test.BaseType;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int SizeOf(Type t)
        {
            if (t.IsValueType)
            {
                return Marshal.SizeOf(t);
            }
            else
            {
                /*
                FieldInfo info = t.GetField("SizeOf", BindingFlags.Static | BindingFlags.Public);
                if (info != null)
                {
                    return (int)info.GetValue(null);
                }
                else
                {
                    throw new OpenCvSharpException("Not defined sizeof({0}) operation", t.Name);
                }
                */
                return IntPtr.Size;
            }
        }
        #endregion
    }
}
