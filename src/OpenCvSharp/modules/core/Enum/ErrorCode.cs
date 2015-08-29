namespace OpenCvSharp
{
    /// <summary>
    /// Error status codes
    /// </summary>
    public enum ErrorCode 
    {
        /* this part of CVStatus is compatible with IPLStatus 
           Some of below symbols are not [yet] used in OpenCV
        */

        // ReSharper disable InconsistentNaming

        /// <summary>
        /// everithing is ok [CV_StsOk]
        /// </summary>
        StsOk = 0,

        /// <summary>
        /// pseudo error for back trace [CV_StsBackTrace]
        /// </summary>
        StsBackTrace = -1,

        /// <summary>
        /// unknown /unspecified error [CV_StsError]
        /// </summary>
        StsError = -2,

        /// <summary>
        /// internal error (bad state)  [CV_StsInternal]
        /// </summary>
        StsInternal = -3,

        /// <summary>
        /// insufficient memory [CV_StsNoMem]
        /// </summary>
        StsNoMem = -4,

        /// <summary>
        /// function arg/param is bad [CV_StsBadArg]
        /// </summary>
        StsBadArg = -5,

        /// <summary>
        /// unsupported function [CV_StsBadFunc]
        /// </summary>
        StsBadFunc = -6,

        /// <summary>
        /// iter. didn't converge [CV_StsNoConv]
        /// </summary>
        StsNoConv = -7,

        /// <summary>
        /// tracing [CV_StsAutoTrace]
        /// </summary>
        StsAutoTrace = -8,


        /// <summary>
        /// image header is NULL [CV_HeaderIsNull]
        /// </summary>
        HeaderIsNull = -9,

        /// <summary>
        /// image size is invalid [CV_BadImageSize]
        /// </summary>
        BadImageSize = -10,

        /// <summary>
        /// offset is invalid [CV_BadOffset]
        /// </summary>
        BadOffset = -11,

        /// <summary>
        /// [CV_BadOffset]
        /// </summary>
        BadDataPtr = -12,

        /// <summary>
        /// [CV_BadStep]
        /// </summary>
        BadStep = -13,

        /// <summary>
        /// [CV_BadModelOrChSeq]
        /// </summary>
        BadModelOrChSeq = -14,

        /// <summary>
        /// [CV_BadNumChannels]
        /// </summary>
        BadNumChannels = -15,

        /// <summary>
        /// [CV_BadNumChannel1U]
        /// </summary>
        BadNumChannel1U = -16,

        /// <summary>
        /// [CV_BadDepth]
        /// </summary>
        BadDepth = -17,

        /// <summary>
        /// [CV_BadAlphaChannel]
        /// </summary>
        BadAlphaChannel = -18,

        /// <summary>
        /// [CV_BadOrder]
        /// </summary>
        BadOrder = -19,

        /// <summary>
        /// [CV_BadOrigin]
        /// </summary>
        BadOrigin = -20,

        /// <summary>
        /// [CV_BadAlign]
        /// </summary>
        BadAlign = -21,

        /// <summary>
        /// [CV_BadCallBack]
        /// </summary>
        BadCallBack = -22,

        /// <summary>
        /// [CV_BadTileSize]
        /// </summary>
        BadTileSize = -23,

        /// <summary>
        /// [CV_BadCOI]
        /// </summary>
        BadCOI = -24,

        /// <summary>
        /// [CV_BadROISize]
        /// </summary>
        BadROISize = -25,

        /// <summary>
        /// [CV_MaskIsTiled]
        /// </summary>
        MaskIsTiled = -26,

        /// <summary>
        /// null pointer [CV_StsNullPtr]
        /// </summary>
        StsNullPtr = -27,

        /// <summary>
        /// incorrect vector length [CV_StsVecLengthErr]
        /// </summary>
        StsVecLengthErr = -28,

        /// <summary>
        /// incorr. filter structure content [CV_StsFilterStructContentErr]
        /// </summary>
        StsFilterStructContentErr = -29,

        /// <summary>
        /// incorr. transform kernel content [CV_StsKernelStructContentErr]
        /// </summary>
        StsKernelStructContentErr = -30,

        /// <summary>
        /// incorrect filter ofset value [CV_StsFilterOffsetErr]
        /// </summary>
        StsFilterOffsetErr = -31,

        /*extra for CV */

        /// <summary>
        /// the input/output structure size is incorrect [CV_StsBadSize]
        /// </summary>
        StsBadSize = -201,

        /// <summary>
        /// division by zero [CV_StsDivByZero]
        /// </summary>
        StsDivByZero = -202,

        /// <summary>
        /// in-place operation is not supported [CV_StsInplaceNotSupported]
        /// </summary>
        StsInplaceNotSupported = -203,

        /// <summary>
        /// request can't be completed [CV_StsObjectNotFound]
        /// </summary>
        StsObjectNotFound = -204,

        /// <summary>
        /// formats of input/output arrays differ [CV_StsUnmatchedFormats]
        /// </summary>
        StsUnmatchedFormats = -205,

        /// <summary>
        /// flag is wrong or not supported [CV_StsBadFlag]
        /// </summary>
        StsBadFlag = -206,

        /// <summary>
        /// bad CvPoint [CV_StsBadPoint]
        /// </summary>
        StsBadPoint = -207,

        /// <summary>
        /// bad format of mask (neither 8uC1 nor 8sC1) [CV_StsBadMask]
        /// </summary>
        StsBadMask = -208,

        /// <summary>
        /// sizes of input/output structures do not match [CV_StsUnmatchedSizes]
        /// </summary>
        StsUnmatchedSizes = -209,

        /// <summary>
        /// the data format/type is not supported by the function [CV_StsUnsupportedFormat]
        /// </summary>
        StsUnsupportedFormat = -210,

        /// <summary>
        /// some of parameters are out of range [CV_StsOutOfRange]
        /// </summary>
        StsOutOfRange = -211,

        /// <summary>
        /// invalid syntax/structure of the parsed file [CV_StsParseError]
        /// </summary>
        StsParseError = -212,

        /// <summary>
        /// the requested function/feature is not implemented [CV_StsNotImplemented]
        /// </summary>
        StsNotImplemented = -213,

        /// <summary>
        /// an allocated block has been corrupted [CV_StsBadMemBlock]
        /// </summary>
        StsBadMemBlock = -214,

        /// <summary>
        /// assertion failed
        /// </summary>
        StsAssert = -215,

#pragma warning disable 1591
        GpuNotSupported = -216,
        GpuApiCallError = -217,
        OpenGlNotSupported = -218,
        OpenGlApiCallError = -219,
        OpenCLApiCallError = -220,
        OpenCLDoubleNotSupported = -221,
        OpenCLInitError = -222,
        OpenCLNoAMDBlasFft = -223
    }
}
