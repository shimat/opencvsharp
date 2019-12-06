#ifndef _CPP_XIMGPROC_SEGMENTATION_H_
#define _CPP_XIMGPROC_SEGMENTATION_H_

#include "include_opencv.h"

// GraphSegmentation

CVAPI(cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation>*) ximgproc_segmentation_createGraphSegmentation(double sigma, float k, int min_size)
{
    return clone(cv::ximgproc::segmentation::createGraphSegmentation(sigma, k, min_size));
}

CVAPI(void) ximgproc_segmentation_Ptr_GraphSegmentation_delete(cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *obj)
{
    delete obj;
}

CVAPI(cv::ximgproc::segmentation::GraphSegmentation*) ximgproc_segmentation_Ptr_GraphSegmentation_get(cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *ptr)
{
    return ptr->get();
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_processImage(cv::ximgproc::segmentation::GraphSegmentation *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    obj->processImage(*src, *dst);
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_setSigma(cv::ximgproc::segmentation::GraphSegmentation *obj, double value)
{
    obj->setSigma(value);
}
CVAPI(double) ximgproc_segmentation_GraphSegmentation_getSigma(cv::ximgproc::segmentation::GraphSegmentation *obj)
{
    return obj->getSigma();
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_setK(cv::ximgproc::segmentation::GraphSegmentation *obj, float value)
{
    obj->setK(value);
}
CVAPI(float) ximgproc_segmentation_GraphSegmentation_getK(cv::ximgproc::segmentation::GraphSegmentation *obj)
{
    return obj->getK();
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_setMinSize(cv::ximgproc::segmentation::GraphSegmentation *obj, int value)
{
    obj->setMinSize(value);
}
CVAPI(int) ximgproc_segmentation_GraphSegmentation_getMinSize(cv::ximgproc::segmentation::GraphSegmentation *obj)
{
    return obj->getMinSize();
}


// SelectiveSearchSegmentationStrategy

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj, cv::_InputArray *img, cv::_InputArray *regions, cv::_InputArray *sizes, int image_id)
{
    obj->setImage(*img, *regions, *sizes, image_id);
}

CVAPI(float) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj, int r1, int r2)
{
    return obj->get(r1, r2);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy *obj, int r1, int r2)
{
    obj->merge(r1, r2);
}

CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor()
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyColor());
}
CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize()
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategySize());
}
CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture()
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyTexture());
}
CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill()
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyFill());
}

CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> *obj)
{
    delete obj;
}
CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> *obj)
{
    delete obj;
}
CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> *obj)
{
    delete obj;
}
CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> *obj)
{
    delete obj;
}

CVAPI(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyColor> *ptr)
{
    return ptr->get();
}
CVAPI(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategySize> *ptr)
{
    return ptr->get();
}
CVAPI(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyTexture> *ptr)
{
    return ptr->get();
}
CVAPI(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyFill> *ptr)
{
    return ptr->get();
}


// SelectiveSearchSegmentationStrategyMultiple

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple *obj, cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *g, float weight)
{
    obj->addStrategy(*g, weight);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple *obj)
{
    obj->clearStrategies();
}

CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0()
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple());
}
CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1)
{
    return clone(createSelectiveSearchSegmentationStrategyMultiple(*s1));
}
CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2)
{
    return clone(createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2));
}
CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s3)
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3));
}
CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s1,
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s2, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s3, 
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s4)
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3, *s4));
}

CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> *obj)
{
    delete obj;
}

CVAPI(cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategyMultiple> *ptr)
{
    return ptr->get();
}

// SelectiveSearchSegmentation

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::_InputArray *img)
{
    obj->setBaseImage(*img);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, int k, float sigma)
{
    obj->switchToSingleStrategy(k, sigma);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, int base_k, int inc_k, float sigma)
{
    obj->switchToSelectiveSearchFast(base_k, inc_k, sigma);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, int base_k, int inc_k, float sigma) 
{
    obj->switchToSelectiveSearchQuality(base_k, inc_k, sigma);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_addImage(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::_InputArray *img)
{
    obj->addImage(*img);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_clearImages(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj)
{
    obj->clearImages();
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::Ptr<cv::ximgproc::segmentation::GraphSegmentation> *g)
{
    obj->addGraphSegmentation(*g);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations(cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj) 
{
    obj->clearGraphSegmentations();
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentationStrategy> *s)
{
    obj->addStrategy(*s);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj) 
{
    obj->clearStrategies();
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_process(
    cv::ximgproc::segmentation::SelectiveSearchSegmentation *obj, std::vector<cv::Rect> *rects) 
{
    obj->process(*rects);
}

CVAPI(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation>*) ximgproc_segmentation_createSelectiveSearchSegmentation()
{
    return clone(cv::ximgproc::segmentation::createSelectiveSearchSegmentation());
}

CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete(cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> *obj)
{
    delete obj;
}

CVAPI(cv::ximgproc::segmentation::SelectiveSearchSegmentation*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get(
    cv::Ptr<cv::ximgproc::segmentation::SelectiveSearchSegmentation> *ptr)
{
    return ptr->get();
}

#endif