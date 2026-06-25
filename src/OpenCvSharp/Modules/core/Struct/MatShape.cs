using System.Linq;

namespace OpenCvSharp;

/// <summary>
/// Represents the shape of a matrix / tensor (OpenCV 5, cv::MatShape).
/// In addition to the per-axis sizes it carries the data <see cref="Layout"/> and, for the block
/// layout, the actual number of <see cref="Channels"/> (C). It also distinguishes an empty shape
/// (<see cref="IsEmpty"/>, total == 0) from a 0-dimensional scalar shape (<see cref="IsScalar"/>,
/// dims == 0 but total == 1).
/// </summary>
public readonly struct MatShape : IEquatable<MatShape>
{
    // null = empty shape; length 0 = 0-D scalar; length N = N-D shape.
    private readonly int[]? sizes;

    /// <summary>
    /// Data layout of the shape.
    /// </summary>
    public DataLayout Layout { get; }

    /// <summary>
    /// Actual number of channels (C), meaningful for the block layout; 0 otherwise.
    /// </summary>
    public int Channels { get; }

    private MatShape(int[]? sizes, DataLayout layout, int channels)
    {
        this.sizes = sizes;
        Layout = layout;
        Channels = channels;
    }

    /// <summary>
    /// Creates an N-D shape from the given per-axis sizes. Passing no sizes creates a 0-D scalar shape.
    /// </summary>
    /// <param name="sizes">Per-axis sizes.</param>
    public MatShape(params int[] sizes)
        : this(sizes ?? throw new ArgumentNullException(nameof(sizes)), DataLayout.UNKNOWN, 0)
    {
    }

    /// <summary>
    /// Creates an N-D shape with an explicit layout and channel count.
    /// </summary>
    /// <param name="sizes">Per-axis sizes.</param>
    /// <param name="layout">Data layout.</param>
    /// <param name="channels">Number of channels (C) for the block layout; 0 otherwise.</param>
    public MatShape(IEnumerable<int> sizes, DataLayout layout, int channels = 0)
        : this((sizes ?? throw new ArgumentNullException(nameof(sizes))) as int[] ?? sizes.ToArray(), layout, channels)
    {
    }

    /// <summary>
    /// An empty shape (total == 0).
    /// </summary>
    public static MatShape Empty => default;

    /// <summary>
    /// A 0-dimensional scalar shape (dims == 0, total == 1).
    /// </summary>
    /// <param name="layout">Data layout.</param>
    public static MatShape Scalar(DataLayout layout = DataLayout.UNKNOWN) => new(Array.Empty<int>(), layout, 0);

    /// <summary>
    /// The number of dimensions (axes). 0 for both empty and scalar shapes.
    /// </summary>
    public int Dims => sizes?.Length ?? 0;

    /// <summary>
    /// True if this is an empty shape (total == 0).
    /// </summary>
    public bool IsEmpty => sizes is null;

    /// <summary>
    /// True if this is a 0-dimensional scalar shape (dims == 0, total == 1).
    /// </summary>
    public bool IsScalar => sizes is { Length: 0 };

    /// <summary>
    /// The total number of elements: 0 for an empty shape, 1 for a scalar, otherwise the product of the sizes.
    /// </summary>
    public long Total
    {
        get
        {
            if (sizes is null)
                return 0;
            long total = 1;
            foreach (var s in sizes)
                total *= s;
            return total;
        }
    }

    /// <summary>
    /// Gets the size of the i-th axis.
    /// </summary>
    /// <param name="index">Axis index.</param>
    public int this[int index]
    {
        get
        {
            if (sizes is null)
                throw new InvalidOperationException("The shape is empty.");
            return sizes[index];
        }
    }

    /// <summary>
    /// Returns the per-axis sizes as an array (empty array for empty or scalar shapes).
    /// </summary>
    public int[] ToArray() => sizes is null ? Array.Empty<int>() : (int[])sizes.Clone();

    /// <summary>
    /// Implicitly converts per-axis sizes to a <see cref="MatShape"/>. A null array becomes an empty shape.
    /// </summary>
    public static implicit operator MatShape(int[]? sizes) => sizes is null ? Empty : new MatShape(sizes);

    /// <summary>
    /// Returns the per-axis sizes.
    /// </summary>
    public static explicit operator int[](MatShape shape) => shape.ToArray();

    // Native marshaling form: ndims == -1 (empty) / 0 (scalar) / N, plus the sizes buffer.
    internal int NativeDims => sizes is null ? -1 : sizes.Length;

    internal int[] NativeSizes => sizes ?? Array.Empty<int>();

    /// <inheritdoc />
    public bool Equals(MatShape other)
    {
        if (Layout != other.Layout || Channels != other.Channels)
            return false;
        if (sizes is null || other.sizes is null)
            return sizes is null && other.sizes is null;
        return sizes.AsSpan().SequenceEqual(other.sizes);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is MatShape other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Layout);
        hash.Add(Channels);
        if (sizes is not null)
        {
            foreach (var s in sizes)
                hash.Add(s);
        }
        return hash.ToHashCode();
    }

    public static bool operator ==(MatShape left, MatShape right) => left.Equals(right);

    public static bool operator !=(MatShape left, MatShape right) => !left.Equals(right);

    /// <inheritdoc />
    public override string ToString()
    {
        if (sizes is null)
            return "MatShape(empty)";
        if (sizes.Length == 0)
            return "MatShape(scalar)";
        var body = string.Join(" x ", sizes);
        return Layout == DataLayout.UNKNOWN ? $"MatShape({body})" : $"MatShape({body}, {Layout})";
    }
}
