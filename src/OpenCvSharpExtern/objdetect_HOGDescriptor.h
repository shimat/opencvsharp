#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

// NOTE: OpenCV 5 moved HOGDescriptor into the contrib xobjdetect module (see
// include_opencv.h); it stays in the cv:: namespace and is kept in all profiles.
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_new1(cv::HOGDescriptor **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::HOGDescriptor;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_new2(
    interop::Size winSize, interop::Size blockSize, interop::Size blockStride, interop::Size cellSize,
    int nbins, int derivAperture, double winSigma, int histogramNormType, double L2HysThreshold, int gammaCorrection, int nlevels,
    cv::HOGDescriptor **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::HOGDescriptor(cpp(winSize), cpp(blockSize), cpp(blockStride), cpp(cellSize), nbins, derivAperture, 
                                     winSigma, static_cast<cv::HOGDescriptor::HistogramNormType>(histogramNormType), L2HysThreshold, gammaCorrection != 0, nlevels);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_new3(const char *filename, cv::HOGDescriptor **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::HOGDescriptor(filename);
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_delete(cv::HOGDescriptor *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_getDescriptorSize(cv::HOGDescriptor *obj, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDescriptorSize();
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_checkDetectorSize(cv::HOGDescriptor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->checkDetectorSize() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_getWinSigma(cv::HOGDescriptor *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getWinSigma();
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_setSVMDetector(cv::HOGDescriptor *obj, std::vector<float> *svmDetector)
{
    return cvTry([&] {
        obj->setSVMDetector(*svmDetector);
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_load(cv::HOGDescriptor *obj, const char *filename, const char *objName, int *returnValue)
{
    return cvTry([&] {
        std::string objNameStr;
        if (objName != nullptr)
            objNameStr = std::string(objName);
        *returnValue = obj->load(filename, objNameStr);
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_save(cv::HOGDescriptor *obj, const char *filename, const char *objName)
{
    return cvTry([&] {
        std::string objNameStr;
        if (objName != nullptr)
            objNameStr = cv::String(objName);
        obj->save(filename, objNameStr);
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_copyTo(cv::HOGDescriptor *obj, cv::HOGDescriptor *c)
{
    return cvTry([&] {
        obj->copyTo(*c);
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_compute(
    cv::HOGDescriptor *obj, cv::Mat *img, std::vector<float> *descriptors,
    interop::Size winStride, interop::Size padding, cv::Point* locations, int locationsLength)
{
    return cvTry([&] {
        std::vector<cv::Point> locationsVec;
        if (locations != nullptr)    
            locationsVec = std::vector<cv::Point>(locations, locations + locationsLength);    
        obj->compute(*img, *descriptors, cpp(winStride), cpp(padding), locationsVec);
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detect1(
    cv::HOGDescriptor *obj, cv::Mat *img, std::vector<cv::Point> *foundLocations,
    double hitThreshold, interop::Size winStride, interop::Size padding, cv::Point* searchLocations, int searchLocationsLength)
{
    return cvTry([&] {
        std::vector<cv::Point> slVec;
        if (searchLocations != nullptr)    
            slVec = std::vector<cv::Point>(searchLocations, searchLocations + searchLocationsLength);    
        obj->detect(*img, *foundLocations, hitThreshold, cpp(winStride), cpp(padding), slVec);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detect2(
    cv::HOGDescriptor *obj, cv::Mat *img, 
    std::vector<cv::Point> *foundLocations, std::vector<double> *weights,
    double hitThreshold, interop::Size winStride, interop::Size padding, cv::Point* searchLocations, int searchLocationsLength)
{
    return cvTry([&] {
        std::vector<cv::Point> slVec;
        if (searchLocations != nullptr)    
            slVec = std::vector<cv::Point>(searchLocations, searchLocations + searchLocationsLength);    
        obj->detect(*img, *foundLocations, *weights, hitThreshold, cpp(winStride), cpp(padding), slVec);
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectMultiScale1(
    cv::HOGDescriptor *obj, cv::Mat *img, 
    std::vector<cv::Rect> *foundLocations,
    double hitThreshold, interop::Size winStride, interop::Size padding, double scale, int groupThreshold)
{
    return cvTry([&] {
        obj->detectMultiScale(*img, *foundLocations, 
                              hitThreshold, cpp(winStride), cpp(padding), scale, groupThreshold);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectMultiScale2(
    cv::HOGDescriptor *obj, cv::Mat *img, 
    std::vector<cv::Rect> *foundLocations, std::vector<double> *foundWeights,
    double hitThreshold, interop::Size winStride, interop::Size padding, double scale, int groupThreshold)
{
    return cvTry([&] {
        obj->detectMultiScale(*img, *foundLocations, *foundWeights, 
                              hitThreshold, cpp(winStride), cpp(padding), scale, groupThreshold);    
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_computeGradient(
    cv::HOGDescriptor *obj, cv::Mat* img, 
    cv::Mat* grad, cv::Mat* angleOfs, interop::Size paddingTL, interop::Size paddingBR)
{
    return cvTry([&] {
        obj->computeGradient(*img, *grad, *angleOfs, cpp(paddingTL), cpp(paddingBR));    
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectROI(
    cv::HOGDescriptor *obj, cv::Mat *img, cv::Point *locations, int locationsLength,
    std::vector<cv::Point> *foundLocations, std::vector<double> *confidences,
    double hitThreshold, interop::Size winStride, interop::Size padding)
{
    return cvTry([&] {
        const std::vector<cv::Point> locationsVec(locations, locations + locationsLength);
        obj->detectROI(*img, locationsVec, *foundLocations, *confidences, hitThreshold, cpp(winStride), cpp(padding));
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectMultiScaleROI(
    cv::HOGDescriptor *obj, cv::Mat *img, std::vector<cv::Rect> *foundLocations,
    std::vector<double> *roiScales, std::vector<std::vector<cv::Point> > *roiLocations, std::vector<std::vector<double> > *roiConfidences,
    double hitThreshold, int groupThreshold)
{
    return cvTry([&] {
        std::vector<cv::DetectionROI> locations;
        obj->detectMultiScaleROI(*img, *foundLocations, locations, hitThreshold, groupThreshold);

        roiScales->resize(locations.size());
        roiLocations->resize(locations.size());
        roiConfidences->resize(locations.size());
        for (size_t i = 0; i < locations.size(); i++)
        {
            (*roiScales)[i] = locations[i].scale;
            (*roiLocations)[i] = locations[i].locations;
            (*roiConfidences)[i] = locations[i].confidences;
        }
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_groupRectangles(cv::HOGDescriptor *obj,
                                                    std::vector<cv::Rect> *rectList, std::vector<double> *weights, int groupThreshold, double eps)
{
    return cvTry([&] {
        obj->groupRectangles(*rectList, *weights, groupThreshold, eps);
    });
}


CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSize_get(cv::HOGDescriptor *obj, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->winSize);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockSize_get(cv::HOGDescriptor *obj, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->blockSize);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockStride_get(cv::HOGDescriptor *obj, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->blockStride);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_cellSize_get(cv::HOGDescriptor *obj, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->cellSize);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nbins_get(cv::HOGDescriptor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->nbins;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_derivAperture_get(cv::HOGDescriptor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->derivAperture;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSigma_get(cv::HOGDescriptor *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->winSigma;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_histogramNormType_get(cv::HOGDescriptor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->histogramNormType;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_L2HysThreshold_get(cv::HOGDescriptor *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->L2HysThreshold;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_gammaCorrection_get(cv::HOGDescriptor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->gammaCorrection ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nlevels_get(cv::HOGDescriptor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->nlevels;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_signedGradient_get(cv::HOGDescriptor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->signedGradient;
    });
}


CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSize_set(cv::HOGDescriptor *obj, interop::Size value)
{
    return cvTry([&] {
        obj->winSize = cpp(value);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockSize_set(cv::HOGDescriptor *obj, interop::Size value)
{
    return cvTry([&] {
        obj->blockSize = cpp(value);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockStride_set(cv::HOGDescriptor *obj, interop::Size value)
{
    return cvTry([&] {
        obj->blockStride = cpp(value);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_cellSize_set(cv::HOGDescriptor *obj, interop::Size value)
{
    return cvTry([&] {
        obj->cellSize = cpp(value);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nbins_set(cv::HOGDescriptor *obj, int value)
{
    return cvTry([&] {
        obj->nbins = value;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_derivAperture_set(cv::HOGDescriptor *obj, int value)
{
    return cvTry([&] {
        obj->derivAperture = value;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSigma_set(cv::HOGDescriptor *obj, double value)
{
    return cvTry([&] {
        obj->winSigma = value;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_histogramNormType_set(cv::HOGDescriptor *obj, int value)
{
    return cvTry([&] {
        obj->histogramNormType = static_cast<cv::HOGDescriptor::HistogramNormType>(value);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_L2HysThreshold_set(cv::HOGDescriptor *obj, double value)
{
    return cvTry([&] {
        obj->L2HysThreshold = value;
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_gammaCorrection_set(cv::HOGDescriptor *obj, int value)
{
    return cvTry([&] {
        obj->gammaCorrection = (value != 0);
    });
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nlevels_set(cv::HOGDescriptor *obj, int value)
{
    return cvTry([&] {
        obj->nlevels = value;
    });
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_signedGradient_set(cv::HOGDescriptor *obj, int value)
{
    return cvTry([&] {
        obj->signedGradient = (value != 0);
    });
}

#endif

#endif // NO_OBJDETECT
