using OpenCvSharp.Internal;

namespace OpenCvSharp.Face;

/// <inheritdoc />
/// <summary>
/// Training and prediction must be done on grayscale images, use cvtColor to convert between the 
/// color spaces.
/// -   **THE EIGENFACES METHOD MAKES THE ASSUMPTION, THAT THE TRAINING AND TEST IMAGES ARE OF EQUAL SIZE.
/// ** (caps-lock, because I got so many mails asking for this). You have to make sure your 
/// input data has the correct shape, else a meaningful exception is thrown.Use resize to resize the images.
/// -   This model does not support updating.
/// </summary>
// ReSharper disable once InconsistentNaming
public class EigenFaceRecognizer : BasicFaceRecognizer
{
    /// <summary>
    ///
    /// </summary>
    protected EigenFaceRecognizer()
    {
    }

    /// <summary>
    /// Training and prediction must be done on grayscale images, use cvtColor to convert between the 
    /// color spaces.
    /// -   **THE EIGENFACES METHOD MAKES THE ASSUMPTION, THAT THE TRAINING AND TEST IMAGES ARE OF EQUAL SIZE.
    /// ** (caps-lock, because I got so many mails asking for this). You have to make sure your 
    /// input data has the correct shape, else a meaningful exception is thrown.Use resize to resize the images.
    /// -   This model does not support updating.
    /// </summary>
    /// <param name="numComponents"> The number of components (read: Eigenfaces) kept for this Principal Component Analysis. 
    /// As a hint: There's no rule how many components (read: Eigenfaces) should be kept for good reconstruction capabilities. 
    /// It is based on your input data, so experiment with the number. Keeping 80 components should almost always be sufficient.</param>
    /// <param name="threshold">The threshold applied in the prediction.</param>
    /// <returns></returns>
    public static EigenFaceRecognizer Create(int numComponents = 0, double threshold = double.MaxValue)
    {
        NativeMethods.HandleException(
            NativeMethods.face_EigenFaceRecognizer_create(numComponents, threshold, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(EigenFaceRecognizer)}> pointer");
        var detector = new EigenFaceRecognizer();
        detector.SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.face_Ptr_EigenFaceRecognizer_delete(p))));
        return detector;
    }

    }
