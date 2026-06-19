namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Method for solving a PnP problem:
/// </summary>
public enum SolvePnPMethod
{
    /// <summary>
    /// Iterative method is based on Levenberg-Marquardt optimization. 
    /// In this case the function finds such a pose that minimizes reprojection error, 
    /// that is the sum of squared distances between the observed projections imagePoints and the projected (using projectPoints() ) objectPoints .
    /// </summary>
    Iterative = 0,
        
    /// <summary>
    /// Method has been introduced by F.Moreno-Noguer, V.Lepetit and P.Fua in the paper “EPnP: Efficient Perspective-n-Point Camera Pose Estimation”.
    /// </summary>
    EPNP = 1,

    /// <summary>
    /// Method is based on the paper of X.S. Gao, X.-R. Hou, J. Tang, H.-F. Chang“Complete Solution Classification for 
    /// the Perspective-Three-Point Problem”. In this case the function requires exactly four object and image points.
    /// </summary>
    P3P = 2,

    /// <summary>
    /// Joel A. Hesch and Stergios I. Roumeliotis. "A Direct Least-Squares (DLS) Method for PnP"
    /// </summary>
    DLS = 3, 
        
    /// <summary>
    /// A.Penate-Sanchez, J.Andrade-Cetto, F.Moreno-Noguer. "Exhaustive Linearization for Robust Camera Pose and Focal Length Estimation"
    /// </summary>
    UPNP = 4,

    /// <summary>
    /// T. Ke, S. Roumeliotis. "An Efficient Algebraic Solution to the Perspective-Three-Point Problem"
    /// </summary>
    AP3P = 5,

    /// <summary>
    /// Infinitesimal Plane-Based Pose Estimation. Object points must be coplanar.
    /// </summary>
    IPPE = 6,

    /// <summary>
    /// Infinitesimal Plane-Based Pose Estimation.
    /// This is a special case suitable for marker pose estimation. 4 coplanar object points must be defined.
    /// </summary>
    IPPE_SQUARE = 7,

    /// <summary>
    /// G. Terzakis, M. Lourakis. "A Consistently Fast and Globally Optimal Solution to the Perspective-n-Point Problem"
    /// </summary>
    SQPNP = 8,
}

/// <summary>
/// Obsolete: Use SolvePnPMethod instead. This enum is kept for backward compatibility.
/// </summary>
[Obsolete("Use SolvePnPMethod instead", true)]
public enum SolvePnPFlags
{
    /// <summary>
    /// Iterative method is based on Levenberg-Marquardt optimization. 
    /// In this case the function finds such a pose that minimizes reprojection error, 
    /// that is the sum of squared distances between the observed projections imagePoints and the projected (using projectPoints() ) objectPoints .
    /// </summary>
    Iterative = 0,

    /// <summary>
    /// Method has been introduced by F.Moreno-Noguer, V.Lepetit and P.Fua in the paper “EPnP: Efficient Perspective-n-Point Camera Pose Estimation”.
    /// </summary>
    EPNP = 1,

    /// <summary>
    /// Method is based on the paper of X.S. Gao, X.-R. Hou, J. Tang, H.-F. Chang“Complete Solution Classification for 
    /// the Perspective-Three-Point Problem”. In this case the function requires exactly four object and image points.
    /// </summary>
    P3P = 2,

    /// <summary>
    /// Joel A. Hesch and Stergios I. Roumeliotis. "A Direct Least-Squares (DLS) Method for PnP"
    /// </summary>
    DLS = 3,

    /// <summary>
    /// A.Penate-Sanchez, J.Andrade-Cetto, F.Moreno-Noguer. "Exhaustive Linearization for Robust Camera Pose and Focal Length Estimation"
    /// </summary>
    UPNP = 4,
}
