using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    static partial class Cv2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool InitModule_ML()
        {
            return NativeMethods.ml_initModule_ml() != 0;
        }
    }
}
