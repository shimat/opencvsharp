using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_create(
           int normType, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_get(
        IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_delete(
        IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_isMaskSupported(
        IntPtr obj, out int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_clear(
        IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_train(
        IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_add(
        IntPtr obj, IntPtr[] descriptors, int descriptorLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_getTrainDescriptors(
        IntPtr obj, IntPtr dst);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_match1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, IntPtr mask);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_knnMatch1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, int k, IntPtr mask, int compactResult);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_radiusMatch1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, float maxDistance, IntPtr mask, int compactResult);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_match2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches, IntPtr[] masks, int masksSize);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_knnMatch2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches, int k, IntPtr[] masks, int masksSize, int compactResult);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_radiusMatch2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches, float maxDistance, IntPtr[] masks, int masksSize, int compactResult);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_matchAsync1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, IntPtr mask, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_knnMatchAsync1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, int k, IntPtr mask, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_radiusMatchAsync1(
        IntPtr obj, IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, float maxDistance, IntPtr mask, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_matchAsync2(
        IntPtr obj, IntPtr queryDescriptors,IntPtr matches, IntPtr[] masks, int maskCount, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_knnMatchAsync2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches, int k, IntPtr[] masks, int maskCount, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_radiusMatchAsync2(
        IntPtr obj, IntPtr queryDescriptors, IntPtr matches, float maxDistance, IntPtr[] masks, int maskCount, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_matchConvert(
        IntPtr obj, IntPtr gpuMatches, IntPtr matches);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_knnMatchConvert(
        IntPtr obj, IntPtr gpuMatches, IntPtr matches, int compactResult);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_DescriptorMatcher_radiusMatchConvert(
        IntPtr obj, IntPtr gpuMatches, IntPtr matches, int compactResult);
}
