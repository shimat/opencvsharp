using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// CvSeqのテスト
    /// </summary>
    class SeqTest
    {        
        public unsafe SeqTest()
        {
            using (CvMemStorage storage = new CvMemStorage(0))
            {
                Random rand = new Random();
                CvSeq<int> seq = new CvSeq<int>(SeqType.EltypeS32C1, storage);
                // push
                for (int i = 0; i < 10; i++)
                {
                    int push = seq.Push(rand.Next(100));//seq.Push(i);
                    Console.WriteLine("{0} is pushed", push);
                }
                Console.WriteLine("----------");

                // enumerate
                Console.WriteLine("contents of seq");
                foreach (int item in seq)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();

                // sort
                CvCmpFunc<int> func = delegate(int a, int b)
                {
                    return a.CompareTo(b);
                };
                seq.Sort(func);

                // convert to array
                int[] array = seq.ToArray();
                Console.WriteLine("contents of sorted seq");
                foreach (int item in array)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
                Console.WriteLine("----------");

                // pop
                for (int i = 0; i < 10; i++)
                {
                    int pop = seq.Pop();
                    Console.WriteLine("{0} is popped", pop);
                }
                Console.ReadKey();
            }
        }
    }
}
