using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Algorithm Information
    /// </summary>
    public class AlgorithmInfo : ICvPtrHolder
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IntPtr ptr;

        /// <summary>
        /// 
        /// </summary>
        public AlgorithmInfo(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        public IntPtr CvPtr
        {
            get { return ptr; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                StringBuilder buf = new StringBuilder(1024);
                NativeMethods.core_AlgorithmInfo_name(ptr, buf, buf.Capacity);
                return buf.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ParamHelp(string name)
        {
            StringBuilder buf = new StringBuilder(4096);
            NativeMethods.core_AlgorithmInfo_paramHelp(ptr, name, buf, buf.Capacity);
            return buf.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetParams()
        {
            using (var namesVec = new VectorOfString())
            {
                NativeMethods.core_AlgorithmInfo_getParams(ptr, namesVec.CvPtr);
                return namesVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AlgorithmParamType ParamType(string name)
        {
            return (AlgorithmParamType)NativeMethods.core_AlgorithmInfo_paramType(ptr, name);
        }
    }
}
