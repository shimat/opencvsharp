using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Core class of the color correction model (ccm). Produces a ColorCorrectionModel instance for inference.
/// </summary>
public class ColorCorrectionModel : CvObject
{
    #region Init & Disposal

    /// <summary>
    /// The default constructor.
    /// </summary>
    public ColorCorrectionModel()
    {
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_new1(out var p));
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Color Correction Model, initialized from a built-in color card.
    /// </summary>
    /// <param name="src">detected colors of ColorChecker patches; the color type is RGB not BGR, and
    /// the color values are in [0, 1].</param>
    /// <param name="constColor">the built-in color card.</param>
    public ColorCorrectionModel(InputArray src, ColorCheckerType constColor)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_new2(src.Proxy, (int)constColor, out var p));
        GC.KeepAlive(src.Source);
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Color Correction Model, initialized from explicit reference color values.
    /// </summary>
    /// <param name="src">detected colors of ColorChecker patches; the color type is RGB not BGR, and
    /// the color values are in [0, 1].</param>
    /// <param name="colors">the reference color values, the color values are in [0, 1].</param>
    /// <param name="refColorSpace">the corresponding color space; if the color type is some RGB,
    /// the format is RGB not BGR.</param>
    public ColorCorrectionModel(InputArray src, InputArray colors, ColorSpace refColorSpace)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_new3(src.Proxy, colors.Proxy, (int)refColorSpace, out var p));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(colors.Source);
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Color Correction Model, initialized from explicit reference color values and a colored-patches mask.
    /// </summary>
    /// <param name="src">detected colors of ColorChecker patches; the color type is RGB not BGR, and
    /// the color values are in [0, 1].</param>
    /// <param name="colors">the reference color values, the color values are in [0, 1].</param>
    /// <param name="refColorSpace">the corresponding color space; if the color type is some RGB,
    /// the format is RGB not BGR.</param>
    /// <param name="coloredPatchesMask">binary mask indicating which patches are colored (non-gray) patches.</param>
    public ColorCorrectionModel(InputArray src, InputArray colors, ColorSpace refColorSpace, InputArray coloredPatchesMask)
    {
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_new4(
                src.Proxy, colors.Proxy, (int)refColorSpace, coloredPatchesMask.Proxy, out var p));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(colors.Source);
        GC.KeepAlive(coloredPatchesMask.Source);
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: false, releaseAction: null));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_delete(CvPtr));
        base.DisposeUnmanaged();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets the absolute color space that detected colors convert to.
    /// It should be some RGB color space. Default: ColorSpace.SRGB.
    /// </summary>
    /// <param name="cs">the absolute color space that detected colors convert to.</param>
    public void SetColorSpace(ColorSpace cs)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setColorSpace(Handle, (int)cs));
    }

    /// <summary>
    /// Sets the shape of the color correction matrix (CCM). Default: CcmType.Linear.
    /// </summary>
    /// <param name="ccmType">the shape of the color correction matrix (CCM).</param>
    public void SetCcmType(CcmType ccmType)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setCcmType(Handle, (int)ccmType));
    }

    /// <summary>
    /// Sets the type of color distance. Default: DistanceType.CIE2000.
    /// </summary>
    /// <param name="distance">the type of color distance.</param>
    public void SetDistance(DistanceType distance)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setDistance(Handle, (int)distance));
    }

    /// <summary>
    /// Sets the method of linearization. Default: LinearizationType.Gamma.
    /// </summary>
    /// <param name="linearizationType">the method of linearization.</param>
    public void SetLinearization(LinearizationType linearizationType)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setLinearization(Handle, (int)linearizationType));
    }

    /// <summary>
    /// Sets the gamma value of gamma correction. Only valid when linearization is set to Gamma.
    /// Default: 2.2.
    /// </summary>
    /// <param name="gamma">the gamma value of gamma correction.</param>
    public void SetLinearizationGamma(double gamma)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setLinearizationGamma(Handle, gamma));
    }

    /// <summary>
    /// Sets the degree of the linearization polynomial. Only valid when linearization is set to
    /// ColorPolyFit, GrayPolyFit, ColorLogPolyFit, or GrayLogPolyFit. Default: 3.
    /// </summary>
    /// <param name="deg">the degree of the linearization polynomial.</param>
    public void SetLinearizationDegree(int deg)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setLinearizationDegree(Handle, deg));
    }

    /// <summary>
    /// Sets the saturation threshold. The colors in the closed interval [lower, upper] are reserved
    /// to participate in the calculation of the loss function and initialization parameters.
    /// </summary>
    /// <param name="lower">the lower threshold to determine saturation. Default: 0.</param>
    /// <param name="upper">the upper threshold to determine saturation. Default: 0.</param>
    public void SetSaturatedThreshold(double lower, double upper)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setSaturatedThreshold(Handle, lower, upper));
    }

    /// <summary>
    /// Sets the list of weights of each color. Default: empty array.
    /// </summary>
    /// <param name="weightsList">the list of weight of each color.</param>
    public void SetWeightsList(Mat weightsList)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(weightsList);
        weightsList.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setWeightsList(Handle, weightsList.CvPtr));

        GC.KeepAlive(weightsList);
    }

    /// <summary>
    /// Sets the exponent number of the L* component of the reference color in CIE Lab color space.
    /// Default: 0.
    /// </summary>
    /// <param name="weightsCoeff">the exponent number of the L* component of the reference color in
    /// CIE Lab color space.</param>
    public void SetWeightCoeff(double weightsCoeff)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setWeightCoeff(Handle, weightsCoeff));
    }

    /// <summary>
    /// Sets the method of calculating the CCM initial value. Default: InitialMethodType.LeastSquare.
    /// </summary>
    /// <param name="initialMethodType">the method of calculating the CCM initial value.</param>
    public void SetInitialMethod(InitialMethodType initialMethodType)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setInitialMethod(Handle, (int)initialMethodType));
    }

    /// <summary>
    /// Sets the terminal criteria max count used in MinProblemSolver-DownhillSolver. Default: 5000.
    /// </summary>
    /// <param name="maxCount">used in MinProblemSolver-DownhillSolver; terminal criteria to the algorithm.</param>
    public void SetMaxCount(int maxCount)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setMaxCount(Handle, maxCount));
    }

    /// <summary>
    /// Sets the terminal criteria epsilon used in MinProblemSolver-DownhillSolver. Default: 1e-4.
    /// </summary>
    /// <param name="epsilon">used in MinProblemSolver-DownhillSolver; terminal criteria to the algorithm.</param>
    public void SetEpsilon(double epsilon)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setEpsilon(Handle, epsilon));
    }

    /// <summary>
    /// Sets whether the input image is in RGB color space.
    /// </summary>
    /// <param name="rgb">If true, the model expects input images in RGB format. If false, input is
    /// assumed to be in BGR (default).</param>
    public void SetRGB(bool rgb)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_setRGB(Handle, rgb ? 1 : 0));
    }

    /// <summary>
    /// Makes the color correction, fitting the CCM to the configured reference colors.
    /// </summary>
    /// <returns>the fitted color correction matrix.</returns>
    public Mat Compute()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_compute(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Gets the fitted color correction matrix.
    /// </summary>
    /// <returns></returns>
    public Mat GetColorCorrectionMatrix()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_getColorCorrectionMatrix(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Gets the loss of the fitted color correction matrix.
    /// </summary>
    /// <returns></returns>
    public double GetLoss()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_getLoss(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Gets the linearized source RGB values used during fitting.
    /// </summary>
    /// <returns></returns>
    public Mat GetSrcLinearRGB()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_getSrcLinearRGB(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Gets the linearized reference RGB values used during fitting.
    /// </summary>
    /// <returns></returns>
    public Mat GetRefLinearRGB()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_getRefLinearRGB(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Gets the mask of the patches used during fitting.
    /// </summary>
    /// <returns></returns>
    public Mat GetMask()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_getMask(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Gets the weights of each color used during fitting.
    /// </summary>
    /// <returns></returns>
    public Mat GetWeights()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_getWeights(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Applies color correction to the input image using the fitted color correction matrix.
    /// The conventional ranges for R, G, and B channel values are 0 to 255 for CV_8U images,
    /// 0 to 65535 for CV_16U images, and 0 to 1 for CV_32F images.
    /// </summary>
    /// <param name="src">Input 8-bit, 16-bit unsigned or 32-bit float 3-channel image.</param>
    /// <param name="dst">Output image of the same size and datatype as src.</param>
    /// <param name="isLinear">Default false.</param>
    public void CorrectImage(InputArray src, OutputArray dst, bool isLinear = false)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_correctImage(Handle, src.Proxy, dst.Proxy, isLinear ? 1 : 0));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// Stores this color correction model in a file storage.
    /// </summary>
    /// <param name="fs"></param>
    public void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);

        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_write(Handle, fs.CvPtr));

        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Reads this color correction model from a file node.
    /// </summary>
    /// <param name="node"></param>
    public void Read(FileNode node)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(node);

        NativeMethods.HandleException(
            NativeMethods.photo_ccm_ColorCorrectionModel_read(Handle, node.CvPtr));

        GC.KeepAlive(node);
    }

    #endregion
}
