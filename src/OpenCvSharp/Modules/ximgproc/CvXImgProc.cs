using System;
using OpenCvSharp.XImgProc.Segmentation;

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
        public static void NiblackThreshold(
            InputArray src, OutputArray dst,
            double maxValue, ThresholdTypes type, int blockSize, double k, 
            LocalBinarizationMethods binarizationMethod = LocalBinarizationMethods.Niblack)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.ximgproc_niBlackThreshold(src.CvPtr, dst.CvPtr, maxValue, (int)type, blockSize, k, (int)binarizationMethod);

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

            NativeMethods.ximgproc_thinning(src.CvPtr, dst.CvPtr, (int)thinningType);

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

            NativeMethods.ximgproc_anisotropicDiffusion(src.CvPtr, dst.CvPtr, alpha, k, niters);

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

        /// <summary>
        /// Creates a RFFeatureGetter
        /// </summary>
        /// <returns></returns>
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
        public static StructuredEdgeDetection CreateStructuredEdgeDetection(string model, RFFeatureGetter howToGetFeatures = null)
        {
            return StructuredEdgeDetection.Create(model, howToGetFeatures);
        }

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

            NativeMethods.ximgproc_FastHoughTransform(src.CvPtr, dst.CvPtr, dstMatDepth, (int)angleRange, (int)op, (int)makeSkew);

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

            var ret = NativeMethods.ximgproc_HoughPoint2Line(houghPoint, srcImgInfo.CvPtr, (int) angleRange, (int) makeSkew,
                (int) rules);
            GC.KeepAlive(srcImgInfo);
            return ret;
        }

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
            double sigma = 25.5, WMFWeightType weightType = WMFWeightType.EXP, Mat mask = null)
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

            NativeMethods.ximgproc_weightedMedianFilter(
                joint.CvPtr, src.CvPtr, dst.CvPtr, r, sigma, (int)weightType, mask?.CvPtr ?? IntPtr.Zero);

            GC.KeepAlive(joint);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
            GC.KeepAlive(mask);
        }

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

            NativeMethods.ximgproc_covarianceEstimation(src.CvPtr, dst.CvPtr, windowRows, windowCols);

            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }
    }
}
