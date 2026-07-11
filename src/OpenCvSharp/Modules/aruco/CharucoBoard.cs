using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Aruco;

/// <summary>
/// ChArUco board — a planar chessboard where the markers are placed inside the white squares.
/// </summary>
public class CharucoBoard : Board
{
    /// <summary>
    /// Creates a CharucoBoard.
    /// </summary>
    /// <param name="squaresX">number of chessboard squares in x direction</param>
    /// <param name="squaresY">number of chessboard squares in y direction</param>
    /// <param name="squareLength">chessboard square side length (normally in meters)</param>
    /// <param name="markerLength">marker side length (same unit as squareLength)</param>
    /// <param name="dictionary">dictionary of markers</param>
    /// <param name="ids">array of id used markers. The first markers in the dictionary are used to fill the white chessboard squares if null.</param>
    public CharucoBoard(int squaresX, int squaresY, float squareLength, float markerLength, Dictionary dictionary, IEnumerable<int>? ids = null)
    {
        ArgumentNullException.ThrowIfNull(dictionary);
        dictionary.ThrowIfDisposed();

        using var idsVec = new StdVector<int>(ids ?? []);

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_create(squaresX, squaresY, squareLength, markerLength, dictionary.CvPtr, idsVec.CvPtr, out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static h => NativeMethods.HandleException(NativeMethods.aruco_CharucoBoard_delete(h))));
        GC.KeepAlive(dictionary);
    }

    internal CharucoBoard(IntPtr ptr)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(ptr, true,
            static h => NativeMethods.HandleException(NativeMethods.aruco_CharucoBoard_delete(h))));
    }

    /// <summary>
    /// Gets the number of chessboard squares in x and y directions.
    /// </summary>
    public Size ChessboardSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_CharucoBoard_getChessboardSize(Handle, out var size));
            return size;
        }
    }

    /// <summary>
    /// Gets the chessboard square side length.
    /// </summary>
    public float SquareLength
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_CharucoBoard_getSquareLength(Handle, out var val));
            return val;
        }
    }

    /// <summary>
    /// Gets the marker side length.
    /// </summary>
    public float MarkerLength
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_CharucoBoard_getMarkerLength(Handle, out var val));
            return val;
        }
    }

    /// <summary>
    /// Gets or sets the legacy pattern mode for compatibility with patterns created before OpenCV 4.6.
    /// </summary>
    public bool LegacyPattern
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_CharucoBoard_getLegacyPattern(Handle, out var val));
            return val != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_CharucoBoard_setLegacyPattern(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Generate the board image.
    /// </summary>
    /// <remarks>
    /// Hides <see cref="Board.GenerateImage"/> to call the CharucoBoard-specific native override directly
    /// (cv::aruco::CharucoBoardImpl overrides generateImage, so the inherited Board method would in fact
    /// dispatch to the same implementation via its virtual PIMPL — this override is kept for clarity/directness).
    /// </remarks>
    public new void GenerateImage(Size outSize, OutputArray img, int marginSize = 0, int borderBits = 1)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_generateImage(Handle, outSize, img.Proxy, marginSize, borderBits));
    }

    /// <summary>
    /// Check whether the ChArUco markers are collinear.
    /// </summary>
    public bool CheckCharucoCornersCollinear(InputArray charucoIds)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_checkCharucoCornersCollinear(Handle, charucoIds.Proxy, out var ret));
        GC.KeepAlive(charucoIds.Source);
        return ret != 0;
    }

    /// <summary>
    /// Get CharucoBoard::chessboardCorners
    /// </summary>
    public Point3f[] GetChessboardCorners()
    {
        ThrowIfDisposed();

        using var vec = new StdVector<Point3f>();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_getChessboardCorners(Handle, vec.CvPtr));
        return vec.ToArray();
    }

    /// <summary>
    /// Get CharucoBoard::nearestMarkerIdx, for each charuco corner, nearest marker index in ids array
    /// </summary>
    public int[][] GetNearestMarkerIdx()
    {
        ThrowIfDisposed();

        using var vec = new VectorOfVectorInt32();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_getNearestMarkerIdx(Handle, vec.CvPtr));
        return vec.ToArray();
    }

    /// <summary>
    /// Get CharucoBoard::nearestMarkerCorners, for each charuco corner, nearest marker corner id of each marker
    /// </summary>
    public int[][] GetNearestMarkerCorners()
    {
        ThrowIfDisposed();

        using var vec = new VectorOfVectorInt32();
        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_getNearestMarkerCorners(Handle, vec.CvPtr));
        return vec.ToArray();
    }

    /// <summary>
    /// Given a board configuration and a set of detected ChArUco corners, returns the corresponding
    /// image points and object points, can be used in solvePnP().
    /// Overload of <see cref="Board.MatchImagePoints"/> for CharucoBoard, whose detected corners are a
    /// flat list of ChArUco corners rather than a jagged per-marker array.
    /// </summary>
    /// <param name="detectedCorners">List of detected ChArUco corners of the board.</param>
    /// <param name="detectedIds">List of identifiers for each charuco corner.</param>
    /// <param name="objPoints">Vector of marker points in the board coordinate space.</param>
    /// <param name="imgPoints">Vector of marker points in the image coordinate space.</param>
    public void MatchImagePoints(
        Point2f[] detectedCorners, InputArray detectedIds, OutputArray objPoints, OutputArray imgPoints)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(detectedCorners);

        using var cornersVec = new StdVector<Point2f>(detectedCorners);
        NativeMethods.HandleException(
            NativeMethods.aruco_Board_matchImagePoints_flat(
                Handle, cornersVec.CvPtr, detectedIds.Proxy, objPoints.Proxy, imgPoints.Proxy));

        GC.KeepAlive(detectedIds.Source);
        GC.KeepAlive(objPoints.Source);
        GC.KeepAlive(imgPoints.Source);
    }
}
