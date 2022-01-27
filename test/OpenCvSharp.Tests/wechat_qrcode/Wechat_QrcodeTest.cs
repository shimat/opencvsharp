using OpenCvSharp.Modules.wechat_qrcode;
using System.IO;
using Xunit;
using Xunit.Abstractions;


namespace OpenCvSharp.Tests.wechat_qrcode
{
    public class WechatQrcodeTest:TestBase
    {
        const string _wechat_QCODE_detector_prototxt_path = "_data/wechat_qrcode/detect.prototxt";
        const string _wechat_QCODE_detector_caffe_model_path = "_data/wechat_qrcode/detect.caffemodel";
        const string _wechat_QCODE_super_resolution_prototxt_path = "_data/wechat_qrcode/sr.prototxt";
        const string _wechat_QCODE_super_resolution_caffe_model_path = "_data/wechat_qrcode/sr.caffemodel";
        private readonly ITestOutputHelper _testOutputHelper;

        public WechatQrcodeTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void WechatQrcodeDecodeRun()
        {
            Assert.True(File.Exists(_wechat_QCODE_detector_prototxt_path), $"DetectorPrototxt '{_wechat_QCODE_detector_prototxt_path}' not found");
            Assert.True(File.Exists(_wechat_QCODE_detector_caffe_model_path), $"DetectorcaffeModel '{_wechat_QCODE_detector_caffe_model_path}' not found");
            Assert.True(File.Exists(_wechat_QCODE_super_resolution_prototxt_path), $"SuperResolutionprototxt '{_wechat_QCODE_super_resolution_prototxt_path}' not found");
            Assert.True(File.Exists(_wechat_QCODE_super_resolution_caffe_model_path), $"SuperResolutionCaffe_model '{_wechat_QCODE_super_resolution_caffe_model_path}' not found");

            using var wechatQrcode = WechatQrcode.Create(_wechat_QCODE_detector_prototxt_path, _wechat_QCODE_detector_caffe_model_path,
                                                        _wechat_QCODE_super_resolution_prototxt_path, _wechat_QCODE_super_resolution_caffe_model_path);
            var src = Cv2.ImRead(@"_data/image/qr_multi.png", ImreadModes.Grayscale);
            wechatQrcode.DetectAndDecode(src, out var rects, out var texts);
            Assert.NotEmpty(texts);
            Assert.Equal(2, texts.Length);
            foreach (var item in texts)
            {
                _testOutputHelper.WriteLine(item);
                Assert.NotEmpty(item);
            }

        }
    }
}
