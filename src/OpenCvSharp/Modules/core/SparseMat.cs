using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>
/// Sparse matrix (cv::SparseMat). This type-erased base exposes the structural and
/// metadata operations that do not depend on the element type. For typed element
/// access use <see cref="SparseMat{T}"/> (e.g. via <see cref="As{T}"/>).
/// </summary>
public class SparseMat : CvObject
{
    #region Init & Disposal

    /// <summary>
    /// Creates from a native cv::SparseMat* pointer.
    /// </summary>
    /// <param name="ptr"></param>
    public SparseMat(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Native object address is NULL");
        InitSafeHandle(ptr);
    }

    /// <summary>
    /// Creates an empty SparseMat.
    /// </summary>
    public SparseMat()
    {
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_new1(out var p));
        InitSafeHandle(p);
    }

    /// <summary>
    /// Constructs an n-dimensional sparse matrix.
    /// </summary>
    /// <param name="sizes">Array of integers specifying an n-dimensional array shape.</param>
    /// <param name="type">Array type.</param>
    public SparseMat(IEnumerable<int> sizes, MatType type)
    {
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));

        var sizesArray = sizes as int[] ?? sizes.ToArray();
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_new2(sizesArray.Length, sizesArray, type, out var p));
        InitSafeHandle(p);
    }

    /// <summary>
    /// Converts a dense cv::Mat to a sparse matrix.
    /// </summary>
    /// <param name="m">cv::Mat object</param>
    public SparseMat(Mat m)
    {
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        m.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_new3(m.CvPtr, out var p));

        GC.KeepAlive(m);
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException();
        InitSafeHandle(p);
    }

    /// <summary>
    /// Releases the resources.
    /// </summary>
    public void Release()
    {
        Dispose();
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.core_SparseMat_delete(h))));
    }

    /// <summary>
    /// Creates a sparse matrix from a dense cv::Mat.
    /// </summary>
    /// <param name="mat"></param>
    public static SparseMat FromMat(Mat mat) => new(mat);

    #endregion

    #region Type-erased operations

    /// <summary>
    /// Assignment operator. This is an O(1) operation that shares the data.
    /// </summary>
    /// <param name="m"></param>
    public SparseMat AssignFrom(SparseMat m)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_operatorAssign_SparseMat(Handle, m.CvPtr));
        GC.KeepAlive(m);
        return this;
    }

    /// <summary>
    /// Assignment from a dense matrix (equivalent to the corresponding constructor).
    /// </summary>
    /// <param name="m"></param>
    public SparseMat AssignFrom(Mat m)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_operatorAssign_Mat(Handle, m.CvPtr));
        GC.KeepAlive(m);
        return this;
    }

    /// <summary>
    /// Creates a full copy of the matrix.
    /// </summary>
    public SparseMat Clone()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_clone(Handle, out var p));
        GC.KeepAlive(this);
        return new SparseMat(p);
    }

    /// <summary>
    /// Copies all the data to another sparse matrix.
    /// </summary>
    /// <param name="m"></param>
    public void CopyTo(SparseMat m)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_copyTo_SparseMat(Handle, m.CvPtr));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// Converts the sparse matrix to a dense matrix.
    /// </summary>
    /// <param name="m"></param>
    public void CopyTo(Mat m)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_copyTo_Mat(Handle, m.CvPtr));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// Multiplies all the matrix elements by the specified scale factor.
    /// </summary>
    public void ConvertTo(SparseMat m, MatType rtype, double alpha = 1)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_convertTo_SparseMat(Handle, m.CvPtr, rtype, alpha));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// Converts sparse matrix to dense matrix.
    /// </summary>
    public void ConvertTo(Mat m, MatType rtype, double alpha = 1, double beta = 0)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_convertTo_Mat(Handle, m.CvPtr, rtype, alpha, beta));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// Converts this sparse matrix to a new dense <see cref="Mat"/> of the same type.
    /// </summary>
    public Mat ToMat()
    {
        ThrowIfDisposed();
        var dst = new Mat();
        ConvertTo(dst, Type());
        return dst;
    }

    /// <summary>
    /// </summary>
    public void AssignTo(SparseMat m, MatType? type = null)
    {
        ThrowIfDisposed();
        if (m is null)
            throw new ArgumentNullException(nameof(m));
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_assignTo(Handle, m.CvPtr, type?.Value ?? -1));
        GC.KeepAlive(m);
    }

    /// <summary>
    /// Reallocates the sparse matrix.
    /// </summary>
    public void Create(MatType type, params int[] sizes)
    {
        ThrowIfDisposed();
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));
        if (sizes.Length == 1)
            throw new ArgumentException("sizes is empty");
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_create(Handle, sizes.Length, sizes, type));
    }

    /// <summary>
    /// Sets all the matrix elements to 0, which means clearing the hash table.
    /// </summary>
    public void Clear()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_clear(Handle));
    }

    /// <summary>
    /// Manually increments the reference counter to the header.
    /// </summary>
    public void AddRef()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_addref(Handle));
    }

    #endregion

    #region Metadata

    /// <summary>
    /// Returns the size of each element in bytes.
    /// </summary>
    public int ElemSize()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_elemSize(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the size of each element channel in bytes.
    /// </summary>
    public int ElemSize1()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_elemSize1(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the type of sparse matrix element.
    /// </summary>
    public MatType Type()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_type(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the depth of sparse matrix element.
    /// </summary>
    public int Depth()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_depth(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the matrix dimensionality.
    /// </summary>
    public int Dims()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_dims(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of sparse matrix channels.
    /// </summary>
    public int Channels()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_channels(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the array of sizes, or null if the matrix is not allocated.
    /// </summary>
    public int[] Size()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_size1(Handle, out var sizePtr));
        if (sizePtr == IntPtr.Zero)
            throw new OpenCvSharpException("core_SparseMat_size1 == IntPtr.Zero");

        var length = Dims();
        var size = new int[length];
        Marshal.Copy(sizePtr, size, 0, length);
        // sizePtr points into this SparseMat; keep it alive across the copy above.
        GC.KeepAlive(this);
        return size;
    }

    /// <summary>
    /// Returns the size of i-th matrix dimension (or 0).
    /// </summary>
    public int Size(int dim)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_size2(Handle, dim, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of non-zero elements (the number of hash table nodes).
    /// </summary>
    public long NzCount()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.core_SparseMat_nzcount(Handle, out var ret));
        return (long)ret;
    }

    #endregion

    #region Typed access support (used by SparseMat&lt;T&gt;)

    /// <summary>
    /// Returns a pointer to the element at <paramref name="index"/>, creating it (zero-initialized)
    /// when <paramref name="createMissing"/> is true. Returns <see cref="IntPtr.Zero"/> if the element
    /// does not exist and is not created.
    /// </summary>
    internal IntPtr ElementPointer(ReadOnlySpan<int> index, bool createMissing)
    {
        ThrowIfDisposed();
        IntPtr ret;
        var flag = createMissing ? 1 : 0;
        unsafe
        {
            switch (index.Length)
            {
                case 1:
                    NativeMethods.HandleException(
                        NativeMethods.core_SparseMat_ptr_1d(Handle, index[0], flag, null, out ret));
                    break;
                case 2:
                    NativeMethods.HandleException(
                        NativeMethods.core_SparseMat_ptr_2d(Handle, index[0], index[1], flag, null, out ret));
                    break;
                case 3:
                    NativeMethods.HandleException(
                        NativeMethods.core_SparseMat_ptr_3d(Handle, index[0], index[1], index[2], flag, null, out ret));
                    break;
                default:
                    NativeMethods.HandleException(
                        NativeMethods.core_SparseMat_ptr_nd(Handle, index.ToArray(), flag, null, out ret));
                    break;
            }
        }
        // Returns an interior pointer into this SparseMat; keep it alive for the caller's dereference.
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Removes the stored element at <paramref name="index"/> (no-op if it does not exist).
    /// </summary>
    internal void EraseElement(ReadOnlySpan<int> index)
    {
        ThrowIfDisposed();
        unsafe
        {
            NativeMethods.HandleException(
                NativeMethods.core_SparseMat_erase_nd(Handle, index.ToArray(), null));
        }
        GC.KeepAlive(this);
    }

    #endregion

    /// <summary>
    /// Returns a typed view of this sparse matrix. The element type must match this matrix's type.
    /// The returned matrix shares the data with this one (O(1)).
    /// </summary>
    /// <typeparam name="T">Element type matching this matrix's <see cref="Type"/>.</typeparam>
    public SparseMat<T> As<T>() where T : unmanaged
    {
        ThrowIfDisposed();
        var expected = MatTypeMap.Get<T>();
        var actual = Type();
        if (actual != expected)
            throw new OpenCvSharpException(
                $"This SparseMat has type {actual}, which does not match {typeof(T)} ({expected}).");
        return SparseMat<T>.WrapShared(this);
    }

    /// <summary>
    /// Returns a string that represents this SparseMat.
    /// </summary>
    public override string ToString()
        => $"SparseMat [ Dims={Dims()}, Type={Type()}, NzCount={NzCount()} ]";
}

/// <summary>
/// Strongly-typed sparse matrix. <typeparamref name="T"/> determines the element type, so element
/// access needs no per-call type argument and no runtime type checks: reading an absent element
/// returns <c>default</c> without creating it; assigning through the indexer creates it.
/// </summary>
/// <typeparam name="T">Element type (e.g. <see cref="int"/>, <see cref="Vec3b"/>).</typeparam>
public sealed class SparseMat<T> : SparseMat
    where T : unmanaged
{
    /// <summary>
    /// Constructs an n-dimensional sparse matrix of the given shape.
    /// </summary>
    /// <param name="dimensions">Size along each dimension.</param>
    public SparseMat(params int[] dimensions)
        : base(dimensions ?? throw new ArgumentNullException(nameof(dimensions)), MatTypeMap.Get<T>())
    {
    }

    private SparseMat()
        : base()
    {
    }

    private SparseMat(IntPtr ptr)
        : base(ptr)
    {
    }

    internal static SparseMat<T> WrapShared(SparseMat source)
    {
        var result = new SparseMat<T>();
        result.AssignFrom(source);
        return result;
    }

    /// <summary>
    /// Creates a typed sparse matrix from a dense <see cref="Mat"/>. The Mat type must match
    /// <typeparamref name="T"/>.
    /// </summary>
    public static new SparseMat<T> FromMat(Mat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        var expected = MatTypeMap.Get<T>();
        if (mat.Type() != expected)
            throw new OpenCvSharpException(
                $"Mat has type {mat.Type()}, which does not match {typeof(T)} ({expected}).");
        var result = new SparseMat<T>();
        result.AssignFrom(mat);
        return result;
    }

    #region Element access

    /// <summary>
    /// Gets or sets the element at the given 2-D index. Reading an absent element returns
    /// <c>default</c> (without creating it); assigning creates the element.
    /// </summary>
    public T this[int i0, int i1]
    {
        get => Read([i0, i1]);
        set => Write([i0, i1], value);
    }

    /// <summary>
    /// Gets or sets the element at the given 3-D index. Reading an absent element returns
    /// <c>default</c> (without creating it); assigning creates the element.
    /// </summary>
    public T this[int i0, int i1, int i2]
    {
        get => Read([i0, i1, i2]);
        set => Write([i0, i1, i2], value);
    }

    /// <summary>
    /// Gets or sets the element at the given n-D index. Reading an absent element returns
    /// <c>default</c> (without creating it); assigning creates the element.
    /// </summary>
    public T this[ReadOnlySpan<int> index]
    {
        get => Read(index);
        set => Write(index, value);
    }

    private unsafe T Read(ReadOnlySpan<int> index)
    {
        var p = ElementPointer(index, createMissing: false);
        if (p == IntPtr.Zero)
            return default;
        var value = Unsafe.Read<T>((void*)p);
        GC.KeepAlive(this);
        return value;
    }

    private unsafe void Write(ReadOnlySpan<int> index, T value)
    {
        var p = ElementPointer(index, createMissing: true);
        Unsafe.Write((void*)p, value);
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns whether an element is stored (non-zero) at the given index.
    /// </summary>
    public bool Contains(ReadOnlySpan<int> index)
    {
        var p = ElementPointer(index, createMissing: false);
        return p != IntPtr.Zero;
    }

    /// <summary>
    /// Gets the element at the given index if it is stored, without creating it.
    /// </summary>
    public unsafe bool TryGetValue(ReadOnlySpan<int> index, out T value)
    {
        var p = ElementPointer(index, createMissing: false);
        if (p == IntPtr.Zero)
        {
            value = default;
            return false;
        }
        value = Unsafe.Read<T>((void*)p);
        GC.KeepAlive(this);
        return true;
    }

    /// <summary>
    /// Removes the stored element at the given index. Returns false if it was not stored.
    /// </summary>
    public bool Remove(ReadOnlySpan<int> index)
    {
        var existed = Contains(index);
        EraseElement(index);
        return existed;
    }

    /// <summary>
    /// Returns a reference to the element at the given index, creating it (zero-initialized) if it
    /// does not exist. Useful for in-place updates such as accumulation (<c>sm.GetValueRef(i, j)++</c>),
    /// which performs a single hash lookup.
    /// </summary>
    /// <remarks>
    /// The reference points into native storage and is only valid until the next structural change
    /// to the matrix (an insertion that triggers a rehash, <see cref="SparseMat.Clear"/>, disposal,
    /// etc.). Do not retain it across such operations.
    /// </remarks>
    public unsafe ref T GetValueRef(ReadOnlySpan<int> index)
    {
        var p = ElementPointer(index, createMissing: true);
        return ref Unsafe.AsRef<T>((void*)p);
    }

    #endregion

    /// <summary>
    /// Enumerates every stored (non-zero) element together with its index, mirroring
    /// cv::SparseMatConstIterator. This visits only the stored elements, not the full dense
    /// index space.
    /// </summary>
    /// <returns>
    /// A sequence of (index, value) pairs. Each <c>Index</c> is a fresh array of length
    /// <see cref="SparseMat.Dims"/>. The enumeration is a snapshot taken when the method is called.
    /// </returns>
    public IEnumerable<(int[] Index, T Value)> EnumerateNonZero()
    {
        ThrowIfDisposed();
        var count = (int)NzCount();
        var dims = Dims();
        var indices = new int[count * dims];
        var values = new T[count];
        if (count > 0)
        {
            unsafe
            {
                fixed (int* indicesPtr = indices)
                fixed (T* valuesPtr = values)
                {
                    NativeMethods.HandleException(
                        NativeMethods.core_SparseMat_getNodes(
                            Handle, dims, (IntPtr)indicesPtr, (IntPtr)valuesPtr, (nuint)Unsafe.SizeOf<T>()));
                }
            }
            GC.KeepAlive(this);
        }
        return Enumerate(indices, values, count, dims);

        static IEnumerable<(int[], T)> Enumerate(int[] indices, T[] values, int count, int dims)
        {
            for (var i = 0; i < count; i++)
            {
                var index = new int[dims];
                Array.Copy(indices, i * dims, index, 0, dims);
                yield return (index, values[i]);
            }
        }
    }

    /// <summary>
    /// Creates a full (deep) copy of the matrix.
    /// </summary>
    public new SparseMat<T> Clone()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SparseMat_clone(Handle, out var p));
        GC.KeepAlive(this);
        return new SparseMat<T>(p);
    }
}
