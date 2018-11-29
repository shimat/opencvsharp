using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Output string format of Mat.Dump()
    /// </summary>
    public enum FormatType
    {
        /// <summary>
        /// Default format. 
        /// [1, 2, 3, 4, 5, 6; \n
        /// 7, 8, 9, ... ]
        /// </summary>
        Default = 0,

        /// <summary>
        /// 
        /// </summary>
        MATLAB = 1,

        /// <summary>
        /// CSV format. 
        /// 1, 2, 3, 4, 5, 6\n
        /// 7, 8, 9, ...
        /// </summary>
        Csv = 2,

        /// <summary>
        /// Python format. 
        /// [[[1, 2, 3], [4, 5, 6]], \n
        /// [[7, 8, 9], ... ]
        /// </summary>
        Python = 3,

        /// <summary>
        /// NumPy format. 
        /// array([[[1, 2, 3], [4, 5, 6]], \n
        /// [[7, 8, 9], .... ]]], type='uint8');
        /// </summary>
        NumPy = 4,

        /// <summary>
        /// C language format. 
        /// {1, 2, 3, 4, 5, 6, \n
        /// 7, 8, 9, ...}; 
        /// </summary>
        C = 5,
    }
}
