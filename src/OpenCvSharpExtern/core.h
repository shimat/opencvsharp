#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#pragma region core.hpp


CVAPI(interop::RotatedRect) core_RotatedRect_byThreeVertexPoints(
    interop::Point2f p1, interop::Point2f p2, interop::Point2f p3)
{
    return c(
        cv::RotatedRect(cpp(p1), cpp(p2), cpp(p3)));
}

CVAPI(ExceptionStatus) core_borderInterpolate(int p, int len, int borderType, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::borderInterpolate(p, len, borderType);
    });
}

CVAPI(ExceptionStatus) core_copyMakeBorder(
    cv::_InputArray* src, cv::_OutputArray* dst, int top, int bottom, int left, int right, int borderType, interop::Scalar value)
{
    return cvTry([&] {
    cv::copyMakeBorder(*src, *dst, top, bottom, left, right, borderType, cpp(value));
    });
}

CVAPI(ExceptionStatus) core_add(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    return cvTry([&] {
    cv::add(*src1, *src2, *dst, entity(mask), dtype);
    });
}

CVAPI(ExceptionStatus) core_subtract_InputArray2(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    return cvTry([&] {
    cv::subtract(*src1, *src2, *dst, entity(mask), dtype);
    });
}
CVAPI(ExceptionStatus) core_subtract_InputArrayScalar(
    cv::_InputArray *src1, interop::Scalar src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    return cvTry([&] {
    cv::subtract(*src1, cpp(src2), *dst, entity(mask), dtype);
    });
}
CVAPI(ExceptionStatus) core_subtract_ScalarInputArray(
    interop::Scalar src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype)
{
    return cvTry([&] {
    cv::subtract(cpp(src1), *src2, *dst, entity(mask), dtype);
    });
}

CVAPI(ExceptionStatus) core_multiply(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, double scale, int dtype)
{
    return cvTry([&] {
    cv::multiply(*src1, *src2, *dst, scale, dtype);
    });
}
CVAPI(ExceptionStatus) core_divide1(
    double scale, cv::_InputArray *src2, cv::_OutputArray *dst, int dtype)
{
    return cvTry([&] {
    cv::divide(scale, *src2, *dst, dtype);
    });
}
CVAPI(ExceptionStatus) core_divide2(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, double scale, int dtype)
{
    return cvTry([&] {
    cv::divide(*src1, *src2, *dst, scale, dtype);
    });
}

CVAPI(ExceptionStatus) core_scaleAdd(cv::_InputArray *src1, double alpha, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::scaleAdd(*src1, alpha, *src2, *dst);
    });
}
CVAPI(ExceptionStatus) core_addWeighted(cv::_InputArray *src1, double alpha, cv::_InputArray *src2,
                             double beta, double gamma, cv::_OutputArray *dst, int dtype)
{
    return cvTry([&] {
    cv::addWeighted(*src1, alpha, *src2, beta, gamma, *dst, dtype);
    });
}

CVAPI(ExceptionStatus) core_convertScaleAbs(cv::_InputArray* src, cv::_OutputArray* dst, double alpha, double beta)
{
    return cvTry([&] {
    cv::convertScaleAbs(*src, *dst, alpha, beta);
    });
}

CVAPI(ExceptionStatus) core_LUT(cv::_InputArray* src, cv::_InputArray* lut, cv::_OutputArray* dst)
{
    return cvTry([&] {
    cv::LUT(*src, *lut, *dst);
    });
}

CVAPI(ExceptionStatus) core_sum(cv::_InputArray* src, interop::Scalar* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::sum(*src));
    });
}

CVAPI(ExceptionStatus) core_countNonZero(cv::_InputArray* src, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::countNonZero(*src);
    });
}

CVAPI(ExceptionStatus) core_findNonZero(cv::_InputArray* src, cv::_OutputArray* idx)
{
    return cvTry([&] {
    cv::findNonZero(*src, *idx);
    });
}

CVAPI(ExceptionStatus) core_mean(cv::_InputArray* src, cv::_InputArray* mask, interop::Scalar* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::mean(*src, entity(mask)));
    });
}

CVAPI(ExceptionStatus) core_meanStdDev_OutputArray(
    cv::_InputArray* src, cv::_OutputArray* mean, cv::_OutputArray* stddev, cv::_InputArray* mask)
{
    return cvTry([&] {
    cv::meanStdDev(*src, *mean, *stddev, entity(mask));
    });
}
CVAPI(ExceptionStatus) core_meanStdDev_Scalar(
    cv::_InputArray* src, interop::Scalar* mean, interop::Scalar* stddev, cv::_InputArray* mask)
{
    return cvTry([&] {
    cv::Scalar mean0, stddev0;
    cv::meanStdDev(*src, mean0, stddev0, entity(mask));
    *mean = c(mean0);
    *stddev = c(stddev0);
    });
}

CVAPI(ExceptionStatus) core_norm1(
    cv::_InputArray* src1, int normType, cv::_InputArray* mask, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::norm(*src1, normType, entity(mask));
    });
}
CVAPI(ExceptionStatus) core_norm2(
    cv::_InputArray* src1, cv::_InputArray* src2,
    int normType, cv::_InputArray* mask, double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::norm(*src1, *src2, normType, entity(mask));
    });
}

CVAPI(ExceptionStatus) core_PSNR(cv::_InputArray* src1, cv::_InputArray* src2, double R, double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::PSNR(*src1, *src2, R);
    });
}

CVAPI(ExceptionStatus) core_batchDistance(
    cv::_InputArray* src1, cv::_InputArray* src2,
    cv::_OutputArray* dist, int dtype, cv::_OutputArray* nidx,
    int normType, int K, cv::_InputArray* mask,
    int update, int crosscheck)
{
    return cvTry([&] {
    cv::batchDistance(
        *src1, *src2, *dist, dtype, *nidx, normType, K, entity(mask), update, crosscheck != 0);
    });
}

CVAPI(ExceptionStatus) core_normalize(
    cv::_InputArray* src, cv::_InputOutputArray* dst, double alpha, double beta, int normType, int dtype, cv::_InputArray* mask)
{
    return cvTry([&] {
    cv::InputArray maskVal = entity(mask);
    cv::normalize(*src, *dst, alpha, beta, normType, dtype, maskVal);
    });
}

CVAPI(ExceptionStatus) core_reduceArgMax(cv::_InputArray* src, cv::_OutputArray* dst, int axis, bool lastIndex)
{
    return cvTry([&] {
    cv::reduceArgMax(*src, *dst, axis, lastIndex);
    });
}

CVAPI(ExceptionStatus) core_reduceArgMin(cv::_InputArray* src, cv::_OutputArray* dst, int axis, bool lastIndex)
{
    return cvTry([&] {
    cv::reduceArgMin(*src, *dst, axis, lastIndex);
    });
}

CVAPI(ExceptionStatus) core_minMaxLoc1(cv::_InputArray* src, double* minVal, double* maxVal)
{
    return cvTry([&] {
    cv::minMaxLoc(*src, minVal, maxVal);
    });
}
CVAPI(ExceptionStatus) core_minMaxLoc2(cv::_InputArray* src, double* minVal, double* maxVal,
    interop::Point* minLoc, interop::Point* maxLoc, cv::_InputArray* mask)
{
    return cvTry([&] {
    cv::InputArray maskVal = entity(mask);
    cv::Point minLoc0, maxLoc0;
    cv::minMaxLoc(*src, minVal, maxVal, &minLoc0, &maxLoc0, maskVal);
    *minLoc = c(minLoc0);
    *maxLoc = c(maxLoc0);
    });
}

CVAPI(ExceptionStatus) core_minMaxIdx1(cv::_InputArray* src, double* minVal, double* maxVal)
{
    return cvTry([&] {
    cv::minMaxIdx(*src, minVal, maxVal);
    });
}
CVAPI(ExceptionStatus) core_minMaxIdx2(cv::_InputArray* src, double* minVal, double* maxVal,
    int* minIdx, int* maxIdx, cv::_InputArray* mask)
{
    return cvTry([&] {
    cv::InputArray maskVal = entity(mask);
    cv::minMaxIdx(*src, minVal, maxVal, minIdx, maxIdx, maskVal);
    });
}

CVAPI(ExceptionStatus) core_reduce(cv::_InputArray* src, cv::_OutputArray* dst, int dim, int rtype, int dtype)
{
    return cvTry([&] {
    cv::reduce(*src, *dst, dim, rtype, dtype);
    });
}

CVAPI(ExceptionStatus) core_merge(cv::Mat** mv, uint32_t count, cv::Mat* dst)
{
    return cvTry([&] {
    std::vector<cv::Mat> vec(static_cast<size_t>(count));
    for (uint32_t i = 0; i < count; i++)
        vec[i] = *mv[i];

    cv::merge(vec, *dst);
    });
}

CVAPI(ExceptionStatus) core_split(cv::Mat* src, std::vector<cv::Mat>* mv)
{
    return cvTry([&] {
    cv::split(*src, *mv);
    });
}

CVAPI(ExceptionStatus) core_mixChannels(cv::Mat** src, uint32_t nsrcs, cv::Mat** dst, uint32_t ndsts, int* fromTo, uint32_t npairs)
{
    return cvTry([&] {
    std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrcs));
    std::vector<cv::Mat> dstVec(static_cast<size_t>(ndsts));
    for (uint32_t i = 0; i < nsrcs; i++)
        srcVec[i] = *(src[i]);
    for (uint32_t i = 0; i < ndsts; i++)
        dstVec[i] = *(dst[i]);

    cv::mixChannels(srcVec, dstVec, fromTo, npairs);
    });
}

CVAPI(ExceptionStatus) core_extractChannel(cv::_InputArray* src, cv::_OutputArray* dst, int coi)
{
    return cvTry([&] {
    cv::extractChannel(*src, *dst, coi);
    });
}

CVAPI(ExceptionStatus) core_insertChannel(cv::_InputArray* src, cv::_InputOutputArray* dst, int coi)
{
    return cvTry([&] {
    cv::insertChannel(*src, *dst, coi);
    });
}

CVAPI(ExceptionStatus) core_flip(cv::_InputArray* src, cv::_OutputArray* dst, int flipCode)
{
    return cvTry([&] {
    cv::flip(*src, *dst, flipCode);
    });
}

CVAPI(ExceptionStatus) core_rotate(cv::_InputArray *src, cv::_OutputArray *dst, int rotateCode)
{
    return cvTry([&] {
    cv::rotate(*src, *dst, rotateCode);
    });
}

CVAPI(ExceptionStatus) core_repeat1(cv::_InputArray* src, int ny, int nx, cv::_OutputArray* dst)
{
    return cvTry([&] {
    cv::repeat(*src, ny, nx, *dst);
    });
}
CVAPI(ExceptionStatus) core_repeat2(cv::Mat* src, int ny, int nx, cv::Mat** returnValue)
{
    return cvTry([&] {
    const cv::Mat ret = cv::repeat(*src, ny, nx);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_hconcat1(cv::Mat** src, uint32_t nsrc, cv::_OutputArray* dst)
{
    return cvTry([&] {
    std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrc));
    for (uint32_t i = 0; i < nsrc; i++)
        srcVec[i] = *(src[i]);
    cv::hconcat(&srcVec[0], nsrc, *dst);
    });
}
CVAPI(ExceptionStatus) core_hconcat2(cv::_InputArray* src1, cv::_InputArray* src2, cv::_OutputArray* dst)
{
    return cvTry([&] {
    cv::hconcat(*src1, *src2, *dst);
    });
}

CVAPI(ExceptionStatus) core_vconcat1(cv::Mat** src, uint32_t nsrc, cv::_OutputArray* dst)
{
    return cvTry([&] {
    std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrc));
    for (uint32_t i = 0; i < nsrc; i++)
        srcVec[i] = *(src[i]);
    cv::vconcat(&srcVec[0], nsrc, *dst);
    });
}
CVAPI(ExceptionStatus) core_vconcat2(cv::_InputArray* src1, cv::_InputArray* src2, cv::_OutputArray* dst)
{
    return cvTry([&] {
    cv::vconcat(*src1, *src2, *dst);
    });
}

CVAPI(ExceptionStatus) core_bitwise_and(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::bitwise_and(*src1, *src2, *dst, entity(mask));
    });
}
CVAPI(ExceptionStatus) core_bitwise_or(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::bitwise_or(*src1, *src2, *dst, entity(mask));
    });
}
CVAPI(ExceptionStatus) core_bitwise_xor(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::bitwise_xor(*src1, *src2, *dst, entity(mask));
    });
}
CVAPI(ExceptionStatus) core_bitwise_not(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::bitwise_not(*src, *dst, entity(mask));
    });
}

CVAPI(ExceptionStatus) core_absdiff(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::absdiff(*src1, *src2, *dst);
    });
}

CVAPI(ExceptionStatus) core_copyTo(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::copyTo(*src, *dst, entity(mask));
    });
}

CVAPI(ExceptionStatus) core_inRange_InputArray(
    cv::_InputArray *src, cv::_InputArray *lowerb, cv::_InputArray *upperb, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::inRange(*src, *lowerb, *upperb, *dst);
    });
}
CVAPI(ExceptionStatus) core_inRange_Scalar(
    cv::_InputArray *src, interop::Scalar lowerb, interop::Scalar upperb, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::inRange(*src, cpp(lowerb), cpp(upperb), *dst);
    });
}

CVAPI(ExceptionStatus) core_compare(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int cmpop)
{
    return cvTry([&] {
    cv::compare(*src1, *src2, *dst, cmpop);
    });
}

CVAPI(ExceptionStatus) core_min1(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::min(*src1, *src2, *dst);
    });
}
CVAPI(ExceptionStatus) core_min_MatMat(cv::Mat* src1, cv::Mat* src2, cv::Mat* dst)
{
    return cvTry([&] {
    cv::min(*src1, *src2, *dst);
    });
}
CVAPI(ExceptionStatus) core_min_MatDouble(cv::Mat* src1, double src2, cv::Mat* dst)
{
    return cvTry([&] {
    cv::min(*src1, src2, *dst);
    });
}

CVAPI(ExceptionStatus) core_max1(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::max(*src1, *src2, *dst);
    });
}
CVAPI(ExceptionStatus) core_max_MatMat(cv::Mat *src1, const cv::Mat *src2, cv::Mat *dst)
{
    return cvTry([&] {
    cv::max(*src1, *src2, *dst);
    });
}
CVAPI(ExceptionStatus) core_max_MatDouble(cv::Mat *src1, double src2, cv::Mat *dst)
{
    return cvTry([&] {
    cv::max(*src1, src2, *dst);
    });
}

CVAPI(ExceptionStatus) core_sqrt(cv::_InputArray *src, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::sqrt(*src, *dst);
    });
}

CVAPI(ExceptionStatus) core_pow_Mat(cv::_InputArray *src, double power, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::pow(*src, power, *dst);
    });
}

CVAPI(ExceptionStatus) core_exp_Mat(cv::_InputArray *src, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::exp(*src, *dst);
    });
}

CVAPI(ExceptionStatus) core_log_Mat(cv::_InputArray *src, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::log(*src, *dst);
    });
}

CVAPI(ExceptionStatus) core_polarToCart(cv::_InputArray* magnitude, cv::_InputArray* angle,
    cv::_OutputArray* x, cv::_OutputArray* y, int angleInDegrees)
{
    return cvTry([&] {
    cv::polarToCart(*magnitude, *angle, *x, *y, angleInDegrees != 0);
    });
}

CVAPI(ExceptionStatus) core_cartToPolar(cv::_InputArray* x, cv::_InputArray* y,
    cv::_OutputArray* magnitude, cv::_OutputArray* angle, int angleInDegrees)
{
    return cvTry([&] {
    cv::cartToPolar(*x, *y, *magnitude, *angle, angleInDegrees != 0);
    });
}

CVAPI(ExceptionStatus) core_phase(cv::_InputArray* x, cv::_InputArray* y, cv::_OutputArray* angle, int angleInDegrees)
{
    return cvTry([&] {
    cv::phase(*x, *y, *angle, angleInDegrees != 0);
    });
}

CVAPI(ExceptionStatus) core_magnitude_Mat(cv::_InputArray* x, cv::_InputArray* y, cv::_OutputArray* magnitude)
{
    return cvTry([&] {
    cv::magnitude(*x, *y, *magnitude);
    });
}

CVAPI(ExceptionStatus) core_checkRange(cv::_InputArray* a, int quiet, interop::Point* pos, double minVal, double maxVal, int* returnValue)
{
    return cvTry([&] {
    cv::Point pos0;
    *returnValue = cv::checkRange(*a, quiet != 0, &pos0, minVal, maxVal);
    *pos = c(pos0);
    });
}

CVAPI(ExceptionStatus) core_patchNaNs(cv::_InputOutputArray *a, double val)
{
    return cvTry([&] {
    cv::patchNaNs(*a, val);
    });
}

CVAPI(ExceptionStatus) core_gemm(cv::_InputArray *src1, cv::_InputArray *src2, double alpha,
                      cv::_InputArray *src3, double gamma, cv::_OutputArray *dst, int flags)
{
    return cvTry([&] {
    cv::gemm(*src1, *src2, alpha, *src3, gamma, *dst, flags);
    });
}

CVAPI(ExceptionStatus) core_mulTransposed(cv::_InputArray *src, cv::_OutputArray *dst, int aTa,
                               cv::_InputArray *delta, double scale, int dtype)
{
    return cvTry([&] {
    cv::mulTransposed(*src, *dst, aTa != 0, entity(delta), scale, dtype);
    });
}

// MIGRATION (issue #1976, strategy 3): array arguments arrive as interop::ArrayProxy passed BY VALUE;
// fromInputProxy()/fromOutputProxy() (my_types.h) rebuild cv::_InputArray/_OutputArray on this stack
// frame. The same signature serves both the ref-struct path (optimized kinds, zero managed alloc) and
// the still-class path (Raw kinds that wrap an existing cv::_InputArray*). Scalar-kind inputs
// reference a stack-local cv::Scalar scratch that must outlive the OpenCV call.
CVAPI(ExceptionStatus) core_transpose(interop::ArrayProxy src, interop::ArrayProxy dst)
{
    return cvTry([&] {
    cv::Scalar s;
    cv::transpose(fromInputProxy(src, s), fromOutputProxy(dst));
    });
}

CVAPI(ExceptionStatus) core_add_io(interop::ArrayProxy src1, interop::ArrayProxy src2, interop::ArrayProxy dst)
{
    return cvTry([&] {
    cv::Scalar s1, s2;
    cv::add(fromInputProxy(src1, s1), fromInputProxy(src2, s2), fromOutputProxy(dst));
    });
}

CVAPI(ExceptionStatus) core_transform(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *m)
{
    return cvTry([&] {
    cv::transform(*src, *dst, *m);
    });
}

CVAPI(ExceptionStatus) core_perspectiveTransform(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *m)
{
    return cvTry([&] {
    cv::perspectiveTransform(*src, *dst, *m);
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Mat(cv::Mat *src, cv::Mat *dst, cv::Mat *m)
{
    return cvTry([&] {
    cv::perspectiveTransform(*src, *dst, *m);
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point2f(cv::Point2f *src, int srcLength, cv::Point2f *dst, int dstLength, cv::_InputArray *m)
{
    return cvTry([&] {
    const std::vector<cv::Point2f> srcVector(src, src + srcLength);
    std::vector<cv::Point2f> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point2d(cv::Point2d *src, int srcLength, cv::Point2d *dst, int dstLength, cv::_InputArray *m)
{
    return cvTry([&] {
    const std::vector<cv::Point2d> srcVector(src, src + srcLength);
    std::vector<cv::Point2d> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point3f(cv::Point3f *src, int srcLength, cv::Point3f *dst, int dstLength, cv::_InputArray *m)
{
    return cvTry([&] {
    const std::vector<cv::Point3f> srcVector(src, src + srcLength);
    std::vector<cv::Point3f> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point3d(cv::Point3d *src, int srcLength, cv::Point3d *dst, int dstLength, cv::_InputArray *m)
{
    return cvTry([&] {
    const std::vector<cv::Point3d> srcVector(src, src + srcLength);
    std::vector<cv::Point3d> dstVector(dst, dst + dstLength);
    cv::perspectiveTransform(srcVector, dstVector, *m);
    });
}

CVAPI(ExceptionStatus) core_completeSymm(cv::_InputOutputArray *mtx, int lowerToUpper)
{
    return cvTry([&] {
    cv::completeSymm(*mtx, lowerToUpper != 0);
    });
}

// FOUNDATION: ref-struct proxy path for an _InputOutputArray argument (see core_transpose_io).
CVAPI(ExceptionStatus) core_completeSymm_io(interop::ArrayProxy mtx, int lowerToUpper)
{
    return cvTry([&] {
    cv::completeSymm(fromInputOutputProxy(mtx), lowerToUpper != 0);
    });
}

CVAPI(ExceptionStatus) core_setIdentity(cv::_InputOutputArray *mtx, interop::Scalar s)
{
    return cvTry([&] {
    cv::setIdentity(*mtx, cpp(s));
    });
}

CVAPI(ExceptionStatus) core_determinant(cv::_InputArray *mtx, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::determinant(*mtx);
    });
}

CVAPI(ExceptionStatus) core_trace(cv::_InputArray *mtx, interop::Scalar *returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::trace(*mtx));
    });
}

CVAPI(ExceptionStatus) core_invert(cv::_InputArray *src, cv::_OutputArray *dst, int flags, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::invert(*src, *dst, flags);
    });
}

CVAPI(ExceptionStatus) core_solve(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int flags, int *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::solve(*src1, *src2, *dst, flags);
    });
}

CVAPI(ExceptionStatus) core_solveLP(cv::_InputArray *Func, cv::_InputArray *Constr, cv::_OutputArray *z, int *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::solveLP(*Func, *Constr, *z);
    });
}

CVAPI(ExceptionStatus) core_sort(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    return cvTry([&] {
    cv::sort(*src, *dst, flags);
    });
}

CVAPI(ExceptionStatus) core_sortIdx(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    return cvTry([&] {
    cv::sortIdx(*src, *dst, flags);
    });
}

CVAPI(ExceptionStatus) core_solveCubic(cv::_InputArray *coeffs, cv::_OutputArray *roots, int *returnValue)
{
    return cvTry([&] {
    *returnValue =  cv::solveCubic(*coeffs, *roots);
    });
}

CVAPI(ExceptionStatus) core_solvePoly(cv::_InputArray *coeffs, cv::_OutputArray *roots, int maxIters, double *returnValue)
{
    return cvTry([&] {
    *returnValue =  cv::solvePoly(*coeffs, *roots, maxIters);
    });
}

CVAPI(ExceptionStatus) core_eigen(cv::_InputArray *src, cv::_OutputArray *eigenvalues,    cv::_OutputArray *eigenvectors, int *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::eigen(*src, *eigenvalues, *eigenvectors) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_eigenNonSymmetric(
    cv::_InputArray *src,  cv::_OutputArray *eigenvalues, cv::_OutputArray *eigenvectors)
{
    return cvTry([&] {
    cv::eigenNonSymmetric(*src, *eigenvalues, *eigenvectors);
    });
}

CVAPI(ExceptionStatus) core_calcCovarMatrix_Mat(cv::Mat **samples, int nsamples, cv::Mat *covar, 
                                     cv::Mat *mean, int flags, int ctype)
{
    return cvTry([&] {
    std::vector<cv::Mat> samplesVec(nsamples);
    for (int i = 0; i < nsamples; i++)    
        samplesVec[i] = *samples[i];
    
    cv::calcCovarMatrix(&samplesVec[0], nsamples, *covar, *mean, flags, ctype);
    });
}
CVAPI(ExceptionStatus) core_calcCovarMatrix_InputArray(cv::_InputArray *samples, cv::_OutputArray *covar, 
                                            cv::_InputOutputArray *mean, int flags, int ctype)
{
    return cvTry([&] {
    cv::calcCovarMatrix(*samples, *covar, *mean, flags, ctype);
    });
}

CVAPI(ExceptionStatus) core_PCACompute(cv::_InputArray *data, cv::_InputOutputArray *mean,
                            cv::_OutputArray *eigenvectors, int maxComponents)
{
    return cvTry([&] {
    cv::PCACompute(*data, *mean, *eigenvectors, maxComponents);
    });
}
CVAPI(ExceptionStatus) core_PCACompute2(cv::_InputArray *data, cv::_InputOutputArray *mean,
                            cv::_OutputArray *eigenvectors, cv::_OutputArray *eigenvalues, int maxComponents)
{
    return cvTry([&] {
    cv::PCACompute(*data, *mean, *eigenvectors, *eigenvalues, maxComponents);
    });
}

CVAPI(ExceptionStatus) core_PCAComputeVar(cv::_InputArray *data, cv::_InputOutputArray *mean,
                               cv::_OutputArray *eigenvectors, double retainedVariance)
{
    return cvTry([&] {
    cv::PCACompute(*data, *mean, *eigenvectors, retainedVariance);
    });
}
CVAPI(ExceptionStatus) core_PCAComputeVar2(cv::_InputArray *data, cv::_InputOutputArray *mean,
                               cv::_OutputArray *eigenvectors, cv::_OutputArray *eigenvalues, double retainedVariance)
{
    return cvTry([&] {
    cv::PCACompute(*data, *mean, *eigenvectors, *eigenvalues, retainedVariance);
    });
}

CVAPI(ExceptionStatus) core_PCAProject(cv::_InputArray *data, cv::_InputArray *mean,
                            cv::_InputArray *eigenvectors, cv::_OutputArray *result)
{
    return cvTry([&] {
    cv::PCAProject(*data, *mean, *eigenvectors, *result);
    });
}
CVAPI(ExceptionStatus) core_PCABackProject(cv::_InputArray *data, cv::_InputArray *mean,
                                cv::_InputArray *eigenvectors, cv::_OutputArray *result)
{
    return cvTry([&] {
    cv::PCABackProject(*data, *mean, *eigenvectors, *result);
    });
}

CVAPI(ExceptionStatus) core_SVDecomp(cv::_InputArray *src, cv::_OutputArray *w,
                          cv::_OutputArray *u, cv::_OutputArray *vt, int flags)
{
    return cvTry([&] {
    cv::SVDecomp(*src, *w, *u, *vt, flags);
    });
}

CVAPI(ExceptionStatus) core_SVBackSubst(cv::_InputArray *w, cv::_InputArray *u, cv::_InputArray *vt,
                             cv::_InputArray *rhs, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::SVBackSubst(*w, *u, *vt, *rhs, *dst);
    });
}

CVAPI(ExceptionStatus) core_Mahalanobis(cv::_InputArray *v1, cv::_InputArray *v2, cv::_InputArray *icovar, double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::Mahalanobis(*v1, *v2, *icovar);
    });
}

CVAPI(ExceptionStatus) core_dft(cv::_InputArray *src, cv::_OutputArray *dst, int flags, int nonzeroRows)
{
    return cvTry([&] {
    cv::dft(*src, *dst, flags, nonzeroRows);
    });
}

CVAPI(ExceptionStatus) core_idft(cv::_InputArray *src, cv::_OutputArray *dst, int flags, int nonzeroRows)
{
    return cvTry([&] {
    cv::idft(*src, *dst, flags, nonzeroRows);
    });
}

CVAPI(ExceptionStatus) core_dct(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    return cvTry([&] {
    cv::dct(*src, *dst, flags); 
    });
}

CVAPI(ExceptionStatus) core_idct(cv::_InputArray *src, cv::_OutputArray *dst, int flags)
{
    return cvTry([&] {
    cv::idct(*src, *dst, flags);
    });
}

CVAPI(ExceptionStatus) core_mulSpectrums(cv::_InputArray *a, cv::_InputArray *b, cv::_OutputArray *c, int flags, int conjB)
{
    return cvTry([&] {
    cv::mulSpectrums(*a, *b, *c, flags, conjB != 0);
    });
}

CVAPI(ExceptionStatus) core_getOptimalDFTSize(int vecsize, int *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getOptimalDFTSize(vecsize);
    });
}

CVAPI(ExceptionStatus) core_theRNG_get(uint64 *returnValue)
{
    return cvTry([&] {
    cv::RNG &rng = cv::theRNG();
    *returnValue = rng.state;
    });
}

CVAPI(ExceptionStatus) core_theRNG_set(uint64 value)
{
    return cvTry([&] {
    cv::theRNG().state = value;
    });
}

CVAPI(ExceptionStatus) core_randu_InputArray(cv::_InputOutputArray *dst, cv::_InputArray *low, cv::_InputArray *high)
{
    return cvTry([&] {
    cv::randu(*dst, *low, *high);
    });
}
CVAPI(ExceptionStatus) core_randu_Scalar(cv::_InputOutputArray *dst, interop::Scalar low, interop::Scalar high)
{
    return cvTry([&] {
    cv::randu(*dst, cpp(low), cpp(high));
    });
}

CVAPI(ExceptionStatus) core_randn_InputArray(cv::_InputOutputArray *dst, cv::_InputArray *mean, cv::_InputArray *stddev)
{
    return cvTry([&] {
    cv::randn(*dst, *mean, *stddev);
    });
}
CVAPI(ExceptionStatus) core_randn_Scalar(cv::_InputOutputArray *dst, interop::Scalar mean, interop::Scalar stddev)
{
    return cvTry([&] {
    cv::randn(*dst, cpp(mean), cpp(stddev));
    });
}

CVAPI(ExceptionStatus) core_randShuffle(cv::_InputOutputArray *dst, double iterFactor, uint64 *rng)
{
    return cvTry([&] {
    cv::RNG rng0;
    cv::randShuffle(*dst, iterFactor, &rng0);
    *rng = rng0.state;
    });
}

CVAPI(ExceptionStatus) core_kmeans(
    cv::_InputArray *data, int k, cv::_InputOutputArray *bestLabels,
    interop::TermCriteria criteria, int attempts, int flags, cv::_OutputArray *centers, 
    double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::kmeans(*data, k, *bestLabels, cpp(criteria), attempts, flags, entity(centers));
    });
}

#pragma endregion

#pragma region base.hpp

CVAPI(ExceptionStatus) core_cubeRoot(float val, float* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::cubeRoot(val);
    });
}
CVAPI(ExceptionStatus) core_fastAtan2(float y, float x, float* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::fastAtan2(y, x);
    });
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

// Native, managed-free OpenCV error handler installed by default. It exists only to
// suppress OpenCV's stderr dump (OpenCV prints to stderr only when no handler is set).
// Error details are captured by cvTry from the thrown exception, not here.
static int opencvsharp_silentErrorHandler(int /*status*/, const char* /*funcName*/,
    const char* /*errMsg*/, const char* /*fileName*/, int /*line*/, void* /*userdata*/)
{
    return 0;
}

// Installs the default native silent error handler. Idempotent. Pass-through for the
// managed default path and for restoring the default after Cv2.SetErrorHandler(null).
CVAPI(ExceptionStatus) core_setSilentErrorHandler()
{
    return cvTry([&] {
        cv::redirectError(opencvsharp_silentErrorHandler);
    });
}

// Reads the per-thread record of the last exception caught at the export boundary
// (see cvTry / LastNativeException). The managed side calls this after an export
// returns ExceptionStatus::Occurred.
CVAPI(ExceptionStatus) core_getLastException(
    int* code, int* line, std::string* func, std::string* file, std::string* message)
{
    return cvTry([&] {
    const auto& last = lastNativeException();
    *code = last.code;
    *line = last.line;
    func->assign(last.func);
    file->assign(last.file);
    message->assign(last.message);
    });
}

CVAPI(ExceptionStatus) core_setNumThreads(int nthreads)
{
    return cvTry([&] {
    cv::setNumThreads(nthreads);
    });
}

CVAPI(ExceptionStatus) core_getNumThreads(int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getNumThreads();
    });
}
CVAPI(ExceptionStatus) core_getThreadNum(int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getThreadNum();
    });
}

CVAPI(ExceptionStatus) core_getBuildInformation(std::string *buf)
{
    return cvTry([&] {
    const auto& str = cv::getBuildInformation();
    buf->assign(str);
    });
}

CVAPI(ExceptionStatus) core_getVersionString(char *buf, int bufLength)
{
    return cvTry([&] {
    const auto& str = cv::getVersionString();
    copyString(str, buf, bufLength);
    });
}

CVAPI(ExceptionStatus) core_getVersionMajor(int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getVersionMajor();
    });
}

CVAPI(ExceptionStatus) core_getVersionMinor(int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getVersionMinor();
    });
}

CVAPI(ExceptionStatus) core_getVersionRevision(int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getVersionRevision();
    });
}

CVAPI(ExceptionStatus) core_getTickCount(int64* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getTickCount();
    });
}

CVAPI(ExceptionStatus) core_getTickFrequency(double* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getTickFrequency();
    });
}

CVAPI(ExceptionStatus) core_getCPUTickCount(int64* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getCPUTickCount();
    });
}

CVAPI(ExceptionStatus) core_checkHardwareSupport(int feature, int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::checkHardwareSupport(feature) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_getHardwareFeatureName(int feature, std::string *buf)
{
    return cvTry([&] {
    const auto& str = cv::getHardwareFeatureName(feature);
    buf->assign(str);
    });
}

CVAPI(ExceptionStatus) core_getCPUFeaturesLine(std::string *buf)
{
    return cvTry([&] {
    const auto& str = cv::getCPUFeaturesLine();
    buf->assign(str);
    });
}

CVAPI(ExceptionStatus) core_getNumberOfCPUs(int* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::getNumberOfCPUs();
    });
}

CVAPI(ExceptionStatus) core_setUseOptimized(int onoff)
{
    return cvTry([&] {
    cv::setUseOptimized(onoff != 0);
    });
}
CVAPI(ExceptionStatus) core_useOptimized(int *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::useOptimized() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_format(cv::_InputArray *mtx, int fmt, std::string *buf)
{
    return cvTry([&] {
    const auto formatted = cv::format(*mtx, static_cast<cv::Formatter::FormatType>(fmt));

    std::stringstream s;
    s << formatted;
    buf->assign(s.str());
    });
}

#pragma endregion

#pragma region logger.hpp

CVAPI(ExceptionStatus) core_logger_setLogLevel(cv::utils::logging::LogLevel logLevel, cv::utils::logging::LogLevel* returnValue)
{
    return cvTry([&] {
    *returnValue = cv::utils::logging::setLogLevel(logLevel);
    });
}

CVAPI(ExceptionStatus) core_logger_getLogLevel(cv::utils::logging::LogLevel *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::utils::logging::getLogLevel();
    });
}

#pragma endregion

#pragma region RNG

CVAPI(ExceptionStatus) core_RNG_fill(uint64 *state, cv::_InputOutputArray *mat, int distType, cv::_InputArray *a, cv::_InputArray *b, int saturateRange)
{
    return cvTry([&] {
    cv::RNG rng(*state);
    rng.fill(*mat, distType, *a, *b, saturateRange != 0);
    *state = rng.state;
    });
}

CVAPI(ExceptionStatus) core_RNG_gaussian(uint64 *state, double sigma, double *returnValue)
{
    return cvTry([&] {
    cv::RNG rng(*state);
    *returnValue = rng.gaussian(sigma);
    *state = rng.state;
    });
}

#pragma endregion
