/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WGPU_H_
#define _CPP_WGPU_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>
#include <opencv2/gpu/gpu.hpp>


CVAPI(int) getCudaEnabledDeviceCount()
{
	return cv::gpu::getCudaEnabledDeviceCount();
}

/*
CVAPI(void) getDeviceName(int device, char* buffer)
{
	std::string str = cv::gpu::getDeviceName(device);
	std::strcpy(buffer, str.c_str());
}
*/
CVAPI(void) setDevice(int device)
{
	cv::gpu::setDevice(device);
}
CVAPI(int) getDevice()
{
	return cv::gpu::getDevice();
}
/*
CVAPI(void) getComputeCapability(int device, int* major, int* minor)
{
	cv::gpu::getComputeCapability(device, *major, *minor);
}
CVAPI(int) getNumberOfSMs(int device)
{
	return cv::gpu::getNumberOfSMs(device);
}
CVAPI(void) getGpuMemInfo(uint64* free, uint64* total)
{
	size_t free_, total_;
	cv::gpu::getGpuMemInfo(free_, total_);
	*free = free_;
	*total = total_;
}
CVAPI(int) hasNativeDoubleSupport(int device)
{
	return cv::gpu::hasNativeDoubleSupport(device) ? 1 : 0;
}
CVAPI(int) hasAtomicsSupport(int device)
{
	return cv::gpu::hasAtomicsSupport(device) ? 1 : 0;
}
*/
#endif