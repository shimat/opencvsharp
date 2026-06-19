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
    /// that is the sum of squared distances between the observed projections imagePoints and the projected (using projectPoints() ) objectPoints.
    /// Initial solution for non-planar "objectPoints" needs at least 6 points and uses the DLT algorithm.
    /// Initial solution for planar "objectPoints" needs at least 4 points and uses pose from homography decomposition.
    /// Method is based on the paper "Pose refinement using non-linear Levenberg-Marquardt minimization scheme"  
    /// </summary>
    Iterative = 0,
        
    /// <summary>
    /// Method has been introduced by F.Moreno-Noguer, V.Lepetit and P.Fua in the paper “EPnP: Efficient Perspective-n-Point Camera Pose Estimation”.
    /// </summary>
    EPNP = 1,

    /// <summary>
    /// Method is based on the paper of Ding, Y., Yang, J., Larsson, V., Olsson, C., & Åstrom, K.
    /// "Revisiting the P3P Problem". In this case the function requires exactly four object and image points.
    /// </summary>
    P3P = 2,

    /// <summary>
    /// **Broken implementation. Using this flag will fallback to EPnP**.
    /// Joel A. Hesch and Stergios I. Roumeliotis. "A Direct Least-Squares (DLS) Method for PnP"
    /// </summary>
    DLS = 3,

    /// <summary>
    /// **Broken implementation. Using this flag will fallback to EPnP.**
    /// Method is based on the paper of A.Penate-Sanchez, J.Andrade-Cetto, F.Moreno-Noguer. 
    /// "Exhaustive Linearization for Robust Camera Pose and Focal Length Estimation"
    /// </summary>
    UPNP = 4,

    /// <summary>
    ///  Method is based on the paper of T. Ke, S. Roumeliotis
    /// "An Efficient Algebraic Solution to the Perspective-Three-Point Problem"
    /// In this case the function requires exactly four object and image points.
    /// </summary>
    AP3P = 5, 

    /// <summary>
    /// Method is based on the paper of T. Collins and A. Bartoli.
    /// "Infinitesimal Plane-Based Pose Estimation". 
    /// This method requires coplanar object points.
    /// </summary>
    IPPE = 6,

    /// <summary>
    /// Method is based on the paper of Toby Collins and Adrien Bartoli.
    /// "Infinitesimal Plane-Based Pose Estimation". This is a special case suitable for marker pose estimation.
    /// It requires 4 coplanar object points defined in the following order:
    ///   - point 0: [-squareLength / 2, squareLength / 2, 0]
    ///   - point 1: [squareLength / 2, squareLength / 2, 0]
    ///   - point 2: [squareLength / 2, -squareLength / 2, 0]
    ///   - point 3: [-squareLength / 2, -squareLength / 2, 0]
    /// </summary>
    IPPE_SQUARE = 7,

    /// <summary>
    /// A Consistently Fast and Globally OptimalSolution to the Perspective-n-Point Problem.
    /// Method is based on the paper "A Consistently Fast and Globally Optimal Solution to the
    /// Perspective-n-Point Problem" by G. Terzakis and M.Lourakis  It requires 3 or more points.
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
