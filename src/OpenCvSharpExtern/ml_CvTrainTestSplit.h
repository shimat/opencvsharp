#ifndef _CPP_ML_CVTRAINTESTSPLIT_H_
#define _CPP_ML_CVTRAINTESTSPLIT_H_

#include "include_opencv.h"

CVAPI(CvTrainTestSplit*) ml_CvTrainTestSplit_new1()
{
	return new CvTrainTestSplit();
}  
CVAPI(CvTrainTestSplit*) ml_CvTrainTestSplit_new2(int trainSampleCount, int mix)
{
    return new CvTrainTestSplit(trainSampleCount, mix != 0);
}  
CVAPI(CvTrainTestSplit*) ml_CvTrainTestSplit_new3(float trainSamplePortion, int mix)
{
    return new CvTrainTestSplit(trainSamplePortion, mix != 0);
}  
CVAPI(void) ml_CvTrainTestSplit_delete(CvTrainTestSplit* obj)
{
	delete obj;
}

CVAPI(int) ml_CvTrainTestSplit_train_sample_part_count_get(CvTrainTestSplit* obj)
{
	return obj->train_sample_part.count;
} 
CVAPI(void) ml_CvTrainTestSplit_train_sample_part_count_set(CvTrainTestSplit* obj, int value)
{
	obj->train_sample_part.count = value;
} 
CVAPI(float) ml_CvTrainTestSplit_train_sample_part_portion_get(CvTrainTestSplit* obj)
{
	return obj->train_sample_part.portion;
} 
CVAPI(void) ml_CvTrainTestSplit_train_sample_part_portion_set(CvTrainTestSplit* obj, float value)
{
	obj->train_sample_part.portion = value;
} 
CVAPI(int) ml_CvTrainTestSplit_train_sample_part_mode_get(CvTrainTestSplit* obj)
{
	return obj->train_sample_part_mode;
} 
CVAPI(void) ml_CvTrainTestSplit_train_sample_part_mode_set(CvTrainTestSplit* obj, int value)
{
	obj->train_sample_part_mode = value;
} 
CVAPI(int) ml_CvTrainTestSplit_mix_Get(CvTrainTestSplit* obj)
{
	return obj->mix ? 1 : 0;
} 
CVAPI(void) ml_CvTrainTestSplit_mix_set(CvTrainTestSplit* obj, int value)
{
	obj->mix = (value != 0);
}

#endif