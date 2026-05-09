#pragma warning disable 1591

using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaHWOpticalFlow_calc(
    IntPtr obj, IntPtr inputImage, IntPtr referenceImage, IntPtr flow, IntPtr stream, IntPtr hint, IntPtr cost);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaHWOpticalFlow_collectGarbage(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_NvidiaHWOpticalFlow_getGridSize(IntPtr obj, out int returnValue);
}
