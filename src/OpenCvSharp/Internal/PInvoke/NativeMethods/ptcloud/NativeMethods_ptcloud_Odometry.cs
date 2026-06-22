using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_new1(out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_new2(int otype, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_new3(int otype, IntPtr settings, int algtype, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_prepareFrame(IntPtr obj, IntPtr frame);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_prepareFrames(IntPtr obj, IntPtr srcFrame, IntPtr dstFrame);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_compute_Frame(IntPtr obj, IntPtr srcFrame, IntPtr dstFrame, IntPtr rt, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_compute_Depth(IntPtr obj, IntPtr srcDepth, IntPtr dstDepth, IntPtr rt, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_compute_DepthRGB(IntPtr obj, IntPtr srcDepth, IntPtr srcRGB, IntPtr dstDepth, IntPtr dstRGB, IntPtr rt, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Odometry_getNormalsComputer(IntPtr obj, out IntPtr returnValue);
}
