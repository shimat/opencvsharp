using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public enum StructuringElementShape
    {       
        /// <summary>
        /// 
        /// </summary>
        Rect = CppConst.MORPH_RECT,
        /// <summary>
        /// 
        /// </summary>
        Cross = CppConst.MORPH_CROSS,
        /// <summary>
        /// 
        /// </summary>
        Ellipse = CppConst.MORPH_ELLIPSE,
    }
}
