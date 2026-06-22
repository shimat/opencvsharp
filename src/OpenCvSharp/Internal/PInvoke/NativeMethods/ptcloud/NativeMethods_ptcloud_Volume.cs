using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_new(int vtype, IntPtr settings, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_integrateFrame(IntPtr obj, IntPtr frame, IntPtr pose);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_integrate(IntPtr obj, IntPtr depth, IntPtr pose);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_integrateColor(IntPtr obj, IntPtr depth, IntPtr image, IntPtr pose);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_raycast(IntPtr obj, IntPtr cameraPose, IntPtr points, IntPtr normals);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_raycastColor(IntPtr obj, IntPtr cameraPose, IntPtr points, IntPtr normals, IntPtr colors);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_raycastEx(IntPtr obj, IntPtr cameraPose, int height, int width, IntPtr k, IntPtr points, IntPtr normals);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_raycastExColor(IntPtr obj, IntPtr cameraPose, int height, int width, IntPtr k, IntPtr points, IntPtr normals, IntPtr colors);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_fetchNormals(IntPtr obj, IntPtr points, IntPtr normals);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_fetchPointsNormals(IntPtr obj, IntPtr points, IntPtr normals);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_fetchPointsNormalsColors(IntPtr obj, IntPtr points, IntPtr normals, IntPtr colors);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_reset(IntPtr obj);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_getVisibleBlocks(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_getTotalVolumeUnits(IntPtr obj, out long returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_getBoundingBox(IntPtr obj, IntPtr bb, int precision);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_setEnableGrowth(IntPtr obj, int v);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_Volume_getEnableGrowth(IntPtr obj, out int returnValue);
}
