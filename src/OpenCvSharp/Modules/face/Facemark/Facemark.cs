using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.Face;

/// <summary>
/// Abstract base class for all facemark models.
/// 
/// All facemark models in OpenCV are derived from the abstract base class Facemark, which 
/// provides a unified access to all facemark algorithms in OpenCV.
/// To utilize this API in your program, please take a look at the @ref tutorial_table_of_content_facemark
/// </summary>
public abstract class Facemark : Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    protected Facemark(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    ///  A function to load the trained model before the fitting process.
    /// </summary>
    /// <param name="model">A string represent the filename of a trained model.</param>
    public virtual void LoadModel(string model)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_Facemark_loadModel(Handle, model));
    }

    /// <summary>
    /// Trains a Facemark algorithm using the given dataset.
    /// </summary>
    /// <param name="image">Input image.</param>
    /// <param name="faces">Output of the function which represent region of interest of the detected faces. Each face is stored in cv::Rect container.</param>
    /// <returns>The detected landmark points for each face. Empty if the fit failed.</returns>
    public virtual Point2f[][] Fit(
        InputArray image,
        InputArray faces)
    {
        ThrowIfDisposed();

        Point2f[][] landmarks;
        using (var landmarx = new VectorOfVectorPoint2f())
        {
            NativeMethods.HandleException(
                NativeMethods.face_Facemark_fit(Handle, image.Proxy, faces.Proxy, landmarx.CvPtr, out _));
            landmarks = landmarx.ToArray();
        }

        GC.KeepAlive(image.Source);

        return landmarks;
    }
}
