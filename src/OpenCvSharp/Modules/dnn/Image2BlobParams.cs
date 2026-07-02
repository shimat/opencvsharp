// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// Processing params of image to blob.
/// It includes all possible image processing operations and corresponding parameters.
/// </summary>
/// <seealso cref="Cv2.Dnn.BlobFromImageWithParams(InputArray, Image2BlobParams)"/>
public class Image2BlobParams
{
    /// <summary>
    /// scalefactor multiplier for input image values.
    /// </summary>
    public Scalar ScaleFactor { get; set; } = new(1.0, 1.0, 1.0, 1.0);

    /// <summary>
    /// spatial size for output image.
    /// </summary>
    public Size Size { get; set; }

    /// <summary>
    /// scalar with mean values which are subtracted from channels.
    /// </summary>
    public Scalar Mean { get; set; }

    /// <summary>
    /// flag which indicates that swap first and last channels.
    /// </summary>
    public bool SwapRB { get; set; }

    /// <summary>
    /// depth of output blob. Choose CV_32F or CV_8U.
    /// </summary>
    public MatType Depth { get; set; } = MatType.CV_32F;

    /// <summary>
    /// order of output dimensions.
    /// </summary>
    public DataLayout DataLayout { get; set; } = DataLayout.NCHW;

    /// <summary>
    /// element of image processing mode.
    /// </summary>
    public ImagePaddingMode PaddingMode { get; set; } = ImagePaddingMode.NULL;

    /// <summary>
    /// border value used with the LETTERBOX padding mode.
    /// </summary>
    public Scalar BorderValue { get; set; }

    /// <summary>
    /// Creates parameters with default values.
    /// </summary>
    public Image2BlobParams()
    {
    }

    /// <summary>
    /// Creates parameters with the specified values.
    /// </summary>
    /// <param name="scaleFactor">multiplier for input image values.</param>
    /// <param name="size">spatial size for output image.</param>
    /// <param name="mean">scalar with mean values which are subtracted from channels.</param>
    /// <param name="swapRB">flag which indicates that swap first and last channels.</param>
    /// <param name="depth">depth of output blob. Choose CV_32F or CV_8U.</param>
    /// <param name="dataLayout">order of output dimensions.</param>
    /// <param name="paddingMode">element of image processing mode.</param>
    /// <param name="borderValue">border value used with the LETTERBOX padding mode.</param>
    public Image2BlobParams(
        Scalar scaleFactor, Size size = default, Scalar mean = default, bool swapRB = false,
        MatType? depth = null, DataLayout dataLayout = DataLayout.NCHW,
        ImagePaddingMode paddingMode = ImagePaddingMode.NULL, Scalar borderValue = default)
    {
        ScaleFactor = scaleFactor;
        Size = size;
        Mean = mean;
        SwapRB = swapRB;
        Depth = depth ?? MatType.CV_32F;
        DataLayout = dataLayout;
        PaddingMode = paddingMode;
        BorderValue = borderValue;
    }
}
