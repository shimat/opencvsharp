using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.Core;

public class MatPixelBlitTest : TestBase
{
    private static readonly int[] ThreeDimSizes = { 2, 2, 2 };

    [Fact]
    public void CopyPixelsToContinuous()
    {
        using var mat = new Mat(3, 4, MatType.CV_8UC3);
        FillSequential(mat);

        var rowBytes = mat.Cols * mat.ElemSize();
        var buffer = Marshal.AllocHGlobal(rowBytes * mat.Rows);
        try
        {
            mat.CopyPixelsTo(buffer, rowBytes);

            for (var y = 0; y < mat.Rows; y++)
            for (var x = 0; x < rowBytes; x++)
                Assert.Equal(GetByteAt(mat, y, x), Marshal.ReadByte(buffer, (y * rowBytes) + x));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsToSubmatrix()
    {
        using var parent = new Mat(6, 6, MatType.CV_8UC1);
        FillSequential(parent);
        using var sub = new Mat(parent, new Rect(1, 1, 3, 2));
        Assert.True(sub.IsSubmatrix());

        var rowBytes = sub.Cols * sub.ElemSize();
        var buffer = Marshal.AllocHGlobal(rowBytes * sub.Rows);
        try
        {
            sub.CopyPixelsTo(buffer, rowBytes);

            for (var y = 0; y < sub.Rows; y++)
            for (var x = 0; x < rowBytes; x++)
                Assert.Equal(GetByteAt(sub, y, x), Marshal.ReadByte(buffer, (y * rowBytes) + x));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsToPaddedDestinationStride()
    {
        using var mat = new Mat(2, 3, MatType.CV_8UC1);
        FillSequential(mat);

        var rowBytes = mat.Cols * mat.ElemSize();
        var dstStep = rowBytes + 5; // simulate a UI framework's padded/aligned stride
        var buffer = Marshal.AllocHGlobal(dstStep * mat.Rows);
        try
        {
            mat.CopyPixelsTo(buffer, dstStep);

            for (var y = 0; y < mat.Rows; y++)
            for (var x = 0; x < rowBytes; x++)
                Assert.Equal(GetByteAt(mat, y, x), Marshal.ReadByte(buffer, (y * dstStep) + x));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsToNegativeStride()
    {
        // Simulates a bottom-up buffer (e.g. a negative-stride GDI+ BitmapData): row 0 of the
        // Mat lands at the END of the buffer, and consecutive rows walk backwards through memory.
        using var mat = new Mat(3, 4, MatType.CV_8UC1);
        FillSequential(mat);

        var rowBytes = mat.Cols * mat.ElemSize();
        var buffer = Marshal.AllocHGlobal(rowBytes * mat.Rows);
        try
        {
            var bottomUpDst = IntPtr.Add(buffer, rowBytes * (mat.Rows - 1));
            mat.CopyPixelsTo(bottomUpDst, -rowBytes);

            for (var y = 0; y < mat.Rows; y++)
            for (var x = 0; x < rowBytes; x++)
            {
                var bufferOffset = (rowBytes * (mat.Rows - 1 - y)) + x;
                Assert.Equal(GetByteAt(mat, y, x), Marshal.ReadByte(buffer, bufferOffset));
            }
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsFromNegativeStride()
    {
        using var mat = new Mat(3, 4, MatType.CV_8UC1);

        var rowBytes = mat.Cols * mat.ElemSize();
        var buffer = Marshal.AllocHGlobal(rowBytes * mat.Rows);
        try
        {
            // Row 0 of the source lives at the END of the buffer (bottom-up layout).
            byte value = 0;
            for (var y = mat.Rows - 1; y >= 0; y--)
            for (var x = 0; x < rowBytes; x++)
                Marshal.WriteByte(buffer, (y * rowBytes) + x, value++);

            var bottomUpSrc = IntPtr.Add(buffer, rowBytes * (mat.Rows - 1));
            mat.CopyPixelsFrom(bottomUpSrc, -rowBytes);

            byte expected = 0;
            for (var y = 0; y < mat.Rows; y++)
            for (var x = 0; x < rowBytes; x++)
                Assert.Equal(expected++, GetByteAt(mat, y, x));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsToThrowsWhenNegativeStrideMagnitudeTooSmall()
    {
        using var mat = new Mat(2, 4, MatType.CV_8UC1);
        var buffer = Marshal.AllocHGlobal(mat.Rows * mat.Cols);
        try
        {
            Assert.Throws<ArgumentException>(() => mat.CopyPixelsTo(buffer, -(mat.Cols - 1)));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsRoundTrip()
    {
        using var src = new Mat(4, 5, MatType.CV_8UC4);
        FillSequential(src);

        var rowBytes = src.Cols * src.ElemSize();
        var buffer = Marshal.AllocHGlobal(rowBytes * src.Rows);
        try
        {
            src.CopyPixelsTo(buffer, rowBytes);

            using var dst = new Mat(src.Rows, src.Cols, MatType.CV_8UC4);
            dst.CopyPixelsFrom(buffer, rowBytes);

            ImageEquals(src, dst);
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsToThrowsOnNullPointer()
    {
        using var mat = new Mat(2, 2, MatType.CV_8UC1);
        Assert.Throws<ArgumentException>(() => mat.CopyPixelsTo(IntPtr.Zero, 2));
    }

    [Fact]
    public void CopyPixelsToThrowsWhenDstStepTooSmall()
    {
        using var mat = new Mat(2, 4, MatType.CV_8UC1);
        var buffer = Marshal.AllocHGlobal(mat.Rows * mat.Cols);
        try
        {
            Assert.Throws<ArgumentException>(() => mat.CopyPixelsTo(buffer, mat.Cols - 1));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [Fact]
    public void CopyPixelsToThrowsForMatWithMoreThanTwoDimensions()
    {
        using var mat = new Mat((IEnumerable<int>)ThreeDimSizes, MatType.CV_8UC1);
        var buffer = Marshal.AllocHGlobal(16);
        try
        {
            Assert.Throws<ArgumentException>(() => mat.CopyPixelsTo(buffer, 4));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    private static unsafe void FillSequential(Mat mat)
    {
        var rowBytes = mat.Cols * mat.ElemSize();
        byte value = 0;
        for (var y = 0; y < mat.Rows; y++)
        {
            var row = mat.DataPointer + (int)(y * mat.Step());
            for (var x = 0; x < rowBytes; x++)
                row[x] = value++;
        }
    }

    private static unsafe byte GetByteAt(Mat mat, int y, int x)
    {
        return (mat.DataPointer + (int)(y * mat.Step()))[x];
    }
}
