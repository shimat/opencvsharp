#ifndef _CPP_CORE_ALGORITHM_H_
#define _CPP_CORE_ALGORITHM_H_

#include "include_opencv.h"

CVAPI(cv::Algorithm*) core_Algorithm_new()
{
    return new cv::Algorithm();
}
CVAPI(void) core_Algorithm_delete(cv::Algorithm *obj)
{
    delete obj;
}

CVAPI(cv::Ptr<cv::Algorithm>*) core_Algorithm_create(const char *name)
{
    cv::Ptr<cv::Algorithm> al = cv::Algorithm::_create(name);
    return al.empty() ? NULL : clone( al );
}

CVAPI(cv::Ptr<cv::Algorithm>*) core_Ptr_Algorithm_new(cv::Algorithm *rawPtr)
{
	return new cv::Ptr<cv::Algorithm>(rawPtr);
}
CVAPI(void) core_Ptr_Algorithm_delete(cv::Ptr<cv::Algorithm> *ptr)
{
	delete ptr;
}
CVAPI(cv::Algorithm*) core_Ptr_Algorithm_obj(cv::Ptr<cv::Algorithm> *ptr)
{
	return ptr->obj;
}

CVAPI(void) core_Algorithm_name(cv::Algorithm *obj, char *buf, int bufLength)
{
    std::string name = reinterpret_cast<cv::FeatureDetector*>(obj)->name();
    copyString(name, buf, bufLength);
}

CVAPI(int) core_Algorithm_getInt(cv::Algorithm *obj, const char *name)
{
	return obj->getInt(name);
}
CVAPI(double) core_Algorithm_getDouble(cv::Algorithm *obj, const char *name)
{
	return obj->getDouble(name);
}
CVAPI(int) core_Algorithm_getBool(cv::Algorithm *obj, const char *name)
{
	return obj->getBool(name) ? 1 : 0;
}
CVAPI(void) core_Algorithm_getString(cv::Algorithm *obj, const char *name, 
                                     char *buf, int bufLength) 
{
	std::string result = obj->getString(name);
	copyString(result, buf, bufLength);
}
CVAPI(cv::Mat*) core_Algorithm_getMat(cv::Algorithm *obj, const char *name) 
{
	const cv::Mat &mat = obj->getMat(name);
	return new cv::Mat(mat);
}
CVAPI(void) core_Algorithm_getMatVector(cv::Algorithm *obj, const char *name,
                                        std::vector<cv::Mat>* outVec)
{
	std::vector<cv::Mat> vec = obj->getMatVector(name);
	std::copy(vec.begin(), vec.end(), std::back_inserter(*outVec));
}
CVAPI(cv::Ptr<cv::Algorithm>*) core_Algorithm_getAlgorithm(cv::Algorithm *obj, const char *name)
{
    return clone( obj->getAlgorithm(name) );
}

CVAPI(void) core_Algorithm_setInt(cv::Algorithm *obj, const char *name, int value)
{
	obj->set(name, value);
}
CVAPI(void) core_Algorithm_setDouble(cv::Algorithm *obj, const char *name, double value)
{
	obj->set(name, value);
}
CVAPI(void) core_Algorithm_setBool(cv::Algorithm *obj, const char *name, bool value)
{
	obj->set(name, value);
}
CVAPI(void) core_Algorithm_setString(cv::Algorithm *obj, const char *name, const char *value)
{
	std::string str(value);
	obj->set(name, str);
}
CVAPI(void) core_Algorithm_setMat(cv::Algorithm *obj, const char *name, const cv::Mat *value)
{
	obj->set(name, *value);
}
CVAPI(void) core_Algorithm_setMatVector(cv::Algorithm *obj, const char *name, 
                                        cv::Mat **value, int valueLength)
{
    std::vector<cv::Mat> valueVec(valueLength);
    for (int i = 0; i < valueLength; i++)
    {
        valueVec[i] = *(value[i]);
    }
	obj->set(name, valueVec);
}
CVAPI(void) core_Algorithm_setAlgorithm(cv::Algorithm *obj, const char *name, 
                                        cv::Algorithm *value)
{
    cv::Ptr<cv::Algorithm> ptr(value);
    ptr.addref();
	obj->set(name, ptr);
}

CVAPI(void) core_Algorithm_paramHelp(cv::Algorithm *obj, const char *name,
                                     char *buf, char *bufLength)
{
    std::string str = obj->paramHelp(name);
    std::strncpy(buf, str.c_str(), (size_t)(bufLength-1));
}
CVAPI(int) core_Algorithm_paramType(cv::Algorithm *obj, const char* name)
{
    return obj->paramType(name);
}
CVAPI(void) core_Algorithm_getParams(cv::Algorithm *obj, std::vector<std::string> *names)
{
    obj->getParams(*names);
}

CVAPI(void) core_Algorithm_getList(std::vector<std::string> *algorithms)
{
    cv::Algorithm::getList(*algorithms);
}
CVAPI(cv::AlgorithmInfo*) core_Algorithm_info(cv::Algorithm *obj)
{
    return obj->info();
}

#endif
