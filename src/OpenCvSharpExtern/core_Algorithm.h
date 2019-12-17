#ifndef _CPP_CORE_ALGORITHM_H_
#define _CPP_CORE_ALGORITHM_H_

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_Algorithm_write(cv::Algorithm *obj, cv::FileStorage *fs)
{
    BEGIN_WRAP
    obj->write(*fs);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Algorithm_read(cv::Algorithm *obj, cv::FileNode *fn)
{
    BEGIN_WRAP
    obj->read(*fn);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Algorithm_empty(cv::Algorithm *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Algorithm_save(cv::Algorithm *obj, const char *filename)
{
    BEGIN_WRAP
    obj->save(filename);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Algorithm_getDefaultName(cv::Algorithm *obj, std::string *buf)
{
    BEGIN_WRAP
    buf->assign(obj->getDefaultName());
    END_WRAP
}

#endif