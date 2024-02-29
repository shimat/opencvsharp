using System.Diagnostics.Contracts;
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

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_add(
        IntPtr obj, IntPtr[] descriptors, int descriptorLength);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_getTrainDescriptors(IntPtr obj, IntPtr dst);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_clear(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_empty(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_isMaskSupported(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_train(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_match1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, IntPtr mask);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_knnMatch1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, int k,
        IntPtr mask, int compactResult);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_radiusMatch1(
        IntPtr obj, IntPtr queryDescriptors,IntPtr trainDescriptors, IntPtr matches, float maxDistance,
        IntPtr mask, int compactResult);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_match2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches,
        IntPtr[] masks, int masksSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_knnMatch2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches,
        int k, IntPtr[] masks, int masksSize, int compactResult);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_radiusMatch2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches,
        float maxDistance, IntPtr[] masks, int masksSize, int compactResult);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_DescriptorMatcher_create(
        [MarshalAs(UnmanagedType.LPStr)] string descriptorMatcherType, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_DescriptorMatcher_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_DescriptorMatcher_delete(IntPtr ptr);


    // BFMatcher

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BFMatcher_new(int normType, int crossCheck, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BFMatcher_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BFMatcher_isMaskSupported(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_BFMatcher_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_BFMatcher_delete(IntPtr ptr);


    // FlannBasedMatcher

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FlannBasedMatcher_new(
        IntPtr indexParams, IntPtr searchParams, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FlannBasedMatcher_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FlannBasedMatcher_add(
        IntPtr obj, IntPtr[] descriptors, int descriptorsSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FlannBasedMatcher_clear(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FlannBasedMatcher_train(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FlannBasedMatcher_isMaskSupported(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_FlannBasedMatcher_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_FlannBasedMatcher_delete(IntPtr ptr);
}
