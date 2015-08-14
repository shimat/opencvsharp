using System;
using System.Diagnostics;

namespace OpenCvSharp.Util
{
    /// <summary>
    /// Substitute of System.Action
    /// </summary>
    public delegate void Action();

    /// <summary>
    /// 
    /// </summary>
    public static class TimeMeasurer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TimeSpan Measure(Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.Elapsed;
        }
    }
}
