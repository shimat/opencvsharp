using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // GeneralizedHough

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_setTemplate1(
            IntPtr obj, IntPtr templ, Point templCenter);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_setTemplate2(
            IntPtr obj, IntPtr edges, IntPtr dx, IntPtr dy, Point templCenter);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_detect1(
            IntPtr obj, IntPtr image, IntPtr positions, IntPtr votes);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_detect2(
            IntPtr obj, IntPtr edges, IntPtr dx, IntPtr dy, IntPtr positions, IntPtr votes);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_setCannyLowThresh(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHough_getCannyLowThresh(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_setCannyHighThresh(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHough_getCannyHighThresh(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_setMinDist(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHough_getMinDist(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_setDp(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHough_getDp(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHough_setMaxBufferSize(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHough_getMaxBufferSize(IntPtr obj);



        // GeneralizedHoughBallard

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_createGeneralizedHoughBallard();

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_Ptr_GeneralizedHoughBallard_get(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Ptr_GeneralizedHoughBallard_delete(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughBallard_setLevels(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHoughBallard_getLevels(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughBallard_setVotesThreshold(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHoughBallard_getVotesThreshold(IntPtr obj);



        // GeneralizedHoughGuil

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_createGeneralizedHoughGuil();

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_Ptr_GeneralizedHoughGuil_get(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Ptr_GeneralizedHoughGuil_delete(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setXi(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getXi(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setLevels(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHoughGuil_getLevels(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setAngleEpsilon(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getAngleEpsilon(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setMinAngle(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getMinAngle(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setMaxAngle(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getMaxAngle(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setAngleStep(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getAngleStep(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setAngleThresh(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHoughGuil_getAngleThresh(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setMinScale(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getMinScale(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setMaxScale(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getMaxScale(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setScaleStep(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_GeneralizedHoughGuil_getScaleStep(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setScaleThresh(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHoughGuil_getScaleThresh(IntPtr obj);


        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GeneralizedHoughGuil_setPosThresh(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_GeneralizedHoughGuil_getPosThresh(IntPtr obj);
    }
}