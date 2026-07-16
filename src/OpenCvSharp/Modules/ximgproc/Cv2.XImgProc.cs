using OpenCvSharp.Internal;
using OpenCvSharp.XImgProc.Segmentation;
using OpenCvSharp.XImgProc;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::ximgproc functions
    /// </summary>
    public static partial class XImgProc
    {
        /// <summary>
        /// Strategy for the selective search segmentation algorithm.
        /// </summary>
    #pragma warning disable CA1034 // Nested types should not be visible
    #pragma warning disable CA1724 // Type names should not match namespaces
        public static class Segmentation
    #pragma warning restore CA1034
    #pragma warning restore CA1724
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
        /// run_length_morphology.hpp
        /// </summary>
    #pragma warning disable CA1034 // Nested types should not be visible
        public static class RL
    #pragma warning restore CA1034
        {
            /// <summary>
            /// Applies a fixed-level threshold to each array element.
            /// </summary>
            /// <param name="src">input array (single-channel).</param>
            /// <param name="rlDest">resulting run length encoded image.</param>
            /// <param name="thresh">threshold value.</param>
            /// <param name="type">thresholding type (only cv::THRESH_BINARY and cv::THRESH_BINARY_INV are supported)</param>
            public static void Threshold(InputArray src, OutputArray rlDest, double thresh, ThresholdTypes type)
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_threshold(src.Proxy, rlDest.Proxy, thresh, (int)type));

                GC.KeepAlive(src.Source);
            }

            /// <summary>
            /// Dilates an run-length encoded binary image by using a specific structuring element.
            /// </summary>
            /// <param name="rlSrc">input image</param>
            /// <param name="rlDest">result</param>
            /// <param name="rlKernel">kernel</param>
            /// <param name="anchor">position of the anchor within the element; default value (0, 0) is usually the element center.</param>
            public static void Dilate(
                InputArray rlSrc, OutputArray rlDest, InputArray rlKernel, Point? anchor = null)
            {
                var anchorValue = anchor.GetValueOrDefault(new Point(0, 0));

                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_dilate(rlSrc.Proxy, rlDest.Proxy, rlKernel.Proxy, anchorValue));

                GC.KeepAlive(rlSrc.Source);
                GC.KeepAlive(rlKernel.Source);
            }

            /// <summary>
            /// Erodes an run-length encoded binary image by using a specific structuring element.
            /// </summary>
            /// <param name="rlSrc">input image</param>
            /// <param name="rlDest">result</param>
            /// <param name="rlKernel">kernel</param>
            /// <param name="bBoundaryOn">indicates whether pixel outside the image boundary are assumed to be on
            /// (True: works in the same way as the default of cv::erode, False: is a little faster)</param>
            /// <param name="anchor">position of the anchor within the element; default value (0, 0)
            /// is usually the element center.</param>
            public static void Erode(
                InputArray rlSrc, OutputArray rlDest, InputArray rlKernel, bool bBoundaryOn = true, Point? anchor = null)
            {
                var anchorValue = anchor.GetValueOrDefault(new Point(0, 0));

                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_erode(rlSrc.Proxy, rlDest.Proxy, rlKernel.Proxy, bBoundaryOn ? 1 : 0, anchorValue));

                GC.KeepAlive(rlSrc.Source);
                GC.KeepAlive(rlKernel.Source);
            }

            /// <summary>
            /// Returns a run length encoded structuring element of the specified size and shape.
            /// </summary>
            /// <param name="shape">Element shape that can be one of cv::MorphShapes</param>
            /// <param name="ksize">Size of the structuring element.</param>
            /// <returns></returns>
            public static Mat GetStructuringElement(MorphShapes shape, Size ksize)
            {
                var ret = new Mat();
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_getStructuringElement((int)shape, ksize, ret.CvPtr));
                return ret;
            }

            /// <summary>
            /// Paint run length encoded binary image into an image.
            /// </summary>
            /// <param name="image">image to paint into (currently only single channel images).</param>
            /// <param name="rlSrc">run length encoded image</param>
            /// <param name="value">all foreground pixel of the binary image are set to this value</param>
            public static void Paint(InputOutputArray image, InputArray rlSrc, Scalar value)
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_paint(image.Proxy, rlSrc.Proxy, value));
                
                GC.KeepAlive(rlSrc.Source);
            }

            /// <summary>
            /// Check whether a custom-made structuring element can be used with run length morphological operations.
            /// (It must consist of a continuous array of single runs per row)
            /// </summary>
            /// <param name="rlStructuringElement"></param>
            /// <returns></returns>
            public static bool IsRLMorphologyPossible(InputArray rlStructuringElement)
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_isRLMorphologyPossible(rlStructuringElement.Proxy, out var ret));

                GC.KeepAlive(rlStructuringElement.Source);

                return ret != 0;
            }

            /// <summary>
            /// Creates a run-length encoded image from a vector of runs (column begin, column end, row)
            /// </summary>
            /// <param name="runs">vector of runs</param>
            /// <param name="res">result</param>
            /// <param name="size">image size (to be used if an "on" boundary should be used in erosion, using the default
            /// means that the size is computed from the extension of the input)</param>
            public static void CreateRLEImage(IEnumerable<Point3i> runs, OutputArray res, Size? size = null)
            {
                var runsArray = runs as Point3i[] ?? runs.ToArray();
                var sizeValue = size.GetValueOrDefault(new Size(0, 0));
                                
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_createRLEImage(runsArray, runsArray.Length, res.Proxy, sizeValue));

            }

            /// <summary>
            /// Applies a morphological operation to a run-length encoded binary image.
            /// </summary>
            /// <param name="rlSrc">input image</param>
            /// <param name="rlDest">result</param>
            /// <param name="op">all operations supported by cv::morphologyEx (except cv::MORPH_HITMISS)</param>
            /// <param name="rlKernel">kernel</param>
            /// <param name="bBoundaryOnForErosion">indicates whether pixel outside the image boundary are assumed
            /// to be on for erosion operations (True: works in the same way as the default of cv::erode, False: is a little faster)</param>
            /// <param name="anchor">position of the anchor within the element; default value (0, 0) is usually the element center.</param>
            public static void MorphologyEx(
                InputArray rlSrc, OutputArray rlDest, MorphTypes op, InputArray rlKernel,
                bool bBoundaryOnForErosion = true, Point? anchor = null)
            {
                var anchorValue = anchor.GetValueOrDefault(new Point(0, 0));

                NativeMethods.HandleException(
                    NativeMethods.ximgproc_rl_morphologyEx(rlSrc.Proxy, rlDest.Proxy, (int)op, rlKernel.Proxy, bBoundaryOnForErosion ? 1 : 0, anchorValue));

                GC.KeepAlive(rlSrc.Source);
                GC.KeepAlive(rlKernel.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_niBlackThreshold(src.Proxy, dst.Proxy, maxValue, (int)type, blockSize, k, (int)binarizationMethod, r));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(dst.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_thinning(src.Proxy, dst.Proxy, (int)thinningType));

            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_anisotropicDiffusion(src.Proxy, dst.Proxy, alpha, k, niters));

            GC.KeepAlive(src.Source);
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
            ArgumentNullException.ThrowIfNull(original);
            ArgumentNullException.ThrowIfNull(edgeView);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_createQuaternionImage(img.Proxy, qimg.Proxy));

            GC.KeepAlive(img.Source);
        }

        /// <summary>
        /// calculates conjugate of a quaternion image.
        /// </summary>
        /// <param name="qimg">quaternion image.</param>
        /// <param name="qcimg">conjugate of qimg</param>
        public static void QConj(InputArray qimg, OutputArray qcimg)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_qconj(qimg.Proxy, qcimg.Proxy));

            GC.KeepAlive(qimg.Source);
        }

        /// <summary>
        /// divides each element by its modulus.
        /// </summary>
        /// <param name="qimg">quaternion image.</param>
        /// <param name="qnimg">conjugate of qimg</param>
        public static void QUnitary(InputArray qimg, OutputArray qnimg)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_qunitary(qimg.Proxy, qnimg.Proxy));

            GC.KeepAlive(qimg.Source);
        }

        /// <summary>
        /// Calculates the per-element quaternion product of two arrays
        /// </summary>
        /// <param name="src1">quaternion image.</param>
        /// <param name="src2">quaternion image.</param>
        /// <param name="dst">product dst(I)=src1(I) . src2(I)</param>
        public static void QMultiply(InputArray src1, InputArray src2, OutputArray dst)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_qmultiply(src1.Proxy, src2.Proxy, dst.Proxy));

            GC.KeepAlive(src1.Source);
            GC.KeepAlive(src2.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_qdft(img.Proxy, qimg.Proxy, (int)flags, sideLeft ? 1 : 0));

            GC.KeepAlive(img.Source);
        }

        /// <summary>
        /// Compares a color template against overlapped color image regions.
        /// </summary>
        /// <param name="img">Image where the search is running. It must be 3 channels image</param>
        /// <param name="templ">Searched template. It must be not greater than the source image and have 3 channels</param>
        /// <param name="result">Map of comparison results. It must be single-channel 64-bit floating-point</param>
        public static void ColorMatchTemplate(InputArray img, InputArray templ, OutputArray result)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_colorMatchTemplate(img.Proxy, templ.Proxy, result.Proxy));

            GC.KeepAlive(img.Source);
            GC.KeepAlive(templ.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientDericheY(op.Proxy, dst.Proxy, alpha, omega));

            GC.KeepAlive(op.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientDericheX(op.Proxy, dst.Proxy, alpha, omega));

            GC.KeepAlive(op.Source);
        }

        #endregion

        #region disparity_filter.hpp

        /// <summary>
        /// Convenience factory method that creates an instance of DisparityWLSFilter and sets up all the
        /// relevant filter parameters automatically based on the matcher instance. Currently supports only
        /// StereoBM and StereoSGBM.
        /// </summary>
        /// <param name="matcherLeft">stereo matcher instance that will be used with the filter.</param>
        /// <returns></returns>
        public static DisparityWLSFilter CreateDisparityWLSFilter(StereoMatcher matcherLeft)
        {
            return DisparityWLSFilter.Create(matcherLeft);
        }

        /// <summary>
        /// More generic factory method, creates an instance of DisparityWLSFilter and executes basic
        /// initialization routines. When using this method you will need to set up the ROI, matchers and
        /// other parameters by yourself.
        /// </summary>
        /// <param name="useConfidence">filtering with confidence requires two disparity maps (for the left
        /// and right views) and is approximately two times slower. However, quality is typically
        /// significantly better.</param>
        /// <returns></returns>
        public static DisparityWLSFilter CreateDisparityWLSFilterGeneric(bool useConfidence)
        {
            return DisparityWLSFilter.CreateGeneric(useConfidence);
        }

        /// <summary>
        /// Convenience method to set up the matcher for computing the right-view disparity map that is
        /// required in case of filtering with confidence.
        /// </summary>
        /// <param name="matcherLeft">main stereo matcher instance that will be used with the filter.</param>
        /// <returns></returns>
        public static StereoMatcher CreateRightMatcher(StereoMatcher matcherLeft)
        {
            ArgumentNullException.ThrowIfNull(matcherLeft);
            matcherLeft.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createRightMatcher(matcherLeft.SmartPtr, out var ret));
            GC.KeepAlive(matcherLeft);

            return StereoMatcher.FromPtr(ret);
        }

        /// <summary>
        /// Function for reading ground truth disparity maps. Supports basic Middlebury and MPI-Sintel
        /// formats. Note that the resulting disparity map is scaled by 16.
        /// </summary>
        /// <param name="srcPath">path to the image, containing ground-truth disparity map.</param>
        /// <param name="dst">output disparity map, CV_16S depth.</param>
        /// <returns>returns zero if successfully read the ground truth.</returns>
        public static int ReadGT(string srcPath, OutputArray dst)
        {
            ArgumentNullException.ThrowIfNull(srcPath);

            NativeMethods.HandleException(
                NativeMethods.ximgproc_readGT(srcPath, dst.Proxy, out var ret));

            GC.KeepAlive(dst.Source);
            return ret;
        }

        /// <summary>
        /// Function for computing mean square error for disparity maps.
        /// </summary>
        /// <param name="gt">ground truth disparity map.</param>
        /// <param name="src">disparity map to evaluate.</param>
        /// <param name="roi">region of interest.</param>
        /// <returns>returns mean square error between GT and src.</returns>
        public static double ComputeMSE(InputArray gt, InputArray src, Rect roi)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_computeMSE(gt.Proxy, src.Proxy, roi, out var ret));

            GC.KeepAlive(gt.Source);
            GC.KeepAlive(src.Source);
            return ret;
        }

        /// <summary>
        /// Function for computing the percent of "bad" pixels in the disparity map (pixels where error is
        /// higher than a specified threshold).
        /// </summary>
        /// <param name="gt">ground truth disparity map.</param>
        /// <param name="src">disparity map to evaluate.</param>
        /// <param name="roi">region of interest.</param>
        /// <param name="thresh">threshold used to determine "bad" pixels.</param>
        /// <returns>returns mean square error between GT and src.</returns>
        public static double ComputeBadPixelPercent(InputArray gt, InputArray src, Rect roi, int thresh = 24)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_computeBadPixelPercent(gt.Proxy, src.Proxy, roi, thresh, out var ret));

            GC.KeepAlive(gt.Source);
            GC.KeepAlive(src.Source);
            return ret;
        }

        /// <summary>
        /// Function for creating a disparity map visualization (clamped CV_8U image).
        /// </summary>
        /// <param name="src">input disparity map (CV_16S depth).</param>
        /// <param name="dst">output visualization.</param>
        /// <param name="scale">disparity map will be multiplied by this value for visualization.</param>
        public static void GetDisparityVis(InputArray src, OutputArray dst, double scale = 1.0)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_getDisparityVis(src.Proxy, dst.Proxy, scale));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(dst.Source);
        }

        #endregion

        #region edge_drawing.hpp

        /// <summary>
        /// Creates a smart pointer to an EdgeDrawing object and initializes it.
        /// </summary>
        /// <returns>EdgeDrawing instance</returns>
        public static EdgeDrawing CreateEdgeDrawing()
        {
            return EdgeDrawing.Create();
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
        // ReSharper disable once InconsistentNaming
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
        // ReSharper disable once InconsistentNaming
        public static void DTFilter(InputArray guide, InputArray src, OutputArray dst, double sigmaSpatial,
            double sigmaColor, EdgeAwareFiltersList mode = EdgeAwareFiltersList.DTF_NC, int numIters = 3)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_dtFilter(guide.Proxy, src.Proxy, dst.Proxy, sigmaSpatial, sigmaColor, (int)mode, numIters));

            GC.KeepAlive(guide.Source);
            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_guidedFilter(guide.Proxy, src.Proxy, dst.Proxy, radius, eps, dDepth));

            GC.KeepAlive(guide.Source);
            GC.KeepAlive(src.Source);
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
        // ReSharper disable once InconsistentNaming
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
        // ReSharper disable once InconsistentNaming
        public static void AMFilter(
            InputArray joint, InputArray src, OutputArray dst, double sigmaS, double sigmaR,
            bool adjustOutliers = false)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_amFilter(joint.Proxy, src.Proxy, dst.Proxy, sigmaS, sigmaR, adjustOutliers ? 1 : 0));

            GC.KeepAlive(joint.Source);
            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_jointBilateralFilter(
                    joint.Proxy, src.Proxy, dst.Proxy, d, sigmaColor, sigmaSpace, (int)borderType));

            GC.KeepAlive(joint.Source);
            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_bilateralTextureFilter(
                    src.Proxy, dst.Proxy, fr, numIter, sigmaAlpha, sigmaAvg));

            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_rollingGuidanceFilter(
                    src.Proxy, dst.Proxy, d, sigmaColor, sigmaSpace, numOfIter, (int)borderType));

            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_fastBilateralSolverFilter(
                    guide.Proxy, src.Proxy, confidence.Proxy, dst.Proxy, sigmaSpatial, sigmaLuma, sigmaChroma, lambda, numIter, maxTol));

            GC.KeepAlive(guide.Source);
            GC.KeepAlive(src.Source);
            GC.KeepAlive(confidence.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_fastGlobalSmootherFilter(
                    guide.Proxy, src.Proxy, dst.Proxy, lambda, sigmaColor, lambdaAttenuation, numIter));

            GC.KeepAlive(guide.Source);
            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_l0Smooth(
                    src.Proxy, dst.Proxy, lambda, kappa));

            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_edgePreservingFilter(src.Proxy, dst.Proxy, d, threshold));

            GC.KeepAlive(src.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_covarianceEstimation(src.Proxy, dst.Proxy, windowRows, windowCols));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(dst.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastHoughTransform(src.Proxy, dst.Proxy, dstMatDepth, (int)angleRange, (int)op, (int)makeSkew));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(dst.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_HoughPoint2Line(houghPoint, srcImgInfo.Proxy, (int)angleRange, (int)makeSkew, (int)rules, out Vec4i ret));
            GC.KeepAlive(srcImgInfo.Source);
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

        #region find_ellipses.hpp

        /// <summary>
        /// Finds ellipses fastly in an image using projective invariant pruning.
        /// </summary>
        /// <param name="image">input image, could be gray or color.</param>
        /// <param name="ellipses">output vector of found ellipses. each vector is encoded as five float x, y, a, b, radius, score.</param>
        /// <param name="scoreThreshold">the threshold of ellipse score.</param>
        /// <param name="reliabilityThreshold">the threshold of reliability.</param>
        /// <param name="centerDistanceThreshold">the threshold of center distance.</param>
        public static void FindEllipses(
            InputArray image, OutputArray ellipses,
            float scoreThreshold = 0.7f, float reliabilityThreshold = 0.5f, float centerDistanceThreshold = 0.05f)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_findEllipses(
                    image.Proxy, ellipses.Proxy, scoreThreshold, reliabilityThreshold, centerDistanceThreshold));

            GC.KeepAlive(image.Source);
            GC.KeepAlive(ellipses.Source);
        }

        #endregion

        #region fourier_descriptors.hpp

        /// <summary>
        /// Creates a ContourFitting algorithm object.
        /// </summary>
        /// <param name="ctr">number of Fourier descriptors equal to number of contour points after resampling.</param>
        /// <param name="fd">number of Fourier descriptors used for optimal curve matching.</param>
        /// <returns></returns>
        public static ContourFitting CreateContourFitting(int ctr = 1024, int fd = 16)
        {
            return ContourFitting.Create(ctr, fd);
        }

        /// <summary>
        /// Fourier descriptors for planar closed curves.
        /// </summary>
        /// <param name="src">contour type vector&lt;Point&gt;, vector&lt;Point2f&gt; or vector&lt;Point2d&gt;.</param>
        /// <param name="dst">Mat of type CV_64FC2 and nbElt rows.</param>
        /// <param name="nbElt">number of rows in dst, or getOptimalDFTSize rows if nbElt=-1.</param>
        /// <param name="nbFD">number of FD returned in dst; dst = [FD(1...nbFD/2) FD(nbFD/2-nbElt+1...:nbElt)].</param>
        public static void FourierDescriptor(InputArray src, OutputArray dst, int nbElt = -1, int nbFD = -1)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_fourierDescriptor(src.Proxy, dst.Proxy, nbElt, nbFD));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(dst.Source);
        }

        /// <summary>
        /// Transform a contour using Fourier descriptors.
        /// </summary>
        /// <param name="src">contour or Fourier descriptors if fdContour is true.</param>
        /// <param name="t">transform Mat given by ContourFitting.EstimateTransformation.</param>
        /// <param name="dst">Mat of type CV_64FC2 and nbElt rows.</param>
        /// <param name="fdContour">true if src are Fourier descriptors; false if src is a contour.</param>
        public static void TransformFD(InputArray src, InputArray t, OutputArray dst, bool fdContour = true)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_transformFD(src.Proxy, t.Proxy, dst.Proxy, fdContour ? 1 : 0));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(t.Source);
            GC.KeepAlive(dst.Source);
        }

        /// <summary>
        /// Contour sampling.
        /// </summary>
        /// <param name="src">contour type vector&lt;Point&gt;, vector&lt;Point2f&gt; or vector&lt;Point2d&gt;.</param>
        /// <param name="outArray">Mat of type CV_64FC2 and nbElt rows.</param>
        /// <param name="nbElt">number of points in the output contour.</param>
        public static void ContourSampling(InputArray src, OutputArray outArray, int nbElt)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_contourSampling(src.Proxy, outArray.Proxy, nbElt));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(outArray.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientPaillouY(op.Proxy, dst.Proxy, alpha, omega));

            GC.KeepAlive(op.Source);
            GC.KeepAlive(dst.Source);
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
            NativeMethods.HandleException(
                NativeMethods.ximgproc_GradientPaillouX(op.Proxy, dst.Proxy, alpha, omega));

            GC.KeepAlive(op.Source);
            GC.KeepAlive(dst.Source);
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
            double[,] ret = new double[2, 3];
            unsafe
            {
                fixed (double* retPointer = ret)
                {
                    NativeMethods.HandleException(
                        NativeMethods.ximgproc_PeiLinNormalization_Mat23d(i.Proxy, retPointer));
                }
            }

            GC.KeepAlive(i.Source);
            return ret;
        }

        /// <summary>
        /// Calculates an affine transformation that normalize given image using Pei&amp;Lin Normalization.
        /// </summary>
        /// <param name="i">Given transformed image.</param>
        /// <param name="t">Inversed image transformation.</param>
        public static void PeiLinNormalization(InputArray i, OutputArray t)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_PeiLinNormalization_OutputArray(i.Proxy, t.Proxy));

            GC.KeepAlive(i.Source);
        }

        #endregion

        #region radon_transform.hpp

        /// <summary>
        /// Calculate Radon Transform of an image.
        /// </summary>
        /// <remarks>
        /// This function calculates the Radon Transform of a given image in any range.
        /// See https://engineering.purdue.edu/~malcolm/pct/CTI_Ch03.pdf for detail.
        /// If the input type is CV_8U, the output will be CV_32S.
        /// If the input type is CV_32F or CV_64F, the output will be CV_64F.
        /// The output size will be num_of_integral x src_diagonal_length.
        /// If crop is selected, the input image will be cropped into a square then a circle,
        /// and the output size will be num_of_integral x min_edge.
        /// </remarks>
        /// <param name="src">The source (input) image.</param>
        /// <param name="dst">The destination image, result of transformation.</param>
        /// <param name="theta">Angle resolution of the transform in degrees.</param>
        /// <param name="startAngle">Start angle of the transform in degrees.</param>
        /// <param name="endAngle">End angle of the transform in degrees.</param>
        /// <param name="crop">Crop the source image into a circle.</param>
        /// <param name="norm">Normalize the output Mat to grayscale and convert type to CV_8U.</param>
        public static void RadonTransform(
            InputArray src, OutputArray dst,
            double theta = 1, double startAngle = 0, double endAngle = 180, bool crop = false, bool norm = false)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_RadonTransform(
                    src.Proxy, dst.Proxy, theta, startAngle, endAngle, crop ? 1 : 0, norm ? 1 : 0));

            GC.KeepAlive(src.Source);
            GC.KeepAlive(dst.Source);
        }

        #endregion

        #region scansegment.hpp

        /// <summary>
        /// Initializes a ScanSegment object.
        /// </summary>
        /// <param name="imageWidth">Image width.</param>
        /// <param name="imageHeight">Image height.</param>
        /// <param name="numSuperpixels">Desired number of superpixels. Note that the actual number may be
        /// smaller due to restrictions (depending on the image size). Use GetNumberOfSuperpixels() to get
        /// the actual number.</param>
        /// <param name="slices">Number of processing threads for parallelisation. Setting -1 uses the
        /// maximum number of threads.</param>
        /// <param name="mergeSmall">Merge small segments to give the desired number of superpixels.</param>
        /// <returns></returns>
        public static ScanSegment CreateScanSegment(
            int imageWidth, int imageHeight, int numSuperpixels, int slices = 8, bool mergeSmall = true)
        {
            return ScanSegment.Create(imageWidth, imageHeight, numSuperpixels, slices, mergeSmall);
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
        // ReSharper disable once InconsistentNaming
        public static SuperpixelSEEDS CreateSuperpixelSEEDS(
            int imageWidth, int imageHeight, int imageChannels,
            int numSuperpixels, int numLevels, int prior = 2,
            int histogramBins = 5, bool doubleStep = false)
        {
            return SuperpixelSEEDS.Create(
                imageWidth, imageHeight, imageChannels, numSuperpixels, numLevels, prior, histogramBins, doubleStep);
        }

        #endregion

        #region sparse_match_interpolator.hpp

        /// <summary>
        /// Factory method that creates an instance of the EdgeAwareInterpolator.
        /// </summary>
        /// <returns></returns>
        public static EdgeAwareInterpolator CreateEdgeAwareInterpolator()
        {
            return EdgeAwareInterpolator.Create();
        }

        /// <summary>
        /// Factory method that creates an instance of the RICInterpolator.
        /// </summary>
        /// <returns></returns>
        public static RICInterpolator CreateRICInterpolator()
        {
            return RICInterpolator.Create();
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
            double sigma = 25.5, WMFWeightType weightType = WMFWeightType.EXP, InputArray mask = default)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_weightedMedianFilter(
                    joint.Proxy, src.Proxy, dst.Proxy, r, sigma, (int)weightType, mask.Proxy));

            GC.KeepAlive(joint.Source);
            GC.KeepAlive(src.Source);
            GC.KeepAlive(dst.Source);
            GC.KeepAlive(mask.Source);
        }

        #endregion
    }
}
