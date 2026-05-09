using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    public static partial class Cuda
    {

        #region Alpha Comp
        /// <summary>
        /// Composites two images using alpha opacity values contained in each image. 
        /// </summary>
        public static void AlphaComp(OpenCvSharp.Cuda.InputArray img1, OpenCvSharp.Cuda.InputArray img2, OpenCvSharp.Cuda.OutputArray dst, 
            AlphaCompTypes alphaOp, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (img1 is null) 
                throw new ArgumentNullException(nameof(img1));
            if (img2 is null) 
                throw new ArgumentNullException(nameof(img2));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            img1.ThrowIfDisposed();
            img2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_alphaComp(img1.CvPtr, img2.CvPtr, dst.CvPtr, alphaOp, stream?.CvPtr ?? IntPtr.Zero));
           
            GC.KeepAlive(img1);
            GC.KeepAlive(img2);
            dst.Fix();
       
        }

        #endregion

        #region Bilateral Filter
        /// <summary>
        /// Performs bilateral filtering of passed image.
        /// </summary>
        public static void BilateralFilter(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst,  
            int kernelSize, float sigmaColor, float sigmaSpatial, BorderTypes borderMode = BorderTypes.Default, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_bilateralFilter(
                    src.CvPtr, dst.CvPtr, kernelSize, sigmaColor, sigmaSpatial, (int)borderMode, stream?.CvPtr ?? IntPtr.Zero));
            
            GC.KeepAlive(src);
            dst.Fix();
         
        }

        #endregion

        #region BlendLinear

        /// <summary>
        /// Performs linear blending of two images. 
        /// </summary>
        public static void BlendLinear(OpenCvSharp.Cuda.InputArray img1, OpenCvSharp.Cuda.InputArray img2, OpenCvSharp.Cuda.InputArray weights1, 
            OpenCvSharp.Cuda.InputArray weights2, OpenCvSharp.Cuda.OutputArray result, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (img1 is null)
                throw new ArgumentNullException(nameof(img1));
            if (img2 is null)
                throw new ArgumentNullException(nameof(img2));
            if (weights1 is null)
                throw new ArgumentNullException(nameof(weights1));
            if (weights2 is null)
                throw new ArgumentNullException(nameof(weights2));
            if (result is null)
                throw new ArgumentNullException(nameof(result));
            img1.ThrowIfDisposed();
            img2.ThrowIfDisposed();
            weights1.ThrowIfDisposed();
            weights2.ThrowIfDisposed();
            result.ThrowIfNotReady();


            NativeMethods.HandleException(
                NativeMethods.cuda_blendLinear(img1.CvPtr, img2.CvPtr, weights1.CvPtr, weights2.CvPtr, result.CvPtr, ToPtr(stream)));
       
            GC.KeepAlive(img1); 
            GC.KeepAlive(img2); 
            GC.KeepAlive(weights1); 
            GC.KeepAlive(weights2);
            result.Fix();
        }

        #endregion

        #region ConnectedComponents

        /// <summary>
        /// Computes the Connected Components Labeled image of a binary image.
        /// </summary>
        /// <param name="image">The 8-bit single-channel image to be labeled.</param>
        /// <param name="labels">Destination labeled image.</param>
        /// <param name="connectivity">8 or 4 connected components.</param>
        /// <param name="ltype">Output image label type. Currently CV_32S and CV_16S are supported.</param>
        /// <param name="ccltype">Connected components algorithm type.</param>
        public static void ConnectedComponents(OpenCvSharp.Cuda.InputArray image, OpenCvSharp.Cuda.OutputArray labels,
            int connectivity = 8,
            MatType? ltype = null,
            OpenCvSharp.Cuda.ConnectedComponentsAlgorithmsTypes ccltype = OpenCvSharp.Cuda.ConnectedComponentsAlgorithmsTypes.Default)
        {
            if (image is null) 
                throw new ArgumentNullException(nameof(image));
            if (labels is null) 
                throw new ArgumentNullException(nameof(labels));

            image.ThrowIfDisposed();
            labels.ThrowIfNotReady();

            int type = ltype?.Value ?? (int)MatType.CV_32S;

            NativeMethods.HandleException(
                NativeMethods.cuda_connectedComponents(
                    image.CvPtr,
                    labels.CvPtr,
                    connectivity,
                    type,
                    (int)ccltype));

            labels.Fix();
            GC.KeepAlive(image);
        }

        #endregion

        #region ConvertSpatialMoments

        /// <summary>
        /// Converts the spatial image moments returned from cuda::spatialMoments to cv::Moments.
        /// </summary>
        /// <param name="spatialMoments">Spatial moments returned from cuda::spatialMoments (CPU Mat).</param>
        /// <param name="order">Order of moments.</param>
        /// <param name="momentsType">Type of moments (CV_32F or CV_64F).</param>
        /// <returns>A Moments structure.</returns>
        public static Moments ConvertSpatialMoments(Mat spatialMoments, MomentsOrder order, MatType momentsType)
        {
            if (spatialMoments is null) throw new ArgumentNullException(nameof(spatialMoments));
            spatialMoments.ThrowIfDisposed();

            double[] buffer = new double[24];

            NativeMethods.HandleException(
                NativeMethods.cuda_convertSpatialMoments(
                    spatialMoments.CvPtr,
                    (int)order,
                    momentsType.Value,
                    buffer));

            GC.KeepAlive(spatialMoments);

            return new Moments
            {
                // Spatial
                M00 = buffer[0],
                M10 = buffer[1],
                M01 = buffer[2],
                M20 = buffer[3],
                M11 = buffer[4],
                M02 = buffer[5],
                M30 = buffer[6],
                M21 = buffer[7],
                M12 = buffer[8],
                M03 = buffer[9],
                // Central
                Mu20 = buffer[10],
                Mu11 = buffer[11],
                Mu02 = buffer[12],
                Mu30 = buffer[13],
                Mu21 = buffer[14],
                Mu12 = buffer[15],
                Mu03 = buffer[16],
                // Normalized
                Nu20 = buffer[17],
                Nu11 = buffer[18],
                Nu02 = buffer[19],
                Nu30 = buffer[20],
                Nu21 = buffer[21],
                Nu12 = buffer[22],
                Nu03 = buffer[23]
            };
        }

        #endregion

        #region CvtColor
        /// <summary>
        /// Converts an image from one color space to another.
        /// </summary>
        public static void CvtColor( OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, ColorConversionCodes code, 
            int dcn = 0, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_cvtColor(src.CvPtr, dst.CvPtr, (int)code, dcn, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
            
        }
        #endregion

        #region Demosaicing

        /// <summary>
        /// Converts an image from Bayer pattern to RGB or grayscale.
        /// </summary>
        /// <param name="src">Source image (Bayer pattern, 8-bit or 16-bit single channel).</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="code">Demosaicing code (e.g. ColorConversionCodes.BayerRG2BGR).</param>
        /// <param name="dcn">Number of channels in the destination image. -1 means derived automatically.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Demosaicing(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst,
            ColorConversionCodes code, int dcn = -1, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_demosaicing(src.CvPtr, dst.CvPtr, (int)code, dcn, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region EqualizeHist
        /// <summary>
        /// Equalizes the histogram of a grayscale image.
        /// </summary>
        /// <param name="src">Source 8-bit single channel image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void EqualizeHist(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_equalizeHist(src.CvPtr, dst.CvPtr, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
            
        }

        #endregion

        #region EvenLevels

        /// <summary>
        /// Computes levels with even distribution.
        /// </summary>
        /// <param name="levels">Output 1D matrix of type CV_32SC1.</param>
        /// <param name="nLevels">Number of levels to compute.</param>
        /// <param name="lowerLevel">Lower bound of the levels.</param>
        /// <param name="upperLevel">Upper bound of the levels.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void EvenLevels(OpenCvSharp.Cuda.OutputArray levels, int nLevels, int lowerLevel, int upperLevel,  OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (levels is null) 
                throw new ArgumentNullException(nameof(levels));
            levels.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_evenLevels(levels.CvPtr, nLevels, lowerLevel, upperLevel, ToPtr(stream)));

            levels.Fix();
        }

        #endregion

        #region GammaCorrection

        /// <summary>
        /// Routines for correcting image color gamma.
        /// </summary>
        /// <param name="src">Source image (8-bit 3-channel BGR/RGB or grayscale).</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="forward">If true, forward gamma correction is performed (gamma=1/2.2). If false, inverse correction (gamma=2.2) is performed.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void GammaCorrection(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, bool forward = true, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_gammaCorrection(src.CvPtr, dst.CvPtr, forward ? 1 : 0, ToPtr(stream)));
            
            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region HistEven

        /// <summary>
        /// Calculates a histogram with evenly distributed bins.
        /// </summary>
        /// <param name="src">Source 8-bit or 16-bit, single-channel image.</param>
        /// <param name="hist">Destination histogram (CV_32SC1).</param>
        /// <param name="histSize">Size of the histogram (number of bins).</param>
        /// <param name="lowerLevel">Lower bound of the histogram.</param>
        /// <param name="upperLevel">Upper bound of the histogram.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void HistEven(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray hist, 
            int histSize, int lowerLevel, int upperLevel, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (hist is null) 
                throw new ArgumentNullException(nameof(hist));

            src.ThrowIfDisposed();
            hist.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_histEven(src.CvPtr, hist.CvPtr, histSize, lowerLevel, upperLevel, ToPtr(stream)));

            GC.KeepAlive(src);
            hist.Fix();
        }

        /// <summary>
        /// Calculates a histogram with evenly distributed bins for each channel (up to 4).
        /// </summary>
        public static void HistEven(OpenCvSharp.Cuda.InputArray src, GpuMat[] hist,  int[] histSize, int[] lowerLevel, int[] upperLevel, 
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (hist is null) 
                throw new ArgumentNullException(nameof(hist));
            if (histSize is null)
                throw new ArgumentNullException(nameof(histSize));
            if (histSize is null)
                throw new ArgumentNullException(nameof(histSize));
            if (lowerLevel is null)
                throw new ArgumentNullException(nameof(lowerLevel));
            if (upperLevel is null)
                throw new ArgumentNullException(nameof(upperLevel));
            if (hist.Length != 4) 
                throw new ArgumentException("hist array must have length 4");
            if (histSize.Length != 4) 
                throw new ArgumentException("histSize array must have length 4");
            if (lowerLevel.Length != 4) 
                throw new ArgumentException("lowerLevel array must have length 4");
            if (upperLevel.Length != 4) 
                throw new ArgumentException("upperLevel array must have length 4");

            src.ThrowIfDisposed();
            IntPtr[] histPtrs = new IntPtr[4];
            for (int i = 0; i < 4; i++)
            {
                if (hist[i] == null) 
                    throw new ArgumentNullException($"hist[{i}]");
                histPtrs[i] = hist[i].CvPtr;
            }

            NativeMethods.HandleException(
                NativeMethods.cuda_histEven_multi(src.CvPtr, histPtrs, histSize, lowerLevel, upperLevel, ToPtr(stream)));

            GC.KeepAlive(src);
            foreach (var h in hist)
                GC.KeepAlive(h);
        }

        #endregion

        #region HistRange
        /// <summary>
        /// Calculates a histogram with bins determined by the levels array.
        /// </summary>
        public static void HistRange(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray hist,
            OpenCvSharp.Cuda.InputArray levels, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (hist is null) 
                throw new ArgumentNullException(nameof(hist));
            if (levels is null) 
                throw new ArgumentNullException(nameof(levels));

            src.ThrowIfDisposed();
            hist.ThrowIfNotReady();
            levels.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_histRange(src.CvPtr, hist.CvPtr, levels.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(levels);
            hist.Fix();
        }

        /// <summary>
        /// Calculates a histogram with bins determined by the levels array for each channel (up to 4).
        /// </summary>
        public static void HistRange(OpenCvSharp.Cuda.InputArray src, GpuMat[] hist, GpuMat[] levels, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (hist is null)
                throw new ArgumentNullException(nameof(hist));
            if (levels is null)
                throw new ArgumentNullException(nameof(levels));
            if (hist.Length != 4) 
                throw new ArgumentException("hist must be length 4");
            if (levels.Length != 4) 
                throw new ArgumentException("levels must be length 4");

            src.ThrowIfDisposed();
            IntPtr[] histPtrs = new IntPtr[4];
            IntPtr[] levelsPtrs = new IntPtr[4];
            for (int i = 0; i < 4; i++)
            {
                histPtrs[i] = hist[i]?.CvPtr ?? IntPtr.Zero;
                levelsPtrs[i] = levels[i]?.CvPtr ?? IntPtr.Zero;
            }

            NativeMethods.HandleException(
                NativeMethods.cuda_histRange_multi(src.CvPtr, histPtrs, levelsPtrs, ToPtr(stream)));

            GC.KeepAlive(src);
            foreach (var h in hist) if (h != null) GC.KeepAlive(h);
            foreach (var l in levels) if (l != null) GC.KeepAlive(l);
        }

        #endregion

        #region NumMoments

        /// <summary>
        /// Returns the number of image moments less than or equal to the largest image moments order.
        /// </summary>
        /// <param name="order">Order of moments.</param>
        /// <returns>Number of moments (buffer size required).</returns>
        public static int NumMoments(MomentsOrder order)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_numMoments((int)order, out var ret));

            return ret;
        }

        #endregion

        #region SpatialMoments
        /// <summary>
        /// Calculates all of the spatial moments up to the 3rd order of a rasterized shape (Asynchronous).
        /// </summary>
        /// <param name="src">Raster image (8-bit 1-channel or floating-point 2D array).</param>
        /// <param name="moments">Destination 1D matrix on GPU containing raw moment values.</param>
        /// <param name="binaryImage">If true, all non-zero image pixels are treated as 1's.</param>
        /// <param name="order">Order of moments to compute.</param>
        /// <param name="momentsType">Type of moments (CV_32F or CV_64F).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void SpatialMoments(OpenCvSharp.Cuda.InputArray src,  OpenCvSharp.Cuda.OutputArray moments,
            bool binaryImage = false,  MomentsOrder order = MomentsOrder.ThirdOrder,
            MatType? momentsType = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (moments is null) 
                throw new ArgumentNullException(nameof(moments));

            src.ThrowIfDisposed();
            moments.ThrowIfNotReady();

            int type = momentsType?.Value ?? (int)MatType.CV_64F;

            NativeMethods.HandleException(
                NativeMethods.cuda_spatialMoments(
                    src.CvPtr,
                    moments.CvPtr,
                    binaryImage ? 1 : 0,
                    (int)order,
                    type,
                    ToPtr(stream)));

            moments.Fix();
            GC.KeepAlive(src);
        }

        #endregion

        #region SwapChannels
        /// <summary>
        /// Exchanges the color channels of an image in-place.
        /// </summary>
        /// <param name="image">Source and destination image. Must be 4-channel (CV_8UC4).</param>
        /// <param name="dstOrder">Integer array describing how to slot the source channels into the destination. Must have length 4.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void SwapChannels(OpenCvSharp.Cuda.InputArray image, int[] dstOrder, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (image is null) 
                throw new ArgumentNullException(nameof(image));
            if (dstOrder is null) 
                throw new ArgumentNullException(nameof(dstOrder));
            if (dstOrder.Length != 4) 
                throw new ArgumentException("dstOrder must have exactly 4 elements.", nameof(dstOrder));

            image.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_swapChannels(image.CvPtr, dstOrder, ToPtr(stream)));

            GC.KeepAlive(image);
        }

        #endregion


    }
}
