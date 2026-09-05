# CMake initial cache for macOS OpenCV builds.
# Keep macOS-specific options here so the workflow can include every effective
# build option in the OpenCV artifact cache key.

include("${CMAKE_CURRENT_LIST_DIR}/opencv_build_options.cmake")

set(CMAKE_OSX_DEPLOYMENT_TARGET 11.0 CACHE STRING "" FORCE)

# Image codecs are provided by vcpkg on macOS.
set(BUILD_JPEG OFF CACHE BOOL "" FORCE)
set(BUILD_PNG  OFF CACHE BOOL "" FORCE)
set(BUILD_TIFF OFF CACHE BOOL "" FORCE)
set(BUILD_WEBP OFF CACHE BOOL "" FORCE)
set(BUILD_ZLIB ON  CACHE BOOL "" FORCE)

set(WITH_TBB      OFF CACHE BOOL "" FORCE)
set(WITH_OPENEXR  OFF CACHE BOOL "" FORCE)
set(WITH_JASPER   OFF CACHE BOOL "" FORCE)
set(WITH_OPENGL   OFF CACHE BOOL "" FORCE)
set(WITH_VA       OFF CACHE BOOL "" FORCE)
set(WITH_VA_INTEL OFF CACHE BOOL "" FORCE)

set(OPENCV_FFMPEG_SKIP_BUILD_CHECK ON CACHE BOOL "" FORCE)

# Disable the ASM language so OpenCV 5's vendored MLAS turns off and DNN falls
# back to its built-in SGEMM. The MLAS FP16/GQA path references
# MlasHGemmSupported(), which OpenCV 5.0.0 declares and calls but never defines.
set(CMAKE_ASM_COMPILER "" CACHE FILEPATH "" FORCE)
