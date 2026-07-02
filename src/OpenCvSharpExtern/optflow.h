#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSF1(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* flow,
    int layers,
    int averagingBlockSize,
    int maxFlow)
{
    return cvTry([&] {
    cv::optflow::calcOpticalFlowSF(InProxy(*from), InProxy(*to), OutProxy(*flow), layers, averagingBlockSize, maxFlow);
    });
}

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSF2(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* flow,
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
    return cvTry([&] {
    cv::optflow::calcOpticalFlowSF(InProxy(*from), InProxy(*to), OutProxy(*flow), layers, averagingBlockSize, maxFlow,
        sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix, sigmaColorFix,
        occThr, upscaleAveragingRadius, upscaleSigmaDist, upscaleSigmaColor, speedUpThr);
    });
}

CVAPI(ExceptionStatus) optflow_calcOpticalFlowSparseToDense(
    const interop::InputArrayProxy* from,
    const interop::InputArrayProxy* to,
    const interop::OutputArrayProxy* flow,
    int grid_step,
    int k,
    float sigma,
    int use_post_proc,
    float fgs_lambda,
    float fgs_sigma)
{
    return cvTry([&] {
    cv::optflow::calcOpticalFlowSparseToDense(
        InProxy(*from), InProxy(*to), OutProxy(*flow),
        grid_step, k, sigma, use_post_proc != 0, fgs_lambda, fgs_sigma);
    });
}

#endif // NO_CONTRIB
