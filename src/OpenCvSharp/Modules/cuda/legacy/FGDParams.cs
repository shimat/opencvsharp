#if ENABLED_CUDA
using System.Runtime.InteropServices;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// parameters for the FGD (Foreground Object Detection) algorithm.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FGDParams
    {
        /// <summary> How quickly we forget old background pixel values seen. Typically set to 0.1. </summary>
        public float Alpha1;
        /// <summary> Controls speed of feature learning. Depends on T. Typical value circa 0.005. </summary>
        public float Alpha2;
        /// <summary> Alternate to alpha2, used for quicker initial convergence. Typical value 0.1. </summary>
        public float Alpha3;
        /// <summary> Affects color and color co-occurrence quantization, typically set to 2. </summary>
        public float Delta;
        /// <summary> If true we ignore holes within foreground blobs. </summary>
        public int IsObjWithoutHoles;
        /// <summary> Quantized levels per color component. Power of two, typically 32, 64 or 128. </summary>
        public int Lc;
        /// <summary> Quantized levels per color co-occurrence component. Power of two, typically 16, 32 or 64. </summary>
        public int Lcc;
        /// <summary> Discard foreground blobs whose bounding box is smaller than this threshold. </summary>
        public float MinArea;
        /// <summary> Number of color vectors used to model normal background color variation. </summary>
        public int N1c;
        /// <summary> Number of color co-occurrence vectors used to model normal background color variation. </summary>
        public int N1cc;
        /// <summary> Used to allow the first N1c vectors to adapt over time to changing background. </summary>
        public int N2c;
        /// <summary> Used to allow the first N1cc vectors to adapt over time to changing background. </summary>
        public int N2cc;
        /// <summary> Erase one-pixel junk blobs and merge almost-touching blobs. Default value is 1. </summary>
        public int PerformMorphing;

        /// <summary>
        /// Returns the default FGD parameters.
        /// </summary>
        public static FGDParams GetDefault()
        {
            return new FGDParams
            {
                Alpha1 = 0.1f,
                Alpha2 = 0.005f,
                Alpha3 = 0.1f,
                Delta = 2.0f,
                IsObjWithoutHoles = 1,
                Lc = 128,
                Lcc = 64,
                MinArea = 50.0f,
                N1c = 15,
                N1cc = 25,
                N2c = 25,
                N2cc = 40,
                PerformMorphing = 1
            };
        }
    }
}
#endif
