#ifndef _CPP_XIMGPROC_SEGMENTATION_H_
#define _CPP_XIMGPROC_SEGMENTATION_H_

#include "include_opencv.h"

using namespace cv::ximgproc::segmentation;

// GraphSegmentation

CVAPI(cv::Ptr<GraphSegmentation>*) ximgproc_segmentation_createGraphSegmentation(double sigma, float k, int min_size)
{
    return clone(createGraphSegmentation(sigma, k, min_size));
}

CVAPI(void) ximgproc_segmentation_Ptr_GraphSegmentation_delete(cv::Ptr<GraphSegmentation> *obj)
{
    delete obj;
}

CVAPI(GraphSegmentation*) ximgproc_segmentation_Ptr_GraphSegmentation_get(cv::Ptr<GraphSegmentation> *ptr)
{
    return ptr->get();
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_processImage(GraphSegmentation *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    obj->processImage(*src, *dst);
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_setSigma(GraphSegmentation *obj, double value)
{
    obj->setSigma(value);
}
CVAPI(double) ximgproc_segmentation_GraphSegmentation_getSigma(GraphSegmentation *obj)
{
    return obj->getSigma();
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_setK(GraphSegmentation *obj, float value)
{
    obj->setK(value);
}
CVAPI(float) ximgproc_segmentation_GraphSegmentation_getK(GraphSegmentation *obj)
{
    return obj->getK();
}

CVAPI(void) ximgproc_segmentation_GraphSegmentation_setMinSize(GraphSegmentation *obj, int value)
{
    obj->setMinSize(value);
}
CVAPI(int) ximgproc_segmentation_GraphSegmentation_getMinSize(GraphSegmentation *obj)
{
    return obj->getMinSize();
}


// SelectiveSearchSegmentationStrategy

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(SelectiveSearchSegmentationStrategy *obj, cv::_InputArray *img, cv::_InputArray *regions, cv::_InputArray *sizes, int image_id)
{
    obj->setImage(*img, *regions, *sizes, image_id);
}

CVAPI(float) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(SelectiveSearchSegmentationStrategy *obj, int r1, int r2)
{
    return obj->get(r1, r2);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(SelectiveSearchSegmentationStrategy *obj, int r1, int r2)
{
    obj->merge(r1, r2);
}

CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyColor>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor()
{
    return clone(createSelectiveSearchSegmentationStrategyColor());
}
CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategySize>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize()
{
    return clone(createSelectiveSearchSegmentationStrategySize());
}
CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyTexture>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture()
{
    return clone(createSelectiveSearchSegmentationStrategyTexture());
}
CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyFill>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill()
{
    return clone(createSelectiveSearchSegmentationStrategyFill());
}

CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(cv::Ptr<SelectiveSearchSegmentationStrategyColor> *obj)
{
    delete obj;
}
CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(cv::Ptr<SelectiveSearchSegmentationStrategySize> *obj)
{
    delete obj;
}
CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(cv::Ptr<SelectiveSearchSegmentationStrategyTexture> *obj)
{
    delete obj;
}
CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(cv::Ptr<SelectiveSearchSegmentationStrategyFill> *obj)
{
    delete obj;
}

CVAPI(SelectiveSearchSegmentationStrategyColor*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(cv::Ptr<SelectiveSearchSegmentationStrategyColor> *ptr)
{
    return ptr->get();
}
CVAPI(SelectiveSearchSegmentationStrategySize*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(cv::Ptr<SelectiveSearchSegmentationStrategySize> *ptr)
{
    return ptr->get();
}
CVAPI(SelectiveSearchSegmentationStrategyTexture*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(cv::Ptr<SelectiveSearchSegmentationStrategyTexture> *ptr)
{
    return ptr->get();
}
CVAPI(SelectiveSearchSegmentationStrategyFill*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(cv::Ptr<SelectiveSearchSegmentationStrategyFill> *ptr)
{
    return ptr->get();
}


// SelectiveSearchSegmentationStrategyMultiple

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy(SelectiveSearchSegmentationStrategyMultiple *obj, cv::Ptr<SelectiveSearchSegmentationStrategy> *g, float weight)
{
    obj->addStrategy(*g, weight);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies(SelectiveSearchSegmentationStrategyMultiple *obj)
{
    obj->clearStrategies();
}

CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0()
{
    return clone(createSelectiveSearchSegmentationStrategyMultiple());
}
CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1(
    cv::Ptr<SelectiveSearchSegmentationStrategy> *s1)
{
    return clone(createSelectiveSearchSegmentationStrategyMultiple(*s1));
}
CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2(
    cv::Ptr<SelectiveSearchSegmentationStrategy> *s1, cv::Ptr<SelectiveSearchSegmentationStrategy> *s2)
{
    return clone(createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2));
}
CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3(
    cv::Ptr<SelectiveSearchSegmentationStrategy> *s1, cv::Ptr<SelectiveSearchSegmentationStrategy> *s2, cv::Ptr<SelectiveSearchSegmentationStrategy> *s3)
{
    return clone(createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3));
}
CVAPI(cv::Ptr<SelectiveSearchSegmentationStrategyMultiple>*) ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4(
    cv::Ptr<SelectiveSearchSegmentationStrategy> *s1, cv::Ptr<SelectiveSearchSegmentationStrategy> *s2, cv::Ptr<SelectiveSearchSegmentationStrategy> *s3, cv::Ptr<SelectiveSearchSegmentationStrategy> *s4)
{
    return clone(createSelectiveSearchSegmentationStrategyMultiple(*s1, *s2, *s3, *s4));
}

CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete(cv::Ptr<SelectiveSearchSegmentationStrategyMultiple> *obj)
{
    delete obj;
}

CVAPI(SelectiveSearchSegmentationStrategyMultiple*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get(cv::Ptr<SelectiveSearchSegmentationStrategyMultiple> *ptr)
{
    return ptr->get();
}

// SelectiveSearchSegmentation

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage(SelectiveSearchSegmentation *obj, cv::_InputArray *img)
{
    obj->setBaseImage(*img);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy(SelectiveSearchSegmentation *obj, int k, float sigma)
{
    obj->switchToSingleStrategy(k, sigma);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast(SelectiveSearchSegmentation *obj, int base_k, int inc_k, float sigma)
{
    obj->switchToSelectiveSearchFast(base_k, inc_k, sigma);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality(SelectiveSearchSegmentation *obj, int base_k, int inc_k, float sigma) 
{
    obj->switchToSelectiveSearchQuality(base_k, inc_k, sigma);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_addImage(SelectiveSearchSegmentation *obj, cv::_InputArray *img)
{
    obj->addImage(*img);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_clearImages(SelectiveSearchSegmentation *obj)
{
    obj->clearImages();
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation(SelectiveSearchSegmentation *obj, cv::Ptr<GraphSegmentation> *g)
{
    obj->addGraphSegmentation(*g);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations(SelectiveSearchSegmentation *obj) 
{
    obj->clearGraphSegmentations();
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy(SelectiveSearchSegmentation *obj, cv::Ptr<SelectiveSearchSegmentationStrategy> *s)
{
    obj->addStrategy(*s);
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies(SelectiveSearchSegmentation *obj) 
{
    obj->clearStrategies();
}

CVAPI(void) ximgproc_segmentation_SelectiveSearchSegmentation_process(SelectiveSearchSegmentation *obj, std::vector<cv::Rect> *rects) 
{
    obj->process(*rects);
}

CVAPI(cv::Ptr<SelectiveSearchSegmentation>*) ximgproc_segmentation_createSelectiveSearchSegmentation()
{
    return clone(createSelectiveSearchSegmentation());
}

CVAPI(void) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete(cv::Ptr<SelectiveSearchSegmentation> *obj)
{
    delete obj;
}

CVAPI(SelectiveSearchSegmentation*) ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get(cv::Ptr<SelectiveSearchSegmentation> *ptr)
{
    return ptr->get();
}

#endif