using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.XImgProc;

namespace OpenCvSharp
{
    static partial class Cv2
    {
        /// <summary>
        /// Applies Niblack thresholding to input image.
        /// </summary> 
        /// <remarks><![CDATA[
        /// The function transforms a grayscale image to a binary image according to the formulae:
        /// -   **THRESH_BINARY**
        /// \f[dst(x, y) =  \fork{\texttt{maxValue }
        /// }{if \(src(x, y) > T(x, y)\)}{0}{otherwise}\f]
        /// -   ** THRESH_BINARY_INV**
        /// \f[dst(x, y) =  \fork{0}{if \(src(x, y) > T(x, y)\)}{\texttt{maxValue}}{otherwise}\f]
        /// where \f$T(x, y)\f$ is a threshold calculated individually for each pixel.
        /// The threshold value \f$T(x, y)\f$ is the mean minus \f$ delta \f$ times standard deviation
        /// of \f$\texttt{blockSize} \times\texttt{blockSize}\f$ neighborhood of \f$(x, y)\f$.
        /// The function can't process the image in-place.
        /// ]]></remarks>
        /// <param name="src">Source 8-bit single-channel image.</param>
        /// <param name="dst">Destination image of the same size and the same type as src.</param>
        /// <param name="maxValue">Non-zero value assigned to the pixels for which the condition is satisfied,
        /// used with the THRESH_BINARY and THRESH_BINARY_INV thresholding types.</param>
        /// <param name="type">Thresholding type, see cv::ThresholdTypes.</param>
        /// <param name="blockSize">Size of a pixel neighborhood that is used to calculate a threshold value for the pixel: 3, 5, 7, and so on.</param>
        /// <param name="delta">Constant multiplied with the standard deviation and subtracted from the mean.
        /// Normally, it is taken to be a real number between 0 and 1.</param>
        public static void NiblackThreshold(
            InputArray src, OutputArray dst,
            double maxValue, ThresholdTypes type, int blockSize, double delta)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.ximgproc_niBlackThreshold(src.CvPtr, dst.CvPtr, maxValue, (int)type, blockSize, delta);

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Applies a binary blob thinning operation, to achieve a skeletization of the input image.
        /// The function transforms a binary blob image into a skeletized form using the technique of Zhang-Suen.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel image, containing binary blobs, with blobs having 255 pixel values.</param>
        /// <param name="dst">Destination image of the same size and the same type as src. The function can work in-place.</param>
        /// <param name="thinningType">Value that defines which thinning algorithm should be used. </param>
        public static void Thinning(
            InputArray src, OutputArray dst,
            ThinningTypes thinningType = ThinningTypes.ZHANGSUEN)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.ximgproc_thinning(src.CvPtr, dst.CvPtr, (int)thinningType);

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Creates a smart pointer to a FastLineDetector object and initializes it
        /// </summary>
        /// <param name="lengthThreshold">Segment shorter than this will be discarded</param>
        /// <param name="distanceThreshold"> A point placed from a hypothesis line segment farther than 
        /// this will be regarded as an outlier</param>
        /// <param name="cannyTh1">First threshold for hysteresis procedure in Canny()</param>
        /// <param name="cannyTh2">Second threshold for hysteresis procedure in Canny()</param>
        /// <param name="cannyApertureSize">Aperturesize for the sobel operator in Canny()</param>
        /// <param name="doMerge">If true, incremental merging of segments will be perfomred</param>
        /// <returns></returns>
        public static FastLineDetector CreateFastLineDetector(
            int lengthThreshold = 10, float distanceThreshold = 1.414213562f,
            double cannyTh1 = 50.0, double cannyTh2 = 50.0, int cannyApertureSize = 3,
            bool doMerge = false)
        {
            return FastLineDetector.Create(lengthThreshold, distanceThreshold, cannyTh1, cannyTh2, cannyApertureSize, doMerge);
        }
    }
}
