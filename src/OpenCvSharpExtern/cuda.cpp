// ReSharper disable CppUnusedIncludeDirective

#ifdef ENABLED_CUDA
#include "cuda_runtime.h"

#include "cuda_Core.h"

#include "cuda_Arithm.h"
#include "cuda_Imgproc.h"
#include "cuda_Warping.h"
#include "cuda_Legacy.h"

#include "cuda_Stereo.h"
#include "cuda_OpenGL.h"
#include "cuda_Photo.h"

// bgsegm
#include "cuda_Bgsegm_mog.h"
#include "cuda_Bgsegm_mog2.h"

// core stuff
#include "cuda_BufferPool.h"
#include "cuda_DeviceInfo.h"
#include "cuda_Event.h"
#include "cuda_EventAccessor.h"
#include "cuda_Stream.h"
#include "cuda_StreamAccessor.h"
#include "cuda_GpuMat.h"
#include "cuda_GpuData.h"
#include "cuda_GpuMatND.h"
#include "cuda_HostMem.h"
#include "cuda_TargetArchs.h"

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

// objectdetect
#include "cuda_CascadeClassifier.h"
#include "cuda_HOG.h"

// optiflow
#include "cuda_BroxOpticalFlow.h"
#include "cuda_DenseOpticalFlow.h"
#include "cuda_DensePyrLKOpticalFlow.h"
#include "cuda_FarnebackOpticalFlow.h"
#include "cuda_OpticalFlowDual_TVL1.h"
#include "cuda_NvidiaHWOpticalFlow.h"
#include "cuda_NvidiaOpticalFlow_1_0.h"
#include "cuda_NvidiaOpticalFlow_2_0.h"
#include "cuda_SparseOpticalFlow.h"
#include "cuda_SparsePyrLKOpticalFlow.h"

// stereo
#include "cuda_DisparityBilateralFilter.h"
#include "cuda_StereoBeliefPropagation.h"
#include "cuda_StereoBM.h"
#include "cuda_StereoConstantSpaceBP.h"
#include "cuda_StereoMatcher.h"
#include "cuda_StereoSGM.h"
#endif
