using System;

namespace OpenCvSharp.XPhoto
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// cv::xphoto functions
    /// </summary>
    public static class CvXPhoto
    {
        #region Inpaint

        /// <summary>
        /// The function implements different single-image inpainting algorithms.
        /// </summary>
        /// <param name="src">source image, it could be of any type and any number of channels from 1 to 4. In case of 3- and 4-channels images the function expect them in CIELab colorspace or similar one, where first color component shows intensity, while second and third shows colors. Nonetheless you can try any colorspaces.</param>
        /// <param name="mask">mask (CV_8UC1), where non-zero pixels indicate valid image area, while zero pixels indicate area to be inpainted</param>
        /// <param name="dst">destination image</param>
        /// <param name="algorithm">see OpenCvSharp.XPhoto.InpaintTypes</param>
        public static void Inpaint(Mat src, Mat mask, Mat dst, InpaintTypes algorithm)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            mask.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.xphoto_inpaint(src.CvPtr, mask.CvPtr, dst.CvPtr, (int)algorithm);
            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            GC.KeepAlive(dst);
        }

        #endregion

        #region WhiteBalance

        /// <summary>
        /// Implements an efficient fixed-point approximation for applying channel gains, 
        /// which is the last step of multiple white balance algorithms.
        /// </summary>
        /// <param name="src">Input three-channel image in the BGR color space (either CV_8UC3 or CV_16UC3)</param>
        /// <param name="dst">Output image of the same size and type as src.</param>
        /// <param name="gainB">gain for the B channel</param>
        /// <param name="gainG">gain for the G channel</param>
        /// <param name="gainR">gain for the R channel</param>
        public static void ApplyChannelGains(InputArray src, OutputArray dst, float gainB, float gainG, float gainR)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.xphoto_applyChannelGains(src.CvPtr, dst.CvPtr, gainB, gainG, gainR);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Creates an instance of GrayworldWB
        /// </summary>
        /// <returns></returns>
        public static GrayworldWB CreateGrayworldWB()
        {
            return GrayworldWB.Create();
        }

        /// <summary>
        /// Creates an instance of LearningBasedWB
        /// </summary>
        /// <param name="model">Path to a .yml file with the model. If not specified, the default model is used</param>
        /// <returns></returns>
        public static LearningBasedWB CreateLearningBasedWB(string model)
        {
            return LearningBasedWB.Create(model);
        }

        /// <summary>
        /// Creates an instance of SimpleWB
        /// </summary>
        /// <returns></returns>
        public static SimpleWB CreateSimpleWB()
        {
            return SimpleWB.Create();
        }

        #endregion

        #region Denoising

        /// <summary>
        /// The function implements simple dct-based denoising
        /// </summary>
        /// <remarks>
        /// http://www.ipol.im/pub/art/2011/ys-dct/
        /// </remarks>
        /// <param name="src">source image</param>
        /// <param name="dst">destination image</param>
        /// <param name="sigma">expected noise standard deviation</param>
        /// <param name="psize">size of block side where dct is computed</param>
        public static void DctDenoising(Mat src, Mat dst, double sigma, int psize = 16)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            NativeMethods.xphoto_dctDenoising(src.CvPtr, dst.CvPtr, sigma, psize);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// Performs image denoising using the Block-Matching and 3D-filtering algorithm 
        /// (http://www.cs.tut.fi/~foi/GCF-BM3D/BM3D_TIP_2007.pdf) with several computational 
        /// optimizations.Noise expected to be a gaussian white noise.
        /// </summary>
        /// <param name="src">Input 8-bit or 16-bit 1-channel image.</param>
        /// <param name="dstStep1">Output image of the first step of BM3D with the same size and type as src.</param>
        /// <param name="dstStep2">Output image of the second step of BM3D with the same size and type as src.</param>
        /// <param name="h">Parameter regulating filter strength. Big h value perfectly removes noise but also 
        /// removes image details, smaller h value preserves details but also preserves some noise.</param>
        /// <param name="templateWindowSize">Size in pixels of the template patch that is used for block-matching. Should be power of 2.</param>
        /// <param name="searchWindowSize">Size in pixels of the window that is used to perform block-matching.
        ///  Affect performance linearly: greater searchWindowsSize - greater denoising time. Must be larger than templateWindowSize.</param>
        /// <param name="blockMatchingStep1">Block matching threshold for the first step of BM3D (hard thresholding),
        /// i.e.maximum distance for which two blocks are considered similar.Value expressed in euclidean distance.</param>
        /// <param name="blockMatchingStep2">Block matching threshold for the second step of BM3D (Wiener filtering),
        /// i.e.maximum distance for which two blocks are considered similar. Value expressed in euclidean distance.</param>
        /// <param name="groupSize">Maximum size of the 3D group for collaborative filtering.</param>
        /// <param name="slidingStep">Sliding step to process every next reference block.</param>
        /// <param name="beta">Kaiser window parameter that affects the sidelobe attenuation of the transform of the 
        /// window.Kaiser window is used in order to reduce border effects.To prevent usage of the window, set beta to zero.</param>
        /// <param name="normType">Norm used to calculate distance between blocks. L2 is slower than L1 but yields more accurate results.</param>
        /// <param name="step">Step of BM3D to be executed. Allowed are only BM3D_STEP1 and BM3D_STEPALL. 
        /// BM3D_STEP2 is not allowed as it requires basic estimate to be present.</param>
        /// <param name="transformType">Type of the orthogonal transform used in collaborative filtering step. 
        /// Currently only Haar transform is supported.</param>
        public static void Bm3dDenoising(
            InputArray src,
            InputOutputArray dstStep1,
            OutputArray dstStep2,
            float h = 1,
            int templateWindowSize = 4,
            int searchWindowSize = 16,
            int blockMatchingStep1 = 2500,
            int blockMatchingStep2 = 400,
            int groupSize = 8,
            int slidingStep = 1,
            float beta = 2.0f,
            NormTypes normType = NormTypes.L2,
            Bm3dSteps step = Bm3dSteps.STEPALL,
            TransformTypes transformType = TransformTypes.HAAR)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dstStep1 == null)
                throw new ArgumentNullException(nameof(dstStep1));
            if (dstStep2 == null)
                throw new ArgumentNullException(nameof(dstStep2));

            src.ThrowIfDisposed();
            dstStep1.ThrowIfNotReady();
            dstStep2.ThrowIfNotReady();

            NativeMethods.xphoto_bm3dDenoising1(src.CvPtr, dstStep1.CvPtr, dstStep2.CvPtr, h, templateWindowSize,
                searchWindowSize, blockMatchingStep1, blockMatchingStep2, groupSize, slidingStep, beta, (int) normType,
                (int) step, (int) transformType);

            GC.KeepAlive(src);
            dstStep1.Fix();
            dstStep2.Fix();
        }

        /// <summary>
        /// Performs image denoising using the Block-Matching and 3D-filtering algorithm 
        /// (http://www.cs.tut.fi/~foi/GCF-BM3D/BM3D_TIP_2007.pdf) with several computational optimizations.Noise expected to be a gaussian white noise.
        /// </summary>
        /// <param name="src">Input 8-bit or 16-bit 1-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src.</param>
        /// <param name="h">Parameter regulating filter strength. Big h value perfectly removes noise but also 
        /// removes image details, smaller h value preserves details but also preserves some noise.</param>
        /// <param name="templateWindowSize">Size in pixels of the template patch that is used for block-matching. Should be power of 2.</param>
        /// <param name="searchWindowSize">Size in pixels of the window that is used to perform block-matching.
        ///  Affect performance linearly: greater searchWindowsSize - greater denoising time. Must be larger than templateWindowSize.</param>
        /// <param name="blockMatchingStep1">Block matching threshold for the first step of BM3D (hard thresholding),
        /// i.e.maximum distance for which two blocks are considered similar.Value expressed in euclidean distance.</param>
        /// <param name="blockMatchingStep2">Block matching threshold for the second step of BM3D (Wiener filtering),
        /// i.e.maximum distance for which two blocks are considered similar. Value expressed in euclidean distance.</param>
        /// <param name="groupSize">Maximum size of the 3D group for collaborative filtering.</param>
        /// <param name="slidingStep">Sliding step to process every next reference block.</param>
        /// <param name="beta">Kaiser window parameter that affects the sidelobe attenuation of the transform of the 
        /// window.Kaiser window is used in order to reduce border effects.To prevent usage of the window, set beta to zero.</param>
        /// <param name="normType">Norm used to calculate distance between blocks. L2 is slower than L1 but yields more accurate results.</param>
        /// <param name="step">Step of BM3D to be executed. Allowed are only BM3D_STEP1 and BM3D_STEPALL. 
        /// BM3D_STEP2 is not allowed as it requires basic estimate to be present.</param>
        /// <param name="transformType">Type of the orthogonal transform used in collaborative filtering step. 
        /// Currently only Haar transform is supported.</param>
        public static void Bm3dDenoising(
            InputArray src,
            OutputArray dst,
            float h = 1,
            int templateWindowSize = 4,
            int searchWindowSize = 16,
            int blockMatchingStep1 = 2500,
            int blockMatchingStep2 = 400,
            int groupSize = 8,
            int slidingStep = 1,
            float beta = 2.0f,
            NormTypes normType = NormTypes.L2,
            Bm3dSteps step = Bm3dSteps.STEPALL,
            TransformTypes transformType = TransformTypes.HAAR)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.xphoto_bm3dDenoising2(src.CvPtr, dst.CvPtr, h, templateWindowSize,
                searchWindowSize, blockMatchingStep1, blockMatchingStep2, groupSize, slidingStep, beta, (int)normType,
                (int)step, (int)transformType);

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion
    }
}
