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
    }
}
