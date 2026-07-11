using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Aruco;

/// <summary>
/// Board of ArUco markers.
/// A board is a set of markers in the 3D space with a common coordinate system.
/// The common form of a board of marker is a planar (2D) board, however any 3D layout can be used.
/// A Board object is composed by:
/// - The object points of the marker corners, i.e. their coordinates respect to the board system.
/// - The dictionary which indicates the type of markers of the board
/// - The identifier of all the markers in the board.
/// </summary>
public class Board : CvObject
{
    /// <summary>
    /// Protected constructor for use by derived classes that create their own native handle.
    /// </summary>
    private protected Board()
    {
    }

    /// <summary>
    /// Common Board constructor
    /// </summary>
    /// <param name="objPoints">array of object points of all the marker corners in the board. Each marker must have exactly 4 corners.</param>
    /// <param name="dictionary">the dictionary of markers employed for this board</param>
    /// <param name="ids">vector of the identifiers of the markers in the board</param>
    public Board(IEnumerable<Point3f[]> objPoints, Dictionary dictionary, IEnumerable<int> ids)
    {
        ArgumentNullException.ThrowIfNull(objPoints);
        ArgumentNullException.ThrowIfNull(dictionary);
        ArgumentNullException.ThrowIfNull(ids);
        dictionary.ThrowIfDisposed();

        using var objPointsAddress = new ArrayAddress2<Point3f>(objPoints.ToArray());
        using var idsVec = new StdVector<int>(ids);

        NativeMethods.HandleException(
            NativeMethods.aruco_Board_create(
                objPointsAddress.GetPointer(), objPointsAddress.GetDim1Length(), objPointsAddress.GetDim2Lengths(),
                dictionary.CvPtr, idsVec.CvPtr, out var p));
        InitSafeHandle(p);

        GC.KeepAlive(dictionary);
    }

    /// <summary>
    /// Sets the native handle. <paramref name="releaseAction"/> lets a derived class (e.g. GridBoard)
    /// release through its own native delete function instead of aruco_Board_delete: cv::aruco::Board
    /// has no virtual destructor, so deleting a derived object through a plain Board* is undefined
    /// behavior even though it happens to be harmless today (GridBoard/CharucoBoard add no fields of
    /// their own; all state lives behind the shared Board::Impl).
    /// </summary>
    private protected void InitSafeHandle(IntPtr p, bool ownsHandle = true, Action<IntPtr>? releaseAction = null)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            releaseAction ?? (static h => NativeMethods.HandleException(NativeMethods.aruco_Board_delete(h)))));
    }

    /// <summary>
    /// return the Dictionary of markers employed for this board
    /// </summary>
    public Dictionary GetDictionary()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_Board_getDictionary(Handle, out var ret));
        return new Dictionary(ret);
    }

    /// <summary>
    /// return array of object points of all the marker corners in the board.
    /// Each marker include its 4 corners in this order:
    /// - objPoints[i][0] - left-top point of i-th marker
    /// - objPoints[i][1] - right-top point of i-th marker
    /// - objPoints[i][2] - right-bottom point of i-th marker
    /// - objPoints[i][3] - left-bottom point of i-th marker
    /// Markers are placed in a certain order - row by row, left to right in every row. For M markers, the size is Mx4.
    /// </summary>
    public Point3f[][] GetObjPoints()
    {
        ThrowIfDisposed();
        using var flatVec = new StdVector<Point3f>();
        NativeMethods.HandleException(
            NativeMethods.aruco_Board_getObjPoints(Handle, flatVec.CvPtr));

        var flat = flatVec.ToArray();
        var result = new Point3f[flat.Length / 4][];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = [flat[i * 4], flat[i * 4 + 1], flat[i * 4 + 2], flat[i * 4 + 3]];
        }
        return result;
    }

    /// <summary>
    /// vector of the identifiers of the markers in the board (should be the same size as objPoints)
    /// </summary>
    public int[] GetIds()
    {
        ThrowIfDisposed();
        using var idsVec = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.aruco_Board_getIds(Handle, idsVec.CvPtr));
        return idsVec.ToArray();
    }

    /// <summary>
    /// get coordinate of the bottom right corner of the board, is set when calling the function create()
    /// </summary>
    public Point3f GetRightBottomCorner()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_Board_getRightBottomCorner(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Given a board configuration and a set of detected markers, returns the corresponding
    /// image points and object points, can be used in solvePnP()
    /// </summary>
    /// <param name="detectedCorners">List of detected marker corners of the board.</param>
    /// <param name="detectedIds">List of identifiers for each marker.</param>
    /// <param name="objPoints">Vector of marker points in the board coordinate space.</param>
    /// <param name="imgPoints">Vector of marker points in the image coordinate space.</param>
    public void MatchImagePoints(
        Point2f[][] detectedCorners, InputArray detectedIds, OutputArray objPoints, OutputArray imgPoints)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(detectedCorners);

        using var cornersAddress = new ArrayAddress2<Point2f>(detectedCorners);
        NativeMethods.HandleException(
            NativeMethods.aruco_Board_matchImagePoints(
                Handle, cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                detectedIds.Proxy, objPoints.Proxy, imgPoints.Proxy));

        GC.KeepAlive(detectedIds.Source);
        GC.KeepAlive(objPoints.Source);
        GC.KeepAlive(imgPoints.Source);
    }

    /// <summary>
    /// Draw a planar board.
    /// This function return the image of the board, ready to be printed.
    /// </summary>
    /// <param name="outSize">size of the output image in pixels.</param>
    /// <param name="img">output image with the board. The size of this image will be outSize and the board will be on the center, keeping the board proportions.</param>
    /// <param name="marginSize">minimum margins (in pixels) of the board in the output image</param>
    /// <param name="borderBits">width of the marker borders.</param>
    public void GenerateImage(Size outSize, OutputArray img, int marginSize = 0, int borderBits = 1)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Board_generateImage(Handle, outSize, img.Proxy, marginSize, borderBits));

        GC.KeepAlive(img.Source);
    }
}
