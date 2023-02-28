﻿using System;
using System.Drawing;
using System.IO;

namespace OpenCvSharp.DebuggerVisualizers
{
    /// <summary>
    /// シリアライズ不可能なクラスをやり取りするために使うプロキシ。
    /// 送る際に、このProxyに表示に必要なシリアライズ可能なデータを詰めて送り、受信側で復元する。
    /// </summary>
    [Serializable]
    public class MatProxy
    {
        public byte[] ImageData { get; private set; }

        public MatProxy(Mat image)
        {
            ImageData = image.ToBytes();
        }

        public Bitmap CreateBitmap()
        {
            if (ImageData is null)
                throw new Exception("ImageData is null");

            using (var stream = new MemoryStream(ImageData))
            {
                return new Bitmap(stream);
            }
        }
    }
}
