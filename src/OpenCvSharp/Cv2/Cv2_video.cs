using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class Cv2
    {
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
                throw new ArgumentNullException(nameof(probImage));
            probImage.ThrowIfDisposed();

            RotatedRect result = NativeMethods.video_CamShift(
                probImage.CvPtr, ref window, criteria);
            GC.KeepAlive(probImage);
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
                throw new ArgumentNullException(nameof(probImage));
            probImage.ThrowIfDisposed();

            int result = NativeMethods.video_meanShift(
                probImage.CvPtr, ref window, criteria);
            GC.KeepAlive(probImage);
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
            BorderTypes pyrBorder = BorderTypes.Reflect101,
            BorderTypes derivBorder = BorderTypes.Constant,
            bool tryReuseInputImage = true)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (pyramid == null)
                throw new ArgumentNullException(nameof(pyramid));
            img.ThrowIfDisposed();
            pyramid.ThrowIfNotReady();

            int result = NativeMethods.video_buildOpticalFlowPyramid1(
                img.CvPtr, pyramid.CvPtr, winSize, maxLevel, withDerivatives ? 1 : 0, 
                (int)pyrBorder, (int)derivBorder, tryReuseInputImage ? 1 : 0);
            pyramid.Fix();
            GC.KeepAlive(img);
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
            InputArray img, out Mat[] pyramid,
            Size winSize, int maxLevel,
            bool withDerivatives = true,
            BorderTypes pyrBorder = BorderTypes.Reflect101,
            BorderTypes derivBorder = BorderTypes.Constant,
            bool tryReuseInputImage = true)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            using (var pyramidVec = new VectorOfMat())
            {
                int result = NativeMethods.video_buildOpticalFlowPyramid2(
                    img.CvPtr, pyramidVec.CvPtr, winSize, maxLevel, withDerivatives ? 1 : 0,
                    (int) pyrBorder, (int) derivBorder, tryReuseInputImage ? 1 : 0);
                GC.KeepAlive(img);
                pyramid = pyramidVec.ToArray();
                return result;
            }
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
                throw new ArgumentNullException(nameof(prevImg));
            if (nextImg == null)
                throw new ArgumentNullException(nameof(nextImg));
            if (prevPts == null)
                throw new ArgumentNullException(nameof(prevPts));
            if (nextPts == null)
                throw new ArgumentNullException(nameof(nextPts));
            if (status == null)
                throw new ArgumentNullException(nameof(status));
            if (err == null)
                throw new ArgumentNullException(nameof(err));
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
                status.CvPtr, err.CvPtr, winSize0, maxLevel,
                criteria0, (int)flags, minEigThreshold);
            GC.KeepAlive(prevImg);
            GC.KeepAlive(nextImg);
            GC.KeepAlive(prevPts);
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
                throw new ArgumentNullException(nameof(prevImg));
            if (nextImg == null)
                throw new ArgumentNullException(nameof(nextImg));
            if (prevPts == null)
                throw new ArgumentNullException(nameof(prevPts));
            if (nextPts == null)
                throw new ArgumentNullException(nameof(nextPts));
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
                GC.KeepAlive(prevImg);
                GC.KeepAlive(nextImg);
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
                throw new ArgumentNullException(nameof(prev));
            if (next == null)
                throw new ArgumentNullException(nameof(next));
            if (flow == null)
                throw new ArgumentNullException(nameof(flow));
            prev.ThrowIfDisposed();
            next.ThrowIfDisposed();
            flow.ThrowIfNotReady();

            NativeMethods.video_calcOpticalFlowFarneback(prev.CvPtr, next.CvPtr, 
                flow.CvPtr, pyrScale, levels, winsize, iterations, polyN, polySigma, 
                (int)flags);
            GC.KeepAlive(prev);
            GC.KeepAlive(next);
            flow.Fix();
        }
    }
}
