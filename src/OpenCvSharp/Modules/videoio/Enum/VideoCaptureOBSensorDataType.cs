namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// OBSENSOR data given from image generator
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/master/modules/videoio/include/opencv2/videoio.hpp
/// </remarks>
public enum VideoCaptureOBSensorDataType
{
    /// <summary>
    /// Depth values in mm (CV_16UC1)
    /// </summary>
    DepthMap = 0,

    /// <summary>
    /// Data given from BGR stream generator
    /// </summary>
    BgrImage = 1,

    /// <summary>
    /// Data given from IR stream generator (CV_16UC1)
    /// </summary>
    IrImage = 2,
}
