using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable CA2101 // Match HighGUI's window name marshaling.
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_setPerspective(
        [MarshalAs(UnmanagedType.LPStr)] string windowName,
        float fieldOfView, float nearClip, float farClip);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_setGridVisible(
        [MarshalAs(UnmanagedType.LPStr)] string windowName,
        int visible);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_setSun(
        [MarshalAs(UnmanagedType.LPStr)] string windowName,
        Vec3f direction, Vec3f ambient, Vec3f diffuse);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_setSky(
        [MarshalAs(UnmanagedType.LPStr)] string windowName,
        Vec3f color);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showBox(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        Vec3f size, Vec3f color, int mode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showPlane(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        Vec2f size, Vec3f color, int mode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showSphere(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        float radius, Vec3f color, int mode, int subdivisions);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showCameraTrajectory(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        in InputArrayProxy trajectory, float aspect, float scale, Vec3f frustumColor, Vec3f lineColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showMesh(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        in InputArrayProxy vertices, in InputArrayProxy indices);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showPoints(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        in InputArrayProxy points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showLines(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        in InputArrayProxy points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showGaussianSplats(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        in InputArrayProxy splats);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_showRGBD(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        in InputArrayProxy image, in InputArrayProxy intrinsics, float scale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_setObjectPosition(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        Vec3f position);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_setObjectRotation(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName,
        Vec3f rotation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_viz3d_destroyObject(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, [MarshalAs(UnmanagedType.LPStr)] string objectName);
}
