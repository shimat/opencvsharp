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
        InputArray cameraMatrix,
        InputArray distCoeffs,
        int minMarkers = 2,
        bool tryRefineMarkers = false,
        bool checkMarkers = true,
        DetectorParameters? detectorParams = null,
        RefineParameters? refineParams = null)
    {
        ArgumentNullException.ThrowIfNull(board);
        board.ThrowIfDisposed();
        if (cameraMatrix.IsEmpty != distCoeffs.IsEmpty)
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
        InputArray image,
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
        InputArray image,
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

    /// <summary>
    /// Gets the ChArUco board used by this detector.
    /// </summary>
    public CharucoBoard GetBoard()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_getBoard(Handle, out var ret));
        return new CharucoBoard(ret);
    }

    /// <summary>
    /// Sets the ChArUco board used by this detector.
    /// </summary>
    public void SetBoard(CharucoBoard board)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(board);
        board.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_setBoard(Handle, board.CvPtr));

        GC.KeepAlive(board);
    }

    /// <summary>
    /// Gets the charuco detection parameters currently used.
    /// </summary>
    public CharucoParameters GetCharucoParameters()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_getCharucoParameters(
                Handle, out var cameraMatrix, out var distCoeffs, out var minMarkers, out var tryRefineMarkers, out var checkMarkers));

        // Avoid letting the object initializer allocate-then-discard CharucoParameters' default
        // CameraMatrix/DistCoeffs (its property initializers construct a throwaway Mat each):
        // dispose those before assigning the real native-backed Mats below.
        var result = new CharucoParameters
        {
            MinMarkers = minMarkers,
            TryRefineMarkers = tryRefineMarkers != 0,
            CheckMarkers = checkMarkers != 0,
        };
        result.CameraMatrix.Dispose();
        result.DistCoeffs.Dispose();
        result.CameraMatrix = new Mat(cameraMatrix);
        result.DistCoeffs = new Mat(distCoeffs);
        return result;
    }

    /// <summary>
    /// Sets the charuco detection parameters to be used.
    /// </summary>
    public void SetCharucoParameters(CharucoParameters charucoParameters)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(charucoParameters);
        ArgumentNullException.ThrowIfNull(charucoParameters.CameraMatrix);
        ArgumentNullException.ThrowIfNull(charucoParameters.DistCoeffs);

        if (charucoParameters.CameraMatrix.Empty() != charucoParameters.DistCoeffs.Empty())
            throw new ArgumentException("CameraMatrix and DistCoeffs must both be empty or both provided.", nameof(charucoParameters));

        InputArray cameraMatrix = charucoParameters.CameraMatrix;
        InputArray distCoeffs = charucoParameters.DistCoeffs;

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_setCharucoParameters(
                Handle,
                cameraMatrix.Proxy,
                distCoeffs.Proxy,
                charucoParameters.MinMarkers,
                charucoParameters.TryRefineMarkers ? 1 : 0,
                charucoParameters.CheckMarkers ? 1 : 0));

        GC.KeepAlive(cameraMatrix.Source);
        GC.KeepAlive(distCoeffs.Source);
    }

    /// <summary>
    /// Gets the detector parameters currently used for marker detection.
    /// </summary>
    public DetectorParameters GetDetectorParameters()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_getDetectorParameters(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets the detector parameters to be used for marker detection.
    /// </summary>
    public void SetDetectorParameters(DetectorParameters detectorParameters)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_setDetectorParameters(Handle, ref detectorParameters));
    }

    /// <summary>
    /// Gets the marker refine detection parameters currently used.
    /// </summary>
    public RefineParameters GetRefineParameters()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_getRefineParameters(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets the marker refine detection parameters to be used.
    /// </summary>
    public void SetRefineParameters(RefineParameters refineParameters)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoDetector_setRefineParameters(Handle, ref refineParameters));
    }
}
