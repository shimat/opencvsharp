using System;

namespace OpenCvSharp
{
    partial class MatExpr 
    {
        /// <summary>
        /// Computes absolute value of each matrix element
        /// </summary>
        /// <returns></returns>
        public MatExpr Abs()
        {
            return Cv2.Abs(this);
        }
    }
}
