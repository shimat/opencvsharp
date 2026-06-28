#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_Algorithm_write(cv::Algorithm *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
    obj->write(*fs);
    });
}

CVAPI(ExceptionStatus) core_Algorithm_read(cv::Algorithm *obj, cv::FileNode *fn)
{
    return cvTry([&] {
    obj->read(*fn);
    });
}

CVAPI(ExceptionStatus) core_Algorithm_empty(cv::Algorithm *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->empty() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_Algorithm_save(cv::Algorithm *obj, const char *filename)
{
    return cvTry([&] {
    obj->save(filename);
    });
}

CVAPI(ExceptionStatus) core_Algorithm_getDefaultName(cv::Algorithm *obj, std::string *buf)
{
    return cvTry([&] {
    buf->assign(obj->getDefaultName());
    });
}
