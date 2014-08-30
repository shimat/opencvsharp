using System;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// Swaps B for R 
    /// </summary>
    class PixelAccess : ISample
    {
        public void Run()
        {
            Console.WriteLine("Get/Set: {0}ms", MeasureTime(GetSet));
            Console.WriteLine("GenericIndexer: {0}ms", MeasureTime(GenericIndexer));
            Console.WriteLine("TypeSpecificMat: {0}ms", MeasureTime(TypeSpecificMat));
            Console.Read();
        }

        /// <summary>
        /// Slow
        /// </summary>
        private void GetSet()
        {
            using (Mat mat = new Mat(FilePath.Image.Lenna, LoadMode.Color))
            {
                for (int y = 0; y < mat.Height; y++)
                {
                    for (int x = 0; x < mat.Width; x++)
                    {
                        Vec3b color = mat.Get<Vec3b>(y, x);
                        Swap(ref color.Item0, ref color.Item2);
                        mat.Set<Vec3b>(y, x, color);
                    }
                }
                //Cv2.ImShow("Slow", mat);
                //Cv2.WaitKey(0);
                //Cv2.DestroyAllWindows();
            }
        }

        /// <summary>
        /// Reasonably fast
        /// </summary>
        private void GenericIndexer()
        {
            using (Mat mat = new Mat(FilePath.Image.Lenna, LoadMode.Color))
            {
                var indexer = mat.GetGenericIndexer<Vec3b>();
                for (int y = 0; y < mat.Height; y++)
                {
                    for (int x = 0; x < mat.Width; x++)
                    {
                        Vec3b color = indexer[y, x];
                        Swap(ref color.Item0, ref color.Item2);
                        indexer[y, x] = color;
                    }
                }
                //Cv2.ImShow("GenericIndexer", mat);
                //Cv2.WaitKey(0);
                //Cv2.DestroyAllWindows();
            }
        }

        /// <summary>
        /// Faster
        /// </summary>
        private void TypeSpecificMat()
        {
            using (Mat mat = new Mat(FilePath.Image.Lenna, LoadMode.Color))
            {
                MatOfByte3 mat3 = new MatOfByte3(mat);
                var indexer = mat3.GetIndexer();
                for (int y = 0; y < mat.Height; y++)
                {
                    for (int x = 0; x < mat.Width; x++)
                    {
                        Vec3b color = indexer[y, x];
                        Swap(ref color.Item0, ref color.Item2);
                        indexer[y, x] = color;
                    }
                }
                //Cv2.ImShow("TypeSpecificMat", mat);
                //Cv2.WaitKey(0);
                //Cv2.DestroyAllWindows();
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = b;
            b = a;
            a = temp;
        }

        private static long MeasureTime(Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}