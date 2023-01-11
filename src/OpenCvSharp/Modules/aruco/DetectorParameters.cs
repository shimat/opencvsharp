using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Aruco;

#pragma warning disable CA1815

/// <summary>
/// Parameters for the detectMarker process
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct DetectorParameters
{
    /// <summary>
    /// minimum window size for adaptive thresholding before finding contours (default 3).
    /// </summary>
    public int AdaptiveThreshWinSizeMin = 3;

    /// <summary>
    /// adaptiveThreshWinSizeMax: maximum window size for adaptive thresholding before finding contours(default 23).
    /// </summary>
    public int AdaptiveThreshWinSizeMax = 23;

    /// <summary>
    /// increments from adaptiveThreshWinSizeMin to adaptiveThreshWinSizeMax during the thresholding(default 10).
    /// </summary>
    public int AdaptiveThreshWinSizeStep = 10;

    /// <summary>
    /// constant for adaptive thresholding before finding contours (default 7)
    /// </summary>
    public double AdaptiveThreshConstant = 7;

    /// <summary>
    /// determine minimum perimeter for marker contour to be detected. 
    /// This is defined as a rate respect to the maximum dimension of the input image(default 0.03).
    /// </summary>
    public double MinMarkerPerimeterRate = 0.03;

    /// <summary>
    ///  determine maximum perimeter for marker contour to be detected. 
    /// This is defined as a rate respect to the maximum dimension of the input image(default 4.0).
    /// </summary>
    public double MaxMarkerPerimeterRate = 4;

    /// <summary>
    /// minimum accuracy during the polygonal approximation process to determine which contours are squares.
    /// </summary>
    public double PolygonalApproxAccuracyRate = 0.03;

    /// <summary>
    /// minimum distance between corners for detected markers relative to its perimeter(default 0.05)
    /// </summary>
    public double MinCornerDistanceRate = 0.05;

    /// <summary>
    ///  minimum distance of any corner to the image border for detected markers (in pixels) (default 3)
    /// </summary>
    public int MinDistanceToBorder = 3;

    /// <summary>
    /// minimum mean distance between two marker corners to be considered similar, 
    /// so that the smaller one is removed.The rate is relative to the smaller perimeter of the two markers(default 0.05).
    /// </summary>
    public double MinMarkerDistanceRate = 0.05;

    /// <summary>
    /// corner refinement method.
    /// (CORNER_REFINE_NONE, no refinement. CORNER_REFINE_SUBPIX, do subpixel refinement. CORNER_REFINE_CONTOUR use contour-Points)
    /// </summary>
    [MarshalAs(UnmanagedType.I4)]
    public CornerRefineMethod CornerRefinementMethod = CornerRefineMethod.None;

    /// <summary>
    /// window size for the corner refinement process (in pixels) (default 5).
    /// </summary>
    public int CornerRefinementWinSize = 5;

    /// <summary>
    /// maximum number of iterations for stop criteria of the corner refinement process(default 30).
    /// </summary>
    public int CornerRefinementMaxIterations = 30;

    /// <summary>
    /// minimum error for the stop criteria of the corner refinement process(default: 0.1)
    /// </summary>
    public double CornerRefinementMinAccuracy = 0.1;

    /// <summary>
    /// number of bits of the marker border, i.e. marker border width (default 1).
    /// </summary>
    public int MarkerBorderBits = 1;

    /// <summary>
    /// number of bits (per dimension) for each cell of the marker when removing the perspective(default 8).
    /// </summary>
    public int PerspectiveRemovePixelPerCell = 4;

    /// <summary>
    /// width of the margin of pixels on each cell not considered for the determination 
    /// of the cell bit.Represents the rate respect to the total  size of the cell, 
    /// i.e. perspectiveRemovePixelPerCell (default 0.13)
    /// </summary>
    public double PerspectiveRemoveIgnoredMarginPerCell = 0.13;

    /// <summary>
    /// maximum number of accepted erroneous bits in the border 
    /// (i.e. number of allowed white bits in the border). Represented as a rate respect to the total 
    /// number of bits per marker(default 0.35).
    /// </summary>
    public double MaxErroneousBitsInBorderRate = 0.35;

    /// <summary>
    /// minimun standard deviation in pixels values during the decodification step to
    ///  apply Otsu thresholding(otherwise, all the bits are set to 0 or 1 depending on mean higher than 128 or not) (default 5.0)
    /// </summary>
    public double MinOtsuStdDev = 5.0;

    /// <summary>
    /// errorCorrectionRate error correction rate respect to the maximun error correction capability for each dictionary. (default 0.6).
    /// </summary>
    public double ErrorCorrectionRate = 0.6;

    /// <summary>
    /// Detection of quads can be done on a lower-resolution image, improving speed at a cost of pose accuracy and a slight decrease in detection rate.
    /// Decoding the binary payload is still done at full resolution.
    /// </summary>
    public float AprilTagQuadDecimate = 0;

    /// <summary>
    /// What Gaussian blur should be applied to the segmented image (used for quad detection?) Parameter is the standard deviation in pixels.
    /// Very noisy images benefit from non-zero values (e.g. 0.8).
    /// </summary>
    public float AprilTagQuadSigma = 0;

    /// <summary>
    /// reject quads containing too few pixels.
    /// </summary>
    public int AprilTagMinClusterPixels = 5;

    /// <summary>
    /// how many corner candidates to consider when segmenting a group of pixels into a quad.
    /// </summary>
    public int AprilTagMaxNmaxima = 10;

    /// <summary>
    /// Reject quads where pairs of edges have angles that are close to straight or close to 180 degrees. Zero means that no quads are rejected. (In radians).
    /// </summary>
    public float AprilTagCriticalRad = (float)(10 * Cv2.PI / 180);

    /// <summary>
    /// When fitting lines to the contours, what is the maximum mean squared error allowed?
    /// This is useful in rejecting contours that are far from being quad shaped; rejecting these quads "early" saves expensive decoding processing.
    /// </summary>
    public float AprilTagMaxLineFitMse = 10;

    /// <summary>
    /// When we build our model of black &amp; white pixels, we add an extra check that the white model must be (overall) brighter than the black model.
    /// How much brighter? (in pixel values, [0,255]).
    /// </summary>
    public int AprilTagMinWhiteBlackDiff = 5;

    /// <summary>
    /// should the thresholded image be deglitched? Only useful for very noisy images
    /// </summary>
    public int AprilTagDeglitch = 0;

    /// <summary>
    /// to check if there is a white marker. In order to generate a "white" marker just invert a normal marker by using a tilde, ~markerImage. (default false)
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool DetectInvertedMarker = false;
    
    /// <summary>
    /// enable the new and faster Aruco detection strategy.
    /// Proposed in the paper:
    /// * Romero-Ramirez et al: Speeded up detection of squared fiducial markers (2018)
    /// * https://www.researchgate.net/publication/325787310_Speeded_Up_Detection_of_Squared_Fiducial_Markers
    /// </summary>
    [MarshalAs(UnmanagedType.U1)]
    public bool UseAruco3Detection = false;

    /// <summary>
    /// minimum side length of a marker in the canonical image. Latter is the binarized image in which contours are searched. 
    /// </summary>
    public int MinSideLengthCanonicalImg = 32;
    
    /// <summary>
    /// range [0,1], eq (2) from paper. The parameter tau_i has a direct influence on the processing speed.
    /// </summary>
    public float MinMarkerLengthRatioOriginalImg = 0.0f;

    /// <summary>
    /// Constructor
    /// </summary>
    public DetectorParameters()
    {
    }
}
