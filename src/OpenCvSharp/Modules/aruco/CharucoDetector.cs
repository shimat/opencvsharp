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
        : this(board, default, default, 2, false, true, new DetectorParameters(), new RefineParameters())
    {
    }

    /// <summary>
    /// Creates CharucoDetector.
    /// </summary>
    public CharucoDetector(
        CharucoBoard board,
        InputArrayRef cameraMatrix,
        InputArrayRef distCoeffs,
        int minMarkers = 2,
        bool tryRefineMarkers = false,
        bool checkMarkers = true,
        DetectorParameters? detectorParams = null,
        RefineParameters? refineParams = null)
    {
        if (board is null)
            throw new ArgumentNullException(nameof(board));
        board.ThrowIfDisposed();
        if ((cameraMatrix.Proxy.Kind == (int)ArrayProxyKind.None) != (distCoeffs.Proxy.Kind == (int)ArrayProxyKind.None))
            throw new ArgumentException("cameraMatrix and distCoeffs must both be omitted or both provided.");

        var dp = detectorParams ?? new DetectorParameters();
        var rp = refineParams ?? new RefineParameters();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_create(
                board.CvPtr,
                cameraMatrix.Proxy,
                distCoeffs.Proxy,
                minMarkers, tryRefineMarkers, checkMarkers,
                ref dp, ref rp,
                out var ptr));

        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static h => NativeMethods.HandleException(NativeMethods.aruco_CharucoDetector_delete(h))));

        GC.KeepAlive(board);
        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
    }

    /// <summary>
    /// Detect aruco markers and interpolate position of ChArUco board corners.
    /// </summary>
    public void DetectBoard(
        InputArrayRef image,
        out Point2f[] charucoCorners,
        out int[] charucoIds,
        out Point2f[][] markerCorners,
        out int[] markerIds)
    {
        ThrowIfDisposed();

        using var charucoCornersVec = new StdVector<Point2f>();
        using var charucoIdsVec = new StdVector<int>();
        using var markerCornersVec = new VectorOfVectorPoint2f();
        using var markerIdsVec = new StdVector<int>();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_detectBoard(
                Handle, image.Proxy,
                charucoCornersVec.CvPtr, charucoIdsVec.CvPtr,
                markerCornersVec.CvPtr, markerIdsVec.CvPtr));

        charucoCorners = charucoCornersVec.ToArray();
        charucoIds = charucoIdsVec.ToArray();
        markerCorners = markerCornersVec.ToArray();
        markerIds = markerIdsVec.ToArray();

        GC.KeepAlive(image.Source);
    }

    /// <summary>
    /// Detect ChArUco Diamond markers.
    /// </summary>
    public void DetectDiamonds(
        InputArrayRef image,
        out Point2f[][] diamondCorners,
        out Vec4i[] diamondIds,
        out Point2f[][] markerCorners,
        out int[] markerIds)
    {
        ThrowIfDisposed();

        using var diamondCornersVec = new VectorOfVectorPoint2f();
        using var diamondIdsVec = new StdVector<Vec4i>();
        using var markerCornersVec = new VectorOfVectorPoint2f();
        using var markerIdsVec = new StdVector<int>();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_detectDiamonds(
                Handle, image.Proxy,
                diamondCornersVec.CvPtr, diamondIdsVec.CvPtr,
                markerCornersVec.CvPtr, markerIdsVec.CvPtr));

        diamondCorners = diamondCornersVec.ToArray();
        diamondIds = diamondIdsVec.ToArray();
        markerCorners = markerCornersVec.ToArray();
        markerIds = markerIdsVec.ToArray();

        GC.KeepAlive(image.Source);
    }
}
