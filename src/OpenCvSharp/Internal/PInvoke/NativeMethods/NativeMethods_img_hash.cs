using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_ImgHashBase_compute(IntPtr obj, IntPtr inputArr, IntPtr outputArr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_ImgHashBase_compare(IntPtr obj, IntPtr hashOne, IntPtr hashTwo, out double returnValue);


    // AverageHash

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_AverageHash_create(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_AverageHash_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_AverageHash_get(IntPtr ptr, out IntPtr returnValue);

    // BlockMeanHash

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_BlockMeanHash_create(int mode, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_BlockMeanHash_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_BlockMeanHash_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_BlockMeanHash_setMode(IntPtr obj, int mode);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_BlockMeanHash_getMean(IntPtr obj, IntPtr outVec);

    // ColorMomentHash

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_ColorMomentHash_create(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_ColorMomentHash_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_ColorMomentHash_get(IntPtr ptr, out IntPtr returnValue);

    // MarrHildrethHash

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_MarrHildrethHash_create(float alpha, float scale, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_MarrHildrethHash_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_MarrHildrethHash_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_MarrHildrethHash_setKernelParam(IntPtr obj, float alpha, float scale);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_MarrHildrethHash_getAlpha(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_MarrHildrethHash_getScale(IntPtr obj, out float returnValue);

    // PHash

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_PHash_create(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_PHash_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_PHash_get(IntPtr ptr, out IntPtr returnValue);

    // RadialVarianceHash

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_RadialVarianceHash_create(double sigma, int numOfAngleLine, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_RadialVarianceHash_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_Ptr_RadialVarianceHash_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_RadialVarianceHash_setNumOfAngleLine(IntPtr obj, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_RadialVarianceHash_setSigma(IntPtr obj, double value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_RadialVarianceHash_getNumOfAngleLine(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus img_hash_RadialVarianceHash_getSigma(IntPtr obj, out double returnValue);
}
