using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;
using System;
namespace OpenCvSharp.Modules.wechat_qrcode
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class WechatQrcode: DisposableCvObject
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    {
        private Ptr? _objectPtr;
        internal WechatQrcode(IntPtr ptr)
        {
            _objectPtr = new Ptr(ptr);
            this.ptr = _objectPtr.Get();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="detector_prototxt_path"></param>
        /// <param name="detector_caffe_model_path"></param>
        /// <param name="super_resolution_prototxt_path"></param>
        /// <param name="super_resolution_caffe_model_path"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static WechatQrcode Create(
           string detector_prototxt_path,
            string detector_caffe_model_path,
            string super_resolution_prototxt_path,
            string super_resolution_caffe_model_path)
        {
            if (string.IsNullOrWhiteSpace(detector_prototxt_path))
                throw new ArgumentException("empty string", nameof(detector_prototxt_path));
            if (string.IsNullOrWhiteSpace(detector_caffe_model_path))
                throw new ArgumentException("empty string", nameof(detector_caffe_model_path));
            if (string.IsNullOrWhiteSpace(super_resolution_prototxt_path))
                throw new ArgumentNullException("empty string", nameof(super_resolution_prototxt_path));
            if (string.IsNullOrWhiteSpace(super_resolution_caffe_model_path))
                throw new ArgumentNullException("empty string", nameof(super_resolution_caffe_model_path));
           
            NativeMethods.HandleException(
                NativeMethods.wechat_qrcode_create1(
                   detector_prototxt_path, detector_caffe_model_path, super_resolution_prototxt_path, super_resolution_caffe_model_path,
                    out var ptr));
           
            return new WechatQrcode(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void DetectAndDecode(InputArray inputImage, out Mat[] bbox, out string?[] results)
        {
            if (inputImage == null)
                throw new ArgumentNullException(nameof(inputImage));
            inputImage.ThrowIfDisposed();
            using var bboxVec = new VectorOfMat();
            using var texts = new VectorOfString();
            NativeMethods.HandleException(
                NativeMethods.wechat_qrcode_WeChatQRCode_detectAndDecode(
                    ptr, inputImage.CvPtr, bboxVec.CvPtr, texts.CvPtr));
            bbox = bboxVec.ToArray();
            results = texts.ToArray();
            GC.KeepAlive(this);
            GC.KeepAlive(inputImage);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.wechat_qrcode_Ptr_WeChatQRCode_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.wechat_qrcode_Ptr_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
