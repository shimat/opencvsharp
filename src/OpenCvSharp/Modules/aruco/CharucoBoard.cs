using OpenCvSharp.Internal;

namespace OpenCvSharp.Aruco;

/// <summary>
/// ChArUco board — a planar chessboard where the markers are placed inside the white squares.
/// </summary>
public class CharucoBoard : CvObject
{
    /// <summary>
    /// Creates a CharucoBoard.
    /// </summary>
    /// <param name="squaresX">number of chessboard squares in x direction</param>
    /// <param name="squaresY">number of chessboard squares in y direction</param>
    /// <param name="squareLength">chessboard square side length (normally in meters)</param>
    /// <param name="markerLength">marker side length (same unit as squareLength)</param>
    /// <param name="dictionary">dictionary of markers</param>
    public CharucoBoard(int squaresX, int squaresY, float squareLength, float markerLength, Dictionary dictionary)
    {
        if (dictionary is null)
            throw new ArgumentNullException(nameof(dictionary));
        dictionary.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_create(squaresX, squaresY, squareLength, markerLength, dictionary.CvPtr, out var ptr));
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
    public void GenerateImage(Size outSize, OutputArray img, int marginSize = 0, int borderBits = 1)
    {
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        img.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_generateImage(Handle, outSize, img.CvPtr, marginSize, borderBits));
        img.Fix();
    }

    /// <summary>
    /// Check whether the ChArUco markers are collinear.
    /// </summary>
    public bool CheckCharucoCornersCollinear(InputArray charucoIds)
    {
        if (charucoIds is null)
            throw new ArgumentNullException(nameof(charucoIds));
        charucoIds.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_CharucoBoard_checkCharucoCornersCollinear(Handle, charucoIds.CvPtr, out var ret));
        GC.KeepAlive(charucoIds);
        return ret != 0;
    }
}
