#ifndef _CPP_OPTFLOW_H_
#define _CPP_OPTFLOW_H_

#include "include_opencv.h"
using namespace cv::optflow;

CVAPI(void) optflow_calcOpticalFlowSF1(
    cv::Mat *from,
    cv::Mat *to,
    cv::Mat *flow,
    int layers,
    int averagingBlockSize,
    int maxFlow)
{
    calcOpticalFlowSF(*from, *to, *flow, layers, averagingBlockSize, maxFlow);
}

CVAPI(void) optflow_calcOpticalFlowSF2(
    cv::Mat *from,
    cv::Mat *to,
    cv::Mat *flow,
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
    calcOpticalFlowSF(*from, *to, *flow, layers, averagingBlockSize, maxFlow,
        sigmaDist, sigmaColor, postprocessWindow, sigmaDistFix, sigmaColorFix,
        occThr, upscaleAveragingRadius, upscaleSigmaDist, upscaleSigmaColor, speedUpThr);
}

#endif
