namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// OBSENSOR stream generator
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/master/modules/videoio/include/opencv2/videoio.hpp
/// </remarks>
public enum VideoCaptureOBSensorGenerators
{
    /// <summary>
    ///
    /// </summary>
    DepthGenerator = 1 << 29,

    /// <summary>
    ///
    /// </summary>
    ImageGenerator = 1 << 28,

    /// <summary>
    ///
    /// </summary>
    IrGenerator = 1 << 27,

    /// <summary>
    ///
    /// </summary>
    GeneratorsMask = DepthGenerator + ImageGenerator + IrGenerator,
}
