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

#pragma region Facemark

CVAPI(ExceptionStatus) face_Facemark_loadModel(cv::face::Facemark *obj, const char *model)
{
    return cvTry([&] {
    obj->loadModel(model);
    });
}

CVAPI(ExceptionStatus)
face_Facemark_fit(
    cv::face::Facemark *obj,
    cv::_InputArray *image,
    cv::_InputArray *faces,
    std::vector<std::vector<cv::Point2f>> *landmarks,
    int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->fit(*image, *faces, *landmarks) ? 1 : 0;
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

#endif // !_WINRT_DLL
#endif // NO_CONTRIB