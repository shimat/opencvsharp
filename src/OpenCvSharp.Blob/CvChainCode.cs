/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.Blob
{
    /// <summary>
    /// Chain code (direction)
    /// </summary>
    public enum CvChainCode : byte
    {
        /// <summary>
        /// Up.
        /// </summary>
        Up = CvBlobConst.CV_CHAINCODE_UP,
        /// <summary>
        /// Up and right.
        /// </summary>
        UpRight = CvBlobConst.CV_CHAINCODE_UP_RIGHT,
        /// <summary>
        /// Right.
        /// </summary>
        Right = CvBlobConst.CV_CHAINCODE_RIGHT,
        /// <summary>
        /// Down and right.
        /// </summary>
        DownRight = CvBlobConst.CV_CHAINCODE_DOWN_RIGHT,
        /// <summary>
        /// Down.
        /// </summary>
        Down = CvBlobConst.CV_CHAINCODE_DOWN,
        /// <summary>
        /// Down and left.
        /// </summary>
        DownLeft = CvBlobConst.CV_CHAINCODE_DOWN_LEFT,
        /// <summary>
        /// Left.
        /// </summary>
        Left = CvBlobConst.CV_CHAINCODE_LEFT,
        /// <summary>
        /// Up and left.
        /// </summary>
        UpLeft = CvBlobConst.CV_CHAINCODE_UP_LEFT,
    }
}