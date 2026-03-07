# CMake initial cache for OpenCV slim build (Ubuntu only).
# Used via: cmake -C cmake/opencv_build_options_slim.cmake -S opencv ...
# Platform-specific settings (CMAKE_INSTALL_PREFIX) are passed directly by the workflow.

set(CMAKE_BUILD_TYPE  Release CACHE STRING "" FORCE)
set(BUILD_SHARED_LIBS OFF     CACHE BOOL   "" FORCE)
set(ENABLE_CXX11      ON      CACHE BOOL   "" FORCE)

# Restrict to a minimal module subset
set(BUILD_LIST "core,imgproc,imgcodecs,calib3d,features2d,flann,objdetect,photo" CACHE STRING "" FORCE)

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