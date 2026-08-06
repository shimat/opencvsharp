#pragma once

#include "include_opencv.h"
#include <opencv2/core/ocl.hpp>

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) core_ocl_finish()
{
    return cvTry([] {
        cv::ocl::finish();
    });
}
