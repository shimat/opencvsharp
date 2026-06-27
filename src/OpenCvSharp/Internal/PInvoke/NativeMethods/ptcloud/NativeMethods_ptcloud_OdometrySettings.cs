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
    public static partial ExceptionStatus ptcloud_OdometrySettings_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setCameraMatrix(OpenCvSafeHandle obj, IntPtr val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getCameraMatrix(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setIterCounts(OpenCvSafeHandle obj, IntPtr val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getIterCounts(OpenCvSafeHandle obj, IntPtr val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMinDepth(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMinDepth(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMaxDepth(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMaxDepth(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMaxDepthDiff(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMaxDepthDiff(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMaxPointsPart(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMaxPointsPart(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setSobelSize(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getSobelSize(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setSobelScale(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getSobelScale(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setNormalWinSize(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getNormalWinSize(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setNormalDiffThreshold(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getNormalDiffThreshold(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setNormalMethod(OpenCvSafeHandle obj, int nm);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getNormalMethod(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setAngleThreshold(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getAngleThreshold(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMaxTranslation(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMaxTranslation(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMaxRotation(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMaxRotation(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMinGradientMagnitude(OpenCvSafeHandle obj, float val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMinGradientMagnitude(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_setMinGradientMagnitudes(OpenCvSafeHandle obj, IntPtr val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometrySettings_getMinGradientMagnitudes(OpenCvSafeHandle obj, IntPtr val);
}
