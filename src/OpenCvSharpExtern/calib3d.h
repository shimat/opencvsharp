/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CALIB3D_H_
#define _CPP_CALIB3D_H_

#include "include_opencv.h"

CVAPI(void) calib3d_Rodrigues(cv::_InputArray *src, cv::_OutputArray *dst, cv::_OutputArray *jacobian)
{
	cv::Rodrigues(*src, *dst, entity(jacobian));
}
CVAPI(void) calib3d_Rodrigues_VecToMat(cv::Mat *vector, cv::Mat *matrix, cv::Mat *jacobian)
{
	cv::Mat vectorM(3, 1, CV_64FC1, vector);
	cv::Mat matrixM(3, 3, CV_64FC1, matrix);
	cv::Mat jacobianM(3, 9, CV_64FC1, jacobian);
	cv::Rodrigues(*vector, *matrix, *jacobian);
}
CVAPI(void) calib3d_Rodrigues_MatToVec(cv::Mat *matrix, cv::Mat *vector, cv::Mat *jacobian)
{
	cv::Mat matrixM(3, 3, CV_64FC1, matrix);
	cv::Mat vectorM(3, 1, CV_64FC1, vector);	
	cv::Mat jacobianM(3, 9, CV_64FC1, jacobian);
	cv::Rodrigues(*matrix, *vector, *jacobian);
}

CVAPI(cv::Mat*) calib3d_findHomography_InputArray(cv::_InputArray *srcPoints, cv::_InputArray *dstPoints,
	int method, double ransacReprojThreshold, cv::_OutputArray *mask)
{
	cv::Mat ret = cv::findHomography(*srcPoints, *dstPoints, method, ransacReprojThreshold, entity(mask));
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) calib3d_findHomography_vector(cv::Point2d *srcPoints, int srcPointsLength,
	cv::Point2d *dstPoints, int dstPointsLength,
	int method, double ransacReprojThreshold, cv::_OutputArray *mask)
{
	std::vector<cv::Point2d> srcPointsVec(srcPoints, srcPoints + srcPointsLength);
	std::vector<cv::Point2d> dstPointsVec(dstPoints, dstPoints + dstPointsLength);
	cv::Mat ret = cv::findHomography(srcPointsVec, dstPointsVec, method, ransacReprojThreshold, entity(mask));
	return new cv::Mat(ret);
}

CVAPI(void) calib3d_RQDecomp3x3_InputArray(cv::_InputArray *src, cv::_OutputArray *mtxR, cv::_OutputArray *mtxQ,
	cv::_OutputArray *qx, cv::_OutputArray *qy, cv::_OutputArray *qz, cv::Vec3d *outVec)
{
	*outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, entity(qx), entity(qy), entity(qz));
}
CVAPI(void) calib3d_RQDecomp3x3_Mat(cv::Mat *src, cv::Mat *mtxR, cv::Mat *mtxQ,
	cv::Mat *qx, cv::Mat *qy, cv::Mat *qz, cv::Vec3d *outVec)
{
	*outVec = cv::RQDecomp3x3(*src, *mtxR, *mtxQ, *qx, *qy, *qz);
}

CVAPI(void) calib3d_decomposeProjectionMatrix_InputArray(cv::_InputArray *projMatrix, cv::_OutputArray *cameraMatrix,
	cv::_OutputArray *rotMatrix, cv::_OutputArray *transVect, cv::_OutputArray *rotMatrixX, 
	cv::_OutputArray *rotMatrixY, cv::_OutputArray *rotMatrixZ, cv::_OutputArray *eulerAngles)
{
	cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
		*transVect, entity(rotMatrixX), entity(rotMatrixY), entity(rotMatrixZ), entity(eulerAngles));
}
CVAPI(void) calib3d_decomposeProjectionMatrix_Mat(cv::Mat *projMatrix, cv::Mat *cameraMatrix,
	cv::Mat *rotMatrix, cv::Mat *transVect, cv::Mat *rotMatrixX,
	cv::Mat *rotMatrixY, cv::Mat *rotMatrixZ, cv::Mat *eulerAngles)
{
	cv::decomposeProjectionMatrix(*projMatrix, *cameraMatrix, *rotMatrix,
		*transVect, *rotMatrixX, *rotMatrixY, *rotMatrixZ, *eulerAngles);
}

CVAPI(void) calib3d_matMulDeriv(cv::_InputArray *a, cv::_InputArray *b,
                               cv::_OutputArray *dABdA, cv::_OutputArray *dABdB)
{
	cv::matMulDeriv(*a, *b, *dABdA, *dABdB);
}

CVAPI(void) calib3d_composeRT_InputArray( cv::_InputArray *rvec1, cv::_InputArray *tvec1,
                             cv::_InputArray *rvec2, cv::_InputArray *tvec2,
                             cv::_OutputArray *rvec3, cv::_OutputArray *tvec3,
                             cv::_OutputArray *dr3dr1, cv::_OutputArray *dr3dt1,
                             cv::_OutputArray *dr3dr2, cv::_OutputArray *dr3dt2,
                             cv::_OutputArray *dt3dr1, cv::_OutputArray *dt3dt1,
                             cv::_OutputArray *dt3dr2, cv::_OutputArray *dt3dt2 )
{
	cv::composeRT(*rvec1, *tvec1, *rvec2, *tvec2, *rvec3, *tvec3, 
		entity(dr3dr1), entity(dr3dt1), entity(dr3dr2), entity(dr3dt2), 
		entity(dt3dr1), entity(dt3dt1), entity(dt3dr2), entity(dt3dt2));
}

CVAPI(void) calib3d_composeRT_Mat(cv::Mat *rvec1, cv::Mat *tvec1,
                             cv::Mat *rvec2, cv::Mat *tvec2,
                             cv::Mat *rvec3, cv::Mat *tvec3,
                             cv::Mat *dr3dr1, cv::Mat *dr3dt1,
                             cv::Mat *dr3dr2, cv::Mat *dr3dt2,
                             cv::Mat *dt3dr1, cv::Mat *dt3dt1,
                             cv::Mat *dt3dr2, cv::Mat *dt3dt2 )
{
	cv::composeRT(*rvec1, *tvec1, *rvec2, *tvec2, *rvec3, *tvec3, 
		entity(dr3dr1), entity(dr3dt1), entity(dr3dr2), entity(dr3dt2), 
		entity(dt3dr1), entity(dt3dt1), entity(dt3dr2), entity(dt3dt2));
}

CVAPI(void) calib3d_projectPoints_InputArray( cv::_InputArray *objectPoints,
                                 cv::_InputArray *rvec, cv::_InputArray *tvec,
                                 cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
                                 cv::_OutputArray *imagePoints,
                                 cv::_OutputArray *jacobian,
                                 double aspectRatio )
{
	cv::projectPoints(*objectPoints, *rvec, *tvec, *cameraMatrix, *distCoeffs,
		*imagePoints, *jacobian, aspectRatio);
}
CVAPI(void) calib3d_projectPoints_Mat( cv::Mat *objectPoints,
                                 cv::Mat *rvec, cv::Mat *tvec,
                                 cv::Mat *cameraMatrix, cv::Mat *distCoeffs,
                                 cv::Mat *imagePoints,
                                 cv::Mat *jacobian,
                                 double aspectRatio )
{
	cv::projectPoints(*objectPoints, *rvec, *tvec, *cameraMatrix, *distCoeffs,
		*imagePoints, *jacobian, aspectRatio);
}


CVAPI(void) calib3d_solvePnP_InputArray(cv::_InputArray *objectPoints, cv::_InputArray *imagePoints, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
	cv::_OutputArray *rvec, cv::_OutputArray *tvec, int useExtrinsicGuess, int flags)
{
	cv::solvePnP(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec, useExtrinsicGuess != 0, flags);
}
CVAPI(void) calib3d_solvePnP_vector(cv::Point3f *objectPoints, int objectPointsLength,
									cv::Point2f *imagePoints, int imagePointsLength,
									double *cameraMatrix, double *distCoeffs, int distCoeffsLength,
									double *rvec, double *tvec, int useExtrinsicGuess,
									int flags)
{
	std::vector<cv::Point3f> objectPointsVec(objectPoints, objectPoints + objectPointsLength);
	std::vector<cv::Point2f> imagePointsVec(imagePoints, imagePoints + imagePointsLength);
	std::vector<double> distCoeffsVec;
	if (distCoeffs != NULL)
		distCoeffsVec = std::vector<double>(distCoeffs, distCoeffs + distCoeffsLength);
	
	cv::Matx<double, 3, 1> rvecM, tvecM;
	cv::solvePnP(objectPointsVec, imagePointsVec, *cameraMatrix, distCoeffsVec, rvecM, tvecM, useExtrinsicGuess != 0, flags);
	memcpy(rvec, rvecM.val, sizeof(double) * 3);
	memcpy(tvec, tvecM.val, sizeof(double) * 3);
}

CVAPI(void) calib3d_solvePnPRansac_InputArray(cv::_InputArray *objectPoints, cv::_InputArray *imagePoints,
	cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs, cv::_OutputArray *rvec, cv::_OutputArray *tvec,
	bool useExtrinsicGuess,	int iterationsCount, float reprojectionError, int minInliersCount,
	cv::_OutputArray *inliers, int flags)
{
	cv::solvePnPRansac(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec,
		useExtrinsicGuess != 0, iterationsCount, reprojectionError, minInliersCount, 
		entity(inliers), flags);
}
CVAPI(void) calib3d_solvePnPRansac_vector(cv::Point3f *objectPoints, int objectPointsLength, 
	cv::Point2f *imagePoints, int imagePointsLength,
	double *cameraMatrix, double *distCoeffs, int distCoeffsLength,
	double *rvec, double *tvec,
	int useExtrinsicGuess, int iterationsCount, float reprojectionError, int minInliersCount,
	std::vector<int> *inliers, int flags)
{
	std::vector<cv::Point3f> objectPointsVec(objectPoints, objectPoints + objectPointsLength);
	std::vector<cv::Point2f> imagePointsVec(imagePoints, imagePoints + imagePointsLength);
	std::vector<double> distCoeffsVec;
	if (distCoeffs != NULL)
		distCoeffsVec = std::vector<double>(distCoeffs, distCoeffs + distCoeffsLength);
	cv::Matx<double, 3, 1> rvecM, tvecM;

	cv::solvePnPRansac(objectPointsVec, imagePointsVec, *cameraMatrix, distCoeffsVec, rvecM, tvecM,
		useExtrinsicGuess != 0, iterationsCount, reprojectionError, minInliersCount,
		*inliers, flags);

	memcpy(rvec, rvecM.val, sizeof(double)* 3);
	memcpy(tvec, tvecM.val, sizeof(double)* 3);
}

CVAPI(cv::Mat*) calib3d_initCameraMatrix2D_Mat(cv::Mat **objectPoints, int objectPointsLength,
	cv::Mat **imagePoints, int imagePointsLength, CvSize imageSize, double aspectRatio)
{
	std::vector<cv::Mat> objectPointsVec(objectPointsLength);
	for (int i = 0; i < objectPointsLength; i++)	
		objectPointsVec[i] = *objectPoints[i];
	std::vector<cv::Mat> imagePointsVec(imagePointsLength);
	for (int i = 0; i < objectPointsLength; i++)
		imagePointsVec[i] = *imagePoints[i];

	cv::Mat ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, imageSize, aspectRatio);
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) calib3d_initCameraMatrix2D_array(cv::Point3d **objectPoints, int opSize1, int *opSize2,
	cv::Point2d **imagePoints, int ipSize1, int *ipSize2, CvSize imageSize, double aspectRatio)
{
	std::vector<std::vector<cv::Point3d> > objectPointsVec(opSize1);
	for (int i = 0; i < opSize1; i++)
		objectPointsVec[i] = std::vector<cv::Point3d>(objectPoints[i], objectPoints[i] + opSize2[i]);
	std::vector<std::vector<cv::Point3d> > imagePointsVec(ipSize1);
	for (int i = 0; i < ipSize1; i++)
		imagePointsVec[i] = std::vector<cv::Point3d>(imagePoints[i], imagePoints[i] + ipSize2[i]);

	cv::Mat ret = cv::initCameraMatrix2D(objectPointsVec, imagePointsVec, imageSize, aspectRatio);
	return new cv::Mat(ret);
}

CVAPI(int) calib3d_findChessboardCorners_InputArray(cv::_InputArray *image, CvSize patternSize,
	cv::_OutputArray *corners, int flags)
{
	return cv::findChessboardCorners(*image, patternSize, *corners, flags) ? 1 : 0;
}
CVAPI(int) calib3d_findChessboardCorners_vector(cv::_InputArray *image, CvSize patternSize,
	std::vector<cv::Point2f> *corners, int flags)
{
	return cv::findChessboardCorners(*image, patternSize, *corners, flags) ? 1 : 0;
}

CVAPI(int) calib3d_find4QuadCornerSubpix_InputArray(cv::_InputArray *img, cv::_OutputArray *corners, CvSize regionSize)
{
	return cv::find4QuadCornerSubpix(*img, *corners, regionSize) ? 1 : 0;
}
CVAPI(int) calib3d_find4QuadCornerSubpix_vector(cv::_InputArray *img, std::vector<cv::Point2f> *corners, CvSize regionSize)
{
	return cv::find4QuadCornerSubpix(*img, *corners, regionSize) ? 1 : 0;
}

CVAPI(void) calib3d_drawChessboardCorners_InputArray(cv::_OutputArray *image, CvSize patternSize,
	cv::_InputArray *corners, int patternWasFound)
{
	cv::drawChessboardCorners(*image, patternSize, *corners, patternWasFound != 0);
}
CVAPI(void) calib3d_drawChessboardCorners_array(cv::_OutputArray *image, CvSize patternSize,
	cv::Point2f *corners, int cornersLength, int patternWasFound)
{
	std::vector<cv::Point2f> cornersVec(corners, corners + cornersLength);
	cv::drawChessboardCorners(*image, patternSize, cornersVec, patternWasFound != 0);
}

CVAPI(int) calib3d_findCirclesGrid_InputArray(cv::_InputArray *image, CvSize patternSize,
	cv::_OutputArray *centers, int flags, cv::FeatureDetector* blobDetector)
{
	if (blobDetector == NULL)
		return cv::findCirclesGrid(*image, patternSize, *centers, flags) ? 1 : 0;

	cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector);
	detectorPtr.addref();
	return cv::findCirclesGrid(*image, patternSize, *centers, flags, detectorPtr) ? 1 : 0;
}
CVAPI(int) calib3d_findCirclesGrid_vector(cv::_InputArray *image, CvSize patternSize,
	std::vector<cv::Point2f> *centers, int flags, cv::FeatureDetector* blobDetector)
{
	if (blobDetector == NULL)
		return cv::findCirclesGrid(*image, patternSize, *centers, flags) ? 1 : 0;

	cv::Ptr<cv::FeatureDetector> detectorPtr(blobDetector);
	detectorPtr.addref();
	return cv::findCirclesGrid(*image, patternSize, *centers, flags, detectorPtr) ? 1 : 0;
}

#pragma region StereoBM

CVAPI(cv::StereoBM*) calib3d_StereoBM_new1()
{
	return new cv::StereoBM();
}
CVAPI(cv::StereoBM*) calib3d_StereoBM_new2(int preset, int ndisparities, int SADWindowSize)
{
	return new cv::StereoBM(preset, ndisparities, SADWindowSize);
}
CVAPI(void) calib3d_StereoBM_init(cv::StereoBM *obj, int preset, int ndisparities, int SADWindowSize)
{
	obj->init(preset, ndisparities, SADWindowSize);
}
CVAPI(void) calib3d_StereoBM_delete(cv::StereoBM* obj)
{
	delete obj;
}

CVAPI(void) calib3d_StereoBM_compute(cv::StereoBM* obj, cv::_InputArray* left, cv::_InputArray* right, 
									 cv::_OutputArray* disp, int disptype)
{
	(*obj)(*left, *right, *disp, disptype);
}

#pragma endregion

#pragma region StereoSGBM

CVAPI(void) calib3d_StereoSGBM_delete(cv::StereoSGBM* obj)
{
	delete obj;
}
CVAPI(cv::StereoSGBM*) calib3d_StereoSGBM_new1()
{
	return new cv::StereoSGBM();
}
CVAPI(cv::StereoSGBM*) calib3d_StereoSGBM_new2(int minDisparity, int numDisparities, int SADWindowSize, int P1, int P2, int disp12MaxDiff, int preFilterCap, int uniquenessRatio, int speckleWindowSize, int speckleRange, bool fullDP)
{
	return new cv::StereoSGBM(minDisparity, numDisparities, SADWindowSize, P1, P2, disp12MaxDiff, preFilterCap, uniquenessRatio, speckleWindowSize, speckleRange, fullDP);
}

CVAPI(void) calib3d_StereoSGBM_compute(cv::StereoSGBM* obj, cv::_InputArray* left, cv::_InputArray* right, cv::_OutputArray* disp)
{
	(*obj)(*left, *right, *disp);
}


CVAPI(int) calib3d_StereoSGBM_minDisparity_get(const cv::StereoSGBM* obj)
{
	return obj->minDisparity;
}
CVAPI(void) calib3d_StereoSGBM_minDisparity_set(cv::StereoSGBM* obj, int value)
{
	obj->minDisparity = value;
}
CVAPI(int) calib3d_StereoSGBM_numberOfDisparities_get(const cv::StereoSGBM* obj)
{
	return obj->numberOfDisparities;
}
CVAPI(void) calib3d_StereoSGBM_numberOfDisparities_set(cv::StereoSGBM* obj, int value)
{
	obj->numberOfDisparities = value;
}
CVAPI(int) calib3d_StereoSGBM_SADWindowSize_get(const cv::StereoSGBM* obj)
{
	return obj->SADWindowSize;
}
CVAPI(void) calib3d_StereoSGBM_SADWindowSize_set(cv::StereoSGBM* obj, int value)
{
	obj->SADWindowSize = value;
}
CVAPI(int) calib3d_StereoSGBM_preFilterCap_get(const cv::StereoSGBM* obj)
{
	return obj->preFilterCap;
}
CVAPI(void) calib3d_StereoSGBM_preFilterCap_set(cv::StereoSGBM* obj, int value)
{
	obj->preFilterCap = value;
}
CVAPI(int) calib3d_StereoSGBM_uniquenessRatio_get(const cv::StereoSGBM* obj)
{
	return obj->uniquenessRatio;
}
CVAPI(void) calib3d_StereoSGBM_uniquenessRatio_set(cv::StereoSGBM* obj, int value)
{
	obj->uniquenessRatio = value;
}
CVAPI(int) calib3d_StereoSGBM_P1_get(const cv::StereoSGBM* obj)
{
	return obj->P1;
}
CVAPI(void) calib3d_StereoSGBM_P1_set(cv::StereoSGBM* obj, int value)
{
	obj->P1 = value;
}
CVAPI(int) calib3d_StereoSGBM_P2_get(const cv::StereoSGBM* obj)
{
	return obj->P2;
}
CVAPI(void) calib3d_StereoSGBM_P2_set(cv::StereoSGBM* obj, int value)
{
	obj->P2 = value;
}
CVAPI(int) calib3d_StereoSGBM_speckleWindowSize_get(const cv::StereoSGBM* obj)
{
	return obj->speckleWindowSize;
}
CVAPI(void) calib3d_StereoSGBM_speckleWindowSize_set(cv::StereoSGBM* obj, int value)
{
	obj->speckleWindowSize = value;
}
CVAPI(int) calib3d_StereoSGBM_speckleRange_get(const cv::StereoSGBM* obj)
{
	return obj->speckleRange;
}
CVAPI(void) calib3d_StereoSGBM_speckleRange_set(cv::StereoSGBM* obj, int value)
{
	obj->speckleRange = value;
}
CVAPI(int) calib3d_StereoSGBM_disp12MaxDiff_get(const cv::StereoSGBM* obj)
{
	return obj->disp12MaxDiff;
}
CVAPI(void) calib3d_StereoSGBM_disp12MaxDiff_set(cv::StereoSGBM* obj, int value)
{
	obj->disp12MaxDiff = value;
}
CVAPI(int) calib3d_StereoSGBM_fullDP_get(const cv::StereoSGBM* obj)
{
	return obj->fullDP ? 1 : 0;
}
CVAPI(void) calib3d_StereoSGBM_fullDP_set(cv::StereoSGBM* obj, int value)
{
	obj->fullDP = (value != 0);
}
#pragma endregion

#endif