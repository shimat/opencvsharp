# CMake initial cache for OpenCV slim build targeting YuNet face detection.
# Modules: core, imgproc, imgcodecs, calib3d, features2d, flann, dnn, ml, objdetect
# Used via: cmake -C cmake/opencv_build_options_yunet.cmake -S opencv ...
# Platform-specific settings (CMAKE_INSTALL_PREFIX, generator, arch) passed by workflow.

set(CMAKE_BUILD_TYPE  Release CACHE STRING "" FORCE)
set(BUILD_SHARED_LIBS OFF     CACHE BOOL   "" FORCE)
set(ENABLE_CXX11      ON      CACHE BOOL   "" FORCE)

# Module subset — includes calib3d/features2d/flann because objdetect (QR) depends on them.
# dnn is required for YuNet .onnx inference. ml included to avoid objdetect link issues.
set(BUILD_LIST "core,imgproc,imgcodecs,calib3d,features2d,flann,dnn,ml,objdetect" CACHE STRING "" FORCE)

# Enable DNN + bundled Protobuf (required for .onnx model loading by FaceDetectorYN)
set(BUILD_opencv_dnn ON  CACHE BOOL "" FORCE)
set(WITH_PROTOBUF    ON  CACHE BOOL "" FORCE)
set(BUILD_PROTOBUF   ON  CACHE BOOL "" FORCE)

# Disable unused build outputs
set(BUILD_EXAMPLES   OFF CACHE BOOL "" FORCE)
set(BUILD_DOCS       OFF CACHE BOOL "" FORCE)
set(BUILD_PERF_TESTS OFF CACHE BOOL "" FORCE)
set(BUILD_TESTS      OFF CACHE BOOL "" FORCE)
set(BUILD_JAVA       OFF CACHE BOOL "" FORCE)
set(BUILD_opencv_apps OFF CACHE BOOL "" FORCE)

# Disable unused 3rd-party integrations
set(WITH_FFMPEG    OFF CACHE BOOL "" FORCE)
set(WITH_GSTREAMER OFF CACHE BOOL "" FORCE)
set(WITH_GTK       OFF CACHE BOOL "" FORCE)
set(WITH_ADE       OFF CACHE BOOL "" FORCE)
set(WITH_TESSERACT OFF CACHE BOOL "" FORCE)

# PNG-only image codec: app converts all input to PNG bytes before calling OpenCV.
# WITH_* = OFF prevents CMake from finding system libs (avoids e.g. Mono tiff.h conflict on macOS).
set(BUILD_ZLIB ON  CACHE BOOL "" FORCE)
set(BUILD_PNG  ON  CACHE BOOL "" FORCE)
set(WITH_JPEG  OFF CACHE BOOL "" FORCE)
set(BUILD_JPEG OFF CACHE BOOL "" FORCE)
set(WITH_TIFF  OFF CACHE BOOL "" FORCE)
set(BUILD_TIFF OFF CACHE BOOL "" FORCE)
set(WITH_WEBP  OFF CACHE BOOL "" FORCE)
set(BUILD_WEBP OFF CACHE BOOL "" FORCE)
set(WITH_OPENJPEG  OFF CACHE BOOL "" FORCE)
set(WITH_OPENEXR   OFF CACHE BOOL "" FORCE)
