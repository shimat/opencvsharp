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

static aruco_DetectorParameters c(const cv::aruco::DetectorParameters& pp)
{
	aruco_DetectorParameters p{};
	p.adaptiveThreshWinSizeMin = pp.adaptiveThreshWinSizeMin;
	p.adaptiveThreshWinSizeMax = pp.adaptiveThreshWinSizeMax;
	p.adaptiveThreshWinSizeStep = pp.adaptiveThreshWinSizeStep;
	p.adaptiveThreshConstant = pp.adaptiveThreshConstant;
	p.minMarkerPerimeterRate = pp.minMarkerPerimeterRate;
	p.maxMarkerPerimeterRate = pp.maxMarkerPerimeterRate;
	p.polygonalApproxAccuracyRate = pp.polygonalApproxAccuracyRate;
	p.minCornerDistanceRate = pp.minCornerDistanceRate;
	p.minDistanceToBorder = pp.minDistanceToBorder;
	p.minMarkerDistanceRate = pp.minMarkerDistanceRate;
	p.minGroupDistance = pp.minGroupDistance;
	p.cornerRefinementMethod = pp.cornerRefinementMethod;
	p.cornerRefinementWinSize = pp.cornerRefinementWinSize;
	p.relativeCornerRefinmentWinSize = pp.relativeCornerRefinmentWinSize;
	p.cornerRefinementMaxIterations = pp.cornerRefinementMaxIterations;
	p.cornerRefinementMinAccuracy = pp.cornerRefinementMinAccuracy;
	p.markerBorderBits = pp.markerBorderBits;
	p.perspectiveRemovePixelPerCell = pp.perspectiveRemovePixelPerCell;
	p.perspectiveRemoveIgnoredMarginPerCell = pp.perspectiveRemoveIgnoredMarginPerCell;
	p.maxErroneousBitsInBorderRate = pp.maxErroneousBitsInBorderRate;
	p.minOtsuStdDev = pp.minOtsuStdDev;
	p.errorCorrectionRate = pp.errorCorrectionRate;
	p.aprilTagQuadDecimate = pp.aprilTagQuadDecimate;
	p.aprilTagQuadSigma = pp.aprilTagQuadSigma;
	p.aprilTagMinClusterPixels = pp.aprilTagMinClusterPixels;
	p.aprilTagMaxNmaxima = pp.aprilTagMaxNmaxima;
	p.aprilTagCriticalRad = pp.aprilTagCriticalRad;
	p.aprilTagMaxLineFitMse = pp.aprilTagMaxLineFitMse;
	p.aprilTagDeglitch = pp.aprilTagDeglitch;
	p.aprilTagMinWhiteBlackDiff = pp.aprilTagMinWhiteBlackDiff;
	p.detectInvertedMarker = pp.detectInvertedMarker;
	p.useAruco3Detection = pp.useAruco3Detection;
	p.minSideLengthCanonicalImg = pp.minSideLengthCanonicalImg;
	p.minMarkerLengthRatioOriginalImg = pp.minMarkerLengthRatioOriginalImg;
	return p;
}

static aruco_RefineParameters c(const cv::aruco::RefineParameters& pp)
{
	aruco_RefineParameters p{};
	p.minRepDistance = pp.minRepDistance;
	p.errorCorrectionRate = pp.errorCorrectionRate;
	p.checkAllOrders = pp.checkAllOrders;
	return p;
}

static cv::aruco::RefineParameters cpp(const aruco_RefineParameters& p)
{
	return cv::aruco::RefineParameters(p.minRepDistance, p.errorCorrectionRate, p.checkAllOrders);
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

CVAPI(ExceptionStatus) aruco_Dictionary_new_default(cv::aruco::Dictionary** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::Dictionary();
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_new(
	cv::Mat* bytesList, int markerSize, int maxCorrectionBits, cv::aruco::Dictionary** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::Dictionary(*bytesList, markerSize, maxCorrectionBits);
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_delete(cv::aruco::Dictionary* ptr)
{
	return cvTry([&] {
	delete ptr;
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_readDictionary(cv::aruco::Dictionary* obj, cv::FileNode* fn, int* returnValue)
{
	return cvTry([&] {
	*returnValue = obj->readDictionary(*fn) ? 1 : 0;
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_writeDictionary(cv::aruco::Dictionary* obj, cv::FileStorage* fs, const char* name)
{
	return cvTry([&] {
	obj->writeDictionary(*fs, cv::String(name));
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

CVAPI(ExceptionStatus) aruco_Dictionary_identify_withThreshold(
	const cv::aruco::Dictionary* obj,
	cv::Mat *onlyCellPixelRatio,
	int *idx,
	int *rotation,
	double maxCorrectionRate,
	float validBitIdThreshold,
	int* returnValue)
{
	return cvTry([&] {
	*returnValue = obj->identify(*onlyCellPixelRatio, *idx, *rotation, maxCorrectionRate, validBitIdThreshold) ? 1 : 0;
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
	int rotationId,
	cv::Mat* returnValue)
{
	return cvTry([&] {
	const auto result = cv::aruco::Dictionary::getBitsFromByteList(*byteList, markerSize, rotationId);
	result.copyTo(*returnValue);
	});
}

CVAPI(ExceptionStatus) aruco_Dictionary_getMarkerBits(
	const cv::aruco::Dictionary* obj,
	int markerId,
	int rotationId,
	cv::Mat* returnValue)
{
	return cvTry([&] {
	const auto result = obj->getMarkerBits(markerId, rotationId);
	result.copyTo(*returnValue);
	});
}

CVAPI(ExceptionStatus) aruco_extendDictionary(
	int nMarkers, int markerSize, cv::aruco::Dictionary* baseDictionary, int randomSeed,
	cv::aruco::Dictionary** returnValue)
{
	return cvTry([&] {
	const auto result = (baseDictionary == nullptr)
		? cv::aruco::extendDictionary(nMarkers, markerSize, cv::aruco::Dictionary(), randomSeed)
		: cv::aruco::extendDictionary(nMarkers, markerSize, *baseDictionary, randomSeed);
	*returnValue = new cv::aruco::Dictionary(result);
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
	const auto rp = cpp(*refineParams);
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
	cv::Point2f** detectedCorners, int detectedCornersSize1, int* detectedCornersSize2,
	int* detectedIds, int detectedIdsSize,
	cv::Point2f** rejectedCorners, int rejectedCornersSize1, int* rejectedCornersSize2,
	const interop::InputArrayProxy* cameraMatrix,
	const interop::InputArrayProxy* distCoeffs,
	std::vector<std::vector<cv::Point2f>>* outDetectedCorners,
	std::vector<int>* outDetectedIds,
	std::vector<std::vector<cv::Point2f>>* outRejectedCorners,
	std::vector<int>* recoveredIdxs)
{
	return cvTry([&] {
	std::vector<std::vector<cv::Point2f>> detectedCornersVec(detectedCornersSize1);
	for (int i = 0; i < detectedCornersSize1; i++)
		detectedCornersVec[i] = std::vector<cv::Point2f>(detectedCorners[i], detectedCorners[i] + detectedCornersSize2[i]);
	std::vector<int> detectedIdsVec(detectedIds, detectedIds + detectedIdsSize);
	std::vector<std::vector<cv::Point2f>> rejectedCornersVec(rejectedCornersSize1);
	for (int i = 0; i < rejectedCornersSize1; i++)
		rejectedCornersVec[i] = std::vector<cv::Point2f>(rejectedCorners[i], rejectedCorners[i] + rejectedCornersSize2[i]);

	cv::_OutputArray recoveredIdxsArr = cv::noArray();
	if (recoveredIdxs != nullptr) recoveredIdxsArr = *recoveredIdxs;

	detector->refineDetectedMarkers(InProxy(*image), *board, detectedCornersVec, detectedIdsVec, rejectedCornersVec,
		InProxy(*cameraMatrix), InProxy(*distCoeffs), recoveredIdxsArr);

	*outDetectedCorners = detectedCornersVec;
	*outDetectedIds = detectedIdsVec;
	*outRejectedCorners = rejectedCornersVec;
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_create_MultiDict(
	cv::aruco::Dictionary** dictionaries, int dictionariesSize,
	aruco_DetectorParameters* detectorParams,
	aruco_RefineParameters* refineParams,
	cv::aruco::ArucoDetector** returnValue)
{
	return cvTry([&] {
	std::vector<cv::aruco::Dictionary> dictVec;
	dictVec.reserve(dictionariesSize);
	for (int i = 0; i < dictionariesSize; i++)
		dictVec.push_back(*dictionaries[i]);
	const auto dp = cpp(*detectorParams);
	const auto rp = cpp(*refineParams);
	*returnValue = new cv::aruco::ArucoDetector(dictVec, dp, rp);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_detectMarkersWithConfidence(
	const cv::aruco::ArucoDetector* detector,
	const interop::InputArrayProxy* image,
	std::vector<std::vector<cv::Point2f>>* corners,
	std::vector<int>* ids,
	std::vector<float>* markersConfidence,
	std::vector<std::vector<cv::Point2f>>* rejectedImgPoints)
{
	return cvTry([&] {
	detector->detectMarkersWithConfidence(InProxy(*image), *corners, *ids, *markersConfidence, *rejectedImgPoints);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_detectMarkersMultiDict(
	const cv::aruco::ArucoDetector* detector,
	const interop::InputArrayProxy* image,
	std::vector<std::vector<cv::Point2f>>* corners,
	std::vector<int>* ids,
	std::vector<std::vector<cv::Point2f>>* rejectedImgPoints,
	std::vector<int>* dictIndices)
{
	return cvTry([&] {
	detector->detectMarkersMultiDict(InProxy(*image), *corners, *ids, *rejectedImgPoints, *dictIndices);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_getDictionary(const cv::aruco::ArucoDetector* detector, cv::aruco::Dictionary** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::Dictionary(detector->getDictionary());
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_setDictionary(cv::aruco::ArucoDetector* detector, cv::aruco::Dictionary* dictionary)
{
	return cvTry([&] {
	detector->setDictionary(*dictionary);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_getDictionariesSize(const cv::aruco::ArucoDetector* detector, int* returnValue)
{
	return cvTry([&] {
	*returnValue = static_cast<int>(detector->getDictionaries().size());
	});
}

// Fills outArray (pre-sized by the caller to aruco_ArucoDetector_getDictionariesSize's result) with one
// cloned Dictionary* per configured dictionary. A single getDictionaries() call, not one per index, so
// this is O(n) rather than O(n^2) for n configured dictionaries.
CVAPI(ExceptionStatus) aruco_ArucoDetector_getDictionaries(
	const cv::aruco::ArucoDetector* detector, cv::aruco::Dictionary** outArray, int arraySize)
{
	return cvTry([&] {
	const auto dicts = detector->getDictionaries();
	const size_t n = std::min(dicts.size(), static_cast<size_t>(arraySize));
	for (size_t i = 0; i < n; i++)
		outArray[i] = new cv::aruco::Dictionary(dicts[i]);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_setDictionaries(
	cv::aruco::ArucoDetector* detector,
	cv::aruco::Dictionary** dictionaries, int dictionariesSize)
{
	return cvTry([&] {
	std::vector<cv::aruco::Dictionary> dictVec;
	dictVec.reserve(dictionariesSize);
	for (int i = 0; i < dictionariesSize; i++)
		dictVec.push_back(*dictionaries[i]);
	detector->setDictionaries(dictVec);
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_getDetectorParameters(const cv::aruco::ArucoDetector* detector, aruco_DetectorParameters* returnValue)
{
	return cvTry([&] {
	*returnValue = c(detector->getDetectorParameters());
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_setDetectorParameters(cv::aruco::ArucoDetector* detector, aruco_DetectorParameters* detectorParameters)
{
	return cvTry([&] {
	detector->setDetectorParameters(cpp(*detectorParameters));
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_getRefineParameters(const cv::aruco::ArucoDetector* detector, aruco_RefineParameters* returnValue)
{
	return cvTry([&] {
	*returnValue = c(detector->getRefineParameters());
	});
}

CVAPI(ExceptionStatus) aruco_ArucoDetector_setRefineParameters(cv::aruco::ArucoDetector* detector, aruco_RefineParameters* refineParameters)
{
	return cvTry([&] {
	const auto rp = cpp(*refineParameters);
	detector->setRefineParameters(rp);
	});
}

// ==================== CharucoBoard ====================

CVAPI(ExceptionStatus) aruco_CharucoBoard_create(
	int squaresX, int squaresY,
	float squareLength, float markerLength,
	cv::aruco::Dictionary* dictionary,
	std::vector<int>* ids,
	cv::aruco::CharucoBoard** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::CharucoBoard(cv::Size(squaresX, squaresY), squareLength, markerLength, *dictionary, *ids);
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

CVAPI(ExceptionStatus) aruco_CharucoBoard_getChessboardCorners(const cv::aruco::CharucoBoard* ptr, std::vector<cv::Point3f>* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getChessboardCorners();
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getNearestMarkerIdx(const cv::aruco::CharucoBoard* ptr, std::vector<std::vector<int>>* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getNearestMarkerIdx();
	});
}

CVAPI(ExceptionStatus) aruco_CharucoBoard_getNearestMarkerCorners(const cv::aruco::CharucoBoard* ptr, std::vector<std::vector<int>>* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getNearestMarkerCorners();
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
	const auto rp = cpp(*refineParams);
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

CVAPI(ExceptionStatus) aruco_CharucoDetector_getBoard(const cv::aruco::CharucoDetector* detector, cv::aruco::CharucoBoard** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::CharucoBoard(detector->getBoard());
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_setBoard(cv::aruco::CharucoDetector* detector, cv::aruco::CharucoBoard* board)
{
	return cvTry([&] {
	detector->setBoard(*board);
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_getCharucoParameters(
	const cv::aruco::CharucoDetector* detector,
	cv::Mat** cameraMatrix, cv::Mat** distCoeffs, int* minMarkers, int* tryRefineMarkers, int* checkMarkers)
{
	return cvTry([&] {
	const auto& cp = detector->getCharucoParameters();
	*cameraMatrix = new cv::Mat(cp.cameraMatrix);
	*distCoeffs = new cv::Mat(cp.distCoeffs);
	*minMarkers = cp.minMarkers;
	*tryRefineMarkers = cp.tryRefineMarkers ? 1 : 0;
	*checkMarkers = cp.checkMarkers ? 1 : 0;
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_setCharucoParameters(
	cv::aruco::CharucoDetector* detector,
	const interop::InputArrayProxy* cameraMatrix, const interop::InputArrayProxy* distCoeffs,
	int minMarkers, int tryRefineMarkers, int checkMarkers)
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
	cp.tryRefineMarkers = tryRefineMarkers != 0;
	cp.checkMarkers = checkMarkers != 0;
	detector->setCharucoParameters(cp);
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_getDetectorParameters(const cv::aruco::CharucoDetector* detector, aruco_DetectorParameters* returnValue)
{
	return cvTry([&] {
	*returnValue = c(detector->getDetectorParameters());
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_setDetectorParameters(cv::aruco::CharucoDetector* detector, aruco_DetectorParameters* detectorParameters)
{
	return cvTry([&] {
	detector->setDetectorParameters(cpp(*detectorParameters));
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_getRefineParameters(const cv::aruco::CharucoDetector* detector, aruco_RefineParameters* returnValue)
{
	return cvTry([&] {
	*returnValue = c(detector->getRefineParameters());
	});
}

CVAPI(ExceptionStatus) aruco_CharucoDetector_setRefineParameters(cv::aruco::CharucoDetector* detector, aruco_RefineParameters* refineParameters)
{
	return cvTry([&] {
	const auto rp = cpp(*refineParameters);
	detector->setRefineParameters(rp);
	});
}

// ==================== Board ====================

CVAPI(ExceptionStatus) aruco_Board_create(
	cv::Point3f** objPoints, int objPointsSize1, int* objPointsSize2,
	cv::aruco::Dictionary* dictionary,
	std::vector<int>* ids,
	cv::aruco::Board** returnValue)
{
	return cvTry([&] {
	std::vector<std::vector<cv::Point3f>> objPointsVec(objPointsSize1);
	for (int i = 0; i < objPointsSize1; i++)
		objPointsVec[i] = std::vector<cv::Point3f>(objPoints[i], objPoints[i] + objPointsSize2[i]);
	*returnValue = new cv::aruco::Board(objPointsVec, *dictionary, *ids);
	});
}

CVAPI(ExceptionStatus) aruco_Board_delete(cv::aruco::Board* ptr)
{
	return cvTry([&] {
	delete ptr;
	});
}

CVAPI(ExceptionStatus) aruco_Board_getDictionary(const cv::aruco::Board* ptr, cv::aruco::Dictionary** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::Dictionary(ptr->getDictionary());
	});
}

CVAPI(ExceptionStatus) aruco_Board_getObjPoints(const cv::aruco::Board* ptr, std::vector<cv::Point3f>* returnValue)
{
	return cvTry([&] {
	returnValue->clear();
	for (const auto& marker : ptr->getObjPoints())
		for (const auto& p : marker)
			returnValue->push_back(p);
	});
}

CVAPI(ExceptionStatus) aruco_Board_getIds(const cv::aruco::Board* ptr, std::vector<int>* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getIds();
	});
}

CVAPI(ExceptionStatus) aruco_Board_getRightBottomCorner(const cv::aruco::Board* ptr, interop::Point3f* returnValue)
{
	return cvTry([&] {
	*returnValue = c(ptr->getRightBottomCorner());
	});
}

CVAPI(ExceptionStatus) aruco_Board_matchImagePoints(
	const cv::aruco::Board* ptr,
	cv::Point2f** detectedCorners, int detectedCornersSize1, int* detectedCornersSize2,
	const interop::InputArrayProxy* detectedIds,
	const interop::OutputArrayProxy* objPoints,
	const interop::OutputArrayProxy* imgPoints)
{
	return cvTry([&] {
	std::vector<std::vector<cv::Point2f>> cornersVec(detectedCornersSize1);
	for (int i = 0; i < detectedCornersSize1; i++)
		cornersVec[i] = std::vector<cv::Point2f>(detectedCorners[i], detectedCorners[i] + detectedCornersSize2[i]);
	ptr->matchImagePoints(cornersVec, InProxy(*detectedIds), OutProxy(*objPoints), OutProxy(*imgPoints));
	});
}

// For cv::CharucoBoard, matchImagePoints() expects a flat vector<Point2f> of ChArUco corners
// (not a jagged per-marker array like Board/GridBoard).
CVAPI(ExceptionStatus) aruco_Board_matchImagePoints_flat(
	const cv::aruco::Board* ptr,
	std::vector<cv::Point2f>* detectedCorners,
	const interop::InputArrayProxy* detectedIds,
	const interop::OutputArrayProxy* objPoints,
	const interop::OutputArrayProxy* imgPoints)
{
	return cvTry([&] {
	ptr->matchImagePoints(*detectedCorners, InProxy(*detectedIds), OutProxy(*objPoints), OutProxy(*imgPoints));
	});
}

CVAPI(ExceptionStatus) aruco_Board_generateImage(
	const cv::aruco::Board* ptr,
	interop::Size outSize,
	const interop::OutputArrayProxy* img,
	int marginSize,
	int borderBits)
{
	return cvTry([&] {
	ptr->generateImage(cpp(outSize), OutProxy(*img), marginSize, borderBits);
	});
}

// ==================== GridBoard ====================

CVAPI(ExceptionStatus) aruco_GridBoard_create(
	interop::Size size,
	float markerLength,
	float markerSeparation,
	cv::aruco::Dictionary* dictionary,
	std::vector<int>* ids,
	cv::aruco::GridBoard** returnValue)
{
	return cvTry([&] {
	*returnValue = new cv::aruco::GridBoard(cpp(size), markerLength, markerSeparation, *dictionary, *ids);
	});
}

CVAPI(ExceptionStatus) aruco_GridBoard_delete(cv::aruco::GridBoard* ptr)
{
	return cvTry([&] {
	delete ptr;
	});
}

CVAPI(ExceptionStatus) aruco_GridBoard_getGridSize(const cv::aruco::GridBoard* ptr, interop::Size* returnValue)
{
	return cvTry([&] {
	*returnValue = c(ptr->getGridSize());
	});
}

CVAPI(ExceptionStatus) aruco_GridBoard_getMarkerLength(const cv::aruco::GridBoard* ptr, float* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getMarkerLength();
	});
}

CVAPI(ExceptionStatus) aruco_GridBoard_getMarkerSeparation(const cv::aruco::GridBoard* ptr, float* returnValue)
{
	return cvTry([&] {
	*returnValue = ptr->getMarkerSeparation();
	});
}

#endif // NO_CONTRIB
