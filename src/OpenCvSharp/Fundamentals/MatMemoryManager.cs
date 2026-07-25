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
    private readonly int elementCount;

    /// <summary>
    /// Create a new UnmanagedMemoryManager instance at the given pointer and size
    /// </summary>
    /// <remarks>It is assumed that the span provided is already unmanaged or externally pinned</remarks>
    public MatMemoryManager(Mat mat, bool isDataOwner = true)
    {
        ArgumentNullException.ThrowIfNull(mat);
        if (!mat.IsContinuous())
            throw new ArgumentException("mat is not continuous", nameof(mat));

        var byteLength = checked(mat.Total() * mat.ElemSize());
        if (byteLength % sizeof(T) != 0)
        {
            throw new ArgumentException(
                $"The Mat byte length ({byteLength}) is not divisible by the size of {typeof(T)} ({sizeof(T)}).",
                nameof(mat));
        }

        elementCount = checked((int)(byteLength / sizeof(T)));
        wrapped = isDataOwner ? mat : new Mat(mat);
    }

    /// <inheritdoc />
    public override Span<T> GetSpan() => new((void*)wrapped.Data, elementCount);

    /// <summary>
    /// Provides access to a pointer that represents the data (note: no actual pin occurs)
    /// </summary>
    public override MemoryHandle Pin(int elementIndex = 0)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(elementIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(elementIndex, elementCount, nameof(elementIndex));

        var pointer = (byte*)wrapped.Data + checked((nint)elementIndex * sizeof(T));
        return new MemoryHandle(pointer, default, this);
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
