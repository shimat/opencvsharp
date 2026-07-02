using System.Runtime.InteropServices;

namespace OpenCvSharp;

// InputArray/OutputArray/InputOutputArray: handle-less, stack-only proxies that mirror OpenCV's
// cv::_InputArray/_OutputArray/_InputOutputArray. Each carries just a native handle + a kind tag
// (and an inline payload for scalar/vector operands). No native _InputArray is allocated on the
// managed side; the extern boundary receives the proxy BY VALUE and rebuilds a
// cv::_InputArray/_OutputArray on its own stack (see fromInputProxy/fromOutputProxy in my_types.h).
// This makes implicit-conversion temporaries (e.g. Cv2.Foo(mat, dst)) allocation-free and avoids the
// non-deterministic finalizer cleanup a heap-allocated proxy class would need.
//
// Scope (owner decision, "Option 1"): handle kinds (Mat/UMat/MatExpr) and inline value kinds
// (Scalar/double/Vec). Array / Span / vector-of-Mat inputs are NOT carried here (they get dedicated
// ReadOnlySpan / out Mat[] signatures), so a proxy never owns pinned memory.

/// <summary>Kind of array a proxy refers to. Must match the switch in my_types.h.</summary>
public enum ArrayProxyKind
{
    /// <summary>No array (cv::noArray()).</summary>
    None = 0,
    /// <summary>A <see cref="Mat"/>.</summary>
    Mat = 1,
    /// <summary>A <see cref="UMat"/>.</summary>
    UMat = 2,
    /// <summary>A <see cref="MatExpr"/> (materialized to a native cv::MatExpr).</summary>
    MatExpr = 3,
    /// <summary>A <see cref="Scalar"/> value (inline).</summary>
    Scalar = 4,
    /// <summary>A scalar <see cref="double"/> value (inline, as Scalar(d,0,0,0)).</summary>
    Double = 5,
    /// <summary>A small fixed-length vector value (inline).</summary>
    Vec = 6,
}

/// <summary>
/// Blittable plain-old-data mirror of <c>interop::InputArrayProxy</c> (my_types.h). Passed BY VALUE
/// across the P/Invoke boundary; no field is a managed reference, so it marshals 1:1. Only inputs
/// can be a Scalar/Vec value, so this is the only proxy that carries the inline payload.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct InputArrayProxy
{
    public IntPtr Handle;     // Mat/UMat/NativeMatExpr CvPtr for handle kinds; zero otherwise
    public int Kind;          // ArrayProxyKind
    public int VecDepth;      // Vec only: CV_8U..CV_64F element depth; otherwise 0
    public int VecLength;     // Vec only: element count (2/3/4/6); otherwise 0
    // Inline payload: Scalar (4 doubles) / double (1) / Vec (raw bytes, <= 48). 6 doubles == 48 bytes.
    public double Payload0;
    public double Payload1;
    public double Payload2;
    public double Payload3;
    public double Payload4;
    public double Payload5;

    public static InputArrayProxy FromScalar(in Scalar s) => new()
    {
        Handle = IntPtr.Zero,
        Kind = (int)ArrayProxyKind.Scalar,
        Payload0 = s.Val0,
        Payload1 = s.Val1,
        Payload2 = s.Val2,
        Payload3 = s.Val3,
    };
}

/// <summary>
/// Blittable mirror of <c>interop::OutputArrayProxy</c> (my_types.h). An output is always a
/// Mat/UMat (or a raw native handle), so it only needs a handle + kind — no inline payload.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct OutputArrayProxy
{
    public IntPtr Handle;     // Mat/UMat CvPtr, or a cv::_OutputArray* for the Raw kind
    public int Kind;          // ArrayProxyKind
}

/// <summary>
/// Blittable mirror of <c>interop::InputOutputArrayProxy</c> (my_types.h). Handle + kind only.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct InputOutputArrayProxy
{
    public IntPtr Handle;     // Mat/UMat CvPtr, or a cv::_InputOutputArray* for the Raw kind
    public int Kind;          // ArrayProxyKind
}

/// <summary>
/// Stack-only input proxy (see file header). Carries a native handle or an inline value; building
/// one allocates nothing on the managed heap.
/// </summary>
public readonly ref struct InputArray
{
    // Keeps the source Mat/UMat/NativeMatExpr alive across the native call (the proxy stores only
    // its raw handle).
    internal readonly object? Source;
    internal readonly InputArrayProxy Proxy;

    private InputArray(object? source, InputArrayProxy proxy)
    {
        Source = source;
        Proxy = proxy;
    }

    /// <summary>True if this proxy carries no array (i.e. wraps <c>cv::noArray()</c>).</summary>
    internal bool IsEmpty => Proxy.Kind == (int)ArrayProxyKind.None;

    /// <summary>Wraps a <see cref="Mat"/> (no allocation).</summary>
    public static implicit operator InputArray(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputArray(mat, new InputArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.Mat });
    }

    /// <summary>Wraps a <see cref="UMat"/> (no allocation).</summary>
    public static implicit operator InputArray(UMat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputArray(mat, new InputArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.UMat });
    }

    /// <summary>
    /// Wraps a <see cref="MatExpr"/>. The expression is materialized into a native cv::MatExpr
    /// (kept alive via <see cref="Source"/>), so this path is not allocation-free — matching the
    /// inherent cost of feeding a lazy expression into an OpenCV call.
    /// </summary>
    public static implicit operator InputArray(MatExpr expr)
    {
        ArgumentNullException.ThrowIfNull(expr);
        var native = expr.Eval();
        return new InputArray(native, new InputArrayProxy { Handle = native.CvPtr, Kind = (int)ArrayProxyKind.MatExpr });
    }

    /// <summary>Wraps a <see cref="Scalar"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Scalar s) =>
        new(null, InputArrayProxy.FromScalar(s));

    /// <summary>Wraps a <see cref="double"/> value (no allocation; travels inline as Scalar(d,0,0,0)).</summary>
    public static implicit operator InputArray(double d) =>
        new(null, new InputArrayProxy { Kind = (int)ArrayProxyKind.Double, Payload0 = d });

    // cv depth constants for the inline Vec payload (cv::CV_8U .. CV_64F).
    private const int DepthU8 = 0, DepthU16 = 2, DepthS16 = 3, DepthS32 = 4, DepthF32 = 5, DepthF64 = 6;

    // Copies a fixed-length vector value into the inline payload (no allocation). The native side
    // reads it back as (const T*)payload with VecLength elements; see fromInputProxy in my_types.h.
    private static InputArray FromVec<T>(T vec, int depth, int length) where T : unmanaged
    {
        var proxy = new InputArrayProxy { Kind = (int)ArrayProxyKind.Vec, VecDepth = depth, VecLength = length };
        var payload = MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref proxy.Payload0, 6));
        MemoryMarshal.Write(payload, in vec);
        return new InputArray(null, proxy);
    }

    /// <summary>Wraps a <see cref="Vec2b"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec2b v) => FromVec(v, DepthU8, 2);
    /// <summary>Wraps a <see cref="Vec3b"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec3b v) => FromVec(v, DepthU8, 3);
    /// <summary>Wraps a <see cref="Vec4b"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec4b v) => FromVec(v, DepthU8, 4);
    /// <summary>Wraps a <see cref="Vec6b"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec6b v) => FromVec(v, DepthU8, 6);
    /// <summary>Wraps a <see cref="Vec2s"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec2s v) => FromVec(v, DepthS16, 2);
    /// <summary>Wraps a <see cref="Vec3s"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec3s v) => FromVec(v, DepthS16, 3);
    /// <summary>Wraps a <see cref="Vec4s"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec4s v) => FromVec(v, DepthS16, 4);
    /// <summary>Wraps a <see cref="Vec6s"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec6s v) => FromVec(v, DepthS16, 6);
    /// <summary>Wraps a <see cref="Vec2w"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec2w v) => FromVec(v, DepthU16, 2);
    /// <summary>Wraps a <see cref="Vec3w"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec3w v) => FromVec(v, DepthU16, 3);
    /// <summary>Wraps a <see cref="Vec4w"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec4w v) => FromVec(v, DepthU16, 4);
    /// <summary>Wraps a <see cref="Vec6w"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec6w v) => FromVec(v, DepthU16, 6);
    /// <summary>Wraps a <see cref="Vec2i"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec2i v) => FromVec(v, DepthS32, 2);
    /// <summary>Wraps a <see cref="Vec3i"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec3i v) => FromVec(v, DepthS32, 3);
    /// <summary>Wraps a <see cref="Vec4i"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec4i v) => FromVec(v, DepthS32, 4);
    /// <summary>Wraps a <see cref="Vec6i"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec6i v) => FromVec(v, DepthS32, 6);
    /// <summary>Wraps a <see cref="Vec2f"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec2f v) => FromVec(v, DepthF32, 2);
    /// <summary>Wraps a <see cref="Vec3f"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec3f v) => FromVec(v, DepthF32, 3);
    /// <summary>Wraps a <see cref="Vec4f"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec4f v) => FromVec(v, DepthF32, 4);
    /// <summary>Wraps a <see cref="Vec6f"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec6f v) => FromVec(v, DepthF32, 6);
    /// <summary>Wraps a <see cref="Vec2d"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec2d v) => FromVec(v, DepthF64, 2);
    /// <summary>Wraps a <see cref="Vec3d"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec3d v) => FromVec(v, DepthF64, 3);
    /// <summary>Wraps a <see cref="Vec4d"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec4d v) => FromVec(v, DepthF64, 4);
    /// <summary>Wraps a <see cref="Vec6d"/> value (no allocation; travels inline).</summary>
    public static implicit operator InputArray(Vec6d v) => FromVec(v, DepthF64, 6);

    #region Create (explicit-call parity with the implicit operators above)

    /// <summary>Wraps a <see cref="Mat"/> (no allocation).</summary>
    public static InputArray Create(Mat? mat) => mat!;

    /// <summary>Wraps a <see cref="UMat"/> (no allocation).</summary>
    public static InputArray Create(UMat mat) => mat;

    /// <summary>Wraps a <see cref="MatExpr"/> (materializes it to a native cv::MatExpr).</summary>
    public static InputArray Create(MatExpr node) => node;

    /// <summary>Wraps a <see cref="Scalar"/> value (no allocation; travels inline).</summary>
    public static InputArray Create(Scalar val) => val;

    /// <summary>Wraps a <see cref="double"/> value (no allocation; travels inline).</summary>
    public static InputArray Create(double val) => val;

    /// <summary>Wraps a fixed-length <see cref="IVec"/> value (no allocation; travels inline).</summary>
    public static InputArray Create(IVec vec)
    {
        ArgumentNullException.ThrowIfNull(vec);
        return vec switch
        {
            Vec2b v => (InputArray)v,
            Vec3b v => (InputArray)v,
            Vec4b v => (InputArray)v,
            Vec6b v => (InputArray)v,
            Vec2s v => (InputArray)v,
            Vec3s v => (InputArray)v,
            Vec4s v => (InputArray)v,
            Vec6s v => (InputArray)v,
            Vec2w v => (InputArray)v,
            Vec3w v => (InputArray)v,
            Vec4w v => (InputArray)v,
            Vec6w v => (InputArray)v,
            Vec2i v => (InputArray)v,
            Vec3i v => (InputArray)v,
            Vec4i v => (InputArray)v,
            Vec6i v => (InputArray)v,
            Vec2f v => (InputArray)v,
            Vec3f v => (InputArray)v,
            Vec4f v => (InputArray)v,
            Vec6f v => (InputArray)v,
            Vec2d v => (InputArray)v,
            Vec3d v => (InputArray)v,
            Vec4d v => (InputArray)v,
            Vec6d v => (InputArray)v,
            _ => throw new ArgumentException($"Not supported type: '{vec.GetType().Name}'", nameof(vec)),
        };
    }

    /// <summary>
    /// Wraps a 1-D array by copying it into a freshly-created <see cref="Mat"/> of the given
    /// <paramref name="type"/> (not allocation-free: this materializes a real Mat, same as the
    /// class-based <c>InputArray.Create&lt;T&gt;</c> it replaces).
    /// </summary>
    public static InputArray Create<T>(T[] array, MatType type) where T : unmanaged
    {
        ArgumentNullException.ThrowIfNull(array);
        if (array.Length == 0)
            throw new ArgumentException("array.Length == 0", nameof(array));
        return Mat.FromPixelData(array.Length, 1, type, array);
    }

    /// <summary>Wraps a 1-D array, inferring the <see cref="MatType"/> from <typeparamref name="T"/>.</summary>
    public static InputArray Create<T>(T[] array) where T : unmanaged =>
        Create(array, EstimateType(typeof(T)));

    /// <summary>
    /// Wraps a 2-D array by copying it into a freshly-created <see cref="Mat"/> of the given
    /// <paramref name="type"/>.
    /// </summary>
    public static InputArray Create<T>(T[,] array, MatType type) where T : unmanaged
    {
        ArgumentNullException.ThrowIfNull(array);
        var rows = array.GetLength(0);
        var cols = array.GetLength(1);
        if (rows == 0)
            throw new ArgumentException("array.GetLength(0) == 0", nameof(array));
        if (cols == 0)
            throw new ArgumentException("array.GetLength(1) == 0", nameof(array));
        return Mat.FromPixelData(rows, cols, type, array);
    }

    /// <summary>Wraps a 2-D array, inferring the <see cref="MatType"/> from <typeparamref name="T"/>.</summary>
    public static InputArray Create<T>(T[,] array) where T : unmanaged =>
        Create(array, EstimateType(typeof(T)));

    /// <summary>Wraps a sequence, inferring the <see cref="MatType"/> from <typeparamref name="T"/>.</summary>
    public static InputArray Create<T>(IEnumerable<T> enumerable) where T : unmanaged
    {
        ArgumentNullException.ThrowIfNull(enumerable);
        return Create(new List<T>(enumerable).ToArray());
    }

    /// <summary>Wraps a sequence by copying it into a freshly-created <see cref="Mat"/> of the given
    /// <paramref name="type"/>.</summary>
    public static InputArray Create<T>(IEnumerable<T> enumerable, MatType type) where T : unmanaged
    {
        ArgumentNullException.ThrowIfNull(enumerable);
        return Create(new List<T>(enumerable).ToArray(), type);
    }

    // Maps a raw/OpenCV struct element type to the single-column MatType used to host it in the
    // Mat built by Create<T>(T[]/T[,]) above. Ported unchanged from the class-based InputArray.
    private static MatType EstimateType(Type t)
    {
        var code = Type.GetTypeCode(t);
        switch (code)
        {
            case TypeCode.Byte: return MatType.CV_8UC1;
            case TypeCode.SByte: return MatType.CV_8SC1;
            case TypeCode.UInt16: return MatType.CV_16UC1;
            case TypeCode.Int16:
            case TypeCode.Char: return MatType.CV_16SC1;
            case TypeCode.UInt32:
            case TypeCode.Int32: return MatType.CV_32SC1;
            case TypeCode.Single: return MatType.CV_32FC1;
            case TypeCode.Double: return MatType.CV_64FC1;
        }

        if (t == typeof(Point)) return MatType.CV_32SC2;
        if (t == typeof(Point2f)) return MatType.CV_32FC2;
        if (t == typeof(Point2d)) return MatType.CV_64FC2;
        if (t == typeof(Point3i)) return MatType.CV_32SC3;
        if (t == typeof(Point3f)) return MatType.CV_32FC3;
        if (t == typeof(Point3d)) return MatType.CV_64FC3;
        if (t == typeof(Range)) return MatType.CV_32SC2;
        if (t == typeof(Rangef)) return MatType.CV_32FC2;
        if (t == typeof(Rect)) return MatType.CV_32SC4;
        if (t == typeof(Size)) return MatType.CV_32SC2;
        if (t == typeof(Size2f)) return MatType.CV_32FC2;

        if (t == typeof(Vec2b)) return MatType.CV_8UC2;
        if (t == typeof(Vec3b)) return MatType.CV_8UC3;
        if (t == typeof(Vec4b)) return MatType.CV_8UC4;
        if (t == typeof(Vec6b)) return MatType.CV_8UC(6);
        if (t == typeof(Vec2s)) return MatType.CV_16SC2;
        if (t == typeof(Vec3s)) return MatType.CV_16SC3;
        if (t == typeof(Vec4s)) return MatType.CV_16SC4;
        if (t == typeof(Vec6s)) return MatType.CV_16SC(6);
        if (t == typeof(Vec2w)) return MatType.CV_16UC2;
        if (t == typeof(Vec3w)) return MatType.CV_16UC3;
        if (t == typeof(Vec4w)) return MatType.CV_16UC4;
        if (t == typeof(Vec6w)) return MatType.CV_16UC(6);
        if (t == typeof(Vec2i)) return MatType.CV_32SC2;
        if (t == typeof(Vec3i)) return MatType.CV_32SC3;
        if (t == typeof(Vec4i)) return MatType.CV_32SC4;
        if (t == typeof(Vec6i)) return MatType.CV_32SC(6);
        if (t == typeof(Vec2f)) return MatType.CV_32FC2;
        if (t == typeof(Vec3f)) return MatType.CV_32FC3;
        if (t == typeof(Vec4f)) return MatType.CV_32FC4;
        if (t == typeof(Vec6f)) return MatType.CV_32FC(6);
        if (t == typeof(Vec2d)) return MatType.CV_64FC2;
        if (t == typeof(Vec3d)) return MatType.CV_64FC3;
        if (t == typeof(Vec4d)) return MatType.CV_64FC4;
        if (t == typeof(Vec6d)) return MatType.CV_64FC(6);

        throw new ArgumentException("Not supported value type for InputArray");
    }

    #endregion
}

/// <summary>
/// Stack-only output proxy (see file header). Single Mat/UMat output only — native writes through
/// the referenced matrix directly, so no write-back (Fix/AssignResult) is needed.
/// </summary>
public readonly ref struct OutputArray
{
    internal readonly object? Source;
    internal readonly OutputArrayProxy Proxy;

    private OutputArray(object? source, OutputArrayProxy proxy)
    {
        Source = source;
        Proxy = proxy;
    }

    /// <summary>Wraps a <see cref="Mat"/> output (no allocation).</summary>
    public static implicit operator OutputArray(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new OutputArray(mat, new OutputArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.Mat });
    }

    /// <summary>Wraps a <see cref="UMat"/> output (no allocation).</summary>
    public static implicit operator OutputArray(UMat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new OutputArray(mat, new OutputArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.UMat });
    }

    /// <summary>Wraps a <see cref="Mat"/> output (no allocation).</summary>
    public static OutputArray Create(Mat mat) => mat;

    /// <summary>Wraps a <see cref="UMat"/> output (no allocation).</summary>
    public static OutputArray Create(UMat mat) => mat;
}

/// <summary>
/// Stack-only input/output proxy (see file header). Single Mat/UMat only; its read/write role is
/// flag-dependent in OpenCV, so it is kept as one type (not split into in/out variants).
/// </summary>
public readonly ref struct InputOutputArray
{
    internal readonly object? Source;
    internal readonly InputOutputArrayProxy Proxy;

    private InputOutputArray(object? source, InputOutputArrayProxy proxy)
    {
        Source = source;
        Proxy = proxy;
    }

    /// <summary>Wraps a <see cref="Mat"/> in/out target (no allocation).</summary>
    public static implicit operator InputOutputArray(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputOutputArray(mat, new InputOutputArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.Mat });
    }

    /// <summary>Wraps a <see cref="UMat"/> in/out target (no allocation).</summary>
    public static implicit operator InputOutputArray(UMat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);
        mat.ThrowIfDisposed();
        return new InputOutputArray(mat, new InputOutputArrayProxy { Handle = mat.CvPtr, Kind = (int)ArrayProxyKind.UMat });
    }

    /// <summary>Wraps a <see cref="Mat"/> in/out target (no allocation).</summary>
    public static InputOutputArray Create(Mat mat) => mat;

    /// <summary>Wraps a <see cref="UMat"/> in/out target (no allocation).</summary>
    public static InputOutputArray Create(UMat mat) => mat;
}
