namespace OpenCvSharp.Text;

/// <summary>
/// Tesseract OCR engine mode.
/// </summary>
public enum OcrEngineMode
{
    /// <summary>
    /// Run Tesseract only, fastest.
    /// </summary>
    TesseractOnly,

    /// <summary>
    /// Run the Cube OCR engine only.
    /// </summary>
    CubeOnly,

    /// <summary>
    /// Run both Tesseract and Cube, and use the classifier that gives the best result.
    /// </summary>
    TesseractCubeCombined,

    /// <summary>
    /// Default OCR engine mode.
    /// </summary>
    Default,
}
