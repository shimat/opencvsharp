#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaarithm.hpp>

// ---------- abs ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_abs(cv::_InputArray *src,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::abs(*src, *dst, streamRef);
    END_WRAP
}

// ---------- absdiff ------------------------------------------------------
CVAPI(ExceptionStatus) cuda_absdiff(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::absdiff(*src1, *src2, *dst, streamRef);
    END_WRAP
}

// ---------- absdiff ------------------------------------------------------
CVAPI(ExceptionStatus) cuda_absdiffWithScalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::absdiff(*src1, src2, *dst, streamRef);
    END_WRAP
}

// ---------- absSum ------------------------------------------------------
CVAPI(ExceptionStatus) cuda_absSum(cv::_InputArray *src, cv::_InputArray *mask,  cv::Scalar *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::absSum(*src, mask ? *mask : cv::noArray());
    END_WRAP
}

// ---------- add ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_add(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::add(*src1, *src2, *dst, entity(mask), dtype, streamRef);
    END_WRAP
}

// ---------- addWeighted --------------------------------------------------
CVAPI(ExceptionStatus) cuda_addWeighted(cv::_InputArray *src1, double alpha,cv::_InputArray *src2, double beta, double gamma,cv::_OutputArray *dst, int dtype,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::addWeighted(*src1, alpha, *src2, beta, gamma, *dst, dtype, streamRef);
    END_WRAP
}

// ---------- Add with Scalar --------------------------------------------------
CVAPI(ExceptionStatus) cuda_addWithScalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::add(*src1, src2, *dst, mask ? *mask : cv::noArray(), dtype, streamRef);
    END_WRAP
}


// ---------- bitwise_and --------------------------------------------------
CVAPI(ExceptionStatus) cuda_bitwise_and(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,cv::_InputArray *mask,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bitwise_and(*src1, *src2, *dst, entity(mask), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_bitwise_and_with_scalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bitwise_and(*src1, src2, *dst, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

// ---------- bitwise_not --------------------------------------------------
CVAPI(ExceptionStatus) cuda_bitwise_not(cv::_InputArray *src,cv::_OutputArray *dst,cv::_InputArray *mask,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bitwise_not(*src, *dst, entity(mask), streamRef);
    END_WRAP
}

// ---------- bitwise_or ---------------------------------------------------
CVAPI(ExceptionStatus) cuda_bitwise_or(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,cv::_InputArray *mask,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bitwise_or(*src1, *src2, *dst, entity(mask), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_bitwise_or_with_scalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst,  cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bitwise_or(*src1, src2, *dst, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

// ---------- bitwise_xor --------------------------------------------------
CVAPI(ExceptionStatus) cuda_bitwise_xor(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,cv::_InputArray *mask,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bitwise_xor(*src1, *src2, *dst, entity(mask), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_bitwise_xor_with_scalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst,  cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::bitwise_xor(*src1, src2, *dst, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

// ---------- calcAbsSum --------------------------------------------------
CVAPI(ExceptionStatus) cuda_calcAbsSum(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::calcAbsSum(*src, *dst, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

// ---------- calcSqrSum --------------------------------------------------
CVAPI(ExceptionStatus) cuda_calcSqrSum(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::calcSqrSum(*src, *dst, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

// ---------- calcSum --------------------------------------------------
CVAPI(ExceptionStatus) cuda_calcSum(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::calcSum(*src, *dst, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

// ---------- calcNorm --------------------------------------------------
CVAPI(ExceptionStatus) cuda_calcNorm(
    cv::_InputArray *src, cv::_OutputArray *dst, int normType, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::calcNorm(*src, *dst, normType, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

// ---------- calcNormDiff --------------------------------------------------
CVAPI(ExceptionStatus) cuda_calcNormDiff(
    cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int normType, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::calcNormDiff(*src1, *src2, *dst, normType, streamRef);
    END_WRAP
}

// ---------- cartToPolar --------------------------------------------------
CVAPI(ExceptionStatus) cuda_cartToPolar(cv::_InputArray *x,cv::_InputArray *y,cv::_OutputArray *magnitude,cv::_OutputArray *angle,    int angleInDegrees,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::cartToPolar(*x, *y, *magnitude, *angle, angleInDegrees != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_cartToPolar_interleaved(cv::_InputArray *xy, cv::_OutputArray *magnitude, cv::_OutputArray *angle, int angleInDegrees, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::cartToPolar(*xy, *magnitude, *angle, angleInDegrees != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_cartToPolar_interleaved_combined(cv::_InputArray *xy, cv::_OutputArray *magnitudeAngle, int angleInDegrees, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::cartToPolar(*xy, *magnitudeAngle, angleInDegrees != 0, streamRef);
    END_WRAP
}

// ---------- compare ------------------------------------------------------
CVAPI(ExceptionStatus) cuda_compare(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst, int cmpop,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::compare(*src1, *src2, *dst, cmpop, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_compareWithScalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, int cmpop, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::compare(*src1, src2, *dst, cmpop, streamRef);
    END_WRAP
}


// ---------- copyMakeborder ------------------------------------------------------
CVAPI(ExceptionStatus) cuda_copyMakeBorder(
    cv::_InputArray *src, cv::_OutputArray *dst, int top, int bottom, int left, int right, int borderType, cv::Scalar value, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::copyMakeBorder(*src, *dst, top, bottom, left, right, borderType, value, streamRef);
    END_WRAP
}
// ---------- copyMakeborder ------------------------------------------------------
CVAPI(ExceptionStatus) cuda_countNonZero_int( cv::_InputArray *src, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::countNonZero(*src);
    END_WRAP
}

// ---------- copyMakeborder ------------------------------------------------------
CVAPI(ExceptionStatus) cuda_countNonZero_dst( cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::countNonZero(*src, *dst, streamRef);
    END_WRAP
}
// ---------- divide -------------------------------------------------------
CVAPI(ExceptionStatus) cuda_divide(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,    double scale,    int dtype,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::divide(*src1, *src2, *dst, scale, dtype, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_divideWithScalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, double scale, int dtype, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::divide(*src1, src2, *dst, scale, dtype, streamRef);
    END_WRAP
}

// ---------- exp ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_exp(cv::_InputArray *src,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::exp(*src, *dst, streamRef);
    END_WRAP
}

// ---------- log ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_log(cv::_InputArray *src,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::log(*src, *dst, streamRef);
    END_WRAP
}

// ---------- lshift -------------------------------------------------------
CVAPI(ExceptionStatus) cuda_lshift(cv::_InputArray *src, cv::Scalar val, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::lshift(*src, val, *dst, streamRef);
    END_WRAP
}

// ---------- magnitude (complex form) ------------------------------------
CVAPI(ExceptionStatus) cuda_magnitude_1(cv::_InputArray *xy,cv::_OutputArray *magnitude,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::magnitude(*xy, *magnitude, streamRef);
    END_WRAP
}

// ---------- magnitude (separate x/y) ------------------------------------
CVAPI(ExceptionStatus) cuda_magnitude_2(cv::_InputArray *x,cv::_InputArray *y,cv::_OutputArray *magnitude,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::magnitude(*x, *y, *magnitude, streamRef);
    END_WRAP
}

// ---------- magnitudeSqr (complex form) ---------------------------------
CVAPI(ExceptionStatus) cuda_magnitudeSqr_1(cv::_InputArray *xy,cv::_OutputArray *magnitude,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::magnitudeSqr(*xy, *magnitude, streamRef);
    END_WRAP
}

// ---------- magnitudeSqr (separate x/y) ---------------------------------
CVAPI(ExceptionStatus) cuda_magnitudeSqr_2(cv::_InputArray *x,cv::_InputArray *y,cv::_OutputArray *magnitude,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::magnitudeSqr(*x, *y, *magnitude, streamRef);
    END_WRAP
}

// ---------- max ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_max(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::max(*src1, *src2, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_maxWithScalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::max(*src1, src2, *dst, streamRef);
    END_WRAP
}

// ---------- min ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_min(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::min(*src1, *src2, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_minWithScalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::min(*src1, src2, *dst, streamRef);
    END_WRAP
}

// ---------- multiply -----------------------------------------------------
CVAPI(ExceptionStatus) cuda_multiply(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,    double scale,    int dtype,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::multiply(*src1, *src2, *dst, scale, dtype, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_multiplyWithScalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, double scale, int dtype, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::multiply(*src1, src2, *dst, scale, dtype, streamRef);
    END_WRAP
}

// ---------- phase --------------------------------------------------------
CVAPI(ExceptionStatus) cuda_phase(cv::_InputArray *x,cv::_InputArray *y,cv::_OutputArray *angle,    int angleInDegrees,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::phase(*x, *y, *angle, angleInDegrees != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_phase_xy(cv::_InputArray *xy, cv::_OutputArray *angle, int angleInDegrees, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::phase(*xy, *angle, angleInDegrees != 0, streamRef);
    END_WRAP
}

// ---------- polarToCart --------------------------------------------------
CVAPI(ExceptionStatus) cuda_polarToCart(cv::_InputArray *magnitude, cv::_InputArray *angle, cv::_OutputArray *x, cv::_OutputArray *y, int angleInDegrees, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::polarToCart(*magnitude, *angle, *x, *y, angleInDegrees != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_polarToCart_interleaved_out( cv::_InputArray *magnitude, cv::_InputArray *angle, cv::_OutputArray *xy, int angleInDegrees, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::polarToCart(*magnitude, *angle, *xy, angleInDegrees != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_polarToCart_interleaved_inout(cv::_InputArray *magnitudeAngle, cv::_OutputArray *xy, int angleInDegrees, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::polarToCart(*magnitudeAngle, *xy, angleInDegrees != 0, streamRef);
    END_WRAP
}

// ---------- pow ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_pow( cv::_InputArray *src, double power,  cv::_OutputArray *dst,  cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::pow(*src, power, *dst, streamRef);
    END_WRAP
}

// ---------- rshift -------------------------------------------------------
CVAPI(ExceptionStatus) cuda_rshift(cv::_InputArray *src, cv::Scalar val, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::rshift(*src, val, *dst, streamRef);
    END_WRAP
}

// ---------- scaleAdd -----------------------------------------------------
CVAPI(ExceptionStatus) cuda_scaleAdd(cv::_InputArray *src1,    double alpha,cv::_InputArray *src2,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::scaleAdd(*src1, alpha, *src2, *dst, streamRef);
    END_WRAP
}

// ---------- sqr ----------------------------------------------------------
CVAPI(ExceptionStatus) cuda_sqr(cv::_InputArray *src,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::sqr(*src, *dst, streamRef);
    END_WRAP
}

// ---------- sqrt ---------------------------------------------------------
CVAPI(ExceptionStatus) cuda_sqrt(cv::_InputArray *src,cv::_OutputArray *dst,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::sqrt(*src, *dst, streamRef);
    END_WRAP
}

// ---------- subtract -----------------------------------------------------
CVAPI(ExceptionStatus) cuda_subtract(cv::_InputArray *src1,cv::_InputArray *src2,cv::_OutputArray *dst,cv::_InputArray *mask,    int dtype,cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::subtract(*src1, *src2, *dst, entity(mask), dtype, streamRef);
    END_WRAP
}

// ---------- threshold ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_threshold(cv::_InputArray *src,cv::_OutputArray *dst,    double thresh,    double maxval,    int type,cv::cuda::Stream *stream,    double *retVal)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    *retVal = cv::cuda::threshold(*src, *dst, thresh, maxval, type, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_dft(cv::_InputArray *src, cv::_OutputArray *dst, cv::Size dft_size, int flags, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::dft(*src, *dst, dft_size, flags, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_findMinMax(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::findMinMax(*src, *dst, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_findMinMaxLoc(cv::_InputArray *src, cv::_OutputArray *minMaxVals, cv::_OutputArray *loc,
    cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::findMinMaxLoc(*src, *minMaxVals, *loc, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_flip(cv::_InputArray *src, cv::_OutputArray *dst, int flipCode, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::flip(*src, *dst, flipCode, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_gemm(cv::_InputArray *src1, cv::_InputArray *src2, double alpha, cv::_InputArray *src3, double beta, cv::_OutputArray *dst, int flags, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::gemm(*src1, *src2, alpha, src3 ? *src3 : cv::noArray(), beta, *dst, flags, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_integral(cv::_InputArray *src, cv::_OutputArray *sum, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::integral(*src, *sum, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_meanStdDev_dst(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::meanStdDev(*src, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_meanStdDev_dst_mask(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::meanStdDev(*src, *dst, *mask, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_meanStdDev_scalar(
    cv::_InputArray *src, cv::Scalar *mean, cv::Scalar *stddev)
{
    BEGIN_WRAP
    cv::cuda::meanStdDev(*src, *mean, *stddev);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_meanStdDev_scalar_mask(
    cv::_InputArray *src, cv::Scalar *mean, cv::Scalar *stddev, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::cuda::meanStdDev(*src, *mean, *stddev, *mask);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_merge(cv::cuda::GpuMat **src, size_t n, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    std::vector<cv::cuda::GpuMat> src_vec;
    src_vec.reserve(n);
    for (size_t i = 0; i < n; i++)
    {
        src_vec.push_back(*src[i]);
    }
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::merge(src_vec, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_minMax(cv::_InputArray *src, double *minVal, double *maxVal, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::cuda::minMax(*src, minVal, maxVal, mask ? *mask : cv::noArray());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_minMaxLoc(cv::_InputArray *src, double *minVal, double *maxVal, cv::Point *minLoc, cv::Point *maxLoc, cv::_InputArray *mask)
{
    BEGIN_WRAP
    cv::cuda::minMaxLoc(*src, minVal, maxVal, minLoc, maxLoc, mask ? *mask : cv::noArray());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_mulSpectrums(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int flags, int conjB, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::mulSpectrums(*src1, *src2, *dst, flags, conjB != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_mulAndScaleSpectrums(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, int flags, float scale, int conjB, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::mulAndScaleSpectrums(*src1, *src2, *dst, flags, scale, conjB != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_norm1(cv::_InputArray *src1, int normType, cv::_InputArray *mask, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::norm(*src1, normType, mask ? *mask : cv::noArray());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_norm2(cv::_InputArray *src1, cv::_InputArray *src2, int normType, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::norm(*src1, *src2, normType);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_normalize(cv::_InputArray *src, cv::_OutputArray *dst, double alpha, double beta, int norm_type, int dtype, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::normalize(*src, *dst, alpha, beta, norm_type, dtype, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_rectStdDev(cv::_InputArray *src, cv::_InputArray *sqr, cv::_OutputArray *dst, cv::Rect rect, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::rectStdDev(*src, *sqr, *dst, rect, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_reduce(cv::_InputArray *mtx, cv::_OutputArray *vec, int dim, int reduceOp, int dtype, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::reduce(*mtx, *vec, dim, reduceOp, dtype, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_split(cv::_InputArray *src, cv::cuda::GpuMat **dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    int cn = src->channels();
    std::vector<cv::cuda::GpuMat> dst_vec;

    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::split(*src, dst_vec, streamRef);

    // Copy the resulting GpuMat objects from the vector
    // back into the pointers provided by C#
    for (int i = 0; i < cn; i++)
    {
        *dst[i] = dst_vec[i];
    }
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_sqrIntegral(cv::_InputArray *src, cv::_OutputArray *sqsum, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::sqrIntegral(*src, *sqsum, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_sqrSum(cv::_InputArray *src, cv::_InputArray *mask, cv::Scalar *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::sqrSum(*src, mask ? *mask : cv::noArray());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_subtract_scalar(cv::_InputArray *src1, cv::Scalar src2, cv::_OutputArray *dst, cv::_InputArray *mask, int dtype, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::subtract(*src1, src2, *dst, mask ? *mask : cv::noArray(), dtype, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_sum(cv::_InputArray *src, cv::_InputArray *mask, cv::Scalar *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::sum(*src, mask ? *mask : cv::noArray());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_transpose(cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::transpose(*src, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_inRange(cv::_InputArray *src, cv::Scalar lowerb, cv::Scalar upperb, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::inRange(*src, lowerb, upperb, *dst, streamRef);
    END_WRAP
}
