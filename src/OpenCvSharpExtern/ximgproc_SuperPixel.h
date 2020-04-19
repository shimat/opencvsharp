#ifndef _CPP_XIMGPROC_SUPERPIXEL_H_
#define _CPP_XIMGPROC_SUPERPIXEL_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// SuperpixelLSC

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelLSC_delete(
    cv::Ptr<cv::ximgproc::SuperpixelLSC>* obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelLSC_get(
    cv::Ptr<cv::ximgproc::SuperpixelLSC>* ptr, cv::ximgproc::SuperpixelLSC** returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_getNumberOfSuperpixels(
    cv::ximgproc::SuperpixelLSC* obj,
    int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNumberOfSuperpixels();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_iterate(
    cv::ximgproc::SuperpixelLSC* obj, int num_iterations)
{
    BEGIN_WRAP
    obj->iterate(num_iterations);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_getLabels(
    cv::ximgproc::SuperpixelLSC* obj, cv::_OutputArray *labels_out)
{
    BEGIN_WRAP
    obj->getLabels(*labels_out);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_getLabelContourMask(
    cv::ximgproc::SuperpixelLSC* obj,
    cv::_OutputArray *image, int thick_line)
{
    BEGIN_WRAP
    obj->getLabelContourMask(*image, thick_line != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_enforceLabelConnectivity(
    cv::ximgproc::SuperpixelLSC* obj,
    int min_element_size)
{
    BEGIN_WRAP
    obj->enforceLabelConnectivity(min_element_size);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_createSuperpixelLSC(
    cv::_InputArray *image, int region_size, float ratio, cv::Ptr<cv::ximgproc::SuperpixelLSC>** returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ximgproc::createSuperpixelLSC(*image, region_size, ratio);
    *returnValue = new cv::Ptr<cv::ximgproc::SuperpixelLSC>(ptr);
    END_WRAP
}


// SuperpixelSEEDS

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSEEDS_delete(
    cv::Ptr<cv::ximgproc::SuperpixelSEEDS>* obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSEEDS_get(
    cv::Ptr<cv::ximgproc::SuperpixelSEEDS>* ptr, cv::ximgproc::SuperpixelSEEDS** returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_getNumberOfSuperpixels(
    cv::ximgproc::SuperpixelSEEDS* obj,
    int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNumberOfSuperpixels();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_iterate(
    cv::ximgproc::SuperpixelSEEDS* obj, cv::_InputArray *img, int num_iterations)
{
    BEGIN_WRAP
    obj->iterate(*img, num_iterations);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_getLabels(
    cv::ximgproc::SuperpixelSEEDS* obj, cv::_OutputArray* labels_out)
{
    BEGIN_WRAP
    obj->getLabels(*labels_out);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_getLabelContourMask(
    cv::ximgproc::SuperpixelSEEDS* obj,
    cv::_OutputArray* image, int thick_line)
{
    BEGIN_WRAP
    obj->getLabelContourMask(*image, thick_line != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_createSuperpixelSEEDS(
    int image_width, int image_height, int image_channels,
    int num_superpixels, int num_levels, int prior,
    int histogram_bins, int double_step,
    cv::Ptr<cv::ximgproc::SuperpixelSEEDS>** returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ximgproc::createSuperpixelSEEDS(
        image_width, image_height, image_channels, num_superpixels, num_levels, prior, histogram_bins, double_step);
    *returnValue = new cv::Ptr<cv::ximgproc::SuperpixelSEEDS>(ptr);
    END_WRAP
}


// SuperpixelSLIC

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSLIC_delete(
    cv::Ptr<cv::ximgproc::SuperpixelSLIC>* obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSLIC_get(
    cv::Ptr<cv::ximgproc::SuperpixelSLIC>* ptr, cv::ximgproc::SuperpixelSLIC** returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_getNumberOfSuperpixels(
    cv::ximgproc::SuperpixelSLIC* obj,
    int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNumberOfSuperpixels();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_iterate(
    cv::ximgproc::SuperpixelSLIC* obj, int num_iterations)
{
    BEGIN_WRAP
    obj->iterate(num_iterations);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_getLabels(
    cv::ximgproc::SuperpixelSLIC* obj, cv::_OutputArray* labels_out)
{
    BEGIN_WRAP
    obj->getLabels(*labels_out);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_getLabelContourMask(
    cv::ximgproc::SuperpixelSLIC* obj,
    cv::_OutputArray* image, int thick_line)
{
    BEGIN_WRAP
    obj->getLabelContourMask(*image, thick_line != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_enforceLabelConnectivity(
    cv::ximgproc::SuperpixelSLIC* obj,
    int min_element_size)
{
    BEGIN_WRAP
    obj->enforceLabelConnectivity(min_element_size);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_createSuperpixelSLIC(
    cv::_InputArray *image, int algorithm, int region_size, float ruler,
    cv::Ptr<cv::ximgproc::SuperpixelSLIC>** returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ximgproc::createSuperpixelSLIC(
        *image, algorithm, region_size, ruler);
    *returnValue = new cv::Ptr<cv::ximgproc::SuperpixelSLIC>(ptr);
    END_WRAP
}
#endif