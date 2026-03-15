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

# Disable unused 3rd-party integrations
set(WITH_GSTREAMER OFF CACHE BOOL "" FORCE)
set(WITH_ADE       OFF CACHE BOOL "" FORCE)

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
  set(ENABLE_BUILD_HARDENING ON CACHE BOOL "" FORCE)
endif()

