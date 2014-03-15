/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CVSTATMODEL_H_
#define _CVSTATMODEL_H_

#include "include_opencv.h"

CVAPI(void) CvStatModel_clear(CvStatModel* model)
{
	model->clear();
}

CVAPI(void) CvStatModel_save(CvStatModel* model, const char* filename, const char* name)
{
	model->save(filename, name);
}

CVAPI(void) CvStatModel_load(CvStatModel* model, const char* filename, const char* name)
{
	model->load(filename, name);
}

CVAPI(void) CvStatModel_read(CvStatModel* model, CvFileStorage* storage, CvFileNode* node)
{
	model->read(storage, node);
}

CVAPI(void) CvStatModel_write(CvStatModel* model, CvFileStorage* storage, const char* name)
{
	model->write(storage, name);
}

#endif
