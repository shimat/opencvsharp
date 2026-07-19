using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <summary>
/// XML/YAML File Storage Class.
/// </summary>
public class FileStorage : CvObject
{
    #region Init & Disposal

    /// <summary>
    /// Default constructor.
    /// You should call FileStorage::open() after initialization.
    /// </summary>
    public FileStorage()
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_new1(out var p));
        InitSafeHandle(p);
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
        ArgumentNullException.ThrowIfNull(source);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_new2(source, (int)flags, encoding, out var p));
        InitSafeHandle(p);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.core_FileStorage_delete(h))));
    }

    #endregion

    #region Properties

    /// <summary>
    /// Returns the specified element of the top-level mapping, or null if the key is not
    /// present (or is explicitly stored as a "none" value).
    /// </summary>
    /// <param name="nodeName"></param>
    /// <returns></returns>
    public FileNode? this[string nodeName]
    {
        get
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(nodeName);

            NativeMethods.HandleException(
                NativeMethods.core_FileStorage_indexer(Handle, nodeName, out var node));

            return FileNode.FromRawPtrOrNull(node);
        }
    }

    /// <summary>
    /// Navigates a chain of mapping keys (<see cref="string"/>) and/or sequence indices
    /// (<see cref="int"/>) starting from the top-level mapping, disposing every intermediate
    /// <see cref="FileNode"/> along the way. Equivalent to repeated indexer chaining (e.g.
    /// <c>fs["a"][2]["b"]</c>), except that the indexer chain leaves every intermediate node
    /// unreferenced - each one is still a real native allocation that would otherwise sit
    /// around until the GC finalizes it.
    /// </summary>
    /// <param name="path">One or more mapping keys / sequence indices to follow, in order.
    /// The first segment must be a string (a key of the top-level mapping).</param>
    /// <returns>The node at the end of the path, or null if any segment along the way is missing.</returns>
    public FileNode? GetPath(object[] path)
    {
        ArgumentNullException.ThrowIfNull(path);
        if (path.Length == 0)
            throw new ArgumentException("Path must contain at least one key or index.", nameof(path));
        if (path[0] is not string firstKey)
            throw new ArgumentException("The first path segment must be a string (top-level mapping key).", nameof(path));

        ThrowIfDisposed();

        var first = this[firstKey];
        if (first is null || path.Length == 1)
            return first;

        try
        {
            return first.GetPath(path[1..]);
        }
        finally
        {
            first.Dispose();
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
                NativeMethods.core_FileStorage_elname(Handle, buf.CvPtr));
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
                NativeMethods.core_FileStorage_state(Handle, out var ret));
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
        ArgumentNullException.ThrowIfNull(fileName);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_open(Handle, fileName, (int)flags, encoding, out var ret));
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
            NativeMethods.core_FileStorage_isOpened(Handle, out var ret));
        return ret != 0;
    }

    /// <summary>
    /// Returns the current format (one of the Modes.Format* flags).
    /// </summary>
    /// <returns></returns>
    public virtual Modes GetFormat()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_getFormat(Handle, out var ret));
        return (Modes)ret;
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
                NativeMethods.core_FileStorage_releaseAndGetString(Handle, stdString.CvPtr));
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
            NativeMethods.core_FileStorage_getFirstTopLevelNode(Handle, out var node));

        return FileNode.FromRawPtrOrNull(node);
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
            NativeMethods.core_FileStorage_root(Handle, streamIdx, out var node));

        return FileNode.FromRawPtrOrNull(node);
    }

    /// <summary>
    /// Writes one or more numbers of the specified format to the currently written structure
    /// </summary>
    /// <param name="fmt">Specification of each array element, see @ref format_spec "format specification"</param>
    /// <param name="vec">The bytes to write.</param>
    public unsafe void WriteRaw(string fmt, ReadOnlySpan<byte> vec)
    {
        ArgumentNullException.ThrowIfNull(fmt);
        ThrowIfDisposed();

        fixed (byte* p = vec)
        {
            NativeMethods.HandleException(
                NativeMethods.core_FileStorage_writeRaw(Handle, fmt, (IntPtr)p, new IntPtr(vec.Length)));
        }
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
        ArgumentNullException.ThrowIfNull(comment);
        ThrowIfDisposed();
            
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeComment(Handle, comment, append ? 1 : 0));

    }

    /// <summary>
    /// Starts to write a nested structure (sequence or a mapping).
    /// </summary>
    /// <param name="name">name of the structure. When writing to sequences (a.k.a. "arrays"), pass an empty string.</param>
    /// <param name="flags">structure type, one of <see cref="FileNode.Types.Map"/>/<see cref="FileNode.Types.Seq"/>,
    /// optionally combined with <see cref="FileNode.Types.Flow"/> for a compact YAML representation.</param>
    /// <param name="typeName">optional name of an object class this structure stores.</param>
    public void StartWriteStruct(string name, FileNode.Types flags, string? typeName = null)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_startWriteStruct(Handle, name, (int)flags, typeName ?? string.Empty));
    }

    /// <summary>
    /// 
    /// </summary>
    public void EndWriteStruct()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_endWriteStruct(Handle));
    }

    /// <summary>
    /// Starts writing a nested structure (sequence or mapping) and returns a disposable scope
    /// that calls <see cref="EndWriteStruct"/> automatically, so the structure can be written
    /// inside a <c>using</c> block instead of manually pairing
    /// <see cref="StartWriteStruct"/>/<see cref="EndWriteStruct"/> calls.
    /// </summary>
    /// <param name="name">name of the structure. When writing to sequences (a.k.a. "arrays"), pass an empty string.</param>
    /// <param name="flags">structure type, one of <see cref="FileNode.Types.Map"/>/<see cref="FileNode.Types.Seq"/>,
    /// optionally combined with <see cref="FileNode.Types.Flow"/> for a compact YAML representation.</param>
    /// <param name="typeName">optional name of an object class this structure stores.</param>
    /// <example>
    /// <code>
    /// using (fs.WriteStruct("camera", FileNode.Types.Map))
    /// {
    ///     fs.Write("fx", 800.0);
    ///     fs.Write("fy", 800.0);
    /// }
    /// </code>
    /// </example>
    public StructScope WriteStruct(string name, FileNode.Types flags, string? typeName = null)
    {
        StartWriteStruct(name, flags, typeName);
        return new StructScope(this);
    }

    /// <summary>
    /// Disposable scope returned by <see cref="WriteStruct"/>. Disposing it calls
    /// <see cref="EndWriteStruct"/> on the owning <see cref="FileStorage"/>.
    /// </summary>
    /// <remarks>
    /// This is deliberately a class, not a struct: EndWriteStruct() has an ordered, one-shot
    /// unmanaged side effect (it closes the innermost open structure in the underlying
    /// cv::FileStorage), so calling it twice corrupts whatever is written afterwards. A struct
    /// can't guarantee that - copying it (e.g. `var b = a;`) produces an independent instance
    /// with its own disposed flag, so guarding with a field only protects the single-variable
    /// case, not a copy disposed separately. As a class, every reference shares the same
    /// disposed flag, so Dispose() is idempotent no matter how many variables point to it.
    /// </remarks>
    public sealed class StructScope : IDisposable
    {
        private readonly FileStorage fileStorage;
        private bool disposed;

        internal StructScope(FileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        /// <summary>
        /// Ends the structure (calls <see cref="FileStorage.EndWriteStruct"/>). Idempotent:
        /// calling this more than once only ends the structure once.
        /// </summary>
        public void Dispose()
        {
            if (disposed)
                return;
            disposed = true;
            fileStorage.EndWriteStruct();
        }
    }

    /// <summary>
    /// Returns the normalized object name for the specified file name
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetDefaultObjectName(string fileName)
    {
        ArgumentNullException.ThrowIfNull(fileName);

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
        ArgumentNullException.ThrowIfNull(name);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_int(Handle, name, value));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, bool value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_bool(Handle, name, value ? 1 : 0));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, long value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_int64(Handle, name, value));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, float value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_float(Handle, name, value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, double value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_double(Handle, name, value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, string value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_String(Handle, name, value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, Mat value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_Mat(Handle, name, value.CvPtr));
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
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);

        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_SparseMat(Handle, name, value.CvPtr));
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
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);

        using var valueVector = new StdVector<KeyPoint>(value);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_vectorOfKeyPoint(Handle, name, valueVector.CvPtr));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, IEnumerable<DMatch> value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);

        using var valueVector = new StdVector<DMatch>(value);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_vectorOfDMatch(Handle, name, valueVector.CvPtr));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Write(string name, IEnumerable<string> value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);

        using var valueVector = new VectorOfString(value);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_write_vectorOfString(Handle, name, valueVector.CvPtr));
    }

    /// <summary>
    /// Writes a <see cref="JsonNode"/> tree (scalars, arrays, objects) under the given key,
    /// recursively, via the ordinary <see cref="Write(string,int)"/>/<see cref="WriteStruct"/>
    /// calls - the counterpart to <see cref="FileNode.ToJsonNode"/>. Native FileStorage remains
    /// the actual XML/YAML/JSON engine; this only lets callers build the data to write using
    /// <see cref="System.Text.Json"/> types instead of one-call-per-value/struct-scope calls.
    /// </summary>
    /// <param name="name">Key to write the value under (top level or inside an open mapping).
    /// Pass an empty string for an anonymous element inside an open sequence.</param>
    /// <param name="value">The value to write. A JSON null throws, since FileStorage has no
    /// native representation for an explicit null scalar.</param>
    public void Write(string name, JsonNode? value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(name);

        switch (value)
        {
            case null:
                throw new NotSupportedException(
                    $"Cannot write a JSON null for key '{name}': FileStorage has no representation for an explicit null value.");

            case JsonObject obj:
                using (WriteStruct(name, FileNode.Types.Map))
                {
                    foreach (var (key, child) in obj)
                        Write(key, child);
                }
                break;

            case JsonArray array:
                using (WriteStruct(name, FileNode.Types.Seq))
                {
                    foreach (var item in array)
                        Write(string.Empty, item);
                }
                break;

            case JsonValue scalar:
                WriteJsonScalar(name, scalar);
                break;

            default:
                throw new NotSupportedException($"Unsupported JsonNode type '{value.GetType()}' for key '{name}'.");
        }
    }

    private void WriteJsonScalar(string name, JsonValue value)
    {
        if (value.TryGetValue(out bool b)) { Write(name, b); return; }

        // JsonValue.Create(T) preserves the exact CLR type it was created from - TryGetValue<T>
        // does a strict type match for it, unlike a JsonNode.Parse()-produced JsonValue (backed by
        // JsonElement, which freely widens across numeric types). So a value created via e.g.
        // JsonValue.Create(3) (int) or a plain `new JsonObject { ["x"] = 3 }` assignment fails
        // TryGetValue<long>/<double> and must be probed by its exact CLR type instead.
        if (value.TryGetValue(out long l)) { Write(name, l); return; }
        if (value.TryGetValue(out int i)) { Write(name, (long)i); return; }
        if (value.TryGetValue(out short sh)) { Write(name, (long)sh); return; }
        if (value.TryGetValue(out sbyte sb)) { Write(name, (long)sb); return; }
        if (value.TryGetValue(out byte by)) { Write(name, (long)by); return; }
        if (value.TryGetValue(out ushort us)) { Write(name, (long)us); return; }
        if (value.TryGetValue(out uint ui)) { Write(name, (long)ui); return; }
        if (value.TryGetValue(out ulong ul)) { Write(name, unchecked((long)ul)); return; }

        if (value.TryGetValue(out double d)) { Write(name, d); return; }
        if (value.TryGetValue(out float f)) { Write(name, (double)f); return; }
        if (value.TryGetValue(out decimal dec)) { Write(name, (double)dec); return; }

        if (value.TryGetValue(out string? s)) { Write(name, s!); return; }
        throw new NotSupportedException($"Unsupported JsonValue underlying type for key '{name}'.");
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(int value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_int(Handle, value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(float value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_float(Handle, value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(double value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_double(Handle, value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void WriteScalar(string value)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(value);
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_writeScalar_String(Handle, value));
    }

    #endregion

    #region Add

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(string val)
    {
        ArgumentNullException.ThrowIfNull(val);
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_String(Handle, val));
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
            NativeMethods.core_FileStorage_shift_int(Handle, val));
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
            NativeMethods.core_FileStorage_shift_float(Handle, val));
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
            NativeMethods.core_FileStorage_shift_double(Handle, val));
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(Mat val)
    {
        ArgumentNullException.ThrowIfNull(val);
        ThrowIfDisposed();
        val.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileStorage_shift_Mat(Handle, val.CvPtr));
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(SparseMat val)
    {
        ArgumentNullException.ThrowIfNull(val);
        ThrowIfDisposed();
        val.ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileStorage_shift_SparseMat(Handle, val.CvPtr));
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
            NativeMethods.core_FileStorage_shift_Range(Handle, val));
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
            NativeMethods.core_FileStorage_shift_KeyPoint(Handle, val));
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
            NativeMethods.core_FileStorage_shift_DMatch(Handle, val));
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(IEnumerable<KeyPoint> val)
    {
        ArgumentNullException.ThrowIfNull(val);
        ThrowIfDisposed();
        using (var valVec = new StdVector<KeyPoint>(val))
        {
            NativeMethods.HandleException( 
                NativeMethods.core_FileStorage_shift_vectorOfKeyPoint(Handle, valVec.CvPtr));
        }
        return this;
    }

    /// <summary>
    /// Writes data to a file storage.
    /// </summary>
    /// <param name="val"></param>
    public FileStorage Add(IEnumerable<DMatch> val)
    {
        ArgumentNullException.ThrowIfNull(val);
        ThrowIfDisposed();
        using (var valVec = new StdVector<DMatch>(val))
        {
            NativeMethods.HandleException( 
                NativeMethods.core_FileStorage_shift_vectorOfDMatch(Handle, valVec.CvPtr));
        }
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
            NativeMethods.core_FileStorage_shift_Point2i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Point2f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Point2d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Point3i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Point3f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Point3d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Size2i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Size2f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Size2d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Rect2i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Rect2f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Rect2d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Scalar(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec2i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec3i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec4i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec6i(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec2d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec3d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec4d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec6d(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec2f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec3f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec4f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec6f(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec2b(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec3b(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec4b(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec6b(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec2s(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec3s(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec4s(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec6s(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec2w(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec3w(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec4w(Handle, val));
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
            NativeMethods.core_FileStorage_shift_Vec6w(Handle, val));
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
        /// flag, JSON format
        /// </summary>
        FormatJson = (3 << 3),

        /// <summary>
        /// flag, legacy YAML 1.0 format (strict headers, booleans as ints)
        /// </summary>
        FormatYaml10 = (4 << 3),

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
