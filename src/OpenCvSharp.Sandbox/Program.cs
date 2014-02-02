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
                Mat mat = CvCpp.ImRead(@"img\lenna.png");
                //Mat mat2 = CvCpp.ImRead(@"img\lenna.png"); 
                
                //Mat matMul = mat.Mul(mat2);
                //matMul.GetHashCode();
                //Console.WriteLine(mat.Dump());

                var matAt = mat.GetIndexer<Byte3>();
                for (int y = 0; y < mat.Height; y++)
                {
                    for (int x = 0; x < mat.Width; x++)
                    {
                        Byte3 item = matAt[y, x];
                        Byte3 newItem = new Byte3
                        {
                            Item1 = item.Item3,
                            Item2 = item.Item2,
                            Item3 = item.Item1,
                        };
                        matAt[y, x] = newItem;
                    }
                }

                CvCpp.ImShow("window", mat);
                CvCpp.WaitKey();

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
