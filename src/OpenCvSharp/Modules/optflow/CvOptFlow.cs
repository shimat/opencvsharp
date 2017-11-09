using System;

namespace OpenCvSharp.OptFlow
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// cv::optflow functions
    /// </summary>
    public static class CvOptFlow
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
            if (silhouette == null)
                throw new ArgumentNullException(nameof(silhouette));
            if (mhi == null)
                throw new ArgumentNullException(nameof(mhi));
            silhouette.ThrowIfDisposed();
            mhi.ThrowIfNotReady();
            NativeMethods.optflow_motempl_updateMotionHistory(
                silhouette.CvPtr, mhi.CvPtr, timestamp, duration);
            mhi.Fix();
            GC.KeepAlive(silhouette);
            GC.KeepAlive(mhi);
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
            if (mhi == null)
                throw new ArgumentNullException(nameof(mhi));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            if (orientation == null)
                throw new ArgumentNullException(nameof(orientation));
            mhi.ThrowIfDisposed();
            mask.ThrowIfNotReady();
            orientation.ThrowIfNotReady();

            NativeMethods.optflow_motempl_calcMotionGradient(
                mhi.CvPtr, mask.CvPtr, orientation.CvPtr, delta1, delta2, apertureSize);

            mask.Fix();
            orientation.Fix();
            GC.KeepAlive(mhi);
            GC.KeepAlive(mask);
            GC.KeepAlive(orientation);
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
            if (orientation == null)
                throw new ArgumentNullException(nameof(orientation));
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            if (mhi == null)
                throw new ArgumentNullException(nameof(mhi));
            orientation.ThrowIfDisposed();
            mask.ThrowIfDisposed();
            mhi.ThrowIfDisposed();

            double result = NativeMethods.optflow_motempl_calcGlobalOrientation(
                orientation.CvPtr, mask.CvPtr, mhi.CvPtr, timestamp, duration);

            GC.KeepAlive(orientation);
            GC.KeepAlive(mask);
            GC.KeepAlive(mhi);
            return result;
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
            if (mhi == null)
                throw new ArgumentNullException(nameof(mhi));
            if (segmask == null)
                throw new ArgumentNullException(nameof(segmask));
            mhi.ThrowIfDisposed();
            segmask.ThrowIfNotReady();

            using (var br = new VectorOfRect())
            {
                NativeMethods.optflow_motempl_segmentMotion(
                    mhi.CvPtr, segmask.CvPtr, br.CvPtr, timestamp, segThresh);
                boundingRects = br.ToArray();
            }
            segmask.Fix();
            GC.KeepAlive(mhi);
            GC.KeepAlive(segmask);
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
            Mat from,
            Mat to,
            Mat flow,
            int layers,
            int averagingBlockSize,
            int maxFlow)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(@from));
            if (to == null)
                throw new ArgumentNullException(nameof(to));
            if (flow == null)
                throw new ArgumentNullException(nameof(flow));
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            flow.ThrowIfDisposed();

            NativeMethods.optflow_calcOpticalFlowSF1(
                from.CvPtr, to.CvPtr, flow.CvPtr,
                layers, averagingBlockSize, maxFlow);
            GC.KeepAlive(from);
            GC.KeepAlive(to);
            GC.KeepAlive(flow);
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
            Mat from,
            Mat to,
            Mat flow,
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
            if (from == null)
                throw new ArgumentNullException(nameof(@from));
            if (to == null)
                throw new ArgumentNullException(nameof(to));
            if (flow == null)
                throw new ArgumentNullException(nameof(flow));
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            flow.ThrowIfDisposed();

            NativeMethods.optflow_calcOpticalFlowSF2(
                from.CvPtr, to.CvPtr, flow.CvPtr,
                layers, averagingBlockSize, maxFlow,
                sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix,
                sigmaColorFix, occThr, upscaleAveragingRadius,
                upscaleSigmaDist, upscaleSigmaColor, speedUpThr);
            GC.KeepAlive(from);
            GC.KeepAlive(to);
            GC.KeepAlive(flow);
        }
    }
}
