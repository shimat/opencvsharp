/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVMLDATA_H_
#define _CVMLDATA_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

CVAPI(int) CvMLData_sizeof()
{
	return sizeof(CvMLData);
}

CVAPI(CvMLData*) CvMLData_construct()
{
	return new CvMLData();
}  
CVAPI(void) CvMLData_destruct(CvMLData* obj)
{
	delete obj;
}


CVAPI(int) CvMLData_read_csv(CvMLData* obj, const char* filename)
{
	return obj->read_csv(filename);
}
CVAPI(const CvMat*) CvMLData_get_values(CvMLData* obj)
{
	return obj->get_values();
}
CVAPI(const CvMat*) CvMLData_get_responses(CvMLData* obj)
{
	return obj->get_responses();
}
CVAPI(const CvMat*) CvMLData_get_missing(CvMLData* obj)
{
	return obj->get_missing();
}
CVAPI(void) CvMLData_set_response_idx(CvMLData* obj, int idx)
{
	obj->set_response_idx(idx);
}
CVAPI(int) CvMLData_get_response_idx(CvMLData* obj)
{
	return obj->get_response_idx();
}
CVAPI(const CvMat*) CvMLData_get_train_sample_idx(CvMLData* obj)
{
	return obj->get_train_sample_idx();
}
CVAPI(const CvMat*) CvMLData_get_test_sample_idx(CvMLData* obj)
{
	return obj->get_test_sample_idx();
}
CVAPI(void) CvMLData_mix_train_and_test_idx(CvMLData* obj)
{
	obj->mix_train_and_test_idx();
}
CVAPI(void) CvMLData_set_train_test_split(CvMLData* obj, const CvTrainTestSplit* spl)
{
	obj->set_train_test_split(spl);
}
CVAPI(const CvMat*) CvMLData_get_var_idx(CvMLData* obj)
{
	return obj->get_var_idx();
}
CVAPI(void) CvMLData_change_var_idx(CvMLData* obj, int vi, bool state)
{
	obj->chahge_var_idx(vi, state);
}
CVAPI(const CvMat*) CvMLData_get_var_types(CvMLData* obj)
{
	return obj->get_var_types();
}
CVAPI(int) CvMLData_get_var_type(CvMLData* obj, int var_idx)
{
	return obj->get_var_type(var_idx);
}
CVAPI(void) CvMLData_set_var_types(CvMLData* obj, const char* str)
{
	obj->set_var_types(str);
}
CVAPI(void) CvMLData_change_var_type(CvMLData* obj, int var_idx, int type)
{
	obj->change_var_type(var_idx, type);
}
CVAPI(void) CvMLData_set_delimiter(CvMLData* obj, char ch)
{
	obj->set_delimiter(ch);
}
CVAPI(char) CvMLData_get_delimiter(CvMLData* obj)
{
	return obj->get_delimiter();
}
CVAPI(void) CvMLData_set_miss_ch(CvMLData* obj, char ch)
{
	obj->set_miss_ch(ch);
}
CVAPI(char) CvMLData_get_miss_ch(CvMLData* obj)
{
	return obj->get_miss_ch();
}

#endif