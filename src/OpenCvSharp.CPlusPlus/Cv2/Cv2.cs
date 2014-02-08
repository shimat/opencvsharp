using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Cv2
    {
        /// <summary>
        /// 引数がnullの時はIntPtr.Zeroに変換する
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static IntPtr ToPtr(ICvPtrHolder obj)
        {
            return (obj == null) ? IntPtr.Zero : obj.CvPtr;
        }
    }
}
