using OpenCvSharp.Internal;

namespace OpenCvSharp.Text;

/// <summary>
/// Callback with the classifier used by <see cref="ERFilter"/>. Instances are obtained by loading a
/// trained classifier model from a file; implementing a custom classifier in managed code is not
/// supported.
/// </summary>
public sealed class ERFilterCallback : CvPtrObject
{
    private ERFilterCallback(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.text_Ptr_ERFilterCallback_delete(p)))
    { }

    /// <summary>
    /// Loads the default classifier used by the 1st stage of the N&amp;M algorithm from the given
    /// XML or YAML file (e.g. trained_classifierNM1.xml).
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model.</param>
    /// <returns></returns>
    public static ERFilterCallback LoadClassifierNM1(string filename)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_loadClassifierNM1(filename, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.text_Ptr_ERFilterCallback_get(smartPtr, out var rawPtr));
        return new ERFilterCallback(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads the default classifier used by the 2nd stage of the N&amp;M algorithm from the given
    /// XML or YAML file (e.g. trained_classifierNM2.xml).
    /// </summary>
    /// <param name="filename">The XML or YAML file with the classifier model.</param>
    /// <returns></returns>
    public static ERFilterCallback LoadClassifierNM2(string filename)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.text_loadClassifierNM2(filename, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.text_Ptr_ERFilterCallback_get(smartPtr, out var rawPtr));
        return new ERFilterCallback(smartPtr, rawPtr);
    }
}
