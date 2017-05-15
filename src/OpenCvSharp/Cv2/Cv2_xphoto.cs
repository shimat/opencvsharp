using System;
using OpenCvSharp.XPhoto;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class Cv2
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

        public static GrayworldWB CreateGrayworldWB()
        {
            var ptr = NativeMethods.xphoto_createGrayworldWB();
            return new GrayworldWB(ptr);
        }

        public static LearningBasedWB CreateLearningBasedWB(string model)
        {
            var ptr = NativeMethods.xphoto_createLearningBasedWB(model ?? "");
            return new LearningBasedWB(ptr);
        }

        public static SimpleWB CreateSimpleWB()
        {
            var ptr = NativeMethods.xphoto_createSimpleWB();
            return new SimpleWB(ptr);
        }

        #endregion
    }
}
