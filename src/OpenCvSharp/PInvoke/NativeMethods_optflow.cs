using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void optflow_motempl_updateMotionHistory(
            IntPtr silhouette, IntPtr mhi,
            double timestamp, double duration);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void optflow_motempl_calcMotionGradient(
            IntPtr mhi, IntPtr mask, IntPtr orientation,
            double delta1, double delta2, int apertureSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double optflow_motempl_calcGlobalOrientation(
            IntPtr orientation, IntPtr mask,
            IntPtr mhi, double timestamp, double duration);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void optflow_motempl_segmentMotion(
            IntPtr mhi, IntPtr segmask, IntPtr boundingRects,
            double timestamp, double segThresh);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void optflow_calcOpticalFlowSF1(
            IntPtr from,
            IntPtr to,
            IntPtr flow,
            int layers,
            int averagingBlockSize,
            int maxFlow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void optflow_calcOpticalFlowSF2(
            IntPtr from,
            IntPtr to,
            IntPtr flow,
            int layers,
            int averagingBlockSize,
            int maxFlow,
            double sigmaDist,
            double sigmaColor,
            int postprocessWindow,
            double sigmaDistFix,
            double sigmaColorFix,
            double occThr,
            int upscaleAveragingRadius,
            double upscaleSigmaDist,
            double upscaleSigmaColor,
            double speedUpThr);
    }
}