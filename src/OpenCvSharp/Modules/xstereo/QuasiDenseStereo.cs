using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Class containing the methods needed for Quasi Dense Stereo computation.
///
/// This class contains the code to perform quasi dense stereo matching. The method initially starts
/// with a sparse 3D reconstruction based on feature matching across a stereo image pair and
/// subsequently propagates the structure into neighboring image regions. To obtain initial seed
/// correspondences, the algorithm locates Shi and Tomasi features in the left image of the stereo pair
/// and then tracks them using pyramidal Lucas-Kanade in the right image. To densify the sparse
/// correspondences, the algorithm computes the zero-mean normalized cross-correlation (ZNCC) in small
/// patches around every seed pair and uses it as a quality metric for each match.
/// </summary>
public class QuasiDenseStereo : CvPtrObject
{
    private QuasiDenseStereo(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(NativeMethods.xstereo_Ptr_QuasiDenseStereo_delete(p)))
    {
    }

    /// <summary>
    /// Creates a QuasiDenseStereo object.
    /// </summary>
    /// <param name="monoImgSize">Size of a single monochrome image.</param>
    /// <param name="paramFilepath">The location of a .YAML file containing the configuration
    /// parameters. If empty, the default parameters are loaded.</param>
    public static QuasiDenseStereo Create(Size monoImgSize, string paramFilepath = "")
    {
        ArgumentNullException.ThrowIfNull(paramFilepath);

        NativeMethods.HandleException(
            NativeMethods.xstereo_QuasiDenseStereo_create(monoImgSize, paramFilepath, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.xstereo_Ptr_QuasiDenseStereo_get(smartPtr, out var rawPtr));
        return new QuasiDenseStereo(smartPtr, rawPtr);
    }

    /// <summary>
    /// Load a file containing the configuration parameters of the class.
    /// </summary>
    /// <param name="filepath">The location of the .YAML file containing the configuration parameters.</param>
    /// <returns>1 if the path is not empty and the program loaded the parameters successfully.
    /// 0 if the path is empty and the program loaded default parameters.
    /// -1 if the file location is not valid or the program could not open the file and loaded default
    /// parameters from defaults.hpp.</returns>
    public virtual int LoadParameters(string filepath)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(filepath);

        NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_loadParameters(Handle, filepath, out var ret));
        return ret;
    }

    /// <summary>
    /// Save a file containing all the configuration parameters the class is currently set to.
    /// </summary>
    /// <param name="filepath">The location to store the parameters file.</param>
    public virtual int SaveParameters(string filepath)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(filepath);

        NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_saveParameters(Handle, filepath, out var ret));
        return ret;
    }

    /// <summary>
    /// Get the sparse corresponding points.
    /// </summary>
    /// <returns>A vector containing all sparse correspondences.</returns>
    public virtual MatchQuasiDense[] GetSparseMatches()
    {
        ThrowIfDisposed();

        using var matches = new VectorOfMatchQuasiDense();
        NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_getSparseMatches(Handle, matches.CvPtr));
        GC.KeepAlive(this);
        return matches.ToArray();
    }

    /// <summary>
    /// Get the dense corresponding points.
    /// </summary>
    /// <returns>A vector containing all dense matches.</returns>
    public virtual MatchQuasiDense[] GetDenseMatches()
    {
        ThrowIfDisposed();

        using var matches = new VectorOfMatchQuasiDense();
        NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_getDenseMatches(Handle, matches.CvPtr));
        GC.KeepAlive(this);
        return matches.ToArray();
    }

    /// <summary>
    /// Main process of the algorithm. This method computes the sparse seeds and then densifies them.
    ///
    /// Initially input images are converted to gray-scale and then the sparse matching is performed,
    /// followed by the propagation of the corresponding points.
    /// </summary>
    /// <param name="imgLeft">The left channel of a stereo image pair.</param>
    /// <param name="imgRight">The right channel of a stereo image pair.</param>
    public virtual void Process(Mat imgLeft, Mat imgRight)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(imgLeft);
        ArgumentNullException.ThrowIfNull(imgRight);
        imgLeft.ThrowIfDisposed();
        imgRight.ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_process(Handle, imgLeft.CvPtr, imgRight.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(imgLeft);
        GC.KeepAlive(imgRight);
    }

    /// <summary>
    /// Specify pixel coordinates in the left image and get its corresponding location in the right image.
    /// This method should be always called after <see cref="Process"/>, otherwise the matches will not
    /// be correct.
    /// </summary>
    /// <param name="x">The x pixel coordinate in the left image channel.</param>
    /// <param name="y">The y pixel coordinate in the left image channel.</param>
    /// <returns>The location of the corresponding pixel in the right image, or (0, 0) if no match is
    /// found.</returns>
    public virtual Point2f GetMatch(int x, int y)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_getMatch(Handle, x, y, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Compute and return the disparity map based on the correspondences found by <see cref="Process"/>.
    /// </summary>
    public virtual Mat GetDisparity()
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_getDisparity(Handle, out var matPtr));
        GC.KeepAlive(this);
        return new Mat(matPtr);
    }

    /// <summary>
    /// The propagation parameters used by the quasi dense matching algorithm.
    /// </summary>
    public PropagationParameters Param
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_getParam(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xstereo_QuasiDenseStereo_setParam(Handle, ref value));
        }
    }
}
