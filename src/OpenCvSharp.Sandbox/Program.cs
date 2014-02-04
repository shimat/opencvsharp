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
            for (int i = 0; ; i++)
            {
                Stopwatch watch = new Stopwatch();

                Mat mat = CvCpp.ImRead(@"img\lenna.png");
                mat[new Rect(100, 100, 200, 200)] /= 3;

                //MatExpr subMat = mat[new Rect(100, 100, 200, 200)];
                //subMat /= 3;

                //Mat subMat = new Mat(mat, new Rect(100, 100, 200, 200));
                //subMat /= 3;
                
                //Console.WriteLine(subMat.IsSubmatrix());

                //MatU8C3 mat3 = new MatU8C3(mat);
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
                            TupleU8C3 item = matAt[y, x];
                            TupleU8C3 newItem = new TupleU8C3
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
                
                //CvCpp.ImShow("window1", mat);
                //CvCpp.ImShow("window2", subMat);
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
