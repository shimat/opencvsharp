using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus;

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
            Run();
        }

        static void Run()
        {
            MatOfByte mm = new MatOfByte(0, 0) { 2, 3, 4, 5 };
            MatOfByte mmm = mm.Reshape(0, 2);
            Console.WriteLine(mm.Dump(DumpFormat.C));
            mmm.ToString();

            var memory = new List<long>(100);
            for (long i = 0; ; i++)
            {
                var a = new List<byte> {1, 128, 255};
                var b = new List<byte>();
                Cv2.BitwiseNot(InputArray.Create(a), OutputArray.Create(b));

                Stopwatch watch = new Stopwatch();

                Mat mat = new Mat(@"img\lenna.png", LoadMode.Color);
                MatOfByte3 mat3 = new MatOfByte3(mat);
                //mat[new Rect(100, 100, 200, 200)] = 3;
                //Console.WriteLine(mat.Dump());
                //mat.Row(100).SetTo(Scalar.All(10));
                //subMat.SetTo(subMat.Clone() / 3);
                //mat[ new Rect(100, 100, 200, 200)] = mat[new Rect(100, 100, 200, 200)].T();
                //mat.Col[100] = ~mat.Col[200] * 2 / 3;
                mat.ImWrite("C:\\temp\\hoge.png");
                Mat gray = new Mat();
                Cv2.CvtColor(mat, gray, ColorConversion.BgrToGray);

                Cv2.GaussianBlur(mat.RowRange(100, 200), mat.RowRange(100, 200), new Size(25, 25), -1);


                
                ///*
                Cv2.ImShow("window1", mat);
                Cv2.ImShow("window2", gray);
                //Cv2.ImShow("subMat", subMat);
                Cv2.WaitKey();
                //*/

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
