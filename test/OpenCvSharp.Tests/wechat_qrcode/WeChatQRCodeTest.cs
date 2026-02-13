using Xunit;

namespace OpenCvSharp.Tests.WeChatQRCode;

public class WeChatQRCodeTest(ITestOutputHelper testOutputHelper) : TestBase
{
    private const string WechatQcodeDetectorPrototxtPath = "_data/wechat_qrcode/detect.prototxt";
    private const string WechatQcodeDetectorCaffeModelPath = "_data/wechat_qrcode/detect.caffemodel";
    private const string WechatQcodeSuperResolutionPrototxtPath = "_data/wechat_qrcode/sr.prototxt";
    private const string WechatQcodeSuperResolutionCaffeModelPath = "_data/wechat_qrcode/sr.caffemodel";

    [Fact]
    public void WechatQrcodeDecodeRun()
    {
        Assert.True(File.Exists(WechatQcodeDetectorPrototxtPath), $"DetectorPrototxt '{WechatQcodeDetectorPrototxtPath}' not found");
        Assert.True(File.Exists(WechatQcodeDetectorCaffeModelPath), $"DetectorcaffeModel '{WechatQcodeDetectorCaffeModelPath}' not found");
        Assert.True(File.Exists(WechatQcodeSuperResolutionPrototxtPath), $"SuperResolutionprototxt '{WechatQcodeSuperResolutionPrototxtPath}' not found");
        Assert.True(File.Exists(WechatQcodeSuperResolutionCaffeModelPath), $"SuperResolutionCaffe_model '{WechatQcodeSuperResolutionCaffeModelPath}' not found");

        using var wechatQrcode = OpenCvSharp.WeChatQRCode.Create(
            WechatQcodeDetectorPrototxtPath, WechatQcodeDetectorCaffeModelPath,
            WechatQcodeSuperResolutionPrototxtPath, WechatQcodeSuperResolutionCaffeModelPath);
        using var src = Cv2.ImRead(@"_data/image/qr_multi.png", ImreadModes.Grayscale);

        wechatQrcode.DetectAndDecode(src, out var rects, out var texts);
        Assert.NotEmpty(texts);
        Assert.Equal(2, texts.Length);
        foreach (var item in texts)
        {
            testOutputHelper.WriteLine(item);
            Assert.NotEmpty(item);
        }
    }
}
