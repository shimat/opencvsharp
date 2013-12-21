using System;
using System.Collections.Generic;
using System.Text;

using CvLabel = System.UInt32;
using CvID = System.UInt32;

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Constants which are defined by cvblob
    /// </summary>
    public static class CvBlobConst
    {
        /// <summary>
        /// Size of a label in bits.
        /// </summary>
        public const BitDepth DepthLabel = (BitDepth)(sizeof(CvLabel) * 8);

        #region RenderBlobsMode
        /// <summary>
        /// Render each blog with a different color.
        /// </summary>
        public const ushort CV_BLOB_RENDER_COLOR = 0x0001;
        /// <summary>
        /// Render centroid.
        /// </summary>
        public const ushort CV_BLOB_RENDER_CENTROID = 0x0002;
        /// <summary>
        /// Render bounding box.
        /// </summary>
        public const ushort CV_BLOB_RENDER_BOUNDING_BOX = 0x0004;
        /// <summary>
        /// Render angle.
        /// </summary>
        public const ushort CV_BLOB_RENDER_ANGLE = 0x0008;
        /// <summary>
        ///  Print blob data to log out.
        /// </summary>
        public const ushort CV_BLOB_RENDER_TO_LOG = 0x0010;
        /// <summary>
        /// Print blob data to std out.
        /// </summary>
        public const ushort CV_BLOB_RENDER_TO_STD = 0x0020;
        #endregion
        #region CvChainCode
        /// <summary>
        /// Up.
        /// </summary>
        public const byte CV_CHAINCODE_UP = 0;
        /// <summary>
        /// Up and right.
        /// </summary>
        public const byte CV_CHAINCODE_UP_RIGHT = 1;
        /// <summary>
        /// Right.
        /// </summary>
        public const byte CV_CHAINCODE_RIGHT = 2;
        /// <summary>
        /// Down and right.
        /// </summary>
        public const byte CV_CHAINCODE_DOWN_RIGHT = 3;
        /// <summary>
        /// Down.
        /// </summary>
        public const byte CV_CHAINCODE_DOWN = 4;
        /// <summary>
        /// Down and left.
        /// </summary>
        public const byte CV_CHAINCODE_DOWN_LEFT = 5;
        /// <summary>
        /// Left.
        /// </summary>
        public const byte CV_CHAINCODE_LEFT = 6;
        /// <summary>
        /// Up and left.
        /// </summary>
        public const byte CV_CHAINCODE_UP_LEFT = 7;

        /// <summary>
        /// Move vectors of chain codes.
        /// </summary>
        public static readonly sbyte[][] cvChainCodeMoves = new sbyte[][]{
                    new sbyte[]{ 0, -1},
                    new sbyte[]{ 1, -1},
					new sbyte[]{ 1,  0},
					new sbyte[]{ 1,  1},
					new sbyte[]{ 0,  1},
					new sbyte[]{-1,  1},
					new sbyte[]{-1,  0},
					new sbyte[]{-1, -1}
        };
        #endregion
        #region RenderTracksMode
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// Print the ID of each track in the image.
        /// </summary>
        public const ushort CV_TRACK_RENDER_ID = 0x0001;
        /// <summary>
        /// Print track info to log out.
        /// </summary>
        public const ushort CV_TRACK_RENDER_TO_LOG = 0x0010;
        /// <summary>
        /// Print track info to log out.
        /// </summary>
        public const ushort CV_TRACK_RENDER_TO_STD = 0x0020;
        // ReSharper restore InconsistentNaming
        #endregion
    }
}
