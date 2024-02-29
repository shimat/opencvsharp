using System.Collections;
using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <summary>
/// File Storage Node class
/// </summary>
public class FileNode : DisposableCvObject, IEnumerable<FileNode>
{
    // ReSharper disable InconsistentNaming

    #region Init & Disposal

    /// <summary>
    /// The default constructor
    /// </summary>
    public FileNode()
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_new1(out ptr));
    }

    /// <summary>
    /// Initializes from cv::FileNode*
    /// </summary>
    /// <param name="ptr"></param>
    public FileNode(IntPtr ptr)
    {
        this.ptr = ptr;
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_delete(ptr));
        base.DisposeUnmanaged();
    }

    #endregion

    #region Cast

    /// <summary>
    /// Returns the node content as an integer. If the node stores floating-point number, it is rounded.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static explicit operator int(FileNode node)
    {
        if (node is null)
            throw new ArgumentNullException(nameof(node));
        return node.ToInt32();
    }

    /// <summary>
    /// Returns the node content as an integer. If the node stores floating-point number, it is rounded.
    /// </summary>
    /// <returns></returns>
    public int ToInt32()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_FileNode_toInt(ptr, out var ret));

        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns the node content as float
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static explicit operator float(FileNode node)
    {
        if (node is null)
            throw new ArgumentNullException(nameof(node));
        return node.ToSingle();
    }

    /// <summary>
    /// Returns the node content as System.Single
    /// </summary>
    /// <returns></returns>
    public float ToSingle()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_FileNode_toFloat(ptr, out var ret));

        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns the node content as double
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static explicit operator double(FileNode node)
    {
        if (node is null)
            throw new ArgumentNullException(nameof(node));
        return node.ToDouble();
    }

    /// <summary>
    /// Returns the node content as double
    /// </summary>
    /// <returns></returns>
    public double ToDouble()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_FileNode_toDouble(ptr, out var ret));

        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns the node content as text string
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static explicit operator string(FileNode node)
    {
        if (node is null)
            throw new ArgumentNullException(nameof(node));
        return node.ToString();
    }

    /// <summary>
    /// Returns the node content as text string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    { 
        ThrowIfDisposed();

        using var buf = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_toString(ptr, buf.CvPtr));

        GC.KeepAlive(this);
        return buf.ToString();
    }
        
    /// <summary>
    /// Returns the node content as OpenCV Mat
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static explicit operator Mat(FileNode node)
    {
        if (node is null)
            throw new ArgumentNullException(nameof(node));
        return node.ToMat();
    }

    /// <summary>
    /// Returns the node content as OpenCV Mat
    /// </summary>
    /// <returns></returns>
    public Mat ToMat()
    {
        ThrowIfDisposed();

        var matrix = new Mat();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_toMat(ptr, matrix.CvPtr));

        GC.KeepAlive(this);
        return matrix;
    }

    #endregion

    #region Properties

    /// <summary>
    /// returns element of a mapping node
    /// </summary>
    public FileNode? this[string nodeName]
    {
        get
        {
            ThrowIfDisposed();
            if (nodeName is null)
                throw new ArgumentNullException(nameof(nodeName));

            NativeMethods.HandleException(
                NativeMethods.core_FileNode_operatorThis_byString(ptr, nodeName, out var node));

            GC.KeepAlive(this);
            if (node == IntPtr.Zero)
                return null;
            return new FileNode(node);
        }
    }

    /// <summary>
    /// returns element of a sequence node
    /// </summary>
    public FileNode? this[int i]
    {
        get
        {
            ThrowIfDisposed();

            NativeMethods.HandleException( 
                NativeMethods.core_FileNode_operatorThis_byInt(ptr, i, out var node));

            GC.KeepAlive(this);
            if (node == IntPtr.Zero)
                return null;
            return new FileNode(node);
        }
    }

    /// <summary>
    /// Returns true if the node is empty
    /// </summary>
    /// <returns></returns>
    public bool Empty
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_empty(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns true if the node is a "none" object
    /// </summary>
    /// <returns></returns>
    public bool IsNone
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException( 
                NativeMethods.core_FileNode_isNone(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns true if the node is a sequence
    /// </summary>
    /// <returns></returns>
    public bool IsSeq
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException( 
                NativeMethods.core_FileNode_isSeq(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns true if the node is a mapping
    /// </summary>
    /// <returns></returns>
    public bool IsMap
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException( 
                NativeMethods.core_FileNode_isMap(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns true if the node is an integer
    /// </summary>
    /// <returns></returns>
    public bool IsInt
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_isInt(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns true if the node is a floating-point number
    /// </summary>
    /// <returns></returns>
    public bool IsReal
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException( 
                NativeMethods.core_FileNode_isReal(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns true if the node is a text string
    /// </summary>
    /// <returns></returns>
    public bool IsString
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException( 
                NativeMethods.core_FileNode_isString(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns true if the node has a name
    /// </summary>
    /// <returns></returns>
    public bool IsNamed
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_isNamed(ptr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
    }

    /// <summary>
    /// Returns the node name or an empty string if the node is nameless
    /// </summary>
    /// <returns></returns>
    public string Name
    {
        get
        {
            ThrowIfDisposed();
            using var buf = new StdString();
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_name(ptr, buf.CvPtr));
            GC.KeepAlive(this);
            return buf.ToString();
        }
    }

    /// <summary>
    /// Returns the number of elements in the node, if it is a sequence or mapping, or 1 otherwise.
    /// </summary>
    /// <returns></returns>
    public long Size
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_size(ptr, out var ret));
            GC.KeepAlive(this);
            return ret.ToInt64();
        }
    }

    /// <summary>
    /// Returns type of the node.
    /// </summary>
    /// <returns>Type of the node.</returns>
    public Types Type
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_type(ptr, out var ret));
            GC.KeepAlive(this);
            return (Types)ret;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// returns iterator pointing to the first node element
    /// </summary>
    /// <returns></returns>
    public FileNodeIterator Begin()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_begin(ptr, out var p));
        GC.KeepAlive(this);
        return new FileNodeIterator(p);
    }

    /// <summary>
    /// returns iterator pointing to the element following the last node element
    /// </summary>
    /// <returns></returns>
    public FileNodeIterator End()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_end(ptr, out var p));
        GC.KeepAlive(this);
        return new FileNodeIterator(p);
    }
        
    /// <summary>
    /// Get FileNode iterator 
    /// </summary>
    /// <returns></returns>
    public IEnumerator<FileNode> GetEnumerator()
    {
        using FileNodeIterator it = Begin(), end = End();
        for (; !it.Equals(end); it.MoveNext())
        {
            yield return it.Current;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Reads node elements to the buffer with the specified format
    /// </summary>
    /// <param name="fmt"></param>
    /// <param name="vec"></param>
    /// <param name="len"></param>
    public void ReadRaw(string fmt, IntPtr vec, long len)
    {
        ThrowIfDisposed();
        if (fmt is null)
            throw new ArgumentNullException(nameof(fmt));
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_readRaw(ptr, fmt, vec, new IntPtr(len)));
        GC.KeepAlive(this);
    }

    #region Read

    /// <summary>
    /// Reads the node element as Int32 (int)
    /// </summary>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public int ReadInt(int defaultValue = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_int(ptr, out var value, defaultValue));
        GC.KeepAlive(this);
        return value;
    }

    /// <summary>
    /// Reads the node element as Single (float)
    /// </summary>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public float ReadFloat(float defaultValue = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_float(ptr, out var value, defaultValue));
        GC.KeepAlive(this);
        return value;
    }

    /// <summary>
    /// Reads the node element as Double
    /// </summary>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public double ReadDouble(double defaultValue = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_double(ptr, out var value, defaultValue));
        GC.KeepAlive(this);
        return value;
    }

    /// <summary>
    /// Reads the node element as String
    /// </summary>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public string ReadString(string? defaultValue = null)
    {
        using var value = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_String(ptr, value.CvPtr, defaultValue));
        GC.KeepAlive(this);
        return value.ToString();
    }

    /// <summary>
    /// Reads the node element as Mat
    /// </summary>
    /// <param name="defaultMat"></param>
    /// <returns></returns>
    public Mat ReadMat(Mat? defaultMat = null)
    {
        var value = new Mat();
        try
        {
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_read_Mat(ptr, value.CvPtr, Cv2.ToPtr(defaultMat)));
            GC.KeepAlive(this);
            GC.KeepAlive(defaultMat);
        }
        catch
        {
            value.Dispose();
            throw;
        }
        return value;
    }

    /// <summary>
    /// Reads the node element as SparseMat
    /// </summary>
    /// <param name="defaultMat"></param>
    /// <returns></returns>
    public SparseMat ReadSparseMat(SparseMat? defaultMat = null)
    {
        var value = new SparseMat();
        try
        {
            NativeMethods.HandleException(
                NativeMethods.core_FileNode_read_SparseMat(ptr, value.CvPtr, Cv2.ToPtr(defaultMat)));
            GC.KeepAlive(this);
            GC.KeepAlive(defaultMat);
        }
        catch
        {
            value.Dispose();
            throw;
        }
        return value;
    }

    /// <summary>
    /// Reads the node element as KeyPoint[]
    /// </summary>
    /// <returns></returns>
    public KeyPoint[] ReadKeyPoints()
    {
        using var valueVector = new VectorOfKeyPoint();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_vectorOfKeyPoint(ptr, valueVector.CvPtr));
        GC.KeepAlive(this);
        return valueVector.ToArray();
    }

    /// <summary>
    /// Reads the node element as DMatch[]
    /// </summary>
    /// <returns></returns>
    public DMatch[] ReadDMatches()
    {
        using var valueVector = new VectorOfDMatch();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_vectorOfDMatch(ptr, valueVector.CvPtr));
        GC.KeepAlive(this);
        return valueVector.ToArray();
    }

    /// <summary>
    /// Reads the node element as Range
    /// </summary>
    /// <returns></returns>
    public Range ReadRange()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Range(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as KeyPoint
    /// </summary>
    /// <returns></returns>
    public KeyPoint ReadKeyPoint()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( NativeMethods.core_FileNode_read_KeyPoint(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as DMatch
    /// </summary>
    /// <returns></returns>
    public DMatch ReadDMatch()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_FileNode_read_DMatch(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Point
    /// </summary>
    /// <returns></returns>
    public Point ReadPoint()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( NativeMethods.core_FileNode_read_Point2i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Point2f
    /// </summary>
    /// <returns></returns>
    public Point2f ReadPoint2f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( NativeMethods.core_FileNode_read_Point2f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Point2d
    /// </summary>
    /// <returns></returns>
    public Point2d ReadPoint2d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( NativeMethods.core_FileNode_read_Point2d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Point3i
    /// </summary>
    /// <returns></returns>
    public Point3i ReadPoint3i()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Point3i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Point3f
    /// </summary>
    /// <returns></returns>
    public Point3f ReadPoint3f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Point3f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Point3d
    /// </summary>
    /// <returns></returns>
    public Point3d ReadPoint3d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Point3d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Size
    /// </summary>
    /// <returns></returns>
    public Size ReadSize()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Size2i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Size2f
    /// </summary>
    /// <returns></returns>
    public Size2f ReadSize2f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Size2f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Size2d
    /// </summary>
    /// <returns></returns>
    public Size2d ReadSize2d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Size2d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Rect
    /// </summary>
    /// <returns></returns>
    public Rect ReadRect()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Rect2i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Rect2f
    /// </summary>
    /// <returns></returns>
    public Rect2f ReadRect2f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Rect2f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Rect2d
    /// </summary>
    /// <returns></returns>
    public Rect2d ReadRect2d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Rect2d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Scalar
    /// </summary>
    /// <returns></returns>
    public Scalar ReadScalar()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Scalar(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec2i ReadVec2i()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Vec2i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec3i ReadVec3i()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec3i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec4i ReadVec4i()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec4i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec6i ReadVec6i()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec6i(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec2d ReadVec2d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec2d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec3d ReadVec3d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec3d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec4d ReadVec4d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec4d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec6d ReadVec6d()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec6d(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec2f ReadVec2f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec2f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec3f ReadVec3f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec3f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec4f ReadVec4f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec4f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec6f ReadVec6f()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec6f(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }
        
    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec2b ReadVec2b()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec2b(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Vec3b ReadVec3b()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec3b(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec4b ReadVec4b()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Vec4b(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec6b ReadVec6b()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec6b(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }


    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec2s ReadVec2s()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec2s(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec3s ReadVec3s()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Vec3s(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec4s ReadVec4s()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec4s(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec6s ReadVec6s()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Vec6s(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }
        
    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec2w ReadVec2w()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Vec2w(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec3w ReadVec3w()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec3w(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec4w ReadVec4w()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException( 
            NativeMethods.core_FileNode_read_Vec4w(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Reads the node element as Vector
    /// </summary>
    /// <returns></returns>
    public Vec6w ReadVec6w()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_FileNode_read_Vec6w(ptr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    #endregion

    #endregion

    /// <summary>
    /// type of the file storage node
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Design", "CA1069: Enums should not have duplicate values")]
    public enum Types
    {
        /// <summary>
        /// empty node
        /// </summary>
        None = 0,

        /// <summary>
        /// an integer
        /// </summary>
        Int = 1,

        /// <summary>
        /// floating-point number
        /// </summary>
        Real = 2,

        /// <summary>
        /// synonym or REAL
        /// </summary>
        Float = Real,

        /// <summary>
        /// text string in UTF-8 encoding
        /// </summary>
        Str = 3,

        /// <summary>
        /// synonym for STR
        /// </summary>
        String = Str,

        /// <summary>
        /// sequence
        /// </summary>
        Seq = 4,

        /// <summary>
        /// mapping
        /// </summary>
        Map = 5, 

        /// <summary>
        /// 
        /// </summary>
        TypeMask = 7,

        /// <summary>
        /// compact representation of a sequence or mapping. Used only by YAML writer
        /// </summary>
        Flow = 8,

        // ReSharper disable once CommentTypo
        /// <summary>
        /// if set, means that all the collection elements are numbers of the same type (real's or int's).
        /// UNIFORM is used only when reading FileStorage; FLOW is used only when writing. So they share the same bit
        /// </summary>
        Uniform = 8,  

        /// <summary>
        /// empty structure (sequence or mapping)
        /// </summary>
        Empty = 16,

        /// <summary>
        /// the node has a name (i.e. it is element of a mapping)
        /// </summary>
        Named = 32,
    }
}
