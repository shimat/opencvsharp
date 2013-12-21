using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Gpu;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// cv::gpu
    /// </summary>
    class GpuTest
    {
        public GpuTest()
        {
            // GPUを使いたい場合は、cmakeでWITH_CUDAを付けてOpenCVをビルドしたときのopencv_gpu220.dllが必要。
            // NVIDIA NPPのインストール先のbinにある npp32_32_16.dll(32bit) or npp64_32_16.dll(64bit) へパスを通しておくことも必要。


            // CUDA付きでビルドされたopencv_gpu220.dllがある場合はtrueになる。
            if (CvGpu.IsEnabled)
            {
                int count = CvGpu.CudaEnabledDeviceCount;
                Console.WriteLine("CudaEnabledDeviceCount : {0}", count);
                for (int device = 0; device < count; device++)
                {
                    //string name = CvGpu.GetDeviceName(device);  // どうも先頭にゴミが付く...
                    //int major, minor;
                    //CvGpu.GetComputeCapability(device, out major, out minor);
                    //ulong free, total;
                    //CvGpu.GetGpuMemInfo(out free, out total);

                    //Console.WriteLine("Device{0} ({1})", device, name);
                    //Console.WriteLine("\tCapability : {0}.{1}", major, minor);
                    //Console.WriteLine("\tMemory : {0}/{1}", free, total);
                    //Console.WriteLine("\tHasAtomicsSupport : {0}", CvGpu.HasAtomicsSupport(device));
                    //Console.WriteLine("\tHasNativeDoubleSupport : {0}", CvGpu.HasNativeDoubleSupport(device));
                    //Console.WriteLine();
                }

                // StereoBM_GPU
                using (Mat matLeft = new Mat(Const.ImageTsukubaLeft, LoadMode.GrayScale))
                using (Mat matRight = new Mat(Const.ImageTsukubaRight, LoadMode.GrayScale))
                {
                    using (GpuMat gpumatLeft = new GpuMat(matLeft))
                    using (GpuMat gpumatRight = new GpuMat(matRight))
                    using (GpuMat gpumatDisp = new GpuMat(matLeft.Size, MatrixType.U8C1))
                    using (StereoBM_GPU bm = new StereoBM_GPU(0))
                    {
                        bm.Run(gpumatLeft, gpumatRight, gpumatDisp);
                        Mat matDst = (Mat)gpumatDisp;
                        matDst.ConvertTo(matDst, matDst.Type, 3, 0);
                        CvWindow.ShowImages((IplImage)matDst);
                    }
                }
            }
            // CUDA無しのときは、GPU関係のメソッドは呼び出すことができない。
            else
            {
                Console.WriteLine("No cuda device");
            }

            Console.Read();
        }
    }
}