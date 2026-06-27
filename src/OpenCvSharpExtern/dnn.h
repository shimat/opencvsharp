#pragma once

#ifndef NO_DNN

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// Path handling (opencv #4242): OpenCV reads model files by narrow fopen, so non-ANSI paths fail on
// Windows. For paths the active code page can represent we call the file-based readNet* directly
// (streaming, unchanged); only non-representable paths are read via a wide stream and handed to the
// in-memory buffer overload. Non-Windows keeps the file-based calls (UTF-8 paths already work there).
#ifdef _WIN32
static std::vector<uchar> dnn_readFileWideOrThrow(const char *utf8)
{
    std::vector<uchar> buf;
    if (!readAllBytesWide(utf8, buf))
        CV_Error(cv::Error::StsError, cv::format("Failed to open file: %s", utf8 ? utf8 : "(null)"));
    return buf;
}

// Mirror cv::dnn::readNet's framework inference from the model file extension. Only used for the
// buffer overload on non-representable paths (representable paths call file-based readNet, which does
// OpenCV's own inference). Returns "" for unknown extensions so the buffer call surfaces OpenCV's error.
static std::string dnn_inferFramework(const char *model)
{
    std::string m(model ? model : "");
    const auto dot = m.find_last_of('.');
    std::string ext = (dot == std::string::npos) ? "" : m.substr(dot + 1);
    for (auto &c : ext) c = static_cast<char>(::tolower(static_cast<unsigned char>(c)));
    if (ext == "caffemodel") return "caffe";
    if (ext == "pb") return "tensorflow";
    if (ext == "t7" || ext == "net") return "torch";
    if (ext == "weights") return "darknet";
    if (ext == "bin" || ext == "xml") return "dldt";
    if (ext == "onnx") return "onnx";
    if (ext == "tflite") return "tflite";
    return "";
}
#endif

// Reads a net from (model, config) file paths, transparently handling non-ANSI paths on Windows
// (representable -> file-based readNet; otherwise wide-read + framework-explicit buffer overload).
// Shared by dnn_readNet and the Model constructors.
static cv::dnn::Net dnn_readNetGated(const char *model, const char *config, const char *framework, int engine)
{
#ifdef _WIN32
    const std::string frameworkStr = (framework == nullptr) ? "" : std::string(framework);
    const bool hasConfig = (config != nullptr && config[0] != '\0');
    std::string modelAcp, configAcp;
    if (pathRoundTripsAcp(model, modelAcp) && (!hasConfig || pathRoundTripsAcp(config, configAcp)))
        return cv::dnn::readNet(cv::String(modelAcp), hasConfig ? cv::String(configAcp) : cv::String(), frameworkStr, engine);

    const std::string fw = frameworkStr.empty() ? dnn_inferFramework(model) : frameworkStr;
    const std::vector<uchar> modelBuf = dnn_readFileWideOrThrow(model);
    const std::vector<uchar> configBuf = hasConfig ? dnn_readFileWideOrThrow(config) : std::vector<uchar>();
    return cv::dnn::readNet(fw, modelBuf, configBuf, engine);
#else
    const std::string configStr = (config == nullptr) ? "" : std::string(config);
    const std::string frameworkStr = (framework == nullptr) ? "" : std::string(framework);
    return cv::dnn::readNet(model, configStr, frameworkStr, engine);
#endif
}

CVAPI(ExceptionStatus) dnn_readNetFromTensorflow(const char *model, const char *config, int engine, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    const bool hasConfig = (config != nullptr && config[0] != '\0');
    std::string modelAcp, configAcp;
    cv::dnn::Net net;
    if (pathRoundTripsAcp(model, modelAcp) && (!hasConfig || pathRoundTripsAcp(config, configAcp)))
    {
        net = cv::dnn::readNetFromTensorflow(cv::String(modelAcp), hasConfig ? cv::String(configAcp) : cv::String(), engine);
    }
    else
    {
        const std::vector<uchar> modelBuf = dnn_readFileWideOrThrow(model);
        const std::vector<uchar> configBuf = hasConfig ? dnn_readFileWideOrThrow(config) : std::vector<uchar>();
        net = cv::dnn::readNetFromTensorflow(
            reinterpret_cast<const char*>(modelBuf.data()), modelBuf.size(),
            hasConfig ? reinterpret_cast<const char*>(configBuf.data()) : nullptr, hasConfig ? configBuf.size() : 0,
            engine);
    }
    *returnValue = new cv::dnn::Net(net);
#else
    const auto configStr = (config == nullptr) ? cv::String() : cv::String(config);
    const auto net = cv::dnn::readNetFromTensorflow(model, configStr, engine);
    *returnValue = new cv::dnn::Net(net);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromTensorflow_InputArray(const char *model,size_t lenModel, const char *config, size_t lenConfig, int engine, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::readNetFromTensorflow(model, lenModel, config, lenConfig, engine);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNet(const char *model, const char *config, const char *framework, int engine, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn::Net(dnn_readNetGated(model, config, framework, engine));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromModelOptimizer(const char *xml, const char *bin, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    std::string xmlAcp, binAcp;
    cv::dnn::Net net;
    if (pathRoundTripsAcp(xml, xmlAcp) && pathRoundTripsAcp(bin, binAcp))
    {
        net = cv::dnn::readNetFromModelOptimizer(cv::String(xmlAcp), cv::String(binAcp));
    }
    else
    {
        const std::vector<uchar> xmlBuf = dnn_readFileWideOrThrow(xml);
        const std::vector<uchar> binBuf = dnn_readFileWideOrThrow(bin);
        net = cv::dnn::readNetFromModelOptimizer(xmlBuf.data(), xmlBuf.size(), binBuf.data(), binBuf.size());
    }
    *returnValue = new cv::dnn::Net(net);
#else
    const auto net = cv::dnn::readNetFromModelOptimizer(xml, bin);
    *returnValue = new cv::dnn::Net(net);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromONNX(const char *onnxFile, int engine, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    std::string acp;
    cv::dnn::Net net;
    if (pathRoundTripsAcp(onnxFile, acp))
    {
        net = cv::dnn::readNetFromONNX(cv::String(acp), engine);
    }
    else
    {
        const std::vector<uchar> buf = dnn_readFileWideOrThrow(onnxFile);
        net = cv::dnn::readNetFromONNX(reinterpret_cast<const char*>(buf.data()), buf.size(), engine);
    }
    *returnValue = new cv::dnn::Net(net);
#else
    // Wrap in cv::String to disambiguate from the (const char* buffer, size_t, int) overload.
    const auto net = cv::dnn::readNetFromONNX(cv::String(onnxFile), engine);
    *returnValue = new cv::dnn::Net(net);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromONNX_InputArray(const char* buffer, size_t sizeBuffer, int engine, cv::dnn::Net** returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::readNetFromONNX(buffer, sizeBuffer, engine);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}


CVAPI(ExceptionStatus) dnn_readTensorFromONNX(const char *path, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::dnn::readTensorFromONNX(path);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_blobFromImage(
    cv::Mat *image, const double scalefactor, const interop::Size size, const interop::Scalar mean, const int swapRB, const int crop, 
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto blob = cv::dnn::blobFromImage(*image, scalefactor, cpp(size), cpp(mean), swapRB != 0, crop != 0);
    *returnValue = new cv::Mat(blob);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_blobFromImages(
    const cv::Mat **images, const int imagesLength, const double scalefactor, const interop::Size size, const interop::Scalar mean, const int swapRB, const int crop, 
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesLength, imagesVec);

    const auto blob = cv::dnn::blobFromImages(imagesVec, scalefactor, cpp(size), cpp(mean), swapRB != 0, crop != 0);
    *returnValue = new cv::Mat(blob);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_writeTextGraph(const char *model, const char *output)
{
    BEGIN_WRAP
    cv::dnn::writeTextGraph(model, output);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxes_Rect(std::vector<cv::Rect> *bboxes, std::vector<float> *scores,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxes(*bboxes, *scores, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxes_Rect2d(std::vector<cv::Rect2d> *bboxes, std::vector<float> *scores,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxes(*bboxes, *scores, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxes_RotatedRect(std::vector<cv::RotatedRect> *bboxes, std::vector<float> *scores,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxes(*bboxes, *scores, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_resetMyriadDevice()
{
    BEGIN_WRAP
    cv::dnn::resetMyriadDevice();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_getAvailableTargets(const int be, std::vector<int> *targets)
{
    BEGIN_WRAP
    const auto v = cv::dnn::getAvailableTargets(static_cast<cv::dnn::Backend>(be));
    targets->clear();
    for (const auto t : v)
        targets->push_back(static_cast<int>(t));
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_getAvailableBackends(std::vector<int> *backends, std::vector<int> *targets)
{
    BEGIN_WRAP
    const auto v = cv::dnn::getAvailableBackends();
    backends->clear();
    targets->clear();
    for (const auto &p : v)
    {
        backends->push_back(static_cast<int>(p.first));
        targets->push_back(static_cast<int>(p.second));
    }
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_enableModelDiagnostics(const int isDiagnosticsMode)
{
    BEGIN_WRAP
    cv::dnn::enableModelDiagnostics(isDiagnosticsMode != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromTFLite(const char *model, int engine, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    std::string acp;
    cv::dnn::Net net;
    if (pathRoundTripsAcp(model, acp))
    {
        net = cv::dnn::readNetFromTFLite(cv::String(acp), engine);
    }
    else
    {
        const std::vector<uchar> buf = dnn_readFileWideOrThrow(model);
        net = cv::dnn::readNetFromTFLite(reinterpret_cast<const char*>(buf.data()), buf.size(), engine);
    }
    *returnValue = new cv::dnn::Net(net);
#else
    // Wrap in cv::String to disambiguate from the (const char* buffer, size_t, int) overload.
    const auto net = cv::dnn::readNetFromTFLite(cv::String(model), engine);
    *returnValue = new cv::dnn::Net(net);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_readNetFromTFLite_InputArray(const char *bufferModel, size_t lenModel, int engine, cv::dnn::Net **returnValue)
{
    BEGIN_WRAP
    const auto net = cv::dnn::readNetFromTFLite(bufferModel, lenModel, engine);
    *returnValue = new cv::dnn::Net(net);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_blobFromImageWithParams(
    cv::_InputArray *image, const interop::Scalar scalefactor, const interop::Size size, const interop::Scalar mean,
    const int swapRB, const int ddepth, const int datalayout, const int paddingmode, const interop::Scalar borderValue,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    const cv::dnn::Image2BlobParams param(
        cpp(scalefactor), cpp(size), cpp(mean), swapRB != 0, ddepth,
        static_cast<cv::DataLayout>(datalayout), static_cast<cv::dnn::ImagePaddingMode>(paddingmode), cpp(borderValue));
    const auto blob = cv::dnn::blobFromImageWithParams(*image, param);
    *returnValue = new cv::Mat(blob);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_blobFromImagesWithParams(
    cv::Mat **images, const int imagesLength, const interop::Scalar scalefactor, const interop::Size size, const interop::Scalar mean,
    const int swapRB, const int ddepth, const int datalayout, const int paddingmode, const interop::Scalar borderValue,
    cv::Mat **returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesLength, imagesVec);
    const cv::dnn::Image2BlobParams param(
        cpp(scalefactor), cpp(size), cpp(mean), swapRB != 0, ddepth,
        static_cast<cv::DataLayout>(datalayout), static_cast<cv::dnn::ImagePaddingMode>(paddingmode), cpp(borderValue));
    const auto blob = cv::dnn::blobFromImagesWithParams(imagesVec, param);
    *returnValue = new cv::Mat(blob);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_imagesFromBlob(cv::Mat *blob, std::vector<cv::Mat> *images)
{
    BEGIN_WRAP
    cv::dnn::imagesFromBlob(*blob, *images);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxesBatched_Rect(
    std::vector<cv::Rect> *bboxes, std::vector<float> *scores, std::vector<int> *classIds,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxesBatched(*bboxes, *scores, *classIds, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_NMSBoxesBatched_Rect2d(
    std::vector<cv::Rect2d> *bboxes, std::vector<float> *scores, std::vector<int> *classIds,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const float eta, const int top_k)
{
    BEGIN_WRAP
    cv::dnn::NMSBoxesBatched(*bboxes, *scores, *classIds, score_threshold, nms_threshold, *indices, eta, top_k);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_softNMSBoxes_Rect(
    std::vector<cv::Rect> *bboxes, std::vector<float> *scores, std::vector<float> *updated_scores,
    const float score_threshold, const float nms_threshold,
    std::vector<int> *indices, const size_t top_k, const float sigma, const int method)
{
    BEGIN_WRAP
    cv::dnn::softNMSBoxes(
        *bboxes, *scores, *updated_scores, score_threshold, nms_threshold, *indices,
        top_k, sigma, static_cast<cv::dnn::SoftNMSMethod>(method));
    END_WRAP
}

#endif // !#ifndef _WINRT_DLL

#endif // NO_DNN
