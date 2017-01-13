#ifndef _CPP_FACE_FACERECOGNIZER_H_
#define _CPP_FACE_FACERECOGNIZER_H_

#include "include_opencv.h"
using namespace cv::face;


CVAPI(void) face_FaceRecognizer_train(
	FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
	std::vector<cv::Mat> srcVec(srcLength);
	for (int i = 0; i < srcLength; i++)
		srcVec[i] = *src[i];
	std::vector<int> labelsVec(labels, labels + labelsLength);
	obj->train(srcVec, labelsVec);
}
CVAPI(void) face_FaceRecognizer_update(
	FaceRecognizer *obj, cv::Mat **src, int srcLength, int *labels, int labelsLength)
{
	std::vector<cv::Mat> srcVec(srcLength);
	for (int i = 0; i < srcLength; i++)
		srcVec[i] = *src[i];
	std::vector<int> labelsVec(labels, labels + labelsLength);
	obj->update(srcVec, labelsVec);
}
CVAPI(int) face_FaceRecognizer_predict1(FaceRecognizer *obj, cv::_InputArray *src)
{
	return obj->predict(*src);
}
CVAPI(void) face_FaceRecognizer_predict2(
	FaceRecognizer *obj, cv::_InputArray *src, int *label, double *confidence)
{
	obj->predict(*src, *label, *confidence);
}
CVAPI(void) face_FaceRecognizer_save1(FaceRecognizer *obj, const char *filename)
{
	obj->save(filename);
}
CVAPI(void) face_FaceRecognizer_load1(FaceRecognizer *obj, const char *filename)
{
	obj->load(filename);
}
CVAPI(void) face_FaceRecognizer_save2(FaceRecognizer *obj, cv::FileStorage *fs)
{
	obj->save(*fs);
}
CVAPI(void) face_FaceRecognizer_load2(FaceRecognizer *obj, cv::FileStorage *fs)
{
	obj->load(*fs);
}

CVAPI(FaceRecognizer*) face_Ptr_FaceRecognizer_get(cv::Ptr<FaceRecognizer> *obj)
{
	return obj->get();
}
CVAPI(void) face_Ptr_FaceRecognizer_delete(cv::Ptr<FaceRecognizer> *obj)
{
	delete obj;
}

#endif
