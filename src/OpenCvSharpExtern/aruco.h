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
	const interop::InputOutputArrayProxy* image,
	cv::Point2f** corners,
	int cornerSize1,
	int* cornerSize2,
	int* idx, int idxCount,
	interop::Scalar borderColor)
{
	return cvTry([&] {
	std::vector< std::vector<cv::Point2f> > cornerVec(cornerSize1);
	std::vector<int> idxVec;

	for (int i = 0; i < cornerSize1; i++)
		cornerVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornerSize2[i]);
	if (idx != nullptr)
		idxVec = std::vector<int>(idx, idx + idxCount);

	cv::aruco::drawDetectedMarkers(IoProxy(*image), cornerVec, idxVec, cpp(borderColor));
	});
}

CVAPI(ExceptionStatus) aruco_getPredefinedDictionary(int name, cv::aruco::Dictionary** returnValue)
{
	return cvTry([&] {
	const auto dictionary = cv::aruco::getPredefinedDictionary(name);
	*returnValue = new cv::aruco::Dictionary(dictionary);
	});
}

CVAPI(ExceptionStatus) aruco_readDictionary(const char* dictionaryFile, cv::aruco::Dictionary** returnValue)
{
	return cvTry([&] {

	auto readMode = cv::FileStorage::READ | cv::FileStorage::FORMAT_YAML;
	cv::FileStorage storeage(dictionaryFile, readMode);
	cv::FileNode rootNode = storeage.root();

	cv::aruco::Dictionary dictionary;
	auto result = dictionary.readDictionary(rootNode);

	storeage.release();

	*returnValue = new cv::aruco::Dictionary(dictionary);

	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_delete(cv::aruco::Dictionary* ptr)
{
	return cvTry([&] {
	delete ptr;
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_setMarkerSize(cv::aruco::Dictionary* obj, int value)
{
	return cvTry([&] {
	obj->markerSize = value;
	});
}
CVAPI(ExceptionStatus) aruco_Dictionary_setMaxCorrectionBits(cv::aruco::Dictionary* obj, int value)
{
	return cvTry([&] {
	obj->maxCorrectionBits = value;
	});
}
CVAPI(ExceptionStatus) aruco_Dictionary_getBytesList(cv::aruco::Dictionary* obj, cv::Mat** returnValue)
{
	return cvTry([&] {
	* returnValue = new cv::Mat(obj->bytesList);
	});
}
CVAPI(ExceptionStatus) aruco_Dictionary_getMarkerSize(cv::aruco::Dictionary* obj, int* returnValue)
{
	return cvTry([&] {
	*returnValue = obj->markerSize;
	});
}
CVAPI(ExceptionStatus) aruco_Dictionary_getMaxCorrectionBits(cv::aruco::Dictionary* obj, int* returnValue)
{
	return cvTry([&] {
	*returnValue = obj->maxCorrectionBits;
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_identify(
	cv::aruco::Dictionary* obj,
	cv::Mat *onlyBits,
	int *idx,
	int *rotation,
	double maxCorrectionRate,
	int* returnValue)
{
	return cvTry([&] {
	*returnValue = obj->identify(*onlyBits, *idx, *rotation, maxCorrectionRate) != 0;
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_getDistanceToId(
	cv::aruco::Dictionary* obj,
	const interop::InputArrayProxy* bits,
	int id,
	int allRotations,
	int* returnValue)
{
	return cvTry([&] {
	*returnValue = obj->getDistanceToId(InProxy(*bits), id, allRotations != 0);
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_generateImageMarker(
	cv::aruco::Dictionary* obj,
	int id,
	int sidePixels,
	const interop::OutputArrayProxy* img,
	int borderBits)
{
	return cvTry([&] {
	obj->generateImageMarker(id, sidePixels, OutProxy(*img), borderBits);
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_getByteListFromBits(
	cv::Mat *bits,
	cv::Mat* returnValue)
{
	return cvTry([&] {
	const auto result = cv::aruco::Dictionary::getByteListFromBits(*bits);
	result.copyTo(*returnValue);
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_getBitsFromByteList(
	cv::Mat *byteList,
	int markerSize,
	cv::Mat* returnValue)
{
	return cvTry([&] {
	const auto result = cv::aruco::Dictionary::getBitsFromByteList(*byteList, markerSize);
	result.copyTo(*returnValue);
	});
}

CVAPI(ExceptionStatus) aruco_drawDetectedDiamonds(
	const interop::InputOutputArrayProxy* image,
	cv::Point2f** corners,
	int cornerSize1,
	int* cornerSize2,
	std::vector<cv::Vec4i>* ids,
	interop::Scalar borderColor)
{
	return cvTry([&] {
		std::vector< std::vector<cv::Point2f> > cornerVec(cornerSize1);

	for (int i = 0; i < cornerSize1; i++)
		cornerVec[i] = std::vector<cv::Point2f>(corners[i], corners[i] + cornerSize2[i]);

	const cv::_InputArray idArray = (ids != nullptr) ? *ids : static_cast<cv::_InputArray>(cv::noArray());

	cv::aruco::drawDetectedDiamonds(IoProxy(*image), cornerVec, idArray, cpp(borderColor));
	});
}

CVAPI(ExceptionStatus) aruco_drawDetectedCornersCharuco(
	const interop::InputOutputArrayProxy* image,
	std::vector<cv::Point2f>* corners,
	std::vector<int>* ids,
	interop::Scalar cornerColor)
{
	return cvTry([&] {
	cv::_InputArray idArray = cv::noArray();
	if (ids != nullptr) idArray = *ids;
	cv::aruco::drawDetectedCornersCharuco(IoProxy(*image), *corners, idArray, cpp(cornerColor));
	});
}

// ==================== ArucoDetector ====================

CVAPI(ExceptionStatus) aruco_ArucoDetector_create(
	cv::aruco::Dictionary* dictionary,
	aruco_DetectorParameters* detectorParams,
	aruco_RefineParameters* refineParams,
	cv::aruco::ArucoDetector** returnValue)
{
	return cvTry([&] {
	const auto dp = cpp(*detectorParams);
	const auto rp = cv::aruco::RefineParameters(refineParams->minRepDistance, refineParams->errorCorrectionRate, refineParams->checkAllOrders);
	*returnValue = new cv::aruco::ArucoDetector(*dictionary, dp, rp);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_delete(cv::aruco::ArucoDetector* ptr)
{
	return cvTry([&] {
	delete ptr;
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_detectMarkers(
	cv::aruco::ArucoDetector* detector,
	const interop::InputArrayProxy* image,
	std::vector<std::vector<cv::Point2f>>* corners,
	std::vector<int>* ids,
	std::vector<std::vector<cv::Point2f>>* rejectedImgPoints)
{
	return cvTry([&] {
	detector->detectMarkers(InProxy(*image), *corners, *ids, *rejectedImgPoints);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_refineDetectedMarkers(
	cv::aruco::ArucoDetector* detector,
	const interop::InputArrayProxy* image,
	cv::aruco::Board* board,
	std::vector<std::vector<cv::Point2f>>* detectedCorners,
	std::vector<int>* detectedIds,
	std::vector<std::vector<cv::Point2f>>* rejectedCorners,
	const interop::InputArrayProxy* cameraMatrix,
	const interop::InputArrayProxy* distCoeffs,
	std::vector<int>* recoveredIdxs)
{
	return cvTry([&] {
	cv::_OutputArray recoveredIdxsArr = cv::noArray();
	if (recoveredIdxs != nullptr) recoveredIdxsArr = *recoveredIdxs;
	detector->refineDetectedMarkers(InProxy(*image), *board, *detectedCorners, *detectedIds, *rejectedCorners,
		InProxy(*cameraMatrix), InProxy(*distCoeffs), recoveredIdxsArr);
	});
}

// ==================== CharucoBoard ====================

CVAPI(ExceptionStatus) aruco_CharucoBoard_create(
	int squaresX, int squaresY,
	float squareLength, float markerLength,
	cv::aruco::Dictionary* dictionary,
	cv::aruco::CharucoBoard** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::CharucoBoard(cv::Size(squaresX, squaresY), squareLength, markerLength, *dictionary);
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_delete(cv::aruco::CharucoBoard* ptr)
{
	return cvTry([&] {
	delete ptr;
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getChessboardSize(cv::aruco::CharucoBoard* ptr, interop::Size* returnValue)
{
	return cvTry([&] {
	const auto s = ptr->getChessboardSize();
	returnValue->width = s.width;
	returnValue->height = s.height;
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getSquareLength(cv::aruco::CharucoBoard* ptr, float* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getSquareLength();
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getMarkerLength(cv::aruco::CharucoBoard* ptr, float* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getMarkerLength();
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_setLegacyPattern(cv::aruco::CharucoBoard* ptr, int value)
{
	return cvTry([&] {
	ptr->setLegacyPattern(value != 0);
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getLegacyPattern(cv::aruco::CharucoBoard* ptr, int* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getLegacyPattern() ? 1 : 0;
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_generateImage(
	cv::aruco::CharucoBoard* ptr,
	interop::Size outSize,
	const interop::OutputArrayProxy* img,
	int marginSize,
	int borderBits)
{
	return cvTry([&] {
	ptr->generateImage(cpp(outSize), OutProxy(*img), marginSize, borderBits);
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_checkCharucoCornersCollinear(
	cv::aruco::CharucoBoard* ptr,
	const interop::InputArrayProxy* charucoIds,
	int* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->checkCharucoCornersCollinear(InProxy(*charucoIds)) ? 1 : 0;
	});
}

// ==================== CharucoDetector ====================

CVAPI(ExceptionStatus) aruco_CharucoDetector_create(
	cv::aruco::CharucoBoard* board,
	const interop::InputArrayProxy* cameraMatrix,
	const interop::InputArrayProxy* distCoeffs,
	int minMarkers,
	bool tryRefineMarkers,
	bool checkMarkers,
	aruco_DetectorParameters* detectorParams,
	aruco_RefineParameters* refineParams,
	cv::aruco::CharucoDetector** returnValue)
{
	return cvTry([&] {
	cv::aruco::CharucoParameters cp;
	cv::Scalar cameraMatrixScratch, distCoeffsScratch;
	const cv::_InputArray cameraMatrixArr = fromInputProxy(*cameraMatrix, cameraMatrixScratch);
	const cv::_InputArray distCoeffsArr = fromInputProxy(*distCoeffs, distCoeffsScratch);
	if (!cameraMatrixArr.empty())
		cp.cameraMatrix = cameraMatrixArr.getMat();
	if (!distCoeffsArr.empty())
		cp.distCoeffs = distCoeffsArr.getMat();
	cp.minMarkers = minMarkers;
	cp.tryRefineMarkers = tryRefineMarkers;
	cp.checkMarkers = checkMarkers;
	const auto dp = cpp(*detectorParams);
	const auto rp = cv::aruco::RefineParameters(refineParams->minRepDistance, refineParams->errorCorrectionRate, refineParams->checkAllOrders);
	*returnValue = new cv::aruco::CharucoDetector(*board, cp, dp, rp);
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_delete(cv::aruco::CharucoDetector* ptr)
{
	return cvTry([&] {
	delete ptr;
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_detectBoard(
	cv::aruco::CharucoDetector* detector,
	const interop::InputArrayProxy* image,
	std::vector<cv::Point2f>* charucoCorners,
	std::vector<int>* charucoIds,
	std::vector<std::vector<cv::Point2f>>* markerCorners,
	std::vector<int>* markerIds)
{
	return cvTry([&] {
	cv::Mat charucoCorners_mat, charucoIds_mat;
	detector->detectBoard(InProxy(*image), charucoCorners_mat, charucoIds_mat, *markerCorners, *markerIds);
	for (int i = 0; i < charucoCorners_mat.rows; ++i)
	{
		charucoCorners->push_back(charucoCorners_mat.at<cv::Point2f>(i, 0));
		charucoIds->push_back(charucoIds_mat.at<int>(i, 0));
	}
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_detectDiamonds(
	cv::aruco::CharucoDetector* detector,
	const interop::InputArrayProxy* image,
	std::vector<std::vector<cv::Point2f>>* diamondCorners,
	std::vector<cv::Vec4i>* diamondIds,
	std::vector<std::vector<cv::Point2f>>* markerCorners,
	std::vector<int>* markerIds)
{
	return cvTry([&] {
	detector->detectDiamonds(InProxy(*image), *diamondCorners, *diamondIds, *markerCorners, *markerIds);
	});
}

#endif // NO_CONTRIB
