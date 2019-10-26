#ifndef _CPP_TRACKING_H_
#define _CPP_TRACKING_H_

// ReSharper disable CommentTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable IdentifierTypo

#include "include_opencv.h"

CVAPI(int) tracking_Tracker_init(cv::Tracker* tracker, const cv::Mat* image, const MyCvRect2D64f boundingBox)
{
    bool ret = tracker->init(*image, cpp(boundingBox));
    return ret ? 1 : 0;
}

/*
CVAPI(int) tracking_Tracker_init2(cv::Tracker* tracker, const cv::Mat* image, const MyCvRect2D boundingBox, std::string *outMessage)
{
	try
	{
		bool ret = tracker->init(*image, cpp(boundingBox));
		return ret ? 1 : 0;
	}
	catch (cv::Exception &ex)
	{
		std::string message = "err:" + ex.err + " file:" + ex.file + " func:" + ex.func + " msg:" + ex.msg;
		outMessage->assign(message);
		return 0;
	}
	catch (std::exception &ex)
	{
		std::string message = ex.what();
		outMessage->assign(message);
		return 0;
	}
}*/

CVAPI(int) tracking_Tracker_update(cv::Tracker* tracker, const cv::Mat* image, MyCvRect2D64f* boundingBox)
{
    cv::Rect2d bb = cpp(*boundingBox);
	const bool ret = tracker->update(*image, bb);
    if (ret)
    {
        boundingBox->x = bb.x;
        boundingBox->y = bb.y;
        boundingBox->width = bb.width;
        boundingBox->height = bb.height;
    }

    return ret ? 1 : 0;
}

CVAPI(void) tracking_Ptr_Tracker_delete(cv::Ptr<cv::Tracker> *ptr)
{
    delete ptr;
}

CVAPI(cv::Tracker*) tracking_Ptr_Tracker_get(cv::Ptr<cv::Tracker> *ptr)
{
    return ptr->get();
}

// TrackerKCF

CVAPI(cv::Ptr<cv::TrackerKCF>*) tracking_TrackerKCF_create1()
{
	const auto p = cv::TrackerKCF::create();
	return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerKCF>*) tracking_TrackerKCF_create2(cv::TrackerKCF::Params *parameters)
{
	const auto p = cv::TrackerKCF::create(*parameters);
	return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerKCF_delete(cv::Ptr<cv::TrackerKCF> *ptr)
{
	delete ptr;
}

CVAPI(cv::TrackerKCF*) tracking_Ptr_TrackerKCF_get(cv::Ptr<cv::TrackerKCF> *ptr)
{
	return ptr->get();
}

// TrackerMIL

CVAPI(cv::Ptr<cv::TrackerMIL>*) tracking_TrackerMIL_create1()
{
	const auto p = cv::TrackerMIL::create();
	return clone(p);
}

CVAPI(cv::Ptr<cv::TrackerMIL>*) tracking_TrackerMIL_create2(cv::TrackerMIL::Params *parameters)
{
    const auto p = cv::TrackerMIL::create(*parameters);
    return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerMIL_delete(cv::Ptr<cv::TrackerMIL> *ptr)
{
    delete ptr;
}

CVAPI(cv::TrackerMIL*) tracking_Ptr_TrackerMIL_get(cv::Ptr<cv::TrackerMIL> *ptr)
{
    return ptr->get();
}

// TrackerBoosting

CVAPI(cv::Ptr<cv::TrackerBoosting>*) tracking_TrackerBoosting_create1()
{
    const auto p = cv::TrackerBoosting::create();
    return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerBoosting>*) tracking_TrackerBoosting_create2(cv::TrackerBoosting::Params *parameters)
{
    const auto p = cv::TrackerBoosting::create(*parameters);
    return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerBoosting_delete(cv::Ptr<cv::TrackerBoosting> *ptr)
{
    delete ptr;
}

CVAPI(cv::TrackerBoosting*) tracking_Ptr_TrackerBoosting_get(cv::Ptr<cv::TrackerBoosting> *ptr)
{
    return ptr->get();
}

// TrackerMedianFlow

CVAPI(cv::Ptr<cv::TrackerMedianFlow>*) tracking_TrackerMedianFlow_create1()
{
    const auto p = cv::TrackerMedianFlow::create();
    return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerMedianFlow>*) tracking_TrackerMedianFlow_create2(cv::TrackerMedianFlow::Params *parameters)
{
    const auto p = cv::TrackerMedianFlow::create(*parameters);
    return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerMedianFlow_delete(cv::Ptr<cv::TrackerMedianFlow> *ptr)
{
    delete ptr;
}

CVAPI(cv::TrackerMedianFlow*) tracking_Ptr_TrackerMedianFlow_get(cv::Ptr<cv::TrackerMedianFlow> *ptr)
{
    return ptr->get();
}

// TrackerTLD

CVAPI(cv::Ptr<cv::TrackerTLD>*) tracking_TrackerTLD_create1()
{
    const auto p = cv::TrackerTLD::create();
    return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerTLD>*) tracking_TrackerTLD_create2(cv::TrackerTLD::Params *parameters)
{
    const auto p = cv::TrackerTLD::create(*parameters);
    return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerTLD_delete(cv::Ptr<cv::TrackerTLD> *ptr)
{
    delete ptr;
}

CVAPI(cv::TrackerTLD*) tracking_Ptr_TrackerTLD_get(cv::Ptr<cv::TrackerTLD> *ptr)
{
    return ptr->get();
}

// TrackerGOTURN

CVAPI(cv::Ptr<cv::TrackerGOTURN>*) tracking_TrackerGOTURN_create1()
{
    const auto p = cv::TrackerGOTURN::create();
    return clone(p);
}
CVAPI(cv::Ptr<cv::TrackerGOTURN>*) tracking_TrackerGOTURN_create2(cv::TrackerGOTURN::Params *parameters)
{
    const auto p = cv::TrackerGOTURN::create(*parameters);
    return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerGOTURN_delete(cv::Ptr<cv::TrackerGOTURN> *ptr)
{
    delete ptr;
}

CVAPI(cv::TrackerGOTURN*) tracking_Ptr_TrackerGOTURN_get(cv::Ptr<cv::TrackerGOTURN> *ptr)
{
    return ptr->get();
}

// TrackerMOSSE

CVAPI(cv::Ptr<cv::TrackerMOSSE>*) tracking_TrackerMOSSE_create()
{
    const auto p = cv::TrackerMOSSE::create();
    return clone(p);
}

CVAPI(void) tracking_Ptr_TrackerMOSSE_delete(cv::Ptr<cv::TrackerMOSSE> *ptr)
{
    delete ptr;
}

CVAPI(cv::TrackerMOSSE*) tracking_Ptr_TrackerMOSSE_get(cv::Ptr<cv::TrackerMOSSE> *ptr)
{
    return ptr->get();
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

CVAPI(cv::Ptr<cv::TrackerCSRT>*) tracking_TrackerCSRT_create1()
{
    const auto p = cv::TrackerCSRT::create();
    return clone(p);
}

CVAPI(cv::Ptr<cv::TrackerCSRT>*) tracking_TrackerCSRT_create2(tracker_TrackerCSRT_Params* parameters)
{
    const auto p = _tracking_TrackerCSRT_Param_ToCpp(parameters);
    const auto obj = cv::TrackerCSRT::create(p);
    return clone(obj);
}

CVAPI(void) tracking_Ptr_TrackerCSRT_delete(cv::Ptr<cv::TrackerCSRT>* ptr)
{
    delete ptr;
}

CVAPI(cv::TrackerCSRT*) tracking_Ptr_TrackerCSRT_get(cv::Ptr<cv::TrackerCSRT>* ptr)
{
    return ptr->get();
}

CVAPI(void) tracking_TrackerCSRT_setInitialMask(cv::TrackerCSRT *tracker, cv::_InputArray *mask)
{
    tracker->setInitialMask(*mask);
}

CVAPI(void) tracking_TrackerCSRT_Params_write(tracker_TrackerCSRT_Params* params, cv::FileStorage *fs)
{
    const auto p = _tracking_TrackerCSRT_Param_ToCpp(params);
    p.write(*fs);
}

CVAPI(void) tracking_TrackerCSRT_Params_read(tracker_TrackerCSRT_Params* params, char *window_function_buf, cv::FileNode* fn)
{
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
}

#endif