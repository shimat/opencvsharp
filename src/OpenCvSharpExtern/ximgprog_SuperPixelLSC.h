#ifndef _CPP_XIMGPROC_SLC_H_
#define _CPP_XIMGPROC_SLC_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

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

#endif