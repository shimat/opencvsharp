using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // GeneralizedHough

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_setTemplate1(
        IntPtr obj, IntPtr templ, Point templCenter);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_setTemplate2(
        IntPtr obj, IntPtr edges, IntPtr dx, IntPtr dy, Point templCenter);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_detect1(
        IntPtr obj, IntPtr image, IntPtr positions, IntPtr votes);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_detect2(
        IntPtr obj, IntPtr edges, IntPtr dx, IntPtr dy, IntPtr positions, IntPtr votes);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_setCannyLowThresh(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_getCannyLowThresh(IntPtr obj, out int returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_setCannyHighThresh(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_getCannyHighThresh(IntPtr obj, out int returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_setMinDist(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_getMinDist(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_setDp(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_getDp(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_setMaxBufferSize(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHough_getMaxBufferSize(IntPtr obj, out int returnValue);



    // GeneralizedHoughBallard

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_createGeneralizedHoughBallard(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_Ptr_GeneralizedHoughBallard_get(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_Ptr_GeneralizedHoughBallard_delete(IntPtr obj);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughBallard_setLevels(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughBallard_getLevels(IntPtr obj, out int returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughBallard_setVotesThreshold(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughBallard_getVotesThreshold(IntPtr obj, out int returnValue);



    // GeneralizedHoughGuil

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_createGeneralizedHoughGuil(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_Ptr_GeneralizedHoughGuil_get(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_Ptr_GeneralizedHoughGuil_delete(IntPtr obj);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setXi(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getXi(IntPtr obj, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setLevels(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getLevels(IntPtr obj, out int returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setAngleEpsilon(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getAngleEpsilon(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setMinAngle(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getMinAngle(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setMaxAngle(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getMaxAngle(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setAngleStep(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getAngleStep(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setAngleThresh(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getAngleThresh(IntPtr obj, out int returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setMinScale(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getMinScale(IntPtr obj, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setMaxScale(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getMaxScale(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setScaleStep(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getScaleStep(IntPtr obj, out double returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setScaleThresh(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getScaleThresh(IntPtr obj, out int returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_setPosThresh(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_GeneralizedHoughGuil_getPosThresh(IntPtr obj, out int returnValue);
}
