using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    static partial class Cv2
    {
        /// <summary>
        /// 
        /// </summary>
        public static void InitModule_Video()
        {
            NativeMethods.video_initModule_video();
        }

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
                throw new ArgumentNullException("silhouette");
            if (mhi == null)
                throw new ArgumentNullException("mhi");
            silhouette.ThrowIfDisposed();
            mhi.ThrowIfNotReady();
            NativeMethods.video_updateMotionHistory(
                silhouette.CvPtr, mhi.CvPtr, timestamp, duration);
            mhi.Fix();
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
                throw new ArgumentNullException("mhi");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (orientation == null)
                throw new ArgumentNullException("orientation");
            mhi.ThrowIfDisposed();
            mask.ThrowIfNotReady();
            orientation.ThrowIfNotReady();

            NativeMethods.video_calcMotionGradient(
                mhi.CvPtr, mask.CvPtr, orientation.CvPtr, delta1, delta2, apertureSize);

            mask.Fix();
            orientation.Fix();
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
                throw new ArgumentNullException("orientation");
            if (mask == null)
                throw new ArgumentNullException("mask");
            if (mhi == null)
                throw new ArgumentNullException("mhi");
            orientation.ThrowIfDisposed();
            mask.ThrowIfDisposed();
            mhi.ThrowIfDisposed();

            return NativeMethods.video_calcGlobalOrientation(
                orientation.CvPtr, mask.CvPtr, mhi.CvPtr, timestamp, duration);
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
                throw new ArgumentNullException("mhi");
            if (segmask == null)
                throw new ArgumentNullException("segmask");
            mhi.ThrowIfDisposed();
            segmask.ThrowIfNotReady();

            using (var br = new VectorOfRect())
            {
                NativeMethods.video_segmentMotion(
                    mhi.CvPtr, segmask.CvPtr, br.CvPtr, timestamp, segThresh);
                boundingRects = br.ToArray();
            }
            segmask.Fix();
        }

        /// <summary>
        /// Finds an object center, size, and orientation.
        /// </summary>
        /// <param name="probImage">Back projection of the object histogram. </param>
        /// <param name="window">Initial search window.</param>
        /// <param name="criteria">Stop criteria for the underlying MeanShift() .</param>
        /// <returns></returns>
        public static RotatedRect CamShift(
            InputArray probImage, ref Rect window, TermCriteria criteria)
        {
            if (probImage == null)
                throw new ArgumentNullException("probImage");
            probImage.ThrowIfDisposed();

            CvRect window0 = window;
            RotatedRect result = NativeMethods.video_CamShift(
                probImage.CvPtr, ref window0, criteria);
            window = window0;
            return result;
        }

        /// <summary>
        /// Finds an object on a back projection image.
        /// </summary>
        /// <param name="probImage">Back projection of the object histogram.</param>
        /// <param name="window">Initial search window.</param>
        /// <param name="criteria">Stop criteria for the iterative search algorithm.</param>
        /// <returns>Number of iterations CAMSHIFT took to converge.</returns>
        public static int MeanShift(
            InputArray probImage, ref Rect window, TermCriteria criteria)
        {
            if (probImage == null)
                throw new ArgumentNullException("probImage");
            probImage.ThrowIfDisposed();

            CvRect window0 = window;
            int result = NativeMethods.video_meanShift(
                probImage.CvPtr, ref window0, criteria);
            window = window0;
            return result;
        }

        /// <summary>
        /// Constructs a pyramid which can be used as input for calcOpticalFlowPyrLK
        /// </summary>
        /// <param name="img">8-bit input image.</param>
        /// <param name="pyramid">output pyramid.</param>
        /// <param name="winSize">window size of optical flow algorithm. 
        /// Must be not less than winSize argument of calcOpticalFlowPyrLK(). 
        /// It is needed to calculate required padding for pyramid levels.</param>
        /// <param name="maxLevel">0-based maximal pyramid level number.</param>
        /// <param name="withDerivatives">set to precompute gradients for the every pyramid level. 
        /// If pyramid is constructed without the gradients then calcOpticalFlowPyrLK() will 
        /// calculate them internally.</param>
        /// <param name="pyrBorder">the border mode for pyramid layers.</param>
        /// <param name="derivBorder">the border mode for gradients.</param>
        /// <param name="tryReuseInputImage">put ROI of input image into the pyramid if possible. 
        /// You can pass false to force data copying.</param>
        /// <returns>number of levels in constructed pyramid. Can be less than maxLevel.</returns>
        public static int BuildOpticalFlowPyramid(
            InputArray img, OutputArray pyramid,
            Size winSize, int maxLevel,
            bool withDerivatives = true,
            BorderType pyrBorder = BorderType.Reflict101,
            BorderType derivBorder = BorderType.Constant,
            bool tryReuseInputImage = true)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (pyramid == null)
                throw new ArgumentNullException("pyramid");
            img.ThrowIfDisposed();
            pyramid.ThrowIfNotReady();

            int result = NativeMethods.video_buildOpticalFlowPyramid(
                img.CvPtr, pyramid.CvPtr, winSize, maxLevel, withDerivatives ? 1 : 0, 
                (int)pyrBorder, (int)derivBorder, tryReuseInputImage ? 1 : 0);
            pyramid.Fix();
            return result;
        }

        /// <summary>
        /// computes sparse optical flow using multi-scale Lucas-Kanade algorithm
        /// </summary>
        /// <param name="prevImg"></param>
        /// <param name="nextImg"></param>
        /// <param name="prevPts"></param>
        /// <param name="nextPts"></param>
        /// <param name="status"></param>
        /// <param name="err"></param>
        /// <param name="winSize"></param>
        /// <param name="maxLevel"></param>
        /// <param name="criteria"></param>
        /// <param name="flags"></param>
        /// <param name="minEigThreshold"></param>
        public static void CalcOpticalFlowPyrLK(
            InputArray prevImg, InputArray nextImg,
            InputArray prevPts, InputOutputArray nextPts,
            OutputArray status, OutputArray err,
            Size? winSize = null,
            int maxLevel = 3,
            TermCriteria? criteria = null,
            OpticalFlowFlags flags = OpticalFlowFlags.None,
            double minEigThreshold = 1e-4)
        {
            if (prevImg == null)
                throw new ArgumentNullException("prevImg");
            if (nextImg == null)
                throw new ArgumentNullException("nextImg");
            if (prevPts == null)
                throw new ArgumentNullException("prevPts");
            if (nextPts == null)
                throw new ArgumentNullException("nextPts");
            if (status == null)
                throw new ArgumentNullException("status");
            if (err == null)
                throw new ArgumentNullException("err");
            prevImg.ThrowIfDisposed();
            nextImg.ThrowIfDisposed();
            prevPts.ThrowIfDisposed();
            nextPts.ThrowIfNotReady();
            status.ThrowIfNotReady();
            err.ThrowIfNotReady();

            Size winSize0 = winSize.GetValueOrDefault(new Size(21, 21));
            TermCriteria criteria0 = criteria.GetValueOrDefault(
                TermCriteria.Both(30, 0.01));

            NativeMethods.video_calcOpticalFlowPyrLK_InputArray(
                prevImg.CvPtr, nextImg.CvPtr, prevPts.CvPtr, nextPts.CvPtr,
                status.CvPtr, err.CvPtr, winSize0,maxLevel,
                criteria0, (int)flags, minEigThreshold);

            nextPts.Fix();
            status.Fix();
            err.Fix();
        }
        /// <summary>
        /// computes sparse optical flow using multi-scale Lucas-Kanade algorithm
        /// </summary>
        /// <param name="prevImg"></param>
        /// <param name="nextImg"></param>
        /// <param name="prevPts"></param>
        /// <param name="nextPts"></param>
        /// <param name="status"></param>
        /// <param name="err"></param>
        /// <param name="winSize"></param>
        /// <param name="maxLevel"></param>
        /// <param name="criteria"></param>
        /// <param name="flags"></param>
        /// <param name="minEigThreshold"></param>
        public static void CalcOpticalFlowPyrLK(
            InputArray prevImg, InputArray nextImg,
            Point2f[] prevPts, ref Point2f[] nextPts,
            out byte[] status, out float[] err,
            Size? winSize = null,
            int maxLevel = 3,
            TermCriteria? criteria = null,
            OpticalFlowFlags flags = OpticalFlowFlags.None,
            double minEigThreshold = 1e-4)
        {
            if (prevImg == null)
                throw new ArgumentNullException("prevImg");
            if (nextImg == null)
                throw new ArgumentNullException("nextImg");
            if (prevPts == null)
                throw new ArgumentNullException("prevPts");
            if (nextPts == null)
                throw new ArgumentNullException("nextPts");
            prevImg.ThrowIfDisposed();
            nextImg.ThrowIfDisposed();

            Size winSize0 = winSize.GetValueOrDefault(new Size(21, 21));
            TermCriteria criteria0 = criteria.GetValueOrDefault(
                TermCriteria.Both(30, 0.01));

            using (var nextPtsVec = new VectorOfPoint2f())
            using (var statusVec = new VectorOfByte())
            using (var errVec = new VectorOfFloat())
            {
                NativeMethods.video_calcOpticalFlowPyrLK_vector(
                    prevImg.CvPtr, nextImg.CvPtr, prevPts, prevPts.Length,
                    nextPtsVec.CvPtr, statusVec.CvPtr, errVec.CvPtr, 
                    winSize0, maxLevel, criteria0, (int)flags, minEigThreshold);
                nextPts = nextPtsVec.ToArray();
                status = statusVec.ToArray();
                err = errVec.ToArray();
            }
        }

        /// <summary>
        /// Computes a dense optical flow using the Gunnar Farneback's algorithm.
        /// </summary>
        /// <param name="prev">first 8-bit single-channel input image.</param>
        /// <param name="next">second input image of the same size and the same type as prev.</param>
        /// <param name="flow">computed flow image that has the same size as prev and type CV_32FC2.</param>
        /// <param name="pyrScale">parameter, specifying the image scale (&lt;1) to build pyramids for each image; 
        /// pyrScale=0.5 means a classical pyramid, where each next layer is twice smaller than the previous one.</param>
        /// <param name="levels">number of pyramid layers including the initial image; 
        /// levels=1 means that no extra layers are created and only the original images are used.</param>
        /// <param name="winsize">averaging window size; larger values increase the algorithm robustness to 
        /// image noise and give more chances for fast motion detection, but yield more blurred motion field.</param>
        /// <param name="iterations">number of iterations the algorithm does at each pyramid level.</param>
        /// <param name="polyN">size of the pixel neighborhood used to find polynomial expansion in each pixel; 
        /// larger values mean that the image will be approximated with smoother surfaces, 
        /// yielding more robust algorithm and more blurred motion field, typically poly_n =5 or 7.</param>
        /// <param name="polySigma">standard deviation of the Gaussian that is used to smooth derivatives used as 
        /// a basis for the polynomial expansion; for polyN=5, you can set polySigma=1.1, 
        /// for polyN=7, a good value would be polySigma=1.5.</param>
        /// <param name="flags">operation flags that can be a combination of OPTFLOW_USE_INITIAL_FLOW and/or OPTFLOW_FARNEBACK_GAUSSIAN</param>
        public static void CalcOpticalFlowFarneback(InputArray prev, InputArray next,
            InputOutputArray flow, double pyrScale, int levels, int winsize,
            int iterations, int polyN, double polySigma, OpticalFlowFlags flags)
        {
            if (prev == null)
                throw new ArgumentNullException("prev");
            if (next == null)
                throw new ArgumentNullException("next");
            if (flow == null)
                throw new ArgumentNullException("flow");
            prev.ThrowIfDisposed();
            next.ThrowIfDisposed();
            flow.ThrowIfNotReady();

            NativeMethods.video_calcOpticalFlowFarneback(prev.CvPtr, next.CvPtr, 
                flow.CvPtr, pyrScale, levels, winsize, iterations, polyN, polySigma, 
                (int)flags);

            flow.Fix();
        }

        /// <summary>
        /// Estimates the best-fit Euqcidean, similarity, affine or perspective transformation
        /// that maps one 2D point set to another or one image to another.
        /// </summary>
        /// <param name="src">First input 2D point set stored in std::vector or Mat, or an image stored in Mat.</param>
        /// <param name="dst">Second input 2D point set of the same size and the same type as A, or another image.</param>
        /// <param name="fullAffine">If true, the function finds an optimal affine transformation with no additional restrictions (6 degrees of freedom). 
        /// Otherwise, the class of transformations to choose from is limited to combinations of translation, rotation, and uniform scaling (5 degrees of freedom).</param>
        /// <returns></returns>
        public static Mat EstimateRigidTransform(
            InputArray src, InputArray dst, bool fullAffine)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            IntPtr result = NativeMethods.video_estimateRigidTransform(
                src.CvPtr, dst.CvPtr, fullAffine ? 1 : 0);
            return new Mat(result);
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
                throw new ArgumentNullException("from");
            if (to == null)
                throw new ArgumentNullException("to");
            if (flow == null)
                throw new ArgumentNullException("flow");
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            flow.ThrowIfDisposed();

            NativeMethods.video_calcOpticalFlowSF1(
                from.CvPtr, to.CvPtr, flow.CvPtr,
                layers, averagingBlockSize, maxFlow);
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
                throw new ArgumentNullException("from");
            if (to == null)
                throw new ArgumentNullException("to");
            if (flow == null)
                throw new ArgumentNullException("flow");
            from.ThrowIfDisposed();
            to.ThrowIfDisposed();
            flow.ThrowIfDisposed();

            NativeMethods.video_calcOpticalFlowSF2(
                from.CvPtr, to.CvPtr, flow.CvPtr,
                layers, averagingBlockSize, maxFlow,
                sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix,
                sigmaColorFix, occThr, upscaleAveragingRadius,
                upscaleSigmaDist, upscaleSigmaColor, speedUpThr);
        }

        /// <summary>
        /// Implementation of the Zach, Pock and Bischof Dual TV-L1 Optical Flow method
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_DualTVL1()
        {
            return DenseOpticalFlow.CreateOptFlow_DualTVL1();
        }
    }
}
