#ifndef MOCK_CUDA_RUNTIME_H
#define MOCK_CUDA_RUNTIME_H

// This file "tricks" the OpenCV accessor header into thinking
// the NVIDIA CUDA Toolkit is installed.

typedef struct CUstream_st *cudaStream_t;
typedef struct CUevent_st *cudaEvent_t;

#endif
