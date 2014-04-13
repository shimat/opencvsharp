/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_ML_CVSTATMODEL_H_
#define _CPP_ML_CVSTATMODEL_H_

#include "include_opencv.h"

CVAPI(cv::StatModel*) ml_StatModel_new()
{
    return new cv::StatModel();
}

CVAPI(void) ml_StatModel_delete(cv::StatModel *obj)
{
    delete obj;
}

CVAPI(void) ml_StatModel_clear(cv::StatModel *obj)
{
    obj->clear();
}

CVAPI(void) ml_StatModel_save(cv::StatModel *obj, const char* filename, const char *name)
{
    obj->save(filename, name);
}

CVAPI(void) ml_StatModel_load(cv::StatModel *obj, const char* filename, const char *name)
{
    obj->load(filename, name);
}

CVAPI(void) ml_StatModel_read(cv::StatModel *obj, CvFileStorage *storage, CvFileNode *node)
{
    obj->read(storage, node);
}

CVAPI(void) ml_StatModel_write(cv::StatModel *obj, CvFileStorage *storage, const char *name)
{
    obj->write(storage, name);
}

#endif
