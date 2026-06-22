using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_new(int volumeType, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setIntegrateWidth(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getIntegrateWidth(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setIntegrateHeight(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getIntegrateHeight(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setRaycastWidth(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getRaycastWidth(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setRaycastHeight(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getRaycastHeight(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setDepthFactor(IntPtr obj, float val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getDepthFactor(IntPtr obj, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setVoxelSize(IntPtr obj, float val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getVoxelSize(IntPtr obj, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setTsdfTruncateDistance(IntPtr obj, float val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getTsdfTruncateDistance(IntPtr obj, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setMaxDepth(IntPtr obj, float val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getMaxDepth(IntPtr obj, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setMaxWeight(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getMaxWeight(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setRaycastStepFactor(IntPtr obj, float val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getRaycastStepFactor(IntPtr obj, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setVolumePose(IntPtr obj, IntPtr val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getVolumePose(IntPtr obj, IntPtr val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setVolumeResolution(IntPtr obj, IntPtr val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getVolumeResolution(IntPtr obj, IntPtr val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getVolumeStrides(IntPtr obj, IntPtr val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setCameraIntegrateIntrinsics(IntPtr obj, IntPtr val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getCameraIntegrateIntrinsics(IntPtr obj, IntPtr val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_setCameraRaycastIntrinsics(IntPtr obj, IntPtr val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ptcloud_VolumeSettings_getCameraRaycastIntrinsics(IntPtr obj, IntPtr val);
}
