using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus.Prototype;

namespace OpenCvSharp.Sandbox
{
    /// <summary>
    /// 書き捨てのコード。
    /// うまくいったらSampleに移管
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var memory = new List<long>(100);
            for (int i = 0; ; i++)
            {
                Mat mat = CvCpp.ImRead(@"img\shapes.png");
                Mat cols = mat.ColRange(10, 100);
                Mat rowsCols = new Mat(mat, new Rect(100,100,200,200));
                cols.GetHashCode();
                rowsCols.GetHashCode();

                memory.Add(MyProcess.WorkingSet64);
                if (memory.Count >= 100)
                {
                    double average = memory.Average();
                    Console.WriteLine("{0:F3}MB", average / 1024.0 / 1024.0);
                    memory.Clear();
                }
            }
            
        }
    }
}
