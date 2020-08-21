using System;
using OpenCvSharp.Util;
using OpenCvSharp.XImgProc.Segmentation;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// cv::ximgproc functions
    /// </summary>
    public static class CvXImgProc
    {
        /// <summary>
        /// Strategy for the selective search segmentation algorithm.
        /// </summary>
        public static class Segmentation
        {
            /// <summary>
            /// Create a new color-based strategy
            /// </summary>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyColor CreateSelectiveSearchSegmentationStrategyColor()
            {
                return SelectiveSearchSegmentationStrategyColor.Create();
            }

            /// <summary>
            /// Create a new size-based strategy
            /// </summary>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategySize CreateSelectiveSearchSegmentationStrategySize()
            {
                return SelectiveSearchSegmentationStrategySize.Create();
            }

            /// <summary>
            /// Create a new size-based strategy
            /// </summary>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyTexture CreateSelectiveSearchSegmentationStrategyTexture()
            {
                return SelectiveSearchSegmentationStrategyTexture.Create();
            }

            /// <summary>
            /// Create a new fill-based strategy
            /// </summary>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyFill CreateSelectiveSearchSegmentationStrategyFill()
            {
                return SelectiveSearchSegmentationStrategyFill.Create();
            }

            /// <summary>
            /// Create a new multiple strategy
            /// </summary>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyMultiple CreateSelectiveSearchSegmentationStrategyMultiple()
            {
                return SelectiveSearchSegmentationStrategyMultiple.Create();
            }

            /// <summary>
            /// Create a new multiple strategy and set one subtrategy
            /// </summary>
            /// <param name="s1">The first strategy</param>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyMultiple CreateSelectiveSearchSegmentationStrategyMultiple(
                SelectiveSearchSegmentationStrategy s1)
            {
                return SelectiveSearchSegmentationStrategyMultiple.Create(s1);
            }

            /// <summary>
            /// Create a new multiple strategy and set one subtrategy
            /// </summary>
            /// <param name="s1">The first strategy</param>
            /// <param name="s2">The second strategy</param>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyMultiple CreateSelectiveSearchSegmentationStrategyMultiple(
                SelectiveSearchSegmentationStrategy s1, SelectiveSearchSegmentationStrategy s2)
            {
                return SelectiveSearchSegmentationStrategyMultiple.Create(s1, s2);
            }

            /// <summary>
            /// Create a new multiple strategy and set one subtrategy
            /// </summary>
            /// <param name="s1">The first strategy</param>
            /// <param name="s2">The second strategy</param>
            /// <param name="s3">The third strategy</param>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyMultiple CreateSelectiveSearchSegmentationStrategyMultiple(
                SelectiveSearchSegmentationStrategy s1, SelectiveSearchSegmentationStrategy s2, SelectiveSearchSegmentationStrategy s3)
            {
                return SelectiveSearchSegmentationStrategyMultiple.Create(s1, s2, s3);
            }

            /// <summary>
            /// Create a new multiple strategy and set one subtrategy
            /// </summary>
            /// <param name="s1">The first strategy</param>
            /// <param name="s2">The second strategy</param>
            /// <param name="s3">The third strategy</param>
            /// <param name="s4">The forth strategy</param>
            /// <returns></returns>
            public static SelectiveSearchSegmentationStrategyMultiple CreateSelectiveSearchSegmentationStrategyMultiple(
                SelectiveSearchSegmentationStrategy s1, SelectiveSearchSegmentationStrategy s2, SelectiveSearchSegmentationStrategy s3, SelectiveSearchSegmentationStrategy s4)
            {
                return SelectiveSearchSegmentationStrategyMultiple.Create(s1, s2, s3, s4);
            }
        }

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
        /// <param name="k">The user-adjustable parameter used by Niblack and inspired techniques.For Niblack,
        /// this is normally a value between 0 and 1 that is multiplied with the standard deviation and subtracted from the mean.</param>
        /// <param name="binarizationMethod">Binarization method to use. By default, Niblack's technique is used.
        /// Other techniques can be specified, see cv::ximgproc::LocalBinarizationMethods.</param>
        /// <param name="r">The user-adjustable parameter used by Sauvola's technique. This is the dynamic range of standard deviation.</param>
        public static void NiblackThreshold(
            InputArray src, 
            OutputArray dst,
            double maxValue,
            ThresholdTypes type,
            int blockSize, 
            double k, 
            LocalBinarizationMethods binarizationMethod = LocalBinarizationMethods.Niblack,
            double r = 128)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_niBlackThreshold(src.CvPtr, dst.CvPtr, maxValue, (int)type, blockSize, k, (int)binarizationMethod, r));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
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

            NativeMethods.HandleException(
                NativeMethods.ximgproc_thinning(src.CvPtr, dst.CvPtr, (int)thinningType));

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Performs anisotropic diffusian on an image.
        /// The function applies Perona-Malik anisotropic diffusion to an image.
        /// </summary>
        /// <param name="src">Grayscale Source image.</param>
        /// <param name="dst">Destination image of the same size and the same number of channels as src.</param>
        /// <param name="alpha">The amount of time to step forward by on each iteration (normally, it's between 0 and 1).</param>
        /// <param name="k">sensitivity to the edges</param>
        /// <param name="niters">The number of iterations</param>
        public static void AnisotropicDiffusion(InputArray src, OutputArray dst, float alpha, float k, int niters)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_anisotropicDiffusion(src.CvPtr, dst.CvPtr, alpha, k, niters));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #region brightedges.hpp

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="edgeView"></param>
        /// <param name="contrast"></param>
        /// <param name="shortRange"></param>
        /// <param name="longRange"></param>
        public static void BrightEdges(Mat original, Mat edgeView, int contrast = 1, int shortRange = 3, int longRange = 9)
        {
            if (original == null)
                throw new ArgumentNullException(nameof(original));
            if (edgeView == null)
                throw new ArgumentNullException(nameof(edgeView));
            original.ThrowIfDisposed();
            edgeView.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_BrightEdges(original.CvPtr, edgeView.CvPtr, contrast, shortRange, longRange));

            GC.KeepAlive(original);
            GC.KeepAlive(edgeView);
        }

        #endregion

        #region color_match.hpp

        /// <summary>
        /// creates a quaternion image.
        /// </summary>
        /// <param name="img">Source 8-bit, 32-bit or 64-bit image, with 3-channel image.</param>
        /// <param name="qimg">result CV_64FC4 a quaternion image( 4 chanels zero channel and B,G,R).</param>
        public static void CreateQuaternionImage(InputArray img, OutputArray qimg)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (qimg == null)
                throw new ArgumentNullException(nameof(qimg));
            img.ThrowIfDisposed();
            qimg.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createQuaternionImage(img.CvPtr, qimg.CvPtr));

            GC.KeepAlive(img);
            qimg.Fix();
        }

        /// <summary>
        /// calculates conjugate of a quaternion image.
        /// </summary>
        /// <param name="qimg">quaternion image.</param>
        /// <param name="qcimg">conjugate of qimg</param>
        public static void QConj(InputArray qimg, OutputArray qcimg)
        {
            if (qimg == null)
                throw new ArgumentNullException(nameof(qimg));
            if (qcimg == null)
                throw new ArgumentNullException(nameof(qcimg));
            qimg.ThrowIfDisposed();
            qcimg.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_qconj(qimg.CvPtr, qcimg.CvPtr));

            GC.KeepAlive(qimg);
            qcimg.Fix();
        }

        /// <summary>
        /// divides each element by its modulus.
        /// </summary>
        /// <param name="qimg">quaternion image.</param>
        /// <param name="qnimg">conjugate of qimg</param>
        public static void QUnitary(InputArray qimg, OutputArray qnimg)
        {
            if (qimg == null)
                throw new ArgumentNullException(nameof(qimg));
            if (qnimg == null)
                throw new ArgumentNullException(nameof(qnimg));
            qimg.ThrowIfDisposed();
            qnimg.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_qunitary(qimg.CvPtr, qnimg.CvPtr));

            GC.KeepAlive(qimg);
            qnimg.Fix();
        }

        /// <summary>
        /// Calculates the per-element quaternion product of two arrays
        /// </summary>
        /// <param name="src1">quaternion image.</param>
        /// <param name="src2">quaternion image.</param>
        /// <param name="dst">product dst(I)=src1(I) . src2(I)</param>
        public static void QMultiply(InputArray src1, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException(nameof(src1));
            if (src2 == null)
                throw new ArgumentNullException(nameof(src2));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_qmultiply(src1.CvPtr, src2.CvPtr, dst.CvPtr));

            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            dst.Fix();
        }

        /// <summary>
        /// Performs a forward or inverse Discrete quaternion Fourier transform of a 2D quaternion array.
        /// </summary>
        /// <param name="img">quaternion image.</param>
        /// <param name="qimg">quaternion image in dual space.</param>
        /// <param name="flags">quaternion image in dual space. only DFT_INVERSE flags is supported</param>
        /// <param name="sideLeft">true the hypercomplex exponential is to be multiplied on the left (false on the right ).</param>
        public static void QDft(InputArray img, OutputArray qimg, DftFlags flags, bool sideLeft)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (qimg == null)
                throw new ArgumentNullException(nameof(qimg));
            img.ThrowIfDisposed();
            qimg.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_qdft(img.CvPtr, qimg.CvPtr, (int)flags, sideLeft ? 1 : 0));

            GC.KeepAlive(img);
            qimg.Fix();
        }

        /// <summary>
        /// Compares a color template against overlapped color image regions.
        /// </summary>
        /// <param name="img">Image where the search is running. It must be 3 channels image</param>
        /// <param name="templ">Searched template. It must be not greater than the source image and have 3 channels</param>
        /// <param name="result">Map of comparison results. It must be single-channel 64-bit floating-point</param>
        public static void ColorMatchTemplate(InputArray img, InputArray templ, OutputArray result)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (templ == null)
                throw new ArgumentNullException(nameof(templ));
            if (result == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            result.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_colorMatchTemplate(img.CvPtr, templ.CvPtr, result.CvPtr));

            GC.KeepAlive(img);
            GC.KeepAlive(templ);
            result.Fix();
        }

        #endregion

        #region deriche_filter.hpp

        /// <summary>
        /// Applies Y Deriche filter to an image.
        /// </summary>
        /// <param name="op">Source 8-bit or 16bit image, 1-channel or 3-channel image.</param>
        /// <param name="dst">result CV_32FC image with same number of channel than _op.</param>
        /// <param name="alpha">double see paper</param>
        /// <param name="omega">double see paper</param>
        public static void GradientDericheY(InputArray op, OutputArray dst, double alpha, double omega)
        {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            op.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientDericheY(op.CvPtr, dst.CvPtr, alpha, omega));

            GC.KeepAlive(op);
            dst.Fix();
        }

        /// <summary>
        /// Applies X Deriche filter to an image.
        /// </summary>
        /// <param name="op">Source 8-bit or 16bit image, 1-channel or 3-channel image.</param>
        /// <param name="dst">result CV_32FC image with same number of channel than _op.</param>
        /// <param name="alpha">double see paper</param>
        /// <param name="omega">double see paper</param>
        public static void GradientDericheX(InputArray op, OutputArray dst, double alpha, double omega)
        {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            op.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientDericheX(op.CvPtr, dst.CvPtr, alpha, omega));

            GC.KeepAlive(op);
            dst.Fix();
        }

        #endregion
        
        #region edgeboxes.hpp

        /// <summary>
        /// Creates a EdgeBoxes
        /// </summary>
        /// <param name="alpha">step size of sliding window search.</param>
        /// <param name="beta">nms threshold for object proposals.</param>
        /// <param name="eta">adaptation rate for nms threshold.</param>
        /// <param name="minScore">min score of boxes to detect.</param>
        /// <param name="maxBoxes">max number of boxes to detect.</param>
        /// <param name="edgeMinMag">edge min magnitude. Increase to trade off accuracy for speed.</param>
        /// <param name="edgeMergeThr">edge merge threshold. Increase to trade off accuracy for speed.</param>
        /// <param name="clusterMinMag">cluster min magnitude. Increase to trade off accuracy for speed.</param>
        /// <param name="maxAspectRatio">max aspect ratio of boxes.</param>
        /// <param name="minBoxArea">minimum area of boxes.</param>
        /// <param name="gamma">affinity sensitivity.</param>
        /// <param name="kappa">scale sensitivity.</param>
        /// <returns></returns>
        public static EdgeBoxes CreateEdgeBoxes(
            float alpha = 0.65f,
            float beta = 0.75f,
            float eta = 1,
            float minScore = 0.01f,
            int maxBoxes = 10000,
            float edgeMinMag = 0.1f,
            float edgeMergeThr = 0.5f,
            float clusterMinMag = 0.5f,
            float maxAspectRatio = 3,
            float minBoxArea = 1000,
            float gamma = 2,
            float kappa = 1.5f)
        {
            return EdgeBoxes.Create(
                alpha, beta, eta, minScore, maxBoxes, edgeMinMag, edgeMergeThr,
                clusterMinMag, maxAspectRatio, minBoxArea, gamma, kappa);
        }

        #endregion

        #region edge_filter.hpp

        /// <summary>
        /// Factory method, create instance of DTFilter and produce initialization routines.
        /// </summary>
        /// <param name="guide">guided image (used to build transformed distance, which describes edge structure of
        /// guided image).</param>
        /// <param name="sigmaSpatial">sigma_H parameter in the original article, it's similar to the sigma in the
        /// coordinate space into bilateralFilter.</param>
        /// <param name="sigmaColor">sigma_r parameter in the original article, it's similar to the sigma in the
        /// color space into bilateralFilter.</param>
        /// <param name="mode">one form three modes DTF_NC, DTF_RF and DTF_IC which corresponds to three modes for
        /// filtering 2D signals in the article.</param>
        /// <param name="numIters">optional number of iterations used for filtering, 3 is quite enough.</param>
        /// <returns></returns>
        public static DTFilter CreateDTFilter(
            InputArray guide, double sigmaSpatial, double sigmaColor,
            EdgeAwareFiltersList mode = EdgeAwareFiltersList.DTF_NC, int numIters = 3)
        {
            return OpenCvSharp.XImgProc.DTFilter.Create(guide, sigmaSpatial, sigmaColor, mode, numIters);
        }

        /// <summary>
        /// Simple one-line Domain Transform filter call. If you have multiple images to filter with the same
        /// guided image then use DTFilter interface to avoid extra computations on initialization stage.
        /// </summary>
        /// <param name="guide">guided image (also called as joint image) with unsigned 8-bit or floating-point 32-bit
        /// depth and up to 4 channels.</param>
        /// <param name="src">filtering image with unsigned 8-bit or floating-point 32-bit depth and up to 4 channels.</param>
        /// <param name="dst">destination image</param>
        /// <param name="sigmaSpatial">sigma_H parameter in the original article, it's similar to the sigma in the
        /// coordinate space into bilateralFilter.</param>
        /// <param name="sigmaColor">sigma_r parameter in the original article, it's similar to the sigma in the
        /// color space into bilateralFilter.</param>
        /// <param name="mode">one form three modes DTF_NC, DTF_RF and DTF_IC which corresponds to three modes for
        /// filtering 2D signals in the article.</param>
        /// <param name="numIters">optional number of iterations used for filtering, 3 is quite enough.</param>
        public static void DTFilter(InputArray guide, InputArray src, OutputArray dst, double sigmaSpatial,
            double sigmaColor, EdgeAwareFiltersList mode = EdgeAwareFiltersList.DTF_NC, int numIters = 3)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            guide.ThrowIfDisposed();
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_dtFilter(guide.CvPtr, src.CvPtr, dst.CvPtr, sigmaSpatial, sigmaColor, (int)mode, numIters));

            GC.KeepAlive(guide);
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Factory method, create instance of GuidedFilter and produce initialization routines.
        /// </summary>
        /// <param name="guide">guided image (or array of images) with up to 3 channels, if it have more then 3
        /// channels then only first 3 channels will be used.</param>
        /// <param name="radius">radius of Guided Filter.</param>
        /// <param name="eps">regularization term of Guided Filter. eps^2 is similar to the sigma in the color
        /// space into bilateralFilter.</param>
        /// <returns></returns>
        public static GuidedFilter CreateGuidedFilter(
            InputArray guide, int radius, double eps)
        {
            return OpenCvSharp.XImgProc.GuidedFilter.Create(guide, radius, eps);
        }

        /// <summary>
        /// Simple one-line Guided Filter call.
        ///
        /// If you have multiple images to filter with the same guided image then use GuidedFilter interface to
        /// avoid extra computations on initialization stage.
        /// </summary>
        /// <param name="guide">guided image (or array of images) with up to 3 channels, if it have more then 3
        /// channels then only first 3 channels will be used.</param>
        /// <param name="src">filtering image with any numbers of channels.</param>
        /// <param name="dst">output image.</param>
        /// <param name="radius">radius of Guided Filter.</param>
        /// <param name="eps">regularization term of Guided Filter. eps^2 is similar to the sigma in the color
        /// space into bilateralFilter.</param>
        /// <param name="dDepth">optional depth of the output image.</param>
        public static void GuidedFilter(
            InputArray guide, InputArray src, OutputArray dst, 
            int radius, double eps, int dDepth = -1)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            guide.ThrowIfDisposed();
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_guidedFilter(guide.CvPtr, src.CvPtr, dst.CvPtr, radius, eps, dDepth));

            GC.KeepAlive(guide);
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Factory method, create instance of AdaptiveManifoldFilter and produce some initialization routines.
        /// </summary>
        /// <param name="sigmaS">spatial standard deviation.</param>
        /// <param name="sigmaR">color space standard deviation, it is similar to the sigma in the color space into
        /// bilateralFilter.</param>
        /// <param name="adjustOutliers">optional, specify perform outliers adjust operation or not, (Eq. 9) in the
        /// original paper.</param>
        /// <returns></returns>
        public static AdaptiveManifoldFilter CreateAMFilter(
            double sigmaS, double sigmaR, bool adjustOutliers = false)
        {
            return AdaptiveManifoldFilter.Create(sigmaS, sigmaR, adjustOutliers);
        }

        /// <summary>
        /// Simple one-line Adaptive Manifold Filter call.
        /// </summary>
        /// <param name="joint">joint (also called as guided) image or array of images with any numbers of channels.</param>
        /// <param name="src">filtering image with any numbers of channels.</param>
        /// <param name="dst">output image.</param>
        /// <param name="sigmaS">spatial standard deviation.</param>
        /// <param name="sigmaR">color space standard deviation, it is similar to the sigma in the color space into
        /// bilateralFilter.</param>
        /// <param name="adjustOutliers">optional, specify perform outliers adjust operation or not, (Eq. 9) in the
        /// original paper.</param>
        public static void AMFilter(
            InputArray joint, InputArray src, OutputArray dst, double sigmaS, double sigmaR,
            bool adjustOutliers = false)
        {
            if (joint == null)
                throw new ArgumentNullException(nameof(joint));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            joint.ThrowIfDisposed();
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_amFilter(joint.CvPtr, src.CvPtr, dst.CvPtr, sigmaS, sigmaR, adjustOutliers ? 1 : 0));

            GC.KeepAlive(joint);
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Applies the joint bilateral filter to an image.
        /// </summary>
        /// <param name="joint">Joint 8-bit or floating-point, 1-channel or 3-channel image.</param>
        /// <param name="src">Source 8-bit or floating-point, 1-channel or 3-channel image with the same depth as joint image.</param>
        /// <param name="dst">Destination image of the same size and type as src.</param>
        /// <param name="d">Diameter of each pixel neighborhood that is used during filtering. If it is non-positive,
        /// it is computed from sigmaSpace.</param>
        /// <param name="sigmaColor">Filter sigma in the color space. A larger value of the parameter means that
        /// farther colors within the pixel neighborhood(see sigmaSpace) will be mixed together, resulting in
        /// larger areas of semi-equal color.</param>
        /// <param name="sigmaSpace">Filter sigma in the coordinate space. A larger value of the parameter means that
        /// farther pixels will influence each other as long as their colors are close enough(see sigmaColor).
        /// When d\>0 , it specifies the neighborhood size regardless of sigmaSpace.Otherwise, d is
        /// proportional to sigmaSpace.</param>
        /// <param name="borderType"></param>
        public static void JointBilateralFilter(
            InputArray joint, InputArray src, OutputArray dst, int d,
            double sigmaColor, double sigmaSpace, BorderTypes borderType = BorderTypes.Default)
        {
            if (joint == null)
                throw new ArgumentNullException(nameof(joint));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            joint.ThrowIfDisposed();
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_jointBilateralFilter(
                    joint.CvPtr, src.CvPtr, dst.CvPtr, d, sigmaColor, sigmaSpace, (int)borderType));

            GC.KeepAlive(joint);
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Applies the bilateral texture filter to an image. It performs structure-preserving texture filter.
        /// For more details about this filter see @cite Cho2014.
        /// </summary>
        /// <param name="src">Source image whose depth is 8-bit UINT or 32-bit FLOAT</param>
        /// <param name="dst">Destination image of the same size and type as src.</param>
        /// <param name="fr">Radius of kernel to be used for filtering. It should be positive integer</param>
        /// <param name="numIter">Number of iterations of algorithm, It should be positive integer</param>
        /// <param name="sigmaAlpha">Controls the sharpness of the weight transition from edges to smooth/texture regions, where
        /// a bigger value means sharper transition.When the value is negative, it is automatically calculated.</param>
        /// <param name="sigmaAvg">Range blur parameter for texture blurring. Larger value makes result to be more blurred. When the
        /// value is negative, it is automatically calculated as described in the paper.</param>
        public static void BilateralTextureFilter(
            InputArray src, OutputArray dst, int fr = 3, int numIter = 1, double sigmaAlpha = -1.0, double sigmaAvg = -1.0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_bilateralTextureFilter(
                    src.CvPtr, dst.CvPtr, fr, numIter, sigmaAlpha, sigmaAvg));

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Applies the rolling guidance filter to an image.
        /// </summary>
        /// <param name="src">8-bit or floating-point, 1-channel or 3-channel image.</param>
        /// <param name="dst">Destination image of the same size and type as src.</param>
        /// <param name="d">Diameter of each pixel neighborhood that is used during filtering. If it is non-positive,
        /// it is computed from sigmaSpace.</param>
        /// <param name="sigmaColor">Filter sigma in the color space. A larger value of the parameter means that
        /// farther colors within the pixel neighborhood(see sigmaSpace) will be mixed together, resulting in
        /// larger areas of semi-equal color.</param>
        /// <param name="sigmaSpace">Filter sigma in the coordinate space. A larger value of the parameter means that
        /// farther pixels will influence each other as long as their colors are close enough(see sigmaColor).
        /// When d\>0 , it specifies the neighborhood size regardless of sigmaSpace.Otherwise, d is
        /// proportional to sigmaSpace.</param>
        /// <param name="numOfIter">Number of iterations of joint edge-preserving filtering applied on the source image.</param>
        /// <param name="borderType"></param>
        public static void RollingGuidanceFilter(
            InputArray src, OutputArray dst, int d = -1, double sigmaColor = 25,
            double sigmaSpace = 3, int numOfIter = 4, BorderTypes borderType = BorderTypes.Default)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_rollingGuidanceFilter(
                    src.CvPtr, dst.CvPtr, d, sigmaColor, sigmaSpace, numOfIter, (int) borderType));

            GC.KeepAlive(src);
            dst.Fix();
        }
        
        /// <summary>
        /// Simple one-line Fast Bilateral Solver filter call. If you have multiple images to filter with the same
        /// guide then use FastBilateralSolverFilter interface to avoid extra computations.
        /// </summary>
        /// <param name="guide">image serving as guide for filtering. It should have 8-bit depth and either 1 or 3 channels.</param>
        /// <param name="src">source image for filtering with unsigned 8-bit or signed 16-bit or floating-point 32-bit depth and up to 4 channels.</param>
        /// <param name="confidence">confidence image with unsigned 8-bit or floating-point 32-bit confidence and 1 channel.</param>
        /// <param name="dst">destination image.</param>
        /// <param name="sigmaSpatial">parameter, that is similar to spatial space sigma (bandwidth) in bilateralFilter.</param>
        /// <param name="sigmaLuma">parameter, that is similar to luma space sigma (bandwidth) in bilateralFilter.</param>
        /// <param name="sigmaChroma">parameter, that is similar to chroma space sigma (bandwidth) in bilateralFilter.</param>
        /// <param name="lambda">smoothness strength parameter for solver.</param>
        /// <param name="numIter">number of iterations used for solver, 25 is usually enough.</param>
        /// <param name="maxTol">convergence tolerance used for solver.</param>
        public static void FastBilateralSolverFilter(
            InputArray guide, InputArray src, InputArray confidence,
            OutputArray dst, double sigmaSpatial = 8, double sigmaLuma = 8, double sigmaChroma = 8,
            double lambda = 128.0, int numIter = 25, double maxTol = 1e-5)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (confidence == null)
                throw new ArgumentNullException(nameof(confidence));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            guide.ThrowIfDisposed();
            src.ThrowIfDisposed();
            confidence.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_fastBilateralSolverFilter(
                    guide.CvPtr, src.CvPtr, confidence.CvPtr, dst.CvPtr, sigmaSpatial, sigmaLuma, sigmaChroma, lambda, numIter, maxTol));

            GC.KeepAlive(guide);
            GC.KeepAlive(src);
            GC.KeepAlive(confidence);
            dst.Fix();
        }

        /// <summary>
        /// Factory method, create instance of FastGlobalSmootherFilter and execute the initialization routines.
        /// </summary>
        /// <param name="guide">image serving as guide for filtering. It should have 8-bit depth and either 1 or 3 channels.</param>
        /// <param name="lambda">parameter defining the amount of regularization</param>
        /// <param name="sigmaColor">parameter, that is similar to color space sigma in bilateralFilter.</param>
        /// <param name="lambdaAttenuation">internal parameter, defining how much lambda decreases after each iteration. Normally,
        /// it should be 0.25. Setting it to 1.0 may lead to streaking artifacts.</param>
        /// <param name="numIter">number of iterations used for filtering, 3 is usually enough.</param>
        /// <returns></returns>
        public static FastGlobalSmootherFilter CreateFastGlobalSmootherFilter(
            InputArray guide, double lambda, double sigmaColor, double lambdaAttenuation = 0.25, int numIter = 3)
        {
            return OpenCvSharp.XImgProc.FastGlobalSmootherFilter.Create(guide, lambda, sigmaColor, lambdaAttenuation, numIter);
        }

        /// <summary>
        /// Simple one-line Fast Global Smoother filter call. If you have multiple images to filter with the same
        /// guide then use FastGlobalSmootherFilter interface to avoid extra computations.
        /// </summary>
        /// <param name="guide">image serving as guide for filtering. It should have 8-bit depth and either 1 or 3 channels.</param>
        /// <param name="src">source image for filtering with unsigned 8-bit or signed 16-bit or floating-point 32-bit depth and up to 4 channels.</param>
        /// <param name="dst">destination image.</param>
        /// <param name="lambda">parameter defining the amount of regularization</param>
        /// <param name="sigmaColor">parameter, that is similar to color space sigma in bilateralFilter.</param>
        /// <param name="lambdaAttenuation">internal parameter, defining how much lambda decreases after each iteration. Normally,
        /// it should be 0.25. Setting it to 1.0 may lead to streaking artifacts.</param>
        /// <param name="numIter">number of iterations used for filtering, 3 is usually enough.</param>
        public static void FastGlobalSmootherFilter(
            InputArray guide, InputArray src, OutputArray dst, double lambda, double sigmaColor,
            double lambdaAttenuation = 0.25, int numIter = 3)
        {
            if (guide == null)
                throw new ArgumentNullException(nameof(guide));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            guide.ThrowIfDisposed();
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_fastGlobalSmootherFilter(
                    guide.CvPtr, src.CvPtr, dst.CvPtr, lambda, sigmaColor, lambdaAttenuation, numIter));

            GC.KeepAlive(guide);
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Global image smoothing via L0 gradient minimization.
        /// </summary>
        /// <param name="src">source image for filtering with unsigned 8-bit or signed 16-bit or floating-point depth.</param>
        /// <param name="dst">destination image.</param>
        /// <param name="lambda">parameter defining the smooth term weight.</param>
        /// <param name="kappa">parameter defining the increasing factor of the weight of the gradient data term.</param>
        public static void L0Smooth(InputArray src, OutputArray dst, double lambda = 0.02, double kappa = 2.0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_l0Smooth(
                    src.CvPtr, dst.CvPtr, lambda, kappa));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region edgepreserving_filter.hpp

        /// <summary>
        /// Smoothes an image using the Edge-Preserving filter.
        /// </summary>
        /// <param name="src">Source 8-bit 3-channel image.</param>
        /// <param name="dst">Destination image of the same size and type as src.</param>
        /// <param name="d">Diameter of each pixel neighborhood that is used during filtering. Must be greater or equal 3.</param>
        /// <param name="threshold">Threshold, which distinguishes between noise, outliers, and data.</param>
        public static void EdgePreservingFilter(InputArray src, OutputArray dst, int d, double threshold)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_edgePreservingFilter(src.CvPtr, dst.CvPtr, d, threshold));

            GC.KeepAlive(src);
            dst.Fix();
        }

        #endregion

        #region estimated_covariance.hpp

        /// <summary>
        /// Computes the estimated covariance matrix of an image using the sliding window forumlation.
        /// </summary>
        /// <remarks>
        /// The window size parameters control the accuracy of the estimation.
        /// The sliding window moves over the entire image from the top-left corner 
        /// to the bottom right corner.Each location of the window represents a sample. 
        /// If the window is the size of the image, then this gives the exact covariance matrix. 
        /// For all other cases, the sizes of the window will impact the number of samples 
        /// and the number of elements in the estimated covariance matrix.
        /// </remarks>
        /// <param name="src">The source image. Input image must be of a complex type.</param>
        /// <param name="dst">The destination estimated covariance matrix. Output matrix will be size (windowRows*windowCols, windowRows*windowCols).</param>
        /// <param name="windowRows">The number of rows in the window.</param>
        /// <param name="windowCols">The number of cols in the window.</param>
        public static void CovarianceEstimation(InputArray src, OutputArray dst, int windowRows, int windowCols)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_covarianceEstimation(src.CvPtr, dst.CvPtr, windowRows, windowCols));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        #endregion

        #region fast_hough_transform.hpp

        /// <summary>
        /// Calculates 2D Fast Hough transform of an image.
        /// </summary>
        /// <param name="src">The source (input) image.</param>
        /// <param name="dst">The destination image, result of transformation.</param>
        /// <param name="dstMatDepth">The depth of destination image</param>
        /// <param name="angleRange">The part of Hough space to calculate, see cv::AngleRangeOption</param>
        /// <param name="op">The operation to be applied, see cv::HoughOp</param>
        /// <param name="makeSkew">Specifies to do or not to do image skewing, see cv::HoughDeskewOption</param>
        public static void FastHoughTransform(
            InputArray src,
            OutputArray dst,
            MatType dstMatDepth,
            AngleRangeOption angleRange = AngleRangeOption.ARO_315_135,
            HoughOP op = HoughOP.FHT_ADD,
            HoughDeskewOption makeSkew = HoughDeskewOption.DESKEW)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastHoughTransform(src.CvPtr, dst.CvPtr, dstMatDepth, (int)angleRange, (int)op, (int)makeSkew));

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Calculates coordinates of line segment corresponded by point in Hough space.
        /// </summary>
        /// <remarks>
        /// If rules parameter set to RO_STRICT then returned line cut along the border of source image.
        /// If rules parameter set to RO_WEAK then in case of point, which belongs 
        /// the incorrect part of Hough image, returned line will not intersect source image.
        /// </remarks>
        /// <param name="houghPoint">Point in Hough space.</param>
        /// <param name="srcImgInfo">The source (input) image of Hough transform.</param>
        /// <param name="angleRange">The part of Hough space where point is situated, see cv::AngleRangeOption</param>
        /// <param name="makeSkew">Specifies to do or not to do image skewing, see cv::HoughDeskewOption</param>
        /// <param name="rules">Specifies strictness of line segment calculating, see cv::RulesOption</param>
        /// <returns>Coordinates of line segment corresponded by point in Hough space.</returns>
        public static Vec4i HoughPoint2Line(
            Point houghPoint,
            InputArray srcImgInfo,
            AngleRangeOption angleRange = AngleRangeOption.ARO_315_135,
            HoughDeskewOption makeSkew = HoughDeskewOption.DESKEW,
            RulesOption rules = RulesOption.IGNORE_BORDERS)
        {
            if (srcImgInfo == null)
                throw new ArgumentNullException(nameof(srcImgInfo));
            srcImgInfo.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_HoughPoint2Line(houghPoint, srcImgInfo.CvPtr, (int)angleRange, (int)makeSkew, (int)rules, out Vec4i ret));
            GC.KeepAlive(srcImgInfo);
            return ret;
        }

        #endregion

        #region fast_line_detector.hpp

        /// <summary>
        /// Creates a smart pointer to a FastLineDetector object and initializes it
        /// </summary>
        /// <param name="lengthThreshold">Segment shorter than this will be discarded</param>
        /// <param name="distanceThreshold"> A point placed from a hypothesis line segment farther than 
        /// this will be regarded as an outlier</param>
        /// <param name="cannyTh1">First threshold for hysteresis procedure in Canny()</param>
        /// <param name="cannyTh2">Second threshold for hysteresis procedure in Canny()</param>
        /// <param name="cannyApertureSize">Aperture size for the sobel operator in Canny()</param>
        /// <param name="doMerge">If true, incremental merging of segments will be performed</param>
        /// <returns></returns>
        public static FastLineDetector CreateFastLineDetector(
            int lengthThreshold = 10, float distanceThreshold = 1.414213562f,
            double cannyTh1 = 50.0, double cannyTh2 = 50.0, int cannyApertureSize = 3,
            bool doMerge = false)
        {
            return FastLineDetector.Create(lengthThreshold, distanceThreshold, cannyTh1, cannyTh2, cannyApertureSize, doMerge);
        }

        #endregion

        #region lsc.hpp

        /// <summary>
        /// Class implementing the LSC (Linear Spectral Clustering) superpixels.
        ///
        /// The function initializes a SuperpixelLSC object for the input image. It sets the parameters of
        /// superpixel algorithm, which are: region_size and ruler.It preallocate some buffers for future
        /// computing iterations over the given image.An example of LSC is illustrated in the following picture.
        /// For enhanced results it is recommended for color images to preprocess image with little gaussian blur
        /// with a small 3 x 3 kernel and additional conversion into CieLAB color space.
        /// </summary>
        /// <param name="image">image Image to segment</param>
        /// <param name="regionSize">Chooses an average superpixel size measured in pixels</param>
        /// <param name="ratio">Chooses the enforcement of superpixel compactness factor of superpixel</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static SuperpixelLSC CreateSuperpixelLSC(InputArray image, int regionSize = 10, float ratio = 0.075f)
        {
            return SuperpixelLSC.Create(image, regionSize, ratio);
        }

        #endregion

        #region paillou_filter.hpp

        /// <summary>
        /// Applies Paillou filter to an image.
        /// </summary>
        /// <param name="op">Source CV_8U(S) or CV_16U(S), 1-channel or 3-channels image.</param>
        /// <param name="dst">Result CV_32F image with same number of channel than op.</param>
        /// <param name="alpha">double see paper</param>
        /// <param name="omega">double see paper</param>
        public static void GradientPaillouY(InputArray op, OutputArray dst, double alpha, double omega)
        {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            op.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientPaillouY(op.CvPtr, dst.CvPtr, alpha, omega));

            GC.KeepAlive(op);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Applies Paillou filter to an image.
        /// </summary>
        /// <param name="op">Source CV_8U(S) or CV_16U(S), 1-channel or 3-channels image.</param>
        /// <param name="dst">Result CV_32F image with same number of channel than op.</param>
        /// <param name="alpha">double see paper</param>
        /// <param name="omega">double see paper</param>
        public static void GradientPaillouX(InputArray op, OutputArray dst, double alpha, double omega)
        {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            op.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientPaillouX(op.CvPtr, dst.CvPtr, alpha, omega));

            GC.KeepAlive(op);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        #endregion

        #region peilin.hpp

        /// <summary>
        /// Calculates an affine transformation that normalize given image using Pei&amp;Lin Normalization.
        /// </summary>
        /// <param name="i">Given transformed image.</param>
        /// <returns>Transformation matrix corresponding to inversed image transformation</returns>
        public static double[,] PeiLinNormalization(InputArray i)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            i.ThrowIfDisposed();

            double[,] ret = new double[2, 3];
            unsafe
            {
                fixed (double* retPointer = ret)
                {
                    NativeMethods.HandleException(
                        NativeMethods.ximgproc_PeiLinNormalization_Mat23d(i.CvPtr, retPointer));
                }
            }

            GC.KeepAlive(i);
            return ret;
        }

        /// <summary>
        /// Calculates an affine transformation that normalize given image using Pei&amp;Lin Normalization.
        /// </summary>
        /// <param name="i">Given transformed image.</param>
        /// <param name="t">Inversed image transformation.</param>
        public static void PeiLinNormalization(InputArray i, OutputArray t)
        {
            if (i == null)
                throw new ArgumentNullException(nameof(i));
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            i.ThrowIfDisposed();
            t.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_PeiLinNormalization_OutputArray(i.CvPtr, t.CvPtr));

            GC.KeepAlive(i);
            t.Fix();
        }

        #endregion

        #region seeds.hpp

        /// <summary>
        /// Initializes a SuperpixelSEEDS object.
        ///
        /// The function initializes a SuperpixelSEEDS object for the input image. It stores the parameters of
        /// the image: image_width, image_height and image_channels.It also sets the parameters of the SEEDS
        /// superpixel algorithm, which are: num_superpixels, num_levels, use_prior, histogram_bins and
        /// double_step.
        ///
        /// The number of levels in num_levels defines the amount of block levels that the algorithm use in the
        /// optimization.The initialization is a grid, in which the superpixels are equally distributed through
        /// the width and the height of the image.The larger blocks correspond to the superpixel size, and the
        /// levels with smaller blocks are formed by dividing the larger blocks into 2 x 2 blocks of pixels,
        /// recursively until the smaller block level. An example of initialization of 4 block levels is
        /// illustrated in the following figure.
        /// </summary>
        /// <param name="imageWidth">Image width.</param>
        /// <param name="imageHeight">Image height.</param>
        /// <param name="imageChannels">Number of channels of the image.</param>
        /// <param name="numSuperpixels">Desired number of superpixels. Note that the actual number may be smaller
        /// due to restrictions(depending on the image size and num_levels). Use getNumberOfSuperpixels() to
        /// get the actual number.</param>
        /// <param name="numLevels">Number of block levels. The more levels, the more accurate is the segmentation,
        /// but needs more memory and CPU time.</param>
        /// <param name="prior">enable 3x3 shape smoothing term if \>0. A larger value leads to smoother shapes. prior
        /// must be in the range[0, 5].</param>
        /// <param name="histogramBins">Number of histogram bins.</param>
        /// <param name="doubleStep">If true, iterate each block level twice for higher accuracy.</param>
        /// <returns></returns>
        public static SuperpixelSEEDS CreateSuperpixelSEEDS(
            int imageWidth, int imageHeight, int imageChannels,
            int numSuperpixels, int numLevels, int prior = 2,
            int histogramBins = 5, bool doubleStep = false)
        {
            return SuperpixelSEEDS.Create(
                imageWidth, imageHeight, imageChannels, numSuperpixels, numLevels, prior, histogramBins, doubleStep);
        }

        #endregion

        #region structured_edge_detection.hpp

        /// <summary>
        /// Creates a RFFeatureGetter
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static RFFeatureGetter CreateRFFeatureGetter()
        {
            return RFFeatureGetter.Create();
        }

        /// <summary>
        /// Creates a StructuredEdgeDetection
        /// </summary>
        /// <param name="model">name of the file where the model is stored</param>
        /// <param name="howToGetFeatures">optional object inheriting from RFFeatureGetter.
        /// You need it only if you would like to train your own forest, pass null otherwise</param>
        /// <returns></returns>
        public static StructuredEdgeDetection CreateStructuredEdgeDetection(string model, RFFeatureGetter? howToGetFeatures = null)
        {
            return StructuredEdgeDetection.Create(model, howToGetFeatures);
        }

        #endregion

        #region weighted_median_filter.hpp

        /// <summary>
        /// Applies weighted median filter to an image.
        /// </summary>
        /// <remarks>
        /// For more details about this implementation, please see @cite zhang2014100+
        /// </remarks>
        /// <param name="joint">Joint 8-bit, 1-channel or 3-channel image.</param>
        /// <param name="src">Source 8-bit or floating-point, 1-channel or 3-channel image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="r">Radius of filtering kernel, should be a positive integer.</param>
        /// <param name="sigma">Filter range standard deviation for the joint image.</param>
        /// <param name="weightType">The type of weight definition, see WMFWeightType</param>
        /// <param name="mask">A 0-1 mask that has the same size with I. This mask is used to ignore the effect of some pixels. If the pixel value on mask is 0,
        /// the pixel will be ignored when maintaining the joint-histogram.This is useful for applications like optical flow occlusion handling.</param>
        public static void WeightedMedianFilter(
            InputArray joint, InputArray src, OutputArray dst, int r,
            double sigma = 25.5, WMFWeightType weightType = WMFWeightType.EXP, Mat? mask = null)
        {
            if (joint == null)
                throw new ArgumentNullException(nameof(joint));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            joint.ThrowIfDisposed();
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_weightedMedianFilter(
                    joint.CvPtr, src.CvPtr, dst.CvPtr, r, sigma, (int)weightType, mask?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(joint);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
            GC.KeepAlive(mask);
        }

        #endregion
    }
}
