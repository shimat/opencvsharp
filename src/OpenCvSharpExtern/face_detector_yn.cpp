#include "face_detector_yn.h"

#ifndef NO_OBJDETECT

#ifdef HAVE_OPENCV_OBJDETECT
#include <opencv2/objdetect/face.hpp>

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
}

void cveFaceDetectorYNRelease(cv::Ptr<cv::FaceDetectorYN>** faceDetector)
{
	delete* faceDetector;
	*faceDetector = 0;
}

int cveFaceDetectorYNDetect(cv::FaceDetectorYN* faceDetector, cv::_InputArray* image, cv::_OutputArray* faces)
{
	return faceDetector->detect(*image, *faces);
}

#else

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
	return nullptr;
}

void cveFaceDetectorYNRelease(cv::Ptr<cv::FaceDetectorYN>** faceDetector)
{
}

int cveFaceDetectorYNDetect(cv::FaceDetectorYN* faceDetector, cv::_InputArray* image, cv::_OutputArray* faces)
{
	return 0;
}
#endif

#endif
