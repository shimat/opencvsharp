#ifndef _CPP_DNN_H_
#define _CPP_DNN_H_

#include "include_opencv.h"


CVAPI(cv::dnn::Net*) dnn_readNetFromDarknet(const char *cfgFile, const char *darknetModel)
{
	const auto darknetModelStr = (darknetModel == nullptr) ? cv::String() : cv::String(darknetModel);
	const auto net = cv::dnn::readNetFromDarknet(cfgFile, darknetModelStr);
	return new cv::dnn::Net(net);
}

CVAPI(cv::dnn::Net*) dnn_readNetFromCaffe(const char *prototxt, const char *caffeModel)
{
	const auto caffeModelStr = (caffeModel == nullptr) ? cv::String() : cv::String(caffeModel);
	const auto net = cv::dnn::readNetFromCaffe(prototxt, caffeModelStr);
	return new cv::dnn::Net(net);
}

CVAPI(cv::dnn::Net*) dnn_readNetFromTensorflow(const char *model, const char *config)
{
	const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
	const auto net = cv::dnn::readNetFromTensorflow(model, configStr);
	return new cv::dnn::Net(net);
}

CVAPI(cv::dnn::Net*) dnn_readNetFromTorch(const char *model, const int isBinary)
{
	const auto net = cv::dnn::readNetFromTorch(model, isBinary != 0);
	return new cv::dnn::Net(net);
}

CVAPI(cv::dnn::Net*) dnn_readNet(const char *model, const char *config, const char *framework)
{
    const auto configStr = (config == nullptr) ? "" : cv::String(config);
    const auto frameworkStr = (framework == nullptr) ? "" : cv::String(framework);
    const auto net = cv::dnn::readNet(model, configStr, frameworkStr);
    return new cv::dnn::Net(net);
}

CVAPI(cv::Mat*) dnn_readTorchBlob(const char *filename, const int isBinary)
{
	const auto blob = cv::dnn::readTorchBlob(filename, isBinary != 0);
	return new cv::Mat(blob);
}

CVAPI(cv::dnn::Net*) dnn_readNetFromModelOptimizer(const char *xml, const char *bin)
{
    const auto net = cv::dnn::readNetFromModelOptimizer(xml, bin);
    return new cv::dnn::Net(net);
}

CVAPI(cv::dnn::Net*) dnn_readNetFromONNX(const char *onnxFile)
{
    const auto net = cv::dnn::readNetFromONNX(onnxFile);
    return new cv::dnn::Net(net);
}

CVAPI(cv::Mat*) dnn_readTensorFromONNX(const char *path)
{
    const auto mat = cv::dnn::readTensorFromONNX(path);
    return new cv::Mat(mat);
}

CVAPI(cv::Mat*) dnn_blobFromImage(
	cv::Mat *image, const double scalefactor, const MyCvSize size, const MyCvScalar mean, const int swapRB, const int crop)
{
	const auto blob = cv::dnn::blobFromImage(*image, scalefactor, cpp(size), cpp(mean), swapRB != 0, crop != 0);
	return new cv::Mat(blob);
}

CVAPI(cv::Mat*) dnn_blobFromImages(
	const cv::Mat **images, const int imagesLength, const double scalefactor, const MyCvSize size, const MyCvScalar mean, const int swapRB, const int crop)
{
	std::vector<cv::Mat> imagesVec;
	toVec(images, imagesLength, imagesVec);

	const auto blob = cv::dnn::blobFromImages(imagesVec, scalefactor, cpp(size), cpp(mean), swapRB != 0, crop != 0);
	return new cv::Mat(blob);
}

CVAPI(void) dnn_shrinkCaffeModel(const char *src, const char *dst)
{
	cv::dnn::shrinkCaffeModel(src, dst);
}

#endif