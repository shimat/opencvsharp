/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVTRAINTESTSPLIT_H_
#define _CVTRAINTESTSPLIT_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

CVAPI(int) CvTrainTestSplit_sizeof()
{
	return sizeof(CvTrainTestSplit);
}

CVAPI(CvTrainTestSplit*) CvTrainTestSplit_construct1()
{
	return new CvTrainTestSplit();
}  
CVAPI(CvTrainTestSplit*) CvTrainTestSplit_construct2(int _train_sample_count, bool _mix)
{
	return new CvTrainTestSplit(_train_sample_count, _mix);
}  
CVAPI(CvTrainTestSplit*) CvTrainTestSplit_construct3(float _train_sample_portion, bool _mix)
{
	return new CvTrainTestSplit(_train_sample_portion, _mix);
}  
CVAPI(void) CvTrainTestSplit_destruct(CvTrainTestSplit* obj)
{
	delete obj;
}

CVAPI(int) CvTrainTestSplit_train_sample_part_count_get(CvTrainTestSplit* obj)
{
	return obj->train_sample_part.count;
} 
CVAPI(void) CvTrainTestSplit_train_sample_part_count_set(CvTrainTestSplit* obj, int value)
{
	obj->train_sample_part.count = value;
} 
CVAPI(float) CvTrainTestSplit_train_sample_part_portion_get(CvTrainTestSplit* obj)
{
	return obj->train_sample_part.portion;
} 
CVAPI(void) CvTrainTestSplit_train_sample_part_portion_set(CvTrainTestSplit* obj, float value)
{
	obj->train_sample_part.portion = value;
} 
CVAPI(int) CvTrainTestSplit_train_sample_part_mode_get(CvTrainTestSplit* obj)
{
	return obj->train_sample_part_mode;
} 
CVAPI(void) CvTrainTestSplit_train_sample_part_mode_set(CvTrainTestSplit* obj, int value)
{
	obj->train_sample_part_mode = value;
} 
CVAPI(bool) CvTrainTestSplit_mix_Get(CvTrainTestSplit* obj)
{
	return obj->mix;
} 
CVAPI(void) CvTrainTestSplit_mix_set(CvTrainTestSplit* obj, bool value)
{
	obj->mix = value;
}

#endif