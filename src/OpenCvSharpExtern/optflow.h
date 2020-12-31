#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSF1(
    cv::_InputArray *from,
    cv::_InputArray *to,
    cv::_OutputArray *flow,
    int layers,
    int averagingBlockSize,
    int maxFlow)
{
    BEGIN_WRAP
    cv::optflow::calcOpticalFlowSF(*from, *to, *flow, layers, averagingBlockSize, maxFlow);
    END_WRAP
}

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSF2(
    cv::_InputArray *from,
    cv::_InputArray *to,
    cv::_OutputArray *flow,
    int layers,
    int averagingBlockSize,
    int maxFlow,
    double sigmaDist,
    double sigmaColor,
    int postprocessWindow,
    double sigmaDistFix,
    double sigmaColorFix,
    double occThr,
    int upscaleAveragingRadius,
    double upscaleSigmaDist,
    double upscaleSigmaColor,
    double speedUpThr)
{
    BEGIN_WRAP
    cv::optflow::calcOpticalFlowSF(*from, *to, *flow, layers, averagingBlockSize, maxFlow,
        sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix, sigmaColorFix,
        occThr, upscaleAveragingRadius, upscaleSigmaDist, upscaleSigmaColor, speedUpThr);
    END_WRAP
}

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSparseToDense(
    cv::_InputArray *from,  cv::_InputArray *to,  cv::_OutputArray *flow,
    int grid_step, int k, float sigma, int use_post_proc, float fgs_lambda, float fgs_sigma )
{
    BEGIN_WRAP
    cv::optflow::calcOpticalFlowSparseToDense(
        *from, *to, *flow, 
        grid_step, k, sigma, use_post_proc != 0, fgs_lambda, fgs_sigma);
    END_WRAP
}
