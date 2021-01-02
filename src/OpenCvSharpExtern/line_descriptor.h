#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) line_descriptor_LSDDetector_new1(
    cv::line_descriptor::LSDDetector** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::line_descriptor::LSDDetector;
    END_WRAP
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_new2(
    const double scale,
    const double sigma_scale,
    const double quant,
    const double ang_th,
    const double log_eps,
    const double density_th,
    const int n_bins,
    cv::line_descriptor::LSDDetector** returnValue)
{
    BEGIN_WRAP
    cv::line_descriptor::LSDParam param;
    param.scale = scale;
    param.sigma_scale = sigma_scale;
    param.quant = quant;
    param.ang_th = ang_th;
    param.log_eps = log_eps;
    param.density_th = density_th;
    param.n_bins = n_bins;
    *returnValue = new cv::line_descriptor::LSDDetector(param);
    END_WRAP
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_delete(cv::line_descriptor::LSDDetector* obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_detect1(
    cv::line_descriptor::LSDDetector* obj,
    cv::Mat* image, std::vector<cv::line_descriptor::KeyLine> *keypoints, int scale, int numOctaves, cv::Mat* mask)
{
    BEGIN_WRAP
    obj->detect(*image, *keypoints, scale, numOctaves, entity(mask));    
    END_WRAP
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_detect2(
    cv::line_descriptor::LSDDetector* obj,
    cv::Mat **images, int32_t imagesSize,
    std::vector<std::vector<cv::line_descriptor::KeyLine> > *keylines, int scale, int numOctaves,
    cv::Mat** masks, int32_t masksSize)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec(imagesSize);
    std::vector<cv::Mat> masksVec(masksSize);
    for (int i = 0; i < imagesSize; i++)
    {
        imagesVec[i] = *images[i];
    }
    for (int i = 0; i < masksSize; i++)
    {
        masksVec[i] = *masks[i];
    }
    
    obj->detect(imagesVec, *keylines, scale, numOctaves, masksVec);

    END_WRAP
}
