#pragma once

#ifndef NO_CONTRIB

// ReSharper disable CommentTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable IdentifierTypo

#include "include_opencv.h"
#include <opencv2/tracking/tracking_legacy.hpp>

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
    return cvTry([&] {
        const auto p = cv::TrackerCSRT::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_TrackerCSRT_create2(tracker_TrackerCSRT_Params* parameters, cv::Ptr<cv::TrackerCSRT> **returnValue)
{
    return cvTry([&] {
        const auto p = tracking_TrackerCSRT_Param_ToCpp(parameters);
        const auto obj = cv::TrackerCSRT::create(p);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerCSRT_delete(cv::Ptr<cv::TrackerCSRT>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerCSRT_get(cv::Ptr<cv::TrackerCSRT>* ptr, cv::TrackerCSRT **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) tracking_TrackerCSRT_setInitialMask(cv::TrackerCSRT *tracker, const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        tracker->setInitialMask(InProxy(*mask));
    });
}

#pragma endregion

#pragma region TrackerKCF

CVAPI(ExceptionStatus) tracking_TrackerKCF_create1(cv::Ptr<cv::TrackerKCF> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::TrackerKCF::create();
        *returnValue = clone(p);
    });
}
CVAPI(ExceptionStatus) tracking_TrackerKCF_create2(cv::TrackerKCF::Params *parameters, cv::Ptr<cv::TrackerKCF> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::TrackerKCF::create(*parameters);
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerKCF_delete(cv::Ptr<cv::TrackerKCF> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_Ptr_TrackerKCF_get(cv::Ptr<cv::TrackerKCF> *ptr, cv::TrackerKCF **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

// cv::TrackerKCF::FeatureExtractorCallbackFN (void(*)(const Mat, const Rect, Mat&)) has no
// per-instance user-data slot, so only one managed callback can be active process-wide at a time:
// registering a new one (on any TrackerKCF instance) replaces it for all instances. The managed
// callback receives pointers only (image/roi/features), never a by-value struct/object: a C#
// delegate cannot replicate the MSVC by-value-object calling convention that cv::Mat's non-trivial
// copy constructor requires, and even a plain-POD by-value struct (interop::Rect) is risky to pass
// through a reverse P/Invoke thunk (Marshal.GetFunctionPointerForDelegate) - all-pointer-sized
// arguments is the shape already proven safe elsewhere in this codebase (see MouseCallback). The
// trampoline below bridges cv::TrackerKCF's real by-value signature to this all-pointers one.
typedef void (*tracking_TrackerKCF_ManagedFeatureExtractorFN)(const cv::Mat* image, const interop::Rect* roi, cv::Mat* features);

static tracking_TrackerKCF_ManagedFeatureExtractorFN g_trackerKCFManagedFeatureExtractor = nullptr;

static void tracking_TrackerKCF_featureExtractorTrampoline(const cv::Mat image, const cv::Rect roi, cv::Mat& features)
{
    if (g_trackerKCFManagedFeatureExtractor != nullptr)
    {
        const interop::Rect interopRoi = c(roi);
        g_trackerKCFManagedFeatureExtractor(&image, &interopRoi, &features);
    }
}

CVAPI(ExceptionStatus) tracking_TrackerKCF_setFeatureExtractor(
    cv::TrackerKCF* tracker, tracking_TrackerKCF_ManagedFeatureExtractorFN callback, int pcaFunc)
{
    return cvTry([&] {
        g_trackerKCFManagedFeatureExtractor = callback;
        tracker->setFeatureExtractor(tracking_TrackerKCF_featureExtractorTrampoline, pcaFunc != 0);
    });
}

#pragma endregion

#pragma region legacy::Tracker

CVAPI(ExceptionStatus) tracking_legacy_Tracker_init(
    cv::legacy::Tracker* tracker, const cv::Mat* image, const interop::Rect2d boundingBox, int* returnValue)
{
    return cvTry([&] {
        const bool ret = tracker->init(*image, cpp(boundingBox));
        *returnValue = ret ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Tracker_update(
    cv::legacy::Tracker* tracker, const cv::Mat* image, interop::Rect2d* boundingBox, int* returnValue)
{
    return cvTry([&] {
        cv::Rect2d bb = cpp(*boundingBox);
        const bool ret = tracker->update(*image, bb);
        if (ret)
        {
            *boundingBox = c(bb);
        }
        *returnValue = ret ? 1 : 0;
    });
}

#pragma endregion

#pragma region legacy::TrackerMIL

CV_EXTERN_C struct tracker_legacy_TrackerMIL_Params
{
    float samplerInitInRadius;
    int samplerInitMaxNegNum;
    float samplerSearchWinSize;
    float samplerTrackInRadius;
    int samplerTrackMaxPosNum;
    int samplerTrackMaxNegNum;
    int featureSetNumFeatures;
};

CVAPI(ExceptionStatus) tracking_legacy_TrackerMIL_create1(cv::Ptr<cv::legacy::TrackerMIL>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::TrackerMIL::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_TrackerMIL_create2(
    tracker_legacy_TrackerMIL_Params* parameters, cv::Ptr<cv::legacy::TrackerMIL>** returnValue)
{
    return cvTry([&] {
        cv::legacy::TrackerMIL::Params p;
        p.samplerInitInRadius = parameters->samplerInitInRadius;
        p.samplerInitMaxNegNum = parameters->samplerInitMaxNegNum;
        p.samplerSearchWinSize = parameters->samplerSearchWinSize;
        p.samplerTrackInRadius = parameters->samplerTrackInRadius;
        p.samplerTrackMaxPosNum = parameters->samplerTrackMaxPosNum;
        p.samplerTrackMaxNegNum = parameters->samplerTrackMaxNegNum;
        p.featureSetNumFeatures = parameters->featureSetNumFeatures;
        const auto obj = cv::legacy::TrackerMIL::create(p);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerMIL_delete(cv::Ptr<cv::legacy::TrackerMIL>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerMIL_get(cv::Ptr<cv::legacy::TrackerMIL>* ptr, cv::legacy::TrackerMIL** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region legacy::TrackerBoosting

CV_EXTERN_C struct tracker_legacy_TrackerBoosting_Params
{
    int numClassifiers;
    float samplerOverlap;
    float samplerSearchFactor;
    int iterationInit;
    int featureSetNumFeatures;
};

CVAPI(ExceptionStatus) tracking_legacy_TrackerBoosting_create1(cv::Ptr<cv::legacy::TrackerBoosting>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::TrackerBoosting::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_TrackerBoosting_create2(
    tracker_legacy_TrackerBoosting_Params* parameters, cv::Ptr<cv::legacy::TrackerBoosting>** returnValue)
{
    return cvTry([&] {
        cv::legacy::TrackerBoosting::Params p;
        p.numClassifiers = parameters->numClassifiers;
        p.samplerOverlap = parameters->samplerOverlap;
        p.samplerSearchFactor = parameters->samplerSearchFactor;
        p.iterationInit = parameters->iterationInit;
        p.featureSetNumFeatures = parameters->featureSetNumFeatures;
        const auto obj = cv::legacy::TrackerBoosting::create(p);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerBoosting_delete(cv::Ptr<cv::legacy::TrackerBoosting>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerBoosting_get(cv::Ptr<cv::legacy::TrackerBoosting>* ptr, cv::legacy::TrackerBoosting** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region legacy::TrackerMedianFlow

CV_EXTERN_C struct tracker_legacy_TrackerMedianFlow_Params
{
    int pointsInGrid;
    interop::Size winSize;
    int maxLevel;
    interop::TermCriteria termCriteria;
    interop::Size winSizeNCC;
    double maxMedianLengthOfDisplacementDifference;
};

CVAPI(ExceptionStatus) tracking_legacy_TrackerMedianFlow_create1(cv::Ptr<cv::legacy::TrackerMedianFlow>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::TrackerMedianFlow::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_TrackerMedianFlow_create2(
    tracker_legacy_TrackerMedianFlow_Params* parameters, cv::Ptr<cv::legacy::TrackerMedianFlow>** returnValue)
{
    return cvTry([&] {
        cv::legacy::TrackerMedianFlow::Params p;
        p.pointsInGrid = parameters->pointsInGrid;
        p.winSize = cpp(parameters->winSize);
        p.maxLevel = parameters->maxLevel;
        p.termCriteria = cpp(parameters->termCriteria);
        p.winSizeNCC = cpp(parameters->winSizeNCC);
        p.maxMedianLengthOfDisplacementDifference = parameters->maxMedianLengthOfDisplacementDifference;
        const auto obj = cv::legacy::TrackerMedianFlow::create(p);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerMedianFlow_delete(cv::Ptr<cv::legacy::TrackerMedianFlow>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerMedianFlow_get(cv::Ptr<cv::legacy::TrackerMedianFlow>* ptr, cv::legacy::TrackerMedianFlow** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region legacy::TrackerTLD

// legacy::TrackerTLD::Params carries no data members (default constructor only), so there is no
// parameterized create overload to bind - just the default factory.
CVAPI(ExceptionStatus) tracking_legacy_TrackerTLD_create1(cv::Ptr<cv::legacy::TrackerTLD>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::TrackerTLD::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerTLD_delete(cv::Ptr<cv::legacy::TrackerTLD>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerTLD_get(cv::Ptr<cv::legacy::TrackerTLD>* ptr, cv::legacy::TrackerTLD** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region legacy::TrackerKCF

CV_EXTERN_C struct tracker_legacy_TrackerKCF_Params
{
    float detect_thresh;
    float sigma;
    float lambda;
    float interp_factor;
    float output_sigma_factor;
    float pca_learning_rate;
    int resize;
    int split_coeff;
    int wrap_kernel;
    int compress_feature;
    int max_patch_size;
    int compressed_size;
    int desc_pca;
    int desc_npca;
};

CVAPI(ExceptionStatus) tracking_legacy_TrackerKCF_create1(cv::Ptr<cv::legacy::TrackerKCF>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::TrackerKCF::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_TrackerKCF_create2(
    tracker_legacy_TrackerKCF_Params* parameters, cv::Ptr<cv::legacy::TrackerKCF>** returnValue)
{
    return cvTry([&] {
        cv::legacy::TrackerKCF::Params p;
        p.detect_thresh = parameters->detect_thresh;
        p.sigma = parameters->sigma;
        p.lambda = parameters->lambda;
        p.interp_factor = parameters->interp_factor;
        p.output_sigma_factor = parameters->output_sigma_factor;
        p.pca_learning_rate = parameters->pca_learning_rate;
        p.resize = parameters->resize != 0;
        p.split_coeff = parameters->split_coeff != 0;
        p.wrap_kernel = parameters->wrap_kernel != 0;
        p.compress_feature = parameters->compress_feature != 0;
        p.max_patch_size = parameters->max_patch_size;
        p.compressed_size = parameters->compressed_size;
        p.desc_pca = parameters->desc_pca;
        p.desc_npca = parameters->desc_npca;
        const auto obj = cv::legacy::TrackerKCF::create(p);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerKCF_delete(cv::Ptr<cv::legacy::TrackerKCF>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerKCF_get(cv::Ptr<cv::legacy::TrackerKCF>* ptr, cv::legacy::TrackerKCF** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region legacy::TrackerMOSSE

// legacy::TrackerMOSSE::create() takes no arguments (no Params struct exists for this tracker).
CVAPI(ExceptionStatus) tracking_legacy_TrackerMOSSE_create1(cv::Ptr<cv::legacy::TrackerMOSSE>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::TrackerMOSSE::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerMOSSE_delete(cv::Ptr<cv::legacy::TrackerMOSSE>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerMOSSE_get(cv::Ptr<cv::legacy::TrackerMOSSE>* ptr, cv::legacy::TrackerMOSSE** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region legacy::TrackerCSRT

CV_EXTERN_C struct tracker_legacy_TrackerCSRT_Params
{
    int use_hog;
    int use_color_names;
    int use_gray;
    int use_rgb;
    int use_channel_weights;
    int use_segmentation;

    char* window_function;
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

    float psr_threshold;
};

cv::legacy::TrackerCSRT::Params tracking_legacy_TrackerCSRT_Param_ToCpp(const tracker_legacy_TrackerCSRT_Params *params)
{
    cv::legacy::TrackerCSRT::Params p;
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

CVAPI(ExceptionStatus) tracking_legacy_TrackerCSRT_create1(cv::Ptr<cv::legacy::TrackerCSRT>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::TrackerCSRT::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_TrackerCSRT_create2(
    tracker_legacy_TrackerCSRT_Params* parameters, cv::Ptr<cv::legacy::TrackerCSRT>** returnValue)
{
    return cvTry([&] {
        const auto p = tracking_legacy_TrackerCSRT_Param_ToCpp(parameters);
        const auto obj = cv::legacy::TrackerCSRT::create(p);
        *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerCSRT_delete(cv::Ptr<cv::legacy::TrackerCSRT>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_TrackerCSRT_get(cv::Ptr<cv::legacy::TrackerCSRT>* ptr, cv::legacy::TrackerCSRT** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) tracking_legacy_TrackerCSRT_setInitialMask(cv::legacy::TrackerCSRT* tracker, const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        tracker->setInitialMask(InProxy(*mask));
    });
}

#pragma endregion

#pragma region legacy::upgradeTrackingAPI

CVAPI(ExceptionStatus) tracking_legacy_upgradeTrackingAPI(cv::Ptr<cv::legacy::Tracker>* legacyTracker, cv::Ptr<cv::Tracker>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::upgradeTrackingAPI(*legacyTracker);
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_UpgradedTracker_delete(cv::Ptr<cv::Tracker>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_UpgradedTracker_get(cv::Ptr<cv::Tracker>* ptr, cv::Tracker** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region legacy::MultiTracker

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_create(cv::Ptr<cv::legacy::MultiTracker>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::legacy::MultiTracker::create();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_MultiTracker_delete(cv::Ptr<cv::legacy::MultiTracker>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_Ptr_MultiTracker_get(cv::Ptr<cv::legacy::MultiTracker>* ptr, cv::legacy::MultiTracker** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

// newTracker is a cv::Ptr<cv::legacy::TrackerXXX>* (a concrete legacy tracker subclass) reinterpreted
// as cv::Ptr<cv::legacy::Tracker>*: safe because every concrete legacy tracker singly (non-virtually)
// inherits cv::legacy::Tracker as its sole direct base, so the two cv::Ptr<> instantiations share the
// same {object pointer, ref-count block} layout and only differ in static element type.
CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_add(
    cv::legacy::MultiTracker* obj, cv::Ptr<cv::legacy::Tracker>* newTracker,
    const cv::Mat* image, const interop::Rect2d boundingBox, int* returnValue)
{
    return cvTry([&] {
        const bool ret = obj->add(*newTracker, *image, cpp(boundingBox));
        *returnValue = ret ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_update(cv::legacy::MultiTracker* obj, const cv::Mat* image, int* returnValue)
{
    return cvTry([&] {
        const bool ret = obj->update(*image);
        *returnValue = ret ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_getObjects(cv::legacy::MultiTracker* obj, std::vector<cv::Rect2d>* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getObjects();
    });
}

#pragma endregion

#pragma region legacy::MultiTracker_Alt

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_Alt_new(cv::legacy::MultiTracker_Alt** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::legacy::MultiTracker_Alt();
    });
}

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_Alt_delete(cv::legacy::MultiTracker_Alt* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

// See the comment on tracking_legacy_MultiTracker_add for why reinterpreting the concrete tracker's
// cv::Ptr<cv::legacy::TrackerXXX>* as cv::Ptr<cv::legacy::Tracker>* is safe here.
CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_Alt_addTarget(
    cv::legacy::MultiTracker_Alt* obj, const cv::Mat* image, const interop::Rect2d boundingBox,
    cv::Ptr<cv::legacy::Tracker>* trackerAlgorithm, int* returnValue)
{
    return cvTry([&] {
        const bool ret = obj->addTarget(*image, cpp(boundingBox), *trackerAlgorithm);
        *returnValue = ret ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_Alt_update(cv::legacy::MultiTracker_Alt* obj, const cv::Mat* image, int* returnValue)
{
    return cvTry([&] {
        const bool ret = obj->update(*image);
        *returnValue = ret ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_Alt_targetNum(cv::legacy::MultiTracker_Alt* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->targetNum;
    });
}

CVAPI(ExceptionStatus) tracking_legacy_MultiTracker_Alt_boundingBoxes(cv::legacy::MultiTracker_Alt* obj, std::vector<cv::Rect2d>* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->boundingBoxes;
    });
}

#pragma endregion

#pragma region legacy::MultiTrackerTLD

CVAPI(ExceptionStatus) tracking_legacy_MultiTrackerTLD_new(cv::legacy::MultiTrackerTLD** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::legacy::MultiTrackerTLD();
    });
}

// No MultiTrackerTLD-specific delete: MultiTrackerTLD adds no data members over MultiTracker_Alt and
// MultiTracker_Alt has no virtual destructor, so the two types are identically sized/laid out and the
// managed side disposes a MultiTrackerTLD through tracking_legacy_MultiTracker_Alt_delete instead.

CVAPI(ExceptionStatus) tracking_legacy_MultiTrackerTLD_updateOpt(cv::legacy::MultiTrackerTLD* obj, const cv::Mat* image, int* returnValue)
{
    return cvTry([&] {
        const bool ret = obj->update_opt(*image);
        *returnValue = ret ? 1 : 0;
    });
}

#pragma endregion

#endif // NO_CONTRIB
