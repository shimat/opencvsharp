using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Cuda;

namespace OpenCvSharp.Internal;
#pragma warning disable 1591
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_alphaComp(
    IntPtr img1, IntPtr img2, IntPtr dst, AlphaCompTypes alpha_op, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_bilateralFilter(
        IntPtr src, IntPtr dst, int kernel_size, float sigma_color, float sigma_spatial, int borderMode, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_blendLinear(IntPtr img1, IntPtr img2, IntPtr weights1, IntPtr weights2, IntPtr result, IntPtr stream);



    








  

   

 

   

   

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_cvtColor(IntPtr src, IntPtr dst, int code, int dcn, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_demosaicing(IntPtr src, IntPtr dst, int code, int dcn, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_equalizeHist( IntPtr src, IntPtr dst, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_evenLevels(IntPtr levels, int nLevels, int lowerLevel, int upperLevel, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_gammaCorrection(IntPtr src, IntPtr dst, int forward, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_histEven(IntPtr src, IntPtr hist, int histSize, int lowerLevel, int upperLevel, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_histEven_multi(IntPtr src, IntPtr[] hist, int[] histSize, int[] lowerLevel, int[] upperLevel, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_histRange(IntPtr src, IntPtr hist, IntPtr levels, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_histRange_multi(IntPtr src, IntPtr[] hist, IntPtr[] levels, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_meanShiftFiltering(IntPtr src, IntPtr dst, int sp, int sr, TermCriteria criteria, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_meanShiftProc(IntPtr src, IntPtr dstr, IntPtr dstsp, int sp, int sr, TermCriteria criteria, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_meanShiftSegmentation( IntPtr src, IntPtr dst, int sp, int sr, int minsize, TermCriteria criteria, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_nonLocalMeans(IntPtr src, IntPtr dst, float h, int searchWindow, int blockSize, int borderMode, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_swapChannels(IntPtr image, [In] int[] dstOrder, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_connectedComponents(IntPtr image, IntPtr labels, int connectivity, int ltype, int ccltype);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_convertSpatialMoments(IntPtr spatialMoments, int order, int momentsType, [Out] double[] outMoments);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_moments(IntPtr src, int binaryImage,    int order,int momentsType, [Out] double[] outMoments);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_numMoments(int order, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_spatialMoments( IntPtr src, IntPtr moments, int binaryImage, int order, int momentsType,  IntPtr stream);
}
