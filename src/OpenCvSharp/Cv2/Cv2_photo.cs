using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
                throw new ArgumentNullException("src");
            if (inpaintMask == null)
                throw new ArgumentNullException("inpaintMask");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            inpaintMask.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_inpaint(src.CvPtr, inpaintMask.CvPtr, dst.CvPtr, inpaintRadius, (int)flags);
            dst.Fix();
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_fastNlMeansDenoising(src.CvPtr, dst.CvPtr, h, templateWindowSize, searchWindowSize);
            dst.Fix();
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
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.photo_fastNlMeansDenoisingColored(src.CvPtr, dst.CvPtr, h, hColor, templateWindowSize, searchWindowSize);
            dst.Fix();
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
                throw new ArgumentNullException("srcImgs");
            if (dst == null)
                throw new ArgumentNullException("dst");
            dst.ThrowIfNotReady();
            IntPtr[] srcImgPtrs = EnumerableEx.SelectPtrs(srcImgs);

            NativeMethods.photo_fastNlMeansDenoisingMulti(srcImgPtrs, srcImgPtrs.Length, dst.CvPtr, imgToDenoiseIndex, 
                templateWindowSize, h, templateWindowSize, searchWindowSize);
            dst.Fix();
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
            FastNlMeansDenoisingMulti(srcImgsAsArrays, dst, imgToDenoiseIndex, templateWindowSize, 
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
                throw new ArgumentNullException("srcImgs");
            if (dst == null)
                throw new ArgumentNullException("dst");
            dst.ThrowIfNotReady();
            IntPtr[] srcImgPtrs = EnumerableEx.SelectPtrs(srcImgs);

            NativeMethods.photo_fastNlMeansDenoisingColoredMulti(srcImgPtrs, srcImgPtrs.Length, dst.CvPtr, imgToDenoiseIndex,
                templateWindowSize, h, hColor, templateWindowSize, searchWindowSize);
            dst.Fix();
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
            FastNlMeansDenoisingColoredMulti(srcImgsAsArrays, dst, imgToDenoiseIndex, templateWindowSize,
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
                throw new ArgumentNullException("observations");
            if (result == null) 
                throw new ArgumentNullException("result");

            IntPtr[] observationsPtrs = EnumerableEx.SelectPtrs(observations);
            NativeMethods.photo_denoise_TVL1(observationsPtrs, observationsPtrs.Length, result.CvPtr, lambda, niters);
            GC.KeepAlive(observations);
            GC.KeepAlive(result);
        }
    }
}
