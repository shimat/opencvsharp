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

// filter
#include "cuda_Filters.h"

// imgproc
#include "cuda_CannyEdgeDetector.h"
#include "cuda_CLAHE.h"
#include "cuda_CascadeClassifier.h"
#include "cuda_CornernessCriteria.h"
#include "cuda_CornersDetector.h"
#include "cuda_GeneralizedHough.h"
#include "cuda_GeneralizedHoughBallard.h"
#include "cuda_GeneralizedHoughGuil.h"
#include "cuda_HoughCirclesDetector.h"
#include "cuda_HoughLinesDetector.h"
#include "cuda_HoughSegmentDetector.h"
#include "cuda_TemplateMatching.h"

// legacy
#include "cuda_Bgsegm_gmg.h"
#include "cuda_Bgsegm_fgd.h"
#include "cuda_ImagePyramid.h"
#include "cuda_FastOpticalFlowBM.h"

// opengl
#include "cuda_OpenGL.h"

// photo
#include "cuda_Photo.h"

// stereo
#include "cuda_Stereo.h"

// warping
#include "cuda_Warping.h"

#endif
