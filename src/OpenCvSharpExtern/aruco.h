#pragma once

#ifndef NO_CONTRIB

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
		float minGroupDistance;
		int cornerRefinementMethod;
		int cornerRefinementWinSize;
		float relativeCornerRefinmentWinSize;
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

	struct aruco_RefineParameters
	{
		float minRepDistance;
		float errorCorrectionRate;
		bool checkAllOrders;
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
	pp.minGroupDistance = p.minGroupDistance;
	pp.cornerRefinementMethod = static_cast<cv::aruco::CornerRefineMethod>(p.cornerRefinementMethod);
	pp.cornerRefinementWinSize = p.cornerRefinementWinSize;
	pp.relativeCornerRefinmentWinSize = p.relativeCornerRefinmentWinSize;
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

CVAPI(ExceptionStatus) aruco_getPredefinedDictionary(int name, cv::aruco::Dictionary** returnValue)
{
	BEGIN_WRAP
	const auto dictionary = cv::aruco::getPredefinedDictionary(name);
	*returnValue = new cv::aruco::Dictionary(dictionary);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_readDictionary(const char* dictionaryFile, cv::aruco::Dictionary** returnValue)
{
	BEGIN_WRAP

	auto readMode = cv::FileStorage::READ | cv::FileStorage::FORMAT_YAML;
	cv::FileStorage storeage(dictionaryFile, readMode);
	cv::FileNode rootNode = storeage.root();

	cv::aruco::Dictionary dictionary;
	auto result = dictionary.readDictionary(rootNode);

	storeage.release();

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

CVAPI(ExceptionStatus) aruco_drawDetectedCornersCharuco(
	cv::_InputOutputArray* image,
	std::vector<cv::Point2f>* corners,
	std::vector<int>* ids,
	MyCvScalar cornerColor)
{
	BEGIN_WRAP
	cv::aruco::drawDetectedCornersCharuco(*image, *corners, *ids, cpp(cornerColor));
	END_WRAP
}

// ==================== ArucoDetector ====================

CVAPI(ExceptionStatus) aruco_ArucoDetector_create(
	cv::aruco::Dictionary* dictionary,
	aruco_DetectorParameters* detectorParams,
	aruco_RefineParameters* refineParams,
	cv::aruco::ArucoDetector** returnValue)
{
	BEGIN_WRAP
	const auto dp = cpp(*detectorParams);
	const auto rp = cv::aruco::RefineParameters(refineParams->minRepDistance, refineParams->errorCorrectionRate, refineParams->checkAllOrders);
	*returnValue = new cv::aruco::ArucoDetector(*dictionary, dp, rp);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_delete(cv::aruco::ArucoDetector* ptr)
{
	BEGIN_WRAP
	delete ptr;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_detectMarkers(
	cv::aruco::ArucoDetector* detector,
	cv::_InputArray* image,
	std::vector<std::vector<cv::Point2f>>* corners,
	std::vector<int>* ids,
	std::vector<std::vector<cv::Point2f>>* rejectedImgPoints)
{
	BEGIN_WRAP
	detector->detectMarkers(*image, *corners, *ids, *rejectedImgPoints);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_refineDetectedMarkers(
	cv::aruco::ArucoDetector* detector,
	cv::_InputArray* image,
	cv::aruco::Board* board,
	std::vector<std::vector<cv::Point2f>>* detectedCorners,
	std::vector<int>* detectedIds,
	std::vector<std::vector<cv::Point2f>>* rejectedCorners,
	cv::_InputArray* cameraMatrix,
	cv::_InputArray* distCoeffs,
	std::vector<int>* recoveredIdxs)
{
	BEGIN_WRAP
	detector->refineDetectedMarkers(*image, *board, *detectedCorners, *detectedIds, *rejectedCorners,
		entity(cameraMatrix), entity(distCoeffs), entity(recoveredIdxs));
	END_WRAP
}

// ==================== CharucoBoard ====================

CVAPI(ExceptionStatus) aruco_CharucoBoard_create(
	int squaresX, int squaresY,
	float squareLength, float markerLength,
	cv::aruco::Dictionary* dictionary,
	cv::aruco::CharucoBoard** returnValue)
{
	BEGIN_WRAP
	*returnValue = new cv::aruco::CharucoBoard(cv::Size(squaresX, squaresY), squareLength, markerLength, *dictionary);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_delete(cv::aruco::CharucoBoard* ptr)
{
	BEGIN_WRAP
	delete ptr;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getChessboardSize(cv::aruco::CharucoBoard* ptr, MyCvSize* returnValue)
{
	BEGIN_WRAP
	const auto s = ptr->getChessboardSize();
	returnValue->width = s.width;
	returnValue->height = s.height;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getSquareLength(cv::aruco::CharucoBoard* ptr, float* returnValue)
{
	BEGIN_WRAP
	*returnValue = ptr->getSquareLength();
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getMarkerLength(cv::aruco::CharucoBoard* ptr, float* returnValue)
{
	BEGIN_WRAP
	*returnValue = ptr->getMarkerLength();
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_setLegacyPattern(cv::aruco::CharucoBoard* ptr, int value)
{
	BEGIN_WRAP
	ptr->setLegacyPattern(value != 0);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getLegacyPattern(cv::aruco::CharucoBoard* ptr, int* returnValue)
{
	BEGIN_WRAP
	*returnValue = ptr->getLegacyPattern() ? 1 : 0;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_generateImage(
	cv::aruco::CharucoBoard* ptr,
	MyCvSize outSize,
	cv::_OutputArray* img,
	int marginSize,
	int borderBits)
{
	BEGIN_WRAP
	ptr->generateImage(cpp(outSize), *img, marginSize, borderBits);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_checkCharucoCornersCollinear(
	cv::aruco::CharucoBoard* ptr,
	cv::_InputArray* charucoIds,
	int* returnValue)
{
	BEGIN_WRAP
	*returnValue = ptr->checkCharucoCornersCollinear(*charucoIds) ? 1 : 0;
	END_WRAP
}

// ==================== CharucoDetector ====================

CVAPI(ExceptionStatus) aruco_CharucoDetector_create(
	cv::aruco::CharucoBoard* board,
	cv::_InputArray* cameraMatrix,
	cv::_InputArray* distCoeffs,
	int minMarkers,
	bool tryRefineMarkers,
	bool checkMarkers,
	aruco_DetectorParameters* detectorParams,
	aruco_RefineParameters* refineParams,
	cv::aruco::CharucoDetector** returnValue)
{
	BEGIN_WRAP
	cv::aruco::CharucoParameters cp;
	if (cameraMatrix != nullptr)
		cp.cameraMatrix = cameraMatrix->getMat();
	if (distCoeffs != nullptr)
		cp.distCoeffs = distCoeffs->getMat();
	cp.minMarkers = minMarkers;
	cp.tryRefineMarkers = tryRefineMarkers;
	cp.checkMarkers = checkMarkers;
	const auto dp = cpp(*detectorParams);
	const auto rp = cv::aruco::RefineParameters(refineParams->minRepDistance, refineParams->errorCorrectionRate, refineParams->checkAllOrders);
	*returnValue = new cv::aruco::CharucoDetector(*board, cp, dp, rp);
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_delete(cv::aruco::CharucoDetector* ptr)
{
	BEGIN_WRAP
	delete ptr;
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_detectBoard(
	cv::aruco::CharucoDetector* detector,
	cv::_InputArray* image,
	std::vector<cv::Point2f>* charucoCorners,
	std::vector<int>* charucoIds,
	std::vector<std::vector<cv::Point2f>>* markerCorners,
	std::vector<int>* markerIds)
{
	BEGIN_WRAP
	cv::Mat charucoCorners_mat, charucoIds_mat;
	detector->detectBoard(*image, charucoCorners_mat, charucoIds_mat, *markerCorners, *markerIds);
	for (int i = 0; i < charucoCorners_mat.rows; ++i)
	{
		charucoCorners->push_back(charucoCorners_mat.at<cv::Point2f>(i, 0));
		charucoIds->push_back(charucoIds_mat.at<int>(i, 0));
	}
	END_WRAP
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_detectDiamonds(
	cv::aruco::CharucoDetector* detector,
	cv::_InputArray* image,
	std::vector<std::vector<cv::Point2f>>* diamondCorners,
	std::vector<cv::Vec4i>* diamondIds,
	std::vector<std::vector<cv::Point2f>>* markerCorners,
	std::vector<int>* markerIds)
{
	BEGIN_WRAP
	detector->detectDiamonds(*image, *diamondCorners, *diamondIds, *markerCorners, *markerIds);
	END_WRAP
}

#endif // NO_CONTRIB
