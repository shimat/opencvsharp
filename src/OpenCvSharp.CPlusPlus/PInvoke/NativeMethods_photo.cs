using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_inpaint(IntPtr src, IntPtr inpaintMask,
            IntPtr dst, double inpaintRadius, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoising(IntPtr src, IntPtr dst, float h,
            int templateWindowSize, int searchWindowSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoisingColored(IntPtr src, IntPtr dst,
            float h, float hColor, int templateWindowSize, int searchWindowSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoisingMulti(IntPtr[] srcImgs, int srcImgsLength,
            IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
            float h, int templateWindowSize, int searchWindowSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoisingColoredMulti(IntPtr[] srcImgs, int srcImgsLength,
            IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
            float h, float hColor, int templateWindowSize, int searchWindowSize);

    }
}