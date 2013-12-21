/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenCvSharp.Utilities
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
