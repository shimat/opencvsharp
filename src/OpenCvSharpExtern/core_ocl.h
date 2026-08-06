#pragma once

#include "include_opencv.h"
#include <opencv2/core/ocl.hpp>

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) core_ocl_haveOpenCL(int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::ocl::haveOpenCL() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_ocl_useOpenCL(int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::ocl::useOpenCL() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_ocl_setUseOpenCL(int flag)
{
    return cvTry([&] {
        cv::ocl::setUseOpenCL(flag != 0);
    });
}

CVAPI(ExceptionStatus) core_ocl_finish()
{
    return cvTry([] {
        cv::ocl::finish();
    });
}
