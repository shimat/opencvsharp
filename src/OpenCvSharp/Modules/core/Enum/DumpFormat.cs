using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Output string format of Mat.Dump()
    /// </summary>
    public enum DumpFormat
    {
        /// <summary>
        /// Default format. 
        /// [1, 2, 3, 4, 5, 6; \n
        /// 7, 8, 9, ... ]
        /// </summary>
        Default,

        /// <summary>
        /// Python format. 
        /// [[[1, 2, 3], [4, 5, 6]], \n
        /// [[7, 8, 9], ... ]
        /// </summary>
        Python,

        /// <summary>
        /// NumPy format. 
        /// array([[[1, 2, 3], [4, 5, 6]], \n
        /// [[7, 8, 9], .... ]]], type='uint8');
        /// </summary>
        NumPy,

        /// <summary>
        /// CSV format. 
        /// 1, 2, 3, 4, 5, 6\n
        /// 7, 8, 9, ...
        /// </summary>
        Csv,

        /// <summary>
        /// C language format. 
        /// {1, 2, 3, 4, 5, 6, \n
        /// 7, 8, 9, ...}; 
        /// </summary>
        C,
    }
}
