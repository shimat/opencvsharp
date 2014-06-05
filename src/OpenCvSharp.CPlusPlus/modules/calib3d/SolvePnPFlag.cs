
namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Method for solving a PnP problem:
    /// </summary>
    public enum SolvePnPFlag : int
    {
        /// <summary>
        /// Iterative method is based on Levenberg-Marquardt optimization. 
        /// In this case the function finds such a pose that minimizes reprojection error, 
        /// that is the sum of squared distances between the observed projections imagePoints and the projected (using projectPoints() ) objectPoints .
        /// </summary>
        Iterative = CppConst.SolvePnP_ITERATIVE,

        /// <summary>
        /// Method is based on the paper of X.S. Gao, X.-R. Hou, J. Tang, H.-F. Chang“Complete Solution Classification for 
        /// the Perspective-Three-Point Problem”. In this case the function requires exactly four object and image points.
        /// </summary>
        P3P = CppConst.SolvePnP_P3P,

        /// <summary>
        /// Method has been introduced by F.Moreno-Noguer, V.Lepetit and P.Fua in the paper “EPnP: Efficient Perspective-n-Point Camera Pose Estimation”.
        /// </summary>
        EPNP = CppConst.SolvePnP_EPNP,
    }
}
