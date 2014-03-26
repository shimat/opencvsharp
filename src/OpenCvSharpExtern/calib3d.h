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

CVAPI(double) calib3d_calibrateCamera_InputArray(
	cv::Mat **objectPoints, int objectPointsSize,
	cv::Mat **imagePoints, int imagePointsSize,
	CvSize imageSize,
	cv::_OutputArray *cameraMatrix,
	cv::_OutputArray *distCoeffs,
	std::vector<cv::Mat> *rvecs, cv::vector<cv::Mat> *tvecs,
	int flags,
	CvTermCriteria criteria)
{
	std::vector<cv::Mat> objectPointsVec(objectPointsSize);
	for (int i = 0; i < objectPointsSize; i++)
		objectPointsVec[i] = *objectPoints[i];
	std::vector<cv::Mat> imagePointsVec(imagePointsSize);
	for (int i = 0; i < imagePointsSize; i++)
		imagePointsVec[i] = *imagePoints[i];

	return cv::calibrateCamera(objectPointsVec, imagePointsVec, imageSize,
		*cameraMatrix, *distCoeffs, *rvecs, *tvecs, flags, criteria);
}
CVAPI(double) calib3d_calibrateCamera_vector(
	cv::Point3d **objectPoints, int opSize1, int *opSize2,
	cv::Point2d **imagePoints, int ipSize1, int *ipSize2,
	CvSize imageSize,
	double *cameraMatrix,
	double *distCoeffs, int distCoeffsSize,
	std::vector<cv::Mat> *rvecs, cv::vector<cv::Mat> *tvecs,
	int flags,
	CvTermCriteria criteria)
{
	std::vector<std::vector<cv::Point3d> > objectPointsVec(opSize1);
	for (int i = 0; i < opSize1; i++)	
		objectPointsVec[i] = std::vector<cv::Point3d>(objectPoints[i], objectPoints[i] + opSize2[i]);

	std::vector<std::vector<cv::Point2d> > imagePointsVec(ipSize1);
	for (int i = 0; i < ipSize1; i++)
		imagePointsVec[i] = std::vector<cv::Point2d>(imagePoints[i], imagePoints[i] + ipSize2[i]);
	
	cv::Mat cametaMatrixM(3, 3, CV_64FC1, cameraMatrix);
	cv::Mat distCoeffsM(distCoeffsSize, 1, CV_64FC1, distCoeffs);

	return cv::calibrateCamera(objectPointsVec, imagePointsVec, imageSize,
		cametaMatrixM, distCoeffsM, *rvecs, *tvecs, flags, criteria);
}

CVAPI(void) calib3d_calibrationMatrixValues_InputArray(cv::_InputArray *cameraMatrix, cv::Size imageSize,
	double apertureWidth, double apertureHeight, double *fovx, double *fovy, double *focalLength,
	cv::Point2d *principalPoint, double *aspectRatio)
{
	double fovx0, fovy0, focalLength0, aspectRatio0;
	cv::Point2d principalPoint0;
	cv::calibrationMatrixValues(*cameraMatrix, imageSize, apertureWidth, apertureHeight,
		fovx0, fovy0, focalLength0, principalPoint0, aspectRatio0);
	*fovx = fovx0;
	*fovy = fovy0;
	*principalPoint = principalPoint0;
	*focalLength = focalLength0;
	*aspectRatio = aspectRatio0;
}
CVAPI(void) calib3d_calibrationMatrixValues_array(double *cameraMatrix, cv::Size imageSize,
	double apertureWidth, double apertureHeight, double *fovx, double *fovy, double *focalLength,
	cv::Point2d *principalPoint, double *aspectRatio)
{
	cv::Mat cameraMatrixM(3, 3, CV_64FC1, cameraMatrix);
	cv::_InputArray cameraMatrixI(cameraMatrixM);
	calib3d_calibrationMatrixValues_InputArray(&cameraMatrixI, imageSize, apertureWidth, apertureHeight,
		fovx, fovy, focalLength, principalPoint, aspectRatio);
}

CVAPI(double) calib3d_stereoCalibrate_InputArray(cv::_InputArray **objectPoints, int opSize,
                                     cv::_InputArray **imagePoints1, int ip1Size,
                                     cv::_InputArray **imagePoints2, int ip2Size,
                                     cv::_OutputArray *cameraMatrix1,
                                     cv::_OutputArray *distCoeffs1,
                                     cv::_OutputArray *cameraMatrix2,
                                     cv::_OutputArray *distCoeffs2,
                                     CvSize imageSize, 
									 cv::_OutputArray *R, cv::_OutputArray *T, 
									 cv::_OutputArray *E, cv::_OutputArray *F,
                                     CvTermCriteria criteria,                              
									 int flags )
{
	std::vector<cv::_InputArray> objectPointsVec(opSize);
	std::vector<cv::_InputArray> imagePoints1Vec(ip1Size);
	std::vector<cv::_InputArray> imagePoints2Vec(ip2Size);
	for (int i = 0; i < opSize; i++)	
		objectPointsVec[i] = *objectPoints[i];
	for (int i = 0; i < ip1Size; i++)	
		imagePoints1Vec[i] = *imagePoints1[i];
	for (int i = 0; i < ip2Size; i++)	
		imagePoints2Vec[i] = *imagePoints2[i];
	
	return cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
		*cameraMatrix1, *distCoeffs1,
		*cameraMatrix2, *distCoeffs2,
		imageSize, entity(R), entity(T), entity(E), entity(F), criteria, flags);
}
CVAPI(double) calib3d_stereoCalibrate_array(cv::Point3d **objectPoints, int opSize1, int *opSizes2,
                                     cv::Point2d **imagePoints1, int ip1Size1, int *ip1Sizes2,
                                     cv::Point2d **imagePoints2, int ip2Size1, int *ip2Sizes2,
                                     double *cameraMatrix1,
                                     double *distCoeffs1, int dc1Size,
                                     double *cameraMatrix2,
                                     double *distCoeffs2, int dc2Size,
                                     CvSize imageSize, 
									 cv::_OutputArray *R, cv::_OutputArray *T, 
									 cv::_OutputArray *E, cv::_OutputArray *F,
                                     CvTermCriteria criteria,                              
									 int flags )
{
	std::vector<std::vector<cv::Point3d>> objectPointsVec(opSize1);
	std::vector<std::vector<cv::Point2d>> imagePoints1Vec(ip1Size1);
	std::vector<std::vector<cv::Point2d>> imagePoints2Vec(ip2Size1);
	for (int i = 0; i < opSize1; i++)
		objectPointsVec[i] = std::vector<cv::Point3d>(
			objectPoints[i], objectPoints[i] + opSizes2[i]);
	for (int i = 0; i < ip1Size1; i++)
		imagePoints1Vec[i] = std::vector<cv::Point2d>(
			imagePoints1[i], imagePoints1[i] + ip1Sizes2[i]);
	for (int i = 0; i < ip2Size1; i++)
		imagePoints2Vec[i] = std::vector<cv::Point2d>(
			imagePoints2[i], imagePoints2[i] + ip2Sizes2[i]);
	
	cv::Mat cameraMatrix1M(3, 3, CV_64FC1, cameraMatrix1);
	cv::Mat cameraMatrix2M(3, 3, CV_64FC1, cameraMatrix2);
	cv::Mat distCoeffs1M(dc1Size, 1, CV_64FC1, distCoeffs1);
	cv::Mat distCoeffs2M(dc2Size, 1, CV_64FC1, distCoeffs2);

	return cv::stereoCalibrate(objectPointsVec, imagePoints1Vec, imagePoints2Vec,
		cameraMatrix1M, distCoeffs1M,
		cameraMatrix2M, distCoeffs2M,
		imageSize, entity(R), entity(T), entity(E), entity(F), criteria, flags);
}

CVAPI(void) calib3d_stereoRectify_InputArray( 
								cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
								cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
								CvSize imageSize, cv::_InputArray *R, cv::_InputArray *T,
								cv::_OutputArray *R1, cv::_OutputArray *R2,
								cv::_OutputArray *P1, cv::_OutputArray *P2,
								cv::_OutputArray *Q, int flags,
								double alpha, cv::Size newImageSize,
								cv::Rect* validPixROI1, cv::Rect* validPixROI2 )
{
	cv::stereoRectify(*cameraMatrix1, *distCoeffs1, *cameraMatrix2, *distCoeffs2,
		imageSize, *R, *T, *R1, *R2, *P1, *P2, *Q, flags, alpha, newImageSize,
		validPixROI1, validPixROI2);
}
CVAPI(void) calib3d_stereoRectify_array( double *cameraMatrix1, 
										 double *distCoeffs1, int dc1Size,
										 double *cameraMatrix2,
										 double *distCoeffs2, int dc2Size,
										 CvSize imageSize, 
										 double *R, double *T,
									     double *R1, double *R2, double *P1, double *P2,
									     double *Q, int flags, double alpha, cv::Size newImageSize,
									     cv::Rect* validPixROI1, cv::Rect* validPixROI2 )
{
	cv::Mat cameraMatrix1M(3, 3, CV_64FC1, cameraMatrix1);
	cv::Mat cameraMatrix2M(3, 3, CV_64FC1, cameraMatrix2);
	cv::Mat distCoeffs1M(dc1Size, 1, CV_64FC1, distCoeffs1);
	cv::Mat distCoeffs2M(dc2Size, 1, CV_64FC1, distCoeffs2);
	cv::Mat RM(3, 3, CV_64FC1, R);
	cv::Mat TM(1, 3, CV_64FC1, T);

	cv::Mat R1M(3, 3, CV_64FC1, R1);
	cv::Mat R2M(3, 3, CV_64FC1, R2);
	cv::Mat P1M(3, 4, CV_64FC1, P1);
	cv::Mat P2M(3, 4, CV_64FC1, P2);
	cv::Mat QM(3, 4, CV_64FC1, Q);

	cv::stereoRectify(cameraMatrix1M, distCoeffs1M, cameraMatrix2M, distCoeffs2M,
		imageSize, RM, TM, R1M, R2M, P1M, P2M, QM, flags, alpha, newImageSize,
		validPixROI1, validPixROI2);
}

CVAPI(int) calib3d_stereoRectifyUncalibrated_InputArray( cv::_InputArray *points1, cv::_InputArray *points2,
                                             cv::_InputArray *F, CvSize imgSize,
                                             cv::_OutputArray *H1, cv::_OutputArray *H2,
                                             double threshold )
{
	return cv::stereoRectifyUncalibrated(*points1, *points2, *F, imgSize, *H1, *H2, threshold) ? 1 : 0;
}
CVAPI(int) calib3d_stereoRectifyUncalibrated_array( cv::Point2d *points1, int points1Size,
												   cv::Point2d *points2, int points2Size,
                                             cv::_InputArray *F, CvSize imgSize,
                                             double *H1, double *H2,
                                             double threshold )
{
	std::vector<cv::Point2d> points1Vec(points1, points1 + points1Size);
	std::vector<cv::Point2d> points2Vec(points2, points2 + points2Size);
	cv::Mat H1M(3, 3, CV_64FC1, H1);
	cv::Mat H2M(3, 3, CV_64FC1, H2);
	return cv::stereoRectifyUncalibrated(points1Vec, points2Vec, *F, imgSize, H1M, H2M, threshold) ? 1 : 0;
}

CVAPI(float) calib3d_rectify3Collinear_InputArray( 
								cv::_InputArray *cameraMatrix1, cv::_InputArray *distCoeffs1,
                                cv::_InputArray *cameraMatrix2, cv::_InputArray *distCoeffs2,
                                cv::_InputArray *cameraMatrix3, cv::_InputArray *distCoeffs3,
								cv::_InputArray **imgpt1, int imgpt1Size,
								cv::_InputArray **imgpt3, int imgpt3Size,
                                cv::Size imageSize, cv::_InputArray *R12, cv::_InputArray *T12,
                                cv::_InputArray *R13, cv::_InputArray *T13,
                                cv::_OutputArray *R1, cv::_OutputArray *R2, cv::_OutputArray *R3,
                                cv::_OutputArray *P1, cv::_OutputArray *P2, cv::_OutputArray *P3,
                                cv::_OutputArray *Q, double alpha, cv::Size newImgSize,
                                cv::Rect *roi1, cv::Rect *roi2, int flags )
{
	std::vector<cv::_InputArray> imgpt1Vec(imgpt1Size);
	std::vector<cv::_InputArray> imgpt3Vec(imgpt3Size);
	for (int i = 0; i < imgpt1Size; i++)
		imgpt1Vec[i] = *(imgpt1[i]);
	for (int i = 0; i < imgpt1Size; i++)
		imgpt3Vec[i] = *(imgpt3[i]);

	return cv::rectify3Collinear(*cameraMatrix1, *distCoeffs1, 
		*cameraMatrix2, *distCoeffs2, *cameraMatrix3, *distCoeffs3,
		imgpt1Vec, imgpt3Vec, imageSize, *R12, *T12, *R13, *T13,
		*R1, *R2, *R3, *P1, *P2, *P3, *Q, alpha, newImgSize,
		roi1, roi2, flags);
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