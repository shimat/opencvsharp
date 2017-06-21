using System;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers
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
}
