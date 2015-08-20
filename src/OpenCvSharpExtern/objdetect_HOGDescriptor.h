#ifndef _CPP_OBJDETECT_HOGDESCRIPTOR_H_
#define _CPP_OBJDETECT_HOGDESCRIPTOR_H_

#include "include_opencv.h"

#pragma region Methods
CVAPI(int) objdetect_HOGDescriptor_sizeof()
{
	return sizeof(cv::HOGDescriptor);
}
CVAPI(cv::HOGDescriptor*) objdetect_HOGDescriptor_new1()
{
	return new cv::HOGDescriptor();
}
CVAPI(cv::HOGDescriptor*) objdetect_HOGDescriptor_new2(CvSize winSize, CvSize blockSize, CvSize blockStride, CvSize cellSize,
	int nbins, int derivAperture, double winSigma, int histogramNormType, double L2HysThreshold, int gammaCorrection, int nlevels)
{
	return new cv::HOGDescriptor(winSize, blockSize, blockStride, cellSize, nbins, derivAperture, 
		winSigma, histogramNormType, L2HysThreshold, gammaCorrection != 0, nlevels);
}
CVAPI(cv::HOGDescriptor*) objdetect_HOGDescriptor_new3(const char *filename)
{
	std::string filename_str(filename);
	return new cv::HOGDescriptor(filename_str);
}
CVAPI(void) objdetect_HOGDescriptor_delete(cv::HOGDescriptor *obj)
{
	delete obj;
}

CVAPI(size_t) objdetect_HOGDescriptor_getDescriptorSize(cv::HOGDescriptor *obj)
{
	return obj->getDescriptorSize();
}
CVAPI(int) objdetect_HOGDescriptor_checkDetectorSize(cv::HOGDescriptor *obj)
{
	return obj->checkDetectorSize() ? 1 : 0;
}
CVAPI(double) objdetect_HOGDescriptor_getWinSigma(cv::HOGDescriptor *obj)
{
	return obj->getWinSigma();
}

CVAPI(void) objdetect_HOGDescriptor_setSVMDetector(cv::HOGDescriptor *obj, std::vector<float> *svmdetector)
{
	obj->setSVMDetector(*svmdetector);
}

CVAPI(bool) objdetect_HOGDescriptor_load(cv::HOGDescriptor *obj, const char *filename, const char *objname)
{
	std::string filenameStr(filename);
	std::string objnameStr;
	if (objname != NULL)
		objnameStr = cv::String(objname);
	return obj->load(filenameStr, objnameStr);
}
CVAPI(void) objdetect_HOGDescriptor_save(cv::HOGDescriptor *obj, const char *filename, const char *objname)
{
	std::string filenameStr(filename);
	std::string objnameStr;
	if (objname != NULL)
		objnameStr = cv::String(objname);
	obj->save(filenameStr, objnameStr);
}

CVAPI(void) objdetect_HOGDescriptor_copyTo(cv::HOGDescriptor *obj, cv::HOGDescriptor *c)
{
	obj->copyTo(*c);
}

CVAPI(void) objdetect_HOGDescriptor_compute(cv::HOGDescriptor *obj, cv::Mat *img, std::vector<float> *descriptors,
	CvSize winStride, CvSize padding, cv::Point* locations, int locationsLength)
{
	std::vector<cv::Point> locationsVec;
	if (locations != NULL)	
		locationsVec = std::vector<cv::Point>(locations, locations + locationsLength);
	
	obj->compute(*img, *descriptors, winStride, padding, locationsVec);
}

CVAPI(void) objdetect_HOGDescriptor_detect1(cv::HOGDescriptor *obj, cv::Mat *img, std::vector<cv::Point> *foundLocations,
	double hitThreshold, CvSize winStride, CvSize padding, cv::Point* searchLocations, int searchLocationsLength)
{
	std::vector<cv::Point> slVec;
	if (searchLocations != NULL)	
		slVec = std::vector<cv::Point>(searchLocations, searchLocations + searchLocationsLength);
	
	obj->detect(*img, *foundLocations, hitThreshold, winStride, padding, slVec);
}
CVAPI(void) objdetect_HOGDescriptor_detect2(cv::HOGDescriptor *obj, cv::Mat *img, 
	std::vector<cv::Point> *foundLocations, std::vector<double> *weights,
	double hitThreshold, CvSize winStride, CvSize padding, cv::Point* searchLocations, int searchLocationsLength)
{
	std::vector<cv::Point> slVec;
	if (searchLocations != NULL)	
		slVec = std::vector<cv::Point>(searchLocations, searchLocations + searchLocationsLength);
	
	obj->detect(*img, *foundLocations, *weights, hitThreshold, winStride, padding, slVec);
}

CVAPI(void) objdetect_HOGDescriptor_detectMultiScale1(cv::HOGDescriptor *obj, cv::Mat *img, 
	std::vector<cv::Rect> *foundLocations,
	double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold)
{
	obj->detectMultiScale(*img, *foundLocations, 
		hitThreshold, winStride, padding, scale, groupThreshold);
}
CVAPI(void) objdetect_HOGDescriptor_detectMultiScale2(cv::HOGDescriptor *obj, cv::Mat *img, 
	std::vector<cv::Rect> *foundLocations, std::vector<double> *foundWeights,
	double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold)
{
	obj->detectMultiScale(*img, *foundLocations, *foundWeights, 
		hitThreshold, winStride, padding, scale, groupThreshold);
}

CVAPI(void) objdetect_HOGDescriptor_computeGradient(cv::HOGDescriptor *obj, cv::Mat* img, 
	cv::Mat* grad, cv::Mat* angleOfs, CvSize paddingTL, CvSize paddingBR)
{
	obj->computeGradient(*img, *grad, *angleOfs, paddingTL, paddingBR);
}

// evaluate specified ROI and return confidence value for each location
CVAPI(void) objdetect_HOGDescriptor_detectROI(cv::HOGDescriptor *obj, cv::Mat *img, cv::Point *locations, int locationsLength,
	std::vector<cv::Point> *foundLocations, std::vector<double> *confidences,
	double hitThreshold, CvSize winStride, CvSize padding)
{
	std::vector<cv::Point> locationsVec(locations, locations + locationsLength);
	obj->detectROI(*img, locationsVec, *foundLocations, *confidences, hitThreshold, winStride, padding);
}

// evaluate specified ROI and return confidence value for each location in multiple scales
CVAPI(void) objdetect_HOGDescriptor_detectMultiScaleROI(cv::HOGDescriptor *obj, cv::Mat *img, std::vector<cv::Rect> *foundLocations,
	std::vector<double> *roiScales, std::vector<std::vector<cv::Point> > *roiLocations, std::vector<std::vector<double> > *roiConfidences,
	double hitThreshold, int groupThreshold)
{
	std::vector<cv::DetectionROI> locations;
	obj->detectMultiScaleROI(*img, *foundLocations, locations, hitThreshold, groupThreshold);

	roiScales->resize(locations.size());
	roiLocations->resize(locations.size());
	roiConfidences->resize(locations.size());
	for (size_t i = 0; i < locations.size(); i++)
	{
		(*roiScales)[i] = locations[i].scale;
		(*roiLocations)[i] = locations[i].locations;
		(*roiConfidences)[i] = locations[i].confidences;
	}
}

// read/parse Dalal's alt model file
CVAPI(void) objdetect_HOGDescriptor_readALTModel(cv::HOGDescriptor *obj, const char *modelfile)
{
	obj->readALTModel(modelfile);
}
CVAPI(void) objdetect_HOGDescriptor_groupRectangles(cv::HOGDescriptor *obj,
	std::vector<cv::Rect> *rectList, std::vector<double> *weights, int groupThreshold, double eps)
{
	obj->groupRectangles(*rectList, *weights, groupThreshold, eps);
}

#pragma endregion

#pragma region Fields
CVAPI(CvSize) objdetect_HOGDescriptor_winSize_get(cv::HOGDescriptor *obj)
{
	return obj->winSize;
}
CVAPI(CvSize) objdetect_HOGDescriptor_blockSize_get(cv::HOGDescriptor *obj)
{
	return obj->blockSize;
}
CVAPI(CvSize) objdetect_HOGDescriptor_blockStride_get(cv::HOGDescriptor *obj)
{
	return obj->blockStride;
}
CVAPI(CvSize) objdetect_HOGDescriptor_cellSize_get(cv::HOGDescriptor *obj)
{
	return obj->winSize;
}
CVAPI(int) objdetect_HOGDescriptor_nbins_get(cv::HOGDescriptor *obj)
{
	return obj->nbins;
}
CVAPI(int) objdetect_HOGDescriptor_derivAperture_get(cv::HOGDescriptor *obj)
{
	return obj->derivAperture;
}
CVAPI(double) objdetect_HOGDescriptor_winSigma_get(cv::HOGDescriptor *obj)
{
	return obj->winSigma;
}
CVAPI(int) objdetect_HOGDescriptor_histogramNormType_get(cv::HOGDescriptor *obj)
{
	return obj->histogramNormType;
}
CVAPI(double) objdetect_HOGDescriptor_L2HysThreshold_get(cv::HOGDescriptor *obj)
{
	return obj->L2HysThreshold;
}
CVAPI(int) objdetect_HOGDescriptor_gammaCorrection_get(cv::HOGDescriptor *obj)
{
	return obj->gammaCorrection ? 1 : 0;
}
CVAPI(int) objdetect_HOGDescriptor_nlevels_get(cv::HOGDescriptor *obj)
{
	return obj->nlevels;
}

CVAPI(void) objdetect_HOGDescriptor_winSize_set(cv::HOGDescriptor *obj, CvSize value)
{
	obj->winSize = value;
}
CVAPI(void) objdetect_HOGDescriptor_blockSize_set(cv::HOGDescriptor *obj, CvSize value)
{
	obj->blockSize = value;
}
CVAPI(void) objdetect_HOGDescriptor_blockStride_set(cv::HOGDescriptor *obj, CvSize value)
{
	obj->blockStride = value;
}
CVAPI(void) objdetect_HOGDescriptor_cellSize_set(cv::HOGDescriptor *obj, CvSize value)
{
	obj->cellSize = value;
}
CVAPI(void) objdetect_HOGDescriptor_nbins_set(cv::HOGDescriptor *obj, int value)
{
	obj->nbins = value;
}
CVAPI(void) objdetect_HOGDescriptor_derivAperture_set(cv::HOGDescriptor *obj, int value)
{
	obj->derivAperture = value;
}
CVAPI(void) objdetect_HOGDescriptor_winSigma_set(cv::HOGDescriptor *obj, double value)
{
	obj->winSigma = value;
}
CVAPI(void) objdetect_HOGDescriptor_histogramNormType_set(cv::HOGDescriptor *obj, int value)
{
	obj->histogramNormType = value;
}
CVAPI(void) objdetect_HOGDescriptor_L2HysThreshold_set(cv::HOGDescriptor *obj, double value)
{
	obj->L2HysThreshold = value;
}
CVAPI(void) objdetect_HOGDescriptor_gammaCorrection_set(cv::HOGDescriptor *obj, int value)
{
	obj->gammaCorrection = (value != 0);
}
CVAPI(void) objdetect_HOGDescriptor_nlevels_set(cv::HOGDescriptor *obj, int value)
{
	obj->nlevels = value;
}
#pragma endregion

#endif