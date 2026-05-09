using System;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Cuda
{
    public sealed class SURF_CUDA : Algorithm
    {
        private SURF_CUDA(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_delete(p)))
        {
        }

        public static SURF_CUDA Create(double hessianThreshold, int nOctaves = 4, int nOctaveLayers = 2, bool extended = false, float keypointsRatio = 0.01f, bool upright = false)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_SURF_CUDA_new(hessianThreshold, nOctaves, nOctaveLayers, extended ? 1 : 0, keypointsRatio, upright ? 1 : 0, out var smartPtr));
            NativeMethods.HandleException(
                NativeMethods.cuda_SURF_CUDA_get(smartPtr, out var rawPtr));
            return new SURF_CUDA(smartPtr, rawPtr);
        }

        public int DescriptorSize
        {
            get 
            { 
                NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_descriptorSize(RawPtr, out int res));
                return res; 
            }
        }

        public double HessianThreshold
        {
            get 
            { 
                NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_getHessianThreshold(RawPtr, out double res));
                return res;
            }
            set 
            {
                NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_setHessianThreshold(RawPtr, value));
            }
        }

        public void Detect(GpuMat img, GpuMat? mask, GpuMat keypoints)
        {
            NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_detect(RawPtr, img.CvPtr, mask?.CvPtr ?? IntPtr.Zero, keypoints.CvPtr));
        }

        public void DetectWithDescriptors(GpuMat img, GpuMat? mask, GpuMat keypoints, GpuMat descriptors, bool useProvidedKeypoints = false)
        {
            NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_detectWithDescriptors(RawPtr, img.CvPtr, mask?.CvPtr ?? IntPtr.Zero, keypoints.CvPtr, descriptors.CvPtr, useProvidedKeypoints ? 1 : 0));
        }

        public KeyPoint[] DownloadKeypoints(GpuMat keypointsGPU)
        {
            using var vec = new VectorOfKeyPoint();
            NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_downloadKeypoints(RawPtr, keypointsGPU.CvPtr, vec.CvPtr));
            return vec.ToArray();
        }

        public float[] DownloadDescriptors(GpuMat descriptorsGPU)
        {
            using var vec = new VectorOfFloat();
            NativeMethods.HandleException(NativeMethods.cuda_SURF_CUDA_downloadDescriptors(RawPtr, descriptorsGPU.CvPtr, vec.CvPtr));
            return vec.ToArray();
        }
    }
}
