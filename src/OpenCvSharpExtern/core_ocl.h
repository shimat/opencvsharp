#pragma once

#include "include_opencv.h"
#include <opencv2/core/ocl.hpp>

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

using OclPlatformInfoVector = std::vector<cv::ocl::PlatformInfo>;

CVAPI(ExceptionStatus) core_ocl_haveOpenCL(int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::ocl::haveOpenCL() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_ocl_useOpenCL(int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::ocl::useOpenCL() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_ocl_setUseOpenCL(int flag)
{
    return cvTry([&] {
        cv::ocl::setUseOpenCL(flag != 0);
    });
}

CVAPI(ExceptionStatus) core_ocl_finish()
{
    return cvTry([] {
        cv::ocl::finish();
    });
}

CVAPI(ExceptionStatus) core_ocl_getPlatformsInfo(OclPlatformInfoVector** returnValue)
{
    return cvTry([&] {
        auto platformInfo = std::make_unique<OclPlatformInfoVector>();
        cv::ocl::getPlatfomsInfo(*platformInfo);
        *returnValue = platformInfo.release();
    });
}

CVAPI(ExceptionStatus) core_ocl_PlatformInfoVector_delete(OclPlatformInfoVector* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) core_ocl_PlatformInfoVector_size(OclPlatformInfoVector* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->size());
    });
}

CVAPI(ExceptionStatus) core_ocl_PlatformInfoVector_getPlatform(
    OclPlatformInfoVector* obj,
    int platformIndex,
    std::string* name,
    std::string* vendor,
    std::string* version,
    int* versionMajor,
    int* versionMinor,
    int* deviceCount)
{
    return cvTry([&] {
        const auto& platform = obj->at(static_cast<size_t>(platformIndex));
        name->assign(platform.name());
        vendor->assign(platform.vendor());
        version->assign(platform.version());
        *versionMajor = platform.versionMajor();
        *versionMinor = platform.versionMinor();
        *deviceCount = platform.deviceNumber();
    });
}

CVAPI(ExceptionStatus) core_ocl_PlatformInfoVector_getDevice(
    OclPlatformInfoVector* obj,
    int platformIndex,
    int deviceIndex,
    std::string* name,
    std::string* vendorName,
    std::string* version,
    std::string* openCLVersion,
    std::string* openCLCVersion,
    std::string* driverVersion,
    int* type,
    int* addressBits,
    int* available,
    int* compilerAvailable,
    int* linkerAvailable,
    int* maxClockFrequency,
    int* maxComputeUnits,
    uint64_t* globalMemorySize,
    uint64_t* localMemorySize,
    int* hostUnifiedMemory,
    int* imageSupport)
{
    return cvTry([&] {
        const auto& platform = obj->at(static_cast<size_t>(platformIndex));
        cv::ocl::Device device;
        platform.getDevice(device, deviceIndex);

        name->assign(device.name());
        vendorName->assign(device.vendorName());
        version->assign(device.version());
        openCLVersion->assign(device.OpenCLVersion());
        openCLCVersion->assign(device.OpenCL_C_Version());
        driverVersion->assign(device.driverVersion());
        *type = device.type();
        *addressBits = device.addressBits();
        *available = device.available() ? 1 : 0;
        *compilerAvailable = device.compilerAvailable() ? 1 : 0;
        *linkerAvailable = device.linkerAvailable() ? 1 : 0;
        *maxClockFrequency = device.maxClockFrequency();
        *maxComputeUnits = device.maxComputeUnits();
        *globalMemorySize = static_cast<uint64_t>(device.globalMemSize());
        *localMemorySize = static_cast<uint64_t>(device.localMemSize());
        *hostUnifiedMemory = device.hostUnifiedMemory() ? 1 : 0;
        *imageSupport = device.imageSupport() ? 1 : 0;
    });
}
