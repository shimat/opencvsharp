using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Synthetic frame sequence generator for testing background subtraction algorithms.
/// It will generate the moving object on top of the background.
/// It will apply some distortion to the background to make the test more complex.
/// </summary>
public class SyntheticSequenceGenerator : Algorithm
{
    /// <summary>
    /// Creates an instance of SyntheticSequenceGenerator.
    /// </summary>
    /// <param name="background">Background image for object.</param>
    /// <param name="object">Object image which will move slowly over the background.</param>
    /// <param name="amplitude">Amplitude of wave distortion applied to background.</param>
    /// <param name="wavelength">Length of waves in distortion applied to background.</param>
    /// <param name="wavespeed">How fast waves will move.</param>
    /// <param name="objspeed">How fast object will fly over background.</param>
    public SyntheticSequenceGenerator(
        InputArray background, InputArray @object, double amplitude, double wavelength, double wavespeed, double objspeed)
        : base(CreateHandle(background, @object, amplitude, wavelength, wavespeed, objspeed),
            static p => NativeMethods.HandleException(NativeMethods.bgsegm_SyntheticSequenceGenerator_delete(p)))
    {
        GC.KeepAlive(background.Source);
        GC.KeepAlive(@object.Source);
    }

    private static IntPtr CreateHandle(
        InputArray background, InputArray @object, double amplitude, double wavelength, double wavespeed, double objspeed)
    {
        NativeMethods.HandleException(
            NativeMethods.bgsegm_SyntheticSequenceGenerator_new(
                background.Proxy, @object.Proxy, amplitude, wavelength, wavespeed, objspeed, out var p));
        return p;
    }

    /// <summary>
    /// Obtain the next frame in the sequence.
    /// </summary>
    /// <param name="frame">Output frame.</param>
    /// <param name="gtMask">Output ground-truth (foreground) mask.</param>
    public void GetNextFrame(OutputArray frame, OutputArray gtMask)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.bgsegm_SyntheticSequenceGenerator_getNextFrame(Handle, frame.Proxy, gtMask.Proxy));

        GC.KeepAlive(frame.Source);
        GC.KeepAlive(gtMask.Source);
    }
}
