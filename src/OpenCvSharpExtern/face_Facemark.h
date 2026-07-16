#pragma once

#ifndef NO_CONTRIB

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


#ifndef _WINRT_DLL

// Blittable POD view of the scalar fields of cv::face::FacemarkLBF::Params.
// The std::string / std::vector members are marshalled separately.
struct FacemarkLBFParamsData
{
    double shape_offset;
    int verbose;
    int n_landmarks;
    int initShape_n;
    int stages_n;
    int tree_n;
    int tree_depth;
    double bagging_overlap;
    int save_model;
    uint32_t seed;
    interop::Rect detectROI;
};

// Blittable POD view of the scalar fields of cv::face::FacemarkAAM::Params.
// The model_filename / scales members are marshalled separately.
struct FacemarkAAMParamsData
{
    int m;
    int n;
    int n_iter;
    int verbose;
    int save_model;
    int max_m;
    int max_n;
    int texture_max_m;
};

struct FacemarkKazemiParamsData
{
    uint64_t cascade_depth;
    uint64_t tree_depth;
    uint64_t num_trees_per_cascade_level;
    float learning_rate;
    uint64_t oversampling_amount;
    uint64_t num_test_coordinates;
    float lambda;
    uint64_t num_test_splits;
};

typedef int (*FacemarkFaceDetectorCallback)(cv::Mat *image, interop::Rect *faces, int capacity);

struct FacemarkFaceDetectorCallbackData
{
    FacemarkFaceDetectorCallback callback;
};

static bool face_Facemark_faceDetectorThunk(
    cv::InputArray image, cv::OutputArray faces, void *userData)
{
    const auto data = static_cast<FacemarkFaceDetectorCallbackData *>(userData);
    if (data == nullptr || data->callback == nullptr)
        return false;
    auto imageMat = image.getMat();
    const auto count = data->callback(&imageMat, nullptr, 0);
    if (count < 0)
        return false;
    if (count == 0)
    {
        faces.release();
        return true;
    }
    std::vector<interop::Rect> interopFaces(count);
    const auto written = data->callback(&imageMat, interopFaces.data(), count);
    if (written != count)
        return false;
    std::vector<cv::Rect> nativeFaces(count);
    for (auto i = 0; i < count; i++)
        nativeFaces[i] = cpp(interopFaces[i]);
    cv::Mat(nativeFaces).copyTo(faces);
    return true;
}

CVAPI(ExceptionStatus) face_FacemarkFaceDetectorCallbackData_delete(
    FacemarkFaceDetectorCallbackData *data)
{
    return cvTry([&] { delete data; });
}

#pragma region Utilities

CVAPI(ExceptionStatus) face_getFacesHAAR(
    const interop::InputArrayProxy *image,
    const interop::OutputArrayProxy *faces,
    const char *cascadeName,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::face::getFacesHAAR(InProxy(*image), OutProxy(*faces), cascadeName) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_loadDatasetList(
    const char *imageList,
    const char *annotationList,
    std::vector<std::string> *images,
    std::vector<std::string> *annotations,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::face::loadDatasetList(imageList, annotationList, *images, *annotations) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_loadTrainingData1(
    const char *filename,
    std::vector<std::string> *images,
    std::vector<std::vector<cv::Point2f>> *facePoints,
    const char delim,
    const float offset,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::face::loadTrainingData(filename, *images, *facePoints, delim, offset) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_loadTrainingData2(
    const char *imageList,
    const char *groundTruth,
    std::vector<std::string> *images,
    std::vector<std::vector<cv::Point2f>> *facePoints,
    const float offset,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::face::loadTrainingData(imageList, groundTruth, *images, *facePoints, offset) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_loadTrainingData3(
    std::vector<std::string> *filenames,
    std::vector<std::vector<cv::Point2f>> *landmarks,
    std::vector<std::string> *images,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::face::loadTrainingData(*filenames, *landmarks, *images) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_loadFacePoints(
    const char *filename,
    std::vector<cv::Point2f> *points,
    const float offset,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::face::loadFacePoints(filename, *points, offset) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_drawFacemarks(
    const interop::InputOutputArrayProxy *image,
    const interop::InputArrayProxy *points,
    const interop::Scalar color)
{
    return cvTry([&] {
        cv::face::drawFacemarks(IoProxy(*image), InProxy(*points), cpp(color));
    });
}

#pragma endregion

#pragma region Facemark

CVAPI(ExceptionStatus) face_Facemark_loadModel(cv::face::Facemark *obj, const char *model)
{
    return cvTry([&] {
        obj->loadModel(model);
    });
}

CVAPI(ExceptionStatus) face_Facemark_fit(
    cv::face::Facemark *obj,
    const interop::InputArrayProxy* image,
    const interop::InputArrayProxy* faces,
    std::vector<std::vector<cv::Point2f>> *landmarks,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->fit(InProxy(*image), InProxy(*faces), *landmarks) ? 1 : 0;
    });
}

#pragma endregion

#pragma region FacemarkTrain

CVAPI(ExceptionStatus) face_FacemarkTrain_addTrainingSample(
    cv::face::FacemarkTrain *obj,
    const interop::InputArrayProxy *image,
    const interop::InputArrayProxy *landmarks,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->addTrainingSample(InProxy(*image), InProxy(*landmarks)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_FacemarkTrain_training(cv::face::FacemarkTrain *obj)
{
    return cvTry([&] { obj->training(); });
}

CVAPI(ExceptionStatus) face_FacemarkTrain_getFaces(
    cv::face::FacemarkTrain *obj,
    const interop::InputArrayProxy *image,
    std::vector<cv::Rect> *faces,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getFaces(InProxy(*image), *faces) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_FacemarkTrain_getData(
    cv::face::FacemarkTrain *obj, void *items, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getData(items) ? 1 : 0; });
}

CVAPI(ExceptionStatus) face_FacemarkTrain_setFaceDetector(
    cv::face::FacemarkTrain *obj,
    const FacemarkFaceDetectorCallback callback,
    FacemarkFaceDetectorCallbackData **callbackData,
    int *returnValue)
{
    return cvTry([&] {
        const auto data = new FacemarkFaceDetectorCallbackData { callback };
        if (!obj->setFaceDetector(face_Facemark_faceDetectorThunk, data))
        {
            delete data;
            *callbackData = nullptr;
            *returnValue = 0;
            return;
        }
        *callbackData = data;
        *returnValue = 1;
    });
}

#pragma endregion

#pragma region FacemarkLBF

CVAPI(ExceptionStatus) face_FacemarkLBF_create(cv::face::FacemarkLBF::Params *params, cv::Ptr<cv::face::FacemarkLBF> **returnValue)
{
    return cvTry([&] {
        const auto obj = (params == nullptr) ? 
            cv::face::FacemarkLBF::create() :
            cv::face::FacemarkLBF::create(*params);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkLBF_get(cv::Ptr<cv::face::FacemarkLBF> *obj, cv::face::FacemarkLBF **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkLBF_delete(cv::Ptr<cv::face::FacemarkLBF> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

#pragma region Params

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_new(cv::face::FacemarkLBF::Params **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::face::FacemarkLBF::Params;
    });
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_delete(cv::face::FacemarkLBF::Params *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_getAll(
    cv::face::FacemarkLBF::Params *obj,
    FacemarkLBFParamsData *data,
    std::string *cascadeFace,
    std::string *modelFilename,
    std::vector<int> *featsM,
    std::vector<double> *radiusM,
    std::vector<int> *pupils0,
    std::vector<int> *pupils1)
{
    return cvTry([&] {
        data->shape_offset = obj->shape_offset;
        data->verbose = obj->verbose ? 1 : 0;
        data->n_landmarks = obj->n_landmarks;
        data->initShape_n = obj->initShape_n;
        data->stages_n = obj->stages_n;
        data->tree_n = obj->tree_n;
        data->tree_depth = obj->tree_depth;
        data->bagging_overlap = obj->bagging_overlap;
        data->save_model = obj->save_model ? 1 : 0;
        data->seed = obj->seed;
        data->detectROI = c(obj->detectROI);
        cascadeFace->assign(obj->cascade_face);
        modelFilename->assign(obj->model_filename);
        std::copy(obj->feats_m.begin(), obj->feats_m.end(), std::back_inserter(*featsM));
        std::copy(obj->radius_m.begin(), obj->radius_m.end(), std::back_inserter(*radiusM));
        std::copy(obj->pupils[0].begin(), obj->pupils[0].end(), std::back_inserter(*pupils0));
        std::copy(obj->pupils[1].begin(), obj->pupils[1].end(), std::back_inserter(*pupils1));
    });
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_setAll(
    cv::face::FacemarkLBF::Params *obj,
    FacemarkLBFParamsData data,
    const char *cascadeFace,
    const char *modelFilename,
    std::vector<int> *featsM,
    std::vector<double> *radiusM,
    std::vector<int> *pupils0,
    std::vector<int> *pupils1)
{
    return cvTry([&] {
        obj->shape_offset = data.shape_offset;
        obj->verbose = (data.verbose != 0);
        obj->n_landmarks = data.n_landmarks;
        obj->initShape_n = data.initShape_n;
        obj->stages_n = data.stages_n;
        obj->tree_n = data.tree_n;
        obj->tree_depth = data.tree_depth;
        obj->bagging_overlap = data.bagging_overlap;
        obj->save_model = (data.save_model != 0);
        obj->seed = data.seed;
        obj->detectROI = cpp(data.detectROI);
        obj->cascade_face = cascadeFace;
        obj->model_filename = modelFilename;
        obj->feats_m.assign(featsM->begin(), featsM->end());
        obj->radius_m.assign(radiusM->begin(), radiusM->end());
        obj->pupils[0].assign(pupils0->begin(), pupils0->end());
        obj->pupils[1].assign(pupils1->begin(), pupils1->end());
    });
}


CVAPI(ExceptionStatus) face_FacemarkLBF_Params_read(cv::face::FacemarkLBF::Params *obj, cv::FileNode *fn)
{
    return cvTry([&] {
        obj->read(*fn);
    });
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_write(cv::face::FacemarkLBF::Params *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
        obj->write(*fs);
    });
}

#pragma endregion
#pragma endregion

#pragma region FacemarkAAM

CVAPI(ExceptionStatus) face_FacemarkAAM_create(cv::face::FacemarkAAM::Params *params, cv::Ptr<cv::face::FacemarkAAM> **returnValue)
{
    return cvTry([&] {
        const auto obj = (params == nullptr) ?
            cv::face::FacemarkAAM::create() :
            cv::face::FacemarkAAM::create(*params);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkAAM_get(cv::Ptr<cv::face::FacemarkAAM> *obj, cv::face::FacemarkAAM **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkAAM_delete(cv::Ptr<cv::face::FacemarkAAM> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) face_FacemarkAAM_fitConfig(
    cv::face::FacemarkAAM *obj,
    const interop::InputArrayProxy *image,
    const interop::InputArrayProxy *roi,
    std::vector<std::vector<cv::Point2f>> *landmarks,
    cv::Mat **rotations,
    const interop::Point2f *translations,
    const float *scales,
    const int *modelScaleIndexes,
    const int configLength,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::face::FacemarkAAM::Config> configs;
        configs.reserve(configLength);
        for (auto i = 0; i < configLength; i++)
        {
            const auto rotation = rotations[i] == nullptr
                ? cv::Mat::eye(2, 2, CV_32F)
                : *rotations[i];
            configs.emplace_back(rotation, cpp(translations[i]), scales[i], modelScaleIndexes[i]);
        }
        *returnValue = obj->fitConfig(InProxy(*image), InProxy(*roi), *landmarks, configs) ? 1 : 0;
    });
}

#pragma region Params

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_new(cv::face::FacemarkAAM::Params **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::face::FacemarkAAM::Params;
    });
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_delete(cv::face::FacemarkAAM::Params *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_getAll(
    cv::face::FacemarkAAM::Params *obj,
    FacemarkAAMParamsData *data,
    std::string *modelFilename,
    std::vector<float> *scales)
{
    return cvTry([&] {
        data->m = obj->m;
        data->n = obj->n;
        data->n_iter = obj->n_iter;
        data->verbose = obj->verbose ? 1 : 0;
        data->save_model = obj->save_model ? 1 : 0;
        data->max_m = obj->max_m;
        data->max_n = obj->max_n;
        data->texture_max_m = obj->texture_max_m;
        modelFilename->assign(obj->model_filename);
        std::copy(obj->scales.begin(), obj->scales.end(), std::back_inserter(*scales));
    });
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_setAll(
    cv::face::FacemarkAAM::Params *obj,
    FacemarkAAMParamsData data,
    const char *modelFilename,
    std::vector<float> *scales)
{
    return cvTry([&] {
        obj->m = data.m;
        obj->n = data.n;
        obj->n_iter = data.n_iter;
        obj->verbose = (data.verbose != 0);
        obj->save_model = (data.save_model != 0);
        obj->max_m = data.max_m;
        obj->max_n = data.max_n;
        obj->texture_max_m = data.texture_max_m;
        obj->model_filename = modelFilename;
        obj->scales.assign(scales->begin(), scales->end());
    });
}


CVAPI(ExceptionStatus) face_FacemarkAAM_Params_read(cv::face::FacemarkAAM::Params *obj, cv::FileNode *fn)
{
    return cvTry([&] {
        obj->read(*fn);
    });
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_write(cv::face::FacemarkAAM::Params *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
        obj->write(*fs);
    });
}

#pragma endregion
#pragma endregion

#pragma region FacemarkKazemi

CVAPI(ExceptionStatus) face_FacemarkKazemi_create(
    cv::face::FacemarkKazemi::Params *params,
    cv::Ptr<cv::face::FacemarkKazemi> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(params == nullptr
            ? cv::face::FacemarkKazemi::create()
            : cv::face::FacemarkKazemi::create(*params));
    });
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkKazemi_get(
    cv::Ptr<cv::face::FacemarkKazemi> *obj,
    cv::face::FacemarkKazemi **returnValue)
{
    return cvTry([&] { *returnValue = obj->get(); });
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkKazemi_delete(
    cv::Ptr<cv::face::FacemarkKazemi> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) face_FacemarkKazemi_training(
    cv::face::FacemarkKazemi *obj,
    cv::Mat **images,
    const int imagesLength,
    cv::Point2f **landmarks,
    const int *landmarkSizes,
    const int landmarksLength,
    const char *configFile,
    const interop::Size scale,
    const char *modelFilename,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> imageVector(imagesLength);
        for (auto i = 0; i < imagesLength; i++)
            imageVector[i] = *images[i];
        std::vector<std::vector<cv::Point2f>> landmarkVector(landmarksLength);
        for (auto i = 0; i < landmarksLength; i++)
        {
            if (landmarkSizes[i] > 0)
                landmarkVector[i].assign(landmarks[i], landmarks[i] + landmarkSizes[i]);
        }
        *returnValue = obj->training(
            imageVector, landmarkVector, configFile, cpp(scale), modelFilename) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) face_FacemarkKazemi_getFaces(
    cv::face::FacemarkKazemi *obj,
    const interop::InputArrayProxy *image,
    std::vector<cv::Rect> *faces,
    int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getFaces(InProxy(*image), *faces) ? 1 : 0; });
}

CVAPI(ExceptionStatus) face_FacemarkKazemi_setFaceDetector(
    cv::face::FacemarkKazemi *obj,
    const FacemarkFaceDetectorCallback callback,
    FacemarkFaceDetectorCallbackData **callbackData,
    int *returnValue)
{
    return cvTry([&] {
        const auto data = new FacemarkFaceDetectorCallbackData { callback };
        if (!obj->setFaceDetector(face_Facemark_faceDetectorThunk, data))
        {
            delete data;
            *callbackData = nullptr;
            *returnValue = 0;
            return;
        }
        *callbackData = data;
        *returnValue = 1;
    });
}

CVAPI(ExceptionStatus) face_FacemarkKazemi_Params_new(
    cv::face::FacemarkKazemi::Params **returnValue)
{
    return cvTry([&] { *returnValue = new cv::face::FacemarkKazemi::Params; });
}

CVAPI(ExceptionStatus) face_FacemarkKazemi_Params_delete(
    cv::face::FacemarkKazemi::Params *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) face_FacemarkKazemi_Params_getAll(
    cv::face::FacemarkKazemi::Params *obj,
    FacemarkKazemiParamsData *data,
    std::string *configFile)
{
    return cvTry([&] {
        data->cascade_depth = obj->cascade_depth;
        data->tree_depth = obj->tree_depth;
        data->num_trees_per_cascade_level = obj->num_trees_per_cascade_level;
        data->learning_rate = obj->learning_rate;
        data->oversampling_amount = obj->oversampling_amount;
        data->num_test_coordinates = obj->num_test_coordinates;
        data->lambda = obj->lambda;
        data->num_test_splits = obj->num_test_splits;
        configFile->assign(obj->configfile);
    });
}

CVAPI(ExceptionStatus) face_FacemarkKazemi_Params_setAll(
    cv::face::FacemarkKazemi::Params *obj,
    const FacemarkKazemiParamsData data,
    const char *configFile)
{
    return cvTry([&] {
        obj->cascade_depth = static_cast<unsigned long>(data.cascade_depth);
        obj->tree_depth = static_cast<unsigned long>(data.tree_depth);
        obj->num_trees_per_cascade_level = static_cast<unsigned long>(data.num_trees_per_cascade_level);
        obj->learning_rate = data.learning_rate;
        obj->oversampling_amount = static_cast<unsigned long>(data.oversampling_amount);
        obj->num_test_coordinates = static_cast<unsigned long>(data.num_test_coordinates);
        obj->lambda = data.lambda;
        obj->num_test_splits = static_cast<unsigned long>(data.num_test_splits);
        obj->configfile = configFile;
    });
}

#pragma endregion

#endif // !_WINRT_DLL
#endif // NO_CONTRIB
