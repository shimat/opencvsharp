using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers
{
    /// <summary>
    /// ビジュアライザでの視覚化処理
    /// </summary>
    public class IplImageDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            // IplImageProxyが送られてくるはず
            using (IplImageProxy proxy = objectProvider.GetObject() as IplImageProxy)
            {
                if (proxy == null)
                {
                    throw new ArgumentException();
                }
                // Formに表示
                using (IplImageViewer form = new IplImageViewer(proxy))
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
        public Bitmap Bitmap { get; private set; }

        public IplImageProxy(IplImage image)
        {
            Bitmap = image.ToBitmap();
        }
        public void Dispose()
        {
            Bitmap.Dispose();
        }
    }

    /// <summary>
    /// シリアライズ処理
    /// </summary>
    public class IplImageObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(outgoingData, new IplImageProxy((IplImage)target));
        }
    }
}
