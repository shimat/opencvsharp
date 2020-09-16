#ifndef CPP_IMGPROC_H
#define CPP_IMGPROC_H

#include "include_opencv.h"

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppParameterMayBeConst

CVAPI(ExceptionStatus) imgproc_getGaussianKernel(int ksize, double sigma, int ktype, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getGaussianKernel(ksize, sigma, ktype);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getDerivKernels(cv::_OutputArray *kx, cv::_OutputArray *ky,
    int dx, int dy, int ksize, int normalize, int ktype)
{
    BEGIN_WRAP
    cv::getDerivKernels(*kx, *ky, dx, dy, ksize, normalize != 0, ktype);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getGaborKernel(MyCvSize ksize, double sigma, double theta,
    double lambd, double gamma, double psi, int ktype, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getGaborKernel(cpp(ksize), sigma, theta, lambd, gamma, psi, ktype);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getStructuringElement(int shape, MyCvSize ksize, MyCvPoint anchor, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getStructuringElement(shape, cpp(ksize), cpp(anchor));
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_medianBlur(cv::_InputArray *src, cv::_OutputArray *dst, int ksize)
{
    BEGIN_WRAP
    cv::medianBlur(*src, *dst, ksize);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_GaussianBlur(cv::_InputArray *src, cv::_OutputArray *dst,
                                            MyCvSize ksize, double sigmaX, double sigmaY, int borderType)
{
    BEGIN_WRAP
    cv::GaussianBlur(*src, *dst, cpp(ksize), sigmaX, sigmaY, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_bilateralFilter(cv::_InputArray *src, cv::_OutputArray *dst,
                                    int d, double sigmaColor, double sigmaSpace, int borderType)
{
    BEGIN_WRAP
    cv::bilateralFilter(*src, *dst, d, sigmaColor, sigmaSpace, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_boxFilter(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                              MyCvSize ksize, MyCvPoint anchor, int normalize, int borderType)
{
    BEGIN_WRAP
    cv::boxFilter(*src, *dst, ddepth, cpp(ksize), cpp(anchor), normalize != 0, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_sqrBoxFilter(
    cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
    MyCvSize ksize, MyCvPoint anchor, int normalize, int borderType)
{
    BEGIN_WRAP
    cv::sqrBoxFilter(*src, *dst, ddepth, cpp(ksize), cpp(anchor), normalize != 0, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_blur(cv::_InputArray *src, cv::_OutputArray *dst, CvSize ksize, CvPoint anchor, int borderType)
{
    BEGIN_WRAP
    cv::blur(*src, *dst, ksize, anchor, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_filter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                             cv::_InputArray *kernel, MyCvPoint anchor, double delta, int borderType)
{
    BEGIN_WRAP
    cv::filter2D(*src, *dst, ddepth, *kernel, cpp(anchor), delta, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_sepFilter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                                cv::_InputArray *kernelX, cv::_InputArray *kernelY,
                                MyCvPoint anchor, double delta, int borderType)
{
    BEGIN_WRAP
    cv::sepFilter2D(*src, *dst, ddepth, *kernelX, *kernelY, cpp(anchor), delta, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Sobel(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                          int dx, int dy, int ksize, double scale, double delta, int borderType)
{
    BEGIN_WRAP
    cv::Sobel(*src, *dst, ddepth, dx, dy, ksize, scale, delta, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_spatialGradient(
    cv::_InputArray *src, cv::_OutputArray *dx, cv::_OutputArray *dy, int ksize, int borderType)
{
    BEGIN_WRAP
    cv::spatialGradient(*src, *dx, *dy, ksize, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Scharr(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                           int dx, int dy, double scale, double delta, int borderType)
{
    BEGIN_WRAP
    cv::Scharr(*src, *dst, ddepth, dx, dy, scale, delta, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Laplacian(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
                              int ksize, double scale, double delta, int borderType)
{
    BEGIN_WRAP
    cv::Laplacian(*src, *dst, ddepth, ksize, scale, delta, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Canny1(cv::_InputArray *src, cv::_OutputArray *edges,
                          double threshold1, double threshold2, int apertureSize, int L2gradient)
{
    BEGIN_WRAP
    cv::Canny(*src, *edges, threshold1, threshold2, apertureSize, L2gradient != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Canny2(
    cv::_InputArray *dx, cv::_InputArray *dy, cv::_OutputArray *edges,
    double threshold1, double threshold2, int L2gradient = false)
{
    BEGIN_WRAP
    cv::Canny(*dx, *dy, *edges, threshold1, threshold2, L2gradient != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_cornerMinEigenVal(cv::_InputArray *src, cv::_OutputArray *dst,
                                      int blockSize, int ksize, int borderType)
{
    BEGIN_WRAP
    cv::cornerMinEigenVal(*src, *dst, blockSize, ksize, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_cornerHarris(cv::_InputArray *src, cv::_OutputArray *dst,
                                 int blockSize, int ksize, double k, int borderType)
{
    BEGIN_WRAP
    cv::cornerHarris(*src, *dst, blockSize, ksize, k, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_cornerEigenValsAndVecs(cv::_InputArray *src, cv::_OutputArray *dst,
                                           int blockSize, int ksize, int borderType)
{
    BEGIN_WRAP
    cv::cornerEigenValsAndVecs(*src, *dst, blockSize, ksize, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_preCornerDetect(cv::_InputArray *src, cv::_OutputArray *dst, int ksize, int borderType)
{
    BEGIN_WRAP
    cv::preCornerDetect(*src, *dst, ksize, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_cornerSubPix(cv::_InputArray *image, std::vector<cv::Point2f> *corners,
                                 CvSize winSize, CvSize zeroZone, MyCvTermCriteria criteria)
{
    BEGIN_WRAP
    cv::cornerSubPix(*image, *corners, winSize, zeroZone, cpp(criteria));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_goodFeaturesToTrack(cv::_InputArray *src, std::vector<cv::Point2f> *corners,
                                        int maxCorners, double qualityLevel, double minDistance,
                                        cv::_InputArray *mask, int blockSize, int useHarrisDetector, double k)
{
    BEGIN_WRAP
    cv::goodFeaturesToTrack(*src, *corners, maxCorners, qualityLevel, minDistance, 
        entity(mask), blockSize, useHarrisDetector != 0, k);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_HoughLines(cv::_InputArray *src, std::vector<cv::Vec2f> *lines,
                               double rho, double theta, int threshold,
                               double srn, double stn)
{
    BEGIN_WRAP
    cv::HoughLines(*src, *lines, rho, theta, threshold, srn, stn);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_HoughLinesP(cv::_InputArray *src, std::vector<cv::Vec4i> *lines,
                                double rho, double theta, int threshold,
                                double minLineLength, double maxLineGap)
{
    BEGIN_WRAP
    cv::HoughLinesP(*src, *lines, rho, theta, threshold, minLineLength, maxLineGap);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_HoughLinesPointSet(
    cv::_InputArray *_point, cv::_OutputArray *_lines, int lines_max, int threshold,
    double min_rho, double max_rho, double rho_step,
    double min_theta, double max_theta, double theta_step)
{
    BEGIN_WRAP
    cv::HoughLinesPointSet(*_point, *_lines, lines_max, threshold, min_rho, max_rho, rho_step, min_theta, max_theta, theta_step);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_HoughCircles(cv::_InputArray *src, std::vector<cv::Vec3f> *circles,
                                 int method, double dp, double minDist,
                                 double param1, double param2, int minRadius, int maxRadius)
{
    BEGIN_WRAP
    cv::HoughCircles(*src, *circles, method, dp, minDist, param1, param2, minRadius, maxRadius);
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_erode(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *kernel,
                          MyCvPoint anchor, int iterations,    int borderType, MyCvScalar borderValue)
{
    BEGIN_WRAP
    cv::erode(*src, *dst, entity(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_dilate(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *kernel,
                           CvPoint anchor, int iterations, int borderType, CvScalar borderValue)
{
    BEGIN_WRAP
    cv::dilate(*src, *dst, entity(kernel), anchor, iterations, borderType, borderValue);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_morphologyEx(cv::_InputArray *src, cv::_OutputArray *dst, int op, cv::_InputArray *kernel,
                                 MyCvPoint anchor, int iterations, int borderType, MyCvScalar borderValue)
{
    BEGIN_WRAP
    cv::morphologyEx(*src, *dst, op, entity(kernel), cpp(anchor), iterations, borderType, cpp(borderValue));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_resize(cv::_InputArray* src, cv::_OutputArray* dst, MyCvSize dsize, double fx, double fy, int interpolation)
{
    BEGIN_WRAP
    cv::resize(*src, *dst, cpp(dsize), fx, fy, interpolation);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_warpAffine(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* M, MyCvSize dsize,
                                          int flags, int borderMode, MyCvScalar borderValue)
{
    BEGIN_WRAP
    cv::warpAffine(*src, *dst, *M, cpp(dsize), flags, borderMode, cpp(borderValue));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_warpPerspective_MisInputArray(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* m, MyCvSize dsize,
                                                             int flags, int borderMode, MyCvScalar borderValue)
{
    BEGIN_WRAP
    cv::warpPerspective(*src, *dst, *m, cpp(dsize), flags, borderMode, cpp(borderValue));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_warpPerspective_MisArray(cv::_InputArray* src, cv::_OutputArray* dst, float* m, int mRow, int mCol, MyCvSize dsize,
                                                        int flags, int borderMode, MyCvScalar borderValue)
{
    BEGIN_WRAP
    const cv::Mat mmat(mRow, mCol, CV_32FC1, m);
    cv::warpPerspective(*src, *dst, mmat, cpp(dsize), flags, borderMode, cpp(borderValue));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_remap(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* map1, cv::_InputArray* map2,
                                     int interpolation, int borderMode, MyCvScalar borderValue)
{
    BEGIN_WRAP
    cv::remap(*src, *dst, *map1, *map2, interpolation, borderMode, cpp(borderValue));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_convertMaps(cv::_InputArray* map1, cv::_InputArray* map2, cv::_OutputArray* dstmap1, cv::_OutputArray* dstmap2,
                                           int dstmap1type, int nnInterpolation)
{
    BEGIN_WRAP
    cv::convertMaps(*map1, *map2, *dstmap1, *dstmap2, dstmap1type, nnInterpolation != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getRotationMatrix2D(MyCvPoint2D32f center, double angle, double scale, cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getRotationMatrix2D(cpp(center), angle, scale);
    *returnValue = new cv::Mat(ret);
    END_WRAP

}
CVAPI(ExceptionStatus) imgproc_invertAffineTransform(cv::_InputArray* M, cv::_OutputArray *iM)
{
    BEGIN_WRAP
    cv::invertAffineTransform(*M, *iM);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getPerspectiveTransform1(cv::Point2f *src, cv::Point2f *dst, cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getPerspectiveTransform(src, dst);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_getPerspectiveTransform2(cv::_InputArray *src, cv::_InputArray *dst, cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getPerspectiveTransform(*src, *dst);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getAffineTransform1(cv::Point2f *src, cv::Point2f *dst, cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getAffineTransform(src, dst);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_getAffineTransform2(cv::_InputArray *src, cv::_InputArray *dst, cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::getAffineTransform(*src, *dst);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getRectSubPix(cv::_InputArray *image, MyCvSize patchSize, MyCvPoint2D32f center, cv::_OutputArray *patch, int patchType)
{
    BEGIN_WRAP
    cv::getRectSubPix(*image, cpp(patchSize), cpp(center), *patch, patchType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_logPolar(cv::_InputArray *src, cv::_OutputArray *dst,
                             MyCvPoint2D32f center, double M, int flags)
{
    BEGIN_WRAP
    cv::logPolar(*src, *dst, cpp(center), M, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_linearPolar(cv::_InputArray *src, cv::_OutputArray *dst,
                                MyCvPoint2D32f center, double maxRadius, int flags)
{
    BEGIN_WRAP
    cv::linearPolar(*src, *dst, cpp(center), maxRadius, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_warpPolar(
    cv::_InputArray *src, cv::_OutputArray *dst, MyCvSize dsize,
    MyCvPoint2D32f center, double maxRadius, int flags)
{
    BEGIN_WRAP
    cv::warpPolar(*src, *dst, cpp(dsize), cpp(center), maxRadius, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_integral1(cv::_InputArray *src, cv::_OutputArray *sum, int sdepth)
{
    BEGIN_WRAP
    cv::integral(*src, *sum, sdepth);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_integral2(cv::_InputArray *src, cv::_OutputArray *sum, cv::_OutputArray *sqsum, int sdepth)
{
    BEGIN_WRAP
    cv::integral(*src, *sum, *sqsum, sdepth);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_integral3(cv::_InputArray *src, cv::_OutputArray *sum, cv::_OutputArray *sqsum, cv::_OutputArray *tilted, int sdepth, int sqdepth)
{
    BEGIN_WRAP
    cv::integral(*src, *sum, *sqsum, *tilted, sdepth, sqdepth);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_accumulate(cv::_InputArray *src, cv::_InputOutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::accumulate(*src, *dst, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_accumulateSquare(cv::_InputArray* src, cv::_InputOutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::accumulateSquare(*src, *dst, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_accumulateProduct(cv::_InputArray *src1, cv::_InputArray *src2, cv::_InputOutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::accumulateProduct(*src1, *src2, *dst, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_accumulateWeighted(cv::_InputArray *src, cv::_InputOutputArray *dst, double alpha, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::accumulateWeighted(*src, *dst, alpha, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_phaseCorrelate(cv::_InputArray *src1, cv::_InputArray *src2,
                                              cv::_InputArray *window, double* response, MyCvPoint2D64f* returnValue)
{
    BEGIN_WRAP
    const auto p = cv::phaseCorrelate(*src1, *src2, *window, response);
    *returnValue = { p.x, p.y };
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_createHanningWindow(cv::_OutputArray *dst, MyCvSize winSize, int type)
{
    BEGIN_WRAP
    cv::createHanningWindow(*dst, cpp(winSize), type);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_threshold(cv::_InputArray *src, cv::_OutputArray *dst,
                                double thresh, double maxVal, int type, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::threshold(*src, *dst, thresh, maxVal, type);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_adaptiveThreshold(cv::_InputArray *src, cv::_OutputArray *dst,
                                      double maxValue, int adaptiveMethod,
                                      int thresholdType, int blockSize, double C)
{
    BEGIN_WRAP
    cv::adaptiveThreshold(*src, *dst, maxValue, adaptiveMethod, thresholdType, blockSize, C);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_pyrDown(cv::_InputArray *src, cv::_OutputArray *dst, MyCvSize dstSize, int borderType)
{
    BEGIN_WRAP
    cv::pyrDown(*src, *dst, cpp(dstSize), borderType);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_pyrUp(cv::_InputArray *src, cv::_OutputArray *dst, MyCvSize dstSize, int borderType)
{
    BEGIN_WRAP
    cv::pyrUp(*src, *dst, cpp(dstSize), borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_calcHist(cv::Mat **images, int nimages,
                              const int* channels, cv::_InputArray *mask,
                              cv::_OutputArray *hist, int dims, const int* histSize,
                              const float** ranges, int uniform, int accumulate)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec(nimages);
    for (auto i = 0; i < nimages; i++)
        imagesVec[i] = *(images[i]);
    cv::calcHist(&imagesVec[0], nimages, channels, entity(mask), *hist, dims, histSize, ranges, uniform != 0, accumulate != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_calcBackProject(cv::Mat **images, int nimages,
                                    const int* channels, cv::_InputArray *hist, cv::_OutputArray *backProject, 
                                    const float** ranges, int uniform)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec(nimages);
    for (auto i = 0; i < nimages; i++)
        imagesVec[i] = *(images[i]);
    cv::calcBackProject(&imagesVec[0], nimages, channels, *hist, *backProject, ranges, uniform != 0);
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_compareHist(cv::_InputArray *h1, cv::_InputArray *h2, int method, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::compareHist(*h1, *h2, method);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_equalizeHist(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::equalizeHist(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_EMD(cv::_InputArray *signature1, cv::_InputArray *signature2,
                         int distType, cv::_InputArray *cost, float* lowerBound, cv::_OutputArray *flow, float* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::EMD(*signature1, *signature2, distType, entity(cost), lowerBound, entity(flow));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_watershed(cv::_InputArray *image, cv::_InputOutputArray *markers)
{
    BEGIN_WRAP
    cv::watershed(*image, *markers);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_pyrMeanShiftFiltering(cv::_InputArray *src, cv::_InputOutputArray *dst,
                                          double sp, double sr, int maxLevel, MyCvTermCriteria termCrit)
{
    BEGIN_WRAP
    cv::pyrMeanShiftFiltering(*src, *dst, sp, sr, maxLevel, cpp(termCrit));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_grabCut(cv::_InputArray *img, cv::_InputOutputArray *mask, CvRect rect,
                            cv::_InputOutputArray *bgdModel, cv::_InputOutputArray *fgdModel,
                            int iterCount, int mode)
{
    BEGIN_WRAP
    cv::grabCut(*img, *mask, rect, *bgdModel, *fgdModel, iterCount, mode);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_distanceTransformWithLabels(cv::_InputArray *src, cv::_OutputArray *dst,
                                                cv::_OutputArray *labels, int distanceType, int maskSize,
                                                int labelType)
{
    BEGIN_WRAP
    cv::distanceTransform(*src, *dst, *labels, distanceType, maskSize, labelType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_distanceTransform(cv::_InputArray *src, cv::_OutputArray *dst,
                                      int distanceType, int maskSize, int dstType)
{
    BEGIN_WRAP
    cv::distanceTransform(*src, *dst, distanceType, maskSize, dstType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_floodFill1(cv::_InputOutputArray *image,
                              MyCvPoint seedPoint, MyCvScalar newVal, MyCvRect *rect,
                              MyCvScalar loDiff, MyCvScalar upDiff, int flags, int *returnValue)
{
    BEGIN_WRAP
    cv::Rect rect0;
    *returnValue = cv::floodFill(*image, cpp(seedPoint), cpp(newVal), &rect0, cpp(loDiff), cpp(upDiff), flags);
    *rect = c(rect0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_floodFill2(cv::_InputOutputArray *image, cv::_InputOutputArray *mask,
                              MyCvPoint seedPoint, MyCvScalar newVal, MyCvRect *rect,
                              MyCvScalar loDiff, MyCvScalar upDiff, int flags, int* returnValue)
{
    BEGIN_WRAP
    cv::Rect rect0;
    *returnValue = cv::floodFill(*image, *mask, cpp(seedPoint), cpp(newVal), &rect0, cpp(loDiff), cpp(upDiff), flags);
    *rect = c(rect0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_blendLinear(
    cv::_InputArray* src1, cv::_InputArray* src2, cv::_InputArray* weights1, cv::_InputArray* weights2, cv::_OutputArray* dst)
{
    BEGIN_WRAP
        cv::blendLinear(*src1, *src2, *weights1, *weights2, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_cvtColor(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dstCn)
{
    BEGIN_WRAP
    cv::cvtColor(*src, *dst, code, dstCn);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_cvtColorTwoPlane(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int code)
{
    BEGIN_WRAP
    cv::cvtColorTwoPlane(*src1, *src2, *dst, code);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_demosaicing(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dstCn)
{
    BEGIN_WRAP
    cv::demosaicing(*src, *dst, code, dstCn);
    END_WRAP    
}

CVAPI(ExceptionStatus) imgproc_moments(cv::_InputArray *arr, int binaryImage, MyCvMoments *returnValue)
{
    BEGIN_WRAP
    const auto m = cv::moments(*arr, binaryImage != 0);
    *returnValue = c(m);
    END_WRAP
}
/*
CVAPI(ExceptionStatus) imgproc_HuMoments(MyCvMoments *moments, double hu[7])
{
    BEGIN_WRAP
    cv::HuMoments(cpp(*moments), hu);
    END_WRAP
}
*/
CVAPI(ExceptionStatus) imgproc_matchTemplate(cv::_InputArray *image, cv::_InputArray *templ,
                                  cv::_OutputArray *result, int method, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::matchTemplate(*image, *templ, *result, method, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithAlgorithm(
    cv::_InputArray *image, cv::_OutputArray *labels, int connectivity, int ltype, int ccltype, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::connectedComponents(entity(image), entity(labels), connectivity, ltype, ccltype);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_connectedComponents(cv::_InputArray *image, cv::_OutputArray *labels,
                                       int connectivity, int ltype, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::connectedComponents(entity(image), entity(labels), connectivity, ltype);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithStatsWithAlgorithm(
    cv::_InputArray *image, cv::_OutputArray *labels,
    cv::_OutputArray *stats, cv::_OutputArray *centroids,
    int connectivity, int ltype, int ccltype, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::connectedComponentsWithStats(
            entity(image), entity(labels), entity(stats), entity(centroids), connectivity, ltype, ccltype);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_connectedComponentsWithStats(cv::_InputArray *image, cv::_OutputArray *labels,
                                                cv::_OutputArray *stats, cv::_OutputArray *centroids, int connectivity, int ltype, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::connectedComponentsWithStats(
        entity(image), entity(labels), entity(stats), entity(centroids), connectivity, ltype);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_findContours1_vector(cv::_InputArray *image, std::vector<std::vector<cv::Point> > **contours,
                                         std::vector<cv::Vec4i> **hierarchy, int mode, int method, MyCvPoint offset)
{
    BEGIN_WRAP
    *contours = new std::vector<std::vector<cv::Point> >;
    *hierarchy = new std::vector<cv::Vec4i>;
    cv::findContours(*image, **contours, **hierarchy, mode, method, cpp(offset));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_findContours1_OutputArray(cv::_InputArray *image, std::vector<cv::Mat> **contours,
                                              cv::_OutputArray *hierarchy, int mode, int method, MyCvPoint offset)
{
    BEGIN_WRAP
    *contours = new std::vector<cv::Mat>;
    cv::findContours(*image, **contours, *hierarchy, mode, method, cpp(offset));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_findContours2_vector(cv::_InputArray *image, std::vector<std::vector<cv::Point> > **contours,
                                         int mode, int method, MyCvPoint offset)
{
    BEGIN_WRAP
    *contours = new std::vector<std::vector<cv::Point> >;
    cv::findContours(*image, **contours, mode, method, cpp(offset));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_findContours2_OutputArray(cv::_InputArray *image, std::vector<cv::Mat> **contours,
                                              int mode, int method, MyCvPoint offset)
{
    BEGIN_WRAP
    *contours = new std::vector<cv::Mat>;
    cv::findContours(*image, **contours, mode, method, cpp(offset));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_approxPolyDP_InputArray(cv::_InputArray *curve, cv::_OutputArray *approxCurve, double epsilon, int closed)
{
    BEGIN_WRAP
    cv::approxPolyDP(*curve, *approxCurve, epsilon, closed != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_approxPolyDP_Point(cv::Point *curve, int curveLength, std::vector<cv::Point> **approxCurve, double epsilon, int closed)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
    *approxCurve = new std::vector<cv::Point>;
    cv::approxPolyDP(curveMat, **approxCurve, epsilon, closed != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_approxPolyDP_Point2f(cv::Point2f *curve, int curveLength, std::vector<cv::Point2f> **approxCurve, double epsilon, int closed)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
    *approxCurve = new std::vector<cv::Point2f>;
    cv::approxPolyDP(curveMat, **approxCurve, epsilon, closed != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_arcLength_InputArray(cv::_InputArray *curve, int closed, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::arcLength(*curve, closed != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_arcLength_Point(cv::Point *curve, int curveLength, int closed, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
    *returnValue = cv::arcLength(curveMat, closed != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_arcLength_Point2f(cv::Point2f *curve, int curveLength, int closed, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
    *returnValue = cv::arcLength(curveMat, closed != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_boundingRect_InputArray(cv::_InputArray *curve, MyCvRect* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::boundingRect(*curve));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_boundingRect_Point(cv::Point *curve, int curveLength, MyCvRect* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> curveMat(curveLength, 1, curve);
    *returnValue = c(cv::boundingRect(curveMat));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_boundingRect_Point2f(cv::Point2f *curve, int curveLength, MyCvRect* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> curveMat(curveLength, 1, curve);
    *returnValue = c(cv::boundingRect(curveMat));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_contourArea_InputArray(cv::_InputArray *contour, int oriented, double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::contourArea(*contour, oriented != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_contourArea_Point(cv::Point *contour, int contourLength, int oriented, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
    *returnValue = cv::contourArea(contourMat, oriented != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_contourArea_Point2f(cv::Point2f *contour, int contourLength, int oriented, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
    *returnValue = cv::contourArea(contourMat, oriented != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_minAreaRect_InputArray(cv::_InputArray *points, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::minAreaRect(*points));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_minAreaRect_Point(cv::Point *points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    *returnValue = c(cv::minAreaRect(pointsMat));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_minAreaRect_Point2f(cv::Point2f *points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    *returnValue = c(cv::minAreaRect(pointsMat));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_boxPoints_OutputArray(MyCvBox2D box, cv::_OutputArray* points)
{
    BEGIN_WRAP
    cv::boxPoints(cpp(box), *points);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_boxPoints_Point2f(MyCvBox2D box, cv::Point2f points[4])
{
    BEGIN_WRAP
    cpp(box).points(points);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_minEnclosingCircle_InputArray(cv::_InputArray *points, MyCvPoint2D32f *center, float *radius)
{
    BEGIN_WRAP
    cv::Point2f center0;
    float radius0;
    cv::minEnclosingCircle(*points, center0, radius0);
    *center = c(center0);
    *radius = radius0;
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_minEnclosingCircle_Point(cv::Point *points, int pointsLength, MyCvPoint2D32f*center, float *radius)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    cv::Point2f center0;
    float radius0;
    cv::minEnclosingCircle(pointsMat, center0, radius0);
    *center = c(center0);
    *radius = radius0;
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_minEnclosingCircle_Point2f(cv::Point2f *points, int pointsLength, MyCvPoint2D32f*center, float *radius)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    cv::Point2f center0;
    float radius0;
    cv::minEnclosingCircle(pointsMat, center0, radius0);
    *center = c(center0);
    *radius = radius0;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_minEnclosingTriangle_InputOutputArray(cv::_InputArray *points, cv::_OutputArray *triangle, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::minEnclosingTriangle(*points, *triangle);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_minEnclosingTriangle_Point(cv::Point* points, int pointsLength, std::vector<cv::Point2f>* triangle, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    *returnValue = cv::minEnclosingTriangle(pointsMat, *triangle);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_minEnclosingTriangle_Point2f(cv::Point2f* points, int pointsLength, std::vector<cv::Point2f>* triangle, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    *returnValue = cv::minEnclosingTriangle(pointsMat, *triangle);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_matchShapes_InputArray(
    cv::_InputArray *contour1, cv::_InputArray *contour2, int method, double parameter, double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::matchShapes(*contour1, *contour2, method, parameter);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_matchShapes_Point(
    cv::Point *contour1, int contour1Length, cv::Point *contour2, int contour2Length, int method, double parameter, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> contour1Mat(contour1Length, 1, contour1);
    const cv::Mat_<cv::Point> contour2Mat(contour2Length, 1, contour2);
    *returnValue = cv::matchShapes(contour1Mat, contour2Mat, method, parameter);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_convexHull_InputArray(cv::_InputArray *points, cv::_OutputArray *hull, int clockwise, int returnPoints)
{
    BEGIN_WRAP
    cv::convexHull(*points, *hull, clockwise != 0, returnPoints != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point_ReturnsPoints(cv::Point *points, int pointsLength, std::vector<cv::Point> *hull, int clockwise)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, true);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point2f_ReturnsPoints(cv::Point2f *points, int pointsLength, std::vector<cv::Point2f> *hull, int clockwise)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, true);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point_ReturnsIndices(cv::Point *points, int pointsLength, std::vector<int> *hull, int clockwise)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, false);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_convexHull_Point2f_ReturnsIndices(cv::Point2f *points, int pointsLength, std::vector<int> *hull, int clockwise)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsMat(pointsLength, 1, points);
    cv::convexHull(pointsMat, *hull, clockwise != 0, false);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_convexityDefects_InputArray(cv::_InputArray *contour, cv::_InputArray *convexHull,
                                                cv::_OutputArray *convexityDefects)
{
    BEGIN_WRAP
    cv::convexityDefects(*contour, *convexHull, *convexityDefects);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_convexityDefects_Point(cv::Point *contour, int contourLength, int *convexHull, int convexHullLength,
                                           std::vector<cv::Vec4i> *convexityDefects)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
    const cv::Mat_<int> convexHullMat(convexHullLength, 1,  convexHull);
    cv::convexityDefects(contourMat, convexHullMat, *convexityDefects);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_convexityDefects_Point2f(cv::Point2f *contour, int contourLength, int *convexHull, int convexHullLength,
                                             std::vector<cv::Vec4i> *convexityDefects)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
    const cv::Mat_<int> convexHullMat(convexHullLength, 1, convexHull);
    cv::convexityDefects(contourMat, convexHullMat, *convexityDefects);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_isContourConvex_InputArray(cv::_InputArray *contour, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::isContourConvex(*contour) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_isContourConvex_Point(cv::Point *contour, int contourLength, int* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> contourMat(contourLength, 1, contour);
    *returnValue = cv::isContourConvex(contourMat) ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_isContourConvex_Point2f(cv::Point2f *contour, int contourLength, int* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> contourMat(contourLength, 1, contour);
    *returnValue = cv::isContourConvex(contourMat) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_intersectConvexConvex_InputArray(cv::_InputArray *p1, cv::_InputArray *p2,
                                                      cv::_OutputArray *p12, int handleNested, float* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::intersectConvexConvex(*p1, *p2, *p12, handleNested != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_intersectConvexConvex_Point(cv::Point *p1, int p1Length, cv::Point *p2, int p2Length,
                                                 std::vector<cv::Point> **p12, int handleNested, float* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> p1Vec(p1Length, 1, p1);
    const cv::Mat_<cv::Point> p2Vec(p2Length, 1, p2);
    *p12 = new std::vector<cv::Point>;
    *returnValue = cv::intersectConvexConvex(p1Vec, p2Vec, **p12, handleNested != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_intersectConvexConvex_Point2f(cv::Point2f *p1, int p1Length, cv::Point2f *p2, int p2Length,
                                                   std::vector<cv::Point2f> **p12, int handleNested, float *returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> p1Vec(p1Length, 1, p1);
    const cv::Mat_<cv::Point2f> p2Vec(p2Length, 1, p2);
    *p12 = new std::vector<cv::Point2f>;
    *returnValue = cv::intersectConvexConvex(p1Vec, p2Vec, **p12, handleNested != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_fitEllipse_InputArray(cv::_InputArray *points, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::fitEllipse(*points));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitEllipse_Point(cv::Point *points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipse(pointsVec));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitEllipse_Point2f(cv::Point2f *points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipse(pointsVec));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_fitEllipseAMS(cv::_InputArray *points, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::fitEllipseAMS(*points));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitEllipseAMS_Point(cv::Point* points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseAMS(pointsVec));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitEllipseAMS_Point2f(cv::Point2f* points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseAMS(pointsVec));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_fitEllipseDirect(cv::_InputArray* points, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::fitEllipseDirect(*points));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitEllipseDirect_Point(cv::Point* points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseDirect(pointsVec));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitEllipseDirect_Point2f(cv::Point2f* points, int pointsLength, MyCvBox2D* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    *returnValue = c(cv::fitEllipseDirect(pointsVec));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_fitLine_InputArray(cv::_InputArray *points, cv::_OutputArray *line,
                                       int distType, double param, double reps, double aeps)
{
    BEGIN_WRAP
    cv::fitLine(*points, *line, distType, param, reps, aeps);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point(cv::Point *points, int pointsLength, float *line, int distType,
                                  double param, double reps, double aeps)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(4, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point2f(cv::Point2f *points, int pointsLength, float *line, int distType,
                                    double param, double reps, double aeps)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(4, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point3i(cv::Point3i *points, int pointsLength, float *line, int distType,
                                    double param, double reps, double aeps)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point3i> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(6, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fitLine_Point3f(cv::Point3f *points, int pointsLength, float *line, int distType,
                                    double param, double reps, double aeps)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point3f> pointsVec(pointsLength, 1, points);
    cv::Mat_<float> lineVec(6, 1, line);
    cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_pointPolygonTest_InputArray(
    cv::_InputArray* contour, MyCvPoint2D32f pt, int measureDist, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::pointPolygonTest(*contour, cpp(pt), measureDist != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_pointPolygonTest_Point(
    cv::Point *contour, int contourLength, MyCvPoint2D32f pt, int measureDist, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point> contourVec(contourLength, 1, contour);
    *returnValue = cv::pointPolygonTest(contourVec, cpp(pt), measureDist != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_pointPolygonTest_Point2f(
    cv::Point2f *contour, int contourLength, MyCvPoint2D32f pt, int measureDist, double* returnValue)
{
    BEGIN_WRAP
    const cv::Mat_<cv::Point2f> contourVec(contourLength, 1, contour);
    *returnValue = cv::pointPolygonTest(contourVec, cpp(pt), measureDist != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_rotatedRectangleIntersection_OutputArray(
    MyCvBox2D rect1, MyCvBox2D rect2, cv::_OutputArray *intersectingRegion, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), *intersectingRegion);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_rotatedRectangleIntersection_vector(
    MyCvBox2D rect1, MyCvBox2D rect2, std::vector<cv::Point2f> *intersectingRegion, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::rotatedRectangleIntersection(cpp(rect1), cpp(rect2), *intersectingRegion);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_applyColorMap1(cv::_InputArray *src, cv::_OutputArray *dst, int colorMap)
{
    BEGIN_WRAP
    cv::applyColorMap(*src, *dst, colorMap);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_applyColorMap2(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *userColor)
{
    BEGIN_WRAP
    cv::applyColorMap(*src, *dst, *userColor);
    END_WRAP    
}

#pragma region Drawing

CVAPI(ExceptionStatus) imgproc_line(
    cv::_InputOutputArray *img, MyCvPoint pt1, MyCvPoint pt2, MyCvScalar color,
    int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::line(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_arrowedLine(
    cv::_InputOutputArray *img, MyCvPoint pt1, MyCvPoint pt2, MyCvScalar color,
    int thickness, int line_type, int shift, double tipLength)
{
    BEGIN_WRAP
    cv::arrowedLine(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, line_type, shift, tipLength);
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_rectangle_InputOutputArray_Point(
    cv::_InputOutputArray *img, MyCvPoint pt1, MyCvPoint pt2,
    MyCvScalar color, int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::rectangle(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_rectangle_InputOutputArray_Rect(
    cv::_InputOutputArray* img, MyCvRect rect,
    MyCvScalar color, int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::rectangle(*img, cpp(rect), cpp(color), thickness, lineType, shift);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_rectangle_Mat_Point(
    cv::Mat* img, MyCvPoint pt1, MyCvPoint pt2,
    MyCvScalar color, int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::rectangle(*img, cpp(pt1), cpp(pt2), cpp(color), thickness, lineType, shift);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_rectangle_Mat_Rect(
    cv::Mat *img, MyCvRect rect,
    MyCvScalar color, int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::rectangle(*img, cpp(rect), cpp(color), thickness, lineType, shift);
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_circle(
    cv::_InputOutputArray *img, MyCvPoint center, int radius,
    MyCvScalar color, int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::circle(*img, cpp(center), radius, cpp(color), thickness, lineType, shift);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_ellipse1(
    cv::_InputOutputArray *img, MyCvPoint center, MyCvSize axes,
    double angle, double startAngle, double endAngle,
    MyCvScalar color, int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::ellipse(*img, cpp(center), cpp(axes), angle, startAngle, endAngle, cpp(color), thickness, lineType, shift);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_ellipse2(
    cv::_InputOutputArray *img, MyCvBox2D box, MyCvScalar color, int thickness, int lineType)
{
    BEGIN_WRAP
    cv::ellipse(*img, cpp(box), cpp(color), thickness, lineType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_drawMarker(
    cv::_InputOutputArray *img, MyCvPoint position, MyCvScalar color,
    int markerType, int markerSize, int thickness, int lineType)
{
    BEGIN_WRAP
    cv::drawMarker(*img, cpp(position), cpp(color), markerType, markerSize, thickness, lineType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_fillConvexPoly_Mat(
    cv::Mat *img, cv::Point *pts, int npts, MyCvScalar color, int lineType, int shift)
{
    BEGIN_WRAP
    cv::fillConvexPoly(*img, pts, npts, cpp(color), lineType, shift);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fillConvexPoly_InputOutputArray(
    cv::_InputOutputArray *img, cv::_InputArray *points, MyCvScalar color, int lineType, int shift)
{
    BEGIN_WRAP
    cv::fillConvexPoly(*img, *points, cpp(color), lineType, shift);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_fillPoly_Mat(cv::Mat *img, const cv::Point **pts, const int *npts,
                                 int ncontours, MyCvScalar color, int lineType, int shift, MyCvPoint offset)
{
    BEGIN_WRAP
    cv::fillPoly(*img, pts, npts, ncontours, cpp(color), lineType, shift, cpp(offset));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_fillPoly_InputOutputArray(cv::_InputOutputArray *img, cv::_InputArray *pts,
                                              MyCvScalar color, int lineType, int shift, MyCvPoint offset)
{
    BEGIN_WRAP
    cv::fillPoly(*img, *pts, cpp(color), lineType, shift, cpp(offset));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_polylines_Mat(
    cv::Mat *img, const cv::Point **pts, const int *npts,
    int ncontours, int isClosed, MyCvScalar color,
    int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::polylines(
        *img, pts, npts, ncontours, isClosed != 0, cpp(color), thickness, lineType, shift);
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_polylines_InputOutputArray(
    cv::_InputOutputArray *img, cv::_InputArray *pts, int isClosed, MyCvScalar color,
    int thickness, int lineType, int shift)
{
    BEGIN_WRAP
    cv::polylines(*img, *pts, isClosed != 0, cpp(color), thickness, lineType, shift);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_drawContours_vector(cv::_InputOutputArray *image,
                                        cv::Point **contours, int contoursSize1, int *contoursSize2,
                                        int contourIdx, MyCvScalar color, int thickness, int lineType,
                                        cv::Vec4i *hierarchy, int hiearchyLength, int maxLevel, MyCvPoint offset)
{
    BEGIN_WRAP
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
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_drawContours_InputArray(cv::_InputOutputArray *image,
                                            cv::Mat **contours, int contoursLength,
                                            int contourIdx, MyCvScalar color, int thickness, int lineType,
                                            cv::_InputArray *hierarchy, int maxLevel, MyCvPoint offset)
{
    BEGIN_WRAP
    std::vector<std::vector<cv::Point> > contoursVec(contoursLength);
    for (auto i = 0; i < contoursLength; i++)
        contoursVec[i] = *contours[i];
    cv::drawContours(
        *image, contoursVec, contourIdx, cpp(color), thickness, lineType, entity(hierarchy), maxLevel, cpp(offset));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_clipLine1(MyCvSize imgSize, MyCvPoint *pt1, MyCvPoint *pt2, int* returnValue)
{
    BEGIN_WRAP
    auto pt1c = cpp(*pt1), pt2c = cpp(*pt2);
    const auto result = cv::clipLine(cpp(imgSize), pt1c, pt2c);
    *pt1 = c(pt1c);
    *pt2 = c(pt2c);
    *returnValue = result ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_clipLine2(MyCvRect imgRect, MyCvPoint *pt1, MyCvPoint *pt2, int* returnValue)
{
    BEGIN_WRAP
    auto pt1c = cpp(*pt1), pt2c = cpp(*pt2);
    const auto result = cv::clipLine(cpp(imgRect), pt1c, pt2c);
    *pt1 = c(pt1c);
    *pt2 = c(pt2c);
    *returnValue = result ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_ellipse2Poly_int(
    MyCvPoint center, MyCvSize axes, int angle, int arcStart, int arcEnd,
    int delta, std::vector<cv::Point>* pts)
{
    BEGIN_WRAP
    cv::ellipse2Poly(cpp(center), cpp(axes), angle, arcStart, arcEnd, delta, *pts);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_ellipse2Poly_double(
    MyCvPoint2D64f center, MyCvSize2D64f axes, int angle, int arcStart, int arcEnd,
    int delta, std::vector<cv::Point2d>* pts)
{
    BEGIN_WRAP
    cv::ellipse2Poly(cpp(center), cpp(axes), angle, arcStart, arcEnd, delta, *pts);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_putText(cv::_InputOutputArray *img, const char *text, MyCvPoint org,
                         int fontFace, double fontScale, MyCvScalar color,
                         int thickness, int lineType, int bottomLeftOrigin)
{
    BEGIN_WRAP
    cv::putText(*img, text, cpp(org), fontFace, fontScale, cpp(color), thickness, lineType, bottomLeftOrigin != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getTextSize(const char *text, int fontFace,
                                 double fontScale, int thickness, int *baseLine, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::getTextSize(text, fontFace, fontScale, thickness, baseLine));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getFontScaleFromHeight(
    int fontFace, int pixelHeight, int thickness, double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getFontScaleFromHeight(fontFace, pixelHeight, thickness);
    END_WRAP
}

#pragma endregion

#endif