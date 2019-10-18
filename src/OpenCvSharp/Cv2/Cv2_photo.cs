using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    static partial class Cv2
    {
        #region Inpaint
        /// <summary>
        /// restores the damaged image areas using one of the available intpainting algorithms
        /// </summary>
        /// <param name="src"></param>
        /// <param name="inpaintMask"></param>
        /// <param name="dst"></param>
        /// <param name="inpaintRadius"></param>
        /// <param name="flags"></param>
        public static void Inpaint(InputArray src, InputArray inpaintMask,
            OutputArray dst, double inpaintRadius, InpaintMethod flags)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (inpaintMask == null)
                throw new ArgumentNullException(nameof(inpaintMask));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            inpaintMask.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_inpaint(src.CvPtr, inpaintMask.CvPtr, dst.CvPtr, inpaintRadius, (int)flags);
            dst.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(inpaintMask);
        }
        #endregion

        #region FastNlMeansDenoising
        /// <summary>
        /// Perform image denoising using Non-local Means Denoising algorithm 
        /// with several computational optimizations. Noise expected to be a gaussian white noise
        /// </summary>
        /// <param name="src">Input 8-bit 1-channel, 2-channel or 3-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src .</param>
        /// <param name="h">
        /// Parameter regulating filter strength. Big h value perfectly removes noise but also removes image details, 
        /// smaller h value preserves details but also preserves some noise</param>
        /// <param name="templateWindowSize">
        /// Size in pixels of the template patch that is used to compute weights. Should be odd. Recommended value 7 pixels</param>
        /// <param name="searchWindowSize">
        /// Size in pixels of the window that is used to compute weighted average for given pixel. 
        /// Should be odd. Affect performance linearly: greater searchWindowsSize - greater denoising time. Recommended value 21 pixels</param>
        public static void FastNlMeansDenoising(InputArray src, OutputArray dst, float h = 3,
            int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_fastNlMeansDenoising(src.CvPtr, dst.CvPtr, h, templateWindowSize, searchWindowSize);
            dst.Fix();
            GC.KeepAlive(src);
        }
        #endregion
        #region FastNlMeansDenoisingColored

        /// <summary>
        /// Modification of fastNlMeansDenoising function for colored images
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src.</param>
        /// <param name="h">Parameter regulating filter strength for luminance component. 
        /// Bigger h value perfectly removes noise but also removes image details, smaller h value preserves details but also preserves some noise</param>
        /// <param name="hColor">The same as h but for color components. For most images value equals 10 will be enought 
        /// to remove colored noise and do not distort colors</param>
        /// <param name="templateWindowSize">
        /// Size in pixels of the template patch that is used to compute weights. Should be odd. Recommended value 7 pixels</param>
        /// <param name="searchWindowSize">
        /// Size in pixels of the window that is used to compute weighted average for given pixel. Should be odd. 
        /// Affect performance linearly: greater searchWindowsSize - greater denoising time. Recommended value 21 pixels</param>
        public static void FastNlMeansDenoisingColored(InputArray src, OutputArray dst,
            float h = 3, float hColor = 3,
            int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_fastNlMeansDenoisingColored(src.CvPtr, dst.CvPtr, h, hColor, templateWindowSize, searchWindowSize);
            dst.Fix();
            GC.KeepAlive(src);
        }
        #endregion
        #region FastNlMeansDenoisingMulti
        /// <summary>
        /// Modification of fastNlMeansDenoising function for images sequence where consequtive images have been captured 
        /// in small period of time. For example video. This version of the function is for grayscale images or for manual manipulation with colorspaces.
        /// </summary>
        /// <param name="srcImgs">Input 8-bit 1-channel, 2-channel or 3-channel images sequence. All images should have the same type and size.</param>
        /// <param name="dst"> Output image with the same size and type as srcImgs images.</param>
        /// <param name="imgToDenoiseIndex">Target image to denoise index in srcImgs sequence</param>
        /// <param name="temporalWindowSize">Number of surrounding images to use for target image denoising. 
        /// Should be odd. Images from imgToDenoiseIndex - temporalWindowSize / 2 to imgToDenoiseIndex - temporalWindowSize / 2 
        /// from srcImgs will be used to denoise srcImgs[imgToDenoiseIndex] image.</param>
        /// <param name="h">Parameter regulating filter strength for luminance component. Bigger h value perfectly removes noise but also removes image details, 
        /// smaller h value preserves details but also preserves some noise</param>
        /// <param name="templateWindowSize">Size in pixels of the template patch that is used to compute weights. Should be odd. Recommended value 7 pixels</param>
        /// <param name="searchWindowSize">Size in pixels of the window that is used to compute weighted average for given pixel. 
        /// Should be odd. Affect performance linearly: greater searchWindowsSize - greater denoising time. Recommended value 21 pixels</param>
        public static void FastNlMeansDenoisingMulti(IEnumerable<InputArray> srcImgs, OutputArray dst,
            int imgToDenoiseIndex, int temporalWindowSize,
            float h = 3, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (srcImgs == null)
                throw new ArgumentNullException(nameof(srcImgs));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();
            IntPtr[] srcImgPtrs = EnumerableEx.SelectPtrs(srcImgs);

            NativeMethods.photo_fastNlMeansDenoisingMulti(srcImgPtrs, srcImgPtrs.Length, dst.CvPtr, imgToDenoiseIndex, 
                temporalWindowSize, h, templateWindowSize, searchWindowSize);
            dst.Fix();
            GC.KeepAlive(srcImgs);
        }
        /// <summary>
        /// Modification of fastNlMeansDenoising function for images sequence where consequtive images have been captured 
        /// in small period of time. For example video. This version of the function is for grayscale images or for manual manipulation with colorspaces.
        /// </summary>
        /// <param name="srcImgs">Input 8-bit 1-channel, 2-channel or 3-channel images sequence. All images should have the same type and size.</param>
        /// <param name="dst"> Output image with the same size and type as srcImgs images.</param>
        /// <param name="imgToDenoiseIndex">Target image to denoise index in srcImgs sequence</param>
        /// <param name="temporalWindowSize">Number of surrounding images to use for target image denoising. 
        /// Should be odd. Images from imgToDenoiseIndex - temporalWindowSize / 2 to imgToDenoiseIndex - temporalWindowSize / 2 
        /// from srcImgs will be used to denoise srcImgs[imgToDenoiseIndex] image.</param>
        /// <param name="h">Parameter regulating filter strength for luminance component. Bigger h value perfectly removes noise but also removes image details, 
        /// smaller h value preserves details but also preserves some noise</param>
        /// <param name="templateWindowSize">Size in pixels of the template patch that is used to compute weights. Should be odd. Recommended value 7 pixels</param>
        /// <param name="searchWindowSize">Size in pixels of the window that is used to compute weighted average for given pixel. 
        /// Should be odd. Affect performance linearly: greater searchWindowsSize - greater denoising time. Recommended value 21 pixels</param>
        public static void FastNlMeansDenoisingMulti(IEnumerable<Mat> srcImgs, OutputArray dst,
            int imgToDenoiseIndex, int temporalWindowSize,
            float h = 3, int templateWindowSize = 7, int searchWindowSize = 21)
        {
            IEnumerable<InputArray> srcImgsAsArrays = EnumerableEx.Select(srcImgs, m => new InputArray(m));
            FastNlMeansDenoisingMulti(srcImgsAsArrays, dst, imgToDenoiseIndex, temporalWindowSize,
                h, templateWindowSize, searchWindowSize);
        }
        #endregion
        #region FastNlMeansDenoisingColoredMulti
        /// <summary>
        /// Modification of fastNlMeansDenoisingMulti function for colored images sequences
        /// </summary>
        /// <param name="srcImgs">Input 8-bit 3-channel images sequence. All images should have the same type and size.</param>
        /// <param name="dst">Output image with the same size and type as srcImgs images.</param>
        /// <param name="imgToDenoiseIndex">Target image to denoise index in srcImgs sequence</param>
        /// <param name="temporalWindowSize">Number of surrounding images to use for target image denoising. Should be odd. 
        /// Images from imgToDenoiseIndex - temporalWindowSize / 2 to imgToDenoiseIndex - temporalWindowSize / 2 from srcImgs 
        /// will be used to denoise srcImgs[imgToDenoiseIndex] image.</param>
        /// <param name="h">Parameter regulating filter strength for luminance component. Bigger h value perfectly removes noise 
        /// but also removes image details, smaller h value preserves details but also preserves some noise.</param>
        /// <param name="hColor"> The same as h but for color components.</param>
        /// <param name="templateWindowSize">Size in pixels of the template patch that is used to compute weights. Should be odd. Recommended value 7 pixels</param>
        /// <param name="searchWindowSize">Size in pixels of the window that is used to compute weighted average for given pixel. 
        /// Should be odd. Affect performance linearly: greater searchWindowsSize - greater denoising time. Recommended value 21 pixels</param>
        public static void FastNlMeansDenoisingColoredMulti(IEnumerable<InputArray> srcImgs, OutputArray dst,
            int imgToDenoiseIndex, int temporalWindowSize, float h = 3, float hColor = 3,
            int templateWindowSize = 7, int searchWindowSize = 21)
        {
            if (srcImgs == null)
                throw new ArgumentNullException(nameof(srcImgs));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            dst.ThrowIfNotReady();
            IntPtr[] srcImgPtrs = EnumerableEx.SelectPtrs(srcImgs);

            NativeMethods.photo_fastNlMeansDenoisingColoredMulti(srcImgPtrs, srcImgPtrs.Length, dst.CvPtr, imgToDenoiseIndex,
                temporalWindowSize, h, hColor, templateWindowSize, searchWindowSize);
            dst.Fix();
            GC.KeepAlive(srcImgs);
        }
        /// <summary>
        /// Modification of fastNlMeansDenoisingMulti function for colored images sequences
        /// </summary>
        /// <param name="srcImgs">Input 8-bit 3-channel images sequence. All images should have the same type and size.</param>
        /// <param name="dst">Output image with the same size and type as srcImgs images.</param>
        /// <param name="imgToDenoiseIndex">Target image to denoise index in srcImgs sequence</param>
        /// <param name="temporalWindowSize">Number of surrounding images to use for target image denoising. Should be odd. 
        /// Images from imgToDenoiseIndex - temporalWindowSize / 2 to imgToDenoiseIndex - temporalWindowSize / 2 from srcImgs 
        /// will be used to denoise srcImgs[imgToDenoiseIndex] image.</param>
        /// <param name="h">Parameter regulating filter strength for luminance component. Bigger h value perfectly removes noise 
        /// but also removes image details, smaller h value preserves details but also preserves some noise.</param>
        /// <param name="hColor"> The same as h but for color components.</param>
        /// <param name="templateWindowSize">Size in pixels of the template patch that is used to compute weights. Should be odd. Recommended value 7 pixels</param>
        /// <param name="searchWindowSize">Size in pixels of the window that is used to compute weighted average for given pixel. 
        /// Should be odd. Affect performance linearly: greater searchWindowsSize - greater denoising time. Recommended value 21 pixels</param>
        public static void FastNlMeansDenoisingColoredMulti(IEnumerable<Mat> srcImgs, OutputArray dst,
            int imgToDenoiseIndex, int temporalWindowSize, float h = 3, float hColor = 3,
            int templateWindowSize = 7, int searchWindowSize = 21)
        {
            IEnumerable<InputArray> srcImgsAsArrays = EnumerableEx.Select(srcImgs, m => new InputArray(m));
            FastNlMeansDenoisingColoredMulti(srcImgsAsArrays, dst, imgToDenoiseIndex, temporalWindowSize,
                h, hColor, templateWindowSize, searchWindowSize);
        }
        #endregion

        /// <summary>
        /// Primal-dual algorithm is an algorithm for solving special types of variational problems 
        /// (that is, finding a function to minimize some functional). As the image denoising, 
        /// in particular, may be seen as the variational problem, primal-dual algorithm then 
        /// can be used to perform denoising and this is exactly what is implemented.
        /// </summary>
        /// <param name="observations">This array should contain one or more noised versions 
        /// of the image that is to be restored.</param>
        /// <param name="result">Here the denoised image will be stored. There is no need to 
        /// do pre-allocation of storage space, as it will be automatically allocated, if necessary.</param>
        /// <param name="lambda">Corresponds to \f$\lambda\f$ in the formulas above. 
        /// As it is enlarged, the smooth (blurred) images are treated more favorably than 
        /// detailed (but maybe more noised) ones. Roughly speaking, as it becomes smaller, 
        /// the result will be more blur but more sever outliers will be removed.</param>
        /// <param name="niters"> Number of iterations that the algorithm will run. 
        /// Of course, as more iterations as better, but it is hard to quantitatively 
        /// refine this statement, so just use the default and increase it if the results are poor.</param>
// ReSharper disable once InconsistentNaming
        public static void DenoiseTVL1(
            IEnumerable<Mat> observations, Mat result, double lambda = 1.0, int niters = 30)
        {
            if (observations == null)
                throw new ArgumentNullException(nameof(observations));
            if (result == null) 
                throw new ArgumentNullException(nameof(result));

            IntPtr[] observationsPtrs = EnumerableEx.SelectPtrs(observations);
            NativeMethods.photo_denoise_TVL1(observationsPtrs, observationsPtrs.Length, result.CvPtr, lambda, niters);
            GC.KeepAlive(observations);
            GC.KeepAlive(result);
        }

        /// <summary>
        /// Transforms a color image to a grayscale image. It is a basic tool in digital 
        /// printing, stylized black-and-white photograph rendering, and in many single 
        /// channel image processing applications @cite CL12 .
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="grayscale">Output 8-bit 1-channel image.</param>
        /// <param name="colorBoost">Output 8-bit 3-channel image.</param>
        public static void Decolor(
            InputArray src, OutputArray grayscale, OutputArray colorBoost)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (grayscale == null) 
                throw new ArgumentNullException(nameof(grayscale));
            if (colorBoost == null)
                throw new ArgumentNullException(nameof(colorBoost));
            src.ThrowIfDisposed();
            grayscale.ThrowIfNotReady();
            colorBoost.ThrowIfNotReady();
            NativeMethods.photo_decolor(src.CvPtr, grayscale.CvPtr, colorBoost.CvPtr);
            GC.KeepAlive(src);
            grayscale.Fix();
            colorBoost.Fix();
        }

        /// <summary>
        /// Image editing tasks concern either global changes (color/intensity corrections, 
        /// filters, deformations) or local changes concerned to a selection. Here we are 
        /// interested in achieving local changes, ones that are restricted to a region 
        /// manually selected (ROI), in a seamless and effortless manner. The extent of 
        /// the changes ranges from slight distortions to complete replacement by novel 
        /// content @cite PM03 .
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="dst">Input 8-bit 3-channel image.</param>
        /// <param name="mask">Input 8-bit 1 or 3-channel image.</param>
        /// <param name="p">Point in dst image where object is placed.</param>
        /// <param name="blend">Output image with the same size and type as dst.</param>
        /// <param name="flags">Cloning method</param>
        public static void SeamlessClone(
            InputArray src, InputArray dst, InputArray mask, Point p,
            OutputArray blend, SeamlessCloneMethods flags)
        {
            if (src == null) 
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (blend == null)
                throw new ArgumentNullException(nameof(blend));
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            if (mask != null)
                mask.ThrowIfDisposed();
            blend.ThrowIfNotReady();

            NativeMethods.photo_seamlessClone(
                src.CvPtr, dst.CvPtr, ToPtr(mask), p, blend.CvPtr, (int)flags);

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            blend.Fix();
        }

        /// <summary>
        /// Given an original color image, two differently colored versions of this 
        /// image can be mixed seamlessly. Multiplication factor is between 0.5 to 2.5.
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="mask">Input 8-bit 1 or 3-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src.</param>
        /// <param name="redMul">R-channel multiply factor.</param>
        /// <param name="greenMul">G-channel multiply factor.</param>
        /// <param name="blueMul">B-channel multiply factor.</param>
        public static void ColorChange(
            InputArray src, InputArray mask, OutputArray dst, 
            float redMul = 1.0f, float greenMul = 1.0f, float blueMul = 1.0f)
        {
            if (src == null) 
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            if (mask != null)
                mask.ThrowIfDisposed();

            NativeMethods.photo_colorChange(
                src.CvPtr, ToPtr(mask), dst.CvPtr, redMul, greenMul, blueMul);

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Applying an appropriate non-linear transformation to the gradient field inside 
        /// the selection and then integrating back with a Poisson solver, modifies locally 
        /// the apparent illumination of an image.
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="mask">Input 8-bit 1 or 3-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src.</param>
        /// <param name="alpha">Value ranges between 0-2.</param>
        /// <param name="beta">Value ranges between 0-2.</param>
        /// <remarks>
        /// This is useful to highlight under-exposed foreground objects or to reduce specular reflections.
        /// </remarks>
        public static void IlluminationChange(
            InputArray src, InputArray mask, OutputArray dst,
            float alpha = 0.2f, float beta = 0.4f)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            if (mask != null)
                mask.ThrowIfDisposed();

            NativeMethods.photo_illuminationChange(
                src.CvPtr, ToPtr(mask), dst.CvPtr, alpha, beta);

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// By retaining only the gradients at edge locations, before integrating with the 
        /// Poisson solver, one washes out the texture of the selected region, giving its 
        /// contents a flat aspect. Here Canny Edge Detector is used.
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="mask">Input 8-bit 1 or 3-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src.</param>
        /// <param name="lowThreshold">Range from 0 to 100.</param>
        /// <param name="highThreshold">Value &gt; 100.</param>
        /// <param name="kernelSize">The size of the Sobel kernel to be used.</param>
        public static void TextureFlattening(
            InputArray src, InputArray mask, OutputArray dst,
            float lowThreshold = 30, float highThreshold = 45,
            int kernelSize = 3)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            if (mask != null)
                mask.ThrowIfDisposed();

            NativeMethods.photo_textureFlattening(
                src.CvPtr, ToPtr(mask), dst.CvPtr, lowThreshold, highThreshold, kernelSize);

            GC.KeepAlive(src);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
        /// Filtering is the fundamental operation in image and video processing. 
        /// Edge-preserving smoothing filters are used in many different applications @cite EM11 .
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="dst">Output 8-bit 3-channel image.</param>
        /// <param name="flags">Edge preserving filters</param>
        /// <param name="sigmaS">Range between 0 to 200.</param>
        /// <param name="sigmaR">Range between 0 to 1.</param>
        public static void EdgePreservingFilter(
            InputArray src, OutputArray dst, 
            EdgePreservingMethods flags = EdgePreservingMethods.RecursFilter,
            float sigmaS = 60, float sigmaR = 0.4f)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.photo_edgePreservingFilter(
                src.CvPtr, dst.CvPtr, (int)flags, sigmaS, sigmaR);

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// This filter enhances the details of a particular image.
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src.</param>
        /// <param name="sigmaS">Range between 0 to 200.</param>
        /// <param name="sigmaR">Range between 0 to 1.</param>
        public static void DetailEnhance(
            InputArray src, OutputArray dst, 
            float sigmaS = 10, float sigmaR = 0.15f)
        {
            if (src == null) 
                throw new ArgumentNullException(nameof(src));
            if (dst == null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.photo_detailEnhance(
                src.CvPtr, dst.CvPtr, sigmaS, sigmaR);

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Pencil-like non-photorealistic line drawing
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="dst1">Output 8-bit 1-channel image.</param>
        /// <param name="dst2">Output image with the same size and type as src.</param>
        /// <param name="sigmaS">Range between 0 to 200.</param>
        /// <param name="sigmaR">Range between 0 to 1.</param>
        /// <param name="shadeFactor">Range between 0 to 0.1.</param>
        public static void PencilSketch(
            InputArray src, OutputArray dst1, OutputArray dst2,
            float sigmaS = 60, float sigmaR = 0.07f, float shadeFactor = 0.02f)
        {
            if (src == null) 
                throw new ArgumentNullException(nameof(src));
            if (dst1 == null)
                throw new ArgumentNullException(nameof(dst1));
            if (dst2 == null)
                throw new ArgumentNullException(nameof(dst2));

            src.ThrowIfDisposed();
            dst1.ThrowIfNotReady();
            dst2.ThrowIfNotReady();

            NativeMethods.photo_pencilSketch(
                src.CvPtr, dst1.CvPtr, dst2.CvPtr, sigmaS, sigmaR, shadeFactor);

            GC.KeepAlive(src);
            dst1.Fix();
            dst2.Fix();
        }

        /// <summary>
        /// Stylization aims to produce digital imagery with a wide variety of effects 
        /// not focused on photorealism. Edge-aware filters are ideal for stylization, 
        /// as they can abstract regions of low contrast while preserving, or enhancing, 
        /// high-contrast features.
        /// </summary>
        /// <param name="src">Input 8-bit 3-channel image.</param>
        /// <param name="dst">Output image with the same size and type as src.</param>
        /// <param name="sigmaS">Range between 0 to 200.</param>
        /// <param name="sigmaR">Range between 0 to 1.</param>
        public static void Stylization(
            InputArray src, OutputArray dst,
            float sigmaS = 60, float sigmaR = 0.45f)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.photo_stylization(
                src.CvPtr, dst.CvPtr, sigmaS, sigmaR);

            GC.KeepAlive(src);
            dst.Fix();
        }
    }
}
