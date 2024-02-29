#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Operation flags for Covariation 
/// </summary>
[Flags]
public enum CovarFlags
{
    /// <summary>
    /// scale * [vects[0]-avg,vects[1]-avg,...]^T * [vects[0]-avg,vects[1]-avg,...]   
    /// that is, the covariation matrix is count×count. Such an unusual covariation matrix is used for fast PCA of a set of very large vectors
    /// (see, for example, Eigen Faces technique for face recognition). Eigenvalues of this "scrambled" matrix will match to the eigenvalues of
    /// the true covariation matrix and the "true" eigenvectors can be easily calculated from the eigenvectors of the "scrambled" covariation matrix.
    /// </summary>
    Scrambled = 0,

    /// <summary>
    /// scale * [vects[0]-avg,vects[1]-avg,...]*[vects[0]-avg,vects[1]-avg,...]^T   
    /// that is, cov_mat will be a usual covariation matrix with the same linear size as the total number of elements in every input vector. 
    /// One and only one of CV_COVAR_SCRAMBLED and CV_COVAR_NORMAL must be specified
    /// </summary>
    Normal = 1,

    /// <summary>
    /// If the flag is specified, the function does not calculate avg from the input vectors, 
    /// but, instead, uses the passed avg vector. This is useful if avg  has been already calculated somehow, 
    /// or if the covariation matrix is calculated by parts - in this case, avg is not a mean vector of the input sub-set of vectors, 
    /// but rather the mean vector of the whole set.
    /// </summary>
    UseAvg = 2,

    /// <summary>
    /// If the flag is specified, the covariation matrix is scaled by the number of input vectors.
    /// </summary>
    Scale = 4,

    /// <summary>
    /// Means that all the input vectors are stored as rows of a single matrix, vects[0].count is ignored in this case, 
    /// and avg should be a single-row vector of an appropriate size.
    /// </summary>
    Rows = 8,

    /// <summary>
    /// Means that all the input vectors are stored as columns of a single matrix, vects[0].count is ignored in this case, 
    /// and avg should be a single-column vector of an appropriate size. 
    /// </summary>
    Cols = 16,
}
