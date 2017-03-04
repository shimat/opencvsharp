#ifndef _CPP_CORE_ALGORITHM_H_
#define _CPP_CORE_ALGORITHM_H_

#include "include_opencv.h"

CVAPI(void) core_Algorithm_write(cv::Algorithm *obj, cv::FileStorage *fs)
{
    obj->write(*fs);
}

CVAPI(void) core_Algorithm_read(cv::Algorithm *obj, cv::FileNode *fn)
{
    obj->read(*fn);
}

CVAPI(int) core_Algorithm_empty(cv::Algorithm *obj)
{
    return obj->empty() ? 1 : 0;
}

CVAPI(void) core_Algorithm_save(cv::Algorithm *obj, const char *filename)
{
    obj->save(filename);
}

CVAPI(void) core_Algorithm_getDefaultName(cv::Algorithm *obj, char *buf, int bufLength)
{
    cv::String str = obj->getDefaultName();
    copyString(str, buf, bufLength);
}

#endif