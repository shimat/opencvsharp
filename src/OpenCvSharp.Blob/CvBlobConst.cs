﻿namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Constants which are defined by cvblob
    /// </summary>
    public static class CvBlobConst
    {
        // ReSharper disable InconsistentNaming

        #region RenderBlobsMode
            
#pragma warning disable CA1707
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
#pragma warning restore CA1707

        #endregion

        #region CvChainCode
        
#pragma warning disable CA1707
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
#pragma warning restore CA1707 

        /// <summary>
        /// Move vectors of chain codes.
        /// </summary>
        public static readonly sbyte[][] ChainCodeMoves = 
        {
            new sbyte[] {0, -1},
            new sbyte[] {1, -1},
            new sbyte[] {1, 0},
            new sbyte[] {1, 1},
            new sbyte[] {0, 1},
            new sbyte[] {-1, 1},
            new sbyte[] {-1, 0},
            new sbyte[] {-1, -1}
        };

        #endregion

        #region RenderTracksMode

#pragma warning disable CA1707 
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// Print the ID of each track in the image.
        /// </summary>
        public const ushort CV_TRACK_RENDER_ID = 0x0001;

        /// <summary>
        /// Draw bounding box of each track in the image. \see cvRenderTracks
        /// </summary>
        public const ushort CV_TRACK_RENDER_BOUNDING_BOX = 0x0002;

        /// <summary>
        /// Print track info to log out.
        /// </summary>
        public const ushort CV_TRACK_RENDER_TO_LOG = 0x0010;

        /// <summary>
        /// Print track info to log out.
        /// </summary>
        public const ushort CV_TRACK_RENDER_TO_STD = 0x0020;

        // ReSharper restore InconsistentNaming
#pragma warning restore CA1707

        #endregion
    }
}
