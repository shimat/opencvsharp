using System;

namespace OpenCvSharp;

public partial class Mat
{
    /// <summary>
    /// Copies this matrix's row data into an unmanaged buffer that has its own row stride,
    /// such as a UI framework's bitmap buffer. Handles submatrices and non-continuous matrices correctly.
    /// Performs no pixel-format conversion; convert the channel layout beforehand (e.g. via Cv2.CvtColor)
    /// if the destination expects a different channel order or count.
    /// </summary>
    /// <param name="dst">Pointer to the first byte of the destination buffer.</param>
    /// <param name="dstStep">Number of bytes between the start of consecutive rows in the destination buffer.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="dst"/> is a null pointer, this matrix has more than 2 dimensions,
    /// or <paramref name="dstStep"/> is smaller than the row byte width of this matrix.
    /// </exception>
    public unsafe void CopyPixelsTo(IntPtr dst, long dstStep)
    {
        ThrowIfDisposed();
        if (dst == IntPtr.Zero)
            throw new ArgumentException("dst must not be a null pointer", nameof(dst));
        if (Dims > 2)
            throw new ArgumentException("CopyPixelsTo supports only 2-dimensional matrices");

        var rowBytes = (long)Cols * ElemSize();
        if (dstStep < rowBytes)
            throw new ArgumentException(
                $"dstStep ({dstStep}) is smaller than the row byte width ({rowBytes})", nameof(dstStep));

        var rows = Rows;
        var srcStep = Step();
        var srcPtr = DataPointer;
        var dstPtr = (byte*)dst;

        if (!IsSubmatrix() && IsContinuous() && srcStep == dstStep)
        {
            Buffer.MemoryCopy(srcPtr, dstPtr, dstStep * rows, srcStep * rows);
        }
        else
        {
            for (var y = 0; y < rows; y++)
            {
                Buffer.MemoryCopy(srcPtr + y * srcStep, dstPtr + y * dstStep, rowBytes, rowBytes);
            }
        }
    }

    /// <summary>
    /// Copies row data from an unmanaged buffer that has its own row stride into this matrix.
    /// Performs no pixel-format conversion; the source buffer must already match this matrix's
    /// channel layout (convert with Cv2.CvtColor after the copy if it doesn't).
    /// </summary>
    /// <param name="src">Pointer to the first byte of the source buffer.</param>
    /// <param name="srcStep">Number of bytes between the start of consecutive rows in the source buffer.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="src"/> is a null pointer, this matrix has more than 2 dimensions,
    /// or <paramref name="srcStep"/> is smaller than the row byte width of this matrix.
    /// </exception>
    public unsafe void CopyPixelsFrom(IntPtr src, long srcStep)
    {
        ThrowIfDisposed();
        if (src == IntPtr.Zero)
            throw new ArgumentException("src must not be a null pointer", nameof(src));
        if (Dims > 2)
            throw new ArgumentException("CopyPixelsFrom supports only 2-dimensional matrices");

        var rowBytes = (long)Cols * ElemSize();
        if (srcStep < rowBytes)
            throw new ArgumentException(
                $"srcStep ({srcStep}) is smaller than the row byte width ({rowBytes})", nameof(srcStep));

        var rows = Rows;
        var dstStep = Step();
        var srcPtr = (byte*)src;
        var dstPtr = DataPointer;

        if (!IsSubmatrix() && IsContinuous() && dstStep == srcStep)
        {
            Buffer.MemoryCopy(srcPtr, dstPtr, dstStep * rows, srcStep * rows);
        }
        else
        {
            for (var y = 0; y < rows; y++)
            {
                Buffer.MemoryCopy(srcPtr + y * srcStep, dstPtr + y * dstStep, rowBytes, rowBytes);
            }
        }
    }
}
