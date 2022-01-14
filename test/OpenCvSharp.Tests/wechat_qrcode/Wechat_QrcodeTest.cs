using OpenCvSharp.Modules.wechat_qrcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

#pragma warning disable CA1707, CA2000 // 标识符不应包含下划线
namespace OpenCvSharp.Tests.wechat_qrcode
{
    public class Wechat_QrcodeTest:TestBase
    {
        const string _wechat_QCODE_detector_prototxt_path = "_data/wechat_qrcode/detect.prototxt";
        const string _wechat_QCODE_detector_caffe_model_path = "_data/wechat_qrcode/detect.caffemodel";
        const string _wechat_QCODE_super_resolution_prototxt_path = "_data/wechat_qrcode/sr.prototxt";
        const string _wechat_QCODE_super_resolution_caffe_model_path = "_data/wechat_qrcode/sr.caffemodel";
        private readonly ITestOutputHelper _testOutputHelper;

        public Wechat_QrcodeTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void Wechat_QrcodeDecodeTest()
        {
            Assert.True(File.Exists(_wechat_QCODE_detector_prototxt_path), $"DetectorPrototxt '{_wechat_QCODE_detector_prototxt_path}' not found");
            Assert.True(File.Exists(_wechat_QCODE_detector_caffe_model_path), $"DetectorcaffeModel '{_wechat_QCODE_detector_caffe_model_path}' not found");
            Assert.True(File.Exists(_wechat_QCODE_super_resolution_prototxt_path), $"SuperResolutionprototxt '{_wechat_QCODE_super_resolution_prototxt_path}' not found");
            Assert.True(File.Exists(_wechat_QCODE_super_resolution_caffe_model_path), $"SuperResolutionCaffe_model '{_wechat_QCODE_super_resolution_caffe_model_path}' not found");
#pragma warning disable CA2000 // 丢失范围之前释放对象
            var wechatQrcode= WechatQrcode.Create(_wechat_QCODE_detector_prototxt_path, _wechat_QCODE_detector_caffe_model_path,
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
#pragma warning restore CA2000 // 丢失范围之前释放对象
        }
    }
}
#pragma warning restore CA1707 // 标识符不应包含下划线