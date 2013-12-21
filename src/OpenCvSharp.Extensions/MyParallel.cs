using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OpenCvSharp.Extensions
{
    /// <summary>
    /// Task Parallel Library for .NET 2.0
    /// </summary>
    internal static class MyParallel
    {
        /// <summary>
        /// Number of Threads
        /// </summary>
        private static readonly int NumThread = Environment.ProcessorCount;

        /// <summary>
        /// Executes a for loop in which iterations may run in parallel.
        /// </summary>
        /// <param name="fromInclusive">The start index, inclusive.</param>
        /// <param name="toExclusive">The end index, exclusive.</param>
        /// <param name="body">The delegate that is invoked once per iteration.</param>
        public static void For(int fromInclusive, int toExclusive, Action<int> body)
        {
            Thread[] threads = new Thread[NumThread];
            for (int i = 0; i < NumThread; i++)
            {
                threads[i] = new Thread(delegate(object arg)
                {
                    ForRange range = (ForRange)arg;
                    for (int j = range.Start; j < range.End; j++)
                    {
                        body(j);
                    }
                });
            }
            for (int i = 0; i < NumThread; i++)
                threads[i].Start(new ForRange(fromInclusive, toExclusive, i));
            for (int i = 0; i < NumThread; i++) 
                threads[i].Join();
        }

        private struct ForRange
        {
            public int Start;
            public int End;

            public ForRange(int fromInclusive, int toExclusive, int threadID)
            {
                Start = DividingPoint(fromInclusive, toExclusive, threadID);
                End = DividingPoint(fromInclusive, toExclusive, threadID + 1);
            }

            private static int DividingPoint(int fromInclusive, int toExclusive, int threadID)
            {
                return fromInclusive + (toExclusive - fromInclusive) * threadID / NumThread;
            }
        }
    }
}