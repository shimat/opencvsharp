using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>Parameters for monocular visual odometry.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct VisualOdometryParams
{
    /// <summary>Gets the default parameters from OpenCV.</summary>
    public static VisualOdometryParams Default
    {
        get
        {
            NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_getDefaultParams(out var parameters));
            return parameters;
        }
    }

    /// <summary>Minimum match and inlier count for initialization.</summary>
    public int MinInitInliers;

    /// <summary>Minimum parallax in degrees for initialization.</summary>
    public double MinInitParallaxDeg;

    /// <summary>Minimum number of triangulated points to initialize the map.</summary>
    public int MinInitPoints;

    /// <summary>Homography-to-fundamental score ratio above which the homography is selected.</summary>
    public double HfRatioThresh;

    /// <summary>Minimum parallax in degrees for triangulating new points.</summary>
    public double MinGrowthParallaxDeg;

    /// <summary>RANSAC reprojection threshold in pixels for essential matrix and homography estimation.</summary>
    public double EssentialRansacThresh;

    /// <summary>RANSAC confidence for essential matrix estimation.</summary>
    public double EssentialRansacConfidence;

    /// <summary>PnP RANSAC reprojection threshold in pixels.</summary>
    public double PnpReprojThresh;

    /// <summary>Minimum PnP inliers required to accept a pose.</summary>
    public int PnpMinInliers;

    /// <summary>Maximum number of PnP RANSAC iterations.</summary>
    public int PnpRansacIters;

    /// <summary>PnP RANSAC confidence.</summary>
    public double PnpConfidence;

    /// <summary>Guided matching radius in pixels.</summary>
    public double MotionModelRadius;

    /// <summary>Fallback guided matching radius in pixels.</summary>
    public double MotionModelRadiusWide;

    /// <summary>Minimum number of matches before widening the search.</summary>
    public int MotionModelMinMatches;

    /// <summary>Descriptor distance cutoff for matching projected map points.</summary>
    public double DescProjThresh;

    /// <summary>Minimum correspondences for the optical flow fallback.</summary>
    public int OpticalFlowMinInliers;

    /// <summary>Minimum number of frames between keyframes.</summary>
    public int KfMinFrames;

    /// <summary>Number of frames after which a keyframe is forced.</summary>
    public int KfMaxFrames;

    /// <summary>Fraction of the last keyframe's inliers below which a keyframe is inserted.</summary>
    public double KfInlierRatio;

    /// <summary>Absolute inlier floor used for keyframe selection.</summary>
    public int KfMinInliers;

    /// <summary>Rotation in degrees from the last keyframe that forces a keyframe.</summary>
    public double KfRotThreshDeg;

    /// <summary>Translation from the last keyframe that forces a keyframe.</summary>
    public double KfTransThresh;

    /// <summary>Number of top co-visible keyframes that form the local map.</summary>
    public int LocalMapTopK;

    /// <summary>Number of co-visible neighbors expanded per local map keyframe.</summary>
    public int LocalMapNeighborK;

    /// <summary>Reprojection search radius in pixels for local map points.</summary>
    public double LocalMapRadius;
}
