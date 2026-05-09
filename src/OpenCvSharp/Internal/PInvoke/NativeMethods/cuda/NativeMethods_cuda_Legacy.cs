using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Internal;
#pragma warning disable 1591
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_calcOpticalFlowBM(IntPtr prev, IntPtr curr, Size blockSize, Size shiftSize, Size maxRange, int usePrevious, IntPtr velx, IntPtr vely, IntPtr buf, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_connectivityMask(IntPtr image, IntPtr mask, Scalar lo, Scalar hi, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_createOpticalFlowNeedleMap(IntPtr u, IntPtr v, IntPtr vertex, IntPtr colors);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_graphcut(IntPtr terminals, IntPtr leftTransp, IntPtr rightTransp, IntPtr top, IntPtr bottom, IntPtr labels, IntPtr buf, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_graphcut8(IntPtr terminals, IntPtr leftTransp, IntPtr rightTransp, IntPtr top, IntPtr topLeft, IntPtr topRight, IntPtr bottom, IntPtr bottomLeft, IntPtr bottomRight, IntPtr labels, IntPtr buf, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_interpolateFrames( IntPtr frame0, IntPtr frame1, IntPtr fu, IntPtr fv, IntPtr bu, IntPtr bv, float pos, IntPtr newFrame, IntPtr buf, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_labelComponents( IntPtr mask, IntPtr components, int flags, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_projectPoints( IntPtr src, IntPtr rvec, IntPtr tvec, IntPtr cameraMat, IntPtr distCoef, IntPtr dst, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_solvePnPRansac(IntPtr @object, IntPtr image, IntPtr cameraMat, IntPtr distCoef, IntPtr rvec, IntPtr tvec, int useExtrinsicGuess, int numIters, float maxDist, int minInlierCount, IntPtr inliers);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_transformPoints(IntPtr src, IntPtr rvec, IntPtr tvec, IntPtr dst, IntPtr stream);



    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_FreeMatPointerArray(IntPtr mats);
}
