using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// NVIDIA Optical Flow 1.0 hardware-accelerated algorithm.
    /// </summary>
    public class NvidiaOpticalFlow_1_0 : NvidiaHWOpticalFlow
    {
        private NvidiaOpticalFlow_1_0(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_NvidiaOpticalFlow_1_0_delete(p)))
        {
        }

        /// <summary>
        /// Instantiate NVIDIA Optical Flow 1.0.
        /// </summary>
        public static NvidiaOpticalFlow_1_0 Create(
            Size imageSize,
            NvidiaOfPerfLevel perfPreset = NvidiaOfPerfLevel.Slow,
            bool enableTemporalHints = false,
            bool enableExternalHints = false,
            bool enableCostBuffer = false,
            int gpuId = 0,
            Stream? inputStream = null,
            Stream? outputStream = null)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createNvidiaOpticalFlow_1_0(
                    imageSize, (int)perfPreset,
                    enableTemporalHints ? 1 : 0, enableExternalHints ? 1 : 0,
                    enableCostBuffer ? 1 : 0, gpuId,
                    inputStream?.CvPtr ?? IntPtr.Zero, outputStream?.CvPtr ?? IntPtr.Zero,
                    out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_NvidiaOpticalFlow_1_0_get(smartPtr, out var rawPtr));

            return new NvidiaOpticalFlow_1_0(smartPtr, rawPtr);
        }

        /// <summary>
        /// Helper function to convert hardware-generated flow vectors to dense representation.
        /// </summary>
        /// <param name="flow">Hardware-generated flow (coarse grid).</param>
        /// <param name="imageSize">Original image size.</param>
        /// <param name="gridSize">Grid size (from GridSize property).</param>
        /// <param name="upsampledFlow">Output dense flow matrix.</param>
        public void UpSampler(OpenCvSharp.Cuda.InputArray flow, Size imageSize, int gridSize, OpenCvSharp.Cuda.InputOutputArray upsampledFlow)
        {
            if (flow == null) throw new ArgumentNullException(nameof(flow));
            if (upsampledFlow == null) throw new ArgumentNullException(nameof(upsampledFlow));

            flow.ThrowIfDisposed();
            upsampledFlow.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_NvidiaOpticalFlow_1_0_upSampler(
                    RawPtr, flow.CvPtr, imageSize, gridSize, upsampledFlow.CvPtr));

            upsampledFlow.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(flow);
        }
    }
}
