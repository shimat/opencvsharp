namespace OpenCvSharp;

/// <summary>
/// Provides zero-allocation, zero-P/Invoke-per-element row access to a 2D <see cref="Mat"/>.
/// Obtain via <see cref="Mat.AsRows{T}"/>. The data pointer, step, and dimensions are captured
/// once at construction time, so all subsequent row indexing is pure pointer arithmetic.
/// </summary>
/// <typeparam name="T">Unmanaged element type matching the matrix element type (e.g. <see cref="Vec3b"/> for CV_8UC3).</typeparam>
/// <remarks>
/// <para>
/// Typical usage for per-pixel iteration:
/// <code>
/// var rows = mat.AsRows&lt;Vec3b&gt;();
/// for (int r = 0; r &lt; rows.Count; r++)
/// {
///     Span&lt;Vec3b&gt; row = rows[r];
///     for (int c = 0; c &lt; row.Length; c++)
///     {
///         Vec3b pixel = row[c];
///     }
/// }
/// </code>
/// </para>
/// <para>
/// This is a <c>ref struct</c> and therefore cannot be stored in fields, boxed, or used as a
/// generic type argument.
/// </para>
/// </remarks>
public readonly ref struct MatRowAccessor<T> where T : unmanaged
{
    private readonly nint _data;
    private readonly nint _step;
    private readonly int _cols;

    /// <summary>Number of rows in the matrix.</summary>
    public int Count { get; }

    internal MatRowAccessor(nint data, nint step, int rows, int cols)
    {
        _data = data;
        _step = step;
        Count = rows;
        _cols = cols;
    }

    /// <summary>
    /// Returns a <see cref="Span{T}"/> over the specified row.
    /// No P/Invoke is performed; this is pure pointer arithmetic.
    /// Bounds are checked in DEBUG builds only.
    /// </summary>
    /// <param name="row">Zero-based row index.</param>
    public unsafe Span<T> this[int row]
    {
        get
        {
#if DEBUG
            if ((uint)row >= (uint)Count)
                throw new ArgumentOutOfRangeException(nameof(row));
#endif
            return new Span<T>((void*)(_data + _step * row), _cols);
        }
    }
}
