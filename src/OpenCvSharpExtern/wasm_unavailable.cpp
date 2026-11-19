#ifdef __EMSCRIPTEN__

#include "include_opencv.h"

// The Wasm linker needs entry points for the managed imports even when the
// corresponding OpenCV modules are absent. Module-specific native types are
// opaque handles at the C ABI. Preserve the full signature of each import,
// including by-value structs and scalar types.
#define WASM_UNAVAILABLE(name, ...) \
    CVAPI(ExceptionStatus) name(__VA_ARGS__) \
    { \
        return reportNativeError(cv::Error::StsNotImplemented, #name, \
            "The OpenCV module for this function is unavailable in this Wasm build.", __FILE__, __LINE__); \
    }

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_BIOINSPIRED)
WASM_UNAVAILABLE(bioinspired_Ptr_Retina_delete, void*)
WASM_UNAVAILABLE(bioinspired_Ptr_Retina_get, void*, void**)
WASM_UNAVAILABLE(bioinspired_Retina_create, int, int, void**)
WASM_UNAVAILABLE(bioinspired_Retina_run, void*, const interop::InputArrayProxy*)
WASM_UNAVAILABLE(bioinspired_Retina_getParvo, void*, const interop::OutputArrayProxy*)
WASM_UNAVAILABLE(bioinspired_Retina_getMagno, void*, const interop::OutputArrayProxy*)
WASM_UNAVAILABLE(bioinspired_Retina_clearBuffers, void*)
WASM_UNAVAILABLE(bioinspired_Ptr_TransientAreasSegmentation_delete, void*)
WASM_UNAVAILABLE(bioinspired_Ptr_TransientAreasSegmentation_get, void*, void**)
WASM_UNAVAILABLE(bioinspired_TransientAreasSegmentation_create, int, int, void**)
WASM_UNAVAILABLE(bioinspired_TransientAreasSegmentation_run, void*, const interop::InputArrayProxy*, int)
WASM_UNAVAILABLE(bioinspired_TransientAreasSegmentation_getPicture, void*, const interop::OutputArrayProxy*)
WASM_UNAVAILABLE(bioinspired_TransientAreasSegmentation_clearBuffers, void*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_CCALIB)
WASM_UNAVAILABLE(ccalib_omnidir_projectPoints,
    const interop::InputArrayProxy*, const interop::OutputArrayProxy*, const interop::InputArrayProxy*,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, double,
    const interop::InputArrayProxy*, const interop::OutputArrayProxy*)
WASM_UNAVAILABLE(ccalib_omnidir_undistortPoints,
    const interop::InputArrayProxy*, const interop::OutputArrayProxy*, const interop::InputArrayProxy*,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, const interop::InputArrayProxy*)
WASM_UNAVAILABLE(ccalib_omnidir_initUndistortRectifyMap,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, const interop::InputArrayProxy*,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, interop::Size, int,
    const interop::OutputArrayProxy*, const interop::OutputArrayProxy*, int)
WASM_UNAVAILABLE(ccalib_omnidir_undistortImage,
    const interop::InputArrayProxy*, const interop::OutputArrayProxy*, const interop::InputArrayProxy*,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, int, const interop::InputArrayProxy*,
    interop::Size, const interop::InputArrayProxy*)
WASM_UNAVAILABLE(ccalib_omnidir_calibrate,
    std::vector<cv::Mat>*, std::vector<cv::Mat>*, interop::Size, const interop::InputOutputArrayProxy*,
    const interop::InputOutputArrayProxy*, const interop::InputOutputArrayProxy*, std::vector<cv::Mat>*,
    std::vector<cv::Mat>*, int, interop::TermCriteria, const interop::OutputArrayProxy*, double*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_DNN_OBJDETECT)
WASM_UNAVAILABLE(dnn_objdetect_inferBboxes, const cv::Mat*, const cv::Mat*, const cv::Mat*, double, void**)
WASM_UNAVAILABLE(dnn_objdetect_detections_count, const void*, int*)
WASM_UNAVAILABLE(dnn_objdetect_detections_get,
    const void*, int, int*, int*, int*, int*, int*, const char**, double*)
WASM_UNAVAILABLE(dnn_objdetect_detections_delete, void*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_DPM)
WASM_UNAVAILABLE(dpm_DPMDetector_create,
    const std::vector<std::string>*, const std::vector<std::string>*, void**)
WASM_UNAVAILABLE(dpm_Ptr_DPMDetector_get, void*, void**)
WASM_UNAVAILABLE(dpm_Ptr_DPMDetector_delete, void*)
WASM_UNAVAILABLE(dpm_DPMDetector_isEmpty, void*, int*)
WASM_UNAVAILABLE(dpm_DPMDetector_getClassCount, void*, int*)
WASM_UNAVAILABLE(dpm_DPMDetector_getClassNames, void*, std::vector<std::string>*)
WASM_UNAVAILABLE(dpm_DPMDetector_detect, void*, const cv::Mat*, void**)
WASM_UNAVAILABLE(dpm_detections_count, const void*, int*)
WASM_UNAVAILABLE(dpm_detections_get, const void*, int, interop::Rect*, float*, int*)
WASM_UNAVAILABLE(dpm_detections_delete, void*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_FUZZY)
WASM_UNAVAILABLE(fuzzy_createKernel, int, int, const interop::OutputArrayProxy*, int)
WASM_UNAVAILABLE(fuzzy_createKernelFromFunctions,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, const interop::OutputArrayProxy*,
    int)
WASM_UNAVAILABLE(fuzzy_filter,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, const interop::OutputArrayProxy*)
WASM_UNAVAILABLE(fuzzy_inpaint,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, const interop::OutputArrayProxy*,
    int, int, int)
WASM_UNAVAILABLE(fuzzy_ft02dProcess,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, const interop::OutputArrayProxy*,
    const interop::InputArrayProxy*)
WASM_UNAVAILABLE(fuzzy_ft12dProcess,
    const interop::InputArrayProxy*, const interop::InputArrayProxy*, const interop::OutputArrayProxy*,
    const interop::InputArrayProxy*)
WASM_UNAVAILABLE(fuzzy_ft02dFastLinearProcess,
    const interop::InputArrayProxy*, int, const interop::OutputArrayProxy*)
WASM_UNAVAILABLE(fuzzy_ft02dFastLinearProcessFloat,
    const interop::InputArrayProxy*, int, const interop::OutputArrayProxy*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_INTENSITY_TRANSFORM)
WASM_UNAVAILABLE(intensity_transform_logTransform, const cv::Mat*, cv::Mat*)
WASM_UNAVAILABLE(intensity_transform_gammaCorrection, const cv::Mat*, cv::Mat*, float)
WASM_UNAVAILABLE(intensity_transform_autoscaling, const cv::Mat*, cv::Mat*)
WASM_UNAVAILABLE(intensity_transform_contrastStretching, const cv::Mat*, cv::Mat*, int, int, int, int)
WASM_UNAVAILABLE(intensity_transform_bimef1,
    const interop::InputArrayProxy*, const interop::OutputArrayProxy*, float, float, float)
WASM_UNAVAILABLE(intensity_transform_bimef2,
    const interop::InputArrayProxy*, const interop::OutputArrayProxy*, float, float, float, float)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_RAPID)
WASM_UNAVAILABLE(rapid_track,
    const cv::Mat*, int, int, const cv::Mat*, const cv::Mat*, const cv::Mat*, cv::Mat*, cv::Mat*, float*,
    double*)
WASM_UNAVAILABLE(rapid_drawWireframe, cv::Mat*, const cv::Mat*, const cv::Mat*, interop::Scalar, int, int)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_REG)
WASM_UNAVAILABLE(reg_estimateTransform, const cv::Mat*, const cv::Mat*, int, int, int, cv::Mat*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_STRUCTURED_LIGHT)
WASM_UNAVAILABLE(structured_light_SinusoidalPattern_create,
    int, int, int, float, int, int, int, int, void**)
WASM_UNAVAILABLE(structured_light_Ptr_SinusoidalPattern_delete, void*)
WASM_UNAVAILABLE(structured_light_Ptr_SinusoidalPattern_get, void*, void**)
WASM_UNAVAILABLE(structured_light_SinusoidalPattern_computePhaseMap,
    void*, std::vector<cv::Mat>*, const interop::OutputArrayProxy*, const interop::OutputArrayProxy*,
    const interop::InputArrayProxy*)
WASM_UNAVAILABLE(structured_light_SinusoidalPattern_unwrapPhaseMap,
    void*, const interop::InputArrayProxy*, const interop::OutputArrayProxy*, interop::Size,
    const interop::InputArrayProxy*)
WASM_UNAVAILABLE(structured_light_SinusoidalPattern_computeDataModulationTerm,
    void*, std::vector<cv::Mat>*, const interop::OutputArrayProxy*, const interop::InputArrayProxy*)
WASM_UNAVAILABLE(structured_light_Ptr_GrayCodePattern_delete, void*)
WASM_UNAVAILABLE(structured_light_Ptr_GrayCodePattern_get, void*, void**)
WASM_UNAVAILABLE(structured_light_GrayCodePattern_create, int, int, void**)
WASM_UNAVAILABLE(structured_light_StructuredLightPattern_generate, void*, std::vector<cv::Mat>*, int*)
WASM_UNAVAILABLE(structured_light_StructuredLightPattern_decode,
    void*, cv::Mat***, const int*, int, std::vector<cv::Mat>*, std::vector<cv::Mat>*,
    const interop::OutputArrayProxy*, int*)
WASM_UNAVAILABLE(structured_light_GrayCodePattern_getNumberOfPatternImages, void*, int*)
WASM_UNAVAILABLE(structured_light_GrayCodePattern_setWhiteThreshold, void*, int)
WASM_UNAVAILABLE(structured_light_GrayCodePattern_setBlackThreshold, void*, int)
WASM_UNAVAILABLE(structured_light_GrayCodePattern_getImagesForShadowMasks,
    void*, const interop::OutputArrayProxy*, const interop::OutputArrayProxy*)
WASM_UNAVAILABLE(structured_light_GrayCodePattern_getProjectorPixel,
    void*, std::vector<cv::Mat>*, int, int, interop::Point*, int*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_SURFACE_MATCHING)
WASM_UNAVAILABLE(surface_matching_ICP_new1, void**)
WASM_UNAVAILABLE(surface_matching_ICP_new2, int, float, float, int, void**)
WASM_UNAVAILABLE(surface_matching_ICP_delete, void*)
WASM_UNAVAILABLE(surface_matching_ICP_registerModelToScene,
    void*, const interop::InputArrayProxy*, const interop::InputArrayProxy*, double*, cv::Mat**, int*)
WASM_UNAVAILABLE(surface_matching_computeNormalsPC3d,
    const interop::InputArrayProxy*, const interop::OutputArrayProxy*, int, int, interop::Vec3f, int*)
#endif

#if defined(NO_CONTRIB) || !defined(HAVE_OPENCV_VIDEOSTAB)
WASM_UNAVAILABLE(videostab_stabilize, cv::Mat**, int, int, float, int, cv::Mat**)
#endif

#undef WASM_UNAVAILABLE

#endif // __EMSCRIPTEN__
