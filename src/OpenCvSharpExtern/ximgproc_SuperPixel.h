#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// SuperpixelLSC

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelLSC_delete(cv::Ptr<cv::ximgproc::SuperpixelLSC>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelLSC_get(cv::Ptr<cv::ximgproc::SuperpixelLSC>* ptr, cv::ximgproc::SuperpixelLSC** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_getNumberOfSuperpixels(cv::ximgproc::SuperpixelLSC* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNumberOfSuperpixels();
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_iterate(cv::ximgproc::SuperpixelLSC* obj, int num_iterations)
{
    return cvTry([&] {
        obj->iterate(num_iterations);
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_getLabels(cv::ximgproc::SuperpixelLSC* obj, const interop::OutputArrayProxy* labels_out)
{
    return cvTry([&] {
        obj->getLabels(OutProxy(*labels_out));
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_getLabelContourMask(
    cv::ximgproc::SuperpixelLSC* obj,
    const interop::OutputArrayProxy* image,
    int thick_line)
{
    return cvTry([&] {
        obj->getLabelContourMask(OutProxy(*image), thick_line != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelLSC_enforceLabelConnectivity(cv::ximgproc::SuperpixelLSC* obj, int min_element_size)
{
    return cvTry([&] {
        obj->enforceLabelConnectivity(min_element_size);
    });
}

CVAPI(ExceptionStatus) ximgproc_createSuperpixelLSC(
    const interop::InputArrayProxy* image,
    int region_size,
    float ratio,
    cv::Ptr<cv::ximgproc::SuperpixelLSC>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createSuperpixelLSC(InProxy(*image), region_size, ratio);
        *returnValue = new cv::Ptr<cv::ximgproc::SuperpixelLSC>(ptr);
    });
}


// SuperpixelSEEDS

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSEEDS_delete(cv::Ptr<cv::ximgproc::SuperpixelSEEDS>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSEEDS_get(cv::Ptr<cv::ximgproc::SuperpixelSEEDS>* ptr, cv::ximgproc::SuperpixelSEEDS** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_getNumberOfSuperpixels(cv::ximgproc::SuperpixelSEEDS* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNumberOfSuperpixels();
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_iterate(
    cv::ximgproc::SuperpixelSEEDS* obj,
    const interop::InputArrayProxy* img,
    int num_iterations)
{
    return cvTry([&] {
        obj->iterate(InProxy(*img), num_iterations);
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_getLabels(cv::ximgproc::SuperpixelSEEDS* obj, const interop::OutputArrayProxy* labels_out)
{
    return cvTry([&] {
        obj->getLabels(OutProxy(*labels_out));
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSEEDS_getLabelContourMask(
    cv::ximgproc::SuperpixelSEEDS* obj,
    const interop::OutputArrayProxy* image,
    int thick_line)
{
    return cvTry([&] {
        obj->getLabelContourMask(OutProxy(*image), thick_line != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_createSuperpixelSEEDS(
    int image_width,
    int image_height,
    int image_channels,
    int num_superpixels,
    int num_levels,
    int prior,
    int histogram_bins,
    int double_step,
    cv::Ptr<cv::ximgproc::SuperpixelSEEDS>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createSuperpixelSEEDS(
            image_width, image_height, image_channels, num_superpixels, num_levels, prior, histogram_bins, double_step);
        *returnValue = new cv::Ptr<cv::ximgproc::SuperpixelSEEDS>(ptr);
    });
}


// SuperpixelSLIC

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSLIC_delete(cv::Ptr<cv::ximgproc::SuperpixelSLIC>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_SuperpixelSLIC_get(cv::Ptr<cv::ximgproc::SuperpixelSLIC>* ptr, cv::ximgproc::SuperpixelSLIC** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_getNumberOfSuperpixels(cv::ximgproc::SuperpixelSLIC* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNumberOfSuperpixels();
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_iterate(cv::ximgproc::SuperpixelSLIC* obj, int num_iterations)
{
    return cvTry([&] {
        obj->iterate(num_iterations);
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_getLabels(cv::ximgproc::SuperpixelSLIC* obj, const interop::OutputArrayProxy* labels_out)
{
    return cvTry([&] {
        obj->getLabels(OutProxy(*labels_out));
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_getLabelContourMask(
    cv::ximgproc::SuperpixelSLIC* obj,
    const interop::OutputArrayProxy* image,
    int thick_line)
{
    return cvTry([&] {
        obj->getLabelContourMask(OutProxy(*image), thick_line != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_SuperpixelSLIC_enforceLabelConnectivity(cv::ximgproc::SuperpixelSLIC* obj, int min_element_size)
{
    return cvTry([&] {
        obj->enforceLabelConnectivity(min_element_size);
    });
}

CVAPI(ExceptionStatus) ximgproc_createSuperpixelSLIC(
    const interop::InputArrayProxy* image,
    int algorithm,
    int region_size,
    float ruler,
    cv::Ptr<cv::ximgproc::SuperpixelSLIC>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createSuperpixelSLIC(
            InProxy(*image), algorithm, region_size, ruler);
        *returnValue = new cv::Ptr<cv::ximgproc::SuperpixelSLIC>(ptr);
    });
}

#endif // NO_CONTRIB
