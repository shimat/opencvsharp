using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>Concatenates arrays along one axis, keeping each element's channels together.</summary>
    /// <param name="src">Arrays of the same type and shape, except for the concatenated axis.</param>
    /// <param name="axis">Axis to concatenate along. Negative values count from the end.</param>
    /// <param name="dst">Output array.</param>
    public static void Concat(ReadOnlySpan<Mat> src, int axis, OutputArray dst)
    {
        if (src.IsEmpty)
            throw new ArgumentException("The input must contain at least one matrix.", nameof(src));

        Span<IntPtr> handles = src.Length <= MaxStackAllocHandles
            ? stackalloc IntPtr[src.Length]
            : new IntPtr[src.Length];
        CopyMatHandles(src, handles, nameof(src));

        NativeMethods.HandleException(NativeMethods.core_concat(handles, src.Length, axis, dst.Proxy));

        foreach (var mat in src)
            GC.KeepAlive(mat);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Evaluates a fused element-wise expression with broadcasting.</summary>
    /// <param name="expression">An OpenCV expression over placeholders such as <c>{0}</c> and <c>{1}</c>.
    /// A parenthesized tuple produces multiple results.</param>
    /// <param name="inputs">Matrices bound to the numbered placeholders.</param>
    /// <returns>One matrix per result. The caller owns the returned matrices.</returns>
    public static Mat[] TExpr(string expression, ReadOnlySpan<Mat> inputs)
    {
        ArgumentNullException.ThrowIfNull(expression);

        Span<IntPtr> handles = inputs.Length <= MaxStackAllocHandles
            ? stackalloc IntPtr[inputs.Length]
            : new IntPtr[inputs.Length];
        CopyMatHandles(inputs, handles, nameof(inputs));

        using var outputs = new VectorOfMat();
        NativeMethods.HandleException(NativeMethods.core_texpr(expression, handles, inputs.Length, outputs.Handle));

        foreach (var mat in inputs)
            GC.KeepAlive(mat);
        return outputs.ToArray();
    }

    private static void CopyMatHandles(ReadOnlySpan<Mat> mats, Span<IntPtr> handles, string paramName)
    {
        for (var i = 0; i < mats.Length; i++)
        {
            ArgumentNullException.ThrowIfNull(mats[i], paramName);
            mats[i].ThrowIfDisposed();
            handles[i] = mats[i].CvPtr;
        }
    }

    /// <summary>Splits an array along one axis, keeping each element's channels together.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="axis">Axis to split along. Negative values count from the end.</param>
    /// <param name="sizes">Length of each part along the split axis. The lengths must sum to the size of the axis.</param>
    /// <returns>One matrix per requested part. The caller owns the returned matrices.</returns>
    public static Mat[] Split(InputArray src, int axis, ReadOnlySpan<int> sizes)
    {
        using var parts = new VectorOfMat();
        NativeMethods.HandleException(NativeMethods.core_splitND(src.Proxy, axis, sizes, sizes.Length, parts.Handle));

        GC.KeepAlive(src.Source);
        return parts.ToArray();
    }

    /// <summary>Copies a strided slice of an array.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="starts">First index along each sliced axis.</param>
    /// <param name="ends">Exclusive end index along each sliced axis. Use -1 to include index 0 when stepping backwards.</param>
    /// <param name="steps">Nonzero step along each sliced axis. An empty span uses a step of 1 for each axis.</param>
    /// <param name="dst">Output array.</param>
    /// <remarks>Indices are absolute. Axes beyond the supplied indices are copied in full.</remarks>
    public static void Slice(InputArray src, ReadOnlySpan<int> starts, ReadOnlySpan<int> ends,
        ReadOnlySpan<int> steps, OutputArray dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_slice(src.Proxy, starts, starts.Length, ends, ends.Length, steps, steps.Length, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Repeats an array along each axis.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="repeats">One nonnegative repeat count per axis.</param>
    /// <param name="dst">Output array.</param>
    public static void Repeat(InputArray src, ReadOnlySpan<int> repeats, OutputArray dst)
    {
        NativeMethods.HandleException(NativeMethods.core_repeatND(src.Proxy, repeats, repeats.Length, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Permutes the axes of an array, keeping each element's channels together.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="order">Input axis index for each output axis.</param>
    /// <param name="dst">Output array.</param>
    public static void Transpose(InputArray src, ReadOnlySpan<int> order, OutputArray dst)
    {
        NativeMethods.HandleException(NativeMethods.core_transposeND(src.Proxy, order, order.Length, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Removes axes of size one from an array.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="dst">Output array.</param>
    /// <param name="axes">Axes to remove. Negative values count from the end. An empty span removes all size-one axes.</param>
    public static void Squeeze(InputArray src, OutputArray dst, ReadOnlySpan<int> axes = default)
    {
        NativeMethods.HandleException(NativeMethods.core_squeeze(src.Proxy, dst.Proxy, axes, axes.Length));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Inserts axes of size one into an array.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="dst">Output array.</param>
    /// <param name="axes">Positions of the new axes. Negative values count from the end of the output shape.</param>
    public static void Unsqueeze(InputArray src, OutputArray dst, ReadOnlySpan<int> axes)
    {
        NativeMethods.HandleException(NativeMethods.core_unsqueeze(src.Proxy, dst.Proxy, axes, axes.Length));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Merges consecutive axes of an array into one axis.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="dst">Output array.</param>
    /// <param name="startAxis">First axis to merge. Negative values count from the end.</param>
    /// <param name="endAxis">Last axis to merge, inclusive. Negative values count from the end.</param>
    public static void Flatten(InputArray src, OutputArray dst, int startAxis = 0, int endAxis = -1)
    {
        NativeMethods.HandleException(NativeMethods.core_flatten(src.Proxy, dst.Proxy, startAxis, endAxis));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Changes an array's shape while preserving the number of elements and channels.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="dst">Output array.</param>
    /// <param name="newShape">Output axis sizes. A single -1 infers the size from the element count.</param>
    /// <param name="allowZero">Treat each 0 as a size instead of copying the corresponding input axis size.</param>
    /// <remarks>Use an empty destination to ensure the requested rank. OpenCV may reuse an existing
    /// one- or two-dimensional destination with matching rows and columns.</remarks>
    public static void Reshape(InputArray src, OutputArray dst, ReadOnlySpan<int> newShape, bool allowZero = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_reshape(src.Proxy, dst.Proxy, newShape, newShape.Length, allowZero ? 1 : 0));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>Reduces an array along the selected axes, processing each channel independently.</summary>
    /// <param name="src">Input array.</param>
    /// <param name="dst">Output array. If all axes are removed, the result is a zero-dimensional array.</param>
    /// <param name="parameters">Reduction operation, axes, and output options.</param>
    public static void Reduce(InputArray src, OutputArray dst, ReduceParams parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        ReadOnlySpan<int> axes = parameters.Axes;
        NativeMethods.HandleException(NativeMethods.core_reduceND(
            src.Proxy, dst.Proxy, (int)parameters.RType, axes, axes.Length,
            parameters.KeepDims ? 1 : 0, parameters.DType));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }
}
