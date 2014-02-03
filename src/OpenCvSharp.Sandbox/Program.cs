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
                /*
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
                }*/

                byte[,] matData = new byte[3,3]
                    {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9}
                    };
                Mat mat2 = new Mat(3, 3, MatrixType.U8C1, matData);
                Mat mat22 = mat2.Mul(mat2);

                for (int r = 0; r < mat2.Rows; r++)
                {
                    for (int c = 0; c < mat2.Cols; c++)
                    {
                        //Console.Write("{0} ", mat22.Get<byte>(r, c));
                        (r + c).GetHashCode();
                        mat22.GetHashCode();
                    }
                    //Console.WriteLine();
                }

                //CvCpp.ImShow("window", mat);
                //CvCpp.WaitKey();

                memory.Add(MyProcess.WorkingSet64);
                if (memory.Count >= 100)
                {
                    double average = memory.Average();
                    Console.WriteLine("{0:F3}MB", average / 1024.0 / 1024.0);
                    memory.Clear();
                    GC.Collect();
                }
            }
            
        }
    }
}
