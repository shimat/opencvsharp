using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

/// <summary>
/// Blittable P/Invoke representation of the scalar fields of <c>large_kinfu::VolumeParams</c>.
/// The Matx44f pose field is marshaled as a separate argument.
/// This type is internal; use <c>OpenCvSharp.Rgbd.LargeKinfuVolumeParams</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvLargeKinfuVolumeParams
{
    public int Kind;
    public int ResolutionX;
    public int ResolutionY;
    public int ResolutionZ;
    public int UnitResolution;
    public float VolumeSize;
    public float VoxelSize;
    public float TsdfTruncDist;
    public int MaxWeight;
    public float DepthTruncThreshold;
    public float RaycastStepFactor;
}

/// <summary>
/// Blittable P/Invoke representation of the scalar/fixed-size fields of <c>large_kinfu::Params</c>
/// (excluding its nested VolumeParams, marshaled separately as <see cref="CvLargeKinfuVolumeParams"/>).
/// The Matx33f fields (Intr, RgbIntr) and the icpIterations vector are marshaled as separate arguments.
/// This type is internal; use <c>OpenCvSharp.Rgbd.LargeKinfuParams</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvLargeKinfuParams
{
    public Size FrameSize;
    public float DepthFactor;
    public float BilateralSigmaDepth;
    public float BilateralSigmaSpatial;
    public int BilateralKernelSize;
    public int PyramidLevels;
    public float TsdfMinCameraMovement;
    public Vec3f LightPose;
    public float IcpDistThresh;
    public float IcpAngleThresh;
    public float TruncateThreshold;
}

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_VolumeParams_defaultParams(
        int volumeType, out CvLargeKinfuVolumeParams pod, in OutputArrayProxy pose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_VolumeParams_coarseParams(
        int volumeType, out CvLargeKinfuVolumeParams pod, in OutputArrayProxy pose);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_Params_defaultParams(
        out CvLargeKinfuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        IntPtr icpIterations, out CvLargeKinfuVolumeParams volumePod, in OutputArrayProxy volumePose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_Params_coarseParams(
        out CvLargeKinfuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        IntPtr icpIterations, out CvLargeKinfuVolumeParams volumePod, in OutputArrayProxy volumePose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_Params_hashTSDFParams(
        int isCoarse, out CvLargeKinfuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        IntPtr icpIterations, out CvLargeKinfuVolumeParams volumePod, in OutputArrayProxy volumePose);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_Ptr_LargeKinfu_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_Ptr_LargeKinfu_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_create(
        in CvLargeKinfuParams pod, in InputArrayProxy intr, in InputArrayProxy rgbIntr,
        IntPtr icpIterations, in CvLargeKinfuVolumeParams volumePod, in InputArrayProxy volumePose,
        out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_getParams(
        OpenCvSafeHandle obj, out CvLargeKinfuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        IntPtr icpIterations, out CvLargeKinfuVolumeParams volumePod, in OutputArrayProxy volumePose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_render(OpenCvSafeHandle obj, in OutputArrayProxy image);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_renderWithPose(
        OpenCvSafeHandle obj, in OutputArrayProxy image, in InputArrayProxy cameraPose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_getCloud(
        OpenCvSafeHandle obj, in OutputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_getPoints(OpenCvSafeHandle obj, in OutputArrayProxy points);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_getNormals(
        OpenCvSafeHandle obj, in InputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_reset(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_getPose(OpenCvSafeHandle obj, in OutputArrayProxy pose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_large_kinfu_LargeKinfu_update(
        OpenCvSafeHandle obj, in InputArrayProxy depth, out int returnValue);
}
