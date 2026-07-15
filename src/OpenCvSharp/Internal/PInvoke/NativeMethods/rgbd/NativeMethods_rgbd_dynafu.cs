using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_Ptr_DynaFu_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_Ptr_DynaFu_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_create(
        in CvKinFuParams pod, in InputArrayProxy intr, in InputArrayProxy rgbIntr,
        in InputArrayProxy volumePose, IntPtr icpIterations, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_getParams(
        OpenCvSafeHandle obj, out CvKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_render(OpenCvSafeHandle obj, in OutputArrayProxy image);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_renderWithPose(
        OpenCvSafeHandle obj, in OutputArrayProxy image, in InputArrayProxy cameraPose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_getCloud(
        OpenCvSafeHandle obj, in OutputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_getPoints(OpenCvSafeHandle obj, in OutputArrayProxy points);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_getNormals(
        OpenCvSafeHandle obj, in InputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_reset(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_getPose(OpenCvSafeHandle obj, in OutputArrayProxy pose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_update(
        OpenCvSafeHandle obj, in InputArrayProxy depth, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_getNodesPos(OpenCvSafeHandle obj, IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_marchCubes(
        OpenCvSafeHandle obj, in OutputArrayProxy vertices, in OutputArrayProxy edges);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_dynafu_DynaFu_renderSurface(
        OpenCvSafeHandle obj, in OutputArrayProxy depthImage, in OutputArrayProxy vertImage,
        in OutputArrayProxy normImage, int warp);
}
