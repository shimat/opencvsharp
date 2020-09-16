#ifndef _CPP_CORE_H_
#define _CPP_CORE_H_

#include "include_opencv.h"

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#pragma region core.hpp

CVAPI(ExceptionStatus) core_borderInterpolate(int p, int len, int borderType, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::borderInterpolate(p, len, borderType);
    END_WRAP
}

CVAPI(ExceptionStatus) core_copyMakeBorder(
    cv::_InputArray* src, cv::_OutputArray* dst, int top, int bottom, int left, int right, int borderType, MyCvScalar value)
{
    BEGIN_WRAP
    cv::copyMakeBorder(*src, *dst, top, bottom, left, right, borderType, cpp(value));
    END_WRAP
}

CVAPI(ExceptionStatus) core_add(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    BEGIN_WRAP
    cv::add(*src1, *src2, *dst, entity(mask), dtype);
    END_WRAP
}

CVAPI(ExceptionStatus) core_subtract_InputArray2(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    BEGIN_WRAP
    cv::subtract(*src1, *src2, *dst, entity(mask), dtype);
    END_WRAP
}
CVAPI(ExceptionStatus) core_subtract_InputArrayScalar(
    cv::_InputArray *src1, MyCvScalar src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    BEGIN_WRAP
    cv::subtract(*src1, cpp(src2), *dst, entity(mask), dtype);
    END_WRAP
}
CVAPI(ExceptionStatus) core_subtract_ScalarInputArray(
    MyCvScalar src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    BEGIN_WRAP
    cv::subtract(cpp(src1), *src2, *dst, entity(mask), dtype);
    END_WRAP
}

CVAPI(ExceptionStatus) core_multiply(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, double scale, int dtype)
{
    BEGIN_WRAP
    cv::multiply(*src1, *src2, *dst, scale, dtype);
    END_WRAP
}
CVAPI(ExceptionStatus) core_divide1(
    double scale, cv::_InputArray *src2, cv::_OutputArray *dst, int dtype)
{
    BEGIN_WRAP
    cv::divide(scale, *src2, *dst, dtype);
    END_WRAP
}
CVAPI(ExceptionStatus) core_divide2(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, double scale, int dtype)
{
    BEGIN_WRAP
    cv::divide(*src1, *src2, *dst, scale, dtype);
    END_WRAP
}

CVAPI(ExceptionStatus) core_scaleAdd(cv::_InputArray *src1, double alpha, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::scaleAdd(*src1, alpha, *src2, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_addWeighted(cv::_InputArray *src1, double alpha, cv::_InputArray *src2,
                             double beta, double gamma, cv::_OutputArray *dst, int dtype)
{
    BEGIN_WRAP
    cv::addWeighted(*src1, alpha, *src2, beta, gamma, *dst, dtype);
    END_WRAP
}

CVAPI(ExceptionStatus) core_convertScaleAbs(cv::_InputArray* src, cv::_OutputArray* dst, double alpha, double beta)
{
    BEGIN_WRAP
    cv::convertScaleAbs(*src, *dst, alpha, beta);
    END_WRAP
}

CVAPI(ExceptionStatus) core_convertFp16(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::convertFp16(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LUT(cv::_InputArray* src, cv::_InputArray* lut, cv::_OutputArray* dst)
{
    BEGIN_WRAP
    cv::LUT(*src, *lut, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_sum(cv::_InputArray* src, MyCvScalar* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::sum(*src));
    END_WRAP
}

CVAPI(ExceptionStatus) core_countNonZero(cv::_InputArray* src, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::countNonZero(*src);
    END_WRAP
}

CVAPI(ExceptionStatus) core_findNonZero(cv::_InputArray* src, cv::_OutputArray* idx)
{
    BEGIN_WRAP
    cv::findNonZero(*src, *idx);
    END_WRAP
}

CVAPI(ExceptionStatus) core_mean(cv::_InputArray* src, cv::_InputArray* mask, MyCvScalar* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::mean(*src, entity(mask)));
    END_WRAP
}

CVAPI(ExceptionStatus) core_meanStdDev_OutputArray(
    cv::_InputArray* src, cv::_OutputArray* mean, cv::_OutputArray* stddev, cv::_InputArray* mask)
{
    BEGIN_WRAP
    cv::meanStdDev(*src, *mean, *stddev, entity(mask));
    END_WRAP
}
CVAPI(ExceptionStatus) core_meanStdDev_Scalar(
    cv::_InputArray* src, MyCvScalar* mean, MyCvScalar* stddev, cv::_InputArray* mask)
{
    BEGIN_WRAP
    cv::Scalar mean0, stddev0;
    cv::meanStdDev(*src, mean0, stddev0, entity(mask));
    *mean = c(mean0);
    *stddev = c(stddev0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_norm1(cv::_InputArray* src1, int normType, cv::_InputArray* mask, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::norm(*src1, normType, entity(mask));
    END_WRAP
}
CVAPI(ExceptionStatus) core_norm2(cv::_InputArray* src1, cv::_InputArray* src2,
    int normType, cv::_InputArray* mask, double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::norm(*src1, *src2, normType, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_PSNR(cv::_InputArray* src1, cv::_InputArray* src2, double R, double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::PSNR(*src1, *src2, R);
    END_WRAP
}

CVAPI(ExceptionStatus) core_batchDistance(
    cv::_InputArray* src1, cv::_InputArray* src2,
    cv::_OutputArray* dist, int dtype, cv::_OutputArray* nidx,
    int normType, int K, cv::_InputArray* mask,
    int update, int crosscheck)
{
    BEGIN_WRAP
    cv::batchDistance(
        *src1, *src2, *dist, dtype, *nidx, normType, K, entity(mask), update, crosscheck != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_normalize(
    cv::_InputArray* src, cv::_InputOutputArray* dst, double alpha, double beta, int normType, int dtype, cv::_InputArray* mask)
{
    BEGIN_WRAP
    cv::InputArray maskVal = entity(mask);
    cv::normalize(*src, *dst, alpha, beta, normType, dtype, maskVal);
    END_WRAP
}

CVAPI(ExceptionStatus) core_minMaxLoc1(cv::_InputArray* src, double* minVal, double* maxVal)
{
    BEGIN_WRAP
    cv::minMaxLoc(*src, minVal, maxVal);
    END_WRAP
}
CVAPI(ExceptionStatus) core_minMaxLoc2(cv::_InputArray* src, double* minVal, double* maxVal,
    MyCvPoint* minLoc, MyCvPoint* maxLoc, cv::_InputArray* mask)
{
    BEGIN_WRAP
    cv::InputArray maskVal = entity(mask);
    cv::Point minLoc0, maxLoc0;
    cv::minMaxLoc(*src, minVal, maxVal, &minLoc0, &maxLoc0, maskVal);
    *minLoc = c(minLoc0);
    *maxLoc = c(maxLoc0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_minMaxIdx1(cv::_InputArray* src, double* minVal, double* maxVal)
{
    BEGIN_WRAP
    cv::minMaxIdx(*src, minVal, maxVal);
    END_WRAP
}
CVAPI(ExceptionStatus) core_minMaxIdx2(cv::_InputArray* src, double* minVal, double* maxVal,
    int* minIdx, int* maxIdx, cv::_InputArray* mask)
{
    BEGIN_WRAP
    cv::InputArray maskVal = entity(mask);
    cv::minMaxIdx(*src, minVal, maxVal, minIdx, maxIdx, maskVal);
    END_WRAP
}

CVAPI(ExceptionStatus) core_reduce(cv::_InputArray* src, cv::_OutputArray* dst, int dim, int rtype, int dtype)
{
    BEGIN_WRAP
    cv::reduce(*src, *dst, dim, rtype, dtype);
    END_WRAP
}

CVAPI(ExceptionStatus) core_merge(cv::Mat** mv, uint32_t count, cv::Mat* dst)
{
    BEGIN_WRAP
    std::vector<cv::Mat> vec(static_cast<size_t>(count));
    for (uint32_t i = 0; i < count; i++)
        vec[i] = *mv[i];

    cv::merge(vec, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_split(cv::Mat* src, std::vector<cv::Mat>* mv)
{
    BEGIN_WRAP
    cv::split(*src, *mv);
    END_WRAP
}

CVAPI(ExceptionStatus) core_mixChannels(cv::Mat** src, uint32_t nsrcs, cv::Mat** dst, uint32_t ndsts, int* fromTo, uint32_t npairs)
{
    BEGIN_WRAP
    std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrcs));
    std::vector<cv::Mat> dstVec(static_cast<size_t>(ndsts));
    for (uint32_t i = 0; i < nsrcs; i++)
        srcVec[i] = *(src[i]);
    for (uint32_t i = 0; i < ndsts; i++)
        dstVec[i] = *(dst[i]);

    cv::mixChannels(srcVec, dstVec, fromTo, npairs);
    END_WRAP
}

CVAPI(ExceptionStatus) core_extractChannel(cv::_InputArray* src, cv::_OutputArray* dst, int coi)
{
    BEGIN_WRAP
    cv::extractChannel(*src, *dst, coi);
    END_WRAP
}

CVAPI(ExceptionStatus) core_insertChannel(cv::_InputArray* src, cv::_InputOutputArray* dst, int coi)
{
    BEGIN_WRAP
    cv::insertChannel(*src, *dst, coi);
    END_WRAP
}

CVAPI(ExceptionStatus) core_flip(cv::_InputArray* src, cv::_OutputArray* dst, int flipCode)
{
    BEGIN_WRAP
    cv::flip(*src, *dst, flipCode);
    END_WRAP
}

CVAPI(ExceptionStatus) core_rotate(cv::_InputArray *src, cv::_OutputArray *dst, int rotateCode)
{
    BEGIN_WRAP
    cv::rotate(*src, *dst, rotateCode);
    END_WRAP
}

CVAPI(ExceptionStatus) core_repeat1(cv::_InputArray* src, int ny, int nx, cv::_OutputArray* dst)
{
    BEGIN_WRAP
    cv::repeat(*src, ny, nx, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_repeat2(cv::Mat* src, int ny, int nx, cv::Mat** returnValue)
{
    BEGIN_WRAP
    cv::Mat ret = cv::repeat(*src, ny, nx);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_hconcat1(cv::Mat** src, uint32_t nsrc, cv::_OutputArray* dst)
{
    BEGIN_WRAP
    std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrc));
    for (uint32_t i = 0; i < nsrc; i++)
        srcVec[i] = *(src[i]);
    cv::hconcat(&srcVec[0], nsrc, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_hconcat2(cv::_InputArray* src1, cv::_InputArray* src2, cv::_OutputArray* dst)
{
    BEGIN_WRAP
    cv::hconcat(*src1, *src2, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_vconcat1(cv::Mat** src, uint32_t nsrc, cv::_OutputArray* dst)
{
    BEGIN_WRAP
    std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrc));
    for (uint32_t i = 0; i < nsrc; i++)
        srcVec[i] = *(src[i]);
    cv::vconcat(&srcVec[0], nsrc, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_vconcat2(cv::_InputArray* src1, cv::_InputArray* src2, cv::_OutputArray* dst)
{
    BEGIN_WRAP
    cv::vconcat(*src1, *src2, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_bitwise_and(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::bitwise_and(*src1, *src2, *dst, entity(mask));
    END_WRAP
}
CVAPI(ExceptionStatus) core_bitwise_or(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::bitwise_or(*src1, *src2, *dst, entity(mask));
    END_WRAP
}
CVAPI(ExceptionStatus) core_bitwise_xor(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::bitwise_xor(*src1, *src2, *dst, entity(mask));
    END_WRAP
}
CVAPI(ExceptionStatus) core_bitwise_not(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::bitwise_not(*src, *dst, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_absdiff(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::absdiff(*src1, *src2, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_copyTo(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::copyTo(*src, *dst, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_inRange_InputArray(
    cv::_InputArray *src, cv::_InputArray *lowerb, cv::_InputArray *upperb, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::inRange(*src, *lowerb, *upperb, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_inRange_Scalar(
    cv::_InputArray *src, MyCvScalar lowerb, MyCvScalar upperb, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::inRange(*src, cpp(lowerb), cpp(upperb), *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_compare(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int cmpop)
{
    BEGIN_WRAP
    cv::compare(*src1, *src2, *dst, cmpop);
    END_WRAP
}

CVAPI(ExceptionStatus) core_min1(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::min(*src1, *src2, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_min_MatMat(cv::Mat* src1, cv::Mat* src2, cv::Mat* dst)
{
    BEGIN_WRAP
    cv::min(*src1, *src2, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_min_MatDouble(cv::Mat* src1, double src2, cv::Mat* dst)
{
    BEGIN_WRAP
    cv::min(*src1, src2, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_max1(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::max(*src1, *src2, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_max_MatMat(cv::Mat *src1, const cv::Mat *src2, cv::Mat *dst)
{
    BEGIN_WRAP
    cv::max(*src1, *src2, *dst);
    END_WRAP
}
CVAPI(ExceptionStatus) core_max_MatDouble(cv::Mat *src1, double src2, cv::Mat *dst)
{
    BEGIN_WRAP
    cv::max(*src1, src2, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_sqrt(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::sqrt(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_pow_Mat(cv::_InputArray *src, double power, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::pow(*src, power, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_exp_Mat(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::exp(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_log_Mat(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::log(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_polarToCart(cv::_InputArray* magnitude, cv::_InputArray* angle,
    cv::_OutputArray* x, cv::_OutputArray* y, int angleInDegrees)
{
    BEGIN_WRAP
    cv::polarToCart(*magnitude, *angle, *x, *y, angleInDegrees != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_cartToPolar(cv::_InputArray* x, cv::_InputArray* y,
    cv::_OutputArray* magnitude, cv::_OutputArray* angle, int angleInDegrees)
{
    BEGIN_WRAP
    cv::cartToPolar(*x, *y, *magnitude, *angle, angleInDegrees != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_phase(cv::_InputArray* x, cv::_InputArray* y, cv::_OutputArray* angle, int angleInDegrees)
{
    BEGIN_WRAP
    cv::phase(*x, *y, *angle, angleInDegrees != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_magnitude_Mat(cv::_InputArray* x, cv::_InputArray* y, cv::_OutputArray* magnitude)
{
    BEGIN_WRAP
    cv::magnitude(*x, *y, *magnitude);
    END_WRAP
}

CVAPI(ExceptionStatus) core_checkRange(cv::_InputArray* a, int quiet, MyCvPoint* pos, double minVal, double maxVal, int* returnValue)
{
    BEGIN_WRAP
    cv::Point pos0;
    *returnValue = cv::checkRange(*a, quiet != 0, &pos0, minVal, maxVal);
    *pos = c(pos0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_patchNaNs(cv::_InputOutputArray *a, double val)
{
    BEGIN_WRAP
    cv::patchNaNs(*a, val);
    END_WRAP
}

CVAPI(ExceptionStatus) core_gemm(cv::_InputArray *src1, cv::_InputArray *src2, double alpha,
                      cv::_InputArray *src3, double gamma, cv::_OutputArray *dst, int flags)
{
    BEGIN_WRAP
    cv::gemm(*src1, *src2, alpha, *src3, gamma, *dst, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_mulTransposed(cv::_InputArray *src, cv::_OutputArray *dst, int aTa,
                               cv::_InputArray *delta, double scale, int dtype)
{
    BEGIN_WRAP
    cv::mulTransposed(*src, *dst, aTa != 0, entity(delta), scale, dtype);
    END_WRAP
}

CVAPI(ExceptionStatus) core_transpose(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::transpose(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_transform(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *m)
{
    BEGIN_WRAP
    cv::transform(*src, *dst, *m);
    END_WRAP
}

CVAPI(ExceptionStatus) core_perspectiveTransform(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *m)
{
    BEGIN_WRAP
    cv::perspectiveTransform(*src, *dst, *m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Mat(cv::Mat *src, cv::Mat *dst, cv::Mat *m)
{
    BEGIN_WRAP
    cv::perspectiveTransform(*src, *dst, *m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point2f(cv::Point2f *src, int srcLength, cv::Point2f *dst, int dstLength, cv::_InputArray *m)
{
    BEGIN_WRAP
    std::vector<cv::Point2f> srcVector(src, src + srcLength);
    std::vector<cv::Point2f> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point2d(cv::Point2d *src, int srcLength, cv::Point2d *dst, int dstLength, cv::_InputArray *m)
{
    BEGIN_WRAP
    std::vector<cv::Point2d> srcVector(src, src + srcLength);
    std::vector<cv::Point2d> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point3f(cv::Point3f *src, int srcLength, cv::Point3f *dst, int dstLength, cv::_InputArray *m)
{
    BEGIN_WRAP
    std::vector<cv::Point3f> srcVector(src, src + srcLength);
    std::vector<cv::Point3f> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point3d(cv::Point3d *src, int srcLength, cv::Point3d *dst, int dstLength, cv::_InputArray *m)
{
    BEGIN_WRAP
    std::vector<cv::Point3d> srcVector(src, src + srcLength);
    std::vector<cv::Point3d> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    END_WRAP
}

CVAPI(ExceptionStatus) core_completeSymm(cv::_InputOutputArray *mtx, int lowerToUpper)
{
    BEGIN_WRAP
    cv::completeSymm(*mtx, lowerToUpper != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_setIdentity(cv::_InputOutputArray *mtx, MyCvScalar s)
{
    BEGIN_WRAP
    cv::setIdentity(*mtx, cpp(s));
    END_WRAP
}

CVAPI(ExceptionStatus) core_determinant(cv::_InputArray *mtx, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::determinant(*mtx);
    END_WRAP
}

CVAPI(ExceptionStatus) core_trace(cv::_InputArray *mtx, MyCvScalar *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::trace(*mtx));
    END_WRAP
}

CVAPI(ExceptionStatus) core_invert(cv::_InputArray *src, cv::_OutputArray *dst, int flags, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::invert(*src, *dst, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_solve(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int flags, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::solve(*src1, *src2, *dst, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_solveLP(cv::_InputArray *Func, cv::_InputArray *Constr, cv::_OutputArray *z, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::solveLP(*Func, *Constr, *z);
    END_WRAP
}

CVAPI(ExceptionStatus) core_sort(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    BEGIN_WRAP
    cv::sort(*src, *dst, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_sortIdx(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    BEGIN_WRAP
    cv::sortIdx(*src, *dst, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_solveCubic(cv::_InputArray *coeffs, cv::_OutputArray *roots, int *returnValue)
{
    BEGIN_WRAP
    *returnValue =  cv::solveCubic(*coeffs, *roots);
    END_WRAP
}

CVAPI(ExceptionStatus) core_solvePoly(cv::_InputArray *coeffs, cv::_OutputArray *roots, int maxIters, double *returnValue)
{
    BEGIN_WRAP
    *returnValue =  cv::solvePoly(*coeffs, *roots, maxIters);
    END_WRAP
}

CVAPI(ExceptionStatus) core_eigen(cv::_InputArray *src, cv::_OutputArray *eigenvalues,    cv::_OutputArray *eigenvectors, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::eigen(*src, *eigenvalues, *eigenvectors) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_eigenNonSymmetric(
    cv::_InputArray *src,  cv::_OutputArray *eigenvalues, cv::_OutputArray *eigenvectors)
{
    BEGIN_WRAP
    cv::eigenNonSymmetric(*src, *eigenvalues, *eigenvectors);
    END_WRAP
}

CVAPI(ExceptionStatus) core_calcCovarMatrix_Mat(cv::Mat **samples, int nsamples, cv::Mat *covar, 
                                     cv::Mat *mean, int flags, int ctype)
{
    BEGIN_WRAP
    std::vector<cv::Mat> samplesVec(nsamples);
    for (int i = 0; i < nsamples; i++)    
        samplesVec[i] = *samples[i];
    
    cv::calcCovarMatrix(&samplesVec[0], nsamples, *covar, *mean, flags, ctype);
    END_WRAP
}
CVAPI(ExceptionStatus) core_calcCovarMatrix_InputArray(cv::_InputArray *samples, cv::_OutputArray *covar, 
                                            cv::_InputOutputArray *mean, int flags, int ctype)
{
    BEGIN_WRAP
    cv::calcCovarMatrix(*samples, *covar, *mean, flags, ctype);
    END_WRAP
}

CVAPI(ExceptionStatus) core_PCACompute(cv::_InputArray *data, cv::_InputOutputArray *mean,
                            cv::_OutputArray *eigenvectors, int maxComponents)
{
    BEGIN_WRAP
    cv::PCACompute(*data, *mean, *eigenvectors, maxComponents);
    END_WRAP
}
CVAPI(ExceptionStatus) core_PCACompute2(cv::_InputArray *data, cv::_InputOutputArray *mean,
                            cv::_OutputArray *eigenvectors, cv::_OutputArray *eigenvalues, int maxComponents)
{
    BEGIN_WRAP
    cv::PCACompute(*data, *mean, *eigenvectors, *eigenvalues, maxComponents);
    END_WRAP
}

CVAPI(ExceptionStatus) core_PCAComputeVar(cv::_InputArray *data, cv::_InputOutputArray *mean,
                               cv::_OutputArray *eigenvectors, double retainedVariance)
{
    BEGIN_WRAP
    cv::PCACompute(*data, *mean, *eigenvectors, retainedVariance);
    END_WRAP
}
CVAPI(ExceptionStatus) core_PCAComputeVar2(cv::_InputArray *data, cv::_InputOutputArray *mean,
                               cv::_OutputArray *eigenvectors, cv::_OutputArray *eigenvalues, double retainedVariance)
{
    BEGIN_WRAP
    cv::PCACompute(*data, *mean, *eigenvectors, *eigenvalues, retainedVariance);
    END_WRAP
}

CVAPI(ExceptionStatus) core_PCAProject(cv::_InputArray *data, cv::_InputArray *mean,
                            cv::_InputArray *eigenvectors, cv::_OutputArray *result)
{
    BEGIN_WRAP
    cv::PCAProject(*data, *mean, *eigenvectors, *result);
    END_WRAP
}
CVAPI(ExceptionStatus) core_PCABackProject(cv::_InputArray *data, cv::_InputArray *mean,
                                cv::_InputArray *eigenvectors, cv::_OutputArray *result)
{
    BEGIN_WRAP
    cv::PCABackProject(*data, *mean, *eigenvectors, *result);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SVDecomp(cv::_InputArray *src, cv::_OutputArray *w,
                          cv::_OutputArray *u, cv::_OutputArray *vt, int flags)
{
    BEGIN_WRAP
    cv::SVDecomp(*src, *w, *u, *vt, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SVBackSubst(cv::_InputArray *w, cv::_InputArray *u, cv::_InputArray *vt,
                             cv::_InputArray *rhs, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::SVBackSubst(*w, *u, *vt, *rhs, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mahalanobis(cv::_InputArray *v1, cv::_InputArray *v2, cv::_InputArray *icovar, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::Mahalanobis(*v1, *v2, *icovar);
    END_WRAP
}

CVAPI(ExceptionStatus) core_dft(cv::_InputArray *src, cv::_OutputArray *dst, int flags, int nonzeroRows)
{
    BEGIN_WRAP
    cv::dft(*src, *dst, flags, nonzeroRows);
    END_WRAP
}

CVAPI(ExceptionStatus) core_idft(cv::_InputArray *src, cv::_OutputArray *dst, int flags, int nonzeroRows)
{
    BEGIN_WRAP
    cv::idft(*src, *dst, flags, nonzeroRows);
    END_WRAP
}

CVAPI(ExceptionStatus) core_dct(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    BEGIN_WRAP
    cv::dct(*src, *dst, flags); 
    END_WRAP
}

CVAPI(ExceptionStatus) core_idct(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    BEGIN_WRAP
    cv::idct(*src, *dst, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_mulSpectrums(cv::_InputArray *a, cv::_InputArray *b, cv::_OutputArray *c, int flags, int conjB)
{
    BEGIN_WRAP
    cv::mulSpectrums(*a, *b, *c, flags, conjB != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_getOptimalDFTSize(int vecsize, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getOptimalDFTSize(vecsize);
    END_WRAP
}

CVAPI(ExceptionStatus) core_theRNG_get(uint64 *returnValue)
{
    BEGIN_WRAP
    cv::RNG &rng = cv::theRNG();
    *returnValue = rng.state;
    END_WRAP
}

CVAPI(ExceptionStatus) core_theRNG_set(uint64 value)
{
    BEGIN_WRAP
    cv::theRNG().state = value;
    END_WRAP
}

CVAPI(ExceptionStatus) core_randu_InputArray(cv::_InputOutputArray *dst, cv::_InputArray *low, cv::_InputArray *high)
{
    BEGIN_WRAP
    cv::randu(*dst, *low, *high);
    END_WRAP
}
CVAPI(ExceptionStatus) core_randu_Scalar(cv::_InputOutputArray *dst, MyCvScalar low, MyCvScalar high)
{
    BEGIN_WRAP
    cv::randu(*dst, cpp(low), cpp(high));
    END_WRAP
}

CVAPI(ExceptionStatus) core_randn_InputArray(cv::_InputOutputArray *dst, cv::_InputArray *mean, cv::_InputArray *stddev)
{
    BEGIN_WRAP
    cv::randn(*dst, *mean, *stddev);
    END_WRAP
}
CVAPI(ExceptionStatus) core_randn_Scalar(cv::_InputOutputArray *dst, MyCvScalar mean, MyCvScalar stddev)
{
    BEGIN_WRAP
    cv::randn(*dst, cpp(mean), cpp(stddev));
    END_WRAP
}

CVAPI(ExceptionStatus) core_randShuffle(cv::_InputOutputArray *dst, double iterFactor, uint64 *rng)
{
    BEGIN_WRAP
    cv::RNG rng0;
    cv::randShuffle(*dst, iterFactor, &rng0);
    *rng = rng0.state;
    END_WRAP
}

CVAPI(ExceptionStatus) core_kmeans(
    cv::_InputArray *data, int k, cv::_InputOutputArray *bestLabels,
    MyCvTermCriteria criteria, int attempts, int flags, cv::_OutputArray *centers, 
    double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::kmeans(*data, k, *bestLabels, cpp(criteria), attempts, flags, entity(centers));
    END_WRAP
}

#pragma endregion

#pragma region base.hpp

CVAPI(ExceptionStatus) core_cubeRoot(float val, float* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cubeRoot(val);
    END_WRAP
}
CVAPI(ExceptionStatus) core_fastAtan2(float y, float x, float* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::fastAtan2(y, x);
    END_WRAP
}

#pragma endregion

#pragma region utility.hpp

CVAPI(int) core_setBreakOnError(int flag)
{
    return cv::setBreakOnError(flag != 0) ? 1 : 0;
}

CVAPI(cv::ErrorCallback) redirectError(cv::ErrorCallback errCallback, void* userdata, void** prevUserdata)
{
    return cv::redirectError(errCallback, userdata, prevUserdata);
}

CVAPI(ExceptionStatus) core_glob(const char *pattern, std::vector<std::string> *result, int recursive)
{
    BEGIN_WRAP
    cv::glob(pattern, *result, recursive != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_setNumThreads(int nthreads)
{
    BEGIN_WRAP
    cv::setNumThreads(nthreads);
    END_WRAP
}

CVAPI(ExceptionStatus) core_getNumThreads(int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getNumThreads();
    END_WRAP
}
CVAPI(ExceptionStatus) core_getThreadNum(int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getThreadNum();
    END_WRAP
}

CVAPI(ExceptionStatus) core_getBuildInformation(std::string *buf)
{
    BEGIN_WRAP
    const auto& str = cv::getBuildInformation();
    buf->assign(str);
    END_WRAP
}

CVAPI(ExceptionStatus) core_getVersionString(char *buf, int bufLength)
{
    BEGIN_WRAP
    const auto& str = cv::getVersionString();
    copyString(str, buf, bufLength);
    END_WRAP
}

CVAPI(ExceptionStatus) core_getVersionMajor(int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getVersionMajor();
    END_WRAP
}

CVAPI(ExceptionStatus) core_getVersionMinor(int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getVersionMinor();
    END_WRAP
}

CVAPI(ExceptionStatus) core_getVersionRevision(int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getVersionRevision();
    END_WRAP
}

CVAPI(ExceptionStatus) core_getTickCount(int64* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getTickCount();
    END_WRAP
}

CVAPI(ExceptionStatus) core_getTickFrequency(double* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getTickFrequency();
    END_WRAP
}

CVAPI(ExceptionStatus) core_getCPUTickCount(int64* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getCPUTickCount();
    END_WRAP
}

CVAPI(ExceptionStatus) core_checkHardwareSupport(int feature, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::checkHardwareSupport(feature) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_getHardwareFeatureName(int feature, std::string *buf)
{
    BEGIN_WRAP
    const auto& str = cv::getHardwareFeatureName(feature);
    buf->assign(str);
    END_WRAP
}

CVAPI(ExceptionStatus) core_getCPUFeaturesLine(std::string *buf)
{
    BEGIN_WRAP
    const auto& str = cv::getCPUFeaturesLine();
    buf->assign(str);
    END_WRAP
}

CVAPI(ExceptionStatus) core_getNumberOfCPUs(int* returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getNumberOfCPUs();
    END_WRAP
}

/*
CVAPI(void*) core_fastMalloc(size_t bufSize)
{
    return cv::fastMalloc(bufSize);
}
CVAPI(void) core_fastFree(void *ptr)
{
    return cv::fastFree(ptr);
}
*/

CVAPI(ExceptionStatus) core_setUseOptimized(int onoff)
{
    BEGIN_WRAP
    cv::setUseOptimized(onoff != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) core_useOptimized(int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::useOptimized() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_format(cv::_InputArray *mtx, int fmt, std::string *buf)
{
    BEGIN_WRAP
    const auto formatted = cv::format(*mtx, static_cast<cv::Formatter::FormatType>(fmt));

    std::stringstream s;
    s << formatted;
    buf->assign(s.str());
    END_WRAP
}

#pragma endregion

#pragma region RNG

CVAPI(ExceptionStatus) core_RNG_fill(uint64 *state, cv::_InputOutputArray *mat, int distType, cv::_InputArray *a, cv::_InputArray *b, int saturateRange)
{
    BEGIN_WRAP
    cv::RNG rng(*state);
    rng.fill(*mat, distType, *a, *b, saturateRange != 0);
    *state = rng.state;
    END_WRAP
}

CVAPI(ExceptionStatus) core_RNG_gaussian(uint64 *state, double sigma, double *returnValue)
{
    BEGIN_WRAP
    cv::RNG rng(*state);
    *returnValue = rng.gaussian(sigma);
    *state = rng.state;
    END_WRAP
}

#pragma endregion


#endif