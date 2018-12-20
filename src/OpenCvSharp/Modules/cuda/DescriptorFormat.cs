#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// TODO
    /// </summary>
    public enum DescriptorFormat 
    {
        /// <summary>
        /// 
        /// [HOGDescriptor::DESCR_FORMAT_ROW_BY_ROW]
        /// </summary>
        RowByRow = 0,

        /// <summary>
        /// 
        /// [HOGDescriptor::DESCR_FORMAT_COL_BY_COL]
        /// </summary>
        ColByCol = 1,
    }
}

#endif
