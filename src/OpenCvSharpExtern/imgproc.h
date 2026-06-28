#pragma once

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppParameterMayBeConst

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_getGaussianKernel(int ksize, double sigma, int ktype, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getGaussianKernel(ksize, sigma, ktype);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgproc_getDerivKernels(cv::_OutputArray *kx, cv::_OutputArray *ky,
    int dx, int dy, int ksize, int normalize, int ktype)
{
    return cvTry([&] {
    cv::getDerivKernels(*kx, *ky, dx, dy, ksize, normalize != 0, ktype);
    });
}

CVAPI(ExceptionStatus) imgproc_getGaborKernel(interop::Size ksize, double sigma, double theta,
    double lambd, double gamma, double psi, int ktype, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getGaborKernel(cpp(ksize), sigma, theta, lambd, gamma, psi, ktype);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgproc_getStructuringElement(int shape, interop::Size ksize, interop::Point anchor, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getStructuringElement(shape, cpp(ksize), cpp(anchor));
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgproc_medianBlur(cv::_InputArray *src, cv::_OutputArray *dst, int ksize)
{
    return cvTry([&] {
    cv::medianBlur(*src, *dst, ksize);
    });
}

CVAPI(ExceptionStatus) imgproc_GaussianBlur(cv::_InputArray *src, cv::_OutputArray *dst,
                                            interop::Size ksize, double sigmaX, double sigmaY, int borderType, int hint)
{
    return cvTry([&] {
    cv::GaussianBlur(*src, *dst, cpp(ksize), sigmaX, sigmaY, borderType, static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_bilateralFilter(cv::_InputArray *src, cv::_OutputArray *dst,
                                    int d, double sigmaColor, double sigmaSpace, int borderType)
{
    return cvTry([&] {
    cv::bilateralFilter(*src, *dst, d, sigmaColor, sigmaSpace, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_boxFilter(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                              interop::Size ksize, interop::Point anchor, int normalize, int borderType)
{
    return cvTry([&] {
    cv::boxFilter(*src, *dst, ddepth, cpp(ksize), cpp(anchor), normalize != 0, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_sqrBoxFilter(
    cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
    interop::Size ksize, interop::Point anchor, int normalize, int borderType)
{
    return cvTry([&] {
    cv::sqrBoxFilter(*src, *dst, ddepth, cpp(ksize), cpp(anchor), normalize != 0, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_blur(cv::_InputArray *src, cv::_OutputArray *dst, interop::Size ksize, interop::Point anchor, int borderType)
{
    return cvTry([&] {
    cv::blur(*src, *dst, cpp(ksize), cpp(anchor), borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_filter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                             cv::_InputArray *kernel, interop::Point anchor, double delta, int borderType)
{
    return cvTry([&] {
    cv::filter2D(*src, *dst, ddepth, *kernel, cpp(anchor), delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_filter2Dp(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *kernel,
                             int anchorX, int anchorY, int borderType, interop::Scalar borderValue, int ddepth, double scale, double shift)
{
    return cvTry([&] {
    cv::Filter2DParams params;
    params.anchorX = anchorX;
    params.anchorY = anchorY;
    params.borderType = borderType;
    params.borderValue = cpp(borderValue);
    params.ddepth = ddepth;
    params.scale = scale;
    params.shift = shift;
    cv::filter2D(*src, *dst, *kernel, params);
    });
}

CVAPI(ExceptionStatus) imgproc_sepFilter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                                cv::_InputArray *kernelX, cv::_InputArray *kernelY,
                                interop::Point anchor, double delta, int borderType)
{
    return cvTry([&] {
    cv::sepFilter2D(*src, *dst, ddepth, *kernelX, *kernelY, cpp(anchor), delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Sobel(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                          int dx, int dy, int ksize, double scale, double delta, int borderType)
{
    return cvTry([&] {
    cv::Sobel(*src, *dst, ddepth, dx, dy, ksize, scale, delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_spatialGradient(
    cv::_InputArray *src, cv::_OutputArray *dx, cv::_OutputArray *dy, int ksize, int borderType)
{
    return cvTry([&] {
    cv::spatialGradient(*src, *dx, *dy, ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Scharr(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                           int dx, int dy, double scale, double delta, int borderType)
{
    return cvTry([&] {
    cv::Scharr(*src, *dst, ddepth, dx, dy, scale, delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Laplacian(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                              int ksize, double scale, double delta, int borderType)
{
    return cvTry([&] {
    cv::Laplacian(*src, *dst, ddepth, ksize, scale, delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Canny1(cv::_InputArray *src, cv::_OutputArray *edges,
                          double threshold1, double threshold2, int apertureSize, int L2gradient)
{
    return cvTry([&] {
    cv::Canny(*src, *edges, threshold1, threshold2, apertureSize, L2gradient != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_Canny2(
    cv::_InputArray *dx, cv::_InputArray *dy, cv::_OutputArray *edges,
    double threshold1, double threshold2, int L2gradient = false)
{
    return cvTry([&] {
    cv::Canny(*dx, *dy, *edges, threshold1, threshold2, L2gradient != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerMinEigenVal(cv::_InputArray *src, cv::_OutputArray *dst,
                                      int blockSize, int ksize, int borderType)
{
    return cvTry([&] {
    cv::cornerMinEigenVal(*src, *dst, blockSize, ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerHarris(cv::_InputArray *src, cv::_OutputArray *dst,
                                 int blockSize, int ksize, double k, int borderType)
{
    return cvTry([&] {
    cv::cornerHarris(*src, *dst, blockSize, ksize, k, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerEigenValsAndVecs(cv::_InputArray *src, cv::_OutputArray *dst,
                                           int blockSize, int ksize, int borderType)
{
    return cvTry([&] {
    cv::cornerEigenValsAndVecs(*src, *dst, blockSize, ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_preCornerDetect(cv::_InputArray *src, cv::_OutputArray *dst, int ksize, int borderType)
{
    return cvTry([&] {
    cv::preCornerDetect(*src, *dst, ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerSubPix(cv::_InputArray *image, std::vector<cv::Point2f> *corners,
                                 interop::Size winSize, interop::Size zeroZone, interop::TermCriteria criteria)
{
    return cvTry([&] {
    cv::cornerSubPix(*image, *corners, cpp(winSize), cpp(zeroZone), cpp(criteria));
    });
}

CVAPI(ExceptionStatus) imgproc_goodFeaturesToTrack(cv::_InputArray *src, std::vector<cv::Point2f> *corners,
                                        int maxCorners, double qualityLevel, double minDistance,
                                        cv::_InputArray *mask, int blockSize, int useHarrisDetector, double k)
{
    return cvTry([&] {
    cv::goodFeaturesToTrack(*src, *corners, maxCorners, qualityLevel, minDistance, 
        entity(mask), blockSize, useHarrisDetector != 0, k);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughLines(cv::_InputArray *src, std::vector<cv::Vec2f> *lines,
                               double rho, double theta, int threshold,
                               double srn, double stn)
{
    return cvTry([&] {
    cv::HoughLines(*src, *lines, rho, theta, threshold, srn, stn);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughLinesP(cv::_InputArray *src, std::vector<cv::Vec4i> *lines,
                                double rho, double theta, int threshold,
                                double minLineLength, double maxLineGap)
{
    return cvTry([&] {
    cv::HoughLinesP(*src, *lines, rho, theta, threshold, minLineLength, maxLineGap);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughLinesPointSet(
    cv::_InputArray *_point, cv::_OutputArray *_lines, int lines_max, int threshold,
    double min_rho, double max_rho, double rho_step,
    double min_theta, double max_theta, double theta_step)
{
    return cvTry([&] {
    cv::HoughLinesPointSet(*_point, *_lines, lines_max, threshold, min_rho, max_rho, rho_step, min_theta, max_theta, theta_step);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughCircles(cv::_InputArray *src, std::vector<cv::Vec3f> *circles,
                                 int method, double dp, double minDist,
                                 double param1, double param2, int minRadius, int maxRadius)
{
    return cvTry([&] {
    cv::HoughCircles(*src, *circles, method, dp, minDist, param1, param2, minRadius, maxRadius);
    });
}


CVAPI(ExceptionStatus) imgproc_erode(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *kernel,
                          interop::Point anchor, int iterations,    int borderType, interop::Scalar borderValue)
{
    return cvTry([&] {
    cv::erode(*src, *dst, entity(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    });
}

CVAPI(ExceptionStatus) imgproc_dilate(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *kernel,
                           interop::Point anchor, int iterations, int borderType, interop::Scalar borderValue)
{
    return cvTry([&] {
    cv::dilate(*src, *dst, entity(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    });
}

CVAPI(ExceptionStatus) imgproc_morphologyEx(cv::_InputArray *src, cv::_OutputArray *dst, int op, cv::_InputArray *kernel,
                                 interop::Point anchor, int iterations, int borderType, interop::Scalar borderValue)
{
    return cvTry([&] {
    cv::morphologyEx(*src, *dst, op, entity(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    });
}

CVAPI(ExceptionStatus) imgproc_resize(cv::_InputArray* src, cv::_OutputArray* dst, interop::Size dsize, double fx, double fy, int interpolation)
{
    return cvTry([&] {
    cv::resize(*src, *dst, cpp(dsize), fx, fy, interpolation);
    });
}

CVAPI(ExceptionStatus) imgproc_warpAffine(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* M, interop::Size dsize,
                                          int flags, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
    cv::warpAffine(*src, *dst, *M, cpp(dsize), flags, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_warpPerspective_MisInputArray(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* m, interop::Size dsize,
                                                             int flags, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
    cv::warpPerspective(*src, *dst, *m, cpp(dsize), flags, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_warpPerspective_MisArray(cv::_InputArray* src, cv::_OutputArray* dst, float* m, int mRow, int mCol, interop::Size dsize,
                                                        int flags, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
    const cv::Mat mmat(mRow, mCol, CV_32FC1, m);
    cv::warpPerspective(*src, *dst, mmat, cpp(dsize), flags, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_remap(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* map1, cv::_InputArray* map2,
                                     int interpolation, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
    cv::remap(*src, *dst, *map1, *map2, interpolation, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_convertMaps(cv::_InputArray* map1, cv::_InputArray* map2, cv::_OutputArray* dstmap1, cv::_OutputArray* dstmap2,
                                           int dstmap1type, int nnInterpolation)
{
    return cvTry([&] {
    cv::convertMaps(*map1, *map2, *dstmap1, *dstmap2, dstmap1type, nnInterpolation != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_getRotationMatrix2D(interop::Point2f center, double angle, double scale, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getRotationMatrix2D(cpp(center), angle, scale);
    *returnValue = new cv::Mat(ret);
    });

}
CVAPI(ExceptionStatus) imgproc_invertAffineTransform(cv::_InputArray* M, cv::_OutputArray *iM)
{
    return cvTry([&] {
    cv::invertAffineTransform(*M, *iM);
    });
}

CVAPI(ExceptionStatus) imgproc_getPerspectiveTransform1(cv::Point2f *src, cv::Point2f *dst, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getPerspectiveTransform(src, dst);
    *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) imgproc_getPerspectiveTransform2(cv::_InputArray *src, cv::_InputArray *dst, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getPerspectiveTransform(*src, *dst);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgproc_getAffineTransform1(cv::Point2f *src, cv::Point2f *dst, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getAffineTransform(src, dst);
    *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) imgproc_getAffineTransform2(cv::_InputArray *src, cv::_InputArray *dst, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getAffineTransform(*src, *dst);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgproc_getRectSubPix(cv::_InputArray *image, interop::Size patchSize, interop::Point2f center, cv::_OutputArray *patch, int patchType)
{
    return cvTry([&] {
    cv::getRectSubPix(*image, cpp(patchSize), cpp(center), *patch, patchType);
    });
}

CVAPI(ExceptionStatus) imgproc_warpPolar(
    cv::_InputArray *src, cv::_OutputArray *dst, interop::Size dsize,
    interop::Point2f center, double maxRadius, int flags)
{
    return cvTry([&] {
    cv::warpPolar(*src, *dst, cpp(dsize), cpp(center), maxRadius, flags);
    });
}

CVAPI(ExceptionStatus) imgproc_integral1(cv::_InputArray *src, cv::_OutputArray *sum, int sdepth)
{
    return cvTry([&] {
    cv::integral(*src, *sum, sdepth);
    });
}

CVAPI(ExceptionStatus) imgproc_integral2(cv::_InputArray *src, cv::_OutputArray *sum, cv::_OutputArray *sqsum, int sdepth)
{
    return cvTry([&] {
    cv::integral(*src, *sum, *sqsum, sdepth);
    });
}

CVAPI(ExceptionStatus) imgproc_integral3(cv::_InputArray *src, cv::_OutputArray *sum, cv::_OutputArray *sqsum, cv::_OutputArray *tilted, int sdepth, int sqdepth)
{
    return cvTry([&] {
    cv::integral(*src, *sum, *sqsum, *tilted, sdepth, sqdepth);
    });
}

CVAPI(ExceptionStatus) imgproc_accumulate(cv::_InputArray *src, cv::_InputOutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::accumulate(*src, *dst, entity(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_accumulateSquare(cv::_InputArray* src, cv::_InputOutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::accumulateSquare(*src, *dst, entity(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_accumulateProduct(cv::_InputArray *src1, cv::_InputArray *src2, cv::_InputOutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::accumulateProduct(*src1, *src2, *dst, entity(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_accumulateWeighted(cv::_InputArray *src, cv::_InputOutputArray *dst, double alpha, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::accumulateWeighted(*src, *dst, alpha, entity(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_phaseCorrelate(cv::_InputArray *src1, cv::_InputArray *src2,
                                              cv::_InputArray *window, double* response, interop::Point2d* returnValue)
{
    return cvTry([&] {
    const auto p = cv::phaseCorrelate(*src1, *src2, *window, response);
    *returnValue = { p.x, p.y };
    });
}

CVAPI(ExceptionStatus) imgproc_createHanningWindow(cv::_OutputArray *dst, interop::Size winSize, int type)
{
    return cvTry([&] {
    cv::createHanningWindow(*dst, cpp(winSize), type);
    });
}

CVAPI(ExceptionStatus) imgproc_threshold(cv::_InputArray *src, cv::_OutputArray *dst,
                                double thresh, double maxVal, int type, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::threshold(*src, *dst, thresh, maxVal, type);
    });
}

CVAPI(ExceptionStatus) imgproc_adaptiveThreshold(cv::_InputArray *src, cv::_OutputArray *dst,
                                      double maxValue, int adaptiveMethod,
                                      int thresholdType, int blockSize, double C)
{
    return cvTry([&] {
    cv::adaptiveThreshold(*src, *dst, maxValue, adaptiveMethod, thresholdType, blockSize, C);
    });
}

CVAPI(ExceptionStatus) imgproc_pyrDown(cv::_InputArray *src, cv::_OutputArray *dst, interop::Size dstSize, int borderType)
{
    return cvTry([&] {
    cv::pyrDown(*src, *dst, cpp(dstSize), borderType);
    });
}
CVAPI(ExceptionStatus) imgproc_pyrUp(cv::_InputArray *src, cv::_OutputArray *dst, interop::Size dstSize, int borderType)
{
    return cvTry([&] {
    cv::pyrUp(*src, *dst, cpp(dstSize), borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_buildPyramid(cv::_InputArray *src, std::vector<cv::Mat> *dst,int maxlevel, int borderType)
{
    return cvTry([&] {
        cv::buildPyramid(*src, *dst, maxlevel, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_calcHist(cv::Mat **images, int nimages,
                              const int* channels, cv::_InputArray *mask,
                              cv::_OutputArray *hist, int dims, const int* histSize,
                              const float** ranges, int uniform, int accumulate)
{
    return cvTry([&] {
    std::vector<cv::Mat> imagesVec(nimages);
    for (auto i = 0; i < nimages; i++)
        imagesVec[i] = *(images[i]);
    cv::calcHist(&imagesVec[0], nimages, channels, entity(mask), *hist, dims, histSize, ranges, uniform != 0, accumulate != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_calcBackProject(cv::Mat **images, int nimages,
                                    const int* channels, cv::_InputArray *hist, cv::_OutputArray *backProject, 
                                    const float** ranges, int uniform)
{
    return cvTry([&] {
    std::vector<cv::Mat> imagesVec(nimages);
    for (auto i = 0; i < nimages; i++)
        imagesVec[i] = *(images[i]);
    cv::calcBackProject(&imagesVec[0], nimages, channels, *hist, *backProject, ranges, uniform != 0);
    });
}


CVAPI(ExceptionStatus) imgproc_compareHist(cv::_InputArray *h1, cv::_InputArray *h2, int method, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::compareHist(*h1, *h2, method);
    });
}

CVAPI(ExceptionStatus) imgproc_equalizeHist(cv::_InputArray *src, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::equalizeHist(*src, *dst);
    });
}

CVAPI(ExceptionStatus) imgproc_EMD(cv::_InputArray *signature1, cv::_InputArray *signature2,
                         int distType, cv::_InputArray *cost, float* lowerBound, cv::_OutputArray *flow, float* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::EMD(*signature1, *signature2, distType, entity(cost), lowerBound, entity(flow));
    });
}

CVAPI(ExceptionStatus) imgproc_watershed(cv::_InputArray *image, cv::_InputOutputArray *markers)
{
    return cvTry([&] {
    cv::watershed(*image, *markers);
    });
}
CVAPI(ExceptionStatus) imgproc_pyrMeanShiftFiltering(cv::_InputArray *src, cv::_InputOutputArray *dst,
                                          double sp, double sr, int maxLevel, interop::TermCriteria termCrit)
{
    return cvTry([&] {
    cv::pyrMeanShiftFiltering(*src, *dst, sp, sr, maxLevel, cpp(termCrit));
    });
}
CVAPI(ExceptionStatus) imgproc_grabCut(cv::_InputArray *img, cv::_InputOutputArray *mask, interop::Rect rect,
                            cv::_InputOutputArray *bgdModel, cv::_InputOutputArray *fgdModel,
                            int iterCount, int mode)
{
    return cvTry([&] {
    cv::grabCut(*img, *mask, cpp(rect), *bgdModel, *fgdModel, iterCount, mode);
    });
}

CVAPI(ExceptionStatus) imgproc_distanceTransformWithLabels(cv::_InputArray *src, cv::_OutputArray *dst,
                                                cv::_OutputArray *labels, int distanceType, int maskSize,
                                                int labelType)
{
    return cvTry([&] {
    cv::distanceTransform(*src, *dst, *labels, distanceType, maskSize, labelType);
    });
}

CVAPI(ExceptionStatus) imgproc_distanceTransform(cv::_InputArray *src, cv::_OutputArray *dst,
                                      int distanceType, int maskSize, int dstType)
{
    return cvTry([&] {
    cv::distanceTransform(*src, *dst, distanceType, maskSize, dstType);
    });
}

CVAPI(ExceptionStatus) imgproc_floodFill1(cv::_InputOutputArray *image,
                              interop::Point seedPoint, interop::Scalar newVal, interop::Rect *rect,
                              interop::Scalar loDiff, interop::Scalar upDiff, int flags, int *returnValue)
{
    return cvTry([&] {
    cv::Rect rect0;
    *returnValue = cv::floodFill(*image, cpp(seedPoint), cpp(newVal), &rect0, cpp(loDiff), cpp(upDiff), flags);
    *rect = c(rect0);
    });
}
CVAPI(ExceptionStatus) imgproc_floodFill2(cv::_InputOutputArray *image, cv::_InputOutputArray *mask,
                              interop::Point seedPoint, interop::Scalar newVal, interop::Rect *rect,
                              interop::Scalar loDiff, interop::Scalar upDiff, int flags, int* returnValue)
{
    return cvTry([&] {
    cv::Rect rect0;
    *returnValue = cv::floodFill(*image, *mask, cpp(seedPoint), cpp(newVal), &rect0, cpp(loDiff), cpp(upDiff), flags);
    *rect = c(rect0);
    });
}

CVAPI(ExceptionStatus) imgproc_blendLinear(
    cv::_InputArray* src1, cv::_InputArray* src2, cv::_InputArray* weights1, cv::_InputArray* weights2, cv::_OutputArray* dst)
{
    return cvTry([&] {
        cv::blendLinear(*src1, *src2, *weights1, *weights2, *dst);
    });
}

CVAPI(ExceptionStatus) imgproc_cvtColor(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dstCn, int hint)
{
    return cvTry([&] {
    cv::cvtColor(*src, *dst, code, dstCn, static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_cvtColorTwoPlane(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int code, int hint)
{
    return cvTry([&] {
    cv::cvtColorTwoPlane(*src1, *src2, *dst, code, static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_demosaicing(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dstCn)
{
    return cvTry([&] {
    cv::demosaicing(*src, *dst, code, dstCn);
    });    
}

CVAPI(ExceptionStatus) imgproc_moments(cv::_InputArray *arr, int binaryImage, interop::Moments *returnValue)
{
    return cvTry([&] {
    const auto m = cv::moments(*arr, binaryImage != 0);
    *returnValue = c(m);
    });
}
/*
CVAPI(ExceptionStatus) imgproc_HuMoments(interop::Moments *moments, double hu[7])
{
    return cvTry([&] {
    cv::HuMoments(cpp(*moments), hu);
    });
}
*/
CVAPI(ExceptionStatus) imgproc_matchTemplate(cv::_InputArray *image, cv::_InputArray *templ,
                                  cv::_OutputArray *result, int method, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::matchTemplate(*image, *templ, *result, method, entity(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithAlgorithm(
    cv::_InputArray *image, cv::_OutputArray *labels, int connectivity, int ltype, int ccltype, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::connectedComponents(entity(image), entity(labels), connectivity, ltype, ccltype);
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponents(cv::_InputArray *image, cv::_OutputArray *labels,
                                       int connectivity, int ltype, int *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::connectedComponents(entity(image), entity(labels), connectivity, ltype);
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithStatsWithAlgorithm(
    cv::_InputArray *image, cv::_OutputArray *labels,
    cv::_OutputArray *stats, cv::_OutputArray *centroids,
    int connectivity, int ltype, int ccltype, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::connectedComponentsWithStats(
            entity(image), entity(labels), entity(stats), entity(centroids), connectivity, ltype, ccltype);
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithStats(cv::_InputArray *image, cv::_OutputArray *labels,
                                                cv::_OutputArray *stats, cv::_OutputArray *centroids, int connectivity, int ltype, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::connectedComponentsWithStats(
        entity(image), entity(labels), entity(stats), entity(centroids), connectivity, ltype);
    });
}

CVAPI(ExceptionStatus) imgproc_findContours1_vector(cv::_InputArray *image, std::vector<std::vector<cv::Point> > *contours,
                                         std::vector<cv::Vec4i> *hierarchy, int mode, int method, interop::Point offset)
{
    return cvTry([&] {
    cv::findContours(*image, *contours, *hierarchy, mode, method, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_findContours1_OutputArray(cv::_InputArray *image, std::vector<cv::Mat> *contours,
                                              cv::_OutputArray *hierarchy, int mode, int method, interop::Point offset)
{
    return cvTry([&] {
    cv::findContours(*image, *contours, *hierarchy, mode, method, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_findContours2_vector(cv::_InputArray *image, std::vector<std::vector<cv::Point> > *contours,
                                         int mode, int method, interop::Point offset)
{
    return cvTry([&] {
    cv::findContours(*image, *contours, mode, method, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_findContours2_OutputArray(cv::_InputArray *image, std::vector<cv::Mat> *contours,
                                              int mode, int method, interop::Point offset)
{
    return cvTry([&] {
    cv::findContours(*image, *contours, mode, method, cpp(offset));
    });
}

CVAPI(ExceptionStatus) imgproc_findContoursLinkRuns1(cv::_InputArray *image,
                                          std::vector<std::vector<cv::Point> > *contours, std::vector<cv::Vec4i> *hierarchy)
{
    return cvTry([&] {
    cv::findContoursLinkRuns(*image, *contours, *hierarchy);
    });
}
CVAPI(ExceptionStatus) imgproc_findContoursLinkRuns2(cv::_InputArray *image,
                                          std::vector<std::vector<cv::Point> > *contours)
{
    return cvTry([&] {
    cv::findContoursLinkRuns(*image, *contours);
    });
}

CVAPI(ExceptionStatus) imgproc_approxPolyDP_InputArray(cv::_InputArray *curve, cv::_OutputArray *approxCurve, double epsilon, int closed)
{
    return cvTry([&] {
    cv::approxPolyDP(*curve, *approxCurve, epsilon, closed != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_approxPolyDP_Point(cv::Point *curve, int curveLength, std::vector<cv::Point> *approxCurve, double epsilon, int closed)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
    cv::approxPolyDP(curveMat, *approxCurve, epsilon, closed != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_approxPolyDP_Point2f(cv::Point2f *curve, int curveLength, std::vector<cv::Point2f> *approxCurve, double epsilon, int closed)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
    cv::approxPolyDP(curveMat, *approxCurve, epsilon, closed != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_arcLength_InputArray(cv::_InputArray *curve, int closed, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::arcLength(*curve, closed != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_arcLength_Point(cv::Point *curve, int curveLength, int closed, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
    *returnValue = cv::arcLength(curveMat, closed != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_arcLength_Point2f(cv::Point2f *curve, int curveLength, int closed, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
    *returnValue = cv::arcLength(curveMat, closed != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_boundingRect_InputArray(cv::_InputArray *curve, interop::Rect* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::boundingRect(*curve));
    });
}
CVAPI(ExceptionStatus) imgproc_boundingRect_Point(cv::Point *curve, int curveLength, interop::Rect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
    *returnValue = c(cv::boundingRect(curveMat));
    });
}
CVAPI(ExceptionStatus) imgproc_boundingRect_Point2f(cv::Point2f *curve, int curveLength, interop::Rect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
    *returnValue = c(cv::boundingRect(curveMat));
    });
}

CVAPI(ExceptionStatus) imgproc_contourArea_InputArray(cv::_InputArray *contour, int oriented, double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::contourArea(*contour, oriented != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_contourArea_Point(cv::Point *contour, int contourLength, int oriented, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
    *returnValue = cv::contourArea(contourMat, oriented != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_contourArea_Point2f(cv::Point2f *contour, int contourLength, int oriented, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
    *returnValue = cv::contourArea(contourMat, oriented != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_minAreaRect_InputArray(cv::_InputArray *points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::minAreaRect(*points));
    });
}
CVAPI(ExceptionStatus) imgproc_minAreaRect_Point(cv::Point *points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    *returnValue = c(cv::minAreaRect(pointsMat));
    });
}
CVAPI(ExceptionStatus) imgproc_minAreaRect_Point2f(cv::Point2f *points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    *returnValue = c(cv::minAreaRect(pointsMat));
    });
}

CVAPI(ExceptionStatus) imgproc_boxPoints_OutputArray(interop::RotatedRect box, cv::_OutputArray* points)
{
    return cvTry([&] {
    cv::boxPoints(cpp(box), *points);
    });
}
CVAPI(ExceptionStatus) imgproc_boxPoints_Point2f(interop::RotatedRect box, cv::Point2f points[4])
{
    return cvTry([&] {
    cpp(box).points(points);
    });
}

CVAPI(ExceptionStatus) imgproc_minEnclosingCircle_InputArray(cv::_InputArray *points, interop::Point2f *center, float *radius)
{
    return cvTry([&] {
    cv::Point2f center0;
    float radius0;
    cv::minEnclosingCircle(*points, center0, radius0);
    *center = c(center0);
    *radius = radius0;
    });
}
CVAPI(ExceptionStatus) imgproc_minEnclosingCircle_Point(cv::Point *points, int pointsLength, interop::Point2f*center, float *radius)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    cv::Point2f center0;
    float radius0;
    cv::minEnclosingCircle(pointsMat, center0, radius0);
    *center = c(center0);
    *radius = radius0;
    });
}
CVAPI(ExceptionStatus) imgproc_minEnclosingCircle_Point2f(cv::Point2f *points, int pointsLength, interop::Point2f*center, float *radius)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    cv::Point2f center0;
    float radius0;
    cv::minEnclosingCircle(pointsMat, center0, radius0);
    *center = c(center0);
    *radius = radius0;
    });
}

CVAPI(ExceptionStatus) imgproc_minEnclosingTriangle_InputOutputArray(cv::_InputArray *points, cv::_OutputArray *triangle, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::minEnclosingTriangle(*points, *triangle);
    });
}
CVAPI(ExceptionStatus) imgproc_minEnclosingTriangle_Point(cv::Point* points, int pointsLength, std::vector<cv::Point2f>* triangle, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    *returnValue = cv::minEnclosingTriangle(pointsMat, *triangle);
    });
}
CVAPI(ExceptionStatus) imgproc_minEnclosingTriangle_Point2f(cv::Point2f* points, int pointsLength, std::vector<cv::Point2f>* triangle, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    *returnValue = cv::minEnclosingTriangle(pointsMat, *triangle);
    });
}

CVAPI(ExceptionStatus) imgproc_matchShapes_InputArray(
    cv::_InputArray *contour1, cv::_InputArray *contour2, int method, double parameter, double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::matchShapes(*contour1, *contour2, method, parameter);
    });
}
CVAPI(ExceptionStatus) imgproc_matchShapes_Point(
    cv::Point *contour1, int contour1Length, cv::Point *contour2, int contour2Length, int method, double parameter, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> contour1Mat(contour1Length, 1, contour1);
    const cv::Mat_<cv::Point> contour2Mat(contour2Length, 1, contour2);
    *returnValue = cv::matchShapes(contour1Mat, contour2Mat, method, parameter);
    });
}

CVAPI(ExceptionStatus) imgproc_convexHull_InputArray(cv::_InputArray *points, cv::_OutputArray *hull, int clockwise, int returnPoints)
{
    return cvTry([&] {
    cv::convexHull(*points, *hull, clockwise != 0, returnPoints != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point_ReturnsPoints(cv::Point *points, int pointsLength, std::vector<cv::Point> *hull, int clockwise)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, true);
    });
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point2f_ReturnsPoints(cv::Point2f *points, int pointsLength, std::vector<cv::Point2f> *hull, int clockwise)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, true);
    });
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point_ReturnsIndices(cv::Point *points, int pointsLength, std::vector<int> *hull, int clockwise)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, false);
    });
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point2f_ReturnsIndices(cv::Point2f *points, int pointsLength, std::vector<int> *hull, int clockwise)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, false);
    });
}

CVAPI(ExceptionStatus) imgproc_convexityDefects_InputArray(cv::_InputArray *contour, cv::_InputArray *convexHull,
                                                cv::_OutputArray *convexityDefects)
{
    return cvTry([&] {
    cv::convexityDefects(*contour, *convexHull, *convexityDefects);
    });
}
CVAPI(ExceptionStatus) imgproc_convexityDefects_Point(cv::Point *contour, int contourLength, int *convexHull, int convexHullLength,
                                           std::vector<cv::Vec4i> *convexityDefects)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
    const cv::Mat_<int> convexHullMat(convexHullLength, 1,  convexHull);
    cv::convexityDefects(contourMat, convexHullMat, *convexityDefects);
    });
}
CVAPI(ExceptionStatus) imgproc_convexityDefects_Point2f(cv::Point2f *contour, int contourLength, int *convexHull, int convexHullLength,
                                             std::vector<cv::Vec4i> *convexityDefects)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
    const cv::Mat_<int> convexHullMat(convexHullLength, 1, convexHull);
    cv::convexityDefects(contourMat, convexHullMat, *convexityDefects);
    });
}

CVAPI(ExceptionStatus) imgproc_isContourConvex_InputArray(cv::_InputArray *contour, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::isContourConvex(*contour) ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) imgproc_isContourConvex_Point(cv::Point *contour, int contourLength, int* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
    *returnValue = cv::isContourConvex(contourMat) ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) imgproc_isContourConvex_Point2f(cv::Point2f *contour, int contourLength, int* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
    *returnValue = cv::isContourConvex(contourMat) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgproc_intersectConvexConvex_InputArray(cv::_InputArray *p1, cv::_InputArray *p2,
                                                      cv::_OutputArray *p12, int handleNested, float* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::intersectConvexConvex(*p1, *p2, *p12, handleNested != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_intersectConvexConvex_Point(cv::Point *p1, int p1Length, cv::Point *p2, int p2Length,
                                                 std::vector<cv::Point> *p12, int handleNested, float* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> p1Vec(p1Length, 1, p1);
    const cv::Mat_<cv::Point> p2Vec(p2Length, 1, p2);
    *returnValue = cv::intersectConvexConvex(p1Vec, p2Vec, *p12, handleNested != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_intersectConvexConvex_Point2f(cv::Point2f *p1, int p1Length, cv::Point2f *p2, int p2Length,
                                                   std::vector<cv::Point2f> *p12, int handleNested, float *returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> p1Vec(p1Length, 1, p1);
    const cv::Mat_<cv::Point2f> p2Vec(p2Length, 1, p2);
    *returnValue = cv::intersectConvexConvex(p1Vec, p2Vec, *p12, handleNested != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_fitEllipse_InputArray(cv::_InputArray *points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::fitEllipse(*points));
    });
}
CVAPI(ExceptionStatus) imgproc_fitEllipse_Point(cv::Point *points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipse(pointsVec));
    });
}
CVAPI(ExceptionStatus) imgproc_fitEllipse_Point2f(cv::Point2f *points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipse(pointsVec));
    });
}

CVAPI(ExceptionStatus) imgproc_fitEllipseAMS_InputArray(cv::_InputArray *points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::fitEllipseAMS(*points));
    });
}
CVAPI(ExceptionStatus) imgproc_fitEllipseAMS_Point(cv::Point* points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseAMS(pointsVec));
    });
}
CVAPI(ExceptionStatus) imgproc_fitEllipseAMS_Point2f(cv::Point2f* points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseAMS(pointsVec));
    });
}

CVAPI(ExceptionStatus) imgproc_fitEllipseDirect_InputArray(cv::_InputArray* points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::fitEllipseDirect(*points));
    });
}
CVAPI(ExceptionStatus) imgproc_fitEllipseDirect_Point(cv::Point* points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseDirect(pointsVec));
    });
}
CVAPI(ExceptionStatus) imgproc_fitEllipseDirect_Point2f(cv::Point2f* points, int pointsLength, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseDirect(pointsVec));
    });
}

CVAPI(ExceptionStatus) imgproc_fitLine_InputArray(cv::_InputArray *points, cv::_OutputArray *line,
                                       int distType, double param, double reps, double aeps)
{
    return cvTry([&] {
    cv::fitLine(*points, *line, distType, param, reps, aeps);
    });
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point(cv::Point *points, int pointsLength, float *line, int distType,
                                  double param, double reps, double aeps)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(4, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point2f(cv::Point2f *points, int pointsLength, float *line, int distType,
                                    double param, double reps, double aeps)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(4, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point3i(cv::Point3i *points, int pointsLength, float *line, int distType,
                                    double param, double reps, double aeps)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point3i> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(6, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point3f(cv::Point3f *points, int pointsLength, float *line, int distType,
                                    double param, double reps, double aeps)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point3f> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(6, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    });
}

CVAPI(ExceptionStatus) imgproc_pointPolygonTest_InputArray(
    cv::_InputArray* contour, interop::Point2f pt, int measureDist, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::pointPolygonTest(*contour, cpp(pt), measureDist != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_pointPolygonTest_Point(
    cv::Point *contour, int contourLength, interop::Point2f pt, int measureDist, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point> contourVec(contourLength, 1, contour);
    *returnValue = cv::pointPolygonTest(contourVec, cpp(pt), measureDist != 0);
    });
}
CVAPI(ExceptionStatus) imgproc_pointPolygonTest_Point2f(
    cv::Point2f *contour, int contourLength, interop::Point2f pt, int measureDist, double* returnValue)
{
    return cvTry([&] {
    const cv::Mat_<cv::Point2f> contourVec(contourLength, 1, contour);
    *returnValue = cv::pointPolygonTest(contourVec, cpp(pt), measureDist != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_rotatedRectangleIntersection_OutputArray(
    interop::RotatedRect rect1, interop::RotatedRect rect2, cv::_OutputArray *intersectingRegion, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), *intersectingRegion);
    });
}
CVAPI(ExceptionStatus) imgproc_rotatedRectangleIntersection_vector(
    interop::RotatedRect rect1, interop::RotatedRect rect2, std::vector<cv::Point2f> *intersectingRegion, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), *intersectingRegion);
    });
}

CVAPI(ExceptionStatus) imgproc_applyColorMap1(cv::_InputArray *src, cv::_OutputArray *dst, int colorMap)
{
    return cvTry([&] {
    cv::applyColorMap(*src, *dst, colorMap);
    });
}

CVAPI(ExceptionStatus) imgproc_applyColorMap2(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *userColor)
{
    return cvTry([&] {
    cv::applyColorMap(*src, *dst, *userColor);
    });    
}

#pragma region Drawing

CVAPI(ExceptionStatus) imgproc_line(
    cv::_InputOutputArray *img, interop::Point pt1, interop::Point pt2, interop::Scalar color,
    int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::line(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_arrowedLine(
    cv::_InputOutputArray *img, interop::Point pt1, interop::Point pt2, interop::Scalar color,
    int thickness, int line_type, int shift, double tipLength)
{
    return cvTry([&] {
    cv::arrowedLine(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, line_type, shift, tipLength);
    });
}


CVAPI(ExceptionStatus) imgproc_rectangle_InputOutputArray_Point(
    cv::_InputOutputArray *img, interop::Point pt1, interop::Point pt2,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::rectangle(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_rectangle_InputOutputArray_Rect(
    cv::_InputOutputArray* img, interop::Rect rect,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::rectangle(*img, cpp(rect), cpp(color), thickness, lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_rectangle_Mat_Point(
    cv::Mat* img, interop::Point pt1, interop::Point pt2,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::rectangle(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_rectangle_Mat_Rect(
    cv::Mat *img, interop::Rect rect,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::rectangle(*img, cpp(rect), cpp(color), thickness, lineType, shift);
    });
}


CVAPI(ExceptionStatus) imgproc_circle(
    cv::_InputOutputArray *img, interop::Point center, int radius,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::circle(*img, cpp(center), radius, cpp(color), thickness, lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_ellipse1(
    cv::_InputOutputArray *img, interop::Point center, interop::Size axes,
    double angle, double startAngle, double endAngle,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::ellipse(*img, cpp(center), cpp(axes), angle, startAngle, endAngle, cpp(color), thickness, lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_ellipse2(
    cv::_InputOutputArray *img, interop::RotatedRect box, interop::Scalar color, int thickness, int lineType)
{
    return cvTry([&] {
    cv::ellipse(*img, cpp(box), cpp(color), thickness, lineType);
    });
}

CVAPI(ExceptionStatus) imgproc_drawMarker(
    cv::_InputOutputArray *img, interop::Point position, interop::Scalar color,
    int markerType, int markerSize, int thickness, int lineType)
{
    return cvTry([&] {
    cv::drawMarker(*img, cpp(position), cpp(color), markerType, markerSize, thickness, lineType);
    });
}

CVAPI(ExceptionStatus) imgproc_fillConvexPoly_Mat(
    cv::Mat *img, cv::Point *pts, int npts, interop::Scalar color, int lineType, int shift)
{
    return cvTry([&] {
    cv::fillConvexPoly(*img, pts, npts, cpp(color), lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_fillConvexPoly_InputOutputArray(
    cv::_InputOutputArray *img, cv::_InputArray *points, interop::Scalar color, int lineType, int shift)
{
    return cvTry([&] {
    cv::fillConvexPoly(*img, *points, cpp(color), lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_fillPoly_Mat(cv::Mat *img, const cv::Point **pts, const int *npts,
                                 int ncontours, interop::Scalar color, int lineType, int shift, interop::Point offset)
{
    return cvTry([&] {
    cv::fillPoly(*img, pts, npts, ncontours, cpp(color), lineType, shift, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_fillPoly_InputOutputArray(cv::_InputOutputArray *img, cv::_InputArray *pts,
                                              interop::Scalar color, int lineType, int shift, interop::Point offset)
{
    return cvTry([&] {
    cv::fillPoly(*img, *pts, cpp(color), lineType, shift, cpp(offset));
    });
}

CVAPI(ExceptionStatus) imgproc_polylines_Mat(
    cv::Mat *img, const cv::Point **pts, const int *npts,
    int ncontours, int isClosed, interop::Scalar color,
    int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::polylines(
        *img, pts, npts, ncontours, isClosed != 0, cpp(color), thickness, lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_polylines_InputOutputArray(
    cv::_InputOutputArray *img, cv::_InputArray *pts, int isClosed, interop::Scalar color,
    int thickness, int lineType, int shift)
{
    return cvTry([&] {
    cv::polylines(*img, *pts, isClosed != 0, cpp(color), thickness, lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_drawContours_vector(cv::_InputOutputArray *image,
                                        cv::Point **contours, int contoursSize1, int *contoursSize2,
                                        int contourIdx, interop::Scalar color, int thickness, int lineType,
                                        cv::Vec4i *hierarchy, int hiearchyLength, int maxLevel, interop::Point offset)
{
    return cvTry([&] {
    std::vector<std::vector<cv::Point> > contoursVec;
    for (auto i = 0; i < contoursSize1; i++)
    {
        std::vector<cv::Point> c1(contours[i], contours[i] + contoursSize2[i]);
        contoursVec.push_back(c1);
    }
    std::vector<cv::Vec4i> hierarchyVec;
    if (hierarchy != nullptr)
    {
        hierarchyVec = std::vector<cv::Vec4i>(hierarchy, hierarchy + hiearchyLength);
    }

    cv::drawContours(
        *image, contoursVec, contourIdx, cpp(color), thickness, lineType, hierarchyVec, maxLevel, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_drawContours_InputArray(cv::_InputOutputArray *image,
                                            cv::Mat **contours, int contoursLength,
                                            int contourIdx, interop::Scalar color, int thickness, int lineType,
                                            cv::_InputArray *hierarchy, int maxLevel, interop::Point offset)
{
    return cvTry([&] {
    std::vector<std::vector<cv::Point> > contoursVec(contoursLength);
    for (auto i = 0; i < contoursLength; i++)
        contoursVec[i] = *contours[i];
    cv::drawContours(
        *image, contoursVec, contourIdx, cpp(color), thickness, lineType, entity(hierarchy), maxLevel, cpp(offset));
    });
}

CVAPI(ExceptionStatus) imgproc_clipLine1(interop::Size imgSize, interop::Point *pt1, interop::Point *pt2, int* returnValue)
{
    return cvTry([&] {
    auto pt1c = cpp(*pt1), pt2c = cpp(*pt2);
    const auto result = cv::clipLine(cpp(imgSize), pt1c, pt2c);
    *pt1 = c(pt1c);
    *pt2 = c(pt2c);
    *returnValue = result ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) imgproc_clipLine2(interop::Rect imgRect, interop::Point *pt1, interop::Point *pt2, int* returnValue)
{
    return cvTry([&] {
    auto pt1c = cpp(*pt1), pt2c = cpp(*pt2);
    const auto result = cv::clipLine(cpp(imgRect), pt1c, pt2c);
    *pt1 = c(pt1c);
    *pt2 = c(pt2c);
    *returnValue = result ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgproc_ellipse2Poly_int(
    interop::Point center, interop::Size axes, int angle, int arcStart, int arcEnd,
    int delta, std::vector<cv::Point>* pts)
{
    return cvTry([&] {
    cv::ellipse2Poly(cpp(center), cpp(axes), angle, arcStart, arcEnd, delta, *pts);
    });
}

CVAPI(ExceptionStatus) imgproc_ellipse2Poly_double(
    interop::Point2d center, interop::Size2d axes, int angle, int arcStart, int arcEnd,
    int delta, std::vector<cv::Point2d>* pts)
{
    return cvTry([&] {
    cv::ellipse2Poly(cpp(center), cpp(axes), angle, arcStart, arcEnd, delta, *pts);
    });
}

CVAPI(ExceptionStatus) imgproc_putText(cv::_InputOutputArray *img, const char *text, interop::Point org,
                         int fontFace, double fontScale, interop::Scalar color,
                         int thickness, int lineType, int bottomLeftOrigin)
{
    return cvTry([&] {
    cv::putText(*img, text, cpp(org), fontFace, fontScale, cpp(color), thickness, lineType, bottomLeftOrigin != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_getTextSize(const char *text, int fontFace,
                                 double fontScale, int thickness, int *baseLine, interop::Size *returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::getTextSize(text, fontFace, fontScale, thickness, baseLine));
    });
}

CVAPI(ExceptionStatus) imgproc_getFontScaleFromHeight(
    int fontFace, int pixelHeight, int thickness, double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getFontScaleFromHeight(fontFace, pixelHeight, thickness);
    });
}

#pragma endregion
