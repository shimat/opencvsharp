#ifndef _CPP_ML_CVSTATMODEL_H_
#define _CPP_ML_CVSTATMODEL_H_

#include "include_opencv.h"

CVAPI(CvStatModel*) ml_CvStatModel_new()
{
    return new CvStatModel();
}

CVAPI(void) ml_CvStatModel_delete(CvStatModel *obj)
{
    delete obj;
}

CVAPI(void) ml_CvStatModel_clear(CvStatModel *obj)
{
    obj->clear();
}

CVAPI(void) ml_CvStatModel_save(CvStatModel *obj, const char* filename, const char *name)
{
    obj->save(filename, name);
}

CVAPI(void) ml_CvStatModel_load(CvStatModel *obj, const char* filename, const char *name)
{
    obj->load(filename, name);
}

CVAPI(void) ml_CvStatModel_read(CvStatModel *obj, CvFileStorage *storage, CvFileNode *node)
{
    obj->read(storage, node);
}

CVAPI(void) ml_CvStatModel_write(CvStatModel *obj, CvFileStorage *storage, const char *name)
{
    obj->write(storage, name);
}

#endif
