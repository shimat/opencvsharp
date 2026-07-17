using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

/// <summary>
/// Blittable P/Invoke representation of <c>cv::optflow::GPCTrainingParams</c>.
/// The bool field uses <c>int</c> (0/1) to match the C++ CvGPCTrainingParams struct layout exactly.
/// This type is internal; use <c>OpenCvSharp.OptFlow.GPCTrainingParams</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvGPCTrainingParams
{
    public uint MaxTreeDepth;
    public int MinNumberOfSamples;
    public int DescriptorType;
    public int PrintProgress;
}

/// <summary>
/// Blittable P/Invoke representation of <c>cv::optflow::GPCMatchingParams</c>.
/// The bool field uses <c>int</c> (0/1) to match the C++ CvGPCMatchingParams struct layout exactly.
/// This type is internal; use <c>OpenCvSharp.OptFlow.GPCMatchingParams</c> in consumer code.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CvGPCMatchingParams
{
    public int UseOpenCL;
}

static partial class NativeMethods
{
    #region GPCTrainingSamples

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_GPCTrainingSamples_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_GPCTrainingSamples_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCTrainingSamples_create(
        IntPtr[] imagesFrom, int imagesFromSize,
        IntPtr[] imagesTo, int imagesToSize,
        IntPtr[] gt, int gtSize,
        int descriptorType,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCTrainingSamples_size(OpenCvSafeHandle obj, out nuint returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCTrainingSamples_type(OpenCvSafeHandle obj, out int returnValue);

    #endregion

    #region GPCTree

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_GPCTree_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_GPCTree_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createGPCTree(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCTree_train(
        OpenCvSafeHandle obj, OpenCvSafeHandle samples, in CvGPCTrainingParams trainingParams);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCTree_getDescriptorType(OpenCvSafeHandle obj, out int returnValue);

    #endregion

    #region GPCForest5

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_GPCForest5_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_Ptr_GPCForest5_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_createGPCForest5(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCForest5_train(
        OpenCvSafeHandle obj, OpenCvSafeHandle samples, in CvGPCTrainingParams trainingParams);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCForest5_train_fromMats(
        OpenCvSafeHandle obj,
        IntPtr[] imagesFrom, int imagesFromSize,
        IntPtr[] imagesTo, int imagesToSize,
        IntPtr[] gt, int gtSize,
        in CvGPCTrainingParams trainingParams);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus optflow_GPCForest5_findCorrespondences(
        OpenCvSafeHandle obj,
        in InputArrayProxy imgFrom, in InputArrayProxy imgTo,
        IntPtr pointsFrom, IntPtr pointsTo,
        in CvGPCMatchingParams matchingParams);

    #endregion
}
