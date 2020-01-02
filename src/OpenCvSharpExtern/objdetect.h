#ifndef _CPP_OBJDETECT_H_
#define _CPP_OBJDETECT_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region CascadeClassifier

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_new(cv::CascadeClassifier **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::CascadeClassifier;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_newFromFile(const char *fileName, cv::CascadeClassifier **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::CascadeClassifier(fileName);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_delete(cv::CascadeClassifier *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_empty(cv::CascadeClassifier *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_load(
    cv::CascadeClassifier *obj, const char *fileName, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->load(fileName) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_detectMultiScale1(
    cv::CascadeClassifier *obj,
    cv::Mat *image, std::vector<cv::Rect> *objects,
    double scaleFactor, int minNeighbors, int flags, MyCvSize minSize, MyCvSize maxSize)
{
    BEGIN_WRAP
    obj->detectMultiScale(*image, *objects,
        scaleFactor, minNeighbors, flags, cpp(minSize), cpp(maxSize));
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_CascadeClassifier_detectMultiScale2(
    cv::CascadeClassifier *obj,
    cv::Mat *image, 
    std::vector<cv::Rect> *objects,
    std::vector<int> *rejectLevels,
    std::vector<double> *levelWeights,
    double scaleFactor, int minNeighbors, int flags,
    MyCvSize minSize, MyCvSize maxSize, int outputRejectLevels)
{
    BEGIN_WRAP
    obj->detectMultiScale(*image, *objects, *rejectLevels, *levelWeights,
        scaleFactor, minNeighbors, flags, cpp(minSize), cpp(maxSize), outputRejectLevels != 0);
    END_WRAP
}


CVAPI(ExceptionStatus) objdetect_CascadeClassifier_isOldFormatCascade(cv::CascadeClassifier *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isOldFormatCascade() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_getOriginalWindowSize(cv::CascadeClassifier *obj, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getOriginalWindowSize());
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_CascadeClassifier_getFeatureType(cv::CascadeClassifier *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getFeatureType();
    END_WRAP
}

#pragma endregion

CVAPI(ExceptionStatus) objdetect_groupRectangles1(
    std::vector<cv::Rect> *rectList, int groupThreshold, double eps)
{
    BEGIN_WRAP
    cv::groupRectangles(*rectList, groupThreshold, eps);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_groupRectangles2(
    std::vector<cv::Rect> *rectList, std::vector<int> *weights, int groupThreshold, double eps)
{
    BEGIN_WRAP
    cv::groupRectangles(*rectList, *weights, groupThreshold, eps);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_groupRectangles3(
    std::vector<cv::Rect> *rectList, int groupThreshold, double eps, std::vector<int> *weights, std::vector<double> *levelWeights)
{
    BEGIN_WRAP
    cv::groupRectangles(*rectList, groupThreshold, eps, weights, levelWeights);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_groupRectangles4(
    std::vector<cv::Rect> *rectList, std::vector<int> *rejectLevels, std::vector<double> *levelWeights, int groupThreshold, double eps)
{
    BEGIN_WRAP
    cv::groupRectangles(*rectList, *rejectLevels, *levelWeights, groupThreshold, eps);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_groupRectangles_meanshift(
    std::vector<cv::Rect> *rectList, std::vector<double> *foundWeights, std::vector<double> *foundScales, double detectThreshold, MyCvSize winDetSize)
{
    BEGIN_WRAP
    cv::groupRectangles_meanshift(*rectList, *foundWeights, *foundScales, detectThreshold, cpp(winDetSize));
    END_WRAP
}

#endif