using OpenCvSharp.Internal;

namespace OpenCvSharp.Text;

// ReSharper disable InconsistentNaming
/// <summary>
/// Base class for the 1st and 2nd stages of the Neumann and Matas scene text detection algorithm.
/// Extracts the component tree (if needed) and filters the extremal regions (ER's) using a given classifier.
/// </summary>
public sealed class ERFilter : Algorithm
{
    private ERFilter(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.text_Ptr_ERFilter_delete(p)))
    { }

    /// <summary>
    /// Creates an Extremal Region Filter for the 1st stage classifier of the N&amp;M algorithm.
    /// </summary>
    /// <param name="cb">Callback with the classifier.</param>
    /// <param name="thresholdDelta">Threshold step in subsequent thresholds when extracting the component tree.</param>
    /// <param name="minArea">The minimum area (% of image size) allowed for retrieved ER's.</param>
    /// <param name="maxArea">The maximum area (% of image size) allowed for retrieved ER's.</param>
    /// <param name="minProbability">The minimum probability P(er|character) allowed for retrieved ER's.</param>
    /// <param name="nonMaxSuppression">Whether non-maximum suppression is done over the branch probabilities.</param>
    /// <param name="minProbabilityDiff">The minimum probability difference between local maxima and local minima ERs.</param>
    /// <returns></returns>
    public static ERFilter CreateNM1(
        ERFilterCallback cb, int thresholdDelta = 1, float minArea = 0.00025f, float maxArea = 0.13f,
        float minProbability = 0.4f, bool nonMaxSuppression = true, float minProbabilityDiff = 0.1f)
    {
        ArgumentNullException.ThrowIfNull(cb);
        cb.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.text_createERFilterNM1_callback(
                cb.SmartPtr, thresholdDelta, minArea, maxArea, minProbability, nonMaxSuppression ? 1 : 0, minProbabilityDiff, out var smartPtr));
        GC.KeepAlive(cb);

        NativeMethods.HandleException(NativeMethods.text_Ptr_ERFilter_get(smartPtr, out var rawPtr));
        return new ERFilter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates an Extremal Region Filter for the 1st stage classifier of the N&amp;M algorithm, reading
    /// the classifier from the given file (e.g. trained_classifierNM1.xml).
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model.</param>
    /// <param name="thresholdDelta">Threshold step in subsequent thresholds when extracting the component tree.</param>
    /// <param name="minArea">The minimum area (% of image size) allowed for retrieved ER's.</param>
    /// <param name="maxArea">The maximum area (% of image size) allowed for retrieved ER's.</param>
    /// <param name="minProbability">The minimum probability P(er|character) allowed for retrieved ER's.</param>
    /// <param name="nonMaxSuppression">Whether non-maximum suppression is done over the branch probabilities.</param>
    /// <param name="minProbabilityDiff">The minimum probability difference between local maxima and local minima ERs.</param>
    /// <returns></returns>
    public static ERFilter CreateNM1(
        string filename, int thresholdDelta = 1, float minArea = 0.00025f, float maxArea = 0.13f,
        float minProbability = 0.4f, bool nonMaxSuppression = true, float minProbabilityDiff = 0.1f)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_createERFilterNM1_file(
                filename, thresholdDelta, minArea, maxArea, minProbability, nonMaxSuppression ? 1 : 0, minProbabilityDiff, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.text_Ptr_ERFilter_get(smartPtr, out var rawPtr));
        return new ERFilter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates an Extremal Region Filter for the 2nd stage classifier of the N&amp;M algorithm.
    /// </summary>
    /// <param name="cb">Callback with the classifier.</param>
    /// <param name="minProbability">The minimum probability P(er|character) allowed for retrieved ER's.</param>
    /// <returns></returns>
    public static ERFilter CreateNM2(ERFilterCallback cb, float minProbability = 0.3f)
    {
        ArgumentNullException.ThrowIfNull(cb);
        cb.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.text_createERFilterNM2_callback(cb.SmartPtr, minProbability, out var smartPtr));
        GC.KeepAlive(cb);

        NativeMethods.HandleException(NativeMethods.text_Ptr_ERFilter_get(smartPtr, out var rawPtr));
        return new ERFilter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates an Extremal Region Filter for the 2nd stage classifier of the N&amp;M algorithm, reading
    /// the classifier from the given file (e.g. trained_classifierNM2.xml).
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model.</param>
    /// <param name="minProbability">The minimum probability P(er|character) allowed for retrieved ER's.</param>
    /// <returns></returns>
    public static ERFilter CreateNM2(string filename, float minProbability = 0.3f)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_createERFilterNM2_file(filename, minProbability, out var smartPtr));

        NativeMethods.HandleException(NativeMethods.text_Ptr_ERFilter_get(smartPtr, out var rawPtr));
        return new ERFilter(smartPtr, rawPtr);
    }

    /// <summary>
    /// Sets the classifier callback used by this filter.
    /// </summary>
    /// <param name="cb"></param>
    public void SetCallback(ERFilterCallback cb)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(cb);
        cb.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_setCallback(Handle, cb.SmartPtr));

        GC.KeepAlive(cb);
    }

    /// <summary>
    /// Sets the threshold step in subsequent thresholds when extracting the component tree.
    /// </summary>
    /// <param name="thresholdDelta"></param>
    public void SetThresholdDelta(int thresholdDelta)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_setThresholdDelta(Handle, thresholdDelta));
    }

    /// <summary>
    /// Sets the minimum area (% of image size) allowed for retrieved ER's.
    /// </summary>
    /// <param name="minArea"></param>
    public void SetMinArea(float minArea)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_setMinArea(Handle, minArea));
    }

    /// <summary>
    /// Sets the maximum area (% of image size) allowed for retrieved ER's.
    /// </summary>
    /// <param name="maxArea"></param>
    public void SetMaxArea(float maxArea)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_setMaxArea(Handle, maxArea));
    }

    /// <summary>
    /// Sets the minimum probability P(er|character) allowed for retrieved ER's.
    /// </summary>
    /// <param name="minProbability"></param>
    public void SetMinProbability(float minProbability)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_setMinProbability(Handle, minProbability));
    }

    /// <summary>
    /// Sets the minimum probability difference between local maxima and local minima ERs.
    /// </summary>
    /// <param name="minProbabilityDiff"></param>
    public void SetMinProbabilityDiff(float minProbabilityDiff)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_setMinProbabilityDiff(Handle, minProbabilityDiff));
    }

    /// <summary>
    /// Sets whether non-maximum suppression is done over the branch probabilities.
    /// </summary>
    /// <param name="nonMaxSuppression"></param>
    public void SetNonMaxSuppression(bool nonMaxSuppression)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_setNonMaxSuppression(Handle, nonMaxSuppression ? 1 : 0));
    }

    /// <summary>
    /// Gets the number of rejected extremal regions.
    /// </summary>
    /// <returns></returns>
    public int GetNumRejected()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.text_ERFilter_getNumRejected(Handle, out var ret));
        return ret;
    }
}
