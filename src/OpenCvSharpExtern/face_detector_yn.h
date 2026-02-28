#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "my_functions.h"
#include <opencv2/core/cvstd.hpp>
#include <opencv2/core/cvstd_wrapper.hpp>
#include <opencv2/core/types_c.h>
#include <opencv2/objdetect/face.hpp>

#ifndef _WINRT_DLL

CVAPI(cv::FaceDetectorYN*) cveFaceDetectorYNCreate(
    cv::String* model,
    cv::String* config,
    CvSize* inputSize,
    float scoreThreshold,
    float nmsThreshold,
    int topK,
    int backendId,
    int targetId,
    cv::Ptr<cv::FaceDetectorYN>** sharedPtr);

CVAPI(void) cveFaceDetectorYNRelease(cv::Ptr<cv::FaceDetectorYN>** faceDetector);

CVAPI(int) cveFaceDetectorYNDetect(cv::FaceDetectorYN* faceDetector, cv::_InputArray* image, cv::_OutputArray* faces);

#endif

#endif // NO_OBJDETECT
