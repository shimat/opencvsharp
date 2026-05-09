#pragma warning disable 1591

using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_SparseOpticalFlow_calc(
    IntPtr obj, IntPtr prevImg, IntPtr nextImg, IntPtr prevPts, IntPtr nextPts,
    IntPtr status, IntPtr err, IntPtr stream);
}
