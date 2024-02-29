namespace OpenCvSharp;

/// <summary>
/// Modes of operation for cvHaarDetectObjects
/// </summary>
[Flags]
public enum HaarDetectionTypes
{
    /// <summary>
    /// If it is set, the function uses Canny edge detector to reject some image regions that contain too few or too much edges and thus can not contain the searched object. 
    /// The particular threshold values are tuned for face detection and in this case the pruning speeds up the processing.
    /// [CV_HAAR_DO_CANNY_PRUNING]
    /// </summary>
    DoCannyPruning = 1,

    /// <summary>
    /// For each scale factor used the function will downscale the image rather than "zoom" the feature coordinates in the classifier cascade. 
    /// Currently, the option can only be used alone, i.e. the flag can not be set together with the others.
    /// [CV_HAAR_SCALE_IMAGE]
    /// </summary>
    ScaleImage = 2,

    /// <summary>
    /// If it is set, the function finds the largest object (if any) in the image. That is, the output sequence will contain one (or zero) element(s).
    /// [CV_HAAR_FIND_BIGGEST_OBJECT]
    /// </summary>
    FindBiggestObject = 4,

    /// <summary>
    /// It should be used only when FindBiggestObject is set and min_neighbors > 0. 
    /// If the flag is set, the function does not look for candidates of a smaller size 
    /// as soon as it has found the object (with enough neighbor candidates) at the current scale. 
    /// Typically, when min_neighbors is fixed, the mode yields less accurate (a bit larger) object rectangle 
    /// than the regular single-object mode (flags=FindBiggestObject), 
    /// but it is much faster, up to an order of magnitude. A greater value of min_neighbors may be specified to improve the accuracy.
    /// [CV_HAAR_DO_ROUGH_SEARCH]
    /// </summary>
    DoRoughSearch = 8,
}
