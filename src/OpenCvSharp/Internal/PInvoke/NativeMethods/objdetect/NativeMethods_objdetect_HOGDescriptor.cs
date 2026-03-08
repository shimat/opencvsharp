using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_new1(out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_new2(
        Size winSize, Size blockSize, Size blockStride, Size cellSize,
        int nbins, int derivAperture, double winSigma, [MarshalAs(UnmanagedType.I4)] HistogramNormType histogramNormType,
        double l2HysThreshold, int gammaCorrection, int nlevels, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_new3(
        [MarshalAs(UnmanagedType.LPStr)] string fileName, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_delete(IntPtr self);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_getDescriptorSize(IntPtr self, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_checkDetectorSize(IntPtr self, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_getWinSigma(IntPtr self, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_setSVMDetector(IntPtr self, IntPtr svmDetector);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_load(
        IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string? objName, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_save(
        IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string? objName);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_compute(
        IntPtr self, IntPtr img, IntPtr descriptors,
        Size winStride, Size padding, [In] Point[]? locations, int locationsLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_detect1(
        IntPtr self, IntPtr img, IntPtr foundLocations,
        double hitThreshold, Size winStride, Size padding, [In] Point[]? searchLocations, int searchLocationsLength);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_detect2(
        IntPtr self, IntPtr img, IntPtr foundLocations, IntPtr weights,
        double hitThreshold, Size winStride, Size padding, [In] Point[]? searchLocations, int searchLocationsLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_detectMultiScale1(
        IntPtr self, IntPtr img, IntPtr foundLocations,
        double hitThreshold, Size winStride, Size padding, double scale, int groupThreshold);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_detectMultiScale2(
        IntPtr self, IntPtr img, IntPtr foundLocations, IntPtr foundWeights,
        double hitThreshold, Size winStride, Size padding, double scale, int groupThreshold);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_computeGradient(
        IntPtr self, IntPtr img, IntPtr grad, IntPtr angleOfs, Size paddingTL, Size paddingBR);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_detectROI(
        IntPtr obj, IntPtr img,
        Point[] locations, int locationsLength,
        IntPtr foundLocations, IntPtr confidences,
        double hitThreshold, Size winStride, Size padding);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_detectMultiScaleROI(
        IntPtr obj, IntPtr img, IntPtr foundLocations,
        IntPtr roiScales, IntPtr roiLocations, IntPtr roiConfidences,
        double hitThreshold, int groupThreshold);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_groupRectangles(IntPtr obj,
        IntPtr rectList, IntPtr weights, int groupThreshold, double eps);


    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_winSize_get(IntPtr self, out Size returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_blockSize_get(IntPtr self, out Size returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_blockStride_get(IntPtr self, out Size returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_cellSize_get(IntPtr self, out Size returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_nbins_get(IntPtr self, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_derivAperture_get(IntPtr self, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_winSigma_get(IntPtr self, out double returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_histogramNormType_get(IntPtr self, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_L2HysThreshold_get(IntPtr self, out double returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_gammaCorrection_get(IntPtr self, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_nlevels_get(IntPtr self, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_signedGradient_get(IntPtr self, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_winSize_set(IntPtr self, Size value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_blockSize_set(IntPtr self, Size value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_blockStride_set(IntPtr self, Size value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_cellSize_set(IntPtr self, Size value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_nbins_set(IntPtr self, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_derivAperture_set(IntPtr self, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_winSigma_set(IntPtr self, double value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_histogramNormType_set(IntPtr self, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_L2HysThreshold_set(IntPtr self, double value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_gammaCorrection_set(IntPtr self, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_nlevels_set(IntPtr self, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus objdetect_HOGDescriptor_signedGradient_set(IntPtr self, int value);
}
