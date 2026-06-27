using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // DescriptorMatcher

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_add(
        OpenCvSafeHandle obj, IntPtr[] descriptors, int descriptorLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_getTrainDescriptors(OpenCvSafeHandle obj, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_clear(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_empty(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_isMaskSupported(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_train(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_match1(
        OpenCvSafeHandle obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_knnMatch1(
        OpenCvSafeHandle obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, int k,
        IntPtr mask, int compactResult);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_radiusMatch1(
        OpenCvSafeHandle obj, IntPtr queryDescriptors,IntPtr trainDescriptors, IntPtr matches, float maxDistance,
        IntPtr mask, int compactResult);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_match2(
        OpenCvSafeHandle obj, IntPtr queryDescriptors, IntPtr matches,
        IntPtr[] masks, int masksSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_knnMatch2(
        OpenCvSafeHandle obj, IntPtr queryDescriptors, IntPtr matches,
        int k, IntPtr[] masks, int masksSize, int compactResult);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_radiusMatch2(
        OpenCvSafeHandle obj, IntPtr queryDescriptors, IntPtr matches,
        float maxDistance, IntPtr[] masks, int masksSize, int compactResult);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DescriptorMatcher_create(
        [MarshalAs(UnmanagedType.LPStr)] string descriptorMatcherType, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_DescriptorMatcher_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_DescriptorMatcher_delete(IntPtr ptr);


    // BFMatcher

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_BFMatcher_new(int normType, int crossCheck, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_BFMatcher_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_BFMatcher_isMaskSupported(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_BFMatcher_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_BFMatcher_delete(IntPtr ptr);


    // FlannBasedMatcher

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FlannBasedMatcher_new(
        IntPtr indexParams, IntPtr searchParams, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FlannBasedMatcher_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FlannBasedMatcher_add(
        OpenCvSafeHandle obj, IntPtr[] descriptors, int descriptorsSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FlannBasedMatcher_clear(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FlannBasedMatcher_train(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FlannBasedMatcher_isMaskSupported(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_FlannBasedMatcher_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_FlannBasedMatcher_delete(IntPtr ptr);

    #region LightGlueMatcher

    [LibraryImport(DllExtern, EntryPoint = "features_LightGlueMatcher_create"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_LightGlueMatcher_create_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string modelPath, float scoreThreshold, int backend, int target, out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "features_LightGlueMatcher_create"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_LightGlueMatcher_create_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string modelPath, float scoreThreshold, int backend, int target, out IntPtr returnValue);

    public static ExceptionStatus features_LightGlueMatcher_create(string modelPath, float scoreThreshold, int backend, int target, out IntPtr returnValue)
        => IsWindows()
            ? features_LightGlueMatcher_create_Windows(modelPath, scoreThreshold, backend, target, out returnValue)
            : features_LightGlueMatcher_create_NotWindows(modelPath, scoreThreshold, backend, target, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_LightGlueMatcher_create_buffer(
        byte[] modelData, IntPtr modelDataLength, float scoreThreshold, int backend, int target, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_LightGlueMatcher_setPairInfo(
        OpenCvSafeHandle obj, IntPtr queryKpts, IntPtr trainKpts, Size queryImageSize, Size trainImageSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_LightGlueMatcher_clearPairInfo(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_LightGlueMatcher_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_LightGlueMatcher_delete(IntPtr ptr);

    #endregion
}
