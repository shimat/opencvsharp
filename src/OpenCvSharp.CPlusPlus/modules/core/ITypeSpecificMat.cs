using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    interface ITypeSpecificMat<out T> where T : struct
    {
        T[] ToArray();
    }
}
