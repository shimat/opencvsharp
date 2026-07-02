using System.Collections;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Iterates over the pixels that lie on a line segment of an image, mirroring
/// cv::LineIterator. The instance describes the scan (its length is available
/// through <see cref="Count"/> immediately after construction); enumerating it
/// walks the pixels from <c>pt1</c> to <c>pt2</c>.
/// </summary>
/// <remarks>
/// Enumeration is independent of the instance state, so a single
/// <see cref="LineIterator"/> can be iterated more than once. Prefer
/// <see cref="AsValues{T}"/> to read pixel values safely: it dereferences each
/// pixel while the source image is guaranteed to be alive. The raw
/// <see cref="Pixel.Ptr"/> exposed by <see cref="GetEnumerator"/> points directly
/// into the image buffer and is only valid while that image has not been disposed.
/// </remarks>
public sealed class LineIterator : CvObject, IEnumerable<LineIterator.Pixel>
{
    private readonly Mat img;
    private readonly Point pt1;
    private readonly Point pt2;
    private readonly PixelConnectivity connectivity;
    private readonly bool leftToRight;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="img"></param>
    /// <param name="pt1"></param>
    /// <param name="pt2"></param>
    /// <param name="connectivity"></param>
    /// <param name="leftToRight"></param>
    public LineIterator(
        Mat img,
        Point pt1,
        Point pt2,
        PixelConnectivity connectivity = PixelConnectivity.Connectivity8,
        bool leftToRight = false)
    {
        this.img = img ?? throw new ArgumentNullException(nameof(img));
        this.pt1 = pt1;
        this.pt2 = pt2;
        this.connectivity = connectivity;
        this.leftToRight = leftToRight;

        // Create the native iterator eagerly so that Count and the other fields are
        // valid as soon as the object exists, matching cv::LineIterator semantics.
        SetSafeHandle(CreateNative());
    }

    /// <summary>
    /// Creates a fresh native cv::LineIterator positioned at the start of the line.
    /// Each enumeration uses its own instance, so the public one is never advanced.
    /// </summary>
    private OpenCvPtrSafeHandle CreateNative()
    {
        img.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.imgproc_LineIterator_new(
                img.CvPtr, pt1, pt2, (int)connectivity, leftToRight ? 1 : 0, out var p));
        GC.KeepAlive(img);
        return new OpenCvPtrSafeHandle(p, ownsHandle: true,
            static h => NativeMethods.HandleException(NativeMethods.imgproc_LineIterator_delete(h)));
    }

    /// <summary>
    /// Enumerates the pixels along the line. Each <see cref="Pixel"/> carries its
    /// position and a raw pointer into the image buffer; that pointer is only valid
    /// while the source image is alive. Use <see cref="AsValues{T}"/> for safe access.
    /// </summary>
    public IEnumerator<Pixel> GetEnumerator()
    {
        // A dedicated native iterator per enumeration keeps the public instance
        // immutable and makes re-enumeration well defined.
        using var it = CreateNative();
        NativeMethods.HandleException(
            NativeMethods.imgproc_LineIterator_count_get(it, out var count));
        for (var i = 0; i < count; i++)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_getValuePosAndShiftToNext(it, out var value, out var pos));
            yield return new Pixel(pos, value);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Enumerates the pixel values along the line as <typeparamref name="T"/>.
    /// Each value is read while the source image is kept alive, so the result is
    /// safe to use after enumeration (unlike the raw <see cref="Pixel.Ptr"/>).
    /// </summary>
    /// <typeparam name="T">Pixel type (e.g. <see cref="Vec3b"/>).</typeparam>
    public IEnumerable<T> AsValues<T>() where T : struct
    {
        foreach (var pixel in this)
        {
            var value = pixel.GetValue<T>();
            GC.KeepAlive(this); // keep this -> img -> Mat alive across the dereference
            yield return value;
        }
    }

    #region Properties

    /// <summary>
    /// Pointer to the current pixel (into the image buffer).
    /// </summary>
    public IntPtr Ptr
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_ptr_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Pointer to the first pixel of the image.
    /// </summary>
    public IntPtr Ptr0
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_ptr0_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Number of bytes between two consecutive rows of the image.
    /// </summary>
    public int Step
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_step_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Size of one pixel in bytes.
    /// </summary>
    public int ElemSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_elemSize_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Bresenham error term of the current position.
    /// </summary>
    public int Err
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_err_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Number of pixels along the line.
    /// </summary>
    public int Count
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_count_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public int MinusDelta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_minusDelta_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public int PlusDelta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_plusDelta_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public int MinusStep
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_minusStep_get(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public int PlusStep
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_plusStep_get(Handle, out var ret));
            return ret;
        }
    }

    #endregion

#pragma warning disable CA1034
    /// <summary>
    /// LineIterator pixel data: its position and a pointer into the image buffer.
    /// </summary>
    /// <param name="Pos">Pixel position.</param>
    /// <param name="Ptr">Pointer to the pixel inside the image buffer. Only valid
    /// while the source image has not been disposed.</param>
    public readonly record struct Pixel(Point Pos, IntPtr Ptr)
    {
        /// <summary>
        /// Pointer to the pixel as a byte pointer.
        /// </summary>
        public unsafe byte* ValuePointer => (byte*)Ptr.ToPointer();

        /// <summary>
        /// Reads the pixel value as <typeparamref name="T"/>.
        /// The source image must still be alive.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetValue<T>() where T : struct
            => Marshal.PtrToStructure<T>(Ptr);

        /// <summary>
        /// Writes the pixel value of type <typeparamref name="T"/>.
        /// The source image must still be alive.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void SetValue<T>(T value) where T : struct
            => Marshal.StructureToPtr(value, Ptr, false);
    }
}
