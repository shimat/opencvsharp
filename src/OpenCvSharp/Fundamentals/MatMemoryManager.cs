using System.Buffers;

namespace OpenCvSharp;

/// <summary>
/// A MemoryManager over an OpenCvSharpMat
/// </summary>
/// <remarks>The pointer is assumed to be fully unmanaged, or externally pinned - no attempt will be made to pin this data</remarks>
public sealed unsafe class MatMemoryManager<T> : MemoryManager<T>
    where T : unmanaged
{
    private readonly Mat wrapped;

    /// <summary>
    /// Create a new UnmanagedMemoryManager instance at the given pointer and size
    /// </summary>
    /// <remarks>It is assumed that the span provided is already unmanaged or externally pinned</remarks>
    public MatMemoryManager(Mat mat, bool isDataOwner = true)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        if (!mat.IsContinuous())
            throw new ArgumentException("mat is not continuous", nameof(mat));

        wrapped = isDataOwner ? mat : new Mat(mat);
    }

    /// <inheritdoc />
    public override Span<T> GetSpan() => new((void*)wrapped.Data, (int)wrapped.Total());

    /// <summary>
    /// Provides access to a pointer that represents the data (note: no actual pin occurs)
    /// </summary>
    public override MemoryHandle Pin(int elementIndex = 0)
    {
        if (elementIndex < 0 || elementIndex >= wrapped.Total())
            throw new ArgumentOutOfRangeException(nameof(elementIndex));

        var dims = wrapped.Dims;
        var idxs = new int[dims];
        var remainIdx = elementIndex;
        for (var dim = dims - 1; dim >= 0; dim--)
        {
            remainIdx = Math.DivRem(remainIdx, wrapped.Size(dim), out idxs[dim]);
        }

        return new MemoryHandle((void*)wrapped.Ptr(idxs));
    }

    /// <summary>
    /// Has no effect
    /// </summary>
    public override void Unpin()
    {
    }

    /// <summary>
    /// Releases all resources associated with this object
    /// </summary>
    protected override void Dispose(bool disposing) 
        => wrapped.Dispose();
}
