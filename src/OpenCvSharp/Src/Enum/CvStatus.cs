/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// エラーステータス
    /// </summary>
#else
    /// <summary>
    /// Error status
    /// </summary>
#endif
    public enum CvStatus : int
    {
        /* this part of CVStatus is compatible with IPLStatus 
           Some of below symbols are not [yet] used in OpenCV
        */

        /// <summary>
        /// everithing is ok [CV_StsOk]
        /// </summary>
        StsOk = CvConst.CV_StsOk,
        /// <summary>
        /// pseudo error for back trace [CV_StsBackTrace]
        /// </summary>
        StsBackTrace = CvConst.CV_StsBackTrace,
        /// <summary>
        /// unknown /unspecified error [CV_StsError]
        /// </summary>
        StsError = CvConst.CV_StsError,
        /// <summary>
        /// internal error (bad state)  [CV_StsInternal]
        /// </summary>
        StsInternal = CvConst.CV_StsInternal,
        /// <summary>
        /// insufficient memory [CV_StsNoMem]
        /// </summary>
        StsNoMem = CvConst.CV_StsNoMem,
        /// <summary>
        /// function arg/param is bad [CV_StsBadArg]
        /// </summary>
        StsBadArg = CvConst.CV_StsBadArg,
        /// <summary>
        /// unsupported function [CV_StsBadFunc]
        /// </summary>
        StsBadFunc = CvConst.CV_StsBadFunc,
        /// <summary>
        /// iter. didn't converge [CV_StsNoConv]
        /// </summary>
        StsNoConv = CvConst.CV_StsNoConv,
        /// <summary>
        /// tracing [CV_StsAutoTrace]
        /// </summary>
        StsAutoTrace = CvConst.CV_StsAutoTrace,


        /// <summary>
        /// image header is NULL [CV_HeaderIsNull]
        /// </summary>
        HeaderIsNull = CvConst.CV_HeaderIsNull,
        /// <summary>
        /// image size is invalid [CV_BadImageSize]
        /// </summary>
        BadImageSize = CvConst.CV_BadImageSize,
        /// <summary>
        /// offset is invalid [CV_BadOffset]
        /// </summary>
        BadOffset = CvConst.CV_BadOffset,
        /// <summary>
        /// [CV_BadOffset]
        /// </summary>
        BadDataPtr = CvConst.CV_BadDataPtr,
        /// <summary>
        /// [CV_BadStep]
        /// </summary>
        BadStep = CvConst.CV_BadStep,
        /// <summary>
        /// [CV_BadModelOrChSeq]
        /// </summary>
        BadModelOrChSeq = CvConst.CV_BadModelOrChSeq,
        /// <summary>
        /// [CV_BadNumChannels]
        /// </summary>
        BadNumChannels = CvConst.CV_BadNumChannels,
        /// <summary>
        /// [CV_BadNumChannel1U]
        /// </summary>
        BadNumChannel1U = CvConst.CV_BadNumChannel1U,
        /// <summary>
        /// [CV_BadDepth]
        /// </summary>
        BadDepth = CvConst.CV_BadDepth,
        /// <summary>
        /// [CV_BadAlphaChannel]
        /// </summary>
        BadAlphaChannel = CvConst.CV_BadAlphaChannel,
        /// <summary>
        /// [CV_BadOrder]
        /// </summary>
        BadOrder = CvConst.CV_BadOrder,
        /// <summary>
        /// [CV_BadOrigin]
        /// </summary>
        BadOrigin = CvConst.CV_BadOrigin,
        /// <summary>
        /// [CV_BadAlign]
        /// </summary>
        BadAlign = CvConst.CV_BadAlign,
        /// <summary>
        /// [CV_BadCallBack]
        /// </summary>
        BadCallBack = CvConst.CV_BadCallBack,
        /// <summary>
        /// [CV_BadTileSize]
        /// </summary>
        BadTileSize = CvConst.CV_BadTileSize,
        /// <summary>
        /// [CV_BadCOI]
        /// </summary>
        BadCOI = CvConst.CV_BadCOI,
        /// <summary>
        /// [CV_BadROISize]
        /// </summary>
        BadROISize = CvConst.CV_BadROISize,


        /// <summary>
        /// [CV_MaskIsTiled]
        /// </summary>
        MaskIsTiled = CvConst.CV_MaskIsTiled,


        /// <summary>
        /// null pointer [CV_StsNullPtr]
        /// </summary>
        StsNullPtr = CvConst.CV_StsNullPtr,
        /// <summary>
        /// incorrect vector length [CV_StsVecLengthErr]
        /// </summary>
        StsVecLengthErr = CvConst.CV_StsVecLengthErr,
        /// <summary>
        /// incorr. filter structure content [CV_StsFilterStructContentErr]
        /// </summary>
        StsFilterStructContentErr = CvConst.CV_StsFilterStructContentErr,
        /// <summary>
        /// incorr. transform kernel content [CV_StsKernelStructContentErr]
        /// </summary>
        StsKernelStructContentErr = CvConst.CV_StsKernelStructContentErr,
        /// <summary>
        /// incorrect filter ofset value [CV_StsFilterOffsetErr]
        /// </summary>
        StsFilterOffsetErr = CvConst.CV_StsFilterOffsetErr,


        /*extra for CV */


        /// <summary>
        /// the input/output structure size is incorrect [CV_StsBadSize]
        /// </summary>
        StsBadSize = CvConst.CV_StsBadSize,
        /// <summary>
        /// division by zero [CV_StsDivByZero]
        /// </summary>
        StsDivByZero = CvConst.CV_StsDivByZero,
        /// <summary>
        /// in-place operation is not supported [CV_StsInplaceNotSupported]
        /// </summary>
        StsInplaceNotSupported = CvConst.CV_StsInplaceNotSupported,
        /// <summary>
        /// request can't be completed [CV_StsObjectNotFound]
        /// </summary>
        StsObjectNotFound = CvConst.CV_StsObjectNotFound,
        /// <summary>
        /// formats of input/output arrays differ [CV_StsUnmatchedFormats]
        /// </summary>
        StsUnmatchedFormats = CvConst.CV_StsUnmatchedFormats,
        /// <summary>
        /// flag is wrong or not supported [CV_StsBadFlag]
        /// </summary>
        StsBadFlag = CvConst.CV_StsBadFlag,
        /// <summary>
        /// bad CvPoint [CV_StsBadPoint]
        /// </summary>
        StsBadPoint = CvConst.CV_StsBadPoint,
        /// <summary>
        /// bad format of mask (neither 8uC1 nor 8sC1) [CV_StsBadMask]
        /// </summary>
        StsBadMask = CvConst.CV_StsBadMask,
        /// <summary>
        /// sizes of input/output structures do not match [CV_StsUnmatchedSizes]
        /// </summary>
        StsUnmatchedSizes = CvConst.CV_StsUnmatchedSizes,
        /// <summary>
        /// the data format/type is not supported by the function [CV_StsUnsupportedFormat]
        /// </summary>
        StsUnsupportedFormat = CvConst.CV_StsUnsupportedFormat,
        /// <summary>
        /// some of parameters are out of range [CV_StsOutOfRange]
        /// </summary>
        StsOutOfRange = CvConst.CV_StsOutOfRange,
        /// <summary>
        /// invalid syntax/structure of the parsed file [CV_StsParseError]
        /// </summary>
        StsParseError = CvConst.CV_StsParseError,
        /// <summary>
        /// the requested function/feature is not implemented [CV_StsNotImplemented]
        /// </summary>
        StsNotImplemented = CvConst.CV_StsNotImplemented,
        /// <summary>
        /// an allocated block has been corrupted [CV_StsBadMemBlock]
        /// </summary>
        StsBadMemBlock = CvConst.CV_StsBadMemBlock,
    }
}
