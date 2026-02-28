#include "face_detector_yn.h"
#include <opencv2/core/cvstd.hpp>
#include <opencv2/core/cvstd_wrapper.hpp>
#include <opencv2/core/mat.hpp>
#include <opencv2/core/types_c.h>
#include <opencv2/objdetect/face.hpp>
#include <opencv2/opencv_modules.hpp>

cv::FaceDetectorYN* cveFaceDetectorYNCreate(
	cv::String* model,
	cv::String* config,
	CvSize* inputSize,
	float scoreThreshold,
	float nmsThreshold,
	int topK,
	int backendId,
	int targetId,
	cv::Ptr<cv::FaceDetectorYN>** sharedPtr)
{
#ifdef HAVE_OPENCV_OBJDETECT
	cv::Ptr<cv::FaceDetectorYN> ptr = cv::FaceDetectorYN::create(
		*model,
		*config,
		*inputSize,
		scoreThreshold,
		nmsThreshold,
		topK,
		backendId,
		targetId);
	*sharedPtr = new cv::Ptr<cv::FaceDetectorYN>(ptr);
	return (*sharedPtr)->get();
#else
	throw_no_objdetect();
#endif
}

void cveFaceDetectorYNRelease(cv::Ptr<cv::FaceDetectorYN>** faceDetector)
{
#ifdef HAVE_OPENCV_OBJDETECT
	delete* faceDetector;
	*faceDetector = 0;
#else 
	throw_no_objdetect();
#endif
}

int cveFaceDetectorYNDetect(cv::FaceDetectorYN* faceDetetor, cv::_InputArray* image, cv::_OutputArray* faces)
{
#ifdef HAVE_OPENCV_OBJDETECT
	return faceDetetor->detect(*image, *faces);
#else 
	throw_no_objdetect();
#endif
}
