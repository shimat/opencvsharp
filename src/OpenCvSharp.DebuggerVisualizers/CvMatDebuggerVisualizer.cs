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
    public class CvMatDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            // 送られてくるはずのCvMatProxyを受け取る
            using (CvMatProxy proxy = objectProvider.GetObject() as CvMatProxy)
            {
                if (proxy == null)
                {
                    throw new ArgumentException();
                }
                using (CvMatViewer form = new CvMatViewer(proxy))
                {
                    // 行列データ表示用フォームを開く
                    windowService.ShowDialog(form);

                    // 値の変更を元データのCvMatに反映
                    if (objectProvider.IsObjectReplaceable)
                    {
                        objectProvider.ReplaceObject(form.ModifiedProxy);
                    }
                }
            }
        }
    }

    /// <summary>
    /// シリアライズ不可能なクラスをやり取りするために使うプロキシ。
    /// 送る際に、このProxyに表示に必要なシリアライズ可能なデータを詰めて送り、受信側で復元する。
    /// </summary>
    [Serializable]
    public class CvMatProxy : IDisposable
    {
        public CvScalar[,] Data { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int ElemChannels { get; set; }

        public CvMatProxy(CvMat mat)
        {
            Data = mat.ToRectangularArray();
            Rows = mat.Rows;
            Cols = mat.Cols;
            ElemChannels = mat.ElemChannels;
        }
        public CvMatProxy(CvScalar[,] data, int rows, int cols, int elemChannels)
        {
            Data = data;
            Rows = rows;
            Cols = cols;
            ElemChannels = elemChannels;
        }
        public void Dispose()
        {
        }
    }

    /// <summary>
    /// シリアライズ処理
    /// </summary>
    public class CvMatObjectSource : VisualizerObjectSource
    {
        /// <summary>
        /// 送信
        /// </summary>
        /// <param name="target"></param>
        /// <param name="outgoingData"></param>
        public override void GetData(object target, Stream outgoingData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(outgoingData, new CvMatProxy((CvMat)target));
        }
        /// <summary>
        /// 値の書き換え
        /// </summary>
        /// <param name="target"></param>
        /// <param name="incomingData"></param>
        /// <returns></returns>
        public override object CreateReplacementObject(object target, Stream incomingData)
        {
            // プロキシデータの復元
            BinaryFormatter bf = new BinaryFormatter();
            CvMatProxy proxy = bf.Deserialize(incomingData) as CvMatProxy;
            if (proxy == null)
            {
                throw new Exception("Failed to cast");
            }
            // 元データのCvMat
            CvMat mat = target as CvMat;
            if (proxy == null || mat == null)
            {
                throw new Exception("Failed to cast");
            }

            // 手作業で値を移し変え
            int rows = mat.Rows;
            int cols = mat.Cols;
            CvScalar[,] data = proxy.Data;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Cv.Set2D(mat, r, c, data[r, c]); 
                }
            }

            return mat;
            //return base.CreateReplacementObject(target, incomingData);
        }
    }
}
