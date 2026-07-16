namespace OpenCvSharp.Text;

/// <summary>
/// OCR character classifier type.
/// </summary>
public enum ClassifierType
{
    /// <summary>
    /// K-nearest neighbors classifier.
    /// </summary>
    Knn = 0,

    /// <summary>
    /// Convolutional neural network classifier.
    /// </summary>
    Cnn = 1,
}
