using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;
using OpenCvSharp.OptFlow;

namespace OpenCvSharp;

public static partial class Cv2
{
    // ReSharper disable InconsistentNaming
    /// <summary>
    /// cv::optflow functions
    /// </summary>
    public static partial class OptFlow
    {
        /// <summary>
        /// Updates motion history image using the current silhouette
        /// </summary>
        /// <param name="silhouette">Silhouette mask that has non-zero pixels where the motion occurs.</param>
        /// <param name="mhi">Motion history image that is updated by the function (single-channel, 32-bit floating-point).</param>
        /// <param name="timestamp">Current time in milliseconds or other units.</param>
        /// <param name="duration">Maximal duration of the motion track in the same units as timestamp .</param>
        public static void UpdateMotionHistory(
            InputArray silhouette, InputOutputArray mhi,
            double timestamp, double duration)
        {
            NativeMethods.HandleException(
                NativeMethods.optflow_motempl_updateMotionHistory(
                    silhouette.Proxy, mhi.Proxy, timestamp, duration));

            GC.KeepAlive(silhouette.Source);
            GC.KeepAlive(mhi.Source);
        }

        /// <summary>
        /// Computes the motion gradient orientation image from the motion history image
        /// </summary>
        /// <param name="mhi">Motion history single-channel floating-point image.</param>
        /// <param name="mask">Output mask image that has the type CV_8UC1 and the same size as mhi. 
        /// Its non-zero elements mark pixels where the motion gradient data is correct.</param>
        /// <param name="orientation">Output motion gradient orientation image that has the same type and the same size as mhi. 
        /// Each pixel of the image is a motion orientation, from 0 to 360 degrees.</param>
        /// <param name="delta1">Minimal (or maximal) allowed difference between mhi values within a pixel neighborhood.</param>
        /// <param name="delta2">Maximal (or minimal) allowed difference between mhi values within a pixel neighborhood. 
        /// That is, the function finds the minimum ( m(x,y) ) and maximum ( M(x,y) ) mhi values over 3x3 neighborhood of each pixel 
        /// and marks the motion orientation at (x, y) as valid only if: 
        /// min(delta1, delta2) &lt;= M(x,y)-m(x,y) &lt;= max(delta1, delta2).</param>
        /// <param name="apertureSize"></param>
        public static void CalcMotionGradient(
            InputArray mhi, OutputArray mask, OutputArray orientation,
            double delta1, double delta2, int apertureSize = 3)
        {
            NativeMethods.HandleException(
                NativeMethods.optflow_motempl_calcMotionGradient(
                    mhi.Proxy, mask.Proxy, orientation.Proxy, delta1, delta2, apertureSize));

            GC.KeepAlive(mhi.Source);
            GC.KeepAlive(mask.Source);
            GC.KeepAlive(orientation.Source);
        }

        /// <summary>
        /// Computes the global orientation of the selected motion history image part
        /// </summary>
        /// <param name="orientation">Motion gradient orientation image calculated by the function CalcMotionGradient() .</param>
        /// <param name="mask">Mask image. It may be a conjunction of a valid gradient mask, also calculated by CalcMotionGradient() ,
        /// and the mask of a region whose direction needs to be calculated.</param>
        /// <param name="mhi">Motion history image calculated by UpdateMotionHistory() .</param>
        /// <param name="timestamp">Timestamp passed to UpdateMotionHistory() .</param>
        /// <param name="duration">Maximum duration of a motion track in milliseconds, passed to UpdateMotionHistory() .</param>
        /// <returns></returns>
        public static double CalcGlobalOrientation(
            InputArray orientation, InputArray mask, InputArray mhi,
            double timestamp, double duration)
        {
            NativeMethods.HandleException(
                NativeMethods.optflow_motempl_calcGlobalOrientation(
                    orientation.Proxy, mask.Proxy, mhi.Proxy, timestamp, duration, out var ret));

            GC.KeepAlive(orientation.Source);
            GC.KeepAlive(mask.Source);
            GC.KeepAlive(mhi.Source);
            return ret;
        }

        /// <summary>
        /// Splits a motion history image into a few parts corresponding to separate independent motions 
        /// (for example, left hand, right hand).
        /// </summary>
        /// <param name="mhi">Motion history image.</param>
        /// <param name="segmask">Image where the found mask should be stored, single-channel, 32-bit floating-point.</param>
        /// <param name="boundingRects">Vector containing ROIs of motion connected components.</param>
        /// <param name="timestamp">Current time in milliseconds or other units.</param>
        /// <param name="segThresh">Segmentation threshold that is recommended to be equal to the interval between motion history “steps” or greater.</param>
        public static void SegmentMotion(
            InputArray mhi, OutputArray segmask,
            out Rect[] boundingRects,
            double timestamp, double segThresh)
        {
            using var br = new StdVector<Rect>();
            NativeMethods.HandleException(
                NativeMethods.optflow_motempl_segmentMotion(
                    mhi.Proxy, segmask.Proxy, br.CvPtr, timestamp, segThresh));
            boundingRects = br.ToArray();
            
            GC.KeepAlive(mhi.Source);
            GC.KeepAlive(segmask.Source);
        }

        /// <summary>
        /// computes dense optical flow using Simple Flow algorithm
        /// </summary>
        /// <param name="from">First 8-bit 3-channel image.</param>
        /// <param name="to">Second 8-bit 3-channel image</param>
        /// <param name="flow">Estimated flow</param>
        /// <param name="layers">Number of layers</param>
        /// <param name="averagingBlockSize">Size of block through which we sum up when calculate cost function for pixel</param>
        /// <param name="maxFlow">maximal flow that we search at each level</param>
        public static void CalcOpticalFlowSF(
            InputArray from,
            InputArray to,
            OutputArray flow,
            int layers,
            int averagingBlockSize,
            int maxFlow)
        {
            NativeMethods.HandleException(
                NativeMethods.optflow_calcOpticalFlowSF1(
                    from.Proxy, to.Proxy, flow.Proxy,
                    layers, averagingBlockSize, maxFlow));

            GC.KeepAlive(from.Source);
            GC.KeepAlive(to.Source);
            GC.KeepAlive(flow.Source);
        }

        /// <summary>
        /// computes dense optical flow using Simple Flow algorithm
        /// </summary>
        /// <param name="from">First 8-bit 3-channel image.</param>
        /// <param name="to">Second 8-bit 3-channel image</param>
        /// <param name="flow">Estimated flow</param>
        /// <param name="layers">Number of layers</param>
        /// <param name="averagingBlockSize">Size of block through which we sum up when calculate cost function for pixel</param>
        /// <param name="maxFlow">maximal flow that we search at each level</param>
        /// <param name="sigmaDist">vector smooth spatial sigma parameter</param>
        /// <param name="sigmaColor">vector smooth color sigma parameter</param>
        /// <param name="postprocessWindow">window size for postprocess cross bilateral filter</param>
        /// <param name="sigmaDistFix">spatial sigma for postprocess cross bilateralf filter</param>
        /// <param name="sigmaColorFix">color sigma for postprocess cross bilateral filter</param>
        /// <param name="occThr">threshold for detecting occlusions</param>
        /// <param name="upscaleAveragingRadius">window size for bilateral upscale operation</param>
        /// <param name="upscaleSigmaDist">spatial sigma for bilateral upscale operation</param>
        /// <param name="upscaleSigmaColor">color sigma for bilateral upscale operation</param>
        /// <param name="speedUpThr">threshold to detect point with irregular flow - where flow should be recalculated after upscale</param>
        public static void CalcOpticalFlowSF(
            InputArray from,
            InputArray to,
            OutputArray flow,
            int layers,
            int averagingBlockSize,
            int maxFlow,
            double sigmaDist,
            double sigmaColor,
            int postprocessWindow,
            double sigmaDistFix,
            double sigmaColorFix,
            double occThr,
            int upscaleAveragingRadius,
            double upscaleSigmaDist,
            double upscaleSigmaColor,
            double speedUpThr)
        {
            NativeMethods.HandleException(
                NativeMethods.optflow_calcOpticalFlowSF2(
                    from.Proxy, to.Proxy, flow.Proxy,
                    layers, averagingBlockSize, maxFlow,
                    sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix,
                    sigmaColorFix, occThr, upscaleAveragingRadius,
                    upscaleSigmaDist, upscaleSigmaColor, speedUpThr));

            GC.KeepAlive(from.Source);
            GC.KeepAlive(to.Source);
            GC.KeepAlive(flow.Source);
        }

        /// <summary>
        /// Fast dense optical flow based on PyrLK sparse matches interpolation.
        /// </summary>
        /// <param name="from">first 8-bit 3-channel or 1-channel image.</param>
        /// <param name="to">second 8-bit 3-channel or 1-channel image of the same size as from</param>
        /// <param name="flow">computed flow image that has the same size as from and CV_32FC2 type</param>
        /// <param name="gridStep">stride used in sparse match computation. Lower values usually
        /// result in higher quality but slow down the algorithm.</param>
        /// <param name="k">number of nearest-neighbor matches considered, when fitting a locally affine
        /// model. Lower values can make the algorithm noticeably faster at the cost of some quality degradation.</param>
        /// <param name="sigma">parameter defining how fast the weights decrease in the locally-weighted affine
        /// fitting. Higher values can help preserve fine details, lower values can help to get rid of the noise in the output flow.</param>
        /// <param name="usePostProc">defines whether the ximgproc::fastGlobalSmootherFilter() is used for post-processing after interpolation</param>
        /// <param name="fgsLambda">see the respective parameter of the ximgproc::fastGlobalSmootherFilter()</param>
        /// <param name="fgsSigma">see the respective parameter of the ximgproc::fastGlobalSmootherFilter()</param>
        public static void CalcOpticalFlowSparseToDense(
            InputArray from,
            InputArray to,
            OutputArray flow,
            int gridStep = 8,
            int k = 128,
            float sigma = 0.05f,
            bool usePostProc = true, 
            float fgsLambda = 500.0f,
            float fgsSigma = 1.5f)
        {
            NativeMethods.HandleException(
                NativeMethods.optflow_calcOpticalFlowSparseToDense(
                    from.Proxy, to.Proxy, flow.Proxy,
                    gridStep, k, sigma, usePostProc ? 1 : 0, fgsLambda, fgsSigma));

            GC.KeepAlive(from.Source);
            GC.KeepAlive(to.Source);
            GC.KeepAlive(flow.Source);
        }

        /// <summary>
        /// DeepFlow optical flow algorithm implementation.
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_DeepFlow()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_DeepFlow(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.video_Ptr_DenseOpticalFlow_get(smartPtr, out var rawPtr));
            return DenseOpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Additional interface to the SimpleFlow algorithm - CalcOpticalFlowSF()
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_SimpleFlow()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_SimpleFlow(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.video_Ptr_DenseOpticalFlow_get(smartPtr, out var rawPtr));
            return DenseOpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Additional interface to the Farneback's algorithm - CalcOpticalFlowFarneback()
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_Farneback()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_Farneback(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.video_Ptr_DenseOpticalFlow_get(smartPtr, out var rawPtr));
            return DenseOpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Additional interface to the SparseToDenseFlow algorithm - CalcOpticalFlowSparseToDense()
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_SparseToDense()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_SparseToDense(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.video_Ptr_DenseOpticalFlow_get(smartPtr, out var rawPtr));
            return DenseOpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Creates an instance of cv::optflow::DualTVL1OpticalFlow, using the algorithm's defaults.
        /// </summary>
        /// <returns></returns>
        // NB: return type is fully qualified because the sibling superres module already has a flat
        // (namespace OpenCvSharp) DualTVL1OpticalFlow class wrapping the unrelated cv::superres::DualTVL1OpticalFlow.
        public static OpenCvSharp.OptFlow.DualTVL1OpticalFlow CreateOptFlow_DualTVL1()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_DualTVL1(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.optflow_Ptr_DualTVL1OpticalFlow_get(smartPtr, out var rawPtr));
            return OpenCvSharp.OptFlow.DualTVL1OpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Creates an instance of the PCAFlow algorithm, using the algorithm's defaults (no learned prior).
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_PCAFlow()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_PCAFlow(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.video_Ptr_DenseOpticalFlow_get(smartPtr, out var rawPtr));
            return DenseOpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Additional interface to the Dense RLOF algorithm - CalcOpticalFlowDenseRLOF(), using the algorithm's defaults.
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_DenseRLOF()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_DenseRLOF(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.video_Ptr_DenseOpticalFlow_get(smartPtr, out var rawPtr));
            return DenseOpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Additional interface to the Sparse RLOF algorithm - CalcOpticalFlowSparseRLOF(), using the algorithm's defaults.
        /// </summary>
        /// <returns></returns>
        public static SparseOpticalFlow CreateOptFlow_SparseRLOF()
        {
            NativeMethods.HandleException(NativeMethods.optflow_createOptFlow_SparseRLOF(out var smartPtr));
            NativeMethods.HandleException(NativeMethods.video_Ptr_SparseOpticalFlow_get(smartPtr, out var rawPtr));
            return SparseOpticalFlow.FromPtr(smartPtr, rawPtr);
        }

        /// <summary>
        /// Fast dense optical flow computation based on robust local optical flow (RLOF) algorithms and
        /// sparse-to-dense interpolation scheme.
        /// </summary>
        /// <param name="i0">First 8-bit input image. If cross-based RLOF is used
        /// (<see cref="RLOFOpticalFlowParameter.SupportRegionType"/> = <see cref="OpenCvSharp.OptFlow.SupportRegionType.Cross"/>)
        /// the image has to be an 8-bit 3-channel image.</param>
        /// <param name="i1">Second 8-bit input image, same requirements as <paramref name="i0"/>.</param>
        /// <param name="flow">Computed flow image that has the same size as i0 and type CV_32FC2.</param>
        /// <param name="rlofParam">See <see cref="RLOFOpticalFlowParameter"/>. Uses the algorithm's defaults when null.</param>
        /// <param name="forwardBackwardThreshold">Threshold for the forward backward confidence check.</param>
        /// <param name="gridStep">Size of the grid to spawn the motion vectors.</param>
        /// <param name="interpType">Interpolation method used to compute the dense optical flow.</param>
        /// <param name="epicK">See ximgproc::EdgeAwareInterpolator's K value.</param>
        /// <param name="epicSigma">See ximgproc::EdgeAwareInterpolator's sigma value.</param>
        /// <param name="epicLambda">See ximgproc::EdgeAwareInterpolator's lambda value.</param>
        /// <param name="ricSpSize">See ximgproc::RICInterpolator's superpixel size parameter.</param>
        /// <param name="ricSlicType">See ximgproc::RICInterpolator's superpixel algorithm variant.</param>
        /// <param name="usePostProc">Enables ximgproc::fastGlobalSmootherFilter() post-processing.</param>
        /// <param name="fgsLambda">See ximgproc::fastGlobalSmootherFilter()'s lambda parameter.</param>
        /// <param name="fgsSigma">See ximgproc::fastGlobalSmootherFilter()'s sigma parameter.</param>
        /// <param name="useVariationalRefinement">Enables VariationalRefinement.</param>
        public static void CalcOpticalFlowDenseRLOF(
            InputArray i0,
            InputArray i1,
            InputOutputArray flow,
            RLOFOpticalFlowParameter? rlofParam = null,
            float forwardBackwardThreshold = 0,
            Size? gridStep = null,
            InterpolationType interpType = InterpolationType.EPIC,
            int epicK = 128,
            float epicSigma = 0.05f,
            float epicLambda = 999.0f,
            int ricSpSize = 15,
            int ricSlicType = 100,
            bool usePostProc = true,
            float fgsLambda = 500.0f,
            float fgsSigma = 1.5f,
            bool useVariationalRefinement = false)
        {
            rlofParam?.ThrowIfDisposed();
            var actualGridStep = gridStep ?? new Size(6, 6);

            NativeMethods.HandleException(
                NativeMethods.optflow_calcOpticalFlowDenseRLOF(
                    i0.Proxy, i1.Proxy, flow.Proxy,
                    rlofParam?.SmartPtr ?? IntPtr.Zero, forwardBackwardThreshold, actualGridStep, (int)interpType,
                    epicK, epicSigma, epicLambda, ricSpSize, ricSlicType,
                    usePostProc ? 1 : 0, fgsLambda, fgsSigma, useVariationalRefinement ? 1 : 0));

            GC.KeepAlive(i0.Source);
            GC.KeepAlive(i1.Source);
            GC.KeepAlive(flow.Source);
            GC.KeepAlive(rlofParam);
        }

        /// <summary>
        /// Calculates a fast optical flow for a sparse feature set using the robust local optical flow (RLOF),
        /// similar to CalcOpticalFlowPyrLK().
        /// </summary>
        /// <param name="prevImg">First 8-bit input image. If cross-based RLOF is used
        /// (<see cref="RLOFOpticalFlowParameter.SupportRegionType"/> = <see cref="OpenCvSharp.OptFlow.SupportRegionType.Cross"/>)
        /// the image has to be an 8-bit 3-channel image.</param>
        /// <param name="nextImg">Second 8-bit input image, same requirements as <paramref name="prevImg"/>.</param>
        /// <param name="prevPts">Vector of 2D points for which the flow needs to be found.</param>
        /// <param name="nextPts">Output vector of 2D points containing the calculated new positions of input features in the second image.</param>
        /// <param name="status">Output status vector. Each element is set to 1 if the flow for the corresponding
        /// feature has passed the forward backward check.</param>
        /// <param name="err">Output vector of errors; each element is set to the forward backward error for the
        /// corresponding feature.</param>
        /// <param name="rlofParam">See <see cref="RLOFOpticalFlowParameter"/>. Uses the algorithm's defaults when null.</param>
        /// <param name="forwardBackwardThreshold">Threshold for the forward backward confidence check.
        /// If &lt;= 0, the forward backward check is not applied.</param>
        public static void CalcOpticalFlowSparseRLOF(
            InputArray prevImg,
            InputArray nextImg,
            InputArray prevPts,
            InputOutputArray nextPts,
            OutputArray status,
            OutputArray err,
            RLOFOpticalFlowParameter? rlofParam = null,
            float forwardBackwardThreshold = 0)
        {
            rlofParam?.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.optflow_calcOpticalFlowSparseRLOF(
                    prevImg.Proxy, nextImg.Proxy, prevPts.Proxy, nextPts.Proxy, status.Proxy, err.Proxy,
                    rlofParam?.SmartPtr ?? IntPtr.Zero, forwardBackwardThreshold));

            GC.KeepAlive(prevImg.Source);
            GC.KeepAlive(nextImg.Source);
            GC.KeepAlive(prevPts.Source);
            GC.KeepAlive(nextPts.Source);
            GC.KeepAlive(status.Source);
            GC.KeepAlive(err.Source);
            GC.KeepAlive(rlofParam);
        }
    }
}
