#ifndef _CPP_FACE_FACEMARK_H_
#define _CPP_FACE_FACEMARK_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


#pragma region Facemark

CVAPI(ExceptionStatus) face_Facemark_loadModel(cv::face::Facemark *obj, const char *model)
{
    BEGIN_WRAP
    obj->loadModel(model);
    END_WRAP
}

CVAPI(ExceptionStatus)
face_Facemark_fit(
    cv::face::Facemark *obj,
    cv::_InputArray *image,
    cv::_InputArray *faces,
    std::vector<std::vector<cv::Point2f>> *landmarks,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->fit(*image, *faces, *landmarks) ? 1 : 0;
    END_WRAP
}

#pragma endregion

#pragma region FacemarkLBF

CVAPI(ExceptionStatus) face_FacemarkLBF_create(cv::face::FacemarkLBF::Params *params, cv::Ptr<cv::face::FacemarkLBF> **returnValue)
{
    BEGIN_WRAP
    const auto obj = (params == nullptr) ? 
        cv::face::FacemarkLBF::create() :
        cv::face::FacemarkLBF::create(*params);
    *returnValue = clone(obj);
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkLBF_get(cv::Ptr<cv::face::FacemarkLBF> *obj, cv::face::FacemarkLBF **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkLBF_delete(cv::Ptr<cv::face::FacemarkLBF> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

#pragma region Params

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_new(cv::face::FacemarkLBF::Params **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::face::FacemarkLBF::Params;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_delete(cv::face::FacemarkLBF::Params *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_shape_offset_get(cv::face::FacemarkLBF::Params *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->shape_offset;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_shape_offset_set(cv::face::FacemarkLBF::Params *obj, double val)
{
    BEGIN_WRAP
    obj->shape_offset = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_cascade_face_get(cv::face::FacemarkLBF::Params *obj, std::string *s)
{
    BEGIN_WRAP
    s->assign(obj->cascade_face);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_cascade_face_set(cv::face::FacemarkLBF::Params *obj, const char *s)
{
    BEGIN_WRAP
     obj->cascade_face = s;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_verbose_get(cv::face::FacemarkLBF::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->verbose ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_verbose_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    BEGIN_WRAP
    obj->verbose = (val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_n_landmarks_get(cv::face::FacemarkLBF::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->n_landmarks;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_n_landmarks_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    BEGIN_WRAP
    obj->n_landmarks = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_initShape_n_get(cv::face::FacemarkLBF::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->initShape_n;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_initShape_n_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    BEGIN_WRAP
    obj->initShape_n = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_stages_n_get(cv::face::FacemarkLBF::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->stages_n;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_stages_n_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    BEGIN_WRAP
    obj->stages_n = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_tree_n_get(cv::face::FacemarkLBF::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->tree_n;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_tree_n_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    BEGIN_WRAP
    obj->tree_n = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_tree_depth_get(cv::face::FacemarkLBF::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->tree_depth;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_tree_depth_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    BEGIN_WRAP
    obj->tree_depth = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_bagging_overlap_get(cv::face::FacemarkLBF::Params *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->bagging_overlap;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_bagging_overlap_set(cv::face::FacemarkLBF::Params *obj, double val)
{
    BEGIN_WRAP
    obj->bagging_overlap = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_model_filename_get(cv::face::FacemarkLBF::Params *obj, std::string *s)
{
    BEGIN_WRAP
    s->assign(obj->model_filename);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_model_filename_set(cv::face::FacemarkLBF::Params *obj, const char *s)
{
    BEGIN_WRAP
    obj->model_filename = s;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_save_model_get(cv::face::FacemarkLBF::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->save_model ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_save_model_set(cv::face::FacemarkLBF::Params *obj, int val)
{
    BEGIN_WRAP
    obj->save_model = (val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_seed_get(cv::face::FacemarkLBF::Params *obj, unsigned int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->seed;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_seed_set(cv::face::FacemarkLBF::Params *obj, unsigned int val)
{
    BEGIN_WRAP
    obj->seed = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_feats_m_get(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    BEGIN_WRAP
    std::copy(obj->feats_m.begin(), obj->feats_m.end(), std::back_inserter(*v));
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_feats_m_set(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    BEGIN_WRAP
    obj->feats_m.clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->feats_m));
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_radius_m_get(cv::face::FacemarkLBF::Params *obj, std::vector<double> *v)
{
    BEGIN_WRAP
    std::copy(obj->radius_m.begin(), obj->radius_m.end(), std::back_inserter(*v));
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_radius_m_set(cv::face::FacemarkLBF::Params *obj, std::vector<double> *v)
{
    BEGIN_WRAP
    obj->radius_m.clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->radius_m));
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_pupils0_get(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    BEGIN_WRAP
    std::copy(obj->pupils[0].begin(), obj->pupils[0].end(), std::back_inserter(*v));
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_pupils0_set(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    BEGIN_WRAP
    obj->pupils[0].clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->pupils[0]));
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_pupils1_get(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    BEGIN_WRAP
    std::copy(obj->pupils[1].begin(), obj->pupils[1].end(), std::back_inserter(*v));
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_pupils1_set(cv::face::FacemarkLBF::Params *obj, std::vector<int> *v)
{
    BEGIN_WRAP
    obj->pupils[1].clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->pupils[1]));
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_detectROI_get(cv::face::FacemarkLBF::Params *obj, MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->detectROI);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkLBF_Params_detectROI_set(cv::face::FacemarkLBF::Params *obj, MyCvRect val)
{
    BEGIN_WRAP
    obj->detectROI = cpp(val);
    END_WRAP
}


CVAPI(ExceptionStatus) face_FacemarkLBF_Params_read(cv::face::FacemarkLBF::Params *obj, cv::FileNode *fn)
{
    BEGIN_WRAP
    obj->read(*fn);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkLBF_Params_write(cv::face::FacemarkLBF::Params *obj, cv::FileStorage *fs)
{
    BEGIN_WRAP
    obj->write(*fs);
    END_WRAP
}

#pragma endregion
#pragma endregion

#pragma region FacemarkAAM

CVAPI(ExceptionStatus) face_FacemarkAAM_create(cv::face::FacemarkAAM::Params *params, cv::Ptr<cv::face::FacemarkAAM> **returnValue)
{
    BEGIN_WRAP
    const auto obj = (params == nullptr) ?
        cv::face::FacemarkAAM::create() :
        cv::face::FacemarkAAM::create(*params);
    *returnValue = clone(obj);
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkAAM_get(cv::Ptr<cv::face::FacemarkAAM> *obj, cv::face::FacemarkAAM **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) face_Ptr_FacemarkAAM_delete(cv::Ptr<cv::face::FacemarkAAM> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

#pragma region Params

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_new(cv::face::FacemarkAAM::Params **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::face::FacemarkAAM::Params;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_delete(cv::face::FacemarkAAM::Params *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_model_filename_get(cv::face::FacemarkAAM::Params *obj, std::string *s)
{
    BEGIN_WRAP
    s->assign(obj->model_filename);
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_model_filename_set(cv::face::FacemarkAAM::Params *obj, const char *s)
{
    BEGIN_WRAP
    obj->model_filename = s;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_m_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->m;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_m_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->m = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_n_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->n;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_n_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->n = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_n_iter_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->n_iter;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_n_iter_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->n_iter = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_verbose_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->verbose ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_verbose_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->verbose = (val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_save_model_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->save_model ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_save_model_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->save_model = (val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_max_m_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->max_m;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_max_m_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->max_m = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_max_n_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->max_n;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_max_n_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->max_n = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_texture_max_m_get(cv::face::FacemarkAAM::Params *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->texture_max_m;
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_texture_max_m_set(cv::face::FacemarkAAM::Params *obj, int val)
{
    BEGIN_WRAP
    obj->texture_max_m = val;
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_scales_get(cv::face::FacemarkAAM::Params *obj, std::vector<float> *v)
{
    BEGIN_WRAP
    std::copy(obj->scales.begin(), obj->scales.end(), std::back_inserter(*v));
    END_WRAP
}
CVAPI(ExceptionStatus) face_FacemarkAAM_Params_scales_set(cv::face::FacemarkAAM::Params *obj, std::vector<float> *v)
{
    BEGIN_WRAP
    obj->scales.clear();
    std::copy(v->begin(), v->end(), std::back_inserter(obj->scales));
    END_WRAP
}


CVAPI(ExceptionStatus) face_FacemarkAAM_Params_read(cv::face::FacemarkAAM::Params *obj, cv::FileNode *fn)
{
    BEGIN_WRAP
    obj->read(*fn);
    END_WRAP
}

CVAPI(ExceptionStatus) face_FacemarkAAM_Params_write(cv::face::FacemarkAAM::Params *obj, cv::FileStorage *fs)
{
    BEGIN_WRAP
    obj->write(*fs);
    END_WRAP
}

#pragma endregion
#pragma endregion

#endif