using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// DebuggrVisualizerにおいて、シリアライズ不可能なクラスをやり取りするために使うプロキシ。
    /// 送る際に、このProxyに表示に必要なシリアライズ可能なデータを詰めて送り、受信側で復元する。
    /// </summary>
    [Serializable]
    public class MatProxy : IDisposable
    {
        /// <summary>
        /// 画像をエンコードしたデータ
        /// </summary>
        public byte[] ImageData { get; private set; }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="image"></param>
        public MatProxy(Mat image)
        {
            using (var converted = new Mat())
            {
                Cv2.ConvertImage(image, converted);
                ImageData = converted.ToBytes(".png");
            }
        }

        /// <summary>
        /// リソースの解放
        /// </summary>
        public void Dispose()
        {
            ImageData = null;
        }

        /// <summary>
        /// ImageDataをストリームにして返す
        /// </summary>
        /// <returns></returns>
        public Stream CreateBitmapStream()
        {
            if (ImageData == null)
                throw new Exception("ImageData == null");
            return new MemoryStream(ImageData);
        }
    }
}
