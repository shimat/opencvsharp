#ifndef _CPP_TRACKING_H_
#define _CPP_TRACKING_H_

// ReSharper disable CommentTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable IdentifierTypo

#include "include_opencv.h"

CVAPI(ExceptionStatus) tracking_Tracker_init(cv::Tracker* tracker, const cv::Mat* image, const MyCvRect2D64f boundingBox, int *returnValue)
{
    BEGIN_WRAP
    const bool ret = tracker->init(*image, cpp(boundingBox));
    *returnValue = ret ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Tracker_update(cv::Tracker* tracker, const cv::Mat* image, MyCvRect2D64f* boundingBox, int *returnValue)
{
    BEGIN_WRAP
    cv::Rect2d bb = cpp(*boundingBox);
    const bool ret = tracker->update(*image, bb);
    if (ret)
    {
        boundingBox->x = bb.x;
        boundingBox->y = bb.y;
        boundingBox->width = bb.width;
        boundingBox->height = bb.height;
    }

    *returnValue = ret ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_Tracker_delete(cv::Ptr<cv::Tracker> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_Tracker_get(cv::Ptr<cv::Tracker> *ptr, cv::Tracker **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerKCF

CVAPI(ExceptionStatus) tracking_TrackerKCF_create1(cv::Ptr<cv::TrackerKCF> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerKCF::create();
    *returnValue = clone(p);
    END_WRAP
}
CVAPI(ExceptionStatus) tracking_TrackerKCF_create2(cv::TrackerKCF::Params *parameters, cv::Ptr<cv::TrackerKCF> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerKCF::create(*parameters);
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerKCF_delete(cv::Ptr<cv::TrackerKCF> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerKCF_get(cv::Ptr<cv::TrackerKCF> *ptr, cv::TrackerKCF **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerMIL

CVAPI(ExceptionStatus) tracking_TrackerMIL_create1(cv::Ptr<cv::TrackerMIL> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerMIL::create();
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_TrackerMIL_create2(cv::TrackerMIL::Params *parameters, cv::Ptr<cv::TrackerMIL> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerMIL::create(*parameters);
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerMIL_delete(cv::Ptr<cv::TrackerMIL> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerMIL_get(cv::Ptr<cv::TrackerMIL> *ptr, cv::TrackerMIL **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerBoosting

CVAPI(ExceptionStatus) tracking_TrackerBoosting_create1(cv::Ptr<cv::TrackerBoosting> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerBoosting::create();
    *returnValue = clone(p);
    END_WRAP
}
CVAPI(ExceptionStatus) tracking_TrackerBoosting_create2(cv::TrackerBoosting::Params *parameters, cv::Ptr<cv::TrackerBoosting> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerBoosting::create(*parameters);
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerBoosting_delete(cv::Ptr<cv::TrackerBoosting> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerBoosting_get(cv::Ptr<cv::TrackerBoosting> *ptr, cv::TrackerBoosting **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerMedianFlow

CVAPI(ExceptionStatus) tracking_TrackerMedianFlow_create1(cv::Ptr<cv::TrackerMedianFlow> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerMedianFlow::create();
    *returnValue = clone(p);
    END_WRAP
}
CVAPI(ExceptionStatus) tracking_TrackerMedianFlow_create2(cv::TrackerMedianFlow::Params *parameters, cv::Ptr<cv::TrackerMedianFlow> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerMedianFlow::create(*parameters);
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerMedianFlow_delete(cv::Ptr<cv::TrackerMedianFlow> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerMedianFlow_get(cv::Ptr<cv::TrackerMedianFlow> *ptr, cv::TrackerMedianFlow **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerTLD

CVAPI(ExceptionStatus) tracking_TrackerTLD_create1(cv::Ptr<cv::TrackerTLD> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerTLD::create();
    *returnValue = clone(p);
    END_WRAP
}
CVAPI(ExceptionStatus) tracking_TrackerTLD_create2(cv::TrackerTLD::Params *parameters, cv::Ptr<cv::TrackerTLD> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerTLD::create(*parameters);
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerTLD_delete(cv::Ptr<cv::TrackerTLD> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerTLD_get(cv::Ptr<cv::TrackerTLD> *ptr, cv::TrackerTLD **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerGOTURN

CVAPI(ExceptionStatus) tracking_TrackerGOTURN_create1(cv::Ptr<cv::TrackerGOTURN> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerGOTURN::create();
    *returnValue = clone(p);
    END_WRAP
}
CVAPI(ExceptionStatus) tracking_TrackerGOTURN_create2(cv::TrackerGOTURN::Params *parameters, cv::Ptr<cv::TrackerGOTURN> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerGOTURN::create(*parameters);
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerGOTURN_delete(cv::Ptr<cv::TrackerGOTURN> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerGOTURN_get(cv::Ptr<cv::TrackerGOTURN> *ptr, cv::TrackerGOTURN **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerMOSSE

CVAPI(ExceptionStatus) tracking_TrackerMOSSE_create(cv::Ptr<cv::TrackerMOSSE> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerMOSSE::create();
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerMOSSE_delete(cv::Ptr<cv::TrackerMOSSE> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerMOSSE_get(cv::Ptr<cv::TrackerMOSSE> *ptr, cv::TrackerMOSSE **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// TrackerCSRT

CV_EXTERN_C struct tracker_TrackerCSRT_Params
{
    int use_hog;
    int use_color_names;
    int use_gray;
    int use_rgb;
    int use_channel_weights;
    int use_segmentation;

    char* window_function; //!<  Window function: "hann", "cheb", "kaiser"
    float kaiser_alpha;
    float cheb_attenuation;

    float template_size;
    float gsl_sigma;
    float hog_orientations;
    float hog_clip;
    float padding;
    float filter_lr;
    float weights_lr;
    int num_hog_channels_used;
    int admm_iterations;
    int histogram_bins;
    float histogram_lr;
    int background_ratio;
    int number_of_scales;
    float scale_sigma_factor;
    float scale_model_max_area;
    float scale_lr;
    float scale_step;

    float psr_threshold; //!< we lost the target, if the psr is lower than this.
};

cv::TrackerCSRT::Params _tracking_TrackerCSRT_Param_ToCpp(const tracker_TrackerCSRT_Params *params)
{
    cv::TrackerCSRT::Params p;
    p.use_hog = params->use_hog != 0;
    p.use_color_names = params->use_color_names != 0;
    p.use_gray = params->use_gray != 0;
    p.use_rgb = params->use_rgb != 0;
    p.use_channel_weights = params->use_channel_weights != 0;
    p.use_segmentation = params->use_segmentation != 0;
    p.window_function = std::string(params->window_function);
    p.kaiser_alpha = params->kaiser_alpha;
    p.cheb_attenuation = params->cheb_attenuation;
    p.template_size = params->template_size;
    p.gsl_sigma = params->gsl_sigma;
    p.hog_orientations = params->hog_orientations;
    p.hog_clip = params->hog_clip;
    p.padding = params->padding;
    p.filter_lr = params->filter_lr;
    p.weights_lr = params->weights_lr;
    p.num_hog_channels_used = params->num_hog_channels_used;
    p.admm_iterations = params->admm_iterations;
    p.histogram_bins = params->histogram_bins;
    p.histogram_lr = params->histogram_lr;
    p.background_ratio = params->background_ratio;
    p.number_of_scales = params->number_of_scales;
    p.scale_sigma_factor = params->scale_sigma_factor;
    p.scale_model_max_area = params->scale_model_max_area;
    p.scale_lr = params->scale_lr;
    p.scale_step = params->scale_step;
    p.psr_threshold = params->psr_threshold;
    return p;
}

CVAPI(ExceptionStatus) tracking_TrackerCSRT_create1(cv::Ptr<cv::TrackerCSRT> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::TrackerCSRT::create();
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_TrackerCSRT_create2(tracker_TrackerCSRT_Params* parameters, cv::Ptr<cv::TrackerCSRT> **returnValue)
{
    BEGIN_WRAP
    const auto p = _tracking_TrackerCSRT_Param_ToCpp(parameters);
    const auto obj = cv::TrackerCSRT::create(p);
    *returnValue = clone(obj);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerCSRT_delete(cv::Ptr<cv::TrackerCSRT>* ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerCSRT_get(cv::Ptr<cv::TrackerCSRT>* ptr, cv::TrackerCSRT **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_TrackerCSRT_setInitialMask(cv::TrackerCSRT *tracker, cv::_InputArray *mask)
{
    BEGIN_WRAP
    tracker->setInitialMask(*mask);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_TrackerCSRT_Params_write(tracker_TrackerCSRT_Params* params, cv::FileStorage *fs)
{
    BEGIN_WRAP
    const auto p = _tracking_TrackerCSRT_Param_ToCpp(params);
    p.write(*fs);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_TrackerCSRT_Params_read(tracker_TrackerCSRT_Params* params, char *window_function_buf, cv::FileNode* fn)
{
    BEGIN_WRAP
    cv::TrackerCSRT::Params p;
    p.read(*fn);

    params->use_hog = p.use_hog ? 1 : 0;
    params->use_color_names = p.use_color_names ? 1 : 0;
    params->use_gray = p.use_gray ? 1 : 0;
    params->use_rgb = p.use_rgb ? 1 : 0;
    params->use_channel_weights = p.use_channel_weights ? 1 : 0;
    params->use_segmentation = p.use_segmentation ? 1 : 0;
    std::strncpy(window_function_buf, p.window_function.c_str(), 16);
    params->kaiser_alpha = p.kaiser_alpha;
    params->cheb_attenuation = p.cheb_attenuation;
    params->template_size = p.template_size;
    params->gsl_sigma = p.gsl_sigma;
    params->hog_orientations = p.hog_orientations;
    params->hog_clip = p.hog_clip;
    params->padding = p.padding;
    params->filter_lr = p.filter_lr;
    params->weights_lr = p.weights_lr;
    params->num_hog_channels_used = p.num_hog_channels_used;
    params->admm_iterations = p.admm_iterations;
    params->histogram_bins = p.histogram_bins;
    params->histogram_lr = p.histogram_lr;
    params->background_ratio = p.background_ratio;
    params->number_of_scales = p.number_of_scales;
    params->scale_sigma_factor = p.scale_sigma_factor;
    params->scale_model_max_area = p.scale_model_max_area;
    params->scale_lr = p.scale_lr;
    params->scale_step = p.scale_step;
    params->psr_threshold = p.psr_threshold;
    END_WRAP
}

#endif