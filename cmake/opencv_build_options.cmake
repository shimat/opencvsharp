# CMake initial cache for OpenCV full build.
# Used via: cmake -C cmake/opencv_build_options.cmake -S opencv ...
# Platform-specific settings (CMAKE_INSTALL_PREFIX, OPENCV_EXTRA_MODULES_PATH,
# CMAKE_PREFIX_PATH, generator) are passed directly by each build script/workflow.

set(CMAKE_BUILD_TYPE       Release CACHE STRING "" FORCE)
set(BUILD_SHARED_LIBS      OFF     CACHE BOOL   "" FORCE)
set(ENABLE_CXX11           ON      CACHE BOOL   "" FORCE)
set(OPENCV_ENABLE_NONFREE  ON      CACHE BOOL   "" FORCE)

# Disable build outputs we don't need
set(BUILD_EXAMPLES  OFF CACHE BOOL "" FORCE)
set(BUILD_DOCS      OFF CACHE BOOL "" FORCE)
set(BUILD_PERF_TESTS OFF CACHE BOOL "" FORCE)
set(BUILD_TESTS     OFF CACHE BOOL "" FORCE)
set(BUILD_JAVA      OFF CACHE BOOL "" FORCE)

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
set(BUILD_opencv_gapi                      ON  CACHE BOOL "" FORCE)
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

# Disable unused 3rd-party integrations
set(WITH_GSTREAMER OFF CACHE BOOL "" FORCE)
set(WITH_ADE       OFF CACHE BOOL "" FORCE)

# Use a flat install layout (avoids x64/vc17/ subdirectories; libs go to staticlib/)
set(OpenCV_INSTALL_BINARIES_PREFIX "" CACHE STRING "" FORCE)