/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_RNG_H_
#define _CPP_CORE_RNG_H_

#include "include_opencv.h"

CVAPI(uint64) core_RNG_new1()
{
	cv::RNG rng;
	return rng.state;
}
CVAPI(uint64) core_RNG_new2(uint64 state)
{
	cv::RNG rng(state);
	return rng.state;
}


//! updates the state and returns the next 32-bit unsigned integer random number
CVAPI(uint32) core_RNG_next(uint64 state)
{
	cv::RNG rng(state);
	return rng.next();
}

CVAPI(uchar) core_RNG_operator_uchar(uint64 state)
{
	cv::RNG rng(state);
	return (uchar)rng;
}
CVAPI(schar) core_RNG_operator_schar(uint64 state)
{
	cv::RNG rng(state);
	return (schar)rng;
}
CVAPI(ushort) core_RNG_operator_ushort(uint64 state)
{
	cv::RNG rng(state);
	return (ushort)rng;
}
CVAPI(short) core_RNG_operator_short(uint64 state)
{
	cv::RNG rng(state);
	return (short)rng;
}
CVAPI(uint32) core_RNG_operator_uint(uint64 state)
{
	cv::RNG rng(state);
	return (uint32)rng;
}
//! returns a random integer sampled uniformly from [0, N).
CVAPI(uint32) core_RNG_operatorThis1(uint64 state, uint32 n)
{
	cv::RNG rng(state);
	return rng(n);
}
CVAPI(uint32) core_RNG_operatorThis2(uint64 state)
{
	cv::RNG rng(state);
	return rng();
}
CVAPI(int) core_RNG_operator_int(uint64 state)
{
	cv::RNG rng(state);
	return (int)rng;
}
CVAPI(float) core_RNG_operator_float(uint64 state)
{
	cv::RNG rng(state);
	return (float)rng;
}
CVAPI(double) core_RNG_operator_double(uint64 state)
{
	cv::RNG rng(state);
	return (double)rng;
}
//! returns uniformly distributed integer random number from [a,b) range
CVAPI(int) core_RNG_uniform_int(uint64 state, int a, int b)
{
	cv::RNG rng(state);
	return rng.uniform(a, b);
}
//! returns uniformly distributed floating-point random number from [a,b) range
CVAPI(float) core_RNG_uniform_float(uint64 state, float a, float b)
{
	cv::RNG rng(state);
	return rng.uniform(a, b);
}
//! returns uniformly distributed double-precision floating-point random number from [a,b) range
CVAPI(double) core_RNG_uniform_double(uint64 state, double a, double b)
{
	cv::RNG rng(state);
	return rng.uniform(a, b);
}
CVAPI(void) core_RNG_fill(uint64 state, cv::_OutputArray *mat, int distType, cv::_InputArray *a, cv::_InputArray *b, int saturateRange)
{
	cv::RNG rng(state);
	rng.fill(*mat, distType, *a, *b, saturateRange != 0);
}
//! returns Gaussian random variate with mean zero.
CVAPI(double) core_RNG_gaussian(uint64 state, double sigma)
{
	cv::RNG rng(state);
	return rng.gaussian(sigma);
}

#endif