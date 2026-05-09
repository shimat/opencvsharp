# CMake initial cache for OpenCV full build.
# Used via: cmake -C cmake/opencv_build_options.cmake -S opencv ...
# Platform-specific settings (CMAKE_INSTALL_PREFIX, OPENCV_EXTRA_MODULES_PATH,
# CMAKE_PREFIX_PATH, generator) are passed directly by each build script/workflow.

set(CMAKE_BUILD_TYPE           Release   CACHE STRING "" FORCE)
set(BUILD_SHARED_LIBS          ON        CACHE BOOL "" FORCE)
set(BUILD_opencv_world         ON        CACHE BOOL "" FORCE)

# --- PATHS (Adjusted based on your GUI requirements) ---
set(OPENCV_EXTRA_MODULES_PATH "${CMAKE_CURRENT_LIST_DIR}/../opencv_contrib/modules" CACHE PATH "" FORCE)
set(CUDNN_INCLUDE_DIR      "C:/Program Files/NVIDIA/CUDNN/v9.20/include/12.9" CACHE PATH "" FORCE)
set(CUDNN_LIBRARY          "C:/Program Files/NVIDIA/CUDNN/v9.20/lib/12.9/x64/cudnn.lib" CACHE FILEPATH "" FORCE)

# --- CUDA SETTINGS ---
set(WITH_CUDA                  ON        CACHE BOOL "" FORCE)
set(WITH_CUDNN                 ON        CACHE BOOL "" FORCE)
set(WITH_CUBLAS                ON        CACHE BOOL "" FORCE)
set(WITH_CUFFT                 ON        CACHE BOOL "" FORCE)
set(OPENCV_DNN_CUDA            ON        CACHE BOOL "" FORCE)
set(CUDA_FAST_MATH             ON        CACHE BOOL "" FORCE)
set(ENABLE_FAST_MATH           ON        CACHE BOOL "" FORCE)

# Architecture settings (Specific to your hardware)
set(CUDA_ARCH_BIN          "8.6"   CACHE STRING "" FORCE)
set(CUDA_ARCH_PTX          "8.6"   CACHE STRING "" FORCE)

# Disable build outputs we don't need
set(BUILD_EXAMPLES         OFF CACHE BOOL "" FORCE)
set(BUILD_DOCS             OFF CACHE BOOL "" FORCE)
set(BUILD_PERF_TESTS       OFF CACHE BOOL "" FORCE)
set(BUILD_TESTS            OFF CACHE BOOL "" FORCE)
set(BUILD_JAVA             OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_apps      OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_js        OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_python_bindings_generator OFF CACHE BOOL "" FORCE)

# Video/FFMPEG Settings
set(WITH_NVCUVID           ON      CACHE BOOL "" FORCE)
set(WITH_NVCUVENC          ON      CACHE BOOL "" FORCE)
set(VIDEO_CODEC_SDK_DIR    "D:/Video_Codec_SDK_13.0.37" CACHE PATH "" FORCE)
set(NVENC_LIBRARY          "D:/Video_Codec_SDK_13.0.37/Lib/win/x64/nvencodeapi.lib" CACHE FILEPATH "" FORCE) 

# Compiler flags for newer Visual Studio versions
set(CUDA_NVCC_FLAGS        "-allow-unsupported-compiler" CACHE STRING "" FORCE)

# --- COMPILER & OPTIMIZATION SETTINGS ---
set(OPENCV_MSVC_PARALLEL       ON        CACHE STRING "" FORCE)
set(CPU_BASELINE               "SSE3"    CACHE STRING "" FORCE)
set(CPU_DISPATCH               "SSE4_1;SSE4_2;AVX;FP16;AVX2;AVX512_SKX" CACHE STRING "" FORCE)

# Disable heavy/unused contrib and core modules
set(BUILD_opencv_apps                      OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_java_bindings_generator   OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_python_bindings_generator OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_python_tests              OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_ts                        OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_js                        OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_js_bindings_generator     OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_bioinspired               OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_ccalib                    OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_datasets                  OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_dnn_objdetect             OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_dpm                       OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_fuzzy                     OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_gapi                      OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_intensity_transform       OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_mcc                       OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_objc_bindings_generator   OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_rapid                     OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_reg                       OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_stereo                    OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_structured_light          OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_surface_matching          OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_videostab                 OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_wechat_qrcode             ON  CACHE BOOL "" FORCE)

# Require Tesseract OCR (provided via vcpkg on Windows/manylinux, libtesseract-dev on Linux ARM)
set(WITH_TESSERACT ON  CACHE BOOL "" FORCE)

# --- OTHER DEPENDENCIES ---
set(WITH_FFMPEG                ON        CACHE BOOL "" FORCE)
set(WITH_GSTREAMER             ON        CACHE BOOL "" FORCE)
set(WITH_MSMF                  ON        CACHE BOOL "" FORCE)
set(WITH_VTK                   ON        CACHE BOOL "" FORCE)
set(WITH_OPENCL                ON        CACHE BOOL "" FORCE)
set(WITH_OPENMP                OFF       CACHE BOOL "" FORCE) 
set(WITH_DIRECTX               OFF       CACHE BOOL "" FORCE) 
set(WITH_DIRECTML              OFF       CACHE BOOL "" FORCE) 

# On Windows, disable bundled 3rd-party lib builds so OpenCV uses the vcpkg-provided
# versions instead. This ensures OpenCVModules.cmake references paths in
# vcpkg_installed/ (which exist) rather than uninstalled paths in opencv_artifacts/.
# These packages are guaranteed to be present via vcpkg.json dependencies.
if(WIN32)
  set(BUILD_ZLIB  OFF CACHE BOOL "" FORCE)
  set(BUILD_TIFF  OFF CACHE BOOL "" FORCE)
  set(BUILD_JPEG  OFF CACHE BOOL "" FORCE)
  set(BUILD_PNG   OFF CACHE BOOL "" FORCE)
  set(BUILD_WEBP  OFF CACHE BOOL "" FORCE)

  # Enable security hardening flags (/GS, /sdl, /guard:cf, /DYNAMICBASE, etc.)
  # to satisfy security audit requirements (issue #1841).
  # Note: opencv_videoio_ffmpeg*.dll is a pre-built binary downloaded from
  # https://github.com/opencv/opencv_3rdparty and is not affected by this flag.
  # Its security hardening status depends entirely on the OpenCV project's build pipeline.
  set(ENABLE_BUILD_HARDENING ON CACHE BOOL "" FORCE)
endif()

