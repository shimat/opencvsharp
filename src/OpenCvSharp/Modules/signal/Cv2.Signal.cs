using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::signal functions.
    /// </summary>
    public static partial class Signal
    {
        /// <summary>
        /// Signal resampling. Implemented using a cubic interpolation function and a filtering function
        /// based on a Kaiser window and Bessel function, used to construct a FIR filter. The result is
        /// similar to scipy.signal.resample.
        /// </summary>
        /// <param name="inputSignal">Array with the input signal.</param>
        /// <param name="outSignal">Array with the output signal.</param>
        /// <param name="inFreq">Input signal frequency.</param>
        /// <param name="outFreq">Output signal frequency.</param>
        public static void ResampleSignal(InputArray inputSignal, OutputArray outSignal, int inFreq, int outFreq)
        {
            NativeMethods.HandleException(
                NativeMethods.signal_resampleSignal(inputSignal.Proxy, outSignal.Proxy, inFreq, outFreq));
            GC.KeepAlive(inputSignal.Source);
            GC.KeepAlive(outSignal.Source);
        }
    }
}
