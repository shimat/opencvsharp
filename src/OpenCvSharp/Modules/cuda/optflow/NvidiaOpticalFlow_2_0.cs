#if ENABLED_CUDA
using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// NVIDIA Optical Flow 2.0 hardware-accelerated algorithm.
    /// </summary>
    public sealed class NvidiaOpticalFlow_2_0 : NvidiaHWOpticalFlow
    {
        private NvidiaOpticalFlow_2_0(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_NvidiaOpticalFlow_2_0_delete(p)))
        {
        }

        /// <summary>
        /// Instantiate NVIDIA Optical Flow 2.0.
        /// </summary>
        public static NvidiaOpticalFlow_2_0 Create(
            Size imageSize,
            NvidiaOfPerfLevel perfPreset = NvidiaOfPerfLevel.Slow,
            NvidiaOfOutputGridSize outputGridSize = NvidiaOfOutputGridSize.Size1,
            NvidiaOfHintGridSize hintGridSize = NvidiaOfHintGridSize.Size1,
            bool enableTemporalHints = false,
            bool enableExternalHints = false,
            bool enableCostBuffer = false,
            int gpuId = 0,
            Stream? inputStream = null,
            Stream? outputStream = null)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createNvidiaOpticalFlow_2_0(
                    imageSize, (int)perfPreset, (int)outputGridSize, (int)hintGridSize,
                    enableTemporalHints ? 1 : 0, enableExternalHints ? 1 : 0,
                    enableCostBuffer ? 1 : 0, gpuId,
                    inputStream?.CvPtr ?? IntPtr.Zero, outputStream?.CvPtr ?? IntPtr.Zero,
                    out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_NvidiaOpticalFlow_2_0_get(smartPtr, out var rawPtr));

            return new NvidiaOpticalFlow_2_0(smartPtr, rawPtr);
        }

        /// <summary>
        /// Instantiate NVIDIA Optical Flow 2.0 with ROI support.
        /// </summary>
        public static NvidiaOpticalFlow_2_0 Create(
            Size imageSize,
            Rect[] roiData,
            NvidiaOfPerfLevel perfPreset = NvidiaOfPerfLevel.Slow,
            NvidiaOfOutputGridSize outputGridSize = NvidiaOfOutputGridSize.Size1,
            NvidiaOfHintGridSize hintGridSize = NvidiaOfHintGridSize.Size1,
            bool enableTemporalHints = false,
            bool enableExternalHints = false,
            bool enableCostBuffer = false,
            int gpuId = 0,
            Stream? inputStream = null,
            Stream? outputStream = null)
        {
            if (roiData == null) throw new ArgumentNullException(nameof(roiData));

            NativeMethods.HandleException(
                NativeMethods.cuda_createNvidiaOpticalFlow_2_0_roi(
                    imageSize, roiData, roiData.Length, (int)perfPreset, (int)outputGridSize, (int)hintGridSize,
                    enableTemporalHints ? 1 : 0, enableExternalHints ? 1 : 0,
                    enableCostBuffer ? 1 : 0, gpuId,
                    inputStream?.CvPtr ?? IntPtr.Zero, outputStream?.CvPtr ?? IntPtr.Zero,
                    out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_NvidiaOpticalFlow_2_0_get(smartPtr, out var rawPtr));

            return new NvidiaOpticalFlow_2_0(smartPtr, rawPtr);
        }

        /// <summary>
        /// Converts the hardware-generated flow vectors to floating point representation.
        /// </summary>
        public void ConvertToFloat(InputArray flow, OutputArray floatFlow)
        {
            if (flow == null) throw new ArgumentNullException(nameof(flow));
            if (floatFlow == null) throw new ArgumentNullException(nameof(floatFlow));

            flow.ThrowIfDisposed();
            floatFlow.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_NvidiaOpticalFlow_2_0_convertToFloat(RawPtr, flow.CvPtr, floatFlow.CvPtr));

            floatFlow.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(flow);
        }
    }
}
#endif
