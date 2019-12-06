#ifndef _CPP_FACE_FACEMARK_H_
#define _CPP_FACE_FACEMARK_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


#pragma region Facemark

CVAPI(void) face_Facemark_read(cv::face::Facemark *obj, cv::FileNode *fn)
{
    obj->read(*fn);
}

CVAPI(void) face_Facemark_write(cv::face::Facemark *obj, cv::FileStorage *fs)
{
    obj->write(*fs);
}

/*
CVAPI(int) face_Facemark_addTrainingSample(Facemark *obj, cv::_InputArray *image, cv::_InputArray *landmarks)
{
    return obj->addTrainingSample(*image, *landmarks) ? 1 : 0;
}

CVAPI(void) face_Facemark_training(Facemark *obj, void* parameters)
{
    obj->training(parameters);
}*/

CVAPI(void) face_Facemark_loadModel(cv::face::Facemark *obj, const char *model)
{
    obj->loadModel(model);
}

CVAPI(int) face_Facemark_fit(cv::face::Facemark *obj, 
    cv::_InputArray *image,
    cv::_InputArray *faces,
    cv::_InputOutputArray *landmarks)
{
    return obj->fit(*image, *faces, *landmarks) ? 1 : 0;
}

/*
CVAPI(int) face_Facemark_setFaceDetector(Facemark *obj, FN_FaceDetector detector, void* userData)
{
    return obj->setFaceDetector(detector, userData) ? 1 : 0;
}

CVAPI(int) face_Facemark_getFaces_OutputArray(Facemark *obj, cv::_InputArray *image, cv::_OutputArray *faces)
{
    return obj->getFaces(*image, *faces) ? 1 : 0;
}
CVAPI(int) face_Facemark_getFaces_vectorOfRect(Facemark *obj, cv::_InputArray *image, std::vector<cv::Rect> *faces)
{
    return obj->getFaces(*image, *faces) ? 1 : 0;
}*/

#pragma endregion

#pragma region FacemarkLBF

CVAPI(cv::Ptr<cv::face::FacemarkLBF>*) face_FacemarkLBF_create(cv::face::FacemarkLBF::Params *params)
{
    const cv::Ptr<cv::face::FacemarkLBF> obj = (params == nullptr) ? 
        cv::face::FacemarkLBF::create() :
        cv::face::FacemarkLBF::create(*params);
    return clone(obj);
}

CVAPI(cv::face::FacemarkLBF*) face_Ptr_FacemarkLBF_get(cv::Ptr<cv::face::FacemarkLBF> *obj)
{
    return obj->get();
}

CVAPI(void) face_Ptr_FacemarkLBF_delete(cv::Ptr<cv::face::FacemarkLBF> *obj)
{
    delete obj;
}

#pragma region Params

CVAPI(cv::face::FacemarkLBF::Params*) face_FacemarkLBF_Params_new()
{
    return new cv::face::FacemarkLBF::Params;
}

CVAPI(void) face_FacemarkLBF_Params_delete(cv::face::FacemarkLBF::Params *obj)
{
    delete obj;
}

CVAPI(double) face_FacemarkLBF_Params_shape_offset_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->shape_offset;
}
CVAPI(void) face_FacemarkLBF_Params_shape_offset_set(cv::face::FacemarkLBF::Params *obj, double val)
{
    obj->shape_offset = val;
}

CVAPI(void) face_FacemarkLBF_Params_cascade_face_get(cv::face::FacemarkLBF::Params *obj, std::string *s)
{
    *s = obj->cascade_face;
}
CVAPI(void) face_FacemarkLBF_Params_cascade_face_set(cv::face::FacemarkLBF::Params *obj, const char *s)
{
     obj->cascade_face = s;
}

CVAPI(int) face_FacemarkLBF_Params_verbose_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->verbose ? 1 : 0;
}
CVAPI(void) face_FacemarkLBF_Params_verbose_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    obj->verbose = (val != 0);
}

CVAPI(int) face_FacemarkLBF_Params_n_landmarks_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->n_landmarks;
}
CVAPI(void) face_FacemarkLBF_Params_n_landmarks_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    obj->n_landmarks = val;
}

CVAPI(int) face_FacemarkLBF_Params_initShape_n_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->initShape_n;
}
CVAPI(void) face_FacemarkLBF_Params_initShape_n_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    obj->initShape_n = val;
}

CVAPI(int) face_FacemarkLBF_Params_stages_n_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->stages_n;
}
CVAPI(void) face_FacemarkLBF_Params_stages_n_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    obj->stages_n = val;
}

CVAPI(int) face_FacemarkLBF_Params_tree_n_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->tree_n;
}
CVAPI(void) face_FacemarkLBF_Params_tree_n_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    obj->tree_n = val;
}

CVAPI(int) face_FacemarkLBF_Params_tree_depth_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->tree_depth;
}
CVAPI(void) face_FacemarkLBF_Params_tree_depth_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    obj->tree_depth = val;
}

CVAPI(double) face_FacemarkLBF_Params_bagging_overlap_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->bagging_overlap;
}
CVAPI(void) face_FacemarkLBF_Params_bagging_overlap_set(cv::face::FacemarkLBF::Params *obj, double val)
{
    obj->bagging_overlap = val;
}

CVAPI(void) face_FacemarkLBF_Params_model_filename_get(cv::face::FacemarkLBF::Params *obj, std::string *s)
{
    *s = obj->model_filename;
}
CVAPI(void) face_FacemarkLBF_Params_model_filename_set(cv::face::FacemarkLBF::Params *obj, const char *s)
{
    obj->model_filename = s;
}

CVAPI(int) face_FacemarkLBF_Params_save_model_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->save_model ? 1 : 0;
}
CVAPI(void) face_FacemarkLBF_Params_save_model_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    obj->save_model = (val != 0);
}

CVAPI(unsigned int) face_FacemarkLBF_Params_seed_get(cv::face::FacemarkLBF::Params *obj)
{
    return obj->seed;
}
CVAPI(void) face_FacemarkLBF_Params_seed_set(cv::face::FacemarkLBF::Params *obj, unsigned int val)
{
    obj->seed = val;
}

CVAPI(void) face_FacemarkLBF_Params_feats_m_get(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    std::copy(obj->feats_m.begin(), obj->feats_m.end(), std::back_inserter(*v));
}
CVAPI(void) face_FacemarkLBF_Params_feats_m_set(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    obj->feats_m.clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->feats_m));
}

CVAPI(void) face_FacemarkLBF_Params_radius_m_get(cv::face::FacemarkLBF::Params *obj, std::vector<double> *v)
{
    std::copy(obj->radius_m.begin(), obj->radius_m.end(), std::back_inserter(*v));
}
CVAPI(void) face_FacemarkLBF_Params_radius_m_set(cv::face::FacemarkLBF::Params *obj, std::vector<double> *v)
{
    obj->radius_m.clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->radius_m));
}

CVAPI(void) face_FacemarkLBF_Params_pupils0_get(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    std::copy(obj->pupils[0].begin(), obj->pupils[0].end(), std::back_inserter(*v));
}
CVAPI(void) face_FacemarkLBF_Params_pupils0_set(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    obj->pupils[0].clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->pupils[0]));
}

CVAPI(void) face_FacemarkLBF_Params_pupils1_get(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    std::copy(obj->pupils[1].begin(), obj->pupils[1].end(), std::back_inserter(*v));
}
CVAPI(void) face_FacemarkLBF_Params_pupils1_set(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    obj->pupils[1].clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->pupils[1]));
}

CVAPI(MyCvRect) face_FacemarkLBF_Params_detectROI_get(cv::face::FacemarkLBF::Params *obj)
{
    return c(obj->detectROI);
}
CVAPI(void) face_FacemarkLBF_Params_detectROI_set(cv::face::FacemarkLBF::Params *obj, MyCvRect val)
{
    obj->detectROI = cpp(val);
}


CVAPI(void) face_FacemarkLBF_Params_read(cv::face::FacemarkLBF::Params *obj, cv::FileNode *fn)
{
    obj->read(*fn);
}

CVAPI(void) face_FacemarkLBF_Params_write(cv::face::FacemarkLBF::Params *obj, cv::FileStorage *fs)
{
    obj->write(*fs);
}

#pragma endregion
#pragma endregion

#pragma region FacemarkAAM

CVAPI(cv::Ptr<cv::face::FacemarkAAM>*) face_FacemarkAAM_create(cv::face::FacemarkAAM::Params *params)
{
    const cv::Ptr<cv::face::FacemarkAAM> obj = (params == nullptr) ?
        cv::face::FacemarkAAM::create() :
        cv::face::FacemarkAAM::create(*params);
    return clone(obj);
}

CVAPI(cv::face::FacemarkAAM*) face_Ptr_FacemarkAAM_get(cv::Ptr<cv::face::FacemarkAAM> *obj)
{
    return obj->get();
}

CVAPI(void) face_Ptr_FacemarkAAM_delete(cv::Ptr<cv::face::FacemarkAAM> *obj)
{
    delete obj;
}

#pragma region Params

CVAPI(cv::face::FacemarkAAM::Params*) face_FacemarkAAM_Params_new()
{
    return new cv::face::FacemarkAAM::Params;
}

CVAPI(void) face_FacemarkAAM_Params_delete(cv::face::FacemarkAAM::Params *obj)
{
    delete obj;
}

CVAPI(void) face_FacemarkAAM_Params_model_filename_get(cv::face::FacemarkAAM::Params *obj, std::string *s)
{
    *s = obj->model_filename;
}
CVAPI(void) face_FacemarkAAM_Params_model_filename_set(cv::face::FacemarkAAM::Params *obj, const char *s)
{
    obj->model_filename = s;
}

CVAPI(int) face_FacemarkAAM_Params_m_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->m;
}
CVAPI(void) face_FacemarkAAM_Params_m_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->m = val;
}

CVAPI(int) face_FacemarkAAM_Params_n_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->n;
}
CVAPI(void) face_FacemarkAAM_Params_n_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->n = val;
}

CVAPI(int) face_FacemarkAAM_Params_n_iter_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->n_iter;
}
CVAPI(void) face_FacemarkAAM_Params_n_iter_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->n_iter = val;
}

CVAPI(int) face_FacemarkAAM_Params_verbose_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->verbose ? 1 : 0;
}
CVAPI(void) face_FacemarkAAM_Params_verbose_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->verbose = (val != 0);
}

CVAPI(int) face_FacemarkAAM_Params_save_model_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->save_model ? 1 : 0;
}
CVAPI(void) face_FacemarkAAM_Params_save_model_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->save_model = (val != 0);
}

CVAPI(int) face_FacemarkAAM_Params_max_m_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->max_m;
}
CVAPI(void) face_FacemarkAAM_Params_max_m_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->max_m = val;
}

CVAPI(int) face_FacemarkAAM_Params_max_n_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->max_n;
}
CVAPI(void) face_FacemarkAAM_Params_max_n_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->max_n = val;
}

CVAPI(int) face_FacemarkAAM_Params_texture_max_m_get(cv::face::FacemarkAAM::Params *obj)
{
    return obj->texture_max_m;
}
CVAPI(void) face_FacemarkAAM_Params_texture_max_m_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    obj->texture_max_m = val;
}

CVAPI(void) face_FacemarkAAM_Params_scales_get(cv::face::FacemarkAAM::Params *obj, std::vector<float> *v)
{
    std::copy(obj->scales.begin(), obj->scales.end(), std::back_inserter(*v));
}
CVAPI(void) face_FacemarkAAM_Params_scales_set(cv::face::FacemarkAAM::Params *obj, std::vector<float> *v)
{
    obj->scales.clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->scales));
}


CVAPI(void) face_FacemarkAAM_Params_read(cv::face::FacemarkAAM::Params *obj, cv::FileNode *fn)
{
    obj->read(*fn);
}

CVAPI(void) face_FacemarkAAM_Params_write(cv::face::FacemarkAAM::Params *obj, cv::FileStorage *fs)
{
    obj->write(*fs);
}

#pragma endregion
#pragma endregion

#endif