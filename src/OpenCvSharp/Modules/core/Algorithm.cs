using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Base class for high-level OpenCV algorithms
/// </summary>
public abstract class Algorithm : CvPtrObject
{
    /// <summary>
    /// Constructor for the factory pattern (cv::Ptr&lt;T&gt;* + raw T*).
    /// </summary>
    protected Algorithm(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> releaseSmartPtr)
        : base(smartPtr, rawPtr, releaseSmartPtr)
    {
    }

    /// <summary>
    /// Constructor for the direct-allocation pattern (raw T* only).
    /// </summary>
    protected Algorithm(IntPtr rawPtr, Action<IntPtr> releaseRawPtr)
        : base(rawPtr, releaseRawPtr)
    {
    }

    /// <summary>
    /// Stores algorithm parameters in a file storage
    /// </summary>
    /// <param name="fs"></param>
    public virtual void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        if (fs is null)
            throw new ArgumentNullException(nameof(fs));

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_write(RawPtr, fs.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Reads algorithm parameters from a file storage
    /// </summary>
    /// <param name="fn"></param>
    public virtual void Read(FileNode fn)
    {
        ThrowIfDisposed();
        if (fn is null)
            throw new ArgumentNullException(nameof(fn));

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_read(RawPtr, fn.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(fn);
    }

    /// <summary>
    /// Returns true if the Algorithm is empty (e.g. in the very beginning or after unsuccessful read
    /// </summary>
    /// <returns></returns>
    public virtual bool Empty
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_Algorithm_empty(RawPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Saves the algorithm to a file.
    /// In order to make this method work, the derived class must 
    /// implement Algorithm::write(FileStorage fs).
    /// </summary>
    /// <param name="fileName"></param>
    public virtual void Save(string fileName)
    {
        ThrowIfDisposed();
        if (fileName is null)
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_save(RawPtr, fileName));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns the algorithm string identifier.
    /// This string is used as top level xml/yml node tag when the object 
    /// is saved to a file or string.
    /// </summary>
    /// <returns></returns>
    public virtual string GetDefaultName()
    {
        ThrowIfDisposed();

        using var buf = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_getDefaultName(RawPtr, buf.CvPtr));
        GC.KeepAlive(this);
        return buf.ToString();
    }
}
