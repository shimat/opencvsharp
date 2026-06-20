#pragma once

//#define ENABLED_CONTRIB
//#undef ENABLED_CONTRIB

#ifndef CV_EXPORTS
# if (defined _WIN32 || defined WINCE || defined __CYGWIN__)
#   define CV_EXPORTS __declspec(dllexport)
# elif defined __GNUC__ && __GNUC__ >= 4 && defined(__APPLE__)
#   define CV_EXPORTS __attribute__ ((visibility ("default")))
# endif
#endif

#ifndef CV_EXPORTS
# define CV_EXPORTS
#endif

#ifdef _MSC_VER
// ReSharper disable once IdentifierTypo
#define NOMINMAX
// ReSharper disable once CppInconsistentNaming
#define _CRT_SECURE_NO_WARNINGS
#pragma warning(push)
#pragma warning(disable: 4244)
#pragma warning(disable: 4251)
#pragma warning(disable: 4819)
#pragma warning(disable: 4996)
#pragma warning(disable: 6294)
#include <codeanalysis/warnings.h>
#pragma warning(disable: ALL_CODE_ANALYSIS_WARNINGS)
#endif

#define OPENCV_TRAITS_ENABLE_DEPRECATED

#include <opencv2/opencv.hpp>

// OpenCV 5 split calib3d into the calib / 3d / stereo modules, and opencv.hpp
// now pulls the new headers (opencv2/3d.hpp, objdetect.hpp). The legacy
// opencv2/calib3d.hpp still re-declares the same enums (LMEDS, SolvePnPMethod,
// CALIB_CB_*, ...) under its own include guard, so it clashes when something
// drags it into the same translation unit (e.g. opencv2/ximgproc/disparity_filter.hpp).
// OpenCvSharpExtern uses the new API via opencv.hpp, so neutralize the legacy
// umbrella by pre-defining its include guard.
#define OPENCV_CALIB3D_HPP

// OpenCV 5 moved the geometry primitives into the new "geometry" module:
//  - 2D (opencv2/geometry/2d.hpp): convexHull, minAreaRect, fitEllipse, boxPoints,
//    minEnclosingCircle/Triangle, Subdiv2D, ...
//  - 3D (opencv2/geometry/3d.hpp): solvePnP, findHomography, triangulatePoints, ...
// opencv2/opencv.hpp does not pull opencv2/geometry.hpp (and the legacy calib3d
// umbrella that used to is neutralized above), so include it explicitly.
#include <opencv2/geometry.hpp>

// OpenCV 5 moved CascadeClassifier / HOGDescriptor / groupRectangles out of the
// main objdetect module into the contrib xobjdetect module (still in the cv::
// namespace). It is lightweight (depends only on core/imgproc/imgcodecs/features),
// so OpenCvSharpExtern keeps it available in every profile (including slim) and is
// not aggregated by opencv2/opencv.hpp, so include it explicitly. These APIs are
// not exposed under WinRT, mirroring the objdetect_*.h export guards.
#ifndef _WINRT_DLL
#include <opencv2/xobjdetect.hpp>
#endif

// MP! Added: To correctly support imShow under WinRT.
#ifdef _WINRT_DLL
#include <opencv2/highgui/highgui_winrt.hpp>
#endif
#include <opencv2/core/utils/logger.hpp>
// NOTE: the legacy C API (imgproc_c.h / highgui_c.h) was removed in OpenCV 5
// and is not used by OpenCvSharpExtern, so the includes have been dropped.

#ifndef NO_VIDEO
#include <opencv2/video.hpp>
#endif

#ifndef NO_STITCHING
#include <opencv2/stitching.hpp>
#endif

#ifndef NO_ML
#include <opencv2/ml.hpp>
#endif

#ifndef NO_CONTRIB
#include <opencv2/shape.hpp>
#ifndef _WINRT_DLL
#include <opencv2/superres.hpp>
#include <opencv2/superres/optical_flow.hpp>
#endif 
// opencv_contrib
// NOTE: OpenCV 5 merged the aruco module into the main objdetect module
// (opencv2/objdetect/aruco_detector.hpp, charuco_detector.hpp, ...), which is
// already pulled in by opencv2/opencv.hpp. The legacy contrib umbrella headers
// opencv2/aruco.hpp / opencv2/aruco/charuco.hpp were removed.
#include <opencv2/bgsegm.hpp>
#include <opencv2/img_hash.hpp>
#include <opencv2/line_descriptor.hpp>
#include <opencv2/optflow.hpp>
#include <opencv2/quality.hpp>
#include <opencv2/tracking.hpp>
#include <opencv2/xfeatures2d.hpp>
#include <opencv2/ximgproc.hpp>
#include <opencv2/saliency.hpp>
#include <opencv2/xphoto.hpp>
#ifndef _WINRT_DLL
#include <opencv2/wechat_qrcode.hpp>
#include <opencv2/dnn.hpp>
#include <opencv2/dnn_superres.hpp>
#include <opencv2/face.hpp>
#include <opencv2/text.hpp>
#endif
#endif // NO_CONTRIB

#include <vector>
#include <algorithm>
#include <iterator>
#include <sstream>
#include <iterator>
#include <fstream>
#include <iostream>
#include <cstdio>
#include <cstring>
#include <cstdlib>
#ifdef _MSC_VER
#pragma warning(pop)
#endif

// Additional types
#include "my_types.h"

// Additional functions
#include "my_functions.h"
