using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // GeneralizedHough

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_setTemplate1(
            IntPtr obj, IntPtr templ, Point templCenter);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_setTemplate2(
            IntPtr obj, IntPtr edges, IntPtr dx, IntPtr dy, Point templCenter);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_detect1(
            IntPtr obj, IntPtr image, IntPtr positions, IntPtr votes);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_detect2(
            IntPtr obj, IntPtr edges, IntPtr dx, IntPtr dy, IntPtr positions, IntPtr votes);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_setCannyLowThresh(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHough_getCannyLowThresh(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_setCannyHighThresh(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHough_getCannyHighThresh(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_setMinDist(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHough_getMinDist(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_setDp(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHough_getDp(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHough_setMaxBufferSize(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHough_getMaxBufferSize(IntPtr obj);



        // GeneralizedHoughBallard

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_createGeneralizedHoughBallard();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_Ptr_GeneralizedHoughBallard_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Ptr_GeneralizedHoughBallard_delete(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughBallard_setLevels(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHoughBallard_getLevels(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughBallard_setVotesThreshold(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHoughBallard_getVotesThreshold(IntPtr obj);



        // GeneralizedHoughGuil

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_createGeneralizedHoughGuil();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_Ptr_GeneralizedHoughGuil_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Ptr_GeneralizedHoughGuil_delete(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setXi(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getXi(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setLevels(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHoughGuil_getLevels(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setAngleEpsilon(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getAngleEpsilon(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setMinAngle(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getMinAngle(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setMaxAngle(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getMaxAngle(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setAngleStep(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getAngleStep(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setAngleThresh(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHoughGuil_getAngleThresh(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setMinScale(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getMinScale(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setMaxScale(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getMaxScale(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setScaleStep(IntPtr obj, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_GeneralizedHoughGuil_getScaleStep(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setScaleThresh(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHoughGuil_getScaleThresh(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GeneralizedHoughGuil_setPosThresh(IntPtr obj, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_GeneralizedHoughGuil_getPosThresh(IntPtr obj);
    }
}