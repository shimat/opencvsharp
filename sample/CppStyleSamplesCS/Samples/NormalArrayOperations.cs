using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class NormalArrayOperations : ISample
    {
        public void Run()
        {
            Threshold1();
            Threshold2();
            Threshold3();

            Console.Read();
        }

        /// <summary>
        /// Run thresholding to byte array 
        /// </summary>
        private void Threshold1()
        {
            const int T = 3;

            byte[] input = {1, 2, 3, 4, 5, };
            List<byte> output = new List<byte>();

            Cv2.Threshold(InputArray.Create(input), OutputArray.Create(output),
                T, 5, ThresholdType.Binary);

            Console.WriteLine("Threshold: {0}", T);
            Console.WriteLine("input:  {0}", String.Join(",", input));
            Console.WriteLine("output: {0}", String.Join(",", output));
        }

        /// <summary>
        /// Run thresholding to short array 
        /// </summary>
        private void Threshold2()
        {
            const int T = 150;

            short[] input = { 50, 100, 150, 200, 250, };
            List<short> output = new List<short>();

            Cv2.Threshold(InputArray.Create(input), OutputArray.Create(output),
                T, 250, ThresholdType.Binary);

            Console.WriteLine("Threshold: {0}", T);
            Console.WriteLine("input:  {0}", String.Join(",", input));
            Console.WriteLine("output: {0}", String.Join(",", output));
        }

        /// <summary>
        /// Run thresholding to struct array 
        /// </summary>
        private void Threshold3()
        {
            const int T = 3;

            Point[] input = { new Point(3, 5), new Point(1, 2), new Point(4,5), };
            List<Point> output = new List<Point>();

            Cv2.Threshold(InputArray.Create(input), OutputArray.Create(output),
                T, 5, ThresholdType.Binary);

            Console.WriteLine("Threshold: {0}", T);
            Console.WriteLine("input:  {0}", String.Join(",", input));
            Console.WriteLine("output: {0}", String.Join(",", output));
        }
    }
}