using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

public static partial class Cv2
{
    // Above this count, collect Mat handles into a heap IntPtr[] instead of stackalloc, to bound
    // stack usage when passing a variable-length vector-of-Mat to the native cv::Mat** ABI.
    private const int MaxStackAllocHandles = 32;

    #region core.hpp

    /// <summary>
    /// Computes the source location of an extrapolated pixel.
    /// </summary>
    /// <param name="p">0-based coordinate of the extrapolated pixel along one of the axes, likely &lt;0 or &gt;= len</param>
    /// <param name="len">Length of the array along the corresponding axis.</param>
    /// <param name="borderType">Border type, one of the #BorderTypes, except for #BORDER_TRANSPARENT and BORDER_ISOLATED. 
    /// When borderType==BORDER_CONSTANT, the function always returns -1, regardless</param>
    /// <returns></returns>
    public static int BorderInterpolate(int p, int len, BorderTypes borderType)
    {
        NativeMethods.HandleException(
            NativeMethods.core_borderInterpolate(p, len, (int)borderType, out var ret));
        return ret;
    }

    /// <summary>
    /// Forms a border around the image
    /// </summary>
    /// <param name="src">The source image</param>
    /// <param name="dst">The destination image; will have the same type as src and 
    /// the size Size(src.cols+left+right, src.rows+top+bottom)</param>
    /// <param name="top">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
    /// <param name="bottom">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
    /// <param name="left">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
    /// <param name="right">Specify how much pixels in each direction from the source image rectangle one needs to extrapolate</param>
    /// <param name="borderType">The border type</param>
    /// <param name="value">The border value if borderType == Constant</param>
    public static void CopyMakeBorder(InputArrayRef src, OutputArrayRef dst, int top, int bottom, int left, int right,
        BorderTypes borderType, Scalar? value = null)
    {
        var value0 = value.GetValueOrDefault(new Scalar());
        NativeMethods.HandleException(
            NativeMethods.core_copyMakeBorder(
                src.Proxy, dst.Proxy, top, bottom, left, right, (int)borderType, value0));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Computes the per-element sum of two arrays or an array and a scalar.
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
    /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
    /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is skipped]</param>
    /// <param name="dtype"></param>
    public static void Add(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, InputArrayRef mask = default,
        int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_add(
                src1.Proxy, src2.Proxy, dst.Proxy,
                mask.Proxy, dtype));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(mask.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Calculates per-element difference between two arrays or array and a scalar
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
    /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
    /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is skipped]</param>
    /// <param name="dtype"></param>
    public static void Subtract(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, InputArrayRef mask = default,
        int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_subtract_InputArray2(
                src1.Proxy, src2.Proxy, dst.Proxy,
                mask.Proxy, dtype));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Calculates per-element difference between two arrays or array and a scalar
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
    /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
    /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is skipped]</param>
    /// <param name="dtype"></param>
    public static void Subtract(InputArrayRef src1, Scalar src2, OutputArrayRef dst, InputArrayRef mask = default,
        int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_subtract_InputArrayScalar(
                src1.Proxy, src2, dst.Proxy,
                mask.Proxy, dtype));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Calculates per-element difference between two arrays or array and a scalar
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
    /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
    /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is skipped]</param>
    /// <param name="dtype"></param>
    public static void Subtract(Scalar src1, InputArrayRef src2, OutputArrayRef dst, InputArrayRef mask = default,
        int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_subtract_ScalarInputArray(
                src1, src2.Proxy, dst.Proxy,
                mask.Proxy, dtype));

        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Calculates the per-element scaled product of two arrays
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="src2">The second source array of the same size and the same type as src1</param>
    /// <param name="dst">The destination array; will have the same size and the same type as src1</param>
    /// <param name="scale">The optional scale factor. [By default this is 1]</param>
    /// <param name="dtype"></param>
    public static void Multiply(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, double scale = 1, int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_multiply(
                src1.Proxy, src2.Proxy, dst.Proxy, scale, dtype));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Performs per-element division of two arrays or a scalar by an array.
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="src2">The second source array; should have the same size and same type as src1</param>
    /// <param name="dst">The destination array; will have the same size and same type as src2</param>
    /// <param name="scale">Scale factor [By default this is 1]</param>
    /// <param name="dtype"></param>
    public static void Divide(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, double scale = 1, MatType? dtype = null)
    {
        NativeMethods.HandleException(
            NativeMethods.core_divide2(
                src1.Proxy, src2.Proxy, dst.Proxy, scale, dtype?.Value ?? -1));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Performs per-element division of two arrays or a scalar by an array.
    /// </summary>
    /// <param name="scale">Scale factor</param>
    /// <param name="src2">The first source array</param>
    /// <param name="dst">The destination array; will have the same size and same type as src2</param>
    /// <param name="dtype"></param>
    public static void Divide(double scale, InputArrayRef src2, OutputArrayRef dst, int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_divide1(scale, src2.Proxy, dst.Proxy, dtype));

        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// adds scaled array to another one (dst = alpha*src1 + src2)
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="alpha"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    public static void ScaleAdd(InputArrayRef src1, double alpha, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_scaleAdd(src1.Proxy, alpha, src2.Proxy, dst.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// computes weighted sum of two arrays (dst = alpha*src1 + beta*src2 + gamma)
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="alpha"></param>
    /// <param name="src2"></param>
    /// <param name="beta"></param>
    /// <param name="gamma"></param>
    /// <param name="dst"></param>
    /// <param name="dtype"></param>
    public static void AddWeighted(InputArrayRef src1, double alpha, InputArrayRef src2,
        double beta, double gamma, OutputArrayRef dst, int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_addWeighted(
                src1.Proxy, alpha, src2.Proxy, beta, gamma, dst.Proxy, dtype));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Scales, computes absolute values and converts the result to 8-bit.
    /// </summary>
    /// <param name="src">The source array</param>
    /// <param name="dst">The destination array</param>
    /// <param name="alpha">The optional scale factor. [By default this is 1]</param>
    /// <param name="beta">The optional delta added to the scaled values. [By default this is 0]</param>
    public static void ConvertScaleAbs(InputArrayRef src, OutputArrayRef dst, double alpha = 1, double beta = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_convertScaleAbs(src.Proxy, dst.Proxy, alpha, beta));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// transforms array of numbers using a lookup table: dst(i)=lut(src(i))
    /// </summary>
    /// <param name="src">Source array of 8-bit elements</param>
    /// <param name="lut">Look-up table of 256 elements.
    /// In the case of multi-channel source array, the table should either have
    /// a single channel (in this case the same table is used for all channels)
    ///  or the same number of channels as in the source array</param>
    /// <param name="dst">Destination array;
    /// will have the same size and the same number of channels as src,
    /// and the same depth as lut</param>
    public static void LUT(InputArrayRef src, InputArrayRef lut, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_LUT(src.Proxy, lut.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(lut.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// transforms array of numbers using a lookup table: dst(i)=lut(src(i))
    /// </summary>
    /// <param name="src">Source array of 8-bit elements</param>
    /// <param name="lut">Look-up table of 256 elements.
    /// In the case of multi-channel source array, the table should either have
    /// a single channel (in this case the same table is used for all channels)
    /// or the same number of channels as in the source array</param>
    /// <param name="dst">Destination array;
    /// will have the same size and the same number of channels as src,
    /// and the same depth as lut</param>
    public static void LUT(InputArrayRef src, byte[] lut, OutputArrayRef dst)
    {
        if (lut is null)
            throw new ArgumentNullException(nameof(lut));
        if (lut.Length != 256)
            throw new ArgumentException("lut.Length != 256");

        using var lutMat = Mat.FromPixelData(256, 1, MatType.CV_8UC1, lut);
        LUT(src, lutMat, dst);
    }

    /// <summary>
    /// computes sum of array elements
    /// </summary>
    /// <param name="src">The source array; must have 1 to 4 channels</param>
    /// <returns></returns>
    public static Scalar Sum(InputArray src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_sum(src.ToInputProxy(), out var ret));

        GC.KeepAlive(src);
        return ret;
    }
        
    /// <summary>
    /// computes the number of nonzero array elements
    /// </summary>
    /// <param name="mtx">Single-channel array</param>
    /// <returns>number of non-zero elements in mtx</returns>
    public static int CountNonZero(InputArray mtx)
    {
        if (mtx is null)
            throw new ArgumentNullException(nameof(mtx));
        mtx.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_countNonZero(mtx.ToInputProxy(), out var ret));

        GC.KeepAlive(mtx);
        return ret;
    }

    /// <summary>
    /// returns the list of locations of non-zero pixels
    /// </summary>
    /// <param name="src"></param>
    /// <param name="idx"></param>
    public static void FindNonZero(InputArray src, OutputArray idx)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (idx is null)
            throw new ArgumentNullException(nameof(idx));
        src.ThrowIfDisposed();
        idx.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.core_findNonZero(src.ToInputProxy(), idx.ToOutputProxy()));

        GC.KeepAlive(src);
        GC.KeepAlive(idx);
        idx.Fix();
    }

    /// <summary>
    /// computes mean value of selected array elements
    /// </summary>
    /// <param name="src">The source array; it should have 1 to 4 channels
    ///  (so that the result can be stored in Scalar)</param>
    /// <param name="mask">The optional operation mask</param>
    /// <returns></returns>
    public static Scalar Mean(InputArray src, InputArray? mask = null)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_mean(src.ToInputProxy(), mask?.ToInputProxy() ?? default, out var ret));

        GC.KeepAlive(src);
        GC.KeepAlive(mask);
        return ret;
    }

    /// <summary>
    /// computes mean value and standard deviation of all or selected array elements
    /// </summary>
    /// <param name="src">The source array; it should have 1 to 4 channels 
    /// (so that the results can be stored in Scalar's)</param>
    /// <param name="mean">The output parameter: computed mean value</param>
    /// <param name="stddev">The output parameter: computed standard deviation</param>
    /// <param name="mask">The optional operation mask</param>
    public static void MeanStdDev(
        InputArrayRef src, OutputArrayRef mean, OutputArrayRef stddev, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_meanStdDev_OutputArray(
                src.Proxy, mean.Proxy, stddev.Proxy, mask.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(stddev.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// computes mean value and standard deviation of all or selected array elements
    /// </summary>
    /// <param name="src">The source array; it should have 1 to 4 channels
    /// (so that the results can be stored in Scalar's)</param>
    /// <param name="mean">The output parameter: computed mean value</param>
    /// <param name="stddev">The output parameter: computed standard deviation</param>
    /// <param name="mask">The optional operation mask</param>
    public static void MeanStdDev(
        InputArrayRef src, out Scalar mean, out Scalar stddev, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_meanStdDev_Scalar(
                src.Proxy, out mean, out stddev, mask.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Calculates absolute array norm, absolute difference norm, or relative difference norm.
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="normType">Type of the norm</param>
    /// <param name="mask">The optional operation mask</param>
    /// <returns></returns>
    public static double Norm(InputArrayRef src1,
        NormTypes normType = NormTypes.L2, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_norm1(src1.Proxy, (int)normType, mask.Proxy, out var ret));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(mask.Source);
        return ret;
    }

    /// <summary>
    /// computes norm of selected part of the difference between two arrays
    /// </summary>
    /// <param name="src1">The first source array</param>
    /// <param name="src2">The second source array of the same size and the same type as src1</param>
    /// <param name="normType">Type of the norm</param>
    /// <param name="mask">The optional operation mask</param>
    /// <returns></returns>
    public static double Norm(InputArrayRef src1, InputArrayRef src2,
        NormTypes normType = NormTypes.L2, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_norm2(src1.Proxy, src2.Proxy, (int)normType, mask.Proxy, out var ret));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(mask.Source);
        return ret;
    }

    /// <summary>
    /// Computes the Peak Signal-to-Noise Ratio (PSNR) image quality metric.
    ///
    /// This function calculates the Peak Signal-to-Noise Ratio(PSNR) image quality metric in decibels(dB),
    /// between two input arrays src1 and src2.The arrays must have the same type.
    /// </summary>
    /// <param name="src1">first input array.</param>
    /// <param name="src2">second input array of the same size as src1.</param>
    /// <param name="r">the maximum pixel value (255 by default)</param>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public static double PSNR(InputArrayRef src1, InputArrayRef src2, double r = 255.0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_PSNR(src1.Proxy, src2.Proxy, r, out var ret));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        return ret;
    }

    /// <summary>
    /// naive nearest neighbor finder
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dist"></param>
    /// <param name="dtype"></param>
    /// <param name="nidx"></param>
    /// <param name="normType"></param>
    /// <param name="k"></param>
    /// <param name="mask"></param>
    /// <param name="update"></param>
    /// <param name="crosscheck"></param>
    public static void BatchDistance(InputArrayRef src1, InputArrayRef src2,
        // ReSharper disable once IdentifierTypo
        OutputArrayRef dist, int dtype, OutputArrayRef nidx,
        NormTypes normType = NormTypes.L2,
        int k = 0, InputArrayRef mask = default,
        int update = 0, bool crosscheck = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_batchDistance(
                src1.Proxy, src2.Proxy, dist.Proxy, dtype, nidx.Proxy,
                (int) normType, k, mask.Proxy, update, crosscheck ? 1 : 0));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dist.Source);
        GC.KeepAlive(nidx.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// scales and shifts array elements so that either the specified norm (alpha)
    /// or the minimum (alpha) and maximum (beta) array values get the specified values
    /// </summary>
    /// <param name="src">The source array</param>
    /// <param name="dst">The destination array; will have the same size as src</param>
    /// <param name="alpha">The norm value to normalize to or the lower range boundary
    /// in the case of range normalization</param>
    /// <param name="beta">The upper range boundary in the case of range normalization;
    /// not used for norm normalization</param>
    /// <param name="normType">The normalization type</param>
    /// <param name="dtype">When the parameter is negative,
    /// the destination array will have the same type as src,
    /// otherwise it will have the same number of channels as src and the depth =CV_MAT_DEPTH(rtype)</param>
    /// <param name="mask">The optional operation mask</param>
    public static void Normalize(InputArrayRef src, InputOutputArrayRef dst, double alpha = 1, double beta = 0,
        NormTypes normType = NormTypes.L2, int dtype = -1, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_normalize(
                src.Proxy, dst.Proxy, alpha, beta, (int)normType, dtype, mask.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Finds indices of max elements along provided axis
    /// </summary>
    /// <param name="src">Input single-channel array</param>
    /// <param name="dst">Output array of type CV_32SC1 with the same dimensionality as src,
    /// except for axis being reduced - it should be set to 1.</param>
    /// <param name="axis">Axis to reduce along</param>
    /// <param name="lastIndex">Whether to get the index of first or last occurrence of max</param>
    public static void ReduceArgMax(InputArrayRef src, OutputArrayRef dst, int axis, bool lastIndex = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_reduceArgMax(src.Proxy, dst.Proxy, axis, lastIndex));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Finds indices of min elements along provided axis
    /// </summary>
    /// <param name="src">Input single-channel array</param>
    /// <param name="dst">Output array of type CV_32SC1 with the same dimensionality as src,
    /// except for axis being reduced - it should be set to 1.</param>
    /// <param name="axis">Axis to reduce along</param>
    /// <param name="lastIndex">Whether to get the index of first or last occurrence of min</param>
    public static void ReduceArgMin(InputArrayRef src, OutputArrayRef dst, int axis, bool lastIndex = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_reduceArgMin(src.Proxy, dst.Proxy, axis, lastIndex));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// finds global minimum and maximum array elements and returns their values and their locations
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="minVal">Pointer to returned minimum value</param>
    /// <param name="maxVal">Pointer to returned maximum value</param>
    public static void MinMaxLoc(InputArrayRef src, out double minVal, out double maxVal)
    {
        NativeMethods.HandleException(
            NativeMethods.core_minMaxLoc1(src.Proxy, out minVal, out maxVal));

        GC.KeepAlive(src.Source);
    }

    /// <summary>
    /// finds global minimum and maximum array elements and returns their values and their locations
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="minLoc">Pointer to returned minimum location</param>
    /// <param name="maxLoc">Pointer to returned maximum location</param>
    public static void MinMaxLoc(InputArrayRef src, out Point minLoc, out Point maxLoc)
    {
        MinMaxLoc(src, out _, out _, out minLoc, out maxLoc);
    }

    /// <summary>
    /// finds global minimum and maximum array elements and returns their values and their locations
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="minVal">Pointer to returned minimum value</param>
    /// <param name="maxVal">Pointer to returned maximum value</param>
    /// <param name="minLoc">Pointer to returned minimum location</param>
    /// <param name="maxLoc">Pointer to returned maximum location</param>
    /// <param name="mask">The optional mask used to select a sub-array</param>
    public static void MinMaxLoc(InputArrayRef src, out double minVal, out double maxVal,
        out Point minLoc, out Point maxLoc, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_minMaxLoc2(
                src.Proxy, out minVal, out maxVal, out minLoc, out maxLoc, mask.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// finds global minimum and maximum array elements and returns their values and their locations
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="minVal">Pointer to returned minimum value</param>
    /// <param name="maxVal">Pointer to returned maximum value</param>
    public static void MinMaxIdx(InputArrayRef src, out double minVal, out double maxVal)
    {
        NativeMethods.HandleException(
            NativeMethods.core_minMaxIdx1(src.Proxy, out minVal, out maxVal));

        GC.KeepAlive(src.Source);
    }

    /// <summary>
    /// finds global minimum and maximum array elements and returns their values and their locations
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="minIdx"></param>
    /// <param name="maxIdx"></param>
    public static void MinMaxIdx(InputArrayRef src, int[] minIdx, int[] maxIdx)
    {
        MinMaxIdx(src, out _, out _, minIdx, maxIdx);
    }

    /// <summary>
    /// finds global minimum and maximum array elements and returns their values and their locations
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="minVal">Pointer to returned minimum value</param>
    /// <param name="maxVal">Pointer to returned maximum value</param>
    /// <param name="minIdx"></param>
    /// <param name="maxIdx"></param>
    /// <param name="mask"></param>
    public static void MinMaxIdx(InputArrayRef src, out double minVal, out double maxVal,
        int[] minIdx, int[] maxIdx, InputArrayRef mask = default)
    {
        if (minIdx is null)
            throw new ArgumentNullException(nameof(minIdx));
        if (maxIdx is null)
            throw new ArgumentNullException(nameof(maxIdx));

        NativeMethods.HandleException(
            NativeMethods.core_minMaxIdx2(
                src.Proxy, out minVal, out maxVal, minIdx, maxIdx, mask.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// transforms 2D matrix to 1D row or column vector by taking sum, minimum, maximum or mean value over all the rows
    /// </summary>
    /// <param name="src">The source 2D matrix</param>
    /// <param name="dst">The destination vector.
    /// Its size and type is defined by dim and dtype parameters</param>
    /// <param name="dim">The dimension index along which the matrix is reduced.
    /// 0 means that the matrix is reduced to a single row and 1 means that the matrix is reduced to a single column</param>
    /// <param name="rtype"></param>
    /// <param name="dtype">When it is negative, the destination vector will have
    /// the same type as the source matrix, otherwise, its type will be CV_MAKE_TYPE(CV_MAT_DEPTH(dtype), mtx.channels())</param>
    public static void Reduce(InputArrayRef src, OutputArrayRef dst, ReduceDimension dim, ReduceTypes rtype, int dtype)
    {
        NativeMethods.HandleException(
            NativeMethods.core_reduce(src.Proxy, dst.Proxy, (int)dim, (int)rtype, dtype));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// makes multi-channel array out of several single-channel arrays
    /// </summary>
    /// <param name="mv"></param>
    /// <param name="dst"></param>
    public static void Merge(ReadOnlySpan<Mat> mv, Mat dst)
    {
        if (mv.Length == 0)
            throw new ArgumentException("mv is empty", nameof(mv));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));

        Span<IntPtr> handles = mv.Length <= MaxStackAllocHandles
            ? stackalloc IntPtr[mv.Length]
            : new IntPtr[mv.Length];
        for (var i = 0; i < mv.Length; i++)
        {
            var m = mv[i] ?? throw new ArgumentException("mv contains null element");
            m.ThrowIfDisposed();
            handles[i] = m.CvPtr;
        }

        dst.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_merge(handles, (uint)mv.Length, dst.CvPtr));

        foreach (var m in mv)
            GC.KeepAlive(m);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// Copies each plane of a multi-channel array to a dedicated array
    /// </summary>
    /// <param name="src">The source multi-channel array</param>
    /// <param name="mv">The destination array or vector of arrays; 
    /// The number of arrays must match mtx.channels() . 
    /// The arrays themselves will be reallocated if needed</param>
    public static void Split(Mat src, out Mat[] mv)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        using var vec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.core_split(src.CvPtr, vec.CvPtr));
        mv = vec.ToArray();

        GC.KeepAlive(src);
    }

    /// <summary>
    /// Copies each plane of a multi-channel array to a dedicated array
    /// </summary>
    /// <param name="src">The source multi-channel array</param>
    /// <returns>The number of arrays must match mtx.channels() . 
    /// The arrays themselves will be reallocated if needed</returns>
    public static Mat[] Split(Mat src)
    {
        Split(src, out var mv);
        return mv;
    }

    /// <summary>
    /// copies selected channels from the input arrays to the selected channels of the output arrays
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="fromTo"></param>
    public static void MixChannels(ReadOnlySpan<Mat> src, ReadOnlySpan<Mat> dst, int[] fromTo)
    {
        if (fromTo is null)
            throw new ArgumentNullException(nameof(fromTo));
        if (src.Length == 0)
            throw new ArgumentException("Length == 0", nameof(src));
        if (dst.Length == 0)
            throw new ArgumentException("Length == 0", nameof(dst));
        if (fromTo.Length == 0 || fromTo.Length % 2 != 0)
            throw new ArgumentException("Invalid length", nameof(fromTo));

        Span<IntPtr> srcPtr = src.Length <= MaxStackAllocHandles ? stackalloc IntPtr[src.Length] : new IntPtr[src.Length];
        Span<IntPtr> dstPtr = dst.Length <= MaxStackAllocHandles ? stackalloc IntPtr[dst.Length] : new IntPtr[dst.Length];
        for (var i = 0; i < src.Length; i++)
        {
            src[i].ThrowIfDisposed();
            srcPtr[i] = src[i].CvPtr;
        }

        for (var i = 0; i < dst.Length; i++)
        {
            dst[i].ThrowIfDisposed();
            dstPtr[i] = dst[i].CvPtr;
        }
        NativeMethods.HandleException(
            NativeMethods.core_mixChannels(
                srcPtr, (uint)src.Length, dstPtr, (uint)dst.Length,
                fromTo, (uint)(fromTo.Length / 2)));

        foreach (var m in src)
            GC.KeepAlive(m);
        foreach (var m in dst)
            GC.KeepAlive(m);
    }

    /// <summary>
    /// extracts a single channel from src (coi is 0-based index)
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="coi"></param>
    public static void ExtractChannel(InputArrayRef src, OutputArrayRef dst, int coi)
    {
        NativeMethods.HandleException(
            NativeMethods.core_extractChannel(src.Proxy, dst.Proxy, coi));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// inserts a single channel to dst (coi is 0-based index)
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="coi"></param>
    public static void InsertChannel(InputArrayRef src, InputOutputArrayRef dst, int coi)
    {
        NativeMethods.HandleException(
            NativeMethods.core_insertChannel(src.Proxy, dst.Proxy, coi));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// reverses the order of the rows, columns or both in a matrix
    /// </summary>
    /// <param name="src">The source array</param>
    /// <param name="dst">The destination array; will have the same size and same type as src</param>
    /// <param name="flipCode">Specifies how to flip the array:
    /// 0 means flipping around the x-axis, positive (e.g., 1) means flipping around y-axis,
    /// and negative (e.g., -1) means flipping around both axes. See also the discussion below for the formulas.</param>
    public static void Flip(InputArrayRef src, OutputArrayRef dst, FlipMode flipCode)
    {
        NativeMethods.HandleException(
            NativeMethods.core_flip(src.Proxy, dst.Proxy, (int) flipCode));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Rotates a 2D array in multiples of 90 degrees.
    /// </summary>
    /// <param name="src">input array.</param>
    /// <param name="dst">output array of the same type as src.
    /// The size is the same with ROTATE_180, and the rows and cols are switched for
    /// ROTATE_90_CLOCKWISE and ROTATE_90_COUNTERCLOCKWISE.</param>
    /// <param name="rotateCode">an enum to specify how to rotate the array.</param>
    public static void Rotate(InputArrayRef src, OutputArrayRef dst, RotateFlags rotateCode)
    {
        NativeMethods.HandleException(
            NativeMethods.core_rotate(src.Proxy, dst.Proxy, (int)rotateCode));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// replicates the input matrix the specified number of times in the horizontal and/or vertical direction
    /// </summary>
    /// <param name="src">The source array to replicate</param>
    /// <param name="ny">How many times the src is repeated along the vertical axis</param>
    /// <param name="nx">How many times the src is repeated along the horizontal axis</param>
    /// <param name="dst">The destination array; will have the same type as src</param>
    public static void Repeat(InputArrayRef src, int ny, int nx, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_repeat1(src.Proxy, ny, nx, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// replicates the input matrix the specified number of times in the horizontal and/or vertical direction
    /// </summary>
    /// <param name="src">The source array to replicate</param>
    /// <param name="ny">How many times the src is repeated along the vertical axis</param>
    /// <param name="nx">How many times the src is repeated along the horizontal axis</param>
    /// <returns></returns>
    public static Mat Repeat(Mat src, int ny, int nx)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_repeat2(src.CvPtr, ny, nx, out var matPtr));

        GC.KeepAlive(src);
        return new Mat(matPtr);
    }

    /// <summary>
    /// Applies horizontal concatenation to given matrices.
    /// </summary>
    /// <param name="src">input array or vector of matrices. all of the matrices must have the same number of rows and the same depth.</param>
    /// <param name="dst">output array. It has the same number of rows and depth as the src, and the sum of cols of the src.</param>
    public static void HConcat(ReadOnlySpan<Mat> src, OutputArrayRef dst)
    {
        if (src.Length == 0)
            throw new ArgumentException("src is empty", nameof(src));

        Span<IntPtr> srcPtr = src.Length <= MaxStackAllocHandles
            ? stackalloc IntPtr[src.Length]
            : new IntPtr[src.Length];
        for (var i = 0; i < src.Length; i++)
        {
            src[i].ThrowIfDisposed();
            srcPtr[i] = src[i].CvPtr;
        }

        NativeMethods.HandleException(
            NativeMethods.core_hconcat1(srcPtr, (uint) src.Length, dst.Proxy));

        foreach (var m in src)
            GC.KeepAlive(m);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Applies horizontal concatenation to given matrices.
    /// </summary>
    /// <param name="src1">first input array to be considered for horizontal concatenation.</param>
    /// <param name="src2">second input array to be considered for horizontal concatenation.</param>
    /// <param name="dst">output array. It has the same number of rows and depth as the src1 and src2, and the sum of cols of the src1 and src2.</param>
    public static void HConcat(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_hconcat2(src1.Proxy, src2.Proxy, dst.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Applies vertical concatenation to given matrices.
    /// </summary>
    /// <param name="src">input array or vector of matrices. all of the matrices must have the same number of cols and the same depth.</param>
    /// <param name="dst">output array. It has the same number of cols and depth as the src, and the sum of rows of the src.</param>
    public static void VConcat(ReadOnlySpan<Mat> src, OutputArrayRef dst)
    {
        if (src.Length == 0)
            throw new ArgumentException("src.Count == 0", nameof(src));

        Span<IntPtr> srcPtr = src.Length <= MaxStackAllocHandles
            ? stackalloc IntPtr[src.Length]
            : new IntPtr[src.Length];
        for (var i = 0; i < src.Length; i++)
        {
            src[i].ThrowIfDisposed();
            srcPtr[i] = src[i].CvPtr;
        }

        NativeMethods.HandleException(
            NativeMethods.core_vconcat1(srcPtr, (uint)src.Length, dst.Proxy));

        foreach (var m in src)
            GC.KeepAlive(m);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Applies vertical concatenation to given matrices.
    /// </summary>
    /// <param name="src1">first input array to be considered for vertical concatenation.</param>
    /// <param name="src2">second input array to be considered for vertical concatenation.</param>
    /// <param name="dst">output array. It has the same number of cols and depth as the src1 and src2, and the sum of rows of the src1 and src2.</param>
    public static void VConcat(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_vconcat2(src1.Proxy, src2.Proxy, dst.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// computes bitwise conjunction of the two arrays (dst = src1 &amp; src2)
    /// </summary>
    /// <param name="src1">first input array or a scalar.</param>
    /// <param name="src2">second input array or a scalar.</param>
    /// <param name="dst">output array that has the same size and type as the input</param>
    /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
    public static void BitwiseAnd(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_bitwise_and(src1.Proxy, src2.Proxy, dst.Proxy, mask.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// computes bitwise disjunction of the two arrays (dst = src1 | src2)
    /// </summary>
    /// <param name="src1">first input array or a scalar.</param>
    /// <param name="src2">second input array or a scalar.</param>
    /// <param name="dst">output array that has the same size and type as the input</param>
    /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
    public static void BitwiseOr(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_bitwise_or(src1.Proxy, src2.Proxy, dst.Proxy, mask.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// computes bitwise exclusive-or of the two arrays (dst = src1 ^ src2)
    /// </summary>
    /// <param name="src1">first input array or a scalar.</param>
    /// <param name="src2">second input array or a scalar.</param>
    /// <param name="dst">output array that has the same size and type as the input</param>
    /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
    public static void BitwiseXor(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_bitwise_xor(src1.Proxy, src2.Proxy, dst.Proxy, mask.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// inverts each bit of array (dst = ~src)
    /// </summary>
    /// <param name="src">input array.</param>
    /// <param name="dst">output array that has the same size and type as the input</param>
    /// <param name="mask">optional operation mask, 8-bit single channel array, that specifies elements of the output array to be changed.</param>
    public static void BitwiseNot(InputArrayRef src, OutputArrayRef dst, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_bitwise_not(src.Proxy, dst.Proxy, mask.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Calculates the per-element absolute difference between two arrays or between an array and a scalar.
    /// </summary>
    /// <param name="src1">first input array or a scalar.</param>
    /// <param name="src2">second input array or a scalar.</param>
    /// <param name="dst">output array that has the same size and type as input arrays.</param>
    public static void Absdiff(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_absdiff(src1.Proxy, src2.Proxy, dst.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Copies the matrix to another one.
    /// When the operation mask is specified, if the Mat::create call shown above reallocates the matrix, the newly allocated matrix is initialized with all zeros before copying the data.
    /// </summary>
    /// <param name="src">Source matrix.</param>
    /// <param name="dst">Destination matrix. If it does not have a proper size or type before the operation, it is reallocated.</param>
    /// <param name="mask">Operation mask of the same size as \*this. Its non-zero elements indicate which matrix
    /// elements need to be copied.The mask has to be of type CV_8U and can have 1 or multiple channels.</param>
    public static void CopyTo(InputArrayRef src, OutputArrayRef dst, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.core_copyTo(src.Proxy, dst.Proxy, mask.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Checks if array elements lie between the elements of two other arrays.
    /// </summary>
    /// <param name="src">first input array.</param>
    /// <param name="lowerb">inclusive lower boundary array or a scalar.</param>
    /// <param name="upperb">inclusive upper boundary array or a scalar.</param>
    /// <param name="dst">output array of the same size as src and CV_8U type.</param>
    public static void InRange(InputArrayRef src, InputArrayRef lowerb, InputArrayRef upperb, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_inRange_InputArray(src.Proxy, lowerb.Proxy, upperb.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(lowerb.Source);
        GC.KeepAlive(upperb.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Checks if array elements lie between the elements of two other arrays.
    /// </summary>
    /// <param name="src">first input array.</param>
    /// <param name="lowerb">inclusive lower boundary array or a scalar.</param>
    /// <param name="upperb">inclusive upper boundary array or a scalar.</param>
    /// <param name="dst">output array of the same size as src and CV_8U type.</param>
    public static void InRange(InputArrayRef src, Scalar lowerb, Scalar upperb, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_inRange_Scalar(src.Proxy, lowerb, upperb, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Performs the per-element comparison of two arrays or an array and scalar value.
    /// </summary>
    /// <param name="src1">first input array or a scalar; when it is an array, it must have a single channel.</param>
    /// <param name="src2">second input array or a scalar; when it is an array, it must have a single channel.</param>
    /// <param name="dst">output array of type ref CV_8U that has the same size and the same number of channels as the input arrays.</param>
    /// <param name="cmpop">a flag, that specifies correspondence between the arrays (cv::CmpTypes)</param>
    // ReSharper disable once IdentifierTypo
    public static void Compare(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst, CmpTypes cmpop)
    {
        NativeMethods.HandleException(
            NativeMethods.core_compare(src1.Proxy, src2.Proxy, dst.Proxy, (int) cmpop));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// computes per-element minimum of two arrays (dst = min(src1, src2))
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    public static void Min(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_min1(src1.Proxy, src2.Proxy, dst.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// computes per-element minimum of two arrays (dst = min(src1, src2))
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    public static void Min(Mat src1, Mat src2, Mat dst)
    {
        if (src1 is null)
            throw new ArgumentNullException(nameof(src1));
        if (src2 is null)
            throw new ArgumentNullException(nameof(src2));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src1.ThrowIfDisposed();
        src2.ThrowIfDisposed();
        dst.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_min_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr));

        GC.KeepAlive(src1);
        GC.KeepAlive(src2);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// computes per-element minimum of array and scalar (dst = min(src1, src2))
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    public static void Min(Mat src1, double src2, Mat dst)
    {
        if (src1 is null)
            throw new ArgumentNullException(nameof(src1));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src1.ThrowIfDisposed();
        dst.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_min_MatDouble(src1.CvPtr, src2, dst.CvPtr));

        GC.KeepAlive(src1);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// computes per-element maximum of two arrays (dst = max(src1, src2))
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    public static void Max(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_max1(src1.Proxy, src2.Proxy, dst.Proxy));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// computes per-element maximum of two arrays (dst = max(src1, src2))
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    public static void Max(Mat src1, Mat src2, Mat dst)
    {
        if (src1 is null)
            throw new ArgumentNullException(nameof(src1));
        if (src2 is null)
            throw new ArgumentNullException(nameof(src2));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src1.ThrowIfDisposed();
        src2.ThrowIfDisposed();
        dst.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_max_MatMat(src1.CvPtr, src2.CvPtr, dst.CvPtr));

        GC.KeepAlive(src1);
        GC.KeepAlive(src2);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// computes per-element maximum of array and scalar (dst = max(src1, src2))
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    public static void Max(Mat src1, double src2, Mat dst)
    {
        if (src1 is null)
            throw new ArgumentNullException(nameof(src1));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src1.ThrowIfDisposed();
        dst.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_max_MatDouble(src1.CvPtr, src2, dst.CvPtr));

        GC.KeepAlive(src1);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// computes square root of each matrix element (dst = src**0.5)
    /// </summary>
    /// <param name="src">The source floating-point array</param>
    /// <param name="dst">The destination array; will have the same size and the same type as src</param>
    public static void Sqrt(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.core_sqrt(src.ToInputProxy(), dst.ToOutputProxy()));

        GC.KeepAlive(src);
        GC.KeepAlive(dst);
        dst.Fix();
    }

    /// <summary>
    /// raises the input matrix elements to the specified power (b = a**power)
    /// </summary>
    /// <param name="src">The source array</param>
    /// <param name="power">The exponent of power</param>
    /// <param name="dst">The destination array; will have the same size and the same type as src</param>
    public static void Pow(InputArrayRef src, double power, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_pow_Mat(src.Proxy, power, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// computes exponent of each matrix element (dst = e**src)
    /// </summary>
    /// <param name="src">The source array</param>
    /// <param name="dst">The destination array; will have the same size and same type as src</param>
    public static void Exp(InputArrayRef src, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_exp_Mat(src.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// computes natural logarithm of absolute value of each matrix element: dst = log(abs(src))
    /// </summary>
    /// <param name="src">The source array</param>
    /// <param name="dst">The destination array; will have the same size and same type as src</param>
    public static void Log(InputArrayRef src, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_log_Mat(src.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Calculates x and y coordinates of 2D vectors from their magnitude and angle.
    /// </summary>
    /// <param name="magnitude">input floating-point array of magnitudes of 2D vectors;
    /// it can be an empty matrix(=Mat()), in this case, the function assumes that all the magnitudes are = 1; if it is not empty,
    /// it must have the same size and type as angle.</param>
    /// <param name="angle">input floating-point array of angles of 2D vectors.</param>
    /// <param name="x">output array of x-coordinates of 2D vectors; it has the same size and type as angle.</param>
    /// <param name="y">output array of y-coordinates of 2D vectors; it has the same size and type as angle.</param>
    /// <param name="angleInDegrees">when true, the input angles are measured in degrees, otherwise, they are measured in radians.</param>
    public static void PolarToCart(InputArrayRef magnitude, InputArrayRef angle,
        OutputArrayRef x, OutputArrayRef y, bool angleInDegrees = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_polarToCart(magnitude.Proxy, angle.Proxy, x.Proxy, y.Proxy, angleInDegrees ? 1 : 0));

        GC.KeepAlive(magnitude.Source);
        GC.KeepAlive(angle.Source);
        GC.KeepAlive(x.Source);
        GC.KeepAlive(y.Source);
    }

    /// <summary>
    /// Calculates the magnitude and angle of 2D vectors.
    /// </summary>
    /// <param name="x">array of x-coordinates; this must be a single-precision or double-precision floating-point array.</param>
    /// <param name="y">array of y-coordinates, that must have the same size and same type as x.</param>
    /// <param name="magnitude">output array of magnitudes of the same size and type as x.</param>
    /// <param name="angle">output array of angles that has the same size and type as x;
    /// the angles are measured in radians(from 0 to 2\*Pi) or in degrees(0 to 360 degrees).</param>
    /// <param name="angleInDegrees">a flag, indicating whether the angles are measured in radians(which is by default), or in degrees.</param>
    public static void CartToPolar(InputArrayRef x, InputArrayRef y,
        OutputArrayRef magnitude, OutputArrayRef angle, bool angleInDegrees = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_cartToPolar(x.Proxy, y.Proxy, magnitude.Proxy, angle.Proxy, angleInDegrees ? 1 : 0));

        GC.KeepAlive(x.Source);
        GC.KeepAlive(y.Source);
        GC.KeepAlive(magnitude.Source);
        GC.KeepAlive(angle.Source);
    }

    /// <summary>
    /// Calculates the rotation angle of 2D vectors.
    /// </summary>
    /// <param name="x">input floating-point array of x-coordinates of 2D vectors.</param>
    /// <param name="y">input array of y-coordinates of 2D vectors; it must have the same size and the same type as x.</param>
    /// <param name="angle">output array of vector angles; it has the same size and same type as x.</param>
    /// <param name="angleInDegrees">when true, the function calculates the angle in degrees, otherwise, they are measured in radians.</param>
    public static void Phase(InputArrayRef x, InputArrayRef y, OutputArrayRef angle, bool angleInDegrees = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_phase(x.Proxy, y.Proxy, angle.Proxy, angleInDegrees ? 1 : 0));

        GC.KeepAlive(x.Source);
        GC.KeepAlive(y.Source);
        GC.KeepAlive(angle.Source);
    }

    /// <summary>
    /// Calculates the magnitude of 2D vectors.
    /// </summary>
    /// <param name="x">floating-point array of x-coordinates of the vectors.</param>
    /// <param name="y">floating-point array of y-coordinates of the vectors; it must have the same size as x.</param>
    /// <param name="magnitude">output array of the same size and type as x.</param>
    public static void Magnitude(InputArrayRef x, InputArrayRef y, OutputArrayRef magnitude)
    {
        NativeMethods.HandleException(
            NativeMethods.core_magnitude_Mat(x.Proxy, y.Proxy, magnitude.Proxy));

        GC.KeepAlive(x.Source);
        GC.KeepAlive(y.Source);
        GC.KeepAlive(magnitude.Source);
    }

    /// <summary>
    /// checks that each matrix element is within the specified range.
    /// </summary>
    /// <param name="src">The array to check</param>
    /// <param name="quiet">The flag indicating whether the functions quietly
    /// return false when the array elements are out of range,
    /// or they throw an exception.</param>
    /// <returns></returns>
    public static bool CheckRange(InputArrayRef src, bool quiet = true)
    {
        return CheckRange(src, quiet, out _);
    }

    /// <summary>
    /// checks that each matrix element is within the specified range.
    /// </summary>
    /// <param name="src">The array to check</param>
    /// <param name="quiet">The flag indicating whether the functions quietly
    /// return false when the array elements are out of range,
    /// or they throw an exception.</param>
    /// <param name="pos">The optional output parameter, where the position of
    /// the first outlier is stored.</param>
    /// <param name="minVal">The inclusive lower boundary of valid values range</param>
    /// <param name="maxVal">The exclusive upper boundary of valid values range</param>
    /// <returns></returns>
    public static bool CheckRange(InputArrayRef src, bool quiet, out Point pos,
        double minVal = double.MinValue, double maxVal = double.MaxValue)
    {
        NativeMethods.HandleException(
            NativeMethods.core_checkRange(src.Proxy, quiet ? 1 : 0, out pos, minVal, maxVal, out var ret));
        GC.KeepAlive(src.Source);
        return ret != 0;
    }

    /// <summary>
    /// converts NaN's to the given number
    /// </summary>
    /// <param name="a"></param>
    /// <param name="val"></param>
    public static void PatchNaNs(InputOutputArrayRef a, double val = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_patchNaNs(a.Proxy, val));

        GC.KeepAlive(a.Source);
    }

    /// <summary>
    /// implements generalized matrix product algorithm GEMM from BLAS
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="alpha"></param>
    /// <param name="src3"></param>
    /// <param name="gamma"></param>
    /// <param name="dst"></param>
    /// <param name="flags"></param>
    // ReSharper disable once IdentifierTypo
    public static void Gemm(InputArrayRef src1, InputArrayRef src2, double alpha,
        InputArrayRef src3, double gamma, OutputArrayRef dst, GemmFlags flags = GemmFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_gemm(src1.Proxy, src2.Proxy, alpha, src3.Proxy, gamma, dst.Proxy, (int) flags));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(src3.Source);
        GC.KeepAlive(dst.Source);
    }
        
    /// <summary>
    /// multiplies matrix by its transposition from the left or from the right
    /// </summary>
    /// <param name="src">The source matrix</param>
    /// <param name="dst">The destination square matrix</param>
    /// <param name="aTa">Specifies the multiplication ordering; see the description below</param>
    /// <param name="delta">The optional delta matrix, subtracted from src before the 
    /// multiplication. When the matrix is empty ( delta=Mat() ), it’s assumed to be 
    /// zero, i.e. nothing is subtracted, otherwise if it has the same size as src, 
    /// then it’s simply subtracted, otherwise it is "repeated" to cover the full src 
    /// and then subtracted. Type of the delta matrix, when it's not empty, must be the 
    /// same as the type of created destination matrix, see the rtype description</param>
    /// <param name="scale">The optional scale factor for the matrix product</param>
    /// <param name="dtype">When it’s negative, the destination matrix will have the 
    /// same type as src . Otherwise, it will have type=CV_MAT_DEPTH(rtype), 
    /// which should be either CV_32F or CV_64F</param>
    public static void MulTransposed(InputArrayRef src, OutputArrayRef dst, bool aTa,
        InputArrayRef delta = default, double scale = 1, int dtype = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.core_mulTransposed(src.Proxy, dst.Proxy, aTa ? 1 : 0, delta.Proxy, scale, dtype));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(delta.Source);
    }
        
    /// <summary>
    /// transposes the matrix
    /// </summary>
    /// <param name="src">The source array</param>
    /// <param name="dst">The destination array of the same type as src</param>
    public static void Transpose(InputArrayRef src, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_transpose(src.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }
        
    /// <summary>
    /// performs affine transformation of each element of multi-channel input matrix
    /// </summary>
    /// <param name="src">The source array; must have as many channels (1 to 4) as mtx.cols or mtx.cols-1</param>
    /// <param name="dst">The destination array; will have the same size and depth as src and as many channels as mtx.rows</param>
    /// <param name="m">The transformation matrix</param>
    public static void Transform(InputArrayRef src, OutputArrayRef dst, InputArrayRef m)
    {
        NativeMethods.HandleException(
            NativeMethods.core_transform(src.Proxy, dst.Proxy, m.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(m.Source);
    }

    /// <summary>
    /// performs perspective transformation of each element of multi-channel input matrix
    /// </summary>
    /// <param name="src">The source two-channel or three-channel floating-point array;
    /// each element is 2D/3D vector to be transformed</param>
    /// <param name="dst">The destination array; it will have the same size and same type as src</param>
    /// <param name="m">3x3 or 4x4 transformation matrix</param>
    public static void PerspectiveTransform(InputArrayRef src, OutputArrayRef dst, InputArrayRef m)
    {
        NativeMethods.HandleException(
            NativeMethods.core_perspectiveTransform(src.Proxy, dst.Proxy, m.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        GC.KeepAlive(m.Source);
    }

    /// <summary>
    /// performs perspective transformation of each element of multi-channel input matrix
    /// </summary>
    /// <param name="src">The source two-channel or three-channel floating-point array; 
    /// each element is 2D/3D vector to be transformed</param>
    /// <param name="m">3x3 or 4x4 transformation matrix</param>
    /// <returns>The destination array; it will have the same size and same type as src</returns>
    public static Point2f[] PerspectiveTransform(IEnumerable<Point2f> src, Mat m)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        using var srcMat = Mat.FromArray(src);
        using var dstMat = new Mat<Point2f>();

        NativeMethods.HandleException(
            NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

        GC.KeepAlive(m);
        return dstMat.ToArray();
    }

    /// <summary>
    /// performs perspective transformation of each element of multi-channel input matrix
    /// </summary>
    /// <param name="src">The source two-channel or three-channel floating-point array; 
    /// each element is 2D/3D vector to be transformed</param>
    /// <param name="m">3x3 or 4x4 transformation matrix</param>
    /// <returns>The destination array; it will have the same size and same type as src</returns>
    public static Point2d[] PerspectiveTransform(IEnumerable<Point2d> src, Mat m)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        using var srcMat = Mat.FromArray(src);
        using var dstMat = new Mat<Point2d>();

        NativeMethods.HandleException(
            NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

        GC.KeepAlive(m);
        return dstMat.ToArray();
    }

    /// <summary>
    /// performs perspective transformation of each element of multi-channel input matrix
    /// </summary>
    /// <param name="src">The source two-channel or three-channel floating-point array; 
    /// each element is 2D/3D vector to be transformed</param>
    /// <param name="m">3x3 or 4x4 transformation matrix</param>
    /// <returns>The destination array; it will have the same size and same type as src</returns>
    public static Point3f[] PerspectiveTransform(IEnumerable<Point3f> src, Mat m)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        using var srcMat = Mat.FromArray(src);
        using var dstMat = new Mat<Point3f>();

        NativeMethods.HandleException(
            NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

        GC.KeepAlive(m);
        return dstMat.ToArray();
    }

    /// <summary>
    /// performs perspective transformation of each element of multi-channel input matrix
    /// </summary>
    /// <param name="src">The source two-channel or three-channel floating-point array; 
    /// each element is 2D/3D vector to be transformed</param>
    /// <param name="m">3x3 or 4x4 transformation matrix</param>
    /// <returns>The destination array; it will have the same size and same type as src</returns>
    public static Point3d[] PerspectiveTransform(IEnumerable<Point3d> src, Mat m)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (m is null)
            throw new ArgumentNullException(nameof(m));

        using var srcMat = Mat.FromArray(src);
        using var dstMat = new Mat<Point3d>();

        NativeMethods.HandleException(
            NativeMethods.core_perspectiveTransform_Mat(srcMat.CvPtr, dstMat.CvPtr, m.CvPtr));

        GC.KeepAlive(m);
        return dstMat.ToArray();
    }
        
    /// <summary>
    /// extends the symmetrical matrix from the lower half or from the upper half
    /// </summary>
    /// <param name="mtx"> Input-output floating-point square matrix</param>
    /// <param name="lowerToUpper">If true, the lower half is copied to the upper half, 
    /// otherwise the upper half is copied to the lower half</param>
    // ReSharper disable once IdentifierTypo
    public static void CompleteSymm(InputOutputArrayRef mtx, bool lowerToUpper = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_completeSymm(mtx.Proxy, lowerToUpper ? 1 : 0));

        GC.KeepAlive(mtx.Source);
    }

    /// <summary>
    /// initializes scaled identity matrix
    /// </summary>
    /// <param name="mtx">The matrix to initialize (not necessarily square)</param>
    /// <param name="s">The value to assign to the diagonal elements</param>
    public static void SetIdentity(InputOutputArrayRef mtx, Scalar? s = null)
    {
        var s0 = s.GetValueOrDefault(new Scalar(1));
        NativeMethods.HandleException(
            NativeMethods.core_setIdentity(mtx.Proxy, s0));

        GC.KeepAlive(mtx.Source);
    }

    /// <summary>
    /// computes determinant of a square matrix
    /// </summary>
    /// <param name="mtx">The input matrix; must have CV_32FC1 or CV_64FC1 type and square size</param>
    /// <returns>determinant of the specified matrix.</returns>
    public static double Determinant(InputArrayRef mtx)
    {
        NativeMethods.HandleException(
            NativeMethods.core_determinant(mtx.Proxy, out var ret));

        GC.KeepAlive(mtx.Source);
        return ret;
    }

    /// <summary>
    /// computes trace of a matrix
    /// </summary>
    /// <param name="mtx">The source matrix</param>
    /// <returns></returns>
    public static Scalar Trace(InputArrayRef mtx)
    {
        NativeMethods.HandleException(
            NativeMethods.core_trace(mtx.Proxy, out var ret));

        GC.KeepAlive(mtx.Source);
        return ret;
    }

    /// <summary>
    /// computes inverse or pseudo-inverse matrix
    /// </summary>
    /// <param name="src">The source floating-point MxN matrix</param>
    /// <param name="dst">The destination matrix; will have NxM size and the same type as src</param>
    /// <param name="flags">The inversion method</param>
    /// <returns></returns>
    public static double Invert(InputArrayRef src, OutputArrayRef dst,
        DecompTypes flags = DecompTypes.LU)
    {
        NativeMethods.HandleException(
            NativeMethods.core_invert(src.Proxy, dst.Proxy, (int) flags, out var ret));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
        return ret;
    }

    /// <summary>
    /// solves linear system or a least-square problem
    /// </summary>
    /// <param name="src1"></param>
    /// <param name="src2"></param>
    /// <param name="dst"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public static bool Solve(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst,
        DecompTypes flags = DecompTypes.LU)
    {
        NativeMethods.HandleException(
            NativeMethods.core_solve(src1.Proxy, src2.Proxy, dst.Proxy, (int) flags, out var ret));

        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
        return ret != 0;
    }

    /// <summary>
    /// Solve given (non-integer) linear programming problem using the Simplex Algorithm (Simplex Method).
    /// </summary>
    /// <param name="func">This row-vector corresponds to \f$c\f$ in the LP problem formulation (see above).
    /// It should contain 32- or 64-bit floating point numbers.As a convenience, column-vector may be also submitted,
    /// in the latter case it is understood to correspond to \f$c^T\f$.</param>
    /// <param name="constr">`m`-by-`n+1` matrix, whose rightmost column corresponds to \f$b\f$ in formulation above
    /// and the remaining to \f$A\f$. It should containt 32- or 64-bit floating point numbers.</param>
    /// <param name="z">The solution will be returned here as a column-vector - it corresponds to \f$c\f$ in the
    /// formulation above.It will contain 64-bit floating point numbers.</param>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public static SolveLPResult SolveLP(InputArrayRef func, InputArrayRef constr, OutputArrayRef z)
    {
        NativeMethods.HandleException(
            NativeMethods.core_solveLP(func.Proxy, constr.Proxy, z.Proxy, out var ret));

        GC.KeepAlive(func.Source);
        GC.KeepAlive(constr.Source);
        GC.KeepAlive(z.Source);
        return (SolveLPResult) ret;
    }

    /// <summary>
    /// sorts independently each matrix row or each matrix column
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="dst">The destination array of the same size and the same type as src</param>
    /// <param name="flags">The operation flags, a combination of the SortFlag values</param>
    public static void Sort(InputArrayRef src, OutputArrayRef dst, SortFlags flags)
    {
        NativeMethods.HandleException(
            NativeMethods.core_sort(src.Proxy, dst.Proxy, (int) flags));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// sorts independently each matrix row or each matrix column
    /// </summary>
    /// <param name="src">The source single-channel array</param>
    /// <param name="dst">The destination integer array of the same size as src</param>
    /// <param name="flags">The operation flags, a combination of SortFlag values</param>
    public static void SortIdx(InputArrayRef src, OutputArrayRef dst, SortFlags flags)
    {
        NativeMethods.HandleException(
            NativeMethods.core_sortIdx(src.Proxy, dst.Proxy, (int) flags));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }
        
    /// <summary>
    /// finds real roots of a cubic polynomial
    /// </summary>
    /// <param name="coeffs">The equation coefficients, an array of 3 or 4 elements</param>
    /// <param name="roots">The destination array of real roots which will have 1 or 3 elements</param>
    /// <returns></returns>
    public static int SolveCubic(InputArrayRef coeffs, OutputArrayRef roots)
    {
        NativeMethods.HandleException(
            NativeMethods.core_solveCubic(coeffs.Proxy, roots.Proxy, out var ret));

        GC.KeepAlive(coeffs.Source);
        GC.KeepAlive(roots.Source);
        return ret;
    }

    /// <summary>
    /// finds real and complex roots of a polynomial
    /// </summary>
    /// <param name="coeffs">The array of polynomial coefficients</param>
    /// <param name="roots">The destination (complex) array of roots</param>
    /// <param name="maxIters">The maximum number of iterations the algorithm does</param>
    /// <returns></returns>
    public static double SolvePoly(InputArrayRef coeffs, OutputArrayRef roots, int maxIters = 300)
    {
        NativeMethods.HandleException(
            NativeMethods.core_solvePoly(coeffs.Proxy, roots.Proxy, maxIters, out var ret));

        GC.KeepAlive(coeffs.Source);
        GC.KeepAlive(roots.Source);
        return ret;
    }

    /// <summary>
    /// Computes eigenvalues and eigenvectors of a symmetric matrix.
    /// </summary>
    /// <param name="src">The input matrix; must have CV_32FC1 or CV_64FC1 type,
    /// square size and be symmetric: src^T == src</param>
    /// <param name="eigenvalues">The output vector of eigenvalues of the same type as src;
    /// The eigenvalues are stored in the descending order.</param>
    /// <param name="eigenvectors">The output matrix of eigenvectors;
    /// It will have the same size and the same type as src; The eigenvectors are stored
    /// as subsequent matrix rows, in the same order as the corresponding eigenvalues</param>
    /// <returns></returns>
    public static bool Eigen(InputArrayRef src, OutputArrayRef eigenvalues, OutputArrayRef eigenvectors)
    {
        NativeMethods.HandleException(
            NativeMethods.core_eigen(src.Proxy, eigenvalues.Proxy, eigenvectors.Proxy, out var ret));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(eigenvalues.Source);
        GC.KeepAlive(eigenvectors.Source);
        return ret != 0;
    }

    /// <summary>
    /// Calculates eigenvalues and eigenvectors of a non-symmetric matrix (real eigenvalues only).
    /// </summary>
    /// <param name="src">input matrix (CV_32FC1 or CV_64FC1 type).</param>
    /// <param name="eigenvalues">output vector of eigenvalues (type is the same type as src).</param>
    /// <param name="eigenvectors">output matrix of eigenvectors (type is the same type as src). The eigenvectors are stored as subsequent matrix rows, in the same order as the corresponding eigenvalues.</param>
    public static void EigenNonSymmetric(InputArrayRef src, OutputArrayRef eigenvalues, OutputArrayRef eigenvectors)
    {
        NativeMethods.HandleException(
            NativeMethods.core_eigenNonSymmetric(src.Proxy, eigenvalues.Proxy, eigenvectors.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(eigenvalues.Source);
        GC.KeepAlive(eigenvectors.Source);
    }

    /// <summary>
    /// computes covariation matrix of a set of samples
    /// </summary>
    /// <param name="samples">samples stored as separate matrices</param>
    /// <param name="covar">output covariance matrix of the type ctype and square size.</param>
    /// <param name="mean">input or output (depending on the flags) array as the average value of the input vectors.</param>
    /// <param name="flags">operation flags - see CovarFlags.</param>
    /// <param name="ctype">type of the matrixl; it equals 'CV_64F' by default.</param>
    public static void CalcCovarMatrix(
        ReadOnlySpan<Mat> samples, Mat covar, Mat mean,
        CovarFlags flags, MatType? ctype = null)
    {
        if (covar is null)
            throw new ArgumentNullException(nameof(covar));
        if (mean is null)
            throw new ArgumentNullException(nameof(mean));
        covar.ThrowIfDisposed();
        mean.ThrowIfDisposed();

        Span<IntPtr> samplesPtr = samples.Length <= MaxStackAllocHandles
            ? stackalloc IntPtr[samples.Length]
            : new IntPtr[samples.Length];
        for (var i = 0; i < samples.Length; i++)
            samplesPtr[i] = samples[i].CvPtr;

        var ctypeValue = ctype.GetValueOrDefault(MatType.CV_64F);
        NativeMethods.HandleException(
            NativeMethods.core_calcCovarMatrix_Mat(samplesPtr, samples.Length, covar.CvPtr, mean.CvPtr, (int) flags, ctypeValue.Value));

        foreach (var m in samples)
            GC.KeepAlive(m);
        GC.KeepAlive(covar);
        GC.KeepAlive(mean);
    }

    /// <summary>
    /// computes covariation matrix of a set of samples
    /// </summary>
    /// <param name="samples">samples stored as rows/columns of a single matrix.</param>
    /// <param name="covar">output covariance matrix of the type ctype and square size.</param>
    /// <param name="mean">input or output (depending on the flags) array as the average value of the input vectors.</param>
    /// <param name="flags">operation flags - see CovarFlags.</param>
    /// <param name="ctype">type of the matrixl; it equals 'CV_64F' by default.</param>
    public static void CalcCovarMatrix(
        InputArrayRef samples, OutputArrayRef covar,
        InputOutputArrayRef mean, CovarFlags flags, MatType? ctype = null)
    {
        var ctypeValue = ctype.GetValueOrDefault(MatType.CV_64F);
        NativeMethods.HandleException(
            NativeMethods.core_calcCovarMatrix_InputArray(samples.Proxy, covar.Proxy, mean.Proxy, (int) flags, ctypeValue.Value));

        GC.KeepAlive(samples.Source);
        GC.KeepAlive(covar.Source);
        GC.KeepAlive(mean.Source);
    }

    /// <summary>
    /// PCA of the supplied dataset.
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
    /// <param name="maxComponents">Number of components that PCA should
    /// retain; by default, all the components are retained.</param>
    public static void PCACompute(
        InputArrayRef data, InputOutputArrayRef mean,
        OutputArrayRef eigenvectors, int maxComponents = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_PCACompute(data.Proxy, mean.Proxy, eigenvectors.Proxy, maxComponents));

        GC.KeepAlive(data.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(eigenvectors.Source);
    }

    /// <summary>
    /// PCA of the supplied dataset.
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
    /// <param name="eigenvalues">eigenvalues of the covariation matrix</param>
    /// <param name="maxComponents">Number of components that PCA should
    /// retain; by default, all the components are retained.</param>
    public static void PCACompute(
        InputArrayRef data, InputOutputArrayRef mean,
        OutputArrayRef eigenvectors, OutputArrayRef eigenvalues, int maxComponents = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_PCACompute2(data.Proxy, mean.Proxy, eigenvectors.Proxy, eigenvalues.Proxy, maxComponents));

        GC.KeepAlive(data.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(eigenvectors.Source);
        GC.KeepAlive(eigenvalues.Source);
    }

    /// <summary>
    /// PCA of the supplied dataset.
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
    /// <param name="retainedVariance">Percentage of variance that PCA should retain.
    /// Using this parameter will let the PCA decided how many components to retain but it will always keep at least 2.</param>
    public static void PCAComputeVar(
        InputArrayRef data, InputOutputArrayRef mean,
        OutputArrayRef eigenvectors, double retainedVariance)
    {
        NativeMethods.HandleException(
            NativeMethods.core_PCAComputeVar(data.Proxy, mean.Proxy, eigenvectors.Proxy, retainedVariance));

        GC.KeepAlive(data.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(eigenvectors.Source);
    }

    /// <summary>
    /// PCA of the supplied dataset. 
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
    /// <param name="eigenvalues">eigenvalues of the covariation matrix</param>
    /// <param name="retainedVariance">Percentage of variance that PCA should retain.
    /// Using this parameter will let the PCA decided how many components to retain but it will always keep at least 2.</param>
    public static void PCAComputeVar(
        InputArray data, InputOutputArray mean,
        OutputArray eigenvectors, OutputArray eigenvalues, double retainedVariance)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        if (mean is null)
            throw new ArgumentNullException(nameof(mean));
        if (eigenvectors is null)
            throw new ArgumentNullException(nameof(eigenvectors));
        if (eigenvalues is null)
            throw new ArgumentNullException(nameof(eigenvalues));
        data.ThrowIfDisposed();
        mean.ThrowIfNotReady();
        eigenvectors.ThrowIfNotReady();
        eigenvalues.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.core_PCAComputeVar2(data.ToInputProxy(), mean.ToInputOutputProxy(), eigenvectors.ToOutputProxy(), eigenvalues.ToOutputProxy(), retainedVariance));

        GC.KeepAlive(data);
        mean.Fix();
        eigenvectors.Fix();
        eigenvalues.Fix();
    }

    /// <summary>
    /// Projects vector(s) to the principal component subspace.
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
    /// <param name="result">output vectors</param>
    public static void PCAProject(InputArrayRef data, InputArrayRef mean,
        InputArrayRef eigenvectors, OutputArrayRef result)
    {
        NativeMethods.HandleException(
            NativeMethods.core_PCAProject(data.Proxy, mean.Proxy, eigenvectors.Proxy, result.Proxy));

        GC.KeepAlive(data.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(eigenvectors.Source);
        GC.KeepAlive(result.Source);
    }

    /// <summary>
    /// Reconstructs vectors from their PC projections.
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="eigenvectors">eigenvectors of the covariation matrix</param>
    /// <param name="result">output vectors</param>
    public static void PCABackProject(InputArrayRef data, InputArrayRef mean,
        InputArrayRef eigenvectors, OutputArrayRef result)
    {
        NativeMethods.HandleException(
            NativeMethods.core_PCABackProject(data.Proxy, mean.Proxy, eigenvectors.Proxy, result.Proxy));

        GC.KeepAlive(data.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(eigenvectors.Source);
        GC.KeepAlive(result.Source);
    }

    /// <summary>
    /// decomposes matrix and stores the results to user-provided matrices
    /// </summary>
    /// <param name="src">decomposed matrix. The depth has to be CV_32F or CV_64F.</param>
    /// <param name="w">calculated singular values</param>
    /// <param name="u">calculated left singular vectors</param>
    /// <param name="vt">transposed matrix of right singular vectors</param>
    /// <param name="flags">peration flags - see SVD::Flags.</param>
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public static void SVDecomp(
        InputArrayRef src, OutputArrayRef w,
        OutputArrayRef u, OutputArrayRef vt, SVD.Flags flags = SVD.Flags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVDecomp(src.Proxy, w.Proxy, u.Proxy, vt.Proxy, (int) flags));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(w.Source);
        GC.KeepAlive(u.Source);
        GC.KeepAlive(vt.Source);
    }

    /// <summary>
    /// performs back substitution for the previously computed SVD
    /// </summary>
    /// <param name="w">calculated singular values</param>
    /// <param name="u">calculated left singular vectors</param>
    /// <param name="vt">transposed matrix of right singular vectors</param>
    /// <param name="rhs">right-hand side of a linear system (u*w*v')*dst = rhs to be solved, where A has been previously decomposed.</param>
    /// <param name="dst">output</param>
    // ReSharper disable once InconsistentNaming
    public static void SVBackSubst(
        InputArrayRef w, InputArrayRef u, InputArrayRef vt,
        InputArrayRef rhs, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVBackSubst(w.Proxy, u.Proxy, vt.Proxy, rhs.Proxy, dst.Proxy));

        GC.KeepAlive(w.Source);
        GC.KeepAlive(u.Source);
        GC.KeepAlive(vt.Source);
        GC.KeepAlive(rhs.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Calculates the Mahalanobis distance between two vectors.
    /// </summary>
    /// <param name="v1">first 1D input vector.</param>
    /// <param name="v2">second 1D input vector.</param>
    /// <param name="icovar">inverse covariance matrix.</param>
    /// <returns></returns>
    public static double Mahalanobis(InputArrayRef v1, InputArrayRef v2, InputArrayRef icovar)
    {
        NativeMethods.HandleException(
            NativeMethods.core_Mahalanobis(v1.Proxy, v2.Proxy, icovar.Proxy, out var ret));

        GC.KeepAlive(v1.Source);
        GC.KeepAlive(v2.Source);
        GC.KeepAlive(icovar.Source);
        return ret;
    }

    /// <summary>
    /// Performs a forward Discrete Fourier transform of 1D or 2D floating-point array.
    /// </summary>
    /// <param name="src">The source array, real or complex</param>
    /// <param name="dst">The destination array, which size and type depends on the flags</param>
    /// <param name="flags">Transformation flags, a combination of the DftFlag2 values</param>
    /// <param name="nonzeroRows">When the parameter != 0, the function assumes that
    /// only the first nonzeroRows rows of the input array ( DFT_INVERSE is not set)
    /// or only the first nonzeroRows of the output array ( DFT_INVERSE is set) contain non-zeros,
    /// thus the function can handle the rest of the rows more efficiently and
    /// thus save some time. This technique is very useful for computing array cross-correlation
    /// or convolution using DFT</param>
    public static void Dft(InputArrayRef src, OutputArrayRef dst, DftFlags flags = DftFlags.None, int nonzeroRows = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_dft(src.Proxy, dst.Proxy, (int) flags, nonzeroRows));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Performs an inverse Discrete Fourier transform of 1D or 2D floating-point array.
    /// </summary>
    /// <param name="src">The source array, real or complex</param>
    /// <param name="dst">The destination array, which size and type depends on the flags</param>
    /// <param name="flags">Transformation flags, a combination of the DftFlag2 values</param>
    /// <param name="nonzeroRows">When the parameter != 0, the function assumes that
    /// only the first nonzeroRows rows of the input array ( DFT_INVERSE is not set)
    /// or only the first nonzeroRows of the output array ( DFT_INVERSE is set) contain non-zeros,
    /// thus the function can handle the rest of the rows more efficiently and
    /// thus save some time. This technique is very useful for computing array cross-correlation
    /// or convolution using DFT</param>
    public static void Idft(InputArrayRef src, OutputArrayRef dst, DftFlags flags = DftFlags.None, int nonzeroRows = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_idft(src.Proxy, dst.Proxy, (int) flags, nonzeroRows));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Performs forward or inverse 1D or 2D Discrete Cosine Transformation
    /// </summary>
    /// <param name="src">The source floating-point array</param>
    /// <param name="dst">The destination array; will have the same size and same type as src</param>
    /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
    public static void Dct(InputArrayRef src, OutputArrayRef dst, DctFlags flags = DctFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_dct(src.Proxy, dst.Proxy, (int) flags));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Performs inverse 1D or 2D Discrete Cosine Transformation
    /// </summary>
    /// <param name="src">The source floating-point array</param>
    /// <param name="dst">The destination array; will have the same size and same type as src</param>
    /// <param name="flags">Transformation flags, a combination of DctFlag2 values</param>
    public static void Idct(InputArrayRef src, OutputArrayRef dst, DctFlags flags = DctFlags.None)
    {
        NativeMethods.HandleException(
            NativeMethods.core_idct(src.Proxy, dst.Proxy, (int) flags));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Performs the per-element multiplication of two Fourier spectrums.
    /// </summary>
    /// <param name="a">first input array.</param>
    /// <param name="b">second input array of the same size and type as src1.</param>
    /// <param name="c"> output array of the same size and type as src1.</param>
    /// <param name="flags">operation flags; currently, the only supported flag is cv::DFT_ROWS, which indicates that
    /// each row of src1 and src2 is an independent 1D Fourier spectrum. If you do not want to use this flag, then simply add a `0` as value.</param>
    /// <param name="conjB">optional flag that conjugates the second input array before the multiplication (true) or not (false).</param>
    public static void MulSpectrums(
        InputArray a, InputArray b, OutputArray c,
        DftFlags flags, bool conjB = false)
    {
        if (a is null)
            throw new ArgumentNullException(nameof(a));
        if (b is null)
            throw new ArgumentNullException(nameof(b));
        if (c is null)
            throw new ArgumentNullException(nameof(c));
        a.ThrowIfDisposed();
        b.ThrowIfDisposed();
        c.ThrowIfNotReady();

        NativeMethods.HandleException( 
            NativeMethods.core_mulSpectrums(a.ToInputProxy(), b.ToInputProxy(), c.ToOutputProxy(), (int) flags, conjB ? 1 : 0));

        GC.KeepAlive(a);
        GC.KeepAlive(b);
        GC.KeepAlive(c);
        c.Fix();
    }

    /// <summary>
    /// Returns the optimal DFT size for a given vector size.
    /// </summary>
    /// <param name="vecSize">vector size.</param>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public static int GetOptimalDFTSize(int vecSize)
    {
        NativeMethods.HandleException( 
            NativeMethods.core_getOptimalDFTSize(vecSize, out var ret));
        return ret;
    }
        
    /// <summary>
    /// Returns the thread-local Random number generator
    /// </summary>
    /// <returns></returns>
    public static RNG GetTheRNG()
    {
        NativeMethods.HandleException(
            NativeMethods.core_theRNG_get(out var state));
        return new RNG(state);
    }
        
    /// <summary>
    /// Sets the thread-local Random number generator
    /// </summary>
    /// <returns></returns>
    public static RNG SetTheRNG(ulong state)
    {
        NativeMethods.HandleException(
            NativeMethods.core_theRNG_set(state));
        return new RNG(state);
    }

    /// <summary>
    /// fills array with uniformly-distributed random numbers from the range [low, high)
    /// </summary>
    /// <param name="dst">The output array of random numbers. 
    /// The array must be pre-allocated and have 1 to 4 channels</param>
    /// <param name="low">The inclusive lower boundary of the generated random numbers</param>
    /// <param name="high">The exclusive upper boundary of the generated random numbers</param>
    public static void Randu(InputOutputArray dst, InputArray low, InputArray high)
    {
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (low is null)
            throw new ArgumentNullException(nameof(low));
        if (high is null)
            throw new ArgumentNullException(nameof(high));
        dst.ThrowIfNotReady();
        low.ThrowIfDisposed();
        high.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_randu_InputArray(dst.ToInputOutputProxy(), low.ToInputProxy(), high.ToInputProxy()));

        GC.KeepAlive(dst);
        GC.KeepAlive(low);
        GC.KeepAlive(high);
        dst.Fix();
    }

    /// <summary>
    /// fills array with uniformly-distributed random numbers from the range [low, high)
    /// </summary>
    /// <param name="dst">The output array of random numbers. 
    /// The array must be pre-allocated and have 1 to 4 channels</param>
    /// <param name="low">The inclusive lower boundary of the generated random numbers</param>
    /// <param name="high">The exclusive upper boundary of the generated random numbers</param>
    // ReSharper disable once IdentifierTypo
    public static void Randu(InputOutputArray dst, Scalar low, Scalar high)
    {
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.core_randu_Scalar(dst.ToInputOutputProxy(), low, high));

        GC.KeepAlive(dst);
        dst.Fix();
    }

    /// <summary>
    /// fills array with normally-distributed random numbers with the specified mean and the standard deviation
    /// </summary>
    /// <param name="dst">The output array of random numbers. 
    /// The array must be pre-allocated and have 1 to 4 channels</param>
    /// <param name="mean">The mean value (expectation) of the generated random numbers</param>
    /// <param name="stddev">The standard deviation of the generated random numbers</param>
    // ReSharper disable once IdentifierTypo
    public static void Randn(InputOutputArray dst, InputArray mean, InputArray stddev)
    {
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (mean is null)
            throw new ArgumentNullException(nameof(mean));
        if (stddev is null)
            throw new ArgumentNullException(nameof(stddev));
        dst.ThrowIfNotReady();
        mean.ThrowIfDisposed();
        stddev.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_randn_InputArray(dst.ToInputOutputProxy(), mean.ToInputProxy(), stddev.ToInputProxy()));

        GC.KeepAlive(dst);
        GC.KeepAlive(mean);
        GC.KeepAlive(stddev);
        dst.Fix();
    }

    /// <summary>
    /// fills array with normally-distributed random numbers with the specified mean and the standard deviation
    /// </summary>
    /// <param name="dst">The output array of random numbers. 
    /// The array must be pre-allocated and have 1 to 4 channels</param>
    /// <param name="mean">The mean value (expectation) of the generated random numbers</param>
    /// <param name="stddev">The standard deviation of the generated random numbers</param>
    public static void Randn(InputOutputArray dst, Scalar mean, Scalar stddev)
    {
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.core_randn_Scalar(dst.ToInputOutputProxy(), mean, stddev));

        GC.KeepAlive(dst);
        dst.Fix();
    }
        
    /// <summary>
    /// shuffles the input array elements
    /// </summary>
    /// <param name="dst">The input/output numerical 1D array</param>
    /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
    // ReSharper disable once IdentifierTypo
    public static void RandShuffle(InputOutputArray dst, double iterFactor)
    {
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.core_randShuffle(dst.ToInputOutputProxy(), iterFactor, IntPtr.Zero));

        GC.KeepAlive(dst);
        dst.Fix();
    }

    /// <summary>
    /// shuffles the input array elements
    /// </summary>
    /// <param name="dst">The input/output numerical 1D array</param>
    /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
    /// <param name="rng">The optional random number generator used for shuffling. 
    /// If it is null, theRng() is used instead.</param>
    // ReSharper disable once IdentifierTypo
    public static void RandShuffle(InputOutputArray dst, double iterFactor, ref RNG rng)
    {
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        dst.ThrowIfNotReady();

        var state = rng.State;
        NativeMethods.HandleException(
            NativeMethods.core_randShuffle(dst.ToInputOutputProxy(), iterFactor, ref state));
        rng = new RNG(state);

        GC.KeepAlive(dst);
        dst.Fix();
    }

    /// <summary>
    /// Finds centers of clusters and groups input samples around the clusters.
    /// </summary>
    /// <param name="data">Data for clustering. An array of N-Dimensional points with float coordinates is needed.</param>
    /// <param name="k">Number of clusters to split the set by.</param>
    /// <param name="bestLabels">Input/output integer array that stores the cluster indices for every sample.</param>
    /// <param name="criteria">The algorithm termination criteria, that is, the maximum number of iterations and/or
    /// the desired accuracy. The accuracy is specified as criteria.epsilon. As soon as each of the cluster centers
    /// moves by less than criteria.epsilon on some iteration, the algorithm stops.</param>
    /// <param name="attempts">Flag to specify the number of times the algorithm is executed using different
    /// initial labellings. The algorithm returns the labels that yield the best compactness (see the last function parameter).</param>
    /// <param name="flags">Flag that can take values of cv::KmeansFlags</param>
    /// <param name="centers">Output matrix of the cluster centers, one row per each cluster center.</param>
    /// <returns>The function returns the compactness measure that is computed as
    /// \f[\sum _i  \| \texttt{samples} _i -  \texttt{centers} _{ \texttt{labels} _i} \| ^2\f]
    /// after every attempt. The best (minimum) value is chosen and the corresponding labels and the compactness
    /// value are returned by the function. Basically, you can use only the core of the function,
    /// set the number of attempts to 1, initialize labels each time using a custom algorithm,
    /// pass them with the ( flags = #KMEANS_USE_INITIAL_LABELS ) flag, and then choose the best (most-compact) clustering.</returns>
    public static double Kmeans(InputArray data, int k, InputOutputArray bestLabels,
        TermCriteria criteria, int attempts, KMeansFlags flags, OutputArray? centers = null)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        if (bestLabels is null)
            throw new ArgumentNullException(nameof(bestLabels));
        data.ThrowIfDisposed();
        bestLabels.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_kmeans(
                data.ToInputProxy(), k, bestLabels.ToInputOutputProxy(), criteria, attempts, (int) flags, centers?.ToOutputProxy() ?? default, out var ret));

        bestLabels.Fix();
        centers?.Fix();
        GC.KeepAlive(data);
        GC.KeepAlive(bestLabels);
        GC.KeepAlive(centers);
        return ret;
    }

    #endregion

    #region base.hpp

    /// <summary>
    /// computes the angle in degrees (0..360) of the vector (x,y)
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static float FastAtan2(float y, float x)
    {
        NativeMethods.HandleException( 
            NativeMethods.core_fastAtan2(y, x, out var ret));
        return ret;
    }

    /// <summary>
    /// computes cube root of the argument
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static float CubeRoot(float val)
    {
        NativeMethods.HandleException(
            NativeMethods.core_cubeRoot(val, out var ret));
        return ret;
    }
        

    #endregion

    #region utility.hpp

    /// <summary>
    /// OpenCV will try to set the number of threads for the next parallel region.
    /// If threads == 0, OpenCV will disable threading optimizations and run all it's functions
    /// sequentially.Passing threads &lt; 0 will reset threads number to system default. This function must
    /// be called outside of parallel region.
    /// OpenCV will try to run its functions with specified threads number, but some behaviour differs from framework:
    /// -   `TBB` - User-defined parallel constructions will run with the same threads number, if another is not specified.If later on user creates his own scheduler, OpenCV will use it.
    /// -   `OpenMP` - No special defined behaviour.
    /// -   `Concurrency` - If threads == 1, OpenCV will disable threading optimizations and run its functions sequentially.
    /// -   `GCD` - Supports only values &lt;= 0.
    /// -   `C=` - No special defined behaviour.
    /// </summary>
    /// <param name="nThreads">Number of threads used by OpenCV.</param>
    public static void SetNumThreads(int nThreads)
    {
        NativeMethods.HandleException(
            NativeMethods.core_setNumThreads(nThreads));
    }

    /// <summary>
    /// Returns the number of threads used by OpenCV for parallel regions.
    /// 
    /// Always returns 1 if OpenCV is built without threading support.
    /// The exact meaning of return value depends on the threading framework used by OpenCV library:
    /// - `TBB` - The number of threads, that OpenCV will try to use for parallel regions. If there is
    /// any tbb::thread_scheduler_init in user code conflicting with OpenCV, then function returns default
    /// number of threads used by TBB library.
    /// - `OpenMP` - An upper bound on the number of threads that could be used to form a new team.
    /// - `Concurrency` - The number of threads, that OpenCV will try to use for parallel regions.
    /// - `GCD` - Unsupported; returns the GCD thread pool limit(512) for compatibility.
    /// - `C=` - The number of threads, that OpenCV will try to use for parallel regions, if before
    /// called setNumThreads with threads &gt; 0, otherwise returns the number of logical CPUs,
    /// available for the process.
    /// </summary>
    /// <returns></returns>
    public static int GetNumThreads()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getNumThreads(out var ret));
        return ret;
    }
        
    /// <summary>
    /// Returns the index of the currently executed thread within the current parallel region.
    /// Always returns 0 if called outside of parallel region.
    /// @deprecated Current implementation doesn't corresponding to this documentation.
    /// The exact meaning of the return value depends on the threading framework used by OpenCV library:
    /// - `TBB` - Unsupported with current 4.1 TBB release.Maybe will be supported in future.
    /// - `OpenMP` - The thread number, within the current team, of the calling thread.
    /// - `Concurrency` - An ID for the virtual processor that the current context is executing
    /// on(0 for master thread and unique number for others, but not necessary 1,2,3,...).
    /// - `GCD` - System calling thread's ID. Never returns 0 inside parallel region.
    /// - `C=` - The index of the current parallel task.
    /// </summary>
    /// <returns></returns>
    public static int GetThreadNum()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getThreadNum(out var ret));
        return ret;
    }

    /// <summary>
    /// Returns full configuration time cmake output.
    ///
    /// Returned value is raw cmake output including version control system revision, compiler version,
    /// compiler flags, enabled modules and third party libraries, etc.Output format depends on target architecture.
    /// </summary>
    /// <returns></returns>
    public static string GetBuildInformation()
    {
        using var stdString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_getBuildInformation(stdString.CvPtr));
        return stdString.ToString();
    }

    // Roots the user-supplied delegate for the lifetime of the registration so it is not
    // collected while OpenCV holds the native function pointer.
    private static CvErrorCallback? userErrorHandler;

    /// <summary>
    /// Overrides OpenCV's native error handler.
    /// </summary>
    /// <param name="errorHandler">
    /// The handler invoked by OpenCV when an error is raised, or <see langword="null"/> to
    /// restore the default native handler (which simply mutes OpenCV's stderr output).
    /// </param>
    /// <remarks>
    /// By default OpenCvSharp installs a native, managed-free handler; native errors are
    /// surfaced as managed <see cref="OpenCVException"/>s regardless. Installing a managed
    /// handler here is opt-in and reintroduces a managed delegate into the native error
    /// path, which is not NativeAOT / trimming friendly.
    /// </remarks>
    public static void SetErrorHandler(CvErrorCallback? errorHandler)
    {
        userErrorHandler = errorHandler;

        if (errorHandler is null)
        {
            NativeMethods.HandleException(NativeMethods.core_setSilentErrorHandler());
            return;
        }

        var zero = IntPtr.Zero;
        var prev = NativeMethods.redirectError(errorHandler, IntPtr.Zero, ref zero);
        GC.KeepAlive(prev);
    }

    /// <summary>
    /// Returns library version string.
    /// For example "3.4.1-dev".
    /// </summary>
    /// <returns></returns>
    public static string? GetVersionString()
    {
        const int bufferSize = 128;

        unsafe
        {
            var buffer = stackalloc byte[bufferSize];
            NativeMethods.HandleException(
                NativeMethods.core_getVersionString(buffer, bufferSize));
            var result = System.Runtime.InteropServices.Marshal.PtrToStringAnsi((IntPtr)buffer);
            return result;
        }
    }

    /// <summary>
    /// Returns major library version
    /// </summary>
    /// <returns></returns>
    public static int GetVersionMajor()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getVersionMajor(out var ret));
        return ret;
    }

    /// <summary>
    /// Returns minor library version
    /// </summary>
    /// <returns></returns>
    public static int GetVersionMinor()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getVersionMinor(out var ret));
        return ret;
    }

    /// <summary>
    /// Returns revision field of the library version
    /// </summary>
    /// <returns></returns>
    public static int GetVersionRevision()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getVersionRevision(out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of ticks.
    /// The function returns the number of ticks after the certain event (for example, when the machine was
    /// turned on). It can be used to initialize RNG or to measure a function execution time by reading the
    /// tick count before and after the function call.
    /// </summary>
    /// <returns></returns>
    public static long GetTickCount()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getTickCount(out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of ticks per second.
    /// The function returns the number of ticks per second.That is, the following code computes the execution time in seconds:
    /// </summary>
    /// <returns></returns>
    public static double GetTickFrequency()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getTickFrequency(out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of CPU ticks.
    ///
    /// The function returns the current number of CPU ticks on some architectures(such as x86, x64, PowerPC).
    /// On other platforms the function is equivalent to getTickCount.It can also be used for very accurate time
    /// measurements, as well as for RNG initialization.Note that in case of multi-CPU systems a thread, from which
    /// getCPUTickCount is called, can be suspended and resumed at another CPU with its own counter. So,
    /// theoretically (and practically) the subsequent calls to the function do not necessary return the monotonously
    /// increasing values. Also, since a modern CPU varies the CPU frequency depending on the load, the number of CPU
    /// clocks spent in some code cannot be directly converted to time units.Therefore, getTickCount is generally
    /// a preferable solution for measuringexecution time.
    /// </summary>
    /// <returns></returns>
    public static long GetCpuTickCount()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getCPUTickCount(out var ret));
        return ret;
    }

    /// <summary>
    /// Returns true if the specified feature is supported by the host hardware.
    /// The function returns true if the host hardware supports the specified feature.When user calls
    /// setUseOptimized(false), the subsequent calls to checkHardwareSupport() will return false until
    /// setUseOptimized(true) is called.This way user can dynamically switch on and off the optimized code in OpenCV.
    /// </summary>
    /// <param name="feature">The feature of interest, one of cv::CpuFeatures</param>
    /// <returns></returns>
    public static bool CheckHardwareSupport(CpuFeatures feature)
    {
        NativeMethods.HandleException(
            NativeMethods.core_checkHardwareSupport((int) feature, out var ret));
        return ret != 0;
    }

    /// <summary>
    /// Returns feature name by ID.
    /// Returns empty string if feature is not defined
    /// </summary>
    /// <param name="feature"></param>
    /// <returns></returns>
    public static string GetHardwareFeatureName(CpuFeatures feature)
    {
        using var buf = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_getHardwareFeatureName((int) feature, buf.CvPtr));
        return buf.ToString();
    }

    /// <summary>
    /// Returns list of CPU features enabled during compilation.
    /// Returned value is a string containing space separated list of CPU features with following markers:
    /// - no markers - baseline features
    /// - prefix `*` - features enabled in dispatcher
    /// - suffix `?` - features enabled but not available in HW
    /// </summary>
    /// <example>
    /// `SSE SSE2 SSE3* SSE4.1 *SSE4.2 *FP16* AVX *AVX2* AVX512-SKX?`
    /// </example>
    /// <returns></returns>
    public static string GetCpuFeaturesLine()
    {
        using var buf = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_getCPUFeaturesLine(buf.CvPtr));
        return buf.ToString();
    }

    /// <summary>
    /// Returns the number of logical CPUs available for the process.
    /// </summary>
    /// <returns></returns>
    public static int GetNumberOfCpus()
    {
        NativeMethods.HandleException(
            NativeMethods.core_getNumberOfCPUs(out var ret));
        return ret;
    }

    /*
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bufSize"></param>
    /// <returns></returns>
    public static IntPtr FastMalloc(long bufSize)
    {
        return NativeMethods.core_fastMalloc(new IntPtr(bufSize));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ptr"></param>
    public static void FastFree(IntPtr ptr)
    {
        NativeMethods.core_fastFree(CvPtr);
    }
    */

    /// <summary>
    /// Turns on/off available optimization.
    /// The function turns on or off the optimized code in OpenCV. Some optimization can not be enabled
    /// or disabled, but, for example, most of SSE code in OpenCV can be temporarily turned on or off this way.
    /// </summary>
    /// <param name="onoff"></param>
    public static void SetUseOptimized(bool onoff)
    {
        NativeMethods.HandleException(
            NativeMethods.core_setUseOptimized(onoff ? 1 : 0));
    }

    /// <summary>
    /// Returns the current optimization status.
    /// The function returns the current optimization status, which is controlled by cv::setUseOptimized().
    /// </summary>
    /// <returns></returns>
    public static bool UseOptimized()
    {
        NativeMethods.HandleException(
            NativeMethods.core_useOptimized(out var ret));
        return ret != 0;
    }

    /// <summary>
    /// Aligns buffer size by the certain number of bytes
    /// This small inline function aligns a buffer size by 
    /// the certian number of bytes by enlarging it.
    /// </summary>
    /// <param name="sz"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int AlignSize(int sz, int n)
    {
        var assert = ((n & (n - 1)) == 0); // n is a power of 2
        if (!assert)
            throw new ArgumentException("n must be a power of 2.", nameof(n));
        return (sz + n - 1) & -n;
    }
        
    /// <summary>
    /// Sets/resets the break-on-error mode.
    /// When the break-on-error mode is set, the default error handler issues a hardware exception,
    /// which can make debugging more convenient.
    /// </summary>
    /// <param name="flag"></param>
    /// <returns>the previous state</returns>
    public static bool SetBreakOnError(bool flag)
    {
        return NativeMethods.core_setBreakOnError(flag ? 1 : 0) != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mtx"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static string Format(InputArray mtx, FormatType format = FormatType.Default)
    {
        if (mtx is null)
            throw new ArgumentNullException(nameof(mtx));

        using var buf = new StdString();
        NativeMethods.HandleException(
            NativeMethods.core_format(mtx.ToInputProxy(), (int) format, buf.CvPtr));
        GC.KeepAlive(mtx);
        return buf.ToString();
    }

    #endregion

    #region logger.hpp

    /// <summary>
    /// Set global logging level
    /// </summary>
    /// <param name="logLevel">logging level</param>
    /// <returns>previous logging level</returns>
    public static LogLevel SetLogLevel(LogLevel logLevel)
    {
        NativeMethods.HandleException(
            NativeMethods.core_logger_setLogLevel(logLevel, out var previous));

        return previous;
    }

    /// <summary>
    /// Get global logging level
    /// </summary>
    /// <returns>logging level</returns>
    public static LogLevel GetLogLevel()
    {
        NativeMethods.HandleException(
            NativeMethods.core_logger_getLogLevel(out var logLevel));

        return logLevel;
    }

    #endregion

    /// <summary>
    /// Computes absolute value of each matrix element
    /// </summary>
    /// <param name="src">matrix</param>
    /// <returns></returns>
    public static MatExpr Abs(Mat src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        return MatExpr.From(src).Abs();
    }
        
    /// <summary>
    /// Equivalence predicate (a boolean function of two arguments).
    /// The predicate returns true when the elements are certainly in the same class, and returns false if they may or may not be in the same class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <returns></returns>
    public delegate bool PartitionPredicate<in T>(T t1, T t2);

    /// <summary>
    /// Splits an element set into equivalency classes.
    /// Consider using GroupBy of Linq instead.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vec">Set of elements stored as a vector.</param>
    /// <param name="labels">Output vector of labels. It contains as many elements as vec. Each label labels[i] is a 0-based cluster index of vec[i] .</param>
    /// <param name="predicate">Equivalence predicate (a boolean function of two arguments).
    /// The predicate returns true when the elements are certainly in the same class, and returns false if they may or may not be in the same class.</param>
    /// <returns></returns>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public static int Partition<T>(IEnumerable<T> vec, out int[] labels, PartitionPredicate<T> predicate)
    {
        if (vec is null) 
            throw new ArgumentNullException(nameof(vec));
        if (predicate is null) 
            throw new ArgumentNullException(nameof(predicate));

        var vecArray = vec as T[] ?? vec.ToArray();
        labels = new int[vecArray.Length];
        var groupHeads = new List<T>();

        var index = 0;
        foreach (var t in vecArray)
        {
            var foundGroup = false;

            var label = 0;
            foreach (var groupHeadElem in groupHeads)
            {
                if (predicate(groupHeadElem, t))
                {
                    labels[index] = label;
                    foundGroup = true;
                    break;
                }

                label++;
            }

            if (!foundGroup)
            {
                labels[index] = groupHeads.Count;
                groupHeads.Add(t);
            }

            index++;
        }

        return groupHeads.Count;
    }
}
