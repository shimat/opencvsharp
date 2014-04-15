using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Mode of FileStorage operation.
    /// </summary>
    [Flags]
    public enum FileStorageMode
    {
        /// <summary>
        /// read mode
        /// </summary>
        Read = CppConst.FileStorage_READ, 

        /// <summary>
        /// write mode
        /// </summary>
        Write = CppConst.FileStorage_WRITE, 

        /// <summary>
        /// append mode
        /// </summary>
        Append = CppConst.FileStorage_APPEND, 

        /// <summary>
        /// 
        /// </summary>
        Memory = CppConst.FileStorage_MEMORY,
        /// <summary>
        /// 
        /// </summary>
        Mask = CppConst.FileStorage_FORMAT_MASK,
        /// <summary>
        /// 
        /// </summary>
        Auto = CppConst.FileStorage_FORMAT_AUTO,
        /// <summary>
        /// 
        /// </summary>
        Xml = CppConst.FileStorage_FORMAT_XML,
        /// <summary>
        /// 
        /// </summary>
        Yaml = CppConst.FileStorage_FORMAT_YAML,
    }
}
