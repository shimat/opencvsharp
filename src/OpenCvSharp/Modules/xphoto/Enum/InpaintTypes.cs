// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp.XPhoto;

/// <summary>
/// various inpainting algorithms
/// </summary>
public enum InpaintTypes
{
    /// <summary>
    /// This algorithm searches for dominant correspondences(transformations) of image patches 
    /// and tries to seamlessly fill-in the area to be inpainted using this transformations inpaint
    /// </summary>
    SHIFTMAP = 0,
        
    /// <summary>
    /// Performs Frequency Selective Reconstruction (FSR).
    /// One of the two quality profiles BEST and FAST can be chosen, depending on the time available for reconstruction.
    /// See @cite GenserPCS2018 and @cite SeilerTIP2015 for details.
    ///
    /// The algorithm may be utilized for the following areas of application:
    /// 1. %Error Concealment (Inpainting).
    /// The sampling mask indicates the missing pixels of the distorted input
    /// image to be reconstructed.
    /// 2. Non-Regular Sampling.
    /// For more information on how to choose a good sampling mask, please review
    /// @cite GroscheICIP2018 and @cite GroscheIST2018.
    ///
    /// 1-channel grayscale or 3-channel BGR image are accepted.
    ///
    /// Conventional accepted ranges:
    /// - 0-255 for CV_8U
    /// - 0-65535 for CV_16U
    /// - 0-1 for CV_32F/CV_64F.
    /// </summary>
    FSR_BEST = 1,

    /// <summary>
    /// See #INPAINT_FSR_BEST
    /// </summary>
    FSR_FAST = 2
}
