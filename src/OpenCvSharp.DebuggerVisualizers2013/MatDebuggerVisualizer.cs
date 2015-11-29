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
