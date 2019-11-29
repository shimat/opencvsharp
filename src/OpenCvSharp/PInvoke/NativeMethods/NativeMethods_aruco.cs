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
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr aruco_getPredefinedDictionary(int name);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_detectMarkers(IntPtr image, IntPtr dictionary, IntPtr corners, IntPtr ids, IntPtr detectParameters, IntPtr outrejectedImgPoints);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_drawDetectedMarkers(IntPtr image, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2, [MarshalAs(UnmanagedType.LPArray)] int[] ids, int idxLength, Scalar borderColor);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_drawDetectedMarkers(IntPtr image, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2, IntPtr ids, int idxLength, Scalar borderColor);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_drawMarker(IntPtr dictionary, int id, int sidePixels, IntPtr mat, int borderBits);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_estimatePoseSingleMarkers([MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornersLength1, int[] cornersLengths2, float markerLength, IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvecs, IntPtr tvecs, IntPtr objPoints);

        #region DetectorParameters

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr aruco_DetectorParameters_create();

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_Ptr_DetectorParameters_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr aruco_Ptr_DetectorParameters_get(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setDoCornerRefinement(IntPtr obj, bool value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setAdaptiveThreshConstant(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setCornerRefinementMinAccuracy(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setErrorCorrectionRate(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMaxErroneousBitsInBorderRate(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMaxMarkerPerimeterRate(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMinCornerDistanceRate(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMinMarkerDistanceRate(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMinMarkerPerimeterRate(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMinOtsuStdDev(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setPerspectiveRemoveIgnoredMarginPerCell(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setPolygonalApproxAccuracyRate(IntPtr obj, double value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setAdaptiveThreshWinSizeMax(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setAdaptiveThreshWinSizeMin(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setAdaptiveThreshWinSizeStep(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setCornerRefinementMethod(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setCornerRefinementWinSize(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setCornerRefinementMaxIterations(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMarkerBorderBits(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setMinDistanceToBorder(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_DetectorParameters_setPerspectiveRemovePixelPerCell(IntPtr obj, int value);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern bool aruco_DetectorParameters_getDoCornerRefinement(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getAdaptiveThreshConstant(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getCornerRefinementMinAccuracy(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getErrorCorrectionRate(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getMaxErroneousBitsInBorderRate(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getMaxMarkerPerimeterRate(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getMinCornerDistanceRate(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getMinMarkerDistanceRate(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getMinMarkerPerimeterRate(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getMinOtsuStdDev(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getPerspectiveRemoveIgnoredMarginPerCell(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double aruco_DetectorParameters_getPolygonalApproxAccuracyRate(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getAdaptiveThreshWinSizeMax(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getAdaptiveThreshWinSizeMin(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getAdaptiveThreshWinSizeStep(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getCornerRefinementMaxIterations(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getCornerRefinementMethod(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getCornerRefinementWinSize(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getMarkerBorderBits(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getMinDistanceToBorder(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_DetectorParameters_getPerspectiveRemovePixelPerCell(IntPtr obj);

        #endregion

        #region Dictionary

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_Ptr_Dictionary_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr aruco_Ptr_Dictionary_get(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_Dictionary_setMarkerSize(IntPtr obj, int value);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void aruco_Dictionary_setMaxCorrectionBits(IntPtr obj, int value);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr aruco_Dictionary_getBytesList(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_Dictionary_getMarkerSize(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int aruco_Dictionary_getMaxCorrectionBits(IntPtr obj);

        #endregion
    }

}
