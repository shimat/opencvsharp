// ReSharper disable CppUnusedIncludeDirective

#ifdef ENABLED_CUDA
#include "cuda.h"
// core stuff
#include "cuda_Core.h"



// bgsegm
#include "cuda_Bgsegm_mog.h"
#include "cuda_Bgsegm_mog2.h"
#include "cuda_Stream.h"
#include "cuda_StreamAccessor.h"

#include "cuda_GpuMat.h"
// arithm
#include "cuda_Convolution.h"
#include "cuda_DFT.h"
#include "cuda_LookUpTable.h"

// feature2d
#include "cuda_DescriptorMatcher.h"
#include "cuda_Feature2DAsync.h"
#include "cuda_FastFeatureDetector.h"
#include "cuda_ORB.h"
#include "cuda_SURF_CUDA.h"
// imgproc
#include "cuda_Imgproc.h"
// legacy
#include "cuda_Legacy.h"

// opengl
#include "cuda_OpenGL.h"

// photo
#include "cuda_Photo.h"

// stereo
#include "cuda_Stereo.h"

// warping
#include "cuda_Warping.h"

#endif
