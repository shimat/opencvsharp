using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers2013
{
    /// <summary>
    /// ビジュアライザでの視覚化処理
    /// </summary>
    public class IplImageDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            // IplImageProxyが送られてくるはず
            using (var proxy = objectProvider.GetObject() as IplImageProxy)
            {
                if (proxy == null)
                {
                    throw new ArgumentException("proxy == null");
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
    public class IplImageProxy : IDisposable
    {
        public byte[] ImageData { get; private set; }

        public IplImageProxy(IplImage image)
        {
            ImageData = image.ToBytes(".png");
        }

        public void Dispose()
        {
            ImageData = null;
        }

        public Bitmap CreateBitmap()
        {
            if(ImageData == null)
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
    public class IplImageObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var bf = new BinaryFormatter();
            bf.Serialize(outgoingData, new IplImageProxy((IplImage)target));
        }
    }
}
