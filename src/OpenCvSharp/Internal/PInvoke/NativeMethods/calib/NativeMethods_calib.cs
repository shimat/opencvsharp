using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_initCameraMatrix2D_Mat(
        IntPtr[] objectPoints, int objectPointsLength,
        IntPtr[] imagePoints, int imagePointsLength,
        Size imageSize, double aspectRatio, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_initCameraMatrix2D_array(
        IntPtr[] objectPoints, int opSize1, int[] opSize2,
        IntPtr[] imagePoints, int ipSize1, int[] ipSize2,
        Size imageSize, double aspectRatio, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_findChessboardCorners_InputArray(
        IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_findChessboardCorners_vector(
        IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_findCirclesGrid_InputArray(
        IntPtr image, Size patternSize,
        IntPtr centers, int flags, IntPtr blobDetector,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_findCirclesGrid_vector(
        IntPtr image, Size patternSize,
        IntPtr centers, int flags, IntPtr blobDetector,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_calibrateCamera_InputArray(
        IntPtr[] objectPoints, int objectPointsSize,
        IntPtr[] imagePoints, int imagePointsSize,
        Size imageSize,
        IntPtr cameraMatrix,IntPtr distCoeffs,
        IntPtr rvecs, IntPtr tvecs,
        int flags, TermCriteria criteria,
        out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus calib_calibrateCamera_vector(
        IntPtr[] objectPoints, int opSize1, int[] opSize2,
        IntPtr[] imagePoints, int ipSize1, int[] ipSize2,
        Size imageSize,
        double* cameraMatrix,
        [In, Out] double[] distCoeffs, int distCoeffsSize,
        IntPtr rvecs, IntPtr tvecs,
        int flags, TermCriteria criteria,
        out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_stereoCalibrate_InputArray(
        IntPtr[] objectPoints, int opSize,
        IntPtr[] imagePoints1, int ip1Size,
        IntPtr[] imagePoints2, int ip2Size,
        IntPtr cameraMatrix1,
        IntPtr distCoeffs1,
        IntPtr cameraMatrix2,
        IntPtr distCoeffs2,
        Size imageSize,
        IntPtr R, IntPtr T,
        IntPtr E, IntPtr F,
        int flags, TermCriteria criteria,
        out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_stereoCalibrate_Mat(
        IntPtr[] objectPoints, int opSize,
        IntPtr[] imagePoints1, int ip1Size,
        IntPtr[] imagePoints2, int ip2Size,
        IntPtr cameraMatrix1,
        IntPtr distCoeffs1,
        IntPtr cameraMatrix2,
        IntPtr distCoeffs2,
        Size imageSize,
        IntPtr R, IntPtr T,
        IntPtr E, IntPtr F,
        int flags, TermCriteria criteria,
        out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus calib_stereoCalibrate_array(
        IntPtr[] objectPoints, int opSize1, int[] opSizes2,
        IntPtr[] imagePoints1, int ip1Size1, int[] ip1Sizes2,
        IntPtr[] imagePoints2, int ip2Size1, int[] ip2Sizes2,
        double* cameraMatrix1,
        [In, Out] double[] distCoeffs1, int dc1Size,
        double* cameraMatrix2,
        [In, Out] double[] distCoeffs2, int dc2Size,
        Size imageSize,
        IntPtr R, IntPtr T,
        IntPtr E, IntPtr F,
        int flags, TermCriteria criteria,
        out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_calibrateHandEye(
        IntPtr[] R_gripper2baseMats, int R_gripper2baseMatsSize,
        IntPtr[] t_gripper2baseMats, int t_gripper2baseMatsSize,
        IntPtr[] R_target2camMats, int R_target2camMatsSize,
        IntPtr[] t_target2camMats, int t_target2camMatsSize,
        IntPtr R_cam2gripper,
        IntPtr t_cam2gripper,
        int method);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_calibrateRobotWorldHandEye_OutputArray(
        IntPtr[] R_world2camMats, int R_world2camMatsSize,
        IntPtr[] t_world2camMats, int t_world2camMatsSize,
        IntPtr[] R_base2gripperMats, int R_base2gripperMatsSize,
        IntPtr[] t_base2gripperMats, int t_base2gripperMatsSize,
        IntPtr R_base2world, IntPtr t_base2world,
        IntPtr R_gripper2cam, IntPtr t_gripper2cam,
        int method);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib_calibrateRobotWorldHandEye_Pointer(
        IntPtr[] R_world2camMats, int R_world2camMatsSize,
        IntPtr[] t_world2camMats, int t_world2camMatsSize,
        IntPtr[] R_base2gripperMats, int R_base2gripperMatsSize,
        IntPtr[] t_base2gripperMats, int t_base2gripperMatsSize,
        [MarshalAs(UnmanagedType.LPArray), Out] double[,] R_base2world, 
        [MarshalAs(UnmanagedType.LPArray), Out] double[] t_base2world,
        [MarshalAs(UnmanagedType.LPArray), Out] double[,] R_gripper2cam, 
        [MarshalAs(UnmanagedType.LPArray), Out] double[] t_gripper2cam,
        int method);
}
