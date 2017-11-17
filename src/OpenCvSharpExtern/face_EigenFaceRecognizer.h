#ifndef _CPP_FACE_EIGENFACERECOGNIZER_H_
#define _CPP_FACE_EIGENFACERECOGNIZER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
using namespace cv::face;


CVAPI(cv::Ptr<EigenFaceRecognizer>*) face_EigenFaceRecognizer_create(
	const int numComponents, const double threshold)
{
	const auto r = EigenFaceRecognizer::create(numComponents, threshold);
	return clone(r);
}

CVAPI(EigenFaceRecognizer*) face_Ptr_EigenFaceRecognizer_get(cv::Ptr<EigenFaceRecognizer> *obj)
{
	return obj->get();
}
CVAPI(void) face_Ptr_EigenFaceRecognizer_delete(cv::Ptr<EigenFaceRecognizer> *obj)
{
	delete obj;
}

#endif