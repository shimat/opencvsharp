#ifndef _CPP_ML_BOOST_H_
#define _CPP_ML_BOOST_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(int) ml_Boost_getBoostType(Boost *obj)
{
	return obj->getBoostType();
}
CVAPI(void) ml_Boost_setBoostType(Boost *obj, int val)
{
	obj->setBoostType(val);
}

CVAPI(int) ml_Boost_getWeakCount(Boost *obj)
{
	return obj->getWeakCount();
}
CVAPI(void) ml_Boost_setWeakCount(Boost *obj, int val)
{
	obj->setWeakCount(val);
}

CVAPI(double) ml_Boost_getWeightTrimRate(Boost *obj)
{
	return obj->getWeightTrimRate();
}
CVAPI(void) ml_Boost_setWeightTrimRate(Boost *obj, double val)
{
	obj->setWeightTrimRate(val);
}


CVAPI(cv::Ptr<Boost>*) ml_Boost_create()
{
	cv::Ptr<Boost> ptr = Boost::create();
	return new cv::Ptr<Boost>(ptr);
}

CVAPI(void) ml_Ptr_Boost_delete(cv::Ptr<Boost> *obj)
{
	delete obj;
}

CVAPI(Boost*) ml_Ptr_Boost_get(cv::Ptr<Boost>* obj)
{
	return obj->get();
}

#endif
