# A failed download can leave OpenCV configured without the requested built-in CJK font.
if(WITH_UNIFONT AND (NOT HAVE_HARFBUZZ OR NOT HAVE_UNIFONT))
  message(FATAL_ERROR "The requested OpenCV built-in 'uni' font is unavailable. Check HarfBuzz support and the OpenCV download log.")
endif()

# CUDA is unsupported by OpenCvSharp. GCC diagnoses OpenCV's CPU-only GpuMat
# stub even though no managed GpuMat API exposes it. Keep other files checked.
if(CMAKE_CXX_COMPILER_ID STREQUAL "GNU" AND NOT HAVE_CUDA AND TARGET opencv_core)
  get_source_file_property(gpumat_compile_options
    "${OpenCV_SOURCE_DIR}/modules/core/src/cuda_gpu_mat.cpp"
    TARGET_DIRECTORY opencv_core COMPILE_OPTIONS)
  if(NOT gpumat_compile_options)
    set(gpumat_compile_options "")
  endif()
  list(APPEND gpumat_compile_options -Wno-nonnull)
  set_source_files_properties("${OpenCV_SOURCE_DIR}/modules/core/src/cuda_gpu_mat.cpp"
    TARGET_DIRECTORY opencv_core PROPERTIES COMPILE_OPTIONS "${gpumat_compile_options}")
  unset(gpumat_compile_options)
endif()
