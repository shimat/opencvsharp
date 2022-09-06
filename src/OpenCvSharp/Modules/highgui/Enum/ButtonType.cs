namespace OpenCvSharp;
// TODO support createButton

/// <summary>
/// Button type flags (cv::createButton)
/// </summary>
public enum ButtonType
{
    /// <summary>
    /// The button will be a push button.
    /// </summary>
    PushButton = 0,

    /// <summary>
    /// The button will be a checkbox button.
    /// </summary>
    Checkbox = 1,

    /// <summary>
    /// The button will be a radiobox button. The radiobox on the same buttonbar (same line) are exclusive; one on can be select at the time.
    /// </summary>
    Radiobox = 2,
}
