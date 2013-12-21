/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WHOGDESCRIPTOR_H_
#define _CPP_WHOGDESCRIPTOR_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
//#pragma warning(disable: 4996)
#endif
#include <opencv2/objdetect/objdetect.hpp>


#ifdef _WIN32
#include <Windows.h>
#include <sstream>
int p(const char* msg)
{
	return MessageBoxA(NULL, msg, "MessageBox", MB_OK);
}
template <typename T>
int p(T obj)
{
	std::stringstream ss;
	ss << obj;
	return p(ss.str().c_str());
}
#endif


#pragma region Methods
CVAPI(int) HOGDescriptor_sizeof()
{
	return sizeof(cv::HOGDescriptor);
}
CVAPI(cv::HOGDescriptor*) HOGDescriptor_new1()
{
	return new cv::HOGDescriptor();
}
CVAPI(cv::HOGDescriptor*) HOGDescriptor_new2( CvSize winSize, CvSize blockSize, CvSize blockStride, CvSize cellSize, 
	int nbins, int derivAperture, double winSigma, int histogramNormType, double L2HysThreshold, bool gammaCorrection, int nlevels)
{
	return new cv::HOGDescriptor(winSize, blockSize, blockStride, cellSize, nbins, derivAperture, winSigma, histogramNormType, L2HysThreshold, gammaCorrection, nlevels);
}
CVAPI(cv::HOGDescriptor*) HOGDescriptor_new3(const char* filename)
{
	std::string filename_str(filename);
	return new cv::HOGDescriptor(filename_str);
}
CVAPI(void) HOGDescriptor_delete(cv::HOGDescriptor* obj)
{
	delete obj;
}

CVAPI(size_t) HOGDescriptor_getDescriptorSize(cv::HOGDescriptor* obj)
{
	return obj->getDescriptorSize();
}
CVAPI(bool) HOGDescriptor_checkDetectorSize(cv::HOGDescriptor* obj)
{
	return obj->checkDetectorSize();
}
CVAPI(double) HOGDescriptor_getWinSigma(cv::HOGDescriptor* obj)
{
	return obj->getWinSigma();
}

CVAPI(std::vector<float>*) HOGDescriptor_getDefaultPeopleDetector()
{
	static std::vector<float> vec = cv::HOGDescriptor::getDefaultPeopleDetector();
	return &vec;
}

CVAPI(void) HOGDescriptor_setSVMDetector(cv::HOGDescriptor* obj, std::vector<float>* svmdetector)
{
	//std::vector<float> vec = obj->getDefaultPeopleDetector();
	//p(vec[0]);
	//p(vec.size());
	obj->setSVMDetector(*svmdetector);
	//hog.setSVMDetector();

	//obj->setSVMDetector(cv::HOGDescriptor::getDefaultPeopleDetector());

	/*
	FILE* fp = fopen("C:\\hoge.txt", "w");
	fprintf(fp, "svmdetector size: %d\n", svmdetector->size());
	fprintf(fp, "svmdetector[0]: %f\n", svmdetector->at(0));

	fprintf(fp, "svmdetector before: %d\n", obj->svmDetector.size());
	fprintf(fp, "getDescriptorSize before: %d\n", obj->getDescriptorSize());
	//obj->svmDetector = *svmdetector;
	fprintf(fp, "svmdetector after: %d\n", obj->svmDetector.size());
	fprintf(fp, "getDescriptorSize after: %d\n", obj->getDescriptorSize());

	size_t detectorSize = obj->svmDetector.size(), descriptorSize = obj->getDescriptorSize();
	bool result1 = obj->checkDetectorSize();
	bool result2 = detectorSize == 0 ||
        detectorSize == descriptorSize ||
        detectorSize == descriptorSize + 1;
		fprintf(fp, "detectorSize : %d\n", detectorSize);
		fprintf(fp, "descriptorSize : %d\n", descriptorSize);
		fprintf(fp, "checkDetectorSize : %d\n", result1 ? 1 : 0);
		fprintf(fp, "myresult : %d\n", result2 ? 1 : 0);
	fclose(fp);
	//*/

	//obj->setSVMDetector(*svmdetector);
	
}
CVAPI(bool) HOGDescriptor_load(cv::HOGDescriptor* obj, const char* filename, const char* objname)
{
	cv::String filename_str(filename);
	cv::String objname_str;
	if(objname != NULL)
		objname_str = cv::String(objname);
	return obj->load(filename_str, objname_str);
}
CVAPI(void) HOGDescriptor_save(cv::HOGDescriptor* obj, const char* filename, const char* objname)
{
	cv::String filename_str(filename);
	cv::String objname_str;
	if(objname != NULL)
		objname_str = cv::String(objname);
	obj->save(filename_str, objname_str);
}
CVAPI(void) HOGDescriptor_compute(cv::HOGDescriptor* obj, cv::Mat* img, std::vector<float>* descriptors,
								  CvSize winStride, CvSize padding, CvPoint* locations, int locations_length)
{
	std::vector<cv::Point> locations_vec;
	if(locations != NULL)
	{
		locations_vec = std::vector<cv::Point>(locations_length);
		for(int i=0; i<locations_length; i++)
		{
			locations_vec[i] = cv::Point(locations[i]);
		}
	}
	
	obj->compute(*img, *descriptors, winStride, padding, locations_vec);
}

CVAPI(void) HOGDescriptor_detect(cv::HOGDescriptor* obj, cv::Mat* img, std::vector<cv::Point>* foundLocations, 
								 double hitThreshold, CvSize winStride, CvSize padding, CvPoint* searchLocations, int searchLocationsLength)
{
	std::vector<cv::Point> slVec;
	if(searchLocations != NULL)
	{
		slVec = std::vector<cv::Point>(searchLocationsLength);
		for(int i=0; i<searchLocationsLength; i++)
		{
			slVec[i] = cv::Point(searchLocations[i]);
		}
	}

	obj->detect(*img, *foundLocations, hitThreshold, winStride, padding, slVec);
}

CVAPI(void) HOGDescriptor_detectMultiScale(cv::HOGDescriptor* obj, cv::Mat* img, std::vector<cv::Rect>* foundLocations, 
										   double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold)
{
	obj->detectMultiScale(*img, *foundLocations, hitThreshold, winStride, padding, scale, groupThreshold);
}

CVAPI(void) HOGDescriptor_computeGradient(cv::HOGDescriptor* obj, cv::Mat* img, cv::Mat* grad, cv::Mat* angleOfs, CvSize paddingTL, CvSize paddingBR)
{
	obj->computeGradient(*img, *grad, *angleOfs, paddingTL, paddingBR);
}
#pragma endregion

#pragma region Fields
CVAPI(CvSize) HOGDescriptor_winSize_get(cv::HOGDescriptor* obj)
{
	return obj->winSize;
}
CVAPI(CvSize) HOGDescriptor_blockSize_get(cv::HOGDescriptor* obj)
{
	return obj->blockSize;
}
CVAPI(CvSize) HOGDescriptor_blockStride_get(cv::HOGDescriptor* obj)
{
	return obj->blockStride;
}
CVAPI(CvSize) HOGDescriptor_cellSize_get(cv::HOGDescriptor* obj)
{
	return obj->winSize;
}
CVAPI(int) HOGDescriptor_nbins_get(cv::HOGDescriptor* obj)
{
	return obj->nbins;
}
CVAPI(int) HOGDescriptor_derivAperture_get(cv::HOGDescriptor* obj)
{
	return obj->derivAperture;
}
CVAPI(double) HOGDescriptor_winSigma_get(cv::HOGDescriptor* obj)
{
	return obj->winSigma;
}
CVAPI(int) HOGDescriptor_histogramNormType_get(cv::HOGDescriptor* obj)
{
	return obj->histogramNormType;
}
CVAPI(double) HOGDescriptor_L2HysThreshold_get(cv::HOGDescriptor* obj)
{
	return obj->L2HysThreshold;
}
CVAPI(int) HOGDescriptor_gammaCorrection_get(cv::HOGDescriptor* obj)
{
	return obj->gammaCorrection ? 1 : 0;
}
CVAPI(int) HOGDescriptor_nlevels_get(cv::HOGDescriptor* obj)
{
	return obj->nlevels;
}

CVAPI(void) HOGDescriptor_winSize_set(cv::HOGDescriptor* obj, CvSize value)
{
	obj->winSize = value;
}
CVAPI(void) HOGDescriptor_blockSize_set(cv::HOGDescriptor* obj, CvSize value)
{
	obj->blockSize = value;
}
CVAPI(void) HOGDescriptor_blockStride_set(cv::HOGDescriptor* obj, CvSize value)
{
	obj->blockStride = value;
}
CVAPI(void) HOGDescriptor_cellSize_set(cv::HOGDescriptor* obj, CvSize value)
{
	obj->cellSize = value;
}
CVAPI(void) HOGDescriptor_nbins_set(cv::HOGDescriptor* obj, int value)
{
	obj->nbins = value;
}
CVAPI(void) HOGDescriptor_derivAperture_set(cv::HOGDescriptor* obj, int value)
{
	obj->derivAperture = value;
}
CVAPI(void) HOGDescriptor_winSigma_set(cv::HOGDescriptor* obj, double value)
{
	obj->winSigma = value;
}
CVAPI(void) HOGDescriptor_histogramNormType_set(cv::HOGDescriptor* obj, int value)
{
	obj->histogramNormType = value;
}
CVAPI(void) HOGDescriptor_L2HysThreshold_set(cv::HOGDescriptor* obj, double value)
{
	obj->L2HysThreshold = value;
}
CVAPI(void) HOGDescriptor_gammaCorrection_set(cv::HOGDescriptor* obj, int value)
{
	obj->gammaCorrection = (value != 0);
}
CVAPI(void) HOGDescriptor_nlevels_set(cv::HOGDescriptor* obj, int value)
{
	obj->nlevels = value;
}
#pragma endregion

#endif