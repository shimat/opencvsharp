#ifndef _CPP_ML_CVMLDATA_H_
#define _CPP_ML_CVMLDATA_H_

#include "include_opencv.h"

CVAPI(CvMLData*) ml_CvMLData_new()
{
	return new CvMLData();
}  
CVAPI(void) ml_CvMLData_delete(CvMLData* obj)
{
	delete obj;
}


CVAPI(int) ml_CvMLData_read_csv(CvMLData* obj, const char* filename)
{
	return obj->read_csv(filename);
}
CVAPI(const CvMat*) ml_CvMLData_get_values(CvMLData* obj)
{
	return obj->get_values();
}
CVAPI(const CvMat*) ml_CvMLData_get_responses(CvMLData* obj)
{
	return obj->get_responses();
}
CVAPI(const CvMat*) ml_CvMLData_get_missing(CvMLData* obj)
{
	return obj->get_missing();
}
CVAPI(void) ml_CvMLData_set_response_idx(CvMLData* obj, int idx)
{
	obj->set_response_idx(idx);
}
CVAPI(int) ml_CvMLData_get_response_idx(CvMLData* obj)
{
	return obj->get_response_idx();
}
CVAPI(const CvMat*) ml_CvMLData_get_train_sample_idx(CvMLData* obj)
{
	return obj->get_train_sample_idx();
}
CVAPI(const CvMat*) ml_CvMLData_get_test_sample_idx(CvMLData* obj)
{
	return obj->get_test_sample_idx();
}
CVAPI(void) ml_CvMLData_mix_train_and_test_idx(CvMLData* obj)
{
	obj->mix_train_and_test_idx();
}
CVAPI(void) ml_CvMLData_set_train_test_split(CvMLData* obj, const CvTrainTestSplit* spl)
{
	obj->set_train_test_split(spl);
}
CVAPI(const CvMat*) ml_CvMLData_get_var_idx(CvMLData* obj)
{
	return obj->get_var_idx();
}
CVAPI(void) ml_CvMLData_change_var_idx(CvMLData* obj, int vi, int state)
{
	obj->chahge_var_idx(vi, state != 0);
}
CVAPI(const CvMat*) ml_CvMLData_get_var_types(CvMLData* obj)
{
	return obj->get_var_types();
}
CVAPI(int) ml_CvMLData_get_var_type(CvMLData* obj, int var_idx)
{
	return obj->get_var_type(var_idx);
}
CVAPI(void) ml_CvMLData_set_var_types(CvMLData* obj, const char* str)
{
	obj->set_var_types(str);
}
CVAPI(void) ml_CvMLData_change_var_type(CvMLData* obj, int var_idx, int type)
{
	obj->change_var_type(var_idx, type);
}
CVAPI(void) ml_CvMLData_set_delimiter(CvMLData* obj, char ch)
{
	obj->set_delimiter(ch);
}
CVAPI(char) ml_CvMLData_get_delimiter(CvMLData* obj)
{
	return obj->get_delimiter();
}
CVAPI(void) ml_CvMLData_set_miss_ch(CvMLData* obj, char ch)
{
	obj->set_miss_ch(ch);
}
CVAPI(char) ml_CvMLData_get_miss_ch(CvMLData* obj)
{
	return obj->get_miss_ch();
}

#endif