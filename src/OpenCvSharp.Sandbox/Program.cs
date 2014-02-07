using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Run();
        }

        static void Run()
        {
            var memory = new List<long>(100);
            for (long i = 0; ; i++)
            {
                Stopwatch watch = new Stopwatch();

                Mat mat = new Mat(@"img\lenna.png", LoadMode.Color);
                //mat[new Rect(100, 100, 200, 200)] = 3;
                //Console.WriteLine(mat.Dump());
                //mat.Row(100).SetTo(Scalar.All(10));
                //subMat.SetTo(subMat.Clone() / 3);
                //mat[ new Rect(100, 100, 200, 200)] = mat[new Rect(100, 100, 200, 200)].T();
                mat.Col[100] = ~mat.Col[200] * 2 / 3;

                Mat gray = new Mat();
                Cv2.CvtColor(mat, gray, (int)ColorConversion.BgrToGray);

                //mat.Row[100,200] = mat.Row[200,300] * 2;

                Mat subMat = new Mat(mat, new Range(200, 400), new Range(200, 400));
                Mat subMat2 = mat.SubMat(100, 200, 100, 200);
                Console.WriteLine(subMat.IsSubmatrix());
                Console.WriteLine(subMat2.IsSubmatrix());
                //Cv2.GaussianBlur(subMat, subMat, new Size(25, 25), -1);
                Cv2.GaussianBlur(mat.GetRowRange(100, 200), mat.GetRowRange(100, 200), new Size(25, 25), -1);

                //Mat3b mat3 = new Mat3b(mat);
                //mat3.GetHashCode();

                //IplImage img = (IplImage)mat;
                //img.GetHashCode();
                //CvWindow.ShowImages(img);

                /*
                watch.Restart();
                {
                    var matAt = mat.GetGenericIndexer<ByteTuple3>();
                    for (int y = 0; y < mat.Height; y++)
                    {
                        for (int x = 0; x < mat.Width; x++)
                        {
                            ByteTuple3 item = matAt[y, x];
                            ByteTuple3 newItem = new ByteTuple3
                                {
                                    Item1 = item.Item3,
                                    Item2 = item.Item2,
                                    Item3 = item.Item1,
                                };
                            matAt[y, x] = newItem;
                        }
                    }
                }
                watch.Stop();
                Console.WriteLine("GenericIndexer: {0}ms", watch.ElapsedMilliseconds);
                //*/

                /*
                watch.Restart();
                {
                    var matAt = mat3.GetIndexer();
                    for (int y = 0; y < mat.Height; y++)
                    {
                        for (int x = 0; x < mat.Width; x++)
                        {
                            Vec3b item = matAt[y, x];
                            Vec3b newItem = new Vec3b
                            {
                                Item1 = item.Item3,
                                Item2 = item.Item2,
                                Item3 = item.Item1,
                            };
                            matAt[y, x] = newItem;
                        }

                    }
                }
                watch.Stop();
                //Console.WriteLine("PointerIndexer: {0}ms", watch.ElapsedMilliseconds);
                //*/

                /*
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
                */
                
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
