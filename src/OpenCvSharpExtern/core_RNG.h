#ifndef _CPP_CORE_RNG_H_
#define _CPP_CORE_RNG_H_

#include "include_opencv.h"

CVAPI(void) core_RNG_fill(uint64 *state, cv::_InputOutputArray *mat, int distType, cv::_InputArray *a, cv::_InputArray *b, int saturateRange)
{
    cv::RNG rng(*state);
    rng.fill(*mat, distType, *a, *b, saturateRange != 0);
    *state = rng.state;
}
//! returns Gaussian random variate with mean zero.
CVAPI(double) core_RNG_gaussian(uint64 *state, double sigma)
{
    cv::RNG rng(*state);
    double result = rng.gaussian(sigma);
    *state = rng.state;
    return result;
}

#endif