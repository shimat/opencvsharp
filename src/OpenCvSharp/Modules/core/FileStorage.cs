using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <summary>
/// XML/YAML File Storage Class.
/// </summary>
public class FileStorage : DisposableCvObject
{
    #region Init & Disposal

    /// <summary>
    /// Default constructor.
    /// You should call FileStorage::open() after initialization.
    /// </summary>
    public FileStorage()
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_new1(out ptr));
    }

    /// <summary>
    /// The full constructor
    /// </summary>
    /// <param name="source">Name of the file to open or the text string to read the data from. 
    /// Extension of the file (.xml or .yml/.yaml) determines its format 
    /// (XML or YAML respectively). Also you can append .gz to work with 
    /// compressed files, for example myHugeMatrix.xml.gz. 
    /// If both FileStorage::WRITE and FileStorage::MEMORY flags are specified, 
    /// source is used just to specify the output file format 
    /// (e.g. mydata.xml, .yml etc.).</param>
    /// <param name="flags"></param>
    /// <param name="encoding">Encoding of the file. Note that UTF-16 XML encoding is not supported 
    /// currently and you should use 8-bit encoding instead of it.</param>
    public FileStorage(string source, Modes flags, string? encoding = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_new2(source, (int)flags, encoding, out ptr));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_delete(ptr));
        base.DisposeUnmanaged();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Returns the specified element of the top-level mapping
    /// </summary>
    /// <param name="nodeName"></param>
    /// <returns></returns>
    public FileNode? this[string nodeName]
    {
        get
        {
            ThrowIfDisposed();
            if (nodeName is null)
                throw new ArgumentNullException(nameof(nodeName));

            NativeMethods.HandleException(
                NativeMethods.core_FileStorage_indexer(ptr, nodeName, out var node));

            GC.KeepAlive(this);
            if (node == IntPtr.Zero)
                return null;
            return new FileNode(node);
        }
    }

    /// <summary>
    /// the currently written element
    /// </summary>
    public string ElName
    {
        get
        {
            ThrowIfDisposed();
            using var buf = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_FileStorage_elname(ptr, buf.CvPtr));
            GC.KeepAlive(this);
            return buf.ToString();
        }
    }

    /// <summary>
    /// the writer state
    /// </summary>
    public States State
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileStorage_state(ptr, out var ret));
            GC.KeepAlive(this);
            return (States)ret;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// operator that performs PCA. The previously stored data, if any, is released
    /// </summary>
    /// <param name="fileName">Name of the file to open or the text string to read the data from.
    /// Extension of the file (.xml, .yml/.yaml or .json) determines its format (XML, YAML or JSON respectively).
    /// Also you can append .gz to work with compressed files, for example myHugeMatrix.xml.gz.
    /// If both FileStorage::WRITE and FileStorage::MEMORY flags are specified, source is used just to specify the output file format (e.g. mydata.xml, .yml etc.).
    /// A file name can also contain parameters. You can use this format, "*?base64" (e.g. "file.json?base64" (case sensitive)),
    /// as an alternative to FileStorage::BASE64 flag.</param>
    /// <param name="flags">Mode of operation.</param>
    /// <param name="encoding">Encoding of the file. Note that UTF-16 XML encoding is not supported 
    /// currently and you should use 8-bit encoding instead of it.</param>
    /// <returns></returns>
    public virtual bool Open(string fileName, Modes flags, string? encoding = null)
    {
        ThrowIfDisposed();
        if (fileName is null)
            throw new ArgumentNullException(nameof(fileName));
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_open(ptr, fileName, (int)flags, encoding, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Returns true if the object is associated with currently opened file.
    /// </summary>
    /// <returns></returns>
    public virtual bool IsOpened()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_isOpened(ptr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Closes the file and releases all the memory buffers
    /// </summary>
    public virtual void Release()
    {
        ThrowIfDisposed();
        Dispose();
    }

    /// <summary>
    /// Closes the file, releases all the memory buffers and returns the text string
    /// </summary>
    /// <returns></returns>
    public string ReleaseAndGetString()
    {
        ThrowIfDisposed();
           
        try
        {
            using var stdString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_FileStorage_releaseAndGetString(ptr, stdString.CvPtr));
            return stdString.ToString();
        }
        finally
        {
            Dispose();
        }
    }

    /// <summary>
    /// Returns the first element of the top-level mapping
    /// </summary>
    /// <returns>The first element of the top-level mapping.</returns>
    public FileNode? GetFirstTopLevelNode()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_getFirstTopLevelNode(ptr, out var node));

        GC.KeepAlive(this);
        if (node == IntPtr.Zero)
            return null;
        return new FileNode(node);
    }

    /// <summary>
    /// Returns the top-level mapping. YAML supports multiple streams
    /// </summary>
    /// <param name="streamIdx"> Zero-based index of the stream. In most cases there is only one stream in the file.
    /// However, YAML supports multiple streams and so there can be several.</param>
    /// <returns>The top-level mapping.</returns>
    public FileNode? Root(int streamIdx = 0)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_root(ptr, streamIdx, out var node));

        GC.KeepAlive(this);
        if (node == IntPtr.Zero)
            return null;
        return new FileNode(node);
    }

    /// <summary>
    /// Writes one or more numbers of the specified format to the currently written structure
    /// </summary>
    /// <param name="fmt">Specification of each array element, see @ref format_spec "format specification"</param>
    /// <param name="vec">Pointer to the written array.</param>
    /// <param name="len">Number of the uchar elements to write.</param>
    public void WriteRaw(string fmt, IntPtr vec, int len)
    {
        if (fmt is null) 
            throw new ArgumentNullException(nameof(fmt));
        if (vec == IntPtr.Zero) 
            throw new ArgumentException("vec == IntPtr.Zero", nameof(vec));
        ThrowIfDisposed();
            
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeRaw(ptr, fmt, vec, new IntPtr(len)));

        GC.KeepAlive(this);
    }

    /// <summary>
    /// Writes a comment.
    /// The function writes a comment into file storage. The comments are skipped when the storage is read.
    /// </summary>
    /// <param name="comment">The written comment, single-line or multi-line</param>
    /// <param name="append">If true, the function tries to put the comment at the end of current line.
    /// Else if the comment is multi-line, or if it does not fit at the end of the current line, the comment starts a new line.</param>
    public void WriteComment(string comment, bool append = false)
    {
        if (comment is null) 
            throw new ArgumentNullException(nameof(comment));
        ThrowIfDisposed();
            
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeComment(ptr, comment, append ? 1 : 0));

        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="flags"></param>
    /// <param name="typeName"></param>
    public void StartWriteStruct(string name, int flags, string typeName)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_startWriteStruct(ptr, name, flags, typeName));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    public void EndWriteStruct()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_endWriteStruct(ptr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns the normalized object name for the specified file name
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetDefaultObjectName(string fileName)
    {
        if (fileName is null)
            throw new ArgumentNullException(nameof(fileName));

        using var buf = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_getDefaultObjectName(fileName, buf.CvPtr));
        return buf.ToString();
    }

    #region Write

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, int value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_int(ptr, name, value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, float value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_float(ptr, name, value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, double value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_double(ptr, name, value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, string value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_String(ptr, name, value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, Mat value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_Mat(ptr, name, value.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, SparseMat value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_SparseMat(ptr, name, value.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, IEnumerable<KeyPoint> value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        using var valueVector = new VectorOfKeyPoint(value);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_vectorOfKeyPoint(ptr, name, valueVector.CvPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, IEnumerable<DMatch> value)
    {
        ThrowIfDisposed();
        if (name is null)
            throw new ArgumentNullException(nameof(name));
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        using var valueVector = new VectorOfDMatch(value);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_vectorOfDMatch(ptr, name, valueVector.CvPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(int value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_int(ptr, value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(float value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_float(ptr, value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(double value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_double(ptr, value));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(string value)
    {
        ThrowIfDisposed();
        if (value is null)
            throw new ArgumentNullException(nameof(value));
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_String(ptr, value));
        GC.KeepAlive(this);
    }

    #endregion

    #region Add

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(string val)
    {
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_String(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(int val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_int(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(float val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_float(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(double val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_double(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Mat val)
    {
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        ThrowIfDisposed();
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_Mat(ptr, val.CvPtr));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(SparseMat val)
    {
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        ThrowIfDisposed();
        val.ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_SparseMat(ptr, val.CvPtr));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Range val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_Range(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(KeyPoint val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_KeyPoint(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(DMatch val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_DMatch(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(IEnumerable<KeyPoint> val)
    {
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        ThrowIfDisposed();
        using (var valVec = new VectorOfKeyPoint(val))
        {
            NativeMethods.HandleException( 
                NativeMethods.core_FileStorage_shift_vectorOfKeyPoint(ptr, valVec.CvPtr));
        }
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(IEnumerable<DMatch> val)
    {
        if (val is null)
            throw new ArgumentNullException(nameof(val));
        ThrowIfDisposed();
        using (var valVec = new VectorOfDMatch(val))
        {
            NativeMethods.HandleException( 
                NativeMethods.core_FileStorage_shift_vectorOfDMatch(ptr, valVec.CvPtr));
        }
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// /Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Point val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Point2i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Point2f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Point2f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Point2d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Point2d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Point3i val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Point3i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Point3f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Point3f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Point3d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Point3d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Size val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Size2i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Size2f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Size2f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Size2d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_Size2d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Rect val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Rect2i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Rect2f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Rect2f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Rect2d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Rect2d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Scalar val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Scalar(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec2i val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(   
            NativeMethods.core_FileStorage_shift_Vec2i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec3i val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Vec3i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec4i val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Vec4i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec6i val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec6i(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec2d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec2d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec3d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Vec3d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec4d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec4d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec6d val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec6d(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec2f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec2f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec3f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec3f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec4f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec4f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec6f val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec6f(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec2b val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec2b(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec3b val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec3b(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec4b val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Vec4b(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec6b val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec6b(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec2s val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Vec2s(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec3s val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec3s(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec4s val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec4s(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec6s val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec6s(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec2w val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_Vec2w(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec3w val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec3w(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec4w val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(  
            NativeMethods.core_FileStorage_shift_Vec4w(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Vec6w val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_Vec6w(ptr, val));
        GC.KeepAlive(this);
        return this;
    }

    #endregion

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Design", "CA1008: Enums should have zero value")]
    [SuppressMessage("Microsoft.Design", "CA1069: Enums should not have duplicate values")]
    public enum States
    {
        /// <summary>
        /// 
        /// </summary>
        Undefined = 0,
            
        /// <summary>
        /// 
        /// </summary>
        ValueExpected = 1,

        /// <summary>
        /// 
        /// </summary>
        NameExpected = 2,

        /// <summary>
        /// 
        /// </summary>
        InsideMap = 4
    }

    /// <summary>
    /// File storage mode
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Design", "CA1008: Enums should have zero value")]
    [SuppressMessage("Microsoft.Design", "CA1069: Enums should not have duplicate values")]
    public enum Modes
    {
        /// <summary>
        /// The storage is open for reading
        /// </summary>
        Read = 0,

        /// <summary>
        /// The storage is open for writing
        /// </summary>
        Write = 1,

        /// <summary>
        /// The storage is open for appending
        /// </summary>
        Append = 2,

        /// <summary>
        /// flag, read data from source or write data to the internal buffer
        /// (which is returned by FileStorage::release)
        /// </summary>
        Memory = 4,

        /// <summary>
        /// flag, auto format
        /// </summary>
        FormatAuto = 0,

        /// <summary>
        /// flag, XML format
        /// </summary>
        FormatXml = (1 << 3),

        /// <summary>
        /// flag, YAML format
        /// </summary>
        FormatYaml = (2 << 3),

        /// <summary>
        /// flag, write rawdata in Base64 by default. (consider using WRITE_BASE64)
        /// </summary>
        Base64 = 64, 

        /// <summary>
        /// flag, enable both WRITE and BASE64
        /// </summary>
        WriteBase64 = Base64 | Write,
    }
}
