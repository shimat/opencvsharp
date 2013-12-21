/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVSTATMODEL_H_
#define _CVSTATMODEL_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

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
