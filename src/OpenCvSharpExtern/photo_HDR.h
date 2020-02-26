#ifndef _CPP_PHOTO_HDR_H_
#define _CPP_PHOTO_HDR_H_

#include "include_opencv.h"

CVAPI(cv::Ptr<cv::CalibrateDebevec>*) photo_createCalibrateDebevec(
    int samples, float lambda, int random) 
{
    return clone(cv::createCalibrateDebevec(samples, lambda, random != 0));
}

CVAPI(cv::Ptr<cv::CalibrateRobertson>*) photo_createCalibrateRobertson(
    int max_iter, float threshold)
{
    return clone(cv::createCalibrateRobertson(max_iter, threshold));
}

CVAPI(void) photo_Ptr_CalibrateDebevec_delete(cv::Ptr<cv::CalibrateDebevec> *obj)
{
    delete obj;
}
CVAPI(void) photo_Ptr_CalibrateRobertson_delete(cv::Ptr<cv::CalibrateRobertson> *obj)
{
    delete obj;
}

CVAPI(cv::CalibrateDebevec*) photo_Ptr_CalibrateDebevec_get(cv::Ptr<cv::CalibrateDebevec> *obj)
{
    return obj->get();
}
CVAPI(cv::CalibrateRobertson*) photo_Ptr_CalibrateRobertson_get(cv::Ptr<cv::CalibrateRobertson> *obj)
{
    return obj->get();
}

CVAPI(void) photo_CalibrateCRF_process(
    cv::CalibrateCRF *obj, 
    cv::Mat ** srcImgs, int srcImgsLength, cv::_OutputArray *dst, float* times)
{
    // Build Mat Vector of images
    std::vector<cv::Mat> srcImgsVec(srcImgsLength);

    // Build float Vector of times
    std::vector<float> times_vec(srcImgsLength);
    
    for (int i = 0; i < srcImgsLength; i++) {
        srcImgsVec[i] = *srcImgs[i];
        times_vec[i] = times[i];
    }

    obj->process(srcImgsVec, *dst, times_vec);
}

CVAPI(cv::Ptr<cv::MergeDebevec>*) photo_createMergeDebevec()
{
	return clone(cv::createMergeDebevec());
}
CVAPI(void) photo_Ptr_MergeDebevec_delete(cv::Ptr<cv::MergeDebevec>* obj)
{
	delete obj;
}
CVAPI(cv::MergeDebevec*) photo_Ptr_MergeDebevec_get(cv::Ptr<cv::MergeDebevec>* obj)
{
	return obj->get();
}

CVAPI(cv::Ptr<cv::MergeMertens>*) photo_createMergeMertens()
{
	return clone(cv::createMergeMertens());
}
CVAPI(void) photo_Ptr_MergeMertens_delete(cv::Ptr<cv::MergeMertens>* obj)
{
	delete obj;
}
CVAPI(cv::MergeMertens*) photo_Ptr_MergeMertens_get(cv::Ptr<cv::MergeMertens>* obj)
{
	return obj->get();
}

CVAPI(void) photo_MergeExposures_process(
	cv::MergeExposures* obj,
	cv::Mat** srcImgs, int srcImgsLength, cv::_OutputArray* dst, float* times, cv::_InputArray* response)
{
	// Build Mat Vector of images
	std::vector<cv::Mat> srcImgsVec(srcImgsLength);

	// Build float Vector of times
	std::vector<float> times_vec(srcImgsLength);

	for (int i = 0; i < srcImgsLength; i++) {
		srcImgsVec[i] = *srcImgs[i];
		times_vec[i] = times[i];
	}

	obj->process(srcImgsVec, *dst, times_vec, *response);
}

CVAPI(void) photo_MergeMertens_process(
	cv::MergeMertens* obj,
	cv::Mat** srcImgs, int srcImgsLength, cv::_OutputArray* dst)
{
	// Build Mat Vector of images
	std::vector<cv::Mat> srcImgsVec(srcImgsLength);

	// Build float Vector of times
	std::vector<float> times_vec(srcImgsLength);

	for (int i = 0; i < srcImgsLength; i++) {
		srcImgsVec[i] = *srcImgs[i];
	}

	obj->process(srcImgsVec, *dst);
}

CVAPI(cv::Ptr<cv::Tonemap>*) photo_createTonemap(float gamma)
{
	return clone(cv::createTonemap(gamma));
}
CVAPI(void) photo_Ptr_Tonemap_delete(cv::Ptr<cv::Tonemap>* obj)
{
	delete obj;
}
CVAPI(cv::Tonemap*) photo_Ptr_Tonemap_get(cv::Ptr<cv::Tonemap>* obj)
{
	return obj->get();
}

CVAPI(void) photo_Tonemap_process(
	cv::Tonemap* obj,
	cv::_InputArray* src, cv::_OutputArray* dst)
{
	obj->process(*src, *dst);
}


#endif