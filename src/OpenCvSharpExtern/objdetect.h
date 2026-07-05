#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

// NOTE: OpenCV 5 relocated CascadeClassifier / groupRectangles into the contrib
// xobjdetect module (see include_opencv.h); they remain in the cv:: namespace and
// are kept available in all profiles (xobjdetect is lightweight).
#pragma region CascadeClassifier

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_new(cv::CascadeClassifier **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::CascadeClassifier;
    });
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_newFromFile(const char *fileName, cv::CascadeClassifier **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::CascadeClassifier(fileName);
    });
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_delete(cv::CascadeClassifier *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_empty(cv::CascadeClassifier *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->empty() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_load(
    cv::CascadeClassifier *obj, const char *fileName, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->load(fileName) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_read(
    cv::CascadeClassifier* obj, cv::FileNode* fn, int* returnValue)
{
    return cvTry([&] {
        * returnValue = obj->read(*fn) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_detectMultiScale1(
    cv::CascadeClassifier *obj,
    cv::Mat *image, std::vector<cv::Rect> *objects,
    double scaleFactor, int minNeighbors, int flags, interop::Size minSize, interop::Size maxSize)
{
    return cvTry([&] {
        obj->detectMultiScale(*image, *objects,
            scaleFactor, minNeighbors, flags, cpp(minSize), cpp(maxSize));
    });
}

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_detectMultiScale2(
    cv::CascadeClassifier *obj,
    cv::Mat *image, 
    std::vector<cv::Rect> *objects,
    std::vector<int> *rejectLevels,
    std::vector<double> *levelWeights,
    double scaleFactor, int minNeighbors, int flags,
    interop::Size minSize, interop::Size maxSize, int outputRejectLevels)
{
    return cvTry([&] {
        obj->detectMultiScale(*image, *objects, *rejectLevels, *levelWeights,
            scaleFactor, minNeighbors, flags, cpp(minSize), cpp(maxSize), outputRejectLevels != 0);
    });
}


CVAPI(ExceptionStatus) objdetect_CascadeClassifier_isOldFormatCascade(cv::CascadeClassifier *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isOldFormatCascade() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_getOriginalWindowSize(cv::CascadeClassifier *obj, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getOriginalWindowSize());
    });
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_getFeatureType(cv::CascadeClassifier *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getFeatureType();
    });
}

#pragma endregion

CVAPI(ExceptionStatus) objdetect_groupRectangles1(
    std::vector<cv::Rect> *rectList, int groupThreshold, double eps)
{
    return cvTry([&] {
        cv::groupRectangles(*rectList, groupThreshold, eps);
    });
}
CVAPI(ExceptionStatus) objdetect_groupRectangles2(
    std::vector<cv::Rect> *rectList, std::vector<int> *weights, int groupThreshold, double eps)
{
    return cvTry([&] {
        cv::groupRectangles(*rectList, *weights, groupThreshold, eps);
    });
}
CVAPI(ExceptionStatus) objdetect_groupRectangles3(
    std::vector<cv::Rect> *rectList, int groupThreshold, double eps, std::vector<int> *weights, std::vector<double> *levelWeights)
{
    return cvTry([&] {
        cv::groupRectangles(*rectList, groupThreshold, eps, weights, levelWeights);
    });
}
CVAPI(ExceptionStatus) objdetect_groupRectangles4(
    std::vector<cv::Rect> *rectList, std::vector<int> *rejectLevels, std::vector<double> *levelWeights, int groupThreshold, double eps)
{
    return cvTry([&] {
        cv::groupRectangles(*rectList, *rejectLevels, *levelWeights, groupThreshold, eps);
    });
}
CVAPI(ExceptionStatus) objdetect_groupRectangles_meanshift(
    std::vector<cv::Rect> *rectList, std::vector<double> *foundWeights, std::vector<double> *foundScales, double detectThreshold, interop::Size winDetSize)
{
    return cvTry([&] {
        cv::groupRectangles_meanshift(*rectList, *foundWeights, *foundScales, detectThreshold, cpp(winDetSize));
    });
}

#endif

#endif // NO_OBJDETECT
