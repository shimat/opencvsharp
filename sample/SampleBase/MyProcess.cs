using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SampleBase
{
    /// <summary>
    /// 
    /// </summary>
    public static class MyProcess
    {
        /// <summary>
        /// 物理メモリ使用量
        /// </summary>
        /// <returns></returns>
        public static long WorkingSet64
        {
            get
            {
                using (var proc = GetCurrentProcess())
                {
                    return proc.WorkingSet64;
                }
            }
        }

        /// <summary>
        /// 仮想メモリ使用量
        /// </summary>
        /// <returns></returns>
        public static long VirtualMemorySize64
        {
            get
            {
                using (var proc = GetCurrentProcess())
                {
                    return proc.VirtualMemorySize64;
                }
            }
        }

        /// <summary>
        /// 物理メモリ最大使用量
        /// </summary>
        /// <returns></returns>
        public static long PeakPagedMemorySize64
        {
            get
            {
                using (var proc = GetCurrentProcess())
                {
                    return proc.PeakPagedMemorySize64;
                }
            }
        }

        /// <summary>
        /// 仮想メモリ最大使用量
        /// </summary>
        /// <returns></returns>
        public static long PeakVirtualMemorySize64
        {
            get
            {
                using (var proc = GetCurrentProcess())
                {
                    return proc.PeakVirtualMemorySize64;
                }
            }
        }

        private static Process GetCurrentProcess()
        {
            var proc = Process.GetCurrentProcess();
            proc.Refresh();
            return proc;
        }
    }
}
