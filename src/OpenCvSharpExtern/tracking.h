#pragma once

// ReSharper disable CommentTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable IdentifierTypo

#include "include_opencv.h"

#pragma region TrackerCSRT

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

cv::TrackerCSRT::Params tracking_TrackerCSRT_Param_ToCpp(const tracker_TrackerCSRT_Params *params)
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
    const auto p = tracking_TrackerCSRT_Param_ToCpp(parameters);
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

#pragma endregion

#pragma region TrackerKCF

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

#pragma endregion
