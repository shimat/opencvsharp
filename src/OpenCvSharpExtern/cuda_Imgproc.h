#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaimgproc.hpp>

// ---------- Alpha Composite --------------------------------------------------
CVAPI(ExceptionStatus) cuda_alphaComp(cv::_InputArray *img1, cv::_InputArray *img2, cv::_OutputArray *dst, int alpha_op, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::alphaComp(*img1, *img2, *dst, alpha_op, streamRef);
    END_WRAP
}

// ---------- BilateralFilter --------------------------------------------------
CVAPI(ExceptionStatus) cuda_bilateralFilter( cv::_InputArray *src, cv::_OutputArray *dst, int kernel_size, float sigma_color, float sigma_spatial, int borderMode, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bilateralFilter(*src, *dst, kernel_size, sigma_color, sigma_spatial, borderMode, streamRef);
    END_WRAP
}

// ---------- blendLinear --------------------------------------------------
CVAPI(ExceptionStatus) cuda_blendLinear(cv::_InputArray *img1, cv::_InputArray *img2, cv::_InputArray *weights1, cv::_InputArray *weights2, cv::_OutputArray *result, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::blendLinear(*img1, *img2, *weights1, *weights2, *result, streamRef);
    END_WRAP
}

// ---------- calcHist --------------------------------------------------
CVAPI(ExceptionStatus) cuda_calcHist(cv::_InputArray *src, cv::_InputArray *mask, cv::_OutputArray *hist, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::calcHist(*src, mask ? *mask : cv::noArray(), *hist, streamRef);
    END_WRAP
}

// ---------- cuda_TemplateMatching_match --------------------------------------------------
CVAPI(ExceptionStatus) cuda_cvtColor(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dcn, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::cvtColor(*src, *dst, code, dcn, streamRef);
    END_WRAP
}

// ---------- cuda_demosaicing --------------------------------------------------
CVAPI(ExceptionStatus) cuda_demosaicing(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dcn, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::demosaicing(*src, *dst, code, dcn, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_equalizeHist(cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::equalizeHist(*src, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_evenLevels(cv::_OutputArray *levels, int nLevels, int lowerLevel, int upperLevel, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::evenLevels(*levels, nLevels, lowerLevel, upperLevel, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_gammaCorrection(cv::_InputArray *src, cv::_OutputArray *dst, int forward, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::gammaCorrection(*src, *dst, forward != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_histEven(cv::_InputArray *src, cv::_OutputArray *hist, int histSize, int lowerLevel, int upperLevel, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::histEven(*src, *hist, histSize, lowerLevel, upperLevel, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_histEven_multi(cv::_InputArray *src, cv::cuda::GpuMat **hist, int *histSize, int *lowerLevel, int *upperLevel, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::GpuMat histArr[4];
    for (int i = 0; i < 4; i++)
    {
        if (hist[i])
            histArr[i] = *hist[i];
    }

    cv::cuda::histEven(*src, histArr, histSize, lowerLevel, upperLevel, streamRef);

    for (int i = 0; i < 4; i++)
    {
        if (hist[i])
            *hist[i] = histArr[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_histRange(cv::_InputArray *src, cv::_OutputArray *hist, cv::_InputArray *levels, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::histRange(*src, *hist, *levels, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_histRange_multi(cv::_InputArray *src, cv::cuda::GpuMat **hist, cv::cuda::GpuMat **levels, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();

    cv::cuda::GpuMat histArr[4];
    cv::cuda::GpuMat levelsArr[4];
    for (int i = 0; i < 4; i++)
    {
        if (hist[i])
            histArr[i] = *hist[i];
        if (levels[i])
            levelsArr[i] = *levels[i];
    }

    cv::cuda::histRange(*src, histArr, levelsArr, streamRef);

    for (int i = 0; i < 4; i++)
    {
        if (hist[i])
            *hist[i] = histArr[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_meanShiftFiltering(cv::_InputArray *src, cv::_OutputArray *dst, int sp, int sr, CvTermCriteria criteria, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::meanShiftFiltering(*src, *dst, sp, sr, criteria, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_meanShiftProc(cv::_InputArray *src, cv::_OutputArray *dstr, cv::_OutputArray *dstsp, int sp, int sr, CvTermCriteria criteria, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::meanShiftProc(*src, *dstr, *dstsp, sp, sr, criteria, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_meanShiftSegmentation(cv::_InputArray *src, cv::_OutputArray *dst, int sp, int sr, int minsize, CvTermCriteria criteria, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::meanShiftSegmentation(*src, *dst, sp, sr, minsize, criteria, streamRef);
    END_WRAP
}



CVAPI(ExceptionStatus) cuda_swapChannels(cv::_InputOutputArray *image, const int *dstOrder, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::swapChannels(*image, dstOrder, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_connectedComponents(
    cv::_InputArray *image,
    cv::_OutputArray *labels,
    int connectivity,
    int ltype,
    int ccltype)
{
    BEGIN_WRAP
    if (ccltype == -1)
    {
        cv::cuda::connectedComponents(*image, *labels, connectivity, ltype);
    }
    else
    {
        cv::cuda::connectedComponents(*image, *labels, connectivity, ltype, static_cast<cv::cuda::ConnectedComponentsAlgorithmsTypes>(ccltype));
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_convertSpatialMoments(cv::Mat *spatialMoments, int order, int momentsType, double *outPointer)
{
    BEGIN_WRAP
    cv::Moments res = cv::cuda::convertSpatialMoments( *spatialMoments, static_cast<cv::cuda::MomentsOrder>(order), momentsType);

    double *data = reinterpret_cast<double *>(&res);
    for (int i = 0; i < 24; i++)
    {
        outPointer[i] = data[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_moments(cv::_InputArray *src,  int binaryImage, int order, int momentsType, double *outPointer)
{
    BEGIN_WRAP
    cv::Moments res = cv::cuda::moments(*src, binaryImage != 0, static_cast<cv::cuda::MomentsOrder>(order), momentsType);

    double *data = reinterpret_cast<double *>(&res);
    for (int i = 0; i < 24; i++)
    {
        outPointer[i] = data[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_numMoments(int order, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::numMoments(static_cast<cv::cuda::MomentsOrder>(order));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_spatialMoments(cv::_InputArray *src, cv::_OutputArray *moments, int binaryImage, int order, int momentsType,  cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::spatialMoments(*src, *moments, binaryImage != 0, static_cast<cv::cuda::MomentsOrder>(order), momentsType, streamRef);
    END_WRAP
}
