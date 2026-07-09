using System.Collections;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>
/// Reads multi-page images on demand. Decodes pages lazily as they are accessed.
/// Performance of page decoding is O(1) when the collection is accessed sequentially; accessing
/// a page out of order is O(n) because the underlying reader has to restart from the beginning.
/// Decoded pages are cached; call <see cref="ReleaseCache"/> to free a decoded page's memory.
/// </summary>
public class ImageCollection : CvObject, IEnumerable<Mat>
{
    /// <summary>
    /// Creates an empty ImageCollection. Call <see cref="Init"/> before use.
    /// </summary>
    public ImageCollection()
    {
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_ImageCollection_new1(out var p));
        InitSafeHandle(p);
    }

    /// <summary>
    /// Creates an ImageCollection over the multi-page image file at the given path.
    /// </summary>
    /// <param name="filename">Name of file to be loaded.</param>
    /// <param name="flags">Flag that can take values of @ref cv::ImreadModes.</param>
    public ImageCollection(string filename, ImreadModes flags = ImreadModes.Color)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_ImageCollection_new2(filename, (int) flags, out var p));
        InitSafeHandle(p);
    }

    private void InitSafeHandle(IntPtr p)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            static h => NativeMethods.HandleException(NativeMethods.imgcodecs_ImageCollection_delete(h))));
    }

    /// <summary>
    /// (Re-)initializes this collection over the multi-page image file at the given path.
    /// </summary>
    /// <param name="filename">Name of file to be loaded.</param>
    /// <param name="flags">Flag that can take values of @ref cv::ImreadModes.</param>
    public void Init(string filename, ImreadModes flags = ImreadModes.Color)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_ImageCollection_init(CvPtr, filename, (int) flags));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Number of pages in the collection.
    /// </summary>
    public long Size
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_ImageCollection_size(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }
    }

    /// <summary>
    /// Decodes and returns the page at the given index.
    /// </summary>
    /// <param name="index">Zero-based page index.</param>
    public Mat At(int index)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_ImageCollection_at(CvPtr, index, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// Decodes and returns the page at the given index.
    /// </summary>
    /// <param name="index">Zero-based page index.</param>
    public Mat this[int index] => At(index);

    /// <summary>
    /// Releases the cached decoded page at the given index.
    /// </summary>
    /// <param name="index">Zero-based page index.</param>
    public void ReleaseCache(int index)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_ImageCollection_releaseCache(CvPtr, index));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Enumerates the pages of the collection in order (index 0, 1, 2, ...).
    /// </summary>
    public IEnumerator<Mat> GetEnumerator()
    {
        var size = Size;
        for (var i = 0L; i < size; i++)
        {
            yield return At((int) i);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
