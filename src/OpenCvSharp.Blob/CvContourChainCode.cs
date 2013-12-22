using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Blob.Old;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// 
    /// </summary>
    public class CvContourChainCode
    {
        /// <summary>
        /// Point where contour begin.
        /// </summary>
        public CvPoint StartingPoint { get; set; }

        /// <summary>
        /// Polygon description based on chain codes.
        /// </summary>
        public List<CvChainCode> ChainCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CvContourChainCode()
        {
            StartingPoint = default(CvPoint);
            ChainCode = new List<CvChainCode>();
        }
    }
}
