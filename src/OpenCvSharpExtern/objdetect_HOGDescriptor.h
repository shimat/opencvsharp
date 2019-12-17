#ifndef _CPP_OBJDETECT_HOGDESCRIPTOR_H_
#define _CPP_OBJDETECT_HOGDESCRIPTOR_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_new1(cv::HOGDescriptor **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::HOGDescriptor;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_new2(
    MyCvSize winSize, MyCvSize blockSize, MyCvSize blockStride, MyCvSize cellSize,
    int nbins, int derivAperture, double winSigma, int histogramNormType, double L2HysThreshold, int gammaCorrection, int nlevels,
    cv::HOGDescriptor **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::HOGDescriptor(cpp(winSize), cpp(blockSize), cpp(blockStride), cpp(cellSize), nbins, derivAperture, 
                                 winSigma, static_cast<cv::HOGDescriptor::HistogramNormType>(histogramNormType), L2HysThreshold, gammaCorrection != 0, nlevels);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_new3(const char *filename, cv::HOGDescriptor **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::HOGDescriptor(filename);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_delete(cv::HOGDescriptor *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_getDescriptorSize(cv::HOGDescriptor *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDescriptorSize();
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_checkDetectorSize(cv::HOGDescriptor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->checkDetectorSize() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_getWinSigma(cv::HOGDescriptor *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getWinSigma();
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_setSVMDetector(cv::HOGDescriptor *obj, std::vector<float> *svmDetector)
{
    BEGIN_WRAP
    obj->setSVMDetector(*svmDetector);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_load(cv::HOGDescriptor *obj, const char *filename, const char *objName, int *returnValue)
{
    BEGIN_WRAP
    std::string objNameStr;
    if (objName != nullptr)
        objNameStr = std::string(objName);
    *returnValue = obj->load(filename, objNameStr);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_save(cv::HOGDescriptor *obj, const char *filename, const char *objName)
{
    BEGIN_WRAP
    std::string objNameStr;
    if (objName != nullptr)
        objNameStr = cv::String(objName);
    obj->save(filename, objNameStr);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_copyTo(cv::HOGDescriptor *obj, cv::HOGDescriptor *c)
{
    BEGIN_WRAP
    obj->copyTo(*c);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_compute(
    cv::HOGDescriptor *obj, cv::Mat *img, std::vector<float> *descriptors,
    MyCvSize winStride, MyCvSize padding, cv::Point* locations, int locationsLength)
{
    BEGIN_WRAP
    std::vector<cv::Point> locationsVec;
    if (locations != nullptr)    
        locationsVec = std::vector<cv::Point>(locations, locations + locationsLength);    
    obj->compute(*img, *descriptors, cpp(winStride), cpp(padding), locationsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detect1(
    cv::HOGDescriptor *obj, cv::Mat *img, std::vector<cv::Point> *foundLocations,
    double hitThreshold, MyCvSize winStride, MyCvSize padding, cv::Point* searchLocations, int searchLocationsLength)
{
    BEGIN_WRAP
    std::vector<cv::Point> slVec;
    if (searchLocations != nullptr)    
        slVec = std::vector<cv::Point>(searchLocations, searchLocations + searchLocationsLength);    
    obj->detect(*img, *foundLocations, hitThreshold, cpp(winStride), cpp(padding), slVec);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detect2(
    cv::HOGDescriptor *obj, cv::Mat *img, 
    std::vector<cv::Point> *foundLocations, std::vector<double> *weights,
    double hitThreshold, MyCvSize winStride, MyCvSize padding, cv::Point* searchLocations, int searchLocationsLength)
{
    BEGIN_WRAP
    std::vector<cv::Point> slVec;
    if (searchLocations != nullptr)    
        slVec = std::vector<cv::Point>(searchLocations, searchLocations + searchLocationsLength);    
    obj->detect(*img, *foundLocations, *weights, hitThreshold, cpp(winStride), cpp(padding), slVec);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectMultiScale1(
    cv::HOGDescriptor *obj, cv::Mat *img, 
    std::vector<cv::Rect> *foundLocations,
    double hitThreshold, MyCvSize winStride, MyCvSize padding, double scale, int groupThreshold)
{
    BEGIN_WRAP
    obj->detectMultiScale(*img, *foundLocations, 
                          hitThreshold, cpp(winStride), cpp(padding), scale, groupThreshold);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectMultiScale2(
    cv::HOGDescriptor *obj, cv::Mat *img, 
    std::vector<cv::Rect> *foundLocations, std::vector<double> *foundWeights,
    double hitThreshold, MyCvSize winStride, MyCvSize padding, double scale, int groupThreshold)
{
    BEGIN_WRAP
    obj->detectMultiScale(*img, *foundLocations, *foundWeights, 
                          hitThreshold, cpp(winStride), cpp(padding), scale, groupThreshold);    
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_computeGradient(
    cv::HOGDescriptor *obj, cv::Mat* img, 
    cv::Mat* grad, cv::Mat* angleOfs, MyCvSize paddingTL, MyCvSize paddingBR)
{
    BEGIN_WRAP
    obj->computeGradient(*img, *grad, *angleOfs, cpp(paddingTL), cpp(paddingBR));    
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectROI(
    cv::HOGDescriptor *obj, cv::Mat *img, cv::Point *locations, int locationsLength,
    std::vector<cv::Point> *foundLocations, std::vector<double> *confidences,
    double hitThreshold, MyCvSize winStride, MyCvSize padding)
{
    BEGIN_WRAP
    std::vector<cv::Point> locationsVec(locations, locations + locationsLength);
    obj->detectROI(*img, locationsVec, *foundLocations, *confidences, hitThreshold, cpp(winStride), cpp(padding));
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_detectMultiScaleROI(
    cv::HOGDescriptor *obj, cv::Mat *img, std::vector<cv::Rect> *foundLocations,
    std::vector<double> *roiScales, std::vector<std::vector<cv::Point> > *roiLocations, std::vector<std::vector<double> > *roiConfidences,
    double hitThreshold, int groupThreshold)
{
    BEGIN_WRAP
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
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_groupRectangles(cv::HOGDescriptor *obj,
                                                    std::vector<cv::Rect> *rectList, std::vector<double> *weights, int groupThreshold, double eps)
{
    BEGIN_WRAP
    obj->groupRectangles(*rectList, *weights, groupThreshold, eps);
    END_WRAP
}


CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSize_get(cv::HOGDescriptor *obj, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->winSize);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockSize_get(cv::HOGDescriptor *obj, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->blockSize);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockStride_get(cv::HOGDescriptor *obj, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->blockStride);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_cellSize_get(cv::HOGDescriptor *obj, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->cellSize);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nbins_get(cv::HOGDescriptor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->nbins;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_derivAperture_get(cv::HOGDescriptor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->derivAperture;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSigma_get(cv::HOGDescriptor *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->winSigma;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_histogramNormType_get(cv::HOGDescriptor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->histogramNormType;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_L2HysThreshold_get(cv::HOGDescriptor *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->L2HysThreshold;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_gammaCorrection_get(cv::HOGDescriptor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->gammaCorrection ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nlevels_get(cv::HOGDescriptor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->nlevels;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_signedGradient_get(cv::HOGDescriptor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->signedGradient;
    END_WRAP
}


CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSize_set(cv::HOGDescriptor *obj, MyCvSize value)
{
    BEGIN_WRAP
    obj->winSize = cpp(value);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockSize_set(cv::HOGDescriptor *obj, MyCvSize value)
{
    BEGIN_WRAP
    obj->blockSize = cpp(value);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_blockStride_set(cv::HOGDescriptor *obj, MyCvSize value)
{
    BEGIN_WRAP
    obj->blockStride = cpp(value);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_cellSize_set(cv::HOGDescriptor *obj, MyCvSize value)
{
    BEGIN_WRAP
    obj->cellSize = cpp(value);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nbins_set(cv::HOGDescriptor *obj, int value)
{
    BEGIN_WRAP
    obj->nbins = value;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_derivAperture_set(cv::HOGDescriptor *obj, int value)
{
    BEGIN_WRAP
    obj->derivAperture = value;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_winSigma_set(cv::HOGDescriptor *obj, double value)
{
    BEGIN_WRAP
    obj->winSigma = value;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_histogramNormType_set(cv::HOGDescriptor *obj, int value)
{
    BEGIN_WRAP
    obj->histogramNormType = static_cast<cv::HOGDescriptor::HistogramNormType>(value);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_L2HysThreshold_set(cv::HOGDescriptor *obj, double value)
{
    BEGIN_WRAP
    obj->L2HysThreshold = value;
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_gammaCorrection_set(cv::HOGDescriptor *obj, int value)
{
    BEGIN_WRAP
    obj->gammaCorrection = (value != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) objdetect_HOGDescriptor_nlevels_set(cv::HOGDescriptor *obj, int value)
{
    BEGIN_WRAP
    obj->nlevels = value;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_HOGDescriptor_signedGradient_set(cv::HOGDescriptor *obj, int value)
{
    BEGIN_WRAP
    obj->signedGradient = (value != 0);
    END_WRAP
}

#endif