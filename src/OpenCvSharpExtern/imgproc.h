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

CVAPI(ExceptionStatus) imgproc_getDerivKernels(interop::OutputArrayProxy kx, interop::OutputArrayProxy ky,
    int dx, int dy, int ksize, int normalize, int ktype)
{
    return cvTry([&] {
        cv::getDerivKernels(OutProxy(kx), OutProxy(ky), dx, dy, ksize, normalize != 0, ktype);
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

CVAPI(ExceptionStatus) imgproc_medianBlur(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ksize)
{
    return cvTry([&] {
        cv::medianBlur(InProxy(src), OutProxy(dst), ksize);
    });
}

CVAPI(ExceptionStatus) imgproc_GaussianBlur(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                            interop::Size ksize, double sigmaX, double sigmaY, int borderType, int hint)
{
    return cvTry([&] {
        cv::GaussianBlur(InProxy(src), OutProxy(dst), cpp(ksize), sigmaX, sigmaY, borderType, static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_bilateralFilter(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                    int d, double sigmaColor, double sigmaSpace, int borderType)
{
    return cvTry([&] {
        cv::bilateralFilter(InProxy(src), OutProxy(dst), d, sigmaColor, sigmaSpace, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_boxFilter(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ddepth,
                              interop::Size ksize, interop::Point anchor, int normalize, int borderType)
{
    return cvTry([&] {
        cv::boxFilter(InProxy(src), OutProxy(dst), ddepth, cpp(ksize), cpp(anchor), normalize != 0, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_sqrBoxFilter(
    interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ddepth,
    interop::Size ksize, interop::Point anchor, int normalize, int borderType)
{
    return cvTry([&] {
        cv::sqrBoxFilter(InProxy(src), OutProxy(dst), ddepth, cpp(ksize), cpp(anchor), normalize != 0, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_blur(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::Size ksize, interop::Point anchor, int borderType)
{
    return cvTry([&] {
        cv::blur(InProxy(src), OutProxy(dst), cpp(ksize), cpp(anchor), borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_filter2D(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ddepth,
                             interop::InputArrayProxy kernel, interop::Point anchor, double delta, int borderType)
{
    return cvTry([&] {
        cv::filter2D(InProxy(src), OutProxy(dst), ddepth, InProxy(kernel), cpp(anchor), delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_filter2Dp(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::InputArrayProxy kernel,
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
        cv::filter2D(InProxy(src), OutProxy(dst), InProxy(kernel), params);
    });
}

CVAPI(ExceptionStatus) imgproc_sepFilter2D(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ddepth,
                                interop::InputArrayProxy kernelX, interop::InputArrayProxy kernelY,
                                interop::Point anchor, double delta, int borderType)
{
    return cvTry([&] {
        cv::sepFilter2D(InProxy(src), OutProxy(dst), ddepth, InProxy(kernelX), InProxy(kernelY), cpp(anchor), delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Sobel(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ddepth,
                          int dx, int dy, int ksize, double scale, double delta, int borderType)
{
    return cvTry([&] {
        cv::Sobel(InProxy(src), OutProxy(dst), ddepth, dx, dy, ksize, scale, delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_spatialGradient(
    interop::InputArrayProxy src, interop::OutputArrayProxy dx, interop::OutputArrayProxy dy, int ksize, int borderType)
{
    return cvTry([&] {
        cv::spatialGradient(InProxy(src), OutProxy(dx), OutProxy(dy), ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Scharr(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ddepth,
                           int dx, int dy, double scale, double delta, int borderType)
{
    return cvTry([&] {
        cv::Scharr(InProxy(src), OutProxy(dst), ddepth, dx, dy, scale, delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Laplacian(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ddepth,
                              int ksize, double scale, double delta, int borderType)
{
    return cvTry([&] {
        cv::Laplacian(InProxy(src), OutProxy(dst), ddepth, ksize, scale, delta, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_Canny1(interop::InputArrayProxy src, interop::OutputArrayProxy edges,
                          double threshold1, double threshold2, int apertureSize, int L2gradient)
{
    return cvTry([&] {
        cv::Canny(InProxy(src), OutProxy(edges), threshold1, threshold2, apertureSize, L2gradient != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_Canny2(
    interop::InputArrayProxy dx, interop::InputArrayProxy dy, interop::OutputArrayProxy edges,
    double threshold1, double threshold2, int L2gradient = false)
{
    return cvTry([&] {
        cv::Canny(InProxy(dx), InProxy(dy), OutProxy(edges), threshold1, threshold2, L2gradient != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerMinEigenVal(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                      int blockSize, int ksize, int borderType)
{
    return cvTry([&] {
        cv::cornerMinEigenVal(InProxy(src), OutProxy(dst), blockSize, ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerHarris(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                 int blockSize, int ksize, double k, int borderType)
{
    return cvTry([&] {
        cv::cornerHarris(InProxy(src), OutProxy(dst), blockSize, ksize, k, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerEigenValsAndVecs(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                           int blockSize, int ksize, int borderType)
{
    return cvTry([&] {
        cv::cornerEigenValsAndVecs(InProxy(src), OutProxy(dst), blockSize, ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_preCornerDetect(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int ksize, int borderType)
{
    return cvTry([&] {
        cv::preCornerDetect(InProxy(src), OutProxy(dst), ksize, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_cornerSubPix(interop::InputArrayProxy image, std::vector<cv::Point2f> *corners,
                                 interop::Size winSize, interop::Size zeroZone, interop::TermCriteria criteria)
{
    return cvTry([&] {
        cv::cornerSubPix(InProxy(image), *corners, cpp(winSize), cpp(zeroZone), cpp(criteria));
    });
}

CVAPI(ExceptionStatus) imgproc_goodFeaturesToTrack(interop::InputArrayProxy src, std::vector<cv::Point2f> *corners,
                                        int maxCorners, double qualityLevel, double minDistance,
                                        interop::InputArrayProxy mask, int blockSize, int useHarrisDetector, double k)
{
    return cvTry([&] {
        cv::goodFeaturesToTrack(InProxy(src), *corners, maxCorners, qualityLevel, minDistance, 
            InProxy(mask), blockSize, useHarrisDetector != 0, k);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughLines(interop::InputArrayProxy src, std::vector<cv::Vec2f> *lines,
                               double rho, double theta, int threshold,
                               double srn, double stn)
{
    return cvTry([&] {
        cv::HoughLines(InProxy(src), *lines, rho, theta, threshold, srn, stn);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughLinesP(interop::InputArrayProxy src, std::vector<cv::Vec4i> *lines,
                                double rho, double theta, int threshold,
                                double minLineLength, double maxLineGap)
{
    return cvTry([&] {
        cv::HoughLinesP(InProxy(src), *lines, rho, theta, threshold, minLineLength, maxLineGap);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughLinesPointSet(
    interop::InputArrayProxy _point, interop::OutputArrayProxy _lines, int lines_max, int threshold,
    double min_rho, double max_rho, double rho_step,
    double min_theta, double max_theta, double theta_step)
{
    return cvTry([&] {
        cv::HoughLinesPointSet(InProxy(_point), OutProxy(_lines), lines_max, threshold, min_rho, max_rho, rho_step, min_theta, max_theta, theta_step);
    });
}

CVAPI(ExceptionStatus) imgproc_HoughCircles(interop::InputArrayProxy src, std::vector<cv::Vec3f> *circles,
                                 int method, double dp, double minDist,
                                 double param1, double param2, int minRadius, int maxRadius)
{
    return cvTry([&] {
        cv::HoughCircles(InProxy(src), *circles, method, dp, minDist, param1, param2, minRadius, maxRadius);
    });
}


CVAPI(ExceptionStatus) imgproc_erode(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::InputArrayProxy kernel,
                          interop::Point anchor, int iterations,    int borderType, interop::Scalar borderValue)
{
    return cvTry([&] {
        cv::erode(InProxy(src), OutProxy(dst), InProxy(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    });
}

CVAPI(ExceptionStatus) imgproc_dilate(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::InputArrayProxy kernel,
                           interop::Point anchor, int iterations, int borderType, interop::Scalar borderValue)
{
    return cvTry([&] {
        cv::dilate(InProxy(src), OutProxy(dst), InProxy(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    });
}

CVAPI(ExceptionStatus) imgproc_morphologyEx(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int op, interop::InputArrayProxy kernel,
                                 interop::Point anchor, int iterations, int borderType, interop::Scalar borderValue)
{
    return cvTry([&] {
        cv::morphologyEx(InProxy(src), OutProxy(dst), op, InProxy(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    });
}

CVAPI(ExceptionStatus) imgproc_resize(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::Size dsize, double fx, double fy, int interpolation)
{
    return cvTry([&] {
        cv::resize(InProxy(src), OutProxy(dst), cpp(dsize), fx, fy, interpolation);
    });
}

CVAPI(ExceptionStatus) imgproc_warpAffine(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::InputArrayProxy M, interop::Size dsize,
                                          int flags, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
        cv::warpAffine(InProxy(src), OutProxy(dst), InProxy(M), cpp(dsize), flags, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_warpPerspective_MisInputArray(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::InputArrayProxy m, interop::Size dsize,
                                                             int flags, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
        cv::warpPerspective(InProxy(src), OutProxy(dst), InProxy(m), cpp(dsize), flags, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_warpPerspective_MisArray(interop::InputArrayProxy src, interop::OutputArrayProxy dst, float* m, int mRow, int mCol, interop::Size dsize,
                                                        int flags, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
        const cv::Mat mmat(mRow, mCol, CV_32FC1, m);
        cv::warpPerspective(InProxy(src), OutProxy(dst), mmat, cpp(dsize), flags, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_remap(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::InputArrayProxy map1, interop::InputArrayProxy map2,
                                     int interpolation, int borderMode, interop::Scalar borderValue, int hint)
{
    return cvTry([&] {
        cv::remap(InProxy(src), OutProxy(dst), InProxy(map1), InProxy(map2), interpolation, borderMode, cpp(borderValue), static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_convertMaps(interop::InputArrayProxy map1, interop::InputArrayProxy map2, interop::OutputArrayProxy dstmap1, interop::OutputArrayProxy dstmap2,
                                           int dstmap1type, int nnInterpolation)
{
    return cvTry([&] {
        cv::convertMaps(InProxy(map1), InProxy(map2), OutProxy(dstmap1), OutProxy(dstmap2), dstmap1type, nnInterpolation != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_getRotationMatrix2D(interop::Point2f center, double angle, double scale, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getRotationMatrix2D(cpp(center), angle, scale);
    *returnValue = new cv::Mat(ret);
    });

}
CVAPI(ExceptionStatus) imgproc_invertAffineTransform(interop::InputArrayProxy M, interop::OutputArrayProxy iM)
{
    return cvTry([&] {
        cv::invertAffineTransform(InProxy(M), OutProxy(iM));
    });
}

CVAPI(ExceptionStatus) imgproc_getPerspectiveTransform1(cv::Point2f *src, cv::Point2f *dst, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::getPerspectiveTransform(src, dst);
    *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) imgproc_getPerspectiveTransform2(interop::InputArrayProxy src, interop::InputArrayProxy dst, cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::getPerspectiveTransform(InProxy(src), InProxy(dst));
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
CVAPI(ExceptionStatus) imgproc_getAffineTransform2(interop::InputArrayProxy src, interop::InputArrayProxy dst, cv::Mat** returnValue)
{
    return cvTry([&] {
        const auto ret = cv::getAffineTransform(InProxy(src), InProxy(dst));
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgproc_getRectSubPix(interop::InputArrayProxy image, interop::Size patchSize, interop::Point2f center, interop::OutputArrayProxy patch, int patchType)
{
    return cvTry([&] {
        cv::getRectSubPix(InProxy(image), cpp(patchSize), cpp(center), OutProxy(patch), patchType);
    });
}

CVAPI(ExceptionStatus) imgproc_warpPolar(
    interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::Size dsize,
    interop::Point2f center, double maxRadius, int flags)
{
    return cvTry([&] {
        cv::warpPolar(InProxy(src), OutProxy(dst), cpp(dsize), cpp(center), maxRadius, flags);
    });
}

CVAPI(ExceptionStatus) imgproc_integral1(interop::InputArrayProxy src, interop::OutputArrayProxy sum, int sdepth)
{
    return cvTry([&] {
        cv::integral(InProxy(src), OutProxy(sum), sdepth);
    });
}

CVAPI(ExceptionStatus) imgproc_integral2(interop::InputArrayProxy src, interop::OutputArrayProxy sum, interop::OutputArrayProxy sqsum, int sdepth)
{
    return cvTry([&] {
        cv::integral(InProxy(src), OutProxy(sum), OutProxy(sqsum), sdepth);
    });
}

CVAPI(ExceptionStatus) imgproc_integral3(interop::InputArrayProxy src, interop::OutputArrayProxy sum, interop::OutputArrayProxy sqsum, interop::OutputArrayProxy tilted, int sdepth, int sqdepth)
{
    return cvTry([&] {
        cv::integral(InProxy(src), OutProxy(sum), OutProxy(sqsum), OutProxy(tilted), sdepth, sqdepth);
    });
}

CVAPI(ExceptionStatus) imgproc_accumulate(interop::InputArrayProxy src, interop::InputOutputArrayProxy dst, interop::InputArrayProxy mask)
{
    return cvTry([&] {
        cv::accumulate(InProxy(src), IoProxy(dst), InProxy(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_accumulateSquare(interop::InputArrayProxy src, interop::InputOutputArrayProxy dst, interop::InputArrayProxy mask)
{
    return cvTry([&] {
        cv::accumulateSquare(InProxy(src), IoProxy(dst), InProxy(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_accumulateProduct(interop::InputArrayProxy src1, interop::InputArrayProxy src2, interop::InputOutputArrayProxy dst, interop::InputArrayProxy mask)
{
    return cvTry([&] {
        cv::accumulateProduct(InProxy(src1), InProxy(src2), IoProxy(dst), InProxy(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_accumulateWeighted(interop::InputArrayProxy src, interop::InputOutputArrayProxy dst, double alpha, interop::InputArrayProxy mask)
{
    return cvTry([&] {
        cv::accumulateWeighted(InProxy(src), IoProxy(dst), alpha, InProxy(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_phaseCorrelate(interop::InputArrayProxy src1, interop::InputArrayProxy src2,
                                              interop::InputArrayProxy window, double* response, interop::Point2d* returnValue)
{
    return cvTry([&] {
        const auto p = cv::phaseCorrelate(InProxy(src1), InProxy(src2), InProxy(window), response);
        *returnValue = { p.x, p.y };
    });
}

CVAPI(ExceptionStatus) imgproc_createHanningWindow(interop::OutputArrayProxy dst, interop::Size winSize, int type)
{
    return cvTry([&] {
        cv::createHanningWindow(OutProxy(dst), cpp(winSize), type);
    });
}

CVAPI(ExceptionStatus) imgproc_threshold(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                double thresh, double maxVal, int type, double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::threshold(InProxy(src), OutProxy(dst), thresh, maxVal, type);
    });
}

CVAPI(ExceptionStatus) imgproc_adaptiveThreshold(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                      double maxValue, int adaptiveMethod,
                                      int thresholdType, int blockSize, double C)
{
    return cvTry([&] {
        cv::adaptiveThreshold(InProxy(src), OutProxy(dst), maxValue, adaptiveMethod, thresholdType, blockSize, C);
    });
}

CVAPI(ExceptionStatus) imgproc_pyrDown(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::Size dstSize, int borderType)
{
    return cvTry([&] {
        cv::pyrDown(InProxy(src), OutProxy(dst), cpp(dstSize), borderType);
    });
}
CVAPI(ExceptionStatus) imgproc_pyrUp(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::Size dstSize, int borderType)
{
    return cvTry([&] {
        cv::pyrUp(InProxy(src), OutProxy(dst), cpp(dstSize), borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_buildPyramid(interop::InputArrayProxy src, std::vector<cv::Mat> *dst,int maxlevel, int borderType)
{
    return cvTry([&] {
        cv::buildPyramid(InProxy(src), *dst, maxlevel, borderType);
    });
}

CVAPI(ExceptionStatus) imgproc_calcHist(cv::Mat **images, int nimages,
                              const int* channels, interop::InputArrayProxy mask,
                              interop::OutputArrayProxy hist, int dims, const int* histSize,
                              const float** ranges, int uniform, int accumulate)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec(nimages);
        for (auto i = 0; i < nimages; i++)
            imagesVec[i] = *(images[i]);
        cv::calcHist(&imagesVec[0], nimages, channels, InProxy(mask), OutProxy(hist), dims, histSize, ranges, uniform != 0, accumulate != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_calcBackProject(cv::Mat **images, int nimages,
                                    const int* channels, interop::InputArrayProxy hist, interop::OutputArrayProxy backProject, 
                                    const float** ranges, int uniform)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec(nimages);
        for (auto i = 0; i < nimages; i++)
            imagesVec[i] = *(images[i]);
        cv::calcBackProject(&imagesVec[0], nimages, channels, InProxy(hist), OutProxy(backProject), ranges, uniform != 0);
    });
}


CVAPI(ExceptionStatus) imgproc_compareHist(interop::InputArrayProxy h1, interop::InputArrayProxy h2, int method, double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::compareHist(InProxy(h1), InProxy(h2), method);
    });
}

CVAPI(ExceptionStatus) imgproc_equalizeHist(interop::InputArrayProxy src, interop::OutputArrayProxy dst)
{
    return cvTry([&] {
        cv::equalizeHist(InProxy(src), OutProxy(dst));
    });
}

CVAPI(ExceptionStatus) imgproc_EMD(interop::InputArrayProxy signature1, interop::InputArrayProxy signature2,
                         int distType, interop::InputArrayProxy cost, float* lowerBound, interop::OutputArrayProxy flow, float* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::EMD(InProxy(signature1), InProxy(signature2), distType, InProxy(cost), lowerBound, OutProxy(flow));
    });
}

CVAPI(ExceptionStatus) imgproc_watershed(interop::InputArrayProxy image, interop::InputOutputArrayProxy markers)
{
    return cvTry([&] {
        cv::watershed(InProxy(image), IoProxy(markers));
    });
}
CVAPI(ExceptionStatus) imgproc_pyrMeanShiftFiltering(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                          double sp, double sr, int maxLevel, interop::TermCriteria termCrit)
{
    return cvTry([&] {
        cv::pyrMeanShiftFiltering(InProxy(src), OutProxy(dst), sp, sr, maxLevel, cpp(termCrit));
    });
}
CVAPI(ExceptionStatus) imgproc_grabCut(interop::InputArrayProxy img, interop::InputOutputArrayProxy mask, interop::Rect rect,
                            interop::InputOutputArrayProxy bgdModel, interop::InputOutputArrayProxy fgdModel,
                            int iterCount, int mode)
{
    return cvTry([&] {
        cv::grabCut(InProxy(img), IoProxy(mask), cpp(rect), IoProxy(bgdModel), IoProxy(fgdModel), iterCount, mode);
    });
}

CVAPI(ExceptionStatus) imgproc_distanceTransformWithLabels(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                                interop::OutputArrayProxy labels, int distanceType, int maskSize,
                                                int labelType)
{
    return cvTry([&] {
        cv::distanceTransform(InProxy(src), OutProxy(dst), OutProxy(labels), distanceType, maskSize, labelType);
    });
}

CVAPI(ExceptionStatus) imgproc_distanceTransform(interop::InputArrayProxy src, interop::OutputArrayProxy dst,
                                      int distanceType, int maskSize, int dstType)
{
    return cvTry([&] {
        cv::distanceTransform(InProxy(src), OutProxy(dst), distanceType, maskSize, dstType);
    });
}

CVAPI(ExceptionStatus) imgproc_floodFill1(interop::InputOutputArrayProxy image,
                              interop::Point seedPoint, interop::Scalar newVal, interop::Rect *rect,
                              interop::Scalar loDiff, interop::Scalar upDiff, int flags, int *returnValue)
{
    return cvTry([&] {
        cv::Rect rect0;
        *returnValue = cv::floodFill(IoProxy(image), cpp(seedPoint), cpp(newVal), &rect0, cpp(loDiff), cpp(upDiff), flags);
        *rect = c(rect0);
    });
}
CVAPI(ExceptionStatus) imgproc_floodFill2(interop::InputOutputArrayProxy image, interop::InputOutputArrayProxy mask,
                              interop::Point seedPoint, interop::Scalar newVal, interop::Rect *rect,
                              interop::Scalar loDiff, interop::Scalar upDiff, int flags, int* returnValue)
{
    return cvTry([&] {
        cv::Rect rect0;
        *returnValue = cv::floodFill(IoProxy(image), IoProxy(mask), cpp(seedPoint), cpp(newVal), &rect0, cpp(loDiff), cpp(upDiff), flags);
        *rect = c(rect0);
    });
}

CVAPI(ExceptionStatus) imgproc_blendLinear(
    interop::InputArrayProxy src1, interop::InputArrayProxy src2, interop::InputArrayProxy weights1, interop::InputArrayProxy weights2, interop::OutputArrayProxy dst)
{
    return cvTry([&] {
        cv::blendLinear(InProxy(src1), InProxy(src2), InProxy(weights1), InProxy(weights2), OutProxy(dst));
    });
}

CVAPI(ExceptionStatus) imgproc_cvtColor(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int code, int dstCn, int hint)
{
    return cvTry([&] {
        cv::cvtColor(InProxy(src), OutProxy(dst), code, dstCn, static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_cvtColorTwoPlane(interop::InputArrayProxy src1, interop::InputArrayProxy src2, interop::OutputArrayProxy dst, int code, int hint)
{
    return cvTry([&] {
        cv::cvtColorTwoPlane(InProxy(src1), InProxy(src2), OutProxy(dst), code, static_cast<cv::AlgorithmHint>(hint));
    });
}

CVAPI(ExceptionStatus) imgproc_demosaicing(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int code, int dstCn)
{
    return cvTry([&] {
        cv::demosaicing(InProxy(src), OutProxy(dst), code, dstCn);
    });    
}

CVAPI(ExceptionStatus) imgproc_moments(interop::InputArrayProxy arr, int binaryImage, interop::Moments *returnValue)
{
    return cvTry([&] {
        const auto m = cv::moments(InProxy(arr), binaryImage != 0);
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
CVAPI(ExceptionStatus) imgproc_matchTemplate(interop::InputArrayProxy image, interop::InputArrayProxy templ,
                                  interop::OutputArrayProxy result, int method, interop::InputArrayProxy mask)
{
    return cvTry([&] {
        cv::matchTemplate(InProxy(image), InProxy(templ), OutProxy(result), method, InProxy(mask));
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithAlgorithm(
    interop::InputArrayProxy image, interop::OutputArrayProxy labels, int connectivity, int ltype, int ccltype, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::connectedComponents(InProxy(image), OutProxy(labels), connectivity, ltype, ccltype);
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponents(interop::InputArrayProxy image, interop::OutputArrayProxy labels,
                                       int connectivity, int ltype, int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::connectedComponents(InProxy(image), OutProxy(labels), connectivity, ltype);
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithStatsWithAlgorithm(
    interop::InputArrayProxy image, interop::OutputArrayProxy labels,
    interop::OutputArrayProxy stats, interop::OutputArrayProxy centroids,
    int connectivity, int ltype, int ccltype, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::connectedComponentsWithStats(
                InProxy(image), OutProxy(labels), OutProxy(stats), OutProxy(centroids), connectivity, ltype, ccltype);
    });
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithStats(interop::InputArrayProxy image, interop::OutputArrayProxy labels,
                                                interop::OutputArrayProxy stats, interop::OutputArrayProxy centroids, int connectivity, int ltype, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::connectedComponentsWithStats(
            InProxy(image), OutProxy(labels), OutProxy(stats), OutProxy(centroids), connectivity, ltype);
    });
}

CVAPI(ExceptionStatus) imgproc_findContours1_vector(interop::InputArrayProxy image, std::vector<std::vector<cv::Point> > *contours,
                                         std::vector<cv::Vec4i> *hierarchy, int mode, int method, interop::Point offset)
{
    return cvTry([&] {
        cv::findContours(InProxy(image), *contours, *hierarchy, mode, method, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_findContours1_OutputArray(interop::InputArrayProxy image, std::vector<cv::Mat> *contours,
                                              interop::OutputArrayProxy hierarchy, int mode, int method, interop::Point offset)
{
    return cvTry([&] {
        cv::findContours(InProxy(image), *contours, OutProxy(hierarchy), mode, method, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_findContours2_vector(interop::InputArrayProxy image, std::vector<std::vector<cv::Point> > *contours,
                                         int mode, int method, interop::Point offset)
{
    return cvTry([&] {
        cv::findContours(InProxy(image), *contours, mode, method, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_findContours2_OutputArray(interop::InputArrayProxy image, std::vector<cv::Mat> *contours,
                                              int mode, int method, interop::Point offset)
{
    return cvTry([&] {
        cv::findContours(InProxy(image), *contours, mode, method, cpp(offset));
    });
}

CVAPI(ExceptionStatus) imgproc_findContoursLinkRuns1(interop::InputArrayProxy image,
                                          std::vector<std::vector<cv::Point> > *contours, std::vector<cv::Vec4i> *hierarchy)
{
    return cvTry([&] {
        cv::findContoursLinkRuns(InProxy(image), *contours, *hierarchy);
    });
}
CVAPI(ExceptionStatus) imgproc_findContoursLinkRuns2(interop::InputArrayProxy image,
                                          std::vector<std::vector<cv::Point> > *contours)
{
    return cvTry([&] {
        cv::findContoursLinkRuns(InProxy(image), *contours);
    });
}

CVAPI(ExceptionStatus) imgproc_approxPolyDP_InputArray(interop::InputArrayProxy curve, interop::OutputArrayProxy approxCurve, double epsilon, int closed)
{
    return cvTry([&] {
        cv::approxPolyDP(InProxy(curve), OutProxy(approxCurve), epsilon, closed != 0);
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

CVAPI(ExceptionStatus) imgproc_arcLength_InputArray(interop::InputArrayProxy curve, int closed, double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::arcLength(InProxy(curve), closed != 0);
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

CVAPI(ExceptionStatus) imgproc_boundingRect_InputArray(interop::InputArrayProxy curve, interop::Rect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::boundingRect(InProxy(curve)));
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

CVAPI(ExceptionStatus) imgproc_contourArea_InputArray(interop::InputArrayProxy contour, int oriented, double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::contourArea(InProxy(contour), oriented != 0);
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

CVAPI(ExceptionStatus) imgproc_minAreaRect_InputArray(interop::InputArrayProxy points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::minAreaRect(InProxy(points)));
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

CVAPI(ExceptionStatus) imgproc_boxPoints_OutputArray(interop::RotatedRect box, interop::OutputArrayProxy points)
{
    return cvTry([&] {
        cv::boxPoints(cpp(box), OutProxy(points));
    });
}
CVAPI(ExceptionStatus) imgproc_boxPoints_Point2f(interop::RotatedRect box, cv::Point2f points[4])
{
    return cvTry([&] {
    cpp(box).points(points);
    });
}

CVAPI(ExceptionStatus) imgproc_minEnclosingCircle_InputArray(interop::InputArrayProxy points, interop::Point2f *center, float *radius)
{
    return cvTry([&] {
        cv::Point2f center0;
        float radius0;
        cv::minEnclosingCircle(InProxy(points), center0, radius0);
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

CVAPI(ExceptionStatus) imgproc_minEnclosingTriangle_InputOutputArray(interop::InputArrayProxy points, interop::OutputArrayProxy triangle, double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::minEnclosingTriangle(InProxy(points), OutProxy(triangle));
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
    interop::InputArrayProxy contour1, interop::InputArrayProxy contour2, int method, double parameter, double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::matchShapes(InProxy(contour1), InProxy(contour2), method, parameter);
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

CVAPI(ExceptionStatus) imgproc_convexHull_InputArray(interop::InputArrayProxy points, interop::OutputArrayProxy hull, int clockwise, int returnPoints)
{
    return cvTry([&] {
        cv::convexHull(InProxy(points), OutProxy(hull), clockwise != 0, returnPoints != 0);
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

CVAPI(ExceptionStatus) imgproc_convexityDefects_InputArray(interop::InputArrayProxy contour, interop::InputArrayProxy convexHull,
                                                interop::OutputArrayProxy convexityDefects)
{
    return cvTry([&] {
        cv::convexityDefects(InProxy(contour), InProxy(convexHull), OutProxy(convexityDefects));
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

CVAPI(ExceptionStatus) imgproc_isContourConvex_InputArray(interop::InputArrayProxy contour, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::isContourConvex(InProxy(contour)) ? 1 : 0;
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

CVAPI(ExceptionStatus) imgproc_intersectConvexConvex_InputArray(interop::InputArrayProxy p1, interop::InputArrayProxy p2,
                                                      interop::OutputArrayProxy p12, int handleNested, float* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::intersectConvexConvex(InProxy(p1), InProxy(p2), OutProxy(p12), handleNested != 0);
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

CVAPI(ExceptionStatus) imgproc_fitEllipse_InputArray(interop::InputArrayProxy points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::fitEllipse(InProxy(points)));
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

CVAPI(ExceptionStatus) imgproc_fitEllipseAMS_InputArray(interop::InputArrayProxy points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::fitEllipseAMS(InProxy(points)));
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

CVAPI(ExceptionStatus) imgproc_fitEllipseDirect_InputArray(interop::InputArrayProxy points, interop::RotatedRect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::fitEllipseDirect(InProxy(points)));
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

CVAPI(ExceptionStatus) imgproc_fitLine_InputArray(interop::InputArrayProxy points, interop::OutputArrayProxy line,
                                       int distType, double param, double reps, double aeps)
{
    return cvTry([&] {
        cv::fitLine(InProxy(points), OutProxy(line), distType, param, reps, aeps);
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
    interop::InputArrayProxy contour, interop::Point2f pt, int measureDist, double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::pointPolygonTest(InProxy(contour), cpp(pt), measureDist != 0);
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
    interop::RotatedRect rect1, interop::RotatedRect rect2, interop::OutputArrayProxy intersectingRegion, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), OutProxy(intersectingRegion));
    });
}
CVAPI(ExceptionStatus) imgproc_rotatedRectangleIntersection_vector(
    interop::RotatedRect rect1, interop::RotatedRect rect2, std::vector<cv::Point2f> *intersectingRegion, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), *intersectingRegion);
    });
}

CVAPI(ExceptionStatus) imgproc_applyColorMap1(interop::InputArrayProxy src, interop::OutputArrayProxy dst, int colorMap)
{
    return cvTry([&] {
        cv::applyColorMap(InProxy(src), OutProxy(dst), colorMap);
    });
}

CVAPI(ExceptionStatus) imgproc_applyColorMap2(interop::InputArrayProxy src, interop::OutputArrayProxy dst, interop::InputArrayProxy userColor)
{
    return cvTry([&] {
        cv::applyColorMap(InProxy(src), OutProxy(dst), InProxy(userColor));
    });    
}

#pragma region Drawing

CVAPI(ExceptionStatus) imgproc_line(
    interop::InputOutputArrayProxy img, interop::Point pt1, interop::Point pt2, interop::Scalar color,
    int thickness, int lineType, int shift)
{
    return cvTry([&] {
        cv::line(IoProxy(img), cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_arrowedLine(
    interop::InputOutputArrayProxy img, interop::Point pt1, interop::Point pt2, interop::Scalar color,
    int thickness, int line_type, int shift, double tipLength)
{
    return cvTry([&] {
        cv::arrowedLine(IoProxy(img), cpp(pt1), cpp(pt2), cpp(color), thickness, line_type, shift, tipLength);
    });
}


CVAPI(ExceptionStatus) imgproc_rectangle_InputOutputArray_Point(
    interop::InputOutputArrayProxy img, interop::Point pt1, interop::Point pt2,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
        cv::rectangle(IoProxy(img), cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_rectangle_InputOutputArray_Rect(
    interop::InputOutputArrayProxy img, interop::Rect rect,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
        cv::rectangle(IoProxy(img), cpp(rect), cpp(color), thickness, lineType, shift);
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
    interop::InputOutputArrayProxy img, interop::Point center, int radius,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
        cv::circle(IoProxy(img), cpp(center), radius, cpp(color), thickness, lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_ellipse1(
    interop::InputOutputArrayProxy img, interop::Point center, interop::Size axes,
    double angle, double startAngle, double endAngle,
    interop::Scalar color, int thickness, int lineType, int shift)
{
    return cvTry([&] {
        cv::ellipse(IoProxy(img), cpp(center), cpp(axes), angle, startAngle, endAngle, cpp(color), thickness, lineType, shift);
    });
}
CVAPI(ExceptionStatus) imgproc_ellipse2(
    interop::InputOutputArrayProxy img, interop::RotatedRect box, interop::Scalar color, int thickness, int lineType)
{
    return cvTry([&] {
        cv::ellipse(IoProxy(img), cpp(box), cpp(color), thickness, lineType);
    });
}

CVAPI(ExceptionStatus) imgproc_drawMarker(
    interop::InputOutputArrayProxy img, interop::Point position, interop::Scalar color,
    int markerType, int markerSize, int thickness, int lineType)
{
    return cvTry([&] {
        cv::drawMarker(IoProxy(img), cpp(position), cpp(color), markerType, markerSize, thickness, lineType);
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
    interop::InputOutputArrayProxy img, interop::InputArrayProxy points, interop::Scalar color, int lineType, int shift)
{
    return cvTry([&] {
        cv::fillConvexPoly(IoProxy(img), InProxy(points), cpp(color), lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_fillPoly_Mat(cv::Mat *img, const cv::Point **pts, const int *npts,
                                 int ncontours, interop::Scalar color, int lineType, int shift, interop::Point offset)
{
    return cvTry([&] {
    cv::fillPoly(*img, pts, npts, ncontours, cpp(color), lineType, shift, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_fillPoly_InputOutputArray(interop::InputOutputArrayProxy img, interop::InputArrayProxy pts,
                                              interop::Scalar color, int lineType, int shift, interop::Point offset)
{
    return cvTry([&] {
        cv::fillPoly(IoProxy(img), InProxy(pts), cpp(color), lineType, shift, cpp(offset));
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
    interop::InputOutputArrayProxy img, interop::InputArrayProxy pts, int isClosed, interop::Scalar color,
    int thickness, int lineType, int shift)
{
    return cvTry([&] {
        cv::polylines(IoProxy(img), InProxy(pts), isClosed != 0, cpp(color), thickness, lineType, shift);
    });
}

CVAPI(ExceptionStatus) imgproc_drawContours_vector(interop::InputOutputArrayProxy image,
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
            IoProxy(image), contoursVec, contourIdx, cpp(color), thickness, lineType, hierarchyVec, maxLevel, cpp(offset));
    });
}
CVAPI(ExceptionStatus) imgproc_drawContours_InputArray(interop::InputOutputArrayProxy image,
                                            cv::Mat **contours, int contoursLength,
                                            int contourIdx, interop::Scalar color, int thickness, int lineType,
                                            interop::InputArrayProxy hierarchy, int maxLevel, interop::Point offset)
{
    return cvTry([&] {
        std::vector<std::vector<cv::Point> > contoursVec(contoursLength);
        for (auto i = 0; i < contoursLength; i++)
            contoursVec[i] = *contours[i];
        cv::drawContours(
            IoProxy(image), contoursVec, contourIdx, cpp(color), thickness, lineType, InProxy(hierarchy), maxLevel, cpp(offset));
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

CVAPI(ExceptionStatus) imgproc_putText(interop::InputOutputArrayProxy img, const char *text, interop::Point org,
                         int fontFace, double fontScale, interop::Scalar color,
                         int thickness, int lineType, int bottomLeftOrigin)
{
    return cvTry([&] {
        cv::putText(IoProxy(img), text, cpp(org), fontFace, fontScale, cpp(color), thickness, lineType, bottomLeftOrigin != 0);
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
