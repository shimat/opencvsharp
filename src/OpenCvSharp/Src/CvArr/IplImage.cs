using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// IPL 画像ヘッダ
    /// </summary>
#else
    /// <summary>
    /// IPL image header
    /// </summary>
#endif
    [Serializable]
    public class IplImage : CvArr, ICloneable, ISerializable
    { 
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 構造体分のメモリ領域を確保して初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public IplImage()
            : this(true)
        {
        }
#if LANG_JP
        /// <summary>
        /// sizeof(IplImage)の分のメモリの割り当てだけ行って、GC禁止設定で初期化
        /// </summary>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#else
        /// <summary>
        /// Allocates memory
        /// </summary>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#endif
        public IplImage(bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            ptr = AllocMemory(SizeOf);
        }

#if LANG_JP
        /// <summary>
        /// 画像ファイルから初期化
        /// </summary>
        /// <param name="fileName">ファイル名</param>
#else
        /// <summary>
        /// Loads an image from the specified file. 
        /// </summary>
        /// <param name="fileName">Name of file to be loaded. </param>
#endif
        public IplImage(string fileName)
            : this(fileName, LoadMode.Color)
        {
        }
#if LANG_JP
        /// <summary>
        /// 画像ファイルから初期化
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="flags">読み込む画像がカラー/グレースケールのどちらか，とビット深度を指定する</param>
        /// <returns>画像へのポインタ</returns>
#else
        /// <summary>
        /// Loads an image from the specified file. 
        /// </summary>
        /// <param name="fileName">Name of file to be loaded. </param>
        /// <param name="flags">Specifies colorness and Depth of the loaded image.</param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public IplImage(string fileName, LoadMode flags)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName)) 
                throw new FileNotFoundException(String.Format("Not found '{0}'", fileName), fileName);

            ptr = NativeMethods.cvLoadImage(fileName, flags);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create IplImage");
        }
#if LANG_JP
        /// <summary>
        /// 画像のヘッダを作成し，データ領域を確保する (cvCreateImage).
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像要素のビットデプス</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
#else
        /// <summary>
        /// Creates header and allocates data (cvCreateImage).
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Bit depth of image elements.</param>
        /// <param name="channels">Number of channels per element(pixel).</param>
#endif
        public IplImage(CvSize size, BitDepth depth, int channels)
        {
            ptr = NativeMethods.cvCreateImage(size, depth, channels);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create IplImage");
        }
#if LANG_JP
        /// <summary>
        /// 画像のヘッダを作成し，データ領域を確保する (cvCreateImage).
        /// </summary>
        /// <param name="width">画像の幅</param>
        /// <param name="height">画像の高さ</param>
        /// <param name="depth">画像要素のビットデプス</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
#else
        /// <summary>
        /// Creates header and allocates data (cvCreateImage).
        /// </summary>
        /// <param name="width">Image width. </param>
        /// <param name="height">Image height. </param>
        /// <param name="depth">Bit depth of image elements.</param>
        /// <param name="channels">Number of channels per element(pixel).</param>
#endif
        public IplImage(int width, int height, BitDepth depth, int channels)
            : this(new CvSize(width, height), depth, channels)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">IntPtr</param>
#else
        /// <summary>
        /// Initializes by native pointer (IplImage*)
        /// </summary>
        /// <param name="ptr">IntPtr</param>
#endif
        public IplImage(IntPtr ptr)
            : this(ptr, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタと自動解放の可否を指定して初期化
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        /// Initializes by native pointer (IplImage*)
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#endif
        public IplImage(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            this.ptr = ptr;
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        // C#で領域を確保したときを除外する
                        if (AllocatedMemory != IntPtr.Zero && AllocatedMemorySize != 0)
                        {
                        }
                        else
                        {
                            NativeMethods.cvReleaseImage(ref ptr);
                        }
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #region Static Initializers
        #region FromFile
#if LANG_JP
        /// <summary>
        /// 画像ファイルからIplImageを生成する
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from image file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
#endif
        public static IplImage FromFile(string fileName)
        {
            return FromFile(fileName, LoadMode.Color);
        }
#if LANG_JP
        /// <summary>
        /// 画像ファイルからIplImageを生成する.
        /// 初めにcvLoadImageでの読み込みを試み、失敗した場合はGDI+による読み込みを試みる
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from image file.
        /// First this function tries to use cvLoadImage. If failed, this function tries to use GDI+.  
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
#endif
        public static IplImage FromFile(string fileName, LoadMode flags)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);

            // cvLoadImageで画像読み込み
            IntPtr ptr = NativeMethods.cvLoadImage(fileName, flags);

            // 読み込み成功
            if (ptr != IntPtr.Zero)
            {
                return new IplImage(ptr);
            }

            byte[] fileBytes = File.ReadAllBytes(fileName);
            using (CvMat mat = new CvMat(fileBytes.Length, 1, MatrixType.S8C1, fileBytes))
            {
                return Cv.DecodeImage(mat, flags);
            }
            
            /*
            // 失敗した場合は、GDI+での読み込みを試みる
            try
            {
                // BitmapからIplImageに変換し、ポインタだけもらう
                using (Bitmap bitmap = new Bitmap(fileName))
                {
                    IplImage ipl1 = BitmapConverter.ToIplImage(bitmap);

                    // グレースケールにするはずが、なってない場合
                    if (flags == LoadMode.GrayScale && ipl1.NChannels != 1)
                    {
                        if (bitmap.PixelFormat == PixelFormat.Format24bppRgb ||
                            bitmap.PixelFormat == PixelFormat.Format32bppArgb)
                        {
                            IplImage ipl2 = new IplImage(ipl1.Size, BitDepth.U8, 1);
                            Cv.CvtColor(ipl1, ipl2, ColorConversion.BgrToGray);
                            ipl1.Dispose();
                            return ipl2;
                        }
                    }

                    // 色付きにするはずが、グレースケールになっている場合
                    if (flags == LoadMode.Color && ipl1.NChannels == 1)
                    {
                        IplImage ipl2 = new IplImage(ipl1.Size, BitDepth.U8, 3);
                        Cv.CvtColor(ipl1, ipl2, ColorConversion.GrayToBgr);
                        ipl1.Dispose();
                        return ipl2;
                    }

                    return ipl1;
                }
            }
            catch
            {
                throw new OpenCvSharpException("Failed to create IplImage");
            }
            //*/
        }
        #endregion
        #region FromImageData
#if LANG_JP
        /// <summary>
        /// 画像データ(JPEG等の画像をメモリに展開したもの)からIplImageを生成する (cvDecodeImage)
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from image data (using cvDecodeImage) 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static IplImage FromImageData(byte[] bytes, LoadMode mode)
        {
            if (bytes == null)
                throw new ArgumentNullException("bytes");
            
            using (CvMat mat = new CvMat(bytes.Length, 1, MatrixType.U8C1, bytes, false))
            {
                return Cv.DecodeImage(mat, mode);
            }
        }
        #endregion
        #region FromStream
#if LANG_JP
        /// <summary>
        /// System.IO.StreamのインスタンスからIplImageを生成する
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from System.IO.Stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static IplImage FromStream(Stream stream, LoadMode mode)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (stream.Length > Int32.MaxValue)
                throw new ArgumentException("Not supported stream (too long)");

            byte[] buf = new byte[stream.Length];
            {
                long currentPosition = stream.Position;
                stream.Position = 0;
                stream.Read(buf, 0, buf.Length);
                stream.Position = currentPosition;
            }
            return FromImageData(buf, mode);
        }
        #endregion
        #region FromPixelData
#if LANG_JP
        /// <summary>
        /// ピクセルデータのbyte配列からIplImageを生成する
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータの先頭ポインタ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pointer to the pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(CvSize size, int channels, IntPtr data)
        {
            return FromPixelData(size.Width, size.Height, channels, data);
        }
#if LANG_JP
        /// <summary>
        /// ピクセルデータのbyte配列からIplImageを生成する
        /// </summary>
        /// <param name="width">画像の幅</param>
        /// <param name="height">画像の高さ</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータの先頭ポインタ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="width">Image width. </param>
        /// <param name="height">Image height. </param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pointer to the pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(int width, int height, int channels, IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                throw new ArgumentNullException("data");
            }
            IplImage image = new IplImage(width, height, BitDepth.U8, channels);
            Util.CopyMemory(image.ImageData, data, image.ImageSize);
            return image;
        }
#if LANG_JP
        /// <summary>
        /// ピクセルデータのbyte配列からIplImageを生成する
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像要素のビットデプス</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータ配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Bit depth of image elements.</param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(CvSize size, BitDepth depth, int channels, Array data)
        {
            return FromPixelData(size.Width, size.Height, depth, channels, data);
        }
#if LANG_JP
        /// <summary>
        /// ピクセルデータの配列からIplImageを生成する
        /// </summary>
        /// <param name="width">画像の幅</param>
        /// <param name="height">画像の高さ</param>
        /// <param name="depth">画像要素のビットデプス</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータ配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="width">Image width. </param>
        /// <param name="height">Image height. </param>
        /// <param name="depth">Bit depth of image elements.</param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(int width, int height, BitDepth depth, int channels, Array data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            IplImage image = new IplImage(width, height, depth, channels);
            using (ScopedGCHandle handle = ScopedGCHandle.Alloc(data, GCHandleType.Pinned))
            {
                Util.CopyMemory(image.ImageData, handle.AddrOfPinnedObject(), image.ImageSize);
            }
            return image;
        }
#if LANG_JP
        /// <summary>
        /// ピクセルデータのbyte配列からIplImageを生成する
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータ配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(CvSize size, int channels, byte[] data)
        {
            return FromPixelData(size.Width, size.Height, channels, data);
        }
#if LANG_JP
        /// <summary>
        /// ピクセルデータのbyte配列からIplImageを生成する
        /// </summary>
        /// <param name="width">画像の幅</param>
        /// <param name="height">画像の高さ</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータ配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="width">Image width. </param>
        /// <param name="height">Image height. </param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(int width, int height, int channels, byte[] data)
        {
            return FromPixelData(width, height, BitDepth.U8, channels, data);
        }
#if LANG_JP
        /// <summary>
        /// ピクセルデータのbyte配列からIplImageを生成する
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータ配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(CvSize size, int channels, short[] data)
        {
            return FromPixelData(size.Width, size.Height, channels, data);
        }
#if LANG_JP
        /// <summary>
        /// ピクセルデータの配列からIplImageを生成する
        /// </summary>
        /// <param name="width">画像の幅</param>
        /// <param name="height">画像の高さ</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．</param>
        /// <param name="data">ピクセルデータ配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates an IplImage instance from pixel data
        /// </summary>
        /// <param name="width">Image width. </param>
        /// <param name="height">Image height. </param>
        /// <param name="channels">Number of channels per element(pixel).</param>
        /// <param name="data">Pixel data array</param>
        /// <returns></returns>
#endif
        public static IplImage FromPixelData(int width, int height, int channels, short[] data)
        {
            return FromPixelData(width, height, BitDepth.U16, channels, data);
        }
        #endregion
        #endregion
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(IplImage) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WIplImage));


        #region Native members
#if LANG_JP
        /// <summary>
        /// 画像の行のアライメント（4 あるいは 8）を取得する．
        /// OpenCV はこれを無視して，代わりに widthStep を使用する．
        /// </summary>
#else
        /// <summary>
        /// Alignment of image rows (4 or 8).
        /// OpenCV ignores it and uses widthStep instead
        /// </summary>
#endif
        [Obsolete]
        public int Align
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->align;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// OpenCVでは無視される．
        /// </summary>
#else
        /// <summary>
        /// Ignored by OpenCV
        /// </summary>
#endif
        [Obsolete]
        public int AlphaChannel
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->alphaChannel;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// OpenCVでは無視される．
        /// </summary>
#else
        /// <summary>
        /// Border completion mode, ignored by OpenCV
        /// </summary>
#endif
        [Obsolete]
        public IntPtr BorderMode
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->BorderMode);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// OpenCVでは無視される．
        /// </summary>
#else
        /// <summary>
        /// Ignored by OpenCV
        /// </summary>
#endif
        [Obsolete]
        public IntPtr BorderConst
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->BorderConst);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// OpenCVでは無視される．
        /// </summary>
#else
        /// <summary>
        /// Ignored by OpenCV
        /// </summary>
#endif
        [Obsolete]
        public IntPtr ColorModel
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->colorModel);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// OpenCVでは無視される．
        /// </summary>
#else
        /// <summary>
        /// Ignored by OpenCV
        /// </summary>
#endif
        [Obsolete]
        public IntPtr ChannelSeq
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->channelSeq);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 0 - インタリーブカラーチャンネル, 1 - 分離カラーチャンネル，
        /// cvCreateImage が作成できるのは，インタリーブ画像のみ
        /// </summary>
#else
        /// <summary>
        /// 0 - interleaved color channels, 1 - separate color channels.
        /// cvCreateImage can only create interleaved images
        /// </summary>
#endif
        public int DataOrder
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->dataOrder;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// ピクセルの色深度のビット数を取得する
        /// </summary>
#else
        /// <summary>
        /// Pixel Depth in bits
        /// </summary>
#endif
        public BitDepth Depth
        {
            get
            {
                unsafe
                {
                    return (BitDepth)(((WIplImage*)ptr)->depth);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 画像のピクセル高さを取得する
        /// </summary>
#else
        /// <summary>
        /// Image height in pixels
        /// </summary>
#endif
        public int Height
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->height;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// バージョン (=0) を取得する
        /// </summary>
#else
        /// <summary>
        /// version (=0)
        /// </summary>
#endif
        public int ID
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->ID;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// アライメントが調整された画像データへのポインタを取得する. これを通してピクセルデータにアクセスできる。
        /// 利用する際は System.Byte* にキャストすべし。
        /// </summary>
#else
        /// <summary>
        /// Pointer to aligned image data.
        /// You can access each pixel by this pointer casted as byte*. 
        /// </summary>
#endif
        public IntPtr ImageData
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->imageData);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// アライメントが調整された画像データへの, byte*にキャスト済みのポインタを取得する. これを通してピクセルデータにアクセスできる。
        /// </summary>
#else
        /// <summary>
        /// Pointer to aligned image data.
        /// </summary>
#endif
        public unsafe byte* ImageDataPtr
        {
            get
            {
                return ((WIplImage*)ptr)->imageData; 
            }
        }
#if LANG_JP
        /// <summary>
        /// オリジナル画像データへのポインタを取得する
        ///（アライメントが調整されているとは限らない）- これは画像を正しく解放するために必要．
        /// </summary>
#else
        /// <summary>
        /// Pointer to a very origin of image data (not necessarily aligned) -
        /// it is needed for correct image deallocation.
        /// </summary>
#endif
        public IntPtr ImageDataOrigin
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->imageDataOrigin);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 画像データのバイトサイズを取得する
        /// (インタリーブデータの場合は，=image->height*image->widthStep）
        /// </summary>
#else
        /// <summary>
        /// image data size in bytes (=image->height*image->widthStep in case of interleaved data)
        /// </summary>
#endif
        public int ImageSize
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->imageSize;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// OpenCVでは必ずNULL
        /// </summary>
#else
        /// <summary>
        /// Must be NULL in OpenCV
        /// </summary>
#endif
        [Obsolete]
        public IntPtr MaskROI
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->maskROI);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// チャンネル数をを取得する. OpenCV のほとんどの関数が，1,2,3および4チャンネルをサポートする
        /// </summary>
#else
        /// <summary>
        /// Most of OpenCV functions support 1,2,3 or 4 channels
        /// </summary>
#endif
        public int NChannels
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->nChannels;
                }
            }
        }
        /// <summary>
        /// sizeof(IplImage)
        /// </summary>
        public int NSize
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->nSize;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 画像の原点をを取得する. 
        /// 0 - 左上原点，1 - 左下原点（Windowsのビットマップ形式）
        /// </summary>
#else
        /// <summary>
        /// 0 - top-left origin,
        /// 1 - bottom-left origin (Windows bitmaps style)
        /// </summary>
#endif
        public ImageOrigin Origin
        {
            get
            {
                unsafe
                {
                    return (ImageOrigin)(((WIplImage*)ptr)->origin);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 画像 ROI の矩形のポインタを取得する
        /// </summary>
#else
        /// <summary>
        /// image ROI. when it is not NULL, this specifies image region to process
        /// </summary>
#endif
        public IntPtr ROIPointer
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->roi);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 画像 ROI の矩形のポインタを取得する
        /// </summary>
#else
        /// <summary>
        /// image ROI. when it is not NULL, this specifies image region to process
        /// </summary>
#endif
        public IplROI ROIValue
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(((WIplImage*)ptr)->roi);
                    return (IplROI)Marshal.PtrToStructure(p, typeof(IplROI));
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 画像のピクセル幅を取得する
        /// </summary>
#else
        /// <summary>
        /// Image width in pixels
        /// </summary>
#endif
        public int Width
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->width;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// アライメントが調整された画像の行のバイトサイズを取得する
        /// </summary>
#else
        /// <summary>
        /// Size of aligned image row in bytes
        /// </summary>
#endif
        public int WidthStep
        {
            get
            {
                unsafe
                {
                    return ((WIplImage*)ptr)->widthStep;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// OpenCVでは必ずNULL
        /// </summary>
#else
        /// <summary>
        /// Must be NULL in OpenCV
        /// </summary>
#endif
        public IntPtr TileInfo
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WIplImage*)ptr)->tileInfo);
                }
            }
        }
        #endregion

#if LANG_JP
        /// <summary>
        /// 画像のサイズを取得する(ROIのサイズではなく、元々のサイズ)
        /// </summary>
#else
        /// <summary>
        /// Gets size of the original image
        /// </summary>
#endif
        public CvSize Size
        {
            get
            {
                unsafe
                {
                    WIplImage* s = (WIplImage*)ptr;
                    return new CvSize(s->width, s->height);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// COI (channel of interest)を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets/Sets COI (cvGetImageCOI/cvSetImageCOI)
        /// </summary>
#endif
        public int COI
        {
            get { return Cv.GetImageCOI(this); }
            set { Cv.SetImageCOI(this, value); }
        }
#if LANG_JP
        /// <summary>
        /// 画像 ROI の矩形を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets/Sets ROI (cvGetImageROI/cvSetImageROI)
        /// </summary>
#endif
        public CvRect ROI
        {
            get { return Cv.GetImageROI(this); }
            set { Cv.SetImageROI(this, value); }
        }
#if LANG_JP
        /// <summary>
        /// 配列の次元数を取得する (2固定)
        /// </summary>
#else
        /// <summary>
        /// Gets number of dimensions (=2)
        /// </summary>
#endif
        public override Int32 Dims
        {
            get { return 2; }
        }
#if LANG_JP
        /// <summary>
        /// 画像の色深度 (Bits per pixel)
        /// </summary>
#else
        /// <summary>
        /// Bits per pixel
        /// </summary>
#endif
        public int Bpp
        {
            get
            {
                unsafe
                {
                    WIplImage* s = (WIplImage*)ptr;
                    return (s->depth & 255) * s->nChannels;
                }
            }
        }
        #endregion

        #region Operators
#if LANG_JP
        /// <summary>
        /// 行列の単項+演算子
        /// </summary>
        /// <param name="a">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="a">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator +(IplImage a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            return a.Clone();
        }
#if LANG_JP
        /// <summary>
        /// 行列の単項-演算子
        /// </summary>
        /// <param name="a">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Unary negation operator
        /// </summary>
        /// <param name="a">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator -(IplImage a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.AddWeighted(a, -1, a, 0, 0, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列の単項not演算子
        /// </summary>
        /// <param name="a">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Logical nagation operator
        /// </summary>
        /// <param name="a">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator ~(IplImage a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.Not(a, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列の加算演算子。cvAddにより加算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary plus operator (cvAdd)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator +(IplImage a, IplImage b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            IplImage result = a.Clone();
            Cv.Add(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの加算演算子。cvAddSにより加算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary plus operator (cvAddS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static IplImage operator +(IplImage a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.AddS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列の減算演算子。cvSubにより減算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary negation operator (cvSub)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator -(IplImage a, IplImage b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            IplImage result = a.Clone();
            Cv.Sub(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの減算演算子。cvSubSにより加算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Binary negation operator (cvSub)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static IplImage operator -(IplImage a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.SubS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列の乗算演算子。cvMatMulにより乗算する。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Multiplicative operator (cvMatMul)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator *(IplImage a, IplImage b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (a.ElemType != b.ElemType)
                throw new ArgumentException("a.ElemType must equal to b.ElemType");
            if (a.Width != b.Height)
                throw new ArgumentException("a.Width must equal to b.Height");

            IplImage result = new IplImage( b.Width, a.Height, a.Depth, a.NChannels);
            Cv.MatMul(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの乗算演算子。aの要素ごとにbをかけた結果をcvAddWeightedにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Multiplicative operator (cvAddWeighted)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static IplImage operator *(IplImage a, Double b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.AddWeighted(a, b, a, 0, 0, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの除算演算子。aの要素ごとにbで割った結果をcvAddWeightedにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Division operator (cvAddWeighted)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static IplImage operator /(IplImage a, double b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (Math.Abs(b - 0) < 1e-15)
                throw new DivideByZeroException();

            IplImage result = a.Clone();
            Cv.AddWeighted(a, 1.0 / b, a, 0, 0, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列のand演算子。cvAndにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise AND operator (cvAnd)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator &(IplImage a, IplImage b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            IplImage result = a.Clone();
            Cv.And(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーのand演算子。cvAndSにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise AND operator (cvAndS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static IplImage operator &(IplImage a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.AndS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列のor演算子。cvOrにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise OR operator (cvOr)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator |(IplImage a, IplImage b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            IplImage result = a.Clone();
            Cv.Or(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーのor演算子。cvOrSにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise OR operator (cvOrS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static IplImage operator |(IplImage a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.OrS(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列と行列のxor演算子。cvXorにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise XOR operator (cvXor)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static IplImage operator ^(IplImage a, IplImage b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            IplImage result = a.Clone();
            Cv.Xor(a, b, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーのxor演算子。cvXorSにより求める。
        /// </summary>
        /// <param name="a">行列</param>
        /// <param name="b">スカラー</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bitwise XOR operator (cvXorS)
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="b">scalar</param>
        /// <returns></returns>
#endif
        public static IplImage operator ^(IplImage a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            IplImage result = a.Clone();
            Cv.XorS(a, b, result);
            return result;
        }
        #endregion

        #region Methods
        #region CheckChessboard
#if LANG_JP
        /// <summary>
        /// チェスボードが画像中にあるかどうかを高速に判定する。
        /// チェスボードが無い画像でcvFindChessboardCornersが遅くなる問題への対処として利用できる。
        /// </summary>
        /// <param name="size">チェスボードのサイズ</param>
        /// <returns>1のときは、チェスボードが画像中に存在し、cvFindChessboardCornersを呼び出せる。
        /// 0のときはチェスボードが存在しない。-1はエラーを示す。</returns>
#else
        /// <summary>
        /// Performs a fast check if a chessboard is in the input image. 
        /// This is a workaround to a problem of cvFindChessboardCorners being slow on images with no chessboard
        /// </summary>
        /// <param name="size">chessboard size</param>
        /// <returns>Returns 1 if a chessboard can be in this image and findChessboardCorners should be called, 
        /// 0 if there is no chessboard, -1 in case of error</returns>
#endif
        public int CheckChessboard(CvSize size)
        {
            return Cv.CheckChessboard(this, size);
        }
        #endregion
        #region Clone
#if LANG_JP
        /// <summary>
        /// ヘッダ，ROI，データを含む画像の完全なコピーを作成する． 
        /// </summary>
        /// <returns>コピーされた画像</returns>
#else
        /// <summary>
        /// Makes a full copy of image
        /// </summary>
        /// <returns></returns>
#endif
        public IplImage Clone()
        {
            return Cv.CloneImage(this);
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

#if LANG_JP
        /// <summary>
        /// 指定した矩形領域を切り出した、画像の完全なコピーを作成する． 
        /// </summary>
        /// <returns>コピーされた画像</returns>
#else
        /// <summary>
        /// Makes a full copy of image
        /// </summary>
        /// <returns></returns>
#endif
        public IplImage Clone(CvRect roi)
        {
            if(roi.X < 0 || roi.Y < 0 || (roi.X + roi.Width) > Width || (roi.Y + roi.Height) > Height)
                throw new ArgumentException("roi is out of image size", "roi");
            if(roi.X == 0 && roi.Y == 0 && roi.Size == Size)
                return Cv.CloneImage(this);

            IplImage ret = new IplImage(roi.Size, Depth, NChannels);
            CvRect currentRoi = ROI;
            SetROI(roi);
            Cv.Copy(this, ret);
            SetROI(currentRoi);
            return ret;
        }
        #endregion
        #region EmptyClone
#if LANG_JP
        /// <summary>
        /// このIplImageと同じサイズ・ビット深度・チャネル数を持つ
        /// IplImageオブジェクトを新たに作成し、返す
        /// </summary>
        /// <returns>コピーされた画像</returns>
#else
        /// <summary>
        /// Makes an image that have the same size, depth and channels as this image
        /// </summary>
        /// <returns></returns>
#endif
        public IplImage EmptyClone()
        {
            return new IplImage(Size, Depth, NChannels);
        }
        #endregion
        #region CreateHeader
#if LANG_JP
        /// <summary>
        /// メモリ確保と初期化を行い，IplImage クラスを返す (cvCreateImageHeader).
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像要素のビットデプス</param>
        /// <param name="channels">要素（ピクセル）毎のチャンネル数．1,2,3,4 のいずれか．このチャンネルはインタリーブされる．例えば，通常のカラー画像のデータレイアウトは，b0 g0 r0 b1 g1 r1 ...となっている．</param>
        /// <returns>画像ポインタ</returns>
#else
        /// <summary>
        /// Allocates, initializes, and returns structure IplImage (cvCreateImageHeader).
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <returns>Reference to image header</returns>
#endif
        public static IplImage CreateHeader(CvSize size, BitDepth depth, int channels)
        {
            return Cv.CreateImageHeader(size, depth, channels);
        }
        #endregion
        #region DeleteMoire
#if LANG_JP
        /// <summary>
        /// 入力画像のモアレを削除する
        /// </summary>
#else
        /// <summary>
        /// Deletes moire in given image
        /// </summary>
#endif
        public void DeleteMoire()
        {
            Cv.DeleteMoire(this);
        }
        #endregion
        #region FindFace
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        public CvSeq<CvFaceData> FindFace(CvMemStorage storage)
        {
            return Cv.FindFace(this, storage);
        }
        #endregion
        #region GetCOI
#if LANG_JP
        /// <summary>
        /// 画像の COI（channel of interest）を返す.
        /// 全チャンネルが選択される場合には，0 が返される）．
        /// </summary>
        /// <returns>COI（channel of interest）を返す（全チャンネルが選択される場合には，0 が返される）.</returns>
#else
        /// <summary>
        /// Returns index of channel of interest
        /// </summary>
        /// <returns>channel of interest of the image (it returns 0 if all the channels are selected)</returns>
#endif
        public int GetCOI()
        {
            return Cv.GetImageCOI(this);
        }
        #endregion
        #region GetROI
#if LANG_JP
        /// <summary>
        /// 画像の ROI 座標を返す (cvGetImageROI)．
        /// ROI が存在しない場合には，矩形 cvRect(0,0,image.Width,image.Height) が返される．
        /// </summary>
        /// <returns>ROI</returns> 
#else
        /// <summary>
        /// Returns image ROI coordinates (cvGetImageROI).
        /// The rectangle cvRect(0,0,image.Width,image.Height) is returned if there is no ROI.
        /// </summary>
        /// <returns></returns>
#endif
        public CvRect GetROI()
        {
            return Cv.GetImageROI(this);
        }
        #endregion
        #region GetDataStream
#if LANG_JP
        /// <summary>
        /// dataポインタを指すStreamを取得する (返却値は要Close)
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns stream that indicates data pointer.
        /// (The return value must be closed manually)
        /// </summary>
        /// <returns></returns>
#endif
        public UnmanagedMemoryStream GetDataStream(string ext, int[] prms)
        {
            unsafe
            {
                return new UnmanagedMemoryStream(ImageDataPtr, Width * Height);
            }
        }
        #endregion
        #region InitImageHeader
#if LANG_JP
        /// <summary>
        /// ユーザから渡された参照が指す, ユーザによって確保された画像のヘッダ構造体を初期化し，その参照を返す (cvInitImageHeader).
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像のカラーデプス</param>
        /// <param name="channels">チャンネル数</param>
        /// <returns>初期化された画像ヘッダ</returns>
#else
        /// <summary>
        /// Initializes allocated by user image header (cvInitImageHeader).
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <returns>Initialzed IplImage header</returns>
#endif
        public static IplImage InitImageHeader(CvSize size, BitDepth depth, int channels)
        {
            IplImage img;
            return Cv.InitImageHeader(out img, size, depth, channels);
        }
#if LANG_JP
        /// <summary>
        /// ユーザから渡された参照が指す, ユーザによって確保された画像のヘッダ構造体を初期化し，その参照を返す (cvInitImageHeader).
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像のカラーデプス</param>
        /// <param name="channels">チャンネル数</param>
        /// <param name="origin">初期化される画像ヘッダ</param>
        /// <returns>初期化された画像ヘッダ</returns>
#else
        /// <summary>
        /// Initializes allocated by user image header (cvInitImageHeader).
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <param name="origin">Origin of image</param>
        /// <returns>Initialzed IplImage header</returns>
#endif
        public static IplImage InitImageHeader(CvSize size, BitDepth depth, int channels, ImageOrigin origin)
        {
            IplImage img;
            return Cv.InitImageHeader(out img, size, depth, channels, origin);
        }
#if LANG_JP
        /// <summary>
        /// ユーザから渡された参照が指す, ユーザによって確保された画像のヘッダ構造体を初期化し，その参照を返す (cvInitImageHeader).
        /// </summary>
        /// <param name="size">画像の幅と高さ</param>
        /// <param name="depth">画像のカラーデプス</param>
        /// <param name="channels">チャンネル数</param>
        /// <param name="origin">初期化される画像ヘッダ</param>
        /// <param name="align">画像の行のアライメント，通常は4，あるいは 8 バイト．</param>
        /// <returns>初期化された画像ヘッダ</returns>
#else
        /// <summary>
        /// Initializes allocated by user image header (cvInitImageHeader).
        /// </summary>
        /// <param name="size">Image width and height. </param>
        /// <param name="depth">Image depth. </param>
        /// <param name="channels">Number of channels. </param>
        /// <param name="origin">Origin of image</param>
        /// <param name="align">Alignment for image rows, typically 4 or 8 bytes. </param>
        /// <returns>Initialzed IplImage header</returns>
#endif
        public static IplImage InitImageHeader(CvSize size, BitDepth depth, int channels, ImageOrigin origin, int align)
        {
            IplImage img;
            return Cv.InitImageHeader(out img, size, depth, channels, origin, align);
        }
        #endregion
        #region PostBoostingFindFace
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        public CvSeq<CvFaceData> PostBoostingFindFace(CvMemStorage storage)
        {
            return Cv.PostBoostingFindFace(this, storage);
        }
        #endregion
        #region PyrSegmentation
#if LANG_JP
        /// <summary>
        /// 画像ピラミッドによる画像のセグメント化を実装する．ピラミッドは，levelまで作成する．(out引数のcompがいらないときバージョン)
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="level">セグメント化のためのピラミッドの最大レベル</param>
        /// <param name="threshold1">リンク構築のための誤差閾値</param>
        /// <param name="threshold2">セグメントクラスタリングのための誤差閾値</param>
#else
        /// <summary>
        /// Does image segmentation by pyramids.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="level"></param>
        /// <param name="threshold1"></param>
        /// <param name="threshold2"></param>
#endif
        public void PyrSegmentation(IplImage dst, int level, double threshold1, double threshold2)
        {
            Cv.PyrSegmentation(this, dst, level, threshold1, threshold2);
        }
#if LANG_JP
        /// <summary>
        /// 画像ピラミッドによる画像のセグメント化を実装する． ピラミッドは，levelまで作成する． 
        /// </summary>
        /// <param name="dst">出力画像</param>
        /// <param name="storage">結果として得られる連結成分のシーケンスを保存するための領域</param>
        /// <param name="comp">セグメント化された成分の出力シーケンスへのポインタ</param>
        /// <param name="level">セグメント化のためのピラミッドの最大レベル</param>
        /// <param name="threshold1">リンク構築のための誤差閾値</param>
        /// <param name="threshold2">セグメントクラスタリングのための誤差閾値</param>
#else
        /// <summary>
        /// Does image segmentation by pyramids.
        /// </summary>
        /// <param name="dst">The destination image. </param>
        /// <param name="storage">Storage; stores the resulting sequence of connected components. </param>
        /// <param name="comp">Pointer to the output sequence of the segmented components. </param>
        /// <param name="level">Maximum level of the pyramid for the segmentation. </param>
        /// <param name="threshold1">Error threshold for establishing the links. </param>
        /// <param name="threshold2">Error threshold for the segments clustering. </param>
#endif
        public void PyrSegmentation(IplImage dst, CvMemStorage storage, out CvSeq comp, int level, double threshold1, double threshold2)
        {
            Cv.PyrSegmentation(this, dst, storage, out comp, level, threshold1, threshold2);
        }
        #endregion
        #region ResetROI
#if LANG_JP
        /// <summary>
        /// 画像の ROI を解放する．解放後は全画像が選択されている状態と同じになる (cvResetImageROI)．
        /// </summary>
#else
        /// <summary>
        /// Releases image ROI. After that the whole image is considered selected (cvResetImageROI). 
        /// </summary>
#endif
        public void ResetROI()
        {
            Cv.ResetImageROI(this);
        }
        #endregion
        #region SetCOI
#if LANG_JP
        /// <summary>
        /// 与えられた値を channel of interest（COI）としてセットする (cvSetImageCOI).
        /// 値 0 は全てのチャンネルが選択されている事を意味し，値 1 は最初のチャンネルが選択されている事を意味する．
        /// </summary>
        /// <param name="coi">COI（Channel of interest）</param>
#else
        /// <summary>
        /// Sets channel of interest to given value (cvSetImageCOI).
        /// Value 0 means that all channels are selected, 1 means that the first channel is selected etc.
        /// </summary>
        /// <param name="coi">Channel of interest. </param>
#endif
        public void SetImageCOI(int coi)
        {
            Cv.SetImageCOI(this, coi);
        }
        #endregion
        #region SetROI
#if LANG_JP
        /// <summary>
        /// 与えられた矩形を画像の ROI としてセットする (cvSetImageROI)．
        /// </summary>
        /// <param name="rect">ROI を表す矩形</param>
#else
        /// <summary>
        /// Sets image ROI to given rectangle (cvSetImageROI).
        /// </summary>
        /// <param name="rect">ROI rectangle. </param>
#endif
        public void SetROI(CvRect rect)
        {
            Cv.SetImageROI(this, rect);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた矩形を画像の ROI としてセットする (cvSetImageROI)．
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
#else
        /// <summary>
        /// Sets image ROI to given rectangle (cvSetImageROI).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
#endif
        public void SetROI(int x, int y, int width, int height)
        {
            Cv.SetImageROI(this, new CvRect(x, y, width, height));
        }
        #endregion
        #region SnakeImage
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weight of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weight of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weight of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
#endif
        public void SnakeImage(CvPoint[] points, float alpha, float beta, float gamma, CvSize win, CvTermCriteria criteria)
        {
            Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria);
        }
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
        /// <param name="calcGradient">勾配フラグ．trueの場合，この関数は全ての画像ピクセルに対する勾配の強さを計算し，これをエネルギー場と見なす． falseの場合は，入力画像自体がエネルギー場と見なされる．</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weight of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weight of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weight of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
        /// <param name="calcGradient">Gradient flag. If true, the function calculates gradient magnitude for every image pixel and consideres it as the energy field, otherwise the input image itself is considered. </param>
#endif
        public void SnakeImage(CvPoint[] points, float alpha, float beta, float gamma, CvSize win, CvTermCriteria criteria, bool calcGradient)
        {
            Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria, calcGradient);
        }
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weights of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weights of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weights of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
#endif
        public void SnakeImage(CvPoint[] points, float[] alpha, float[] beta, float[] gamma, CvSize win, CvTermCriteria criteria)
        {
            Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria);
        }
#if LANG_JP
        /// <summary>
        /// 内部エネルギーと外部エネルギーの総和が最小になるように snake を更新する． 
        /// 内部エネルギーは輪郭形状に依存する（滑らかな輪郭ほど内部エネルギーが小さい）．
        /// 外部エネルギーはエネルギー場に依存し，画像勾配の場合は画像のエッジに対応するような局所的なエネルギー極小値において最小になる.
        /// </summary>
        /// <param name="points">輪郭点. ここに格納されている点をもとに計算をし、結果もここに入る</param>
        /// <param name="alpha">連続エネルギーの重み．pointsと同じ長さを持つ浮動小数点型配列（各輪郭点に配列の各要素が対応）．</param>
        /// <param name="beta">曲率エネルギーの重み．alpha と同様．</param>
        /// <param name="gamma">画像エネルギーの重み．alpha と同様．</param>
        /// <param name="win">最小値を探索する各点の近傍のサイズ． Width と Height は奇数でなければならない．</param>
        /// <param name="criteria">終了条件</param>
        /// <param name="calcGradient">勾配フラグ．trueの場合，この関数は全ての画像ピクセルに対する勾配の強さを計算し，これをエネルギー場と見なす． falseの場合は，入力画像自体がエネルギー場と見なされる．</param>
#else
        /// <summary>
        /// Changes contour position to minimize its energy
        /// </summary>
        /// <param name="points">Contour points (snake). </param>
        /// <param name="alpha">Weights of continuity energy, single float or array of length floats, one per each contour point. </param>
        /// <param name="beta">Weights of curvature energy, similar to alpha. </param>
        /// <param name="gamma">Weights of image energy, similar to alpha. </param>
        /// <param name="win">Size of neighborhood of every point used to search the minimum, both win.width and win.height must be odd. </param>
        /// <param name="criteria">Termination criteria. </param>
        /// <param name="calcGradient">Gradient flag. If true, the function calculates gradient magnitude for every image pixel and consideres it as the energy field, otherwise the input image itself is considered. </param>
#endif
        public void SnakeImage(CvPoint[] points, float[] alpha, float[] beta, float[] gamma, CvSize win, CvTermCriteria criteria, bool calcGradient)
        {
            Cv.SnakeImage(this, points, alpha, beta, gamma, win, criteria, calcGradient);
        }
        #endregion
        #region Split
#if LANG_JP
        /// <summary>
        /// マルチチャンネルの配列を，複数のシングルチャンネルの配列に分割する．
        /// </summary>
        /// <returns>各チャンネルごとの配列</returns>
#else
        /// <summary>
        /// Divides multi-channel array into several single-channel arrays
        /// </summary>
        /// <returns></returns>
#endif
        public IplImage[] Split()
        {
            List<IplImage> c = new List<IplImage>(4);

            int w = ROI.Width;
            int h = ROI.Height;

            for (int i = 1; i <= 4; i++)
            {
                if (i <= NChannels)
                {
                    c.Add(new IplImage(w, h, Depth, 1));
                }
                else
                {
                    c.Add(null);
                }
            }
            Cv.Split(this, c[0], c[1], c[2], c[3]);

            c.RemoveAll(delegate(IplImage obj) { return obj == null; });

            return c.ToArray();
        }
        #endregion
        #region Transpose
#if LANG_JP
        /// <summary>
        /// 行列の転置を行う.
        /// </summary>
#else
        /// <summary>
        /// Transposes matrix
        /// </summary>
#endif
        public IplImage Transpose()
        {
            IplImage result = new IplImage(Height, Width, Depth, NChannels);
            Cv.Transpose(this, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列の転置を行う.
        /// </summary>
#else
        /// <summary>
        /// Transposes matrix
        /// </summary>
#endif
        public IplImage T()
        {
             return Transpose();
        }
        #endregion

        #region CopyPixelData
#if LANG_JP
        /// <summary>
        /// この画像にピクセルデータをコピーする
        /// </summary>
        /// <param name="data">ピクセルデータ配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Copies pixel data to this image
        /// </summary>
        /// <param name="data">Pixel data array</param>
        /// <returns></returns>
#endif
        public void CopyPixelData(Array data)
        {         
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            using (ScopedGCHandle handle = ScopedGCHandle.Alloc(data, GCHandleType.Pinned))
            {
                CopyPixelData(handle.AddrOfPinnedObject());
            }
        }
#if LANG_JP
        /// <summary>
        /// この画像にピクセルデータをコピーする
        /// </summary>
        /// <param name="data">ピクセルデータの先頭ポインタ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Copies pixel data to this image
        /// </summary>
        /// <param name="data">Pointer to the pixel data array</param>
        /// <returns></returns>
#endif
        public void CopyPixelData(IntPtr data)
        {
            if (data == IntPtr.Zero)
            {
                throw new ArgumentNullException("data");
            }
            Util.CopyMemory(ImageData, data, ImageSize);
        }
        #endregion    
        #region GetSubImage
#if LANG_JP
        /// <summary>
        /// 画像の一部分を切り取った新しい画像を生成して返す.
        /// (使い終わったら解放が必要)
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
#endif
        public IplImage GetSubImage(CvRect rect)
        {
            if (rect.Width < 0)
                throw new ArgumentException();
            if (rect.Height < 0)
                throw new ArgumentException();

            if (rect.X + rect.Width >= Width)
                rect.Width = Width - rect.X - 1;
            if (rect.Y + rect.Height >= Height)
                rect.Height = Height - rect.Y - 1;
            if (rect.X < 0)
            {
                rect.Width += rect.X;
                rect.X = 0;
            }
            if (rect.Y < 0)
            {
                rect.Height += rect.Y;
                rect.Y = 0;
            }

            IplImage imgDst = new IplImage(rect.Size, Depth, NChannels);
            
            SetROI(rect);
            Cv.Copy(this, imgDst);
            ResetROI();

            return imgDst;
        }
        #endregion

        #region DrawImage
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <param name="image"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi"></param>
        /// <param name="image"></param>
#endif
        public void DrawImage(CvRect roi, CvArr image)
        {
            CvRect currentROI = Cv.GetImageROI(this);
            Cv.SetImageROI(this, roi);
            Cv.Copy(image, this);
            Cv.SetImageROI(this, currentROI);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="image"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="image"></param>
#endif
        public void DrawImage(int x, int y, int width, int height, CvArr image)
        {
            DrawImage(new CvRect(x, y, width, height), image);
        }
        #endregion
        #endregion

        #region ISerializable
#if LANG_JP
        /// <summary>
        /// SerializationInfo に、オブジェクトをシリアル化するために必要なデータを設定します。 
        /// </summary>
        /// <param name="info">データを読み込む先の SerializationInfo。</param>
        /// <param name="context">このシリアル化のシリアル化先。 </param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data. </param>
        /// <param name="context">The destination for this serialization. </param>
#endif
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Size", Size);
            info.AddValue("Depth", Depth);
            info.AddValue("ROI", ROI);
            info.AddValue("COI", COI);
            info.AddValue("NChannels", NChannels);

            // ピクセルデータのシリアライズ処理
            // 一気に読み込まず、少しずつ読み込み、gzipで圧縮
            const int WriteLength = 1024 * 512;
            byte[] buffer = new byte[WriteLength];
            using (MemoryStream ms = new MemoryStream())
            using (DeflateStream gzs = new DeflateStream(ms, CompressionMode.Compress))
            {
                for (int offset = 0; offset < ImageSize; offset += WriteLength)
                {
                    int length = (offset + WriteLength < ImageSize) ? WriteLength : ImageSize - offset;
                    IntPtr p = new IntPtr(ImageData.ToInt64() + offset);
                    Marshal.Copy(p, buffer, 0, length);
                    gzs.Write(buffer, 0, length);
                }
                info.AddValue("ImageData", ms.ToArray());
            }
        }
#if LANG_JP
        /// <summary>
        /// シリアライズ化の際の初期化
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
#endif
        protected IplImage(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            CvSize size = (CvSize)info.GetValue("Size", typeof(CvSize));
            BitDepth depth = (BitDepth)info.GetValue("Depth", typeof(BitDepth));
            int nChannels = info.GetInt32("NChannels");
            CvRect roi = (CvRect)info.GetValue("ROI", typeof(CvRect));
            int coi = info.GetInt32("COI");

            byte[] imageData = (byte[])info.GetValue("ImageData", typeof(byte[]));

            // 画像領域を準備
            ptr = NativeMethods.cvCreateImage(size, depth, nChannels);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create IplImage");
            
            ROI = roi;
            COI = coi;

            // 圧縮されたピクセルデータを少しずつ展開し、IplImageに書き込む
            const int ReadLength = 1024 * 512;
            byte[] buffer = new byte[ReadLength];
            IntPtr p = ImageData;
            using (MemoryStream ms = new MemoryStream(imageData))
            using (DeflateStream gzs = new DeflateStream(ms, CompressionMode.Decompress))
            {                
                while (true)
                {
                    int readSize = gzs.Read(buffer, 0, buffer.Length);
                    if (readSize == 0)
                    {
                        break;
                    }
                    Marshal.Copy(buffer, 0, p, readSize);
                    p = new IntPtr(p.ToInt64() + readSize);
                }
            }
        }
        #endregion
    }
}