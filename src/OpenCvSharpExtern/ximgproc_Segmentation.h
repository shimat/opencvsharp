#ifndef _CPP_XIMGPROC_SEGMENTATION_H_
#define _CPP_XIMGPROC_SEGMENTATION_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// GraphSegmentation

CVAPI(ExceptionStatus) ximgproc_segmentation_createGraphSegmentation(
    double sigma, float k, int min_size, cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createGraphSegmentation(sigma, k, min_size));
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_GraphSegmentation_delete(cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_GraphSegmentation_get(
    cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *ptr, 
    cv::ximgproc::segmentation::GraphSegmentation **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_processImage(cv::ximgproc::segmentation::GraphSegmentation *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->processImage(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_setSigma(cv::ximgproc::segmentation::GraphSegmentation *obj, double value)
{
    BEGIN_WRAP
    obj->setSigma(value);
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_getSigma(cv::ximgproc::segmentation::GraphSegmentation *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSigma();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_setK(cv::ximgproc::segmentation::GraphSegmentation *obj, float value)
{
    BEGIN_WRAP
    obj->setK(value);
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_getK(cv::ximgproc::segmentation::GraphSegmentation *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getK();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_setMinSize(cv::ximgproc::segmentation::GraphSegmentation *obj, int value)
{
    BEGIN_WRAP
    obj->setMinSize(value);
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_GraphSegmentation_getMinSize(cv::ximgproc::segmentation::GraphSegmentation *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinSize();
    END_WRAP
}


// SelectiveSearchSegmentationStrategy

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj, cv::_InputArray *img, cv::_InputArray *regions, cv::_InputArray *sizes, int image_id)
{
    BEGIN_WRAP
    obj->setImage(*img, *regions, *sizes, image_id);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj, int r1, int r2, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get(r1, r2);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj, int r1, int r2)
{
    BEGIN_WRAP
    obj->merge(r1, r2);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyColor());
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategySize());
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyTexture());
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyFill());
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> *ptr, 
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> *ptr, 
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> *ptr, 
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> *ptr, 
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// SelectiveSearchSegmentationStrategyMultiple

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple *obj, cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *g, float weight)
{
    BEGIN_WRAP
    obj->addStrategy(*g, weight);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple *obj)
{
    BEGIN_WRAP
    obj->clearStrategies();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple());
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(createSelectiveSearchSegmentationStrategyMultiple(*s1));
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2));
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s3, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3));
    END_WRAP
}
CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s3, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s4, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3, *s4));
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> *ptr, 
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// SelectiveSearchSegmentation

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::_InputArray *img)
{
    BEGIN_WRAP
    obj->setBaseImage(*img);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, int k, float sigma)
{
    BEGIN_WRAP
    obj->switchToSingleStrategy(k, sigma);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, int base_k, int inc_k, float sigma)
{
    BEGIN_WRAP
    obj->switchToSelectiveSearchFast(base_k, inc_k, sigma);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, int base_k, int inc_k, float sigma) 
{
    BEGIN_WRAP
    obj->switchToSelectiveSearchQuality(base_k, inc_k, sigma);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_addImage(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::_InputArray *img)
{
    BEGIN_WRAP
    obj->addImage(*img);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_clearImages(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj)
{
    BEGIN_WRAP
    obj->clearImages();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *g)
{
    BEGIN_WRAP
    obj->addGraphSegmentation(*g);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj) 
{
    BEGIN_WRAP
    obj->clearGraphSegmentations();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s)
{
    BEGIN_WRAP
    obj->addStrategy(*s);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj) 
{
    BEGIN_WRAP
    obj->clearStrategies();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_SelectiveSearchSegmentation_process(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, std::vector<cv::Rect> *rects) 
{
    BEGIN_WRAP
    obj->process(*rects);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_createSelectiveSearchSegmentation(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentation());
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> *ptr, cv::ximgproc::segmentation::SelectiveSearchSegmentation **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#endif