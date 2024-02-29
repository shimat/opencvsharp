using System.Collections;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Contrast Limited Adaptive Histogram Equalization
/// </summary>
public sealed class LineIterator : DisposableCvObject, IEnumerable<LineIterator.Pixel>
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
    /// <returns></returns>
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
    }

    /// <summary>
    /// Initializes the iterator
    /// </summary>
    /// <returns></returns>
    private void Initialize()
    {
        if (ptr != IntPtr.Zero)
            throw new OpenCvSharpException("invalid state");
        img.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.imgproc_LineIterator_new(
                img.CvPtr, pt1, pt2, (int)connectivity, leftToRight ? 1 : 0, out ptr));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_LineIterator_delete(ptr));
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator<Pixel> GetEnumerator()
    {
        Dispose();
        Initialize();

        NativeMethods.HandleException(
            NativeMethods.imgproc_LineIterator_count_get(ptr, out var count));
        for (var i = 0; i < count; i++)
        {
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_getValuePosAndShiftToNext(ptr, out var value, out var pos));
            yield return new Pixel(pos, value);
            GC.KeepAlive(this);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public IntPtr Ptr
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_ptr_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public IntPtr Ptr0
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_ptr0_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Step
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_step_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int ElemSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_elemSize_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Err
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_err_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Count
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.imgproc_LineIterator_count_get(ptr, out var ret));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_LineIterator_minusDelta_get(ptr, out var ret));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_LineIterator_plusDelta_get(ptr, out var ret));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_LineIterator_minusStep_get(ptr, out var ret));
            GC.KeepAlive(this);
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
                NativeMethods.imgproc_LineIterator_plusStep_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
    }

    #endregion

#pragma warning disable CA1034
    /// <summary>
    /// LineIterator pixel data
    /// </summary>
    public class Pixel
    {
        /// <summary>
        /// 
        /// </summary>
        public unsafe byte* ValuePointer => (byte*)Ptr.ToPointer();

        /// <summary>
        /// 
        /// </summary>
        public Point Pos { get; }

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Ptr { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetValue<T>() where T : struct
        {
            return Marshal.PtrToStructure<T>(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetValue<T>(T value) where T : struct
        {
            Marshal.StructureToPtr(value, Ptr, false);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="ptr"></param>
        internal Pixel(Point pos, IntPtr ptr)
        {
            Pos = pos;
            Ptr = ptr;
        }
    }
}
