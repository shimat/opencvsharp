using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.DebuggerVisualizers;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.DebuggerVisualizers2012
{
    /// <summary>
    /// ビジュアライザでの視覚化処理
    /// </summary>
    public class MatDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            // MatProxyが送られてくるはず
            using (var proxy = objectProvider.GetObject() as MatProxy)
            {
                if (proxy == null)
                {
                    throw new ArgumentException();
                }
                // Formに表示
                using (var form = new ImageViewer(proxy))
                {
                    windowService.ShowDialog(form);
                }
            } 
        }
    }

    /// <summary>
    /// シリアライズ不可能なクラスをやり取りするために使うプロキシ。
    /// 送る際に、このProxyに表示に必要なシリアライズ可能なデータを詰めて送り、受信側で復元する。
    /// </summary>
    [Serializable]
    public class MatProxy : IDisposable
    {
        public byte[] ImageData { get; private set; }

        public MatProxy(Mat image)
        {
            ImageData = image.ToBytes(".png");
        }

        public void Dispose()
        {
            ImageData = null;
        }

        public Bitmap CreateBitmap()
        {
            if (ImageData == null)
                throw new Exception("ImageData == null");

            using (var stream = new MemoryStream(ImageData))
            {
                return new Bitmap(stream);
            }
        }
    }

    /// <summary>
    /// シリアライズ処理
    /// </summary>
    public class MatObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var bf = new BinaryFormatter();
            bf.Serialize(outgoingData, new MatProxy((Mat)target));
        }
    }
}
