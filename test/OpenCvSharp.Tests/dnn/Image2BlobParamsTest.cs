using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

public class Image2BlobParamsTest : TestBase
{
    // Note: when param.Size == the image size passed to BlobRectToImageRect/BlobRectsToImageRects,
    // OpenCV's blobRectsToImageRects leaves the output untouched (all-zero Rects) rather than
    // treating it as an identity mapping - see opencv/modules/dnn/src/dnn_utils.cpp. So these
    // tests deliberately use a blob size different from the image size to exercise the real
    // (PMODE_NULL) scaling path.
    [Fact]
    public void BlobRectToImageRectScalesByRatio()
    {
        var param = new Image2BlobParams(new Scalar(1.0, 1.0, 1.0, 1.0), new Size(208, 208));

        var imageSize = new Size(416, 416);
        var rBlob = new Rect(10, 20, 100, 200);

        var rImg = param.BlobRectToImageRect(rBlob, imageSize);

        // PaddingMode.NULL: image coordinates are blob coordinates scaled by imageSize/paramSize (here x2).
        Assert.Equal(new Rect(20, 40, 200, 400), rImg);
    }

    [Fact]
    public void BlobRectsToImageRectsMatchesSingleOverload()
    {
        var param = new Image2BlobParams(new Scalar(1.0, 1.0, 1.0, 1.0), new Size(208, 208));
        var imageSize = new Size(416, 416);

        Rect[] rBlobs = [new(0, 0, 50, 50), new(10, 20, 100, 200)];

        var rImgs = param.BlobRectsToImageRects(rBlobs, imageSize);

        Assert.Equal(rBlobs.Length, rImgs.Length);
        for (var i = 0; i < rBlobs.Length; i++)
        {
            Assert.Equal(param.BlobRectToImageRect(rBlobs[i], imageSize), rImgs[i]);
        }
    }
}
