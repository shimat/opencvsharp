using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers
{
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