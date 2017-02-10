using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Specifies the degree of rules validation. 
    /// </summary>
    /// <remarks>
    /// The enum specifies the degree of rules validation. This can be used, for example, to choose a proper way of input arguments validation.
    /// </remarks>
    public enum RulesOption : int
    {
        /// <summary>
        /// Validate each rule in a proper way.
        /// </summary>
        STRICT = 0x00,

        /// <summary>
        /// Skip validations of image borders.
        /// </summary>
        IGNORE_BORDERS = 0x01, 
    }
}