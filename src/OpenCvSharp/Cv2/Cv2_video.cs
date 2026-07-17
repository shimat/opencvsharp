using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

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
        NativeMethods.HandleException(
            NativeMethods.video_CamShift(probImage.Proxy, ref window, criteria, out var ret));
        GC.KeepAlive(probImage.Source);
        return ret;
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
        NativeMethods.HandleException(
            NativeMethods.video_meanShift(probImage.Proxy, ref window, criteria, out var ret));
        GC.KeepAlive(probImage.Source);
        return ret;
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
        NativeMethods.HandleException(
            NativeMethods.video_buildOpticalFlowPyramid1(img.Proxy, pyramid.Proxy, winSize, maxLevel, withDerivatives ? 1 : 0, (int) pyrBorder, (int) derivBorder, tryReuseInputImage ? 1 : 0, out var ret));
        GC.KeepAlive(img.Source);
        return ret;
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
        using var pyramidVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.video_buildOpticalFlowPyramid2(img.Proxy, pyramidVec.CvPtr, winSize, maxLevel, withDerivatives ? 1 : 0, (int) pyrBorder, (int) derivBorder, tryReuseInputImage ? 1 : 0, out var ret));
        GC.KeepAlive(img.Source);
        pyramid = pyramidVec.ToArray();
        return ret;
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
        var winSize0 = winSize.GetValueOrDefault(new Size(21, 21));
        var criteria0 = criteria.GetValueOrDefault(
            TermCriteria.Both(30, 0.01));

        NativeMethods.HandleException(
            NativeMethods.video_calcOpticalFlowPyrLK_InputArray(prevImg.Proxy, nextImg.Proxy, prevPts.Proxy, nextPts.Proxy, status.Proxy, err.Proxy, winSize0, maxLevel, criteria0, (int) flags, minEigThreshold));
        GC.KeepAlive(prevImg.Source);
        GC.KeepAlive(nextImg.Source);
        GC.KeepAlive(prevPts.Source);
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
        InputArray prevImg, 
        InputArray nextImg,
        Point2f[] prevPts, 
        ref Point2f[] nextPts,
        out byte[] status, 
        out float[] err,
        Size? winSize = null,
        int maxLevel = 3,
        TermCriteria? criteria = null,
        OpticalFlowFlags flags = OpticalFlowFlags.None,
        double minEigThreshold = 1e-4)
    {
        ArgumentNullException.ThrowIfNull(prevPts);
        ArgumentNullException.ThrowIfNull(nextPts);

        var winSize0 = winSize.GetValueOrDefault(new Size(21, 21));
        var criteria0 = criteria.GetValueOrDefault(
            TermCriteria.Both(30, 0.01));

        using var nextPtsVec = new StdVector<Point2f>(nextPts);
        using var statusVec = new StdVector<byte>();
        using var errVec = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.video_calcOpticalFlowPyrLK_vector(prevImg.Proxy, nextImg.Proxy, prevPts, prevPts.Length, nextPtsVec.CvPtr, statusVec.CvPtr, errVec.CvPtr, winSize0, maxLevel, criteria0, (int) flags, minEigThreshold));
        GC.KeepAlive(prevImg.Source);
        GC.KeepAlive(nextImg.Source);
        nextPts = nextPtsVec.ToArray();
        status = statusVec.ToArray();
        err = errVec.ToArray();
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
        NativeMethods.HandleException(
            NativeMethods.video_calcOpticalFlowFarneback(prev.Proxy, next.Proxy, flow.Proxy, pyrScale, levels, winsize, iterations, polyN, polySigma, (int) flags));
        GC.KeepAlive(prev.Source);
        GC.KeepAlive(next.Source);
    }

    /// <summary>
    /// Computes the Enhanced Correlation Coefficient value between two images @cite EP08 .
    /// </summary>
    /// <param name="templateImage">single-channel template image; CV_8U or CV_32F array.</param>
    /// <param name="inputImage">single-channel input image to be warped to provide an image similar to templateImage, same type as templateImage.</param>
    /// <param name="inputMask">An optional mask to indicate valid values of inputImage.</param>
    /// <returns></returns>
    public static double ComputeECC(InputArray templateImage, InputArray inputImage, InputArray inputMask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.video_computeECC(templateImage.Proxy, inputImage.Proxy, inputMask.Proxy, out var ret));

        GC.KeepAlive(templateImage.Source);
        GC.KeepAlive(inputImage.Source);
        GC.KeepAlive(inputMask.Source);
        return ret;
    }

    /// <summary>
    /// Finds the geometric transform (warp) between two images in terms of the ECC criterion @cite EP08 .
    /// </summary>
    /// <param name="templateImage">single-channel template image; CV_8U or CV_32F array.</param>
    /// <param name="inputImage">single-channel input image which should be warped with the final warpMatrix in
    /// order to provide an image similar to templateImage, same type as templateImage.</param>
    /// <param name="warpMatrix">floating-point \f$2\times 3\f$ or \f$3\times 3\f$ mapping matrix (warp).</param>
    /// <param name="motionType">parameter, specifying the type of motion</param>
    /// <param name="criteria">parameter, specifying the termination criteria of the ECC algorithm;
    /// criteria.epsilon defines the threshold of the increment in the correlation coefficient between two
    /// iterations(a negative criteria.epsilon makes criteria.maxcount the only termination criterion).
    /// Default values are shown in the declaration above.</param>
    /// <param name="inputMask">An optional mask to indicate valid values of inputImage.</param>
    /// <param name="gaussFiltSize">An optional value indicating size of gaussian blur filter; (DEFAULT: 5)</param>
    /// <returns></returns>
    public static double FindTransformECC(
        InputArray templateImage,
        InputArray inputImage,
        InputOutputArray warpMatrix,
        MotionTypes motionType,
        TermCriteria criteria,
        InputArray inputMask = default, 
        int gaussFiltSize = 5)
    {
        NativeMethods.HandleException(
            NativeMethods.video_findTransformECC1(templateImage.Proxy, inputImage.Proxy, warpMatrix.Proxy, (int)motionType, criteria, inputMask.Proxy, gaussFiltSize, out var ret));

        GC.KeepAlive(templateImage.Source);
        GC.KeepAlive(inputImage.Source);
        GC.KeepAlive(warpMatrix.Source);
        GC.KeepAlive(inputMask.Source);
        return ret;
    }

    /// <summary>
    /// Finds the geometric transform (warp) between two images in terms of the ECC criterion @cite EP08 .
    /// </summary>
    /// <param name="templateImage">single-channel template image; CV_8U or CV_32F array.</param>
    /// <param name="inputImage">single-channel input image which should be warped with the final warpMatrix in
    /// order to provide an image similar to templateImage, same type as templateImage.</param>
    /// <param name="warpMatrix">floating-point \f$2\times 3\f$ or \f$3\times 3\f$ mapping matrix (warp).</param>
    /// <param name="motionType">parameter, specifying the type of motion</param>
    /// <param name="criteria">parameter, specifying the termination criteria of the ECC algorithm;
    /// criteria.epsilon defines the threshold of the increment in the correlation coefficient between two
    /// iterations(a negative criteria.epsilon makes criteria.maxcount the only termination criterion).
    /// Default values are shown in the declaration above.</param>
    /// <param name="inputMask">An optional mask to indicate valid values of inputImage.</param>
    /// <returns></returns>
    public static double FindTransformECC(
        InputArray templateImage,
        InputArray inputImage,
        InputOutputArray warpMatrix, 
        MotionTypes motionType = MotionTypes.Affine,
        TermCriteria? criteria = null,
        InputArray inputMask = default)
    {
        var criteriaValue = criteria.GetValueOrDefault(new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 50, 0.001));

        NativeMethods.HandleException(
            NativeMethods.video_findTransformECC2(templateImage.Proxy, inputImage.Proxy, warpMatrix.Proxy, (int)motionType, criteriaValue, inputMask.Proxy, out var ret));

        GC.KeepAlive(templateImage.Source);
        GC.KeepAlive(inputImage.Source);
        GC.KeepAlive(warpMatrix.Source);
        GC.KeepAlive(inputMask.Source);
        return ret;
    }

    /// <summary>
    /// Finds the geometric transform (warp) between two images in terms of the ECC criterion, using
    /// validity masks for both the template and the input images.
    /// This extends <see cref="FindTransformECC(InputArray,InputArray,InputOutputArray,MotionTypes,TermCriteria?,InputArray)"/>
    /// by adding a mask for the template image. The Enhanced Correlation Coefficient is evaluated only
    /// over pixels that are valid in both images: on each iteration inputMask is warped into the
    /// template frame and combined with templateMask, and only the intersection of these masks
    /// contributes to the objective function.
    /// </summary>
    /// <param name="templateImage">1 or 3 channel template image; CV_8U, CV_16U, CV_32F, CV_64F type.</param>
    /// <param name="inputImage">input image which should be warped with the final warpMatrix in
    /// order to provide an image similar to templateImage, same type as templateImage.</param>
    /// <param name="templateMask">single-channel 8-bit mask for templateImage indicating valid pixels
    /// to be used in the alignment. Must have the same size as templateImage.</param>
    /// <param name="inputMask">single-channel 8-bit mask for inputImage indicating valid pixels
    /// before warping. Must have the same size as inputImage.</param>
    /// <param name="warpMatrix">floating-point 2x3 or 3x3 mapping matrix (warp).</param>
    /// <param name="motionType">parameter, specifying the type of motion</param>
    /// <param name="criteria">parameter, specifying the termination criteria of the ECC algorithm</param>
    /// <param name="gaussFiltSize">size of the Gaussian blur filter used for smoothing images and
    /// masks before computing the alignment (DEFAULT: 5).</param>
    /// <returns></returns>
    public static double FindTransformECCWithMask(
        InputArray templateImage,
        InputArray inputImage,
        InputArray templateMask,
        InputArray inputMask,
        InputOutputArray warpMatrix,
        MotionTypes motionType = MotionTypes.Affine,
        TermCriteria? criteria = null,
        int gaussFiltSize = 5)
    {
        var criteriaValue = criteria.GetValueOrDefault(new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 50, 1e-6));

        NativeMethods.HandleException(
            NativeMethods.video_findTransformECCWithMask(
                templateImage.Proxy, inputImage.Proxy, templateMask.Proxy, inputMask.Proxy,
                warpMatrix.Proxy, (int)motionType, criteriaValue, gaussFiltSize, out var ret));

        GC.KeepAlive(templateImage.Source);
        GC.KeepAlive(inputImage.Source);
        GC.KeepAlive(templateMask.Source);
        GC.KeepAlive(inputMask.Source);
        GC.KeepAlive(warpMatrix.Source);
        return ret;
    }

    /// <summary>
    /// Finds the geometric transform (warp) between two images in terms of the ECC criterion. Uses pyramids,
    /// making the function more stable and able to correctly handle more sophisticated cases than
    /// <see cref="FindTransformECC(InputArray,InputArray,InputOutputArray,MotionTypes,TermCriteria?,InputArray)"/>.
    /// </summary>
    /// <param name="reference">Single channel reference image; CV_8U, CV_16U, CV_32F, CV_64F type.</param>
    /// <param name="sample">sample image which should be warped with the final warpMatrix in order
    /// to provide an image similar to reference, same type as reference.</param>
    /// <param name="warpMatrix">floating-point 2x3 or 3x3 mapping matrix (warp).</param>
    /// <param name="eccParams">List of the algorithm parameters. See <see cref="ECCParameters"/> for details.</param>
    /// <param name="referenceMask">An optional single channel mask to indicate valid values of reference.</param>
    /// <param name="sampleMask">An optional single channel mask to indicate valid values of sample.</param>
    /// <returns></returns>
    public static double FindTransformECCMultiScale(
        InputArray reference,
        InputArray sample,
        InputOutputArray warpMatrix,
        ECCParameters? eccParams = null,
        InputArray referenceMask = default,
        InputArray sampleMask = default)
    {
        eccParams ??= new ECCParameters();
        using var itersPerLevelVec = new StdVector<int>(eccParams.ItersPerLevel ?? []);
        var nativeEccParams = new CvECCParameters
        {
            MotionType = (int)eccParams.MotionType,
            Criteria = eccParams.Criteria,
            GaussFiltSize = eccParams.GaussFiltSize,
            NLevels = eccParams.NLevels,
            Interpolation = (int)eccParams.Interpolation,
        };

        NativeMethods.HandleException(
            NativeMethods.video_findTransformECCMultiScale(
                reference.Proxy, sample.Proxy, warpMatrix.Proxy, in nativeEccParams,
                itersPerLevelVec.CvPtr,
                referenceMask.Proxy, sampleMask.Proxy, out var ret));

        GC.KeepAlive(reference.Source);
        GC.KeepAlive(sample.Source);
        GC.KeepAlive(warpMatrix.Source);
        GC.KeepAlive(referenceMask.Source);
        GC.KeepAlive(sampleMask.Source);
        return ret;
    }

    /// <summary>
    /// Reads a .flo file.
    /// The function loads a flow field from a file and returns it as a single matrix. Resulting Mat
    /// has a type CV_32FC2 - floating-point, 2-channel. First channel corresponds to the flow in the
    /// horizontal direction (u), second - vertical (v).
    /// </summary>
    /// <param name="path">Path to the file to be loaded</param>
    /// <returns></returns>
    public static Mat ReadOpticalFlow(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        NativeMethods.HandleException(
            NativeMethods.video_readOpticalFlow(path, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Writes a .flo file to disk.
    /// The flow field must be a 2-channel, floating-point matrix (CV_32FC2). First channel
    /// corresponds to the flow in the horizontal direction (u), second - vertical (v).
    /// </summary>
    /// <param name="path">Path to the file to be written</param>
    /// <param name="flow">Flow field to be stored</param>
    /// <returns>true on success, false otherwise</returns>
    public static bool WriteOpticalFlow(string path, InputArray flow)
    {
        ArgumentNullException.ThrowIfNull(path);

        NativeMethods.HandleException(
            NativeMethods.video_writeOpticalFlow(path, flow.Proxy, out var ret));
        GC.KeepAlive(flow.Source);
        return ret != 0;
    }
}
