using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Aruco;

/// <summary>
/// CharucoDetector detects ChArUco board corners and diamond markers.
/// </summary>
public class CharucoDetector : CvObject
{
    /// <summary>
    /// Creates CharucoDetector with default parameters.
    /// </summary>
    public CharucoDetector(CharucoBoard board)
        : this(board, null, null, 2, false, true, new DetectorParameters(), new RefineParameters())
    {
    }

    /// <summary>
    /// Creates CharucoDetector.
    /// </summary>
    public CharucoDetector(
        CharucoBoard board,
        InputArray? cameraMatrix,
        InputArray? distCoeffs,
        int minMarkers = 2,
        bool tryRefineMarkers = false,
        bool checkMarkers = true,
        DetectorParameters? detectorParams = null,
        RefineParameters? refineParams = null)
    {
        if (board is null)
            throw new ArgumentNullException(nameof(board));
        board.ThrowIfDisposed();
        if (cameraMatrix is null != distCoeffs is null)
            throw new ArgumentException("cameraMatrix and distCoeffs must both be null or both non-null.");

        var dp = detectorParams ?? new DetectorParameters();
        var rp = refineParams ?? new RefineParameters();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_create(
                board.CvPtr,
                cameraMatrix?.CvPtr ?? IntPtr.Zero,
                distCoeffs?.CvPtr ?? IntPtr.Zero,
                minMarkers, tryRefineMarkers, checkMarkers,
                ref dp, ref rp,
                out var ptr));

        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static h => NativeMethods.HandleException(NativeMethods.aruco_CharucoDetector_delete(h))));

        GC.KeepAlive(board);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(distCoeffs);
    }

    /// <summary>
    /// Detect aruco markers and interpolate position of ChArUco board corners.
    /// </summary>
    public void DetectBoard(
        InputArray image,
        out Point2f[] charucoCorners,
        out int[] charucoIds,
        out Point2f[][] markerCorners,
        out int[] markerIds)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        ThrowIfDisposed();

        using var charucoCornersVec = new StdVector<Point2f>();
        using var charucoIdsVec = new StdVector<int>();
        using var markerCornersVec = new VectorOfVectorPoint2f();
        using var markerIdsVec = new StdVector<int>();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_detectBoard(
                Handle, image.CvPtr,
                charucoCornersVec.CvPtr, charucoIdsVec.CvPtr,
                markerCornersVec.CvPtr, markerIdsVec.CvPtr));

        charucoCorners = charucoCornersVec.ToArray();
        charucoIds = charucoIdsVec.ToArray();
        markerCorners = markerCornersVec.ToArray();
        markerIds = markerIdsVec.ToArray();

        GC.KeepAlive(image);
    }

    /// <summary>
    /// Detect ChArUco Diamond markers.
    /// </summary>
    public void DetectDiamonds(
        InputArray image,
        out Point2f[][] diamondCorners,
        out Vec4i[] diamondIds,
        out Point2f[][] markerCorners,
        out int[] markerIds)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        ThrowIfDisposed();

        using var diamondCornersVec = new VectorOfVectorPoint2f();
        using var diamondIdsVec = new StdVector<Vec4i>();
        using var markerCornersVec = new VectorOfVectorPoint2f();
        using var markerIdsVec = new StdVector<int>();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_detectDiamonds(
                Handle, image.CvPtr,
                diamondCornersVec.CvPtr, diamondIdsVec.CvPtr,
                markerCornersVec.CvPtr, markerIdsVec.CvPtr));

        diamondCorners = diamondCornersVec.ToArray();
        diamondIds = diamondIdsVec.ToArray();
        markerCorners = markerCornersVec.ToArray();
        markerIds = markerIdsVec.ToArray();

        GC.KeepAlive(image);
    }
}
