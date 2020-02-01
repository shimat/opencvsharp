﻿using System;

#pragma warning disable 1591

namespace OpenCvSharp.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class MemoryHelper
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
#if NET40
            // 転送先をuint幅にalignする
            const uint align = sizeof(uint) - 1;
            var offset = (uint)outDest & align;
            // ↑ポインタは32bitとは限らないので本来このキャストはuintではダメだが、
            // 今は下位2bitだけあればいいのでこれでOK。
            if (offset != 0)
                offset = align - offset;
            offset = Math.Min(offset, inNumOfBytes);

            // 先頭の余り部分をbyteでちまちまコピー
            var srcBytes = (byte*)inSrc;
            var dstBytes = (byte*)outDest;
            for (uint i = 0; i < offset; i++)
                dstBytes[i] = srcBytes[i];

            // uintで一気に転送
            var dst = (uint*)((byte*)outDest + offset);
            var src = (uint*)((byte*)inSrc + offset);
            var numOfUInt = (inNumOfBytes - offset) / sizeof(uint);
            for (uint i = 0; i < numOfUInt; i++)
                dst[i] = src[i];

            // 末尾の余り部分をbyteでちまちまコピー
            for (var i = offset + numOfUInt * sizeof(uint); i < inNumOfBytes; i++)
                dstBytes[i] = srcBytes[i];
#else
            Buffer.MemoryCopy(inSrc, outDest, inNumOfBytes, inNumOfBytes);
#endif
        }

        public static unsafe void CopyMemory(void* outDest, void* inSrc, int inNumOfBytes)
        {
#if NET40
            CopyMemory(outDest, inSrc, (uint)inNumOfBytes);
#else
            Buffer.MemoryCopy(inSrc, outDest, inNumOfBytes, inNumOfBytes);
#endif
        }

        public static unsafe void CopyMemory(IntPtr outDest, IntPtr inSrc, uint inNumOfBytes)
        {
#if NET40
            CopyMemory(outDest.ToPointer(), inSrc.ToPointer(), inNumOfBytes);
#else
            Buffer.MemoryCopy(inSrc.ToPointer(), outDest.ToPointer(), inNumOfBytes, inNumOfBytes);
#endif
        }

        public static unsafe void CopyMemory(IntPtr outDest, IntPtr inSrc, int inNumOfBytes)
        {
#if NET40
            CopyMemory(outDest.ToPointer(), inSrc.ToPointer(), (uint)inNumOfBytes);
#else
            Buffer.MemoryCopy(inSrc.ToPointer(), outDest.ToPointer(), inNumOfBytes, inNumOfBytes);
#endif
        }

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
            var offset = (uint)outDest & align;
            // ↑ポインタは32bitとは限らないので本来このキャストはuintではダメだが、
            // 今は下位2bitだけあればいいのでこれでOK。
            if (offset != 0)
                offset = align - offset;
            offset = Math.Min(offset, inNumOfBytes);

            // 先頭の余り部分をbyteでちまちまコピー
            var dstBytes = (byte*)outDest;
            for (uint i = 0; i < offset; i++)
                dstBytes[i] = 0;

            // uintで一気に転送
            var dst = (uint*)((byte*)outDest + offset);
            var numOfUInt = (inNumOfBytes - offset) / sizeof(uint);
            for (uint i = 0; i < numOfUInt; i++)
                dst[i] = 0;

            // 末尾の余り部分をbyteでちまちまコピー
            for (var i = offset + numOfUInt * sizeof(uint); i < inNumOfBytes; i++)
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
    }
}
