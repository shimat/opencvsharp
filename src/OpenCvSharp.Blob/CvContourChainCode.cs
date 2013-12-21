/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Chain code contour.
    /// </summary>
    public class CvContourChainCode : CvObject
    {
        #region Constructors
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvContourChainCode*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvContourChainCode*</param>
#endif
        public CvContourChainCode(IntPtr ptr)
        {
            _ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvContourChainCode*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvContourChainCode*</param>
#endif
        public static CvFileNode FromPtr(IntPtr ptr)
        {
            return new CvFileNode(ptr);
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvContourChainCode) 
        /// </summary>
        public static readonly int SizeOf = CvBlobInvoke.CvContourChainCode_sizeof();

        /// <summary>
        /// Point where contour begin.
        /// </summary>
        public CvPoint StartingPoint
        {
            get
            {
                return CvBlobInvoke.CvContourChainCode_startingPoint_get(_ptr);
            }
            set
            {
                CvBlobInvoke.CvContourChainCode_startingPoint_set(_ptr, value);
            }
        }

        /// <summary>
        /// Polygon description based on chain codes.
        /// </summary>
        public CvChainCodes ChainCode
        {
            get
            {
                IntPtr ptr = CvBlobInvoke.CvContourChainCode_chainCode_get(_ptr);
                return new CvChainCodes(ptr);
            }
        }
        #endregion

        #region Methods
        #region RenderContourChainCode
        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="img">Image to draw on.</param>
        public void RenderContourChainCode(IplImage img)
        {
            CvBlobLib.RenderContourChainCode(this, img);
        }
        /// <summary>
        /// Draw a contour.
        /// </summary>
        /// <param name="img">Image to draw on.</param>
        /// <param name="color">Color to draw (default, white).</param>
        public void RenderContourChainCode(IplImage img, CvScalar color)
        {
            CvBlobLib.RenderContourChainCode(this, img, color);
        }
        #endregion
        #region ConvertChainCodesToPolygon
        /// <summary>
        /// Convert a chain code contour to a polygon.
        /// </summary>
        /// <returns>A polygon.</returns>
        public CvContourPolygon ConvertChainCodesToPolygon()
        {
            return CvBlobLib.ConvertChainCodesToPolygon(this);
        }
        #endregion
        #endregion
    }
}
