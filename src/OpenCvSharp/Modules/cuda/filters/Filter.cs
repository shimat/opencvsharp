using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda;

public class Filter : Algorithm
{
    protected Filter(IntPtr smartPtr, IntPtr rawPtr)
           : base(smartPtr, rawPtr, p=> NativeMethods.HandleException(NativeMethods.cuda_Filter_delete(p)))
    {
    }

    /// <summary>
    /// Applies the specified filter to the image.
    /// </summary>
    public virtual void Apply(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (src is null) 
            throw new ArgumentNullException(nameof(src));
        if (dst is null) 
            throw new ArgumentNullException(nameof(dst));

        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_apply(RawPtr, src.CvPtr, dst.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

        GC.KeepAlive(this);
        GC.KeepAlive(src);
        dst.Fix();
    }

    /// <summary>
    /// Creates a normalized 2D box filter.
    /// </summary>
    public static Filter CreateBoxFilter(MatType srcType, MatType dstType, Size ksize, Point? anchor = null, BorderTypes borderMode = BorderTypes.Default, Scalar? borderVal = null)
    {
        Point pt = anchor ?? new Point(-1, -1);
        Scalar val = borderVal ?? new Scalar(0);

        NativeMethods.HandleException(NativeMethods.cuda_createBoxFilter(
            (int)srcType, (int)dstType, ksize, pt, (int)borderMode, val, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_Filter_get(smartPtr, out IntPtr rawPtr));
        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates the maximum filter.
    /// </summary>
    public static Filter CreateBoxMaxFilter(MatType srcType, Size ksize, Point? anchor = null, BorderTypes borderMode = BorderTypes.Default, Scalar? borderVal = null)
    {
        Point pt = anchor ?? new Point(-1, -1);
        Scalar val = borderVal ?? new Scalar(0);

        NativeMethods.HandleException(NativeMethods.cuda_createBoxMaxFilter(
            (int)srcType, ksize, pt, (int)borderMode, val, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_Filter_get(smartPtr, out IntPtr rawPtr));
        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates the minimum filter. 
    /// </summary>
    public static Filter CreateBoxMinFilter(MatType srcType, Size ksize, Point? anchor = null, BorderTypes borderMode = BorderTypes.Default, Scalar? borderVal = null)
    {
        Point pt = anchor ?? new Point(-1, -1);
        Scalar val = borderVal ?? new Scalar(0);

        NativeMethods.HandleException(NativeMethods.cuda_createBoxMinFilter(
            (int)srcType, ksize, pt, (int)borderMode, val, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_Filter_get(smartPtr, out IntPtr rawPtr));
        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a vertical 1D box filter.
    /// </summary>
    public static Filter CreateColumnSumFilter(MatType srcType, MatType dstType, int ksize, int anchor = -1, BorderTypes borderMode = BorderTypes.Default, Scalar? borderVal = null)
    {
        Scalar val = borderVal ?? new Scalar(0);

        NativeMethods.HandleException(NativeMethods.cuda_createColumnSumFilter(
            (int)srcType, (int)dstType, ksize, anchor, (int)borderMode, val, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_Filter_get(smartPtr, out IntPtr rawPtr));
        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a generalized Deriv operator.
    /// </summary>
    public static Filter CreateDerivFilter(MatType srcType, MatType dstType, int dx, int dy, int ksize, bool normalize = false, double scale = 1, BorderTypes rowBorderMode = BorderTypes.Default, int columnBorderMode = -1)
    {
        NativeMethods.HandleException(NativeMethods.cuda_createDerivFilter(
            (int)srcType, (int)dstType, dx, dy, ksize, normalize ? 1 : 0, scale,
            (int)rowBorderMode, columnBorderMode, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.cuda_Filter_get(smartPtr, out IntPtr rawPtr));
        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a Gaussian filter.
    /// </summary>
    /// <param name="srcType">Source image type.</param>
    /// <param name="dstType">Destination image type.</param>
    /// <param name="ksize">Kernel size.</param>
    /// <param name="sigma1">Gaussian sigma in the horizontal direction.</param>
    /// <param name="sigma2">Gaussian sigma in the vertical direction. If 0, then sigma2 is set to be equal to sigma1.</param>
    /// <param name="rowBorderMode">Pixel extrapolation method in the row direction.</param>
    /// <param name="columnBorderMode">Pixel extrapolation method in the column direction. -1 means same as rowBorderMode.</param>
    /// <returns></returns>
    public static Filter CreateGaussianFilter(MatType srcType, MatType dstType, Size ksize, double sigma1, double sigma2 = 0,  BorderTypes rowBorderMode = BorderTypes.Default, int columnBorderMode = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createGaussianFilter(
                (int)srcType, (int)dstType, ksize, sigma1, sigma2, (int)rowBorderMode, columnBorderMode, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a Laplacian operator.
    /// </summary>
    /// <param name="srcType">Source image type.</param>
    /// <param name="dstType">Destination image type.</param>
    /// <param name="ksize">Aperture size used to compute the second-derivative filters.</param>
    /// <param name="scale">Optional scale factor for the computed Laplacian values.</param>
    /// <param name="borderMode">Pixel extrapolation method.</param>
    /// <param name="borderVal">Value for constant borders.</param>
    /// <returns></returns>
    public static Filter CreateLaplacianFilter(MatType srcType, MatType dstType, int ksize = 1, double scale = 1, BorderTypes borderMode = BorderTypes.Default, Scalar? borderVal = null)
    {
        Scalar val = borderVal ?? new Scalar(0);

        NativeMethods.HandleException(
            NativeMethods.cuda_createLaplacianFilter(
                (int)srcType, (int)dstType, ksize, scale, (int)borderMode, val, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a non-separable linear 2D filter.
    /// </summary>
    /// <param name="srcType">Input image type.</param>
    /// <param name="dstType">Output image type.</param>
    /// <param name="kernel">2D array of filter coefficients (usually CV_32F).</param>
    /// <param name="anchor">Anchor point. -1 means center.</param>
    /// <param name="borderMode">Pixel extrapolation method.</param>
    /// <param name="borderVal">Value for constant borders.</param>
    /// <returns></returns>
    public static Filter CreateLinearFilter( MatType srcType, MatType dstType, OpenCvSharp.InputArray kernel,  Point? anchor = null, BorderTypes borderMode = BorderTypes.Default, Scalar? borderVal = null)
    {
        if (kernel == null) throw new ArgumentNullException(nameof(kernel));
        kernel.ThrowIfDisposed();

        Point pt = anchor ?? new Point(-1, -1);
        Scalar val = borderVal ?? new Scalar(0);

        NativeMethods.HandleException(
            NativeMethods.cuda_createLinearFilter(
                (int)srcType, (int)dstType, kernel.CvPtr, pt, (int)borderMode, val, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Performs median filtering for each point of the source image.
    /// </summary>
    /// <param name="srcType">Source image type. CV_8UC1 is supported.</param>
    /// <param name="windowSize">Window size. Must be an odd number.</param>
    /// <param name="partition">Partition value used in the algorithm. Default is 128.</param>
    /// <returns></returns>
    public static Filter CreateMedianFilter(MatType srcType, int windowSize, int partition = 128)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createMedianFilter((int)srcType, windowSize, partition, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a 2D morphological filter.
    /// </summary>
    /// <param name="op">Morphological operation (Erode, Dilate, Open, Close, etc.).</param>
    /// <param name="srcType">Input image type. CV_8UC1 and CV_8UC4 are commonly supported.</param>
    /// <param name="kernel">2D structuring element used for morphology.</param>
    /// <param name="anchor">Anchor position within the structuring element. -1 means center.</param>
    /// <param name="iterations">Number of times erosion and dilation are applied.</param>
    /// <returns></returns>
    public static Filter CreateMorphologyFilter(MorphTypes op, MatType srcType, OpenCvSharp.InputArray kernel, Point? anchor = null, int iterations = 1)
    {
        if (kernel == null) throw new ArgumentNullException(nameof(kernel));
        kernel.ThrowIfDisposed();

        Point pt = anchor ?? new Point(-1, -1);

        NativeMethods.HandleException(
            NativeMethods.cuda_createMorphologyFilter(
                (int)op, (int)srcType, kernel.CvPtr, pt, iterations, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a horizontal 1D box filter.
    /// </summary>
    /// <param name="srcType">Input image type.</param>
    /// <param name="dstType">Output image type (e.g., CV_32SC1 to avoid overflow).</param>
    /// <param name="ksize">Kernel size (horizontal width).</param>
    /// <param name="anchor">Anchor point. -1 means center.</param>
    /// <param name="borderMode">Border handling.</param>
    /// <param name="borderVal">Value for constant borders.</param>
    /// <returns></returns>
    public static Filter CreateRowSumFilter(MatType srcType, MatType dstType, int ksize, int anchor = -1, BorderTypes borderMode = BorderTypes.Default, Scalar? borderVal = null)
    {
        Scalar val = borderVal ?? new Scalar(0);

        NativeMethods.HandleException(NativeMethods.cuda_createRowSumFilter(
            (int)srcType, (int)dstType, ksize, anchor, (int)borderMode, val, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a vertical or horizontal Scharr operator.
    /// </summary>
    /// <param name="srcType">Source image type.</param>
    /// <param name="dstType">Destination image type.</param>
    /// <param name="dx">Order of the derivative x.</param>
    /// <param name="dy">Order of the derivative y.</param>
    /// <param name="scale">Optional scale factor for the computed derivative values.</param>
    /// <param name="rowBorderMode">Pixel extrapolation method in the row direction.</param>
    /// <param name="columnBorderMode">Pixel extrapolation method in the column direction. -1 means same as rowBorderMode.</param>
    /// <returns></returns>
    public static Filter CreateScharrFilter(MatType srcType, MatType dstType, int dx, int dy, double scale = 1, BorderTypes rowBorderMode = BorderTypes.Default, int columnBorderMode = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createScharrFilter(
                (int)srcType, (int)dstType, dx, dy, scale, (int)rowBorderMode, columnBorderMode, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a separable linear filter.
    /// </summary>
    /// <param name="srcType">Source image type.</param>
    /// <param name="dstType">Destination image type.</param>
    /// <param name="rowKernel">Horizontal filter coefficients (1D Mat).</param>
    /// <param name="columnKernel">Vertical filter coefficients (1D Mat).</param>
    /// <param name="anchor">Anchor point. -1 means center.</param>
    /// <param name="rowBorderMode">Pixel extrapolation method in the row direction.</param>
    /// <param name="columnBorderMode">Pixel extrapolation method in the column direction. -1 means same as rowBorderMode.</param>
    /// <returns></returns>
    public static Filter CreateSeparableLinearFilter(MatType srcType, MatType dstType, OpenCvSharp. InputArray rowKernel, OpenCvSharp.InputArray columnKernel, Point? anchor = null, BorderTypes rowBorderMode = BorderTypes.Default, int columnBorderMode = -1)
    {
        if (rowKernel == null) throw new ArgumentNullException(nameof(rowKernel));
        if (columnKernel == null) throw new ArgumentNullException(nameof(columnKernel));
        rowKernel.ThrowIfDisposed();
        columnKernel.ThrowIfDisposed();

        Point pt = anchor ?? new Point(-1, -1);

        NativeMethods.HandleException(
            NativeMethods.cuda_createSeparableLinearFilter(
                (int)srcType, (int)dstType, rowKernel.CvPtr, columnKernel.CvPtr,
                pt, (int)rowBorderMode, columnBorderMode, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a Sobel operator.
    /// </summary>
    /// <param name="srcType">Source image type.</param>
    /// <param name="dstType">Destination image type.</param>
    /// <param name="dx">Order of the derivative x.</param>
    /// <param name="dy">Order of the derivative y.</param>
    /// <param name="ksize">Size of the extended Sobel kernel; it must be 1, 3, 5, or 7.</param>
    /// <param name="scale">Optional scale factor for the computed derivative values.</param>
    /// <param name="rowBorderMode">Pixel extrapolation method in the row direction.</param>
    /// <param name="columnBorderMode">Pixel extrapolation method in the column direction. -1 means same as rowBorderMode.</param>
    /// <returns></returns>
    public static Filter CreateSobelFilter(MatType srcType, MatType dstType, int dx, int dy, int ksize = 3, double scale = 1, BorderTypes rowBorderMode = BorderTypes.Default, int columnBorderMode = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_createSobelFilter(
                (int)srcType, (int)dstType, dx, dy, ksize, scale, (int)rowBorderMode, columnBorderMode, out var smartPtr));

        NativeMethods.HandleException(
            NativeMethods.cuda_Filter_get(smartPtr, out var rawPtr));

        return new Filter(smartPtr, rawPtr);
    }
}
