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
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int top, int bottom, int left, int right,
    int borderType,
    interop::Scalar value)
{
    return cvTry([&] {
        cv::copyMakeBorder(InProxy(*src), OutProxy(*dst), top, bottom, left, right, borderType, cpp(value));
    });
}

CVAPI(ExceptionStatus) core_add(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask,
    int dtype)
{
    return cvTry([&] {
        cv::add(InProxy(*src1), InProxy(*src2), OutProxy(*dst), InProxy(*mask), dtype);
    });
}

CVAPI(ExceptionStatus) core_subtract_InputArray2(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask,
    int dtype)
{
    return cvTry([&] {
        cv::subtract(InProxy(*src1), InProxy(*src2), OutProxy(*dst), InProxy(*mask), dtype);
    });
}
CVAPI(ExceptionStatus) core_subtract_InputArrayScalar(
    const interop::InputArrayProxy* src1,
    interop::Scalar src2,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask,
    int dtype)
{
    return cvTry([&] {
        cv::subtract(InProxy(*src1), cpp(src2), OutProxy(*dst), InProxy(*mask), dtype);
    });
}
CVAPI(ExceptionStatus) core_subtract_ScalarInputArray(
    interop::Scalar src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask,
    int dtype)
{
    return cvTry([&] {
        cv::subtract(cpp(src1), InProxy(*src2), OutProxy(*dst), InProxy(*mask), dtype);
    });
}

CVAPI(ExceptionStatus) core_multiply(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    double scale,
    int dtype)
{
    return cvTry([&] {
        cv::multiply(InProxy(*src1), InProxy(*src2), OutProxy(*dst), scale, dtype);
    });
}
CVAPI(ExceptionStatus) core_divide1(
    double scale,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    int dtype)
{
    return cvTry([&] {
        cv::divide(scale, InProxy(*src2), OutProxy(*dst), dtype);
    });
}
CVAPI(ExceptionStatus) core_divide2(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    double scale,
    int dtype)
{
    return cvTry([&] {
        cv::divide(InProxy(*src1), InProxy(*src2), OutProxy(*dst), scale, dtype);
    });
}

CVAPI(ExceptionStatus) core_scaleAdd(
    const interop::InputArrayProxy* src1,
    double alpha,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::scaleAdd(InProxy(*src1), alpha, InProxy(*src2), OutProxy(*dst));
    });
}
CVAPI(ExceptionStatus) core_addWeighted(
    const interop::InputArrayProxy* src1,
    double alpha,
    const interop::InputArrayProxy* src2,
    double beta,
    double gamma,
    const interop::OutputArrayProxy* dst,
    int dtype)
{
    return cvTry([&] {
        cv::addWeighted(InProxy(*src1), alpha, InProxy(*src2), beta, gamma, OutProxy(*dst), dtype);
    });
}

CVAPI(ExceptionStatus) core_convertScaleAbs(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    double alpha,
    double beta)
{
    return cvTry([&] {
        cv::convertScaleAbs(InProxy(*src), OutProxy(*dst), alpha, beta);
    });
}

CVAPI(ExceptionStatus) core_LUT(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* lut,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::LUT(InProxy(*src), InProxy(*lut), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_sum(const interop::InputArrayProxy* src, interop::Scalar* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::sum(InProxy(*src)));
    });
}

CVAPI(ExceptionStatus) core_countNonZero(const interop::InputArrayProxy* src, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::countNonZero(InProxy(*src));
    });
}

CVAPI(ExceptionStatus) core_findNonZero(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* idx)
{
    return cvTry([&] {
        cv::findNonZero(InProxy(*src), OutProxy(*idx));
    });
}

CVAPI(ExceptionStatus) core_mean(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* mask,
    interop::Scalar* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::mean(InProxy(*src), InProxy(*mask)));
    });
}

CVAPI(ExceptionStatus) core_meanStdDev_OutputArray(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* mean,
    const interop::OutputArrayProxy* stddev,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::meanStdDev(InProxy(*src), OutProxy(*mean), OutProxy(*stddev), InProxy(*mask));
    });
}
CVAPI(ExceptionStatus) core_meanStdDev_Scalar(
    const interop::InputArrayProxy* src,
    interop::Scalar* mean,
    interop::Scalar* stddev,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::Scalar mean0, stddev0;
        cv::meanStdDev(InProxy(*src), mean0, stddev0, InProxy(*mask));
        *mean = c(mean0);
        *stddev = c(stddev0);
    });
}

CVAPI(ExceptionStatus) core_norm1(
    const interop::InputArrayProxy* src1,
    int normType,
    const interop::InputArrayProxy* mask,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::norm(InProxy(*src1), normType, InProxy(*mask));
    });
}
CVAPI(ExceptionStatus) core_norm2(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    int normType,
    const interop::InputArrayProxy* mask,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::norm(InProxy(*src1), InProxy(*src2), normType, InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) core_PSNR(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    double R,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::PSNR(InProxy(*src1), InProxy(*src2), R);
    });
}

CVAPI(ExceptionStatus) core_batchDistance(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dist,
    int dtype,
    const interop::OutputArrayProxy* nidx,
    int normType,
    int K,
    const interop::InputArrayProxy* mask,
    int update,
    int crosscheck)
{
    return cvTry([&] {
        cv::batchDistance(
            InProxy(*src1), InProxy(*src2), OutProxy(*dist), dtype, OutProxy(*nidx), normType, K, InProxy(*mask), update, crosscheck != 0);
    });
}

CVAPI(ExceptionStatus) core_normalize(
    const interop::InputArrayProxy* src,
    const interop::InputOutputArrayProxy* dst,
    double alpha,
    double beta,
    int normType,
    int dtype,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::normalize(InProxy(*src), IoProxy(*dst), alpha, beta, normType, dtype, InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) core_reduceArgMax(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int axis,
    bool lastIndex)
{
    return cvTry([&] {
        cv::reduceArgMax(InProxy(*src), OutProxy(*dst), axis, lastIndex);
    });
}

CVAPI(ExceptionStatus) core_reduceArgMin(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int axis,
    bool lastIndex)
{
    return cvTry([&] {
        cv::reduceArgMin(InProxy(*src), OutProxy(*dst), axis, lastIndex);
    });
}

CVAPI(ExceptionStatus) core_minMaxLoc1(const interop::InputArrayProxy* src, double* minVal, double* maxVal)
{
    return cvTry([&] {
        cv::minMaxLoc(InProxy(*src), minVal, maxVal);
    });
}
CVAPI(ExceptionStatus) core_minMaxLoc2(
    const interop::InputArrayProxy* src,
    double* minVal,
    double* maxVal,
    interop::Point* minLoc,
    interop::Point* maxLoc,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::Point minLoc0, maxLoc0;
        cv::minMaxLoc(InProxy(*src), minVal, maxVal, &minLoc0, &maxLoc0, InProxy(*mask));
        *minLoc = c(minLoc0);
        *maxLoc = c(maxLoc0);
    });
}

CVAPI(ExceptionStatus) core_minMaxIdx1(const interop::InputArrayProxy* src, double* minVal, double* maxVal)
{
    return cvTry([&] {
        cv::minMaxIdx(InProxy(*src), minVal, maxVal);
    });
}
CVAPI(ExceptionStatus) core_minMaxIdx2(
    const interop::InputArrayProxy* src,
    double* minVal,
    double* maxVal,
    int* minIdx,
    int* maxIdx,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::minMaxIdx(InProxy(*src), minVal, maxVal, minIdx, maxIdx, InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) core_reduce(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int dim,
    int rtype,
    int dtype)
{
    return cvTry([&] {
        cv::reduce(InProxy(*src), OutProxy(*dst), dim, rtype, dtype);
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

CVAPI(ExceptionStatus) core_extractChannel(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int coi)
{
    return cvTry([&] {
        cv::extractChannel(InProxy(*src), OutProxy(*dst), coi);
    });
}

CVAPI(ExceptionStatus) core_insertChannel(const interop::InputArrayProxy* src, const interop::InputOutputArrayProxy* dst, int coi)
{
    return cvTry([&] {
        cv::insertChannel(InProxy(*src), IoProxy(*dst), coi);
    });
}

CVAPI(ExceptionStatus) core_flip(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int flipCode)
{
    return cvTry([&] {
        cv::flip(InProxy(*src), OutProxy(*dst), flipCode);
    });
}

CVAPI(ExceptionStatus) core_rotate(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int rotateCode)
{
    return cvTry([&] {
        cv::rotate(InProxy(*src), OutProxy(*dst), rotateCode);
    });
}

CVAPI(ExceptionStatus) core_repeat1(
    const interop::InputArrayProxy* src,
    int ny,
    int nx,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::repeat(InProxy(*src), ny, nx, OutProxy(*dst));
    });
}
CVAPI(ExceptionStatus) core_repeat2(cv::Mat* src, int ny, int nx, cv::Mat** returnValue)
{
    return cvTry([&] {
        const cv::Mat ret = cv::repeat(*src, ny, nx);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_hconcat1(cv::Mat** src, uint32_t nsrc, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrc));
        for (uint32_t i = 0; i < nsrc; i++)
            srcVec[i] = *(src[i]);
        cv::hconcat(&srcVec[0], nsrc, OutProxy(*dst));
    });
}
CVAPI(ExceptionStatus) core_hconcat2(const interop::InputArrayProxy* src1, const interop::InputArrayProxy* src2, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::hconcat(InProxy(*src1), InProxy(*src2), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_vconcat1(cv::Mat** src, uint32_t nsrc, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        std::vector<cv::Mat> srcVec(static_cast<size_t>(nsrc));
        for (uint32_t i = 0; i < nsrc; i++)
            srcVec[i] = *(src[i]);
        cv::vconcat(&srcVec[0], nsrc, OutProxy(*dst));
    });
}
CVAPI(ExceptionStatus) core_vconcat2(const interop::InputArrayProxy* src1, const interop::InputArrayProxy* src2, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::vconcat(InProxy(*src1), InProxy(*src2), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_bitwise_and(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::bitwise_and(InProxy(*src1), InProxy(*src2), OutProxy(*dst), InProxy(*mask));
    });
}
CVAPI(ExceptionStatus) core_bitwise_or(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::bitwise_or(InProxy(*src1), InProxy(*src2), OutProxy(*dst), InProxy(*mask));
    });
}
CVAPI(ExceptionStatus) core_bitwise_xor(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::bitwise_xor(InProxy(*src1), InProxy(*src2), OutProxy(*dst), InProxy(*mask));
    });
}
CVAPI(ExceptionStatus) core_bitwise_not(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::bitwise_not(InProxy(*src), OutProxy(*dst), InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) core_absdiff(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::absdiff(InProxy(*src1), InProxy(*src2), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_copyTo(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::copyTo(InProxy(*src), OutProxy(*dst), InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) core_inRange_InputArray(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* lowerb,
    const interop::InputArrayProxy* upperb,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::inRange(InProxy(*src), InProxy(*lowerb), InProxy(*upperb), OutProxy(*dst));
    });
}
CVAPI(ExceptionStatus) core_inRange_Scalar(
    const interop::InputArrayProxy* src,
    interop::Scalar lowerb,
    interop::Scalar upperb,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::inRange(InProxy(*src), cpp(lowerb), cpp(upperb), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_compare(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    int cmpop)
{
    return cvTry([&] {
        cv::compare(InProxy(*src1), InProxy(*src2), OutProxy(*dst), cmpop);
    });
}

CVAPI(ExceptionStatus) core_min1(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        // Named lvalues (not InProxy temporaries): cv::min/max also have a [[nodiscard]] MatExpr(Mat,Mat)
        // overload, and passing InProxy temporaries makes overload resolution pick it (it builds a MatExpr
        // over dangling temporaries -> heap corruption, plus C4834). Binding to named cv::_InputArray
        // lvalues forces the void min(InputArray,InputArray,OutputArray) overload.
        cv::Scalar s1, s2;
        const cv::_InputArray a = fromInputProxy(*src1, s1);
        const cv::_InputArray b = fromInputProxy(*src2, s2);
        cv::_OutputArray d = fromOutputProxy(*dst);
        cv::min(a, b, d);
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

CVAPI(ExceptionStatus) core_max1(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        // See core_min1: named lvalues force the void max(InputArray,InputArray,OutputArray) overload
        // instead of the [[nodiscard]] MatExpr max(Mat,Mat).
        cv::Scalar s1, s2;
        const cv::_InputArray a = fromInputProxy(*src1, s1);
        const cv::_InputArray b = fromInputProxy(*src2, s2);
        cv::_OutputArray d = fromOutputProxy(*dst);
        cv::max(a, b, d);
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

CVAPI(ExceptionStatus) core_sqrt(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::sqrt(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_pow_Mat(const interop::InputArrayProxy* src, double power, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::pow(InProxy(*src), power, OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_exp_Mat(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::exp(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_log_Mat(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::log(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_polarToCart(
    const interop::InputArrayProxy* magnitude,
    const interop::InputArrayProxy* angle,
    const interop::OutputArrayProxy* x,
    const interop::OutputArrayProxy* y,
    int angleInDegrees)
{
    return cvTry([&] {
        cv::polarToCart(InProxy(*magnitude), InProxy(*angle), OutProxy(*x), OutProxy(*y), angleInDegrees != 0);
    });
}

CVAPI(ExceptionStatus) core_cartToPolar(
    const interop::InputArrayProxy* x,
    const interop::InputArrayProxy* y,
    const interop::OutputArrayProxy* magnitude,
    const interop::OutputArrayProxy* angle,
    int angleInDegrees)
{
    return cvTry([&] {
        cv::cartToPolar(InProxy(*x), InProxy(*y), OutProxy(*magnitude), OutProxy(*angle), angleInDegrees != 0);
    });
}

CVAPI(ExceptionStatus) core_phase(
    const interop::InputArrayProxy* x,
    const interop::InputArrayProxy* y,
    const interop::OutputArrayProxy* angle,
    int angleInDegrees)
{
    return cvTry([&] {
        cv::phase(InProxy(*x), InProxy(*y), OutProxy(*angle), angleInDegrees != 0);
    });
}

CVAPI(ExceptionStatus) core_magnitude_Mat(
    const interop::InputArrayProxy* x,
    const interop::InputArrayProxy* y,
    const interop::OutputArrayProxy* magnitude)
{
    return cvTry([&] {
        cv::magnitude(InProxy(*x), InProxy(*y), OutProxy(*magnitude));
    });
}

CVAPI(ExceptionStatus) core_checkRange(
    const interop::InputArrayProxy* a,
    int quiet,
    interop::Point* pos,
    double minVal,
    double maxVal,
    int* returnValue)
{
    return cvTry([&] {
        cv::Point pos0;
        *returnValue = cv::checkRange(InProxy(*a), quiet != 0, &pos0, minVal, maxVal);
        *pos = c(pos0);
    });
}

CVAPI(ExceptionStatus) core_patchNaNs(const interop::InputOutputArrayProxy* a, double val)
{
    return cvTry([&] {
        cv::patchNaNs(IoProxy(*a), val);
    });
}

CVAPI(ExceptionStatus) core_gemm(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    double alpha,
    const interop::InputArrayProxy* src3,
    double gamma,
    const interop::OutputArrayProxy* dst,
    int flags)
{
    return cvTry([&] {
        cv::gemm(InProxy(*src1), InProxy(*src2), alpha, InProxy(*src3), gamma, OutProxy(*dst), flags);
    });
}

CVAPI(ExceptionStatus) core_mulTransposed(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int aTa,
    const interop::InputArrayProxy* delta,
    double scale,
    int dtype)
{
    return cvTry([&] {
        cv::mulTransposed(InProxy(*src), OutProxy(*dst), aTa != 0, InProxy(*delta), scale, dtype);
    });
}

// MIGRATION (issue #1976, strategy 3): array arguments arrive as interop::{Input,Output,InputOutput}
// ArrayProxy passed BY VALUE (the type names keep the signature self-documenting about in/out).
// The InProxy/OutProxy/IoProxy views (my_types.h) rebuild cv::_InputArray/_OutputArray on this stack
// frame. The same signature serves both the ref-struct path (optimized kinds, zero managed alloc) and
// the still-class path (Raw kinds that wrap an existing cv::_InputArray*).
CVAPI(ExceptionStatus) core_transpose(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::transpose(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_transform(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* m)
{
    return cvTry([&] {
        cv::transform(InProxy(*src), OutProxy(*dst), InProxy(*m));
    });
}

CVAPI(ExceptionStatus) core_perspectiveTransform(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* m)
{
    return cvTry([&] {
        cv::perspectiveTransform(InProxy(*src), OutProxy(*dst), InProxy(*m));
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Mat(cv::Mat *src, cv::Mat *dst, cv::Mat *m)
{
    return cvTry([&] {
        cv::perspectiveTransform(*src, *dst, *m);
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point2f(cv::Point2f *src, int srcLength, cv::Point2f *dst, int dstLength, const interop::InputArrayProxy* m)
{
    return cvTry([&] {
        const std::vector<cv::Point2f> srcVector(src, src + srcLength);
        std::vector<cv::Point2f> dstVector(dst, dst + dstLength);
        cv::perspectiveTransform(srcVector, dstVector, InProxy(*m));
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point2d(cv::Point2d *src, int srcLength, cv::Point2d *dst, int dstLength, const interop::InputArrayProxy* m)
{
    return cvTry([&] {
        const std::vector<cv::Point2d> srcVector(src, src + srcLength);
        std::vector<cv::Point2d> dstVector(dst, dst + dstLength);
        cv::perspectiveTransform(srcVector, dstVector, InProxy(*m));
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point3f(cv::Point3f *src, int srcLength, cv::Point3f *dst, int dstLength, const interop::InputArrayProxy* m)
{
    return cvTry([&] {
        const std::vector<cv::Point3f> srcVector(src, src + srcLength);
        std::vector<cv::Point3f> dstVector(dst, dst + dstLength);
        cv::perspectiveTransform(srcVector, dstVector, InProxy(*m));
    });
}
CVAPI(ExceptionStatus) core_perspectiveTransform_Point3d(cv::Point3d *src, int srcLength, cv::Point3d *dst, int dstLength, const interop::InputArrayProxy* m)
{
    return cvTry([&] {
        const std::vector<cv::Point3d> srcVector(src, src + srcLength);
        std::vector<cv::Point3d> dstVector(dst, dst + dstLength);
        cv::perspectiveTransform(srcVector, dstVector, InProxy(*m));
    });
}

CVAPI(ExceptionStatus) core_completeSymm(const interop::InputOutputArrayProxy* mtx, int lowerToUpper)
{
    return cvTry([&] {
        cv::completeSymm(IoProxy(*mtx), lowerToUpper != 0);
    });
}

CVAPI(ExceptionStatus) core_setIdentity(const interop::InputOutputArrayProxy* mtx, interop::Scalar s)
{
    return cvTry([&] {
        cv::setIdentity(IoProxy(*mtx), cpp(s));
    });
}

CVAPI(ExceptionStatus) core_determinant(const interop::InputArrayProxy* mtx, double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::determinant(InProxy(*mtx));
    });
}

CVAPI(ExceptionStatus) core_trace(const interop::InputArrayProxy* mtx, interop::Scalar *returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::trace(InProxy(*mtx)));
    });
}

CVAPI(ExceptionStatus) core_invert(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int flags,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::invert(InProxy(*src), OutProxy(*dst), flags);
    });
}

CVAPI(ExceptionStatus) core_solve(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst,
    int flags,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::solve(InProxy(*src1), InProxy(*src2), OutProxy(*dst), flags);
    });
}

CVAPI(ExceptionStatus) core_solveLP(
    const interop::InputArrayProxy* Func,
    const interop::InputArrayProxy* Constr,
    const interop::OutputArrayProxy* z,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::solveLP(InProxy(*Func), InProxy(*Constr), OutProxy(*z));
    });
}

CVAPI(ExceptionStatus) core_sort(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int flags)
{
    return cvTry([&] {
        cv::sort(InProxy(*src), OutProxy(*dst), flags);
    });
}

CVAPI(ExceptionStatus) core_sortIdx(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int flags)
{
    return cvTry([&] {
        cv::sortIdx(InProxy(*src), OutProxy(*dst), flags);
    });
}

CVAPI(ExceptionStatus) core_solveCubic(const interop::InputArrayProxy* coeffs, const interop::OutputArrayProxy* roots, int *returnValue)
{
    return cvTry([&] {
        *returnValue =  cv::solveCubic(InProxy(*coeffs), OutProxy(*roots));
    });
}

CVAPI(ExceptionStatus) core_solvePoly(
    const interop::InputArrayProxy* coeffs,
    const interop::OutputArrayProxy* roots,
    int maxIters,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue =  cv::solvePoly(InProxy(*coeffs), OutProxy(*roots), maxIters);
    });
}

CVAPI(ExceptionStatus) core_eigen(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* eigenvalues,
    const interop::OutputArrayProxy* eigenvectors,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::eigen(InProxy(*src), OutProxy(*eigenvalues), OutProxy(*eigenvectors)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_eigenNonSymmetric(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* eigenvalues,
    const interop::OutputArrayProxy* eigenvectors)
{
    return cvTry([&] {
        cv::eigenNonSymmetric(InProxy(*src), OutProxy(*eigenvalues), OutProxy(*eigenvectors));
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
CVAPI(ExceptionStatus) core_calcCovarMatrix_InputArray(
    const interop::InputArrayProxy* samples,
    const interop::OutputArrayProxy* covar,
    const interop::InputOutputArrayProxy* mean,
    int flags,
    int ctype)
{
    return cvTry([&] {
        cv::calcCovarMatrix(InProxy(*samples), OutProxy(*covar), IoProxy(*mean), flags, ctype);
    });
}

CVAPI(ExceptionStatus) core_PCACompute(
    const interop::InputArrayProxy* data,
    const interop::InputOutputArrayProxy* mean,
    const interop::OutputArrayProxy* eigenvectors,
    int maxComponents)
{
    return cvTry([&] {
        cv::PCACompute(InProxy(*data), IoProxy(*mean), OutProxy(*eigenvectors), maxComponents);
    });
}
CVAPI(ExceptionStatus) core_PCACompute2(
    const interop::InputArrayProxy* data,
    const interop::InputOutputArrayProxy* mean,
    const interop::OutputArrayProxy* eigenvectors,
    const interop::OutputArrayProxy* eigenvalues,
    int maxComponents)
{
    return cvTry([&] {
        cv::PCACompute(InProxy(*data), IoProxy(*mean), OutProxy(*eigenvectors), OutProxy(*eigenvalues), maxComponents);
    });
}

CVAPI(ExceptionStatus) core_PCAComputeVar(
    const interop::InputArrayProxy* data,
    const interop::InputOutputArrayProxy* mean,
    const interop::OutputArrayProxy* eigenvectors,
    double retainedVariance)
{
    return cvTry([&] {
        cv::PCACompute(InProxy(*data), IoProxy(*mean), OutProxy(*eigenvectors), retainedVariance);
    });
}
CVAPI(ExceptionStatus) core_PCAComputeVar2(
    const interop::InputArrayProxy* data,
    const interop::InputOutputArrayProxy* mean,
    const interop::OutputArrayProxy* eigenvectors,
    const interop::OutputArrayProxy* eigenvalues,
    double retainedVariance)
{
    return cvTry([&] {
        cv::PCACompute(InProxy(*data), IoProxy(*mean), OutProxy(*eigenvectors), OutProxy(*eigenvalues), retainedVariance);
    });
}

CVAPI(ExceptionStatus) core_PCAProject(
    const interop::InputArrayProxy* data,
    const interop::InputArrayProxy* mean,
    const interop::InputArrayProxy* eigenvectors,
    const interop::OutputArrayProxy* result)
{
    return cvTry([&] {
        cv::PCAProject(InProxy(*data), InProxy(*mean), InProxy(*eigenvectors), OutProxy(*result));
    });
}
CVAPI(ExceptionStatus) core_PCABackProject(
    const interop::InputArrayProxy* data,
    const interop::InputArrayProxy* mean,
    const interop::InputArrayProxy* eigenvectors,
    const interop::OutputArrayProxy* result)
{
    return cvTry([&] {
        cv::PCABackProject(InProxy(*data), InProxy(*mean), InProxy(*eigenvectors), OutProxy(*result));
    });
}

CVAPI(ExceptionStatus) core_SVDecomp(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* w,
    const interop::OutputArrayProxy* u,
    const interop::OutputArrayProxy* vt,
    int flags)
{
    return cvTry([&] {
        cv::SVDecomp(InProxy(*src), OutProxy(*w), OutProxy(*u), OutProxy(*vt), flags);
    });
}

CVAPI(ExceptionStatus) core_SVBackSubst(
    const interop::InputArrayProxy* w,
    const interop::InputArrayProxy* u,
    const interop::InputArrayProxy* vt,
    const interop::InputArrayProxy* rhs,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::SVBackSubst(InProxy(*w), InProxy(*u), InProxy(*vt), InProxy(*rhs), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) core_Mahalanobis(
    const interop::InputArrayProxy* v1,
    const interop::InputArrayProxy* v2,
    const interop::InputArrayProxy* icovar,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::Mahalanobis(InProxy(*v1), InProxy(*v2), InProxy(*icovar));
    });
}

CVAPI(ExceptionStatus) core_dft(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int flags, int nonzeroRows)
{
    return cvTry([&] {
        cv::dft(InProxy(*src), OutProxy(*dst), flags, nonzeroRows);
    });
}

CVAPI(ExceptionStatus) core_idft(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int flags, int nonzeroRows)
{
    return cvTry([&] {
        cv::idft(InProxy(*src), OutProxy(*dst), flags, nonzeroRows);
    });
}

CVAPI(ExceptionStatus) core_dct(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int flags)
{
    return cvTry([&] {
        cv::dct(InProxy(*src), OutProxy(*dst), flags);
    });
}

CVAPI(ExceptionStatus) core_idct(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, int flags)
{
    return cvTry([&] {
        cv::idct(InProxy(*src), OutProxy(*dst), flags);
    });
}

CVAPI(ExceptionStatus) core_mulSpectrums(
    const interop::InputArrayProxy* a,
    const interop::InputArrayProxy* b,
    const interop::OutputArrayProxy* c,
    int flags,
    int conjB)
{
    return cvTry([&] {
        cv::mulSpectrums(InProxy(*a), InProxy(*b), OutProxy(*c), flags, conjB != 0);
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

CVAPI(ExceptionStatus) core_randu_InputArray(const interop::InputOutputArrayProxy* dst, const interop::InputArrayProxy* low, const interop::InputArrayProxy* high)
{
    return cvTry([&] {
        cv::randu(IoProxy(*dst), InProxy(*low), InProxy(*high));
    });
}
CVAPI(ExceptionStatus) core_randu_Scalar(const interop::InputOutputArrayProxy* dst, interop::Scalar low, interop::Scalar high)
{
    return cvTry([&] {
        cv::randu(IoProxy(*dst), cpp(low), cpp(high));
    });
}

CVAPI(ExceptionStatus) core_randn_InputArray(const interop::InputOutputArrayProxy* dst, const interop::InputArrayProxy* mean, const interop::InputArrayProxy* stddev)
{
    return cvTry([&] {
        cv::randn(IoProxy(*dst), InProxy(*mean), InProxy(*stddev));
    });
}
CVAPI(ExceptionStatus) core_randn_Scalar(const interop::InputOutputArrayProxy* dst, interop::Scalar mean, interop::Scalar stddev)
{
    return cvTry([&] {
        cv::randn(IoProxy(*dst), cpp(mean), cpp(stddev));
    });
}

CVAPI(ExceptionStatus) core_randShuffle(const interop::InputOutputArrayProxy* dst, double iterFactor, uint64 *rng)
{
    return cvTry([&] {
        cv::RNG rng0;
        if (rng != nullptr)
            rng0.state = *rng;
        cv::randShuffle(IoProxy(*dst), iterFactor, &rng0);
        if (rng != nullptr)
            *rng = rng0.state;
    });
}

CVAPI(ExceptionStatus) core_kmeans(
    const interop::InputArrayProxy* data,
    int k,
    const interop::InputOutputArrayProxy* bestLabels,
    interop::TermCriteria criteria,
    int attempts,
    int flags,
    const interop::OutputArrayProxy* centers,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::kmeans(InProxy(*data), k, IoProxy(*bestLabels), cpp(criteria), attempts, flags, OutProxy(*centers));
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

CVAPI(ExceptionStatus) core_format(const interop::InputArrayProxy* mtx, int fmt, std::string *buf)
{
    return cvTry([&] {
        const auto formatted = cv::format(InProxy(*mtx), static_cast<cv::Formatter::FormatType>(fmt));

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

CVAPI(ExceptionStatus) core_RNG_fill(
    uint64 *state,
    const interop::InputOutputArrayProxy* mat,
    int distType,
    const interop::InputArrayProxy* a,
    const interop::InputArrayProxy* b,
    int saturateRange)
{
    return cvTry([&] {
        cv::RNG rng(*state);
        rng.fill(IoProxy(*mat), distType, InProxy(*a), InProxy(*b), saturateRange != 0);
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
