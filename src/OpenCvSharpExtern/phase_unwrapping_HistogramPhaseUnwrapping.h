#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

struct CvHistogramPhaseUnwrappingParams
{
    int width;
    int height;
    float histThresh;
    int nbrOfSmallBins;
    int nbrOfLargeBins;
};

CVAPI(ExceptionStatus) phase_unwrapping_Ptr_HistogramPhaseUnwrapping_delete(
    cv::Ptr<cv::phase_unwrapping::HistogramPhaseUnwrapping>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) phase_unwrapping_Ptr_HistogramPhaseUnwrapping_get(
    cv::Ptr<cv::phase_unwrapping::HistogramPhaseUnwrapping>* ptr,
    cv::phase_unwrapping::HistogramPhaseUnwrapping** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) phase_unwrapping_HistogramPhaseUnwrapping_create(
    CvHistogramPhaseUnwrappingParams* parameters,
    cv::Ptr<cv::phase_unwrapping::HistogramPhaseUnwrapping>** returnValue)
{
    return cvTry([&] {
        cv::phase_unwrapping::HistogramPhaseUnwrapping::Params p;
        p.width = parameters->width;
        p.height = parameters->height;
        p.histThresh = parameters->histThresh;
        p.nbrOfSmallBins = parameters->nbrOfSmallBins;
        p.nbrOfLargeBins = parameters->nbrOfLargeBins;
        const auto ptr = cv::phase_unwrapping::HistogramPhaseUnwrapping::create(p);
        *returnValue = new cv::Ptr<cv::phase_unwrapping::HistogramPhaseUnwrapping>(ptr);
    });
}

CVAPI(ExceptionStatus) phase_unwrapping_HistogramPhaseUnwrapping_getInverseReliabilityMap(
    cv::phase_unwrapping::HistogramPhaseUnwrapping* obj,
    const interop::OutputArrayProxy* reliabilityMap)
{
    return cvTry([&] {
        obj->getInverseReliabilityMap(OutProxy(*reliabilityMap));
    });
}

#endif // NO_CONTRIB
