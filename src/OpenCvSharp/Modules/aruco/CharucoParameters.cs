namespace OpenCvSharp.Aruco;

/// <summary>
/// Parameters used by CharucoDetector (cv::aruco::CharucoParameters).
/// </summary>
public class CharucoParameters : IDisposable
{
    /// <summary>
    /// optional 3x3 floating-point camera matrix
    /// </summary>
    public Mat CameraMatrix { get; set; } = new();

    /// <summary>
    /// optional vector of distortion coefficients
    /// </summary>
    public Mat DistCoeffs { get; set; } = new();

    /// <summary>
    /// number of adjacent markers that must be detected to return a charuco corner (default 2)
    /// </summary>
    public int MinMarkers { get; set; } = 2;

    /// <summary>
    /// try to use refine board (default false)
    /// </summary>
    public bool TryRefineMarkers { get; set; }

    /// <summary>
    /// run check to verify that markers belong to the same board (default true)
    /// </summary>
    public bool CheckMarkers { get; set; } = true;

    /// <summary>
    /// Destructor
    /// </summary>
    ~CharucoParameters()
    {
        Dispose(false);
    }

    /// <summary>
    /// Releases the CameraMatrix/DistCoeffs Mat instances.
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            CameraMatrix.Dispose();
            DistCoeffs.Dispose();
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
