# CMake initial cache for OpenCV slim build (Ubuntu only).
# Used via: cmake -C cmake/opencv_build_options_slim.cmake -S opencv ...
# Platform-specific settings (CMAKE_INSTALL_PREFIX) are passed directly by the workflow.

set(CMAKE_BUILD_TYPE  Release CACHE STRING "" FORCE)
set(BUILD_SHARED_LIBS OFF     CACHE BOOL   "" FORCE)
set(ENABLE_CXX11      ON      CACHE BOOL   "" FORCE)

# Restrict to a minimal module subset.
# OpenCV 5 module renames vs 4.x:
#   - calib3d was split into geometry (2D/3D primitives: convexHull, solvePnP,
#     findHomography, ...), calib (camera calibration), stereo (StereoBM/SGBM)
#     and ptcloud (TSDF volume integration, odometry). ptcloud has no heavy
#     external dependency (deps are the core/imgproc/3d family already listed),
#     so it is kept in slim to match the family and the wrapped Volume/Odometry API.
#   - features2d was renamed to features
#   - barcode was merged into objdetect (no standalone module anymore)
#   - CascadeClassifier / HOGDescriptor / groupRectangles moved to the contrib
#     xobjdetect module (lightweight: depends only on core/imgproc/imgcodecs/
#     features), kept in the slim profile. Pulled from OPENCV_EXTRA_MODULES_PATH.
#   - BRISK / KAZE / AKAZE / AGAST / FREAK / BRIEF / DAISY / ... moved to the
#     contrib xfeatures2d module. Its required deps (core/imgproc/features/
#     geometry) are all in this list and it pulls no heavy external dependency,
#     so it is kept in the slim profile too.
# Additional lightweight contrib kept in slim (deps all in this list, no heavy
# external dependency): ximgproc, xphoto, bgsegm, img_hash.
# stitching is dropped from slim (large, niche); the extern is built with
# NO_STITCHING=ON to match.
# Dependencies of whitelisted modules are added automatically.
set(BUILD_LIST "core,imgproc,imgcodecs,geometry,calib,stereo,ptcloud,features,flann,objdetect,photo,ml,video,xobjdetect,xfeatures2d,ximgproc,xphoto,bgsegm,img_hash" CACHE STRING "" FORCE)

# Disable DNN and Protobuf (not needed in slim profile)
set(BUILD_opencv_dnn  OFF CACHE BOOL "" FORCE)
set(BUILD_PROTOBUF    OFF CACHE BOOL "" FORCE)
set(WITH_PROTOBUF     OFF CACHE BOOL "" FORCE)

set(BUILD_EXAMPLES   OFF CACHE BOOL "" FORCE)
set(BUILD_DOCS       OFF CACHE BOOL "" FORCE)
set(BUILD_PERF_TESTS OFF CACHE BOOL "" FORCE)
set(BUILD_TESTS      OFF CACHE BOOL "" FORCE)
set(BUILD_JAVA       OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_apps OFF CACHE BOOL "" FORCE)

set(WITH_GSTREAMER OFF CACHE BOOL "" FORCE)
set(WITH_FFMPEG    OFF CACHE BOOL "" FORCE)
set(WITH_GTK       OFF CACHE BOOL "" FORCE)
set(WITH_ADE       OFF CACHE BOOL "" FORCE)