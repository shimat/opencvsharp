namespace OpenCvSharp;

// PROTOTYPE (issue: InputArray/OutputArray ref struct redesign).
// A handle-less, stack-only proxy that mirrors OpenCV's cv::_InputArray: it carries just a
// native handle + a kind tag (and an inline Scalar for scalar operands). No native _InputArray
// is allocated on the managed side; the extern boundary builds cv::_InputArray on the stack.
// This makes the implicit-conversion temporaries (e.g. Cv2.Foo(mat, dst)) allocation-free and
// removes the non-deterministic finalizer cleanup of the current class-based InputArray.
//
// Named *Ref while prototyping to avoid colliding with the existing InputArray/OutputArray
// classes; once proven on a few functions these replace them.

/// <summary>Kind of array a ref-struct proxy refers to.</summary>
public enum ArrayProxyKind
{
    /// <summary>No array (cv::noArray()).</summary>
    None = 0,
    /// <summary>A <see cref="Mat"/>.</summary>
    Mat = 1,
    /// <summary>A <see cref="UMat"/>.</summary>
    UMat = 2,
    /// <summary>A <see cref="Scalar"/> value.</summary>
    Scalar = 3,
    /// <summary>A scalar <see cref="double"/> value.</summary>
    Double = 4,
}

/// <summary>
/// PROTOTYPE stack-only input proxy (see file header).
/// </summary>
public readonly ref struct InputArrayRef
{
    // Keeps the source Mat/UMat alive across the native call (the struct only stores its raw handle).
    internal readonly object? Source;
    internal readonly nint Handle;
    internal readonly ArrayProxyKind Kind;
    internal readonly Scalar ScalarValue;

    private InputArrayRef(object? source, nint handle, ArrayProxyKind kind, Scalar scalar)
    {
        Source = source;
        Handle = handle;
        Kind = kind;
        ScalarValue = scalar;
    }

    /// <summary>Wraps a <see cref="Mat"/> (no allocation).</summary>
    public static implicit operator InputArrayRef(Mat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        mat.ThrowIfDisposed();
        return new InputArrayRef(mat, mat.CvPtr, ArrayProxyKind.Mat, default);
    }

    /// <summary>Wraps a <see cref="UMat"/> (no allocation).</summary>
    public static implicit operator InputArrayRef(UMat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        mat.ThrowIfDisposed();
        return new InputArrayRef(mat, mat.CvPtr, ArrayProxyKind.UMat, default);
    }

    /// <summary>Wraps a <see cref="Scalar"/> value (no allocation).</summary>
    public static implicit operator InputArrayRef(Scalar s) =>
        new(null, 0, ArrayProxyKind.Scalar, s);

    /// <summary>Wraps a <see cref="double"/> value (no allocation).</summary>
    public static implicit operator InputArrayRef(double d) =>
        new(null, 0, ArrayProxyKind.Double, new Scalar(d, 0, 0, 0));
}

/// <summary>
/// PROTOTYPE stack-only output proxy (see file header). Single Mat/UMat output only — native
/// writes through the referenced matrix directly, so no write-back (Fix/AssignResult) is needed.
/// </summary>
public readonly ref struct OutputArrayRef
{
    internal readonly object? Source;
    internal readonly nint Handle;
    internal readonly ArrayProxyKind Kind;

    private OutputArrayRef(object? source, nint handle, ArrayProxyKind kind)
    {
        Source = source;
        Handle = handle;
        Kind = kind;
    }

    /// <summary>Wraps a <see cref="Mat"/> output (no allocation).</summary>
    public static implicit operator OutputArrayRef(Mat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        mat.ThrowIfDisposed();
        return new OutputArrayRef(mat, mat.CvPtr, ArrayProxyKind.Mat);
    }

    /// <summary>Wraps a <see cref="UMat"/> output (no allocation).</summary>
    public static implicit operator OutputArrayRef(UMat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        mat.ThrowIfDisposed();
        return new OutputArrayRef(mat, mat.CvPtr, ArrayProxyKind.UMat);
    }
}
