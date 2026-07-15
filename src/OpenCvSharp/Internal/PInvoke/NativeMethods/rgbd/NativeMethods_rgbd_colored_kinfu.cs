using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

/// <summary>
/// Blittable P/Invoke representation of the scalar/fixed-size fields of
/// <c>colored_kinfu::Params</c>. The Matx33f/Matx44f fields (Intr, RgbIntr, VolumePose) and the
/// icpIterations vector are marshaled as separate arguments alongside this struct.
/// This type is internal; use <c>OpenCvSharp.Rgbd.ColoredKinFuParams</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvColoredKinFuParams
{
    public Size FrameSize;
    public Size RgbFrameSize;
    public int VolumeKind;
    public float DepthFactor;
    public float BilateralSigmaDepth;
    public float BilateralSigmaSpatial;
    public int BilateralKernelSize;
    public int PyramidLevels;
    public Vec3i VolumeDims;
    public float VoxelSize;
    public float TsdfMinCameraMovement;
    public float TsdfTruncDist;
    public int TsdfMaxWeight;
    public float RaycastStepFactor;
    public Vec3f LightPose;
    public float IcpDistThresh;
    public float IcpAngleThresh;
    public float TruncateThreshold;
}

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_Params_defaultParams(
        out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_Params_coarseParams(
        out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_Params_hashTSDFParams(
        int isCoarse, out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_Params_coloredTSDFParams(
        int isCoarse, out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_Ptr_ColoredKinFu_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_Ptr_ColoredKinFu_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_create(
        in CvColoredKinFuParams pod, in InputArrayProxy intr, in InputArrayProxy rgbIntr,
        in InputArrayProxy volumePose, IntPtr icpIterations, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_getParams(
        OpenCvSafeHandle obj, out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_render(OpenCvSafeHandle obj, in OutputArrayProxy image);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_renderWithPose(
        OpenCvSafeHandle obj, in OutputArrayProxy image, in InputArrayProxy cameraPose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_getCloud(
        OpenCvSafeHandle obj, in OutputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_getPoints(OpenCvSafeHandle obj, in OutputArrayProxy points);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_getNormals(
        OpenCvSafeHandle obj, in InputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_reset(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_getPose(OpenCvSafeHandle obj, in OutputArrayProxy pose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_colored_kinfu_ColoredKinFu_update(
        OpenCvSafeHandle obj, in InputArrayProxy depth, in InputArrayProxy rgb, out int returnValue);
}
