#ifndef _CPP_CORE_ALGORITHMINFO_H_
#define _CPP_CORE_ALGORITHMINFO_H_

#include "include_opencv.h"

// public AlgorithmInfo::set
class AlgorithmInfoHack : public cv::AlgorithmInfo
{
public:
    void set(cv::Algorithm* algo, const char* name, int argType,
        const void* value, bool force=false) const
    {
        cv::AlgorithmInfo::set(algo, name, argType, value, force);
    }
};


CVAPI(void) core_AlgorithmInfo_paramHelp(cv::AlgorithmInfo *obj, char *name, char *dst, int dstLength)
{
	std::string result = obj->paramHelp(name);
	copyString(result, dst, dstLength);    
}
CVAPI(int) core_AlgorithmInfo_paramType(cv::AlgorithmInfo *obj, char *name)
{
	return (int)obj->paramType(name);
}
CVAPI(void) core_AlgorithmInfo_name(cv::AlgorithmInfo *obj, char *dst, int dstLength) 
{
	std::string result = obj->name();
	copyString(result, dst, dstLength);      
}
CVAPI(void) core_AlgorithmInfo_getParams(cv::AlgorithmInfo *obj, std::vector<std::string> *names)
{
    obj->getParams(*names);
}



CVAPI(void) core_AlgorithmInfo_getInt(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, int *value)
{
    obj->get(algo, name, argType, value);
}
CVAPI(void) core_AlgorithmInfo_getDouble(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, double *value)
{
    obj->get(algo, name, argType, value);
}
CVAPI(void) core_AlgorithmInfo_getBool(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, int *value)
{
    bool valueBool;
    obj->get(algo, name, argType, &valueBool);
    *value = valueBool ? 1 : 0;
}
CVAPI(void) core_AlgorithmInfo_getString(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, char *value, int valueLength)
{
    std::string valueStr;
    obj->get(algo, name, argType, &valueStr);

    copyString(valueStr.c_str(), value, valueLength);
}
CVAPI(void) core_AlgorithmInfo_getMat(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, cv::Mat *value)
{
    obj->get(algo, name, argType, value);
}


CVAPI(void) core_AlgorithmInfo_setInt(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, int value, int force)
{
    AlgorithmInfoHack *hack = reinterpret_cast<AlgorithmInfoHack*>(obj);
    hack->set(algo, name, argType, &value, force != 0);
}
CVAPI(void) core_AlgorithmInfo_setDouble(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, double value, int force)
{
    AlgorithmInfoHack *hack = reinterpret_cast<AlgorithmInfoHack*>(obj);
    hack->set(algo, name, argType, &value, force != 0);
}
CVAPI(void) core_AlgorithmInfo_setBool(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, int value, int force)
{
    AlgorithmInfoHack *hack = reinterpret_cast<AlgorithmInfoHack*>(obj);
    bool valueBool = (value != 0);
    hack->set(algo, name, argType, &valueBool, force != 0);
}
CVAPI(void) core_AlgorithmInfo_setString(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, const char *value, int force)
{
    AlgorithmInfoHack *hack = reinterpret_cast<AlgorithmInfoHack*>(obj);
    hack->set(algo, name, argType, value, force != 0);
}
CVAPI(void) core_AlgorithmInfo_setMat(cv::AlgorithmInfo *obj, cv::Algorithm* algo, 
                                   const char* name, int argType, cv::Mat *value, int force)
{
    AlgorithmInfoHack *hack = reinterpret_cast<AlgorithmInfoHack*>(obj);
    hack->set(algo, name, argType, value, force != 0);
}

#endif