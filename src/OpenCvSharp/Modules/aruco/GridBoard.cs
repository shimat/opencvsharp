using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Aruco;

/// <summary>
/// Planar board with grid arrangement of markers.
/// More common type of board. All markers are placed in the same plane in a grid arrangement.
/// The board image can be drawn using the GenerateImage() method.
/// </summary>
public class GridBoard : Board
{
    /// <summary>
    /// GridBoard constructor
    /// </summary>
    /// <param name="size">number of markers in x and y directions</param>
    /// <param name="markerLength">marker side length (normally in meters)</param>
    /// <param name="markerSeparation">separation between two markers (same unit as markerLength)</param>
    /// <param name="dictionary">dictionary of markers indicating the type of markers</param>
    /// <param name="ids">set of marker ids in dictionary to use on board. If null, sequential ids starting at 0 are used.</param>
    public GridBoard(Size size, float markerLength, float markerSeparation, Dictionary dictionary, IEnumerable<int>? ids = null)
    {
        ArgumentNullException.ThrowIfNull(dictionary);
        dictionary.ThrowIfDisposed();

        using var idsVec = new StdVector<int>(ids ?? []);

        NativeMethods.HandleException(
            NativeMethods.aruco_GridBoard_create(size, markerLength, markerSeparation, dictionary.CvPtr, idsVec.CvPtr, out var p));
        InitSafeHandle(p, releaseAction: static h => NativeMethods.HandleException(NativeMethods.aruco_GridBoard_delete(h)));

        GC.KeepAlive(dictionary);
    }

    /// <summary>
    /// Number of markers in x and y directions.
    /// </summary>
    public Size GetGridSize()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_GridBoard_getGridSize(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Marker side length (normally in meters).
    /// </summary>
    public float GetMarkerLength()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_GridBoard_getMarkerLength(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Separation between two markers (same unit as markerLength).
    /// </summary>
    public float GetMarkerSeparation()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.aruco_GridBoard_getMarkerSeparation(Handle, out var ret));
        return ret;
    }
}
