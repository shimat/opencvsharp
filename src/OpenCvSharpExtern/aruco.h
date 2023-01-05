#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

extern "C"
{
	struct aruco_DetectorParameters
	{
		int adaptiveThreshWinSizeMin;
		int adaptiveThreshWinSizeMax;
		int adaptiveThreshWinSizeStep;
		double adaptiveThreshConstant;		
		double minMarkerPerimeterRate;
		double maxMarkerPerimeterRate;
		double polygonalApproxAccuracyRate;
		double minCornerDistanceRate;
		int minDistanceToBorder;		
		double minMarkerDistanceRate;
		int cornerRefinementMethod;
		int cornerRefinementWinSize;
		int cornerRefinementMaxIterations;
		double cornerRefinementMinAccuracy;
		int markerBorderBits;
		int perspectiveRemovePixelPerCell;
		double perspectiveRemoveIgnoredMarginPerCell;
		double maxErroneousBitsInBorderRate;
		double minOtsuStdDev;
		double errorCorrectionRate;
		float aprilTagQuadDecimate;
		float aprilTagQuadSigma;
		int aprilTagMinClusterPixels;
		int aprilTagMaxNmaxima;
		float aprilTagCriticalRad;
		float aprilTagMaxLineFitMse;
		int aprilTagMinWhiteBlackDiff;
		int aprilTagDeglitch;
		bool detectInvertedMarker;
		bool useAruco3Detection;
		int minSideLengthCanonicalImg;
		float minMarkerLengthRatioOriginalImg;
	};
}

static cv::aruco::DetectorParameters cpp(const aruco_DetectorParameters& p)
{
	cv::aruco::DetectorParameters pp;
	pp.adaptiveThreshWinSizeMin = p.adaptiveThreshWinSizeMin;
	pp.adaptiveThreshWinSizeMax = p.adaptiveThreshWinSizeMax;
	pp.adaptiveThreshWinSizeStep = p.adaptiveThreshWinSizeStep;
	pp.adaptiveThreshConstant = p.adaptiveThreshConstant;
	pp.minMarkerPerimeterRate = p.minMarkerPerimeterRate;
	pp.maxMarkerPerimeterRate = p.maxMarkerPerimeterRate;
	pp.polygonalApproxAccuracyRate = p.polygonalApproxAccuracyRate;
	pp.minCornerDistanceRate = p.minCornerDistanceRate;
	pp.minDistanceToBorder = p.minDistanceToBorder;
	pp.minMarkerDistanceRate = p.minMarkerDistanceRate;
	pp.cornerRefinementMethod = static_cast<cv::aruco::CornerRefineMethod>(p.cornerRefinementMethod);
	pp.cornerRefinementWinSize = p.cornerRefinementWinSize;
	pp.cornerRefinementMaxIterations = p.cornerRefinementMaxIterations;
	pp.cornerRefinementMinAccuracy = p.cornerRefinementMinAccuracy;
	pp.markerBorderBits = p.markerBorderBits;
	pp.perspectiveRemovePixelPerCell = p.perspectiveRemovePixelPerCell;
	pp.perspectiveRemoveIgnoredMarginPerCell = p.perspectiveRemoveIgnoredMarginPerCell;
	pp.maxErroneousBitsInBorderRate = p.maxErroneousBitsInBorderRate;
	pp.minOtsuStdDev = p.minOtsuStdDev;
	pp.errorCorrectionRate = p.errorCorrectionRate;
	pp.aprilTagQuadDecimate = p.aprilTagQuadDecimate;
	pp.aprilTagQuadSigma = p.aprilTagQuadSigma;
	pp.aprilTagMinClusterPixels = p.aprilTagMinClusterPixels;
	pp.aprilTagMaxNmaxima = p.aprilTagMaxNmaxima;
	pp.aprilTagCriticalRad = p.aprilTagCriticalRad;
	pp.aprilTagMaxLineFitMse = p.aprilTagMaxLineFitMse;
	pp.aprilTagDeglitch = p.aprilTagDeglitch;
	pp.aprilTagMinWhiteBlackDiff = p.aprilTagMinWhiteBlackDiff;
	pp.detectInvertedMarker = p.detectInvertedMarker;	
	pp.useAruco3Detection = p.useAruco3Detection;
	pp.minSideLengthCanonicalImg = p.minSideLengthCanonicalImg;
	pp.minMarkerLengthRatioOriginalImg = p.minMarkerLengthRatioOriginalImg;
	return pp;
}

CVAPI(ExceptionStatus) aruco_drawDetectedMarkers(
	cv::_InputOutputArray* image,
	cv::Point2f** corners,
	int cornerSize1,
	int* cornerSize2,
	int* idx, int idxCount, 
	MyCvScalar borderColor)
{
	BEGIN_WRAP
	std::vector< std::vector<cv::Point2f> > cornerVec(cornerSize1);
	std::vector<int> idxVec;

	for (int i = 0; i < cornerSize1; i++)
		cornerVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornerSize2[i]);
	if (idx != nullptr)
		idxVec = std::vector<int>(idx, idx + idxCount);

	cv::aruco::drawDetectedMarkers(*image, cornerVec, idxVec, cpp(borderColor));
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_detectMarkers(
	cv::_InputArray* image,
	cv::aruco::Dictionary* dictionary,
	std::vector< std::vector<cv::Point2f> >* corners,
	std::vector<int>* ids,
	aruco_DetectorParameters* parameters,
	std::vector< std::vector<cv::Point2f> >* rejectedImgPoints)
{
	BEGIN_WRAP
	const auto p = cpp(*parameters);
	const auto pp = cv::makePtr<cv::aruco::DetectorParameters>(p);
	const auto d = cv::makePtr<cv::aruco::Dictionary>(*dictionary);
	cv::aruco::detectMarkers(*image, d, *corners, *ids, pp, *rejectedImgPoints);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_estimatePoseSingleMarkers(
	cv::Point2f** corners, int cornersLength1,
	int* cornersLengths2, float markerLength,
	cv::_InputArray* cameraMatrix,
	cv::_InputArray* distCoeffs,
	cv::_OutputArray* rvecs,
	cv::_OutputArray* tvecs,
	cv::_OutputArray* objPoints)
{
	BEGIN_WRAP
		std::vector<std::vector<cv::Point2f> > cornersVec(cornersLength1);
	for (int i = 0; i < cornersLength1; i++)
		cornersVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornersLengths2[i]);

	cv::aruco::estimatePoseSingleMarkers(cornersVec, markerLength, *cameraMatrix, *distCoeffs, *rvecs, *tvecs, entity(objPoints));
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_getPredefinedDictionary(int name, cv::aruco::Dictionary** returnValue)
{
	BEGIN_WRAP
	const auto dictionary = cv::aruco::getPredefinedDictionary(name);
	*returnValue = new cv::aruco::Dictionary(dictionary);
	END_WRAP
}


CVAPI(ExceptionStatus) aruco_Dictionary_delete(cv::aruco::Dictionary* ptr)
{
	BEGIN_WRAP
	delete ptr;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_Dictionary_setMarkerSize(cv::aruco::Dictionary* obj, int value)
{
	BEGIN_WRAP
	obj->markerSize = value;
	END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_setMaxCorrectionBits(cv::aruco::Dictionary* obj, int value)
{
	BEGIN_WRAP
	obj->maxCorrectionBits = value;
	END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_getBytesList(cv::aruco::Dictionary* obj, cv::Mat** returnValue)
{
	BEGIN_WRAP
	* returnValue = new cv::Mat(obj->bytesList);
	END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_getMarkerSize(cv::aruco::Dictionary* obj, int* returnValue)
{
	BEGIN_WRAP
	*returnValue = obj->markerSize;
	END_WRAP
}
CVAPI(ExceptionStatus) aruco_Dictionary_getMaxCorrectionBits(cv::aruco::Dictionary* obj, int* returnValue)
{
	BEGIN_WRAP
	*returnValue = obj->maxCorrectionBits;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_Dictionary_identify(
	cv::aruco::Dictionary* obj, 
	cv::Mat *onlyBits,
	int *idx,
	int *rotation,
	double maxCorrectionRate,
	int* returnValue)
{
	BEGIN_WRAP
	*returnValue = obj->identify(*onlyBits, *idx, *rotation, maxCorrectionRate) != 0;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_Dictionary_getDistanceToId(
	cv::aruco::Dictionary* obj, 
	cv::_InputArray *bits,
	int id,
	int allRotations,
	int* returnValue)
{
	BEGIN_WRAP
	*returnValue = obj->getDistanceToId(*bits, id, allRotations != 0);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_Dictionary_generateImageMarker(
	cv::aruco::Dictionary* obj,
	int id,
	int sidePixels,
	cv::_OutputArray *img,
	int borderBits)
{
	BEGIN_WRAP
	obj->generateImageMarker(id, sidePixels, *img, borderBits);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_Dictionary_getByteListFromBits(
	cv::Mat *bits,
	cv::Mat* returnValue)
{
	BEGIN_WRAP
	const auto result = cv::aruco::Dictionary::getByteListFromBits(*bits);
	result.copyTo(*returnValue);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_Dictionary_getBitsFromByteList(
	cv::Mat *byteList,
	int markerSize,
	cv::Mat* returnValue)
{
	BEGIN_WRAP
	const auto result = cv::aruco::Dictionary::getBitsFromByteList(*byteList, markerSize);
	result.copyTo(*returnValue);
	END_WRAP
}


CVAPI(ExceptionStatus) aruco_detectCharucoDiamond(
	cv::_InputArray* image,
	cv::Point2f** markerCorners,
	int markerCornersSize1,
	int* markerCornersSize2,
	std::vector<int>* markerIds,
	float squareMarkerLengthRate,
	std::vector< std::vector<cv::Point2f> >* diamondCorners,
	std::vector<cv::Vec4i>* diamondIds,
	cv::_InputArray* cameraMatrix, cv::_InputArray* distCoeffs)
{
	BEGIN_WRAP
		std::vector< std::vector<cv::Point2f> > markerCornerVec(markerCornersSize1);
	for (int i = 0; i < markerCornersSize1; i++)
		markerCornerVec[i] = std::vector<cv::Point2f>(markerCorners[i], markerCorners[i] + markerCornersSize2[i]);

	cv::aruco::detectCharucoDiamond(*image, markerCornerVec, *markerIds, squareMarkerLengthRate,
		*diamondCorners, *diamondIds, entity(cameraMatrix), entity(distCoeffs));
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_drawDetectedDiamonds(
	cv::_InputOutputArray* image,
	cv::Point2f** corners,
	int cornerSize1,
	int* cornerSize2,
	std::vector<cv::Vec4i>* ids,
	MyCvScalar borderColor)
{
	BEGIN_WRAP
		std::vector< std::vector<cv::Point2f> > cornerVec(cornerSize1);

	for (int i = 0; i < cornerSize1; i++)
		cornerVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornerSize2[i]);

	const cv::_InputArray idArray = (ids != nullptr) ? *ids : static_cast<cv::_InputArray>(cv::noArray());

	cv::aruco::drawDetectedDiamonds(*image, cornerVec, idArray, cpp(borderColor));
	END_WRAP
}
