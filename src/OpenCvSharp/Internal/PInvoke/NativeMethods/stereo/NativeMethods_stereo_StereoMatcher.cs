using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    #region StereoMatcher

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_compute(
        IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_getMinDisparity(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_setMinDisparity(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_getNumDisparities(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_setNumDisparities(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_getBlockSize(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_setBlockSize(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_getSpeckleWindowSize(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_setSpeckleWindowSize(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_getSpeckleRange(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_setSpeckleRange(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_getDisp12MaxDiff(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoMatcher_setDisp12MaxDiff(
        IntPtr obj, int value);

    #endregion

    #region StereoBM

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_Ptr_StereoBM_delete(
        IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_Ptr_StereoBM_get(
        IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_create(
        int numDisparities, int blockSize, out IntPtr returnValue);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getPreFilterType(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setPreFilterType(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getPreFilterSize(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setPreFilterSize(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getPreFilterCap(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setPreFilterCap(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getTextureThreshold(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setTextureThreshold(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getUniquenessRatio(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setUniquenessRatio(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getSmallerBlockSize(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setSmallerBlockSize(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getROI1(
        IntPtr obj, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setROI1(
        IntPtr obj, Rect value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_getROI2(
        IntPtr obj, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoBM_setROI2(
        IntPtr obj, Rect value);

    #endregion

    #region StereoSGBM
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_Ptr_StereoSGBM_get(
        IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_Ptr_StereoSGBM_delete(
        IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_create(
        int minDisparity, int numDisparities, int blockSize,
        int P1, int P2, int disp12MaxDiff,
        int preFilterCap, int uniquenessRatio,
        int speckleWindowSize, int speckleRange, int mode, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_getPreFilterCap(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_setPreFilterCap(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_getUniquenessRatio(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_setUniquenessRatio(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_getP1(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_setP1(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_getP2(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_setP2(
        IntPtr obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_getMode(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stereo_StereoSGBM_setMode(
        IntPtr obj, int value);

    #endregion
}
