using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

/// <summary>
/// Blittable P/Invoke representation of the scalar/fixed-size fields of <c>kinfu::Params</c>
/// (also used for <c>dynafu::Params</c>, which is a C++ alias of the same type). The
/// <c>Matx33f</c>/<c>Matx44f</c> fields (Intr, RgbIntr, VolumePose) and the icpIterations vector
/// are marshaled as separate arguments alongside this struct, not embedded in it.
/// This type is internal; use <c>OpenCvSharp.Rgbd.KinFuParams</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvKinFuParams
{
    public Size FrameSize;
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
    internal static partial ExceptionStatus rgbd_kinfu_Params_defaultParams(
        out CvKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_Params_coarseParams(
        out CvKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_Params_hashTSDFParams(
        int isCoarse, out CvKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_Params_coloredTSDFParams(
        int isCoarse, out CvKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_Ptr_KinFu_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_Ptr_KinFu_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_create(
        in CvKinFuParams pod, in InputArrayProxy intr, in InputArrayProxy rgbIntr,
        in InputArrayProxy volumePose, IntPtr icpIterations, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_getParams(
        OpenCvSafeHandle obj, out CvKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_render(OpenCvSafeHandle obj, in OutputArrayProxy image);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_renderWithPose(
        OpenCvSafeHandle obj, in OutputArrayProxy image, in InputArrayProxy cameraPose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_getCloud(
        OpenCvSafeHandle obj, in OutputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_getPoints(OpenCvSafeHandle obj, in OutputArrayProxy points);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_getNormals(
        OpenCvSafeHandle obj, in InputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_reset(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_getPose(OpenCvSafeHandle obj, in OutputArrayProxy pose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus rgbd_kinfu_KinFu_update(
        OpenCvSafeHandle obj, in InputArrayProxy depth, out int returnValue);
}
