using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Base class for high-level OpenCV algorithms
/// </summary>
public abstract class Algorithm : DisposableCvObject
{
    /// <summary>
    /// Stores algorithm parameters in a file storage
    /// </summary>
    /// <param name="fs"></param>
    public virtual void Write(FileStorage fs)
    {
        if (ptr == IntPtr.Zero)
            throw new ObjectDisposedException(GetType().Name);
        if (fs is null)
            throw new ArgumentNullException(nameof(fs));

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_write(ptr, fs.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Reads algorithm parameters from a file storage
    /// </summary>
    /// <param name="fn"></param>
    public virtual void Read(FileNode fn)
    {
        if (ptr == IntPtr.Zero)
            throw new ObjectDisposedException(GetType().Name);
        if (fn is null)
            throw new ArgumentNullException(nameof(fn));

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_read(ptr, fn.CvPtr));
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
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);

            NativeMethods.HandleException(
                NativeMethods.core_Algorithm_empty(ptr, out var ret));
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
        if (ptr == IntPtr.Zero)
            throw new ObjectDisposedException(GetType().Name);
        if (fileName is null)
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_save(ptr, fileName));
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
        if (ptr == IntPtr.Zero)
            throw new ObjectDisposedException(GetType().Name);

        using var buf = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_Algorithm_getDefaultName(ptr, buf.CvPtr));
        GC.KeepAlive(this);
        return buf.ToString();
    }
}
