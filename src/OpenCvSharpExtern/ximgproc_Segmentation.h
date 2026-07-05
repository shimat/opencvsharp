#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// GraphSegmentation

CVAPI(ExceptionStatus) ximgproc_segmentation_createGraphSegmentation(
    double sigma,
    float k,
    int min_size,
    cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createGraphSegmentation(sigma, k, min_size));
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_GraphSegmentation_delete(cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_GraphSegmentation_get(cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *ptr, cv::ximgproc::segmentation::GraphSegmentation **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_processImage(
    cv::ximgproc::segmentation::GraphSegmentation *obj,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        obj->processImage(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_setSigma(cv::ximgproc::segmentation::GraphSegmentation *obj, double value)
{
    return cvTry([&] {
        obj->setSigma(value);
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_getSigma(cv::ximgproc::segmentation::GraphSegmentation *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSigma();
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_setK(cv::ximgproc::segmentation::GraphSegmentation *obj, float value)
{
    return cvTry([&] {
        obj->setK(value);
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_getK(cv::ximgproc::segmentation::GraphSegmentation *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getK();
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_setMinSize(cv::ximgproc::segmentation::GraphSegmentation *obj, int value)
{
    return cvTry([&] {
        obj->setMinSize(value);
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_getMinSize(cv::ximgproc::segmentation::GraphSegmentation *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMinSize();
    });
}


// SelectiveSearchSegmentationStrategy

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj,
    const interop::InputArrayProxy* img,
    const interop::InputArrayProxy* regions,
    const interop::InputArrayProxy* sizes,
    int image_id)
{
    return cvTry([&] {
        obj->setImage(InProxy(*img), InProxy(*regions), InProxy(*sizes), image_id);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj,
    int r1,
    int r2,
    float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get(r1, r2);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj,
    int r1,
    int r2)
{
    return cvTry([&] {
        obj->merge(r1, r2);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyColor());
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategySize());
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyTexture());
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyFill());
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> *ptr, cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> *ptr, cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> *ptr, cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> *ptr, cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}


// SelectiveSearchSegmentationStrategyMultiple

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple *obj,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *g,
    float weight)
{
    return cvTry([&] {
        obj->addStrategy(*g, weight);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple *obj)
{
    return cvTry([&] {
        obj->clearStrategies();
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple());
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1, cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(createSelectiveSearchSegmentationStrategyMultiple(*s1));
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2));
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s3,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3));
    });
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s3,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s4,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3, *s4));
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> *ptr, cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

// SelectiveSearchSegmentation

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, const interop::InputArrayProxy* img)
{
    return cvTry([&] {
        obj->setBaseImage(InProxy(*img));
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj,
    int k,
    float sigma)
{
    return cvTry([&] {
        obj->switchToSingleStrategy(k, sigma);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj,
    int base_k,
    int inc_k,
    float sigma)
{
    return cvTry([&] {
        obj->switchToSelectiveSearchFast(base_k, inc_k, sigma);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj,
    int base_k,
    int inc_k,
    float sigma) 
{
    return cvTry([&] {
        obj->switchToSelectiveSearchQuality(base_k, inc_k, sigma);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_addImage(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, const interop::InputArrayProxy* img)
{
    return cvTry([&] {
        obj->addImage(InProxy(*img));
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_clearImages(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj)
{
    return cvTry([&] {
        obj->clearImages();
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *g)
{
    return cvTry([&] {
        obj->addGraphSegmentation(*g);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj) 
{
    return cvTry([&] {
        obj->clearGraphSegmentations();
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s)
{
    return cvTry([&] {
        obj->addStrategy(*s);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj) 
{
    return cvTry([&] {
        obj->clearStrategies();
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_process(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, std::vector<cv::Rect> *rects) 
{
    return cvTry([&] {
        obj->process(*rects);
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentation(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentation());
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> *ptr, cv::ximgproc::segmentation::SelectiveSearchSegmentation **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#endif // NO_CONTRIB
