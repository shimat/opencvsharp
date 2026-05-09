#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_TargetArchs_builtWith(int feature_set, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::builtWith(static_cast<cv::cuda::FeatureSet>(feature_set)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_TargetArchs_has(int major, int minor, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::has(major, minor) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_TargetArchs_hasBin(int major, int minor, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::hasBin(major, minor) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_TargetArchs_hasPtx(int major, int minor, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::hasPtx(major, minor) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_TargetArchs_hasEqualOrGreater(int major, int minor, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::hasEqualOrGreater(major, minor) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_TargetArchs_hasEqualOrGreaterBin(int major, int minor, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::hasEqualOrGreaterBin(major, minor) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_TargetArchs_hasEqualOrGreaterPtx(int major, int minor, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::hasEqualOrGreaterPtx(major, minor) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_TargetArchs_hasEqualOrLessPtx(int major, int minor, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::TargetArchs::hasEqualOrLessPtx(major, minor) ? 1 : 0;
    END_WRAP
}
