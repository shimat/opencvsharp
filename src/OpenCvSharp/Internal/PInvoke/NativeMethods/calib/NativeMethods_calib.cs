using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_initCameraMatrix2D_Mat(
        IntPtr[] objectPoints, int objectPointsLength,
        IntPtr[] imagePoints, int imagePointsLength,
        Size imageSize, double aspectRatio, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_initCameraMatrix2D_array(
        IntPtr[] objectPoints, int opSize1, int[] opSize2,
        IntPtr[] imagePoints, int ipSize1, int[] ipSize2,
        Size imageSize, double aspectRatio, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_findChessboardCorners_InputArray(
        IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_findChessboardCorners_vector(
        IntPtr image, Size patternSize, IntPtr corners, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_findCirclesGrid_InputArray(
        IntPtr image, Size patternSize,
        IntPtr centers, int flags, IntPtr blobDetector,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_findCirclesGrid_vector(
        IntPtr image, Size patternSize,
        IntPtr centers, int flags, IntPtr blobDetector,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_calibrateCamera_InputArray(
        IntPtr[] objectPoints, int objectPointsSize,
        IntPtr[] imagePoints, int imagePointsSize,
        Size imageSize,
        IntPtr cameraMatrix,IntPtr distCoeffs,
        IntPtr rvecs, IntPtr tvecs,
        int flags, TermCriteria criteria,
        out double returnValue);

    // OpenCV 5 multi-view calibration
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_registerCameras(
        IntPtr[] objectPoints1, int objectPoints1Size,
        IntPtr[] objectPoints2, int objectPoints2Size,
        IntPtr[] imagePoints1, int imagePoints1Size,
        IntPtr[] imagePoints2, int imagePoints2Size,
        IntPtr cameraMatrix1, IntPtr distCoeffs1, int cameraModel1,
        IntPtr cameraMatrix2, IntPtr distCoeffs2, int cameraModel2,
        IntPtr R, IntPtr T, IntPtr E, IntPtr F,
        IntPtr perViewErrors,
        int flags, TermCriteria criteria, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_calibrateMultiview(
        IntPtr[] objPoints, int objPointsSize,
        IntPtr[] imagePoints, int numCameras, int[] framesPerCamera,
        Size[] imageSize, int imageSizeSize,
        IntPtr detectionMask, IntPtr models,
        IntPtr ks, IntPtr distortions, IntPtr rs, IntPtr ts,
        IntPtr flagsForIntrinsics, int flags, TermCriteria criteria, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus calib_calibrateCamera_vector(
        IntPtr[] objectPoints, int opSize1, int[] opSize2,
        IntPtr[] imagePoints, int ipSize1, int[] ipSize2,
        Size imageSize,
        double* cameraMatrix,
        [In, Out] double[] distCoeffs, int distCoeffsSize,
        IntPtr rvecs, IntPtr tvecs,
        int flags, TermCriteria criteria,
        out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_stereoCalibrate_InputArray(
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_stereoCalibrate_Mat(
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus calib_stereoCalibrate_array(
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_calibrateHandEye(
        IntPtr[] R_gripper2baseMats, int R_gripper2baseMatsSize,
        IntPtr[] t_gripper2baseMats, int t_gripper2baseMatsSize,
        IntPtr[] R_target2camMats, int R_target2camMatsSize,
        IntPtr[] t_target2camMats, int t_target2camMatsSize,
        IntPtr R_cam2gripper,
        IntPtr t_cam2gripper,
        int method);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_calibrateRobotWorldHandEye_OutputArray(
        IntPtr[] R_world2camMats, int R_world2camMatsSize,
        IntPtr[] t_world2camMats, int t_world2camMatsSize,
        IntPtr[] R_base2gripperMats, int R_base2gripperMatsSize,
        IntPtr[] t_base2gripperMats, int t_base2gripperMatsSize,
        IntPtr R_base2world, IntPtr t_base2world,
        IntPtr R_gripper2cam, IntPtr t_gripper2cam,
        int method);

    // The 3x3 output matrices are contiguous, blittable double[,]; pass them as (pinned) Span<double>
    // so source-generated marshalling can handle them (native writes into the buffer via double*).
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_calibrateRobotWorldHandEye_Pointer(
        IntPtr[] R_world2camMats, int R_world2camMatsSize,
        IntPtr[] t_world2camMats, int t_world2camMatsSize,
        IntPtr[] R_base2gripperMats, int R_base2gripperMatsSize,
        IntPtr[] t_base2gripperMats, int t_base2gripperMatsSize,
        Span<double> R_base2world,
        [MarshalAs(UnmanagedType.LPArray), Out] double[] t_base2world,
        Span<double> R_gripper2cam,
        [MarshalAs(UnmanagedType.LPArray), Out] double[] t_gripper2cam,
        int method);
}
