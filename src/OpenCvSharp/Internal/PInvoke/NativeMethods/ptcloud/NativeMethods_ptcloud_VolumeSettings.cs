using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_new(int volumeType, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setIntegrateWidth(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getIntegrateWidth(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setIntegrateHeight(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getIntegrateHeight(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setRaycastWidth(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getRaycastWidth(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setRaycastHeight(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getRaycastHeight(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setDepthFactor(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getDepthFactor(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setVoxelSize(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getVoxelSize(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setTsdfTruncateDistance(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getTsdfTruncateDistance(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setMaxDepth(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getMaxDepth(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setMaxWeight(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getMaxWeight(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setRaycastStepFactor(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getRaycastStepFactor(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setVolumePose(OpenCvSafeHandle obj, IntPtr val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getVolumePose(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setVolumeResolution(OpenCvSafeHandle obj, IntPtr val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getVolumeResolution(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getVolumeStrides(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setCameraIntegrateIntrinsics(OpenCvSafeHandle obj, IntPtr val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getCameraIntegrateIntrinsics(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_setCameraRaycastIntrinsics(OpenCvSafeHandle obj, IntPtr val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_VolumeSettings_getCameraRaycastIntrinsics(OpenCvSafeHandle obj, IntPtr val);
}
