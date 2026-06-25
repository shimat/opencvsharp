// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Camera model used by the OpenCV 5 multi-view calibration functions
/// (<see cref="Cv2.RegisterCameras"/> / <see cref="Cv2.CalibrateMultiview"/>).
/// </summary>
public enum CameraModel
{
    /// <summary>
    /// Pinhole camera model (CALIB_MODEL_PINHOLE).
    /// </summary>
    Pinhole = 0,

    /// <summary>
    /// Fisheye camera model (CALIB_MODEL_FISHEYE).
    /// </summary>
    Fisheye = 1
}
