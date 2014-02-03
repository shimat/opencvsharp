/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 多重行列
    /// </summary>
#else
    /// <summary>
    /// Multi-channel matrix
    /// </summary>
#endif
    public class CvMat : CvArr, ICloneable, IEnumerable<CvScalar>
    {
        #region Fields
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Byte dataArrayByte;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Int16 dataArrayInt16;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Int32 dataArrayInt32;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Single dataArraySingle;
        /// <summary>
        /// 
        /// </summary>
        private PointerAccessor1D_Double dataArrayDouble;
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 新たな行列とその内部データのためのヘッダを確保する
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
        /// <returns>行列</returns>
#else
        /// <summary>
        /// Allocates header for the new matrix and underlying data, and returns a pointer to the created matrix.
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <returns></returns>
#endif
        public CvMat(int rows, int cols, MatrixType type)
        {
            ptr = CvInvoke.cvCreateMat(rows, cols, type);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvMat");
            NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// 新たな行列とその内部データのためのヘッダを確保し、内部データに指定した配列を指定する (cvCreateMatHeader + cvSetData)
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
        /// <param name="elements">行列要素とする配列. blittableな型の配列でなければならない(intやCvPointなど)</param>
        /// <returns>行列</returns>
#else
        /// <summary>
        /// Allocates header for the new matrix and underlying data, and returns a pointer to the created matrix. (cvCreateMatHeader + cvSetData)
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <param name="elements">Data of elements. The type of the array must be blittable.</param>
        /// <returns></returns>
#endif
        public CvMat(int rows, int cols, MatrixType type, Array elements)
            : this(rows, cols, type, elements, false)
        {
        }
#if LANG_JP
        /// <summary>
        /// 新たな行列とその内部データのためのヘッダを確保し、内部データに指定した配列を指定する (cvCreateMatHeader + cvSetData)
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
        /// <param name="elements">行列要素とする配列. blittableな型の配列でなければならない(intやCvPointなど)</param>
        /// <param name="copyData"></param>
        /// <returns>行列</returns>
#else
        /// <summary>
        /// Allocates header for the new matrix and underlying data, and returns a pointer to the created matrix. (cvCreateMatHeader + cvSetData)
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <param name="elements">Data of elements. The type of the array must be blittable.</param>
        /// <param name="copyData"></param>
        /// <returns></returns>
#endif
        public CvMat(int rows, int cols, MatrixType type, Array elements, bool copyData)
            //: this(rows, cols, type)
        {
            ptr = CvInvoke.cvCreateMatHeader(rows, cols, type);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvMat");
            
            Array data;
            if (copyData)
                data = (Array)elements.Clone();
            else
                data = elements;
            
            GCHandle gch = base.AllocGCHandle(data);
            CvInvoke.cvSetData(ptr, gch.AddrOfPinnedObject(), Cv.AUTOSTEP);
            NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// 新たな行列とその内部データのためのヘッダを確保し、内部データに指定した配列を指定する (cvCreateMatHeader + cvSetData)
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
        /// <param name="data">行列要素とするデータ</param>
        /// <returns>行列</returns>
#else
        /// <summary>
        /// Allocates header for the new matrix and underlying data, and returns a pointer to the created matrix. (cvCreateMatHeader + cvSetData)
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <param name="data">Data pointer of elements.</param>
        /// <returns></returns>
#endif
        public CvMat(int rows, int cols, MatrixType type, IntPtr data)
            : this(rows, cols, type)
        {
            ptr = CvInvoke.cvCreateMatHeader(rows, cols, type);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvMat");
            }
            CvInvoke.cvSetData(ptr, data, Cv.AUTOSTEP);
        }
#if LANG_JP
        /// <summary>
        /// 新たな行列とその内部データのためのヘッダを確保し、初期値を設定する.
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
        /// <param name="value">行列要素の初期値</param>
        /// <returns>行列</returns>
#else
        /// <summary>
        /// Allocates header for the new matrix and underlying data, and returns a pointer to the created matrix.
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <param name="value">Initial value of elements</param>
        /// <returns></returns>
#endif
        public CvMat(int rows, int cols, MatrixType type, CvScalar value)
        {
            ptr = CvInvoke.cvCreateMat(rows, cols, type);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvMat");
            }
            CvInvoke.cvSet(ptr, value, IntPtr.Zero);
            NotifyMemoryPressure(SizeOf);
        }

#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込んで初期化
        /// </summary>
        /// <param name="filename">ファイル名</param>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image as CvMat. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public CvMat(string filename)
            : this(filename, LoadMode.Color)
        {
        }
#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込んで初期化
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="flags">読み込む画像がカラー/グレースケールのどちらか，とビット深度を指定する</param>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image as CvMat. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <param name="flags">Specifies colorness and Depth of the loaded image.</param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public CvMat(string filename, LoadMode flags)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (!File.Exists(filename))
                throw new FileNotFoundException("", filename);
            
            ptr = CvInvoke.cvLoadImageM(filename, flags);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvMat");
            }
            NotifyMemoryPressure(SizeOf);
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes by native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvMat(IntPtr ptr)
            : this(ptr, true)
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタと自動解放の可否を指定して初期化
        /// </summary>
        /// <param name="p"></param>
        /// <param name="isEnabledDispose"></param>
#else
        /// <summary>
        /// Initializes by native pointer
        /// </summary>
        /// <param name="p"></param>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#endif
        public CvMat(IntPtr p, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            ptr = p;
            NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// sizeof(CvMat)の分のメモリの割り当てだけ行って初期化
        /// </summary>
#else
        /// <summary>
        /// Allocates memory
        /// </summary>
#endif
        public CvMat()
            : this(true)
        {
        }
#if LANG_JP
        /// <summary>
        /// sizeof(CvMat)の分のメモリの割り当てだけ行って、GC禁止設定で初期化
        /// </summary>
#else
        /// <summary>
        /// Allocates memory
        /// </summary>
        /// <param name="isEnabledDispose">If true, this matrix will be disposed by GC automatically.</param>
#endif
        internal CvMat(bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            ptr = AllocMemory(SizeOf);
            NotifyMemoryPressure(SizeOf);
        }

        #region Static initializer
        #region From liner array
#if LANG_JP
        /// <summary>
        /// double[]からCvMatを初期化して返す. F64C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat</returns>
#else
        /// <summary>
        /// Creates CvMat from double liner array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (F64C1)</returns>
#endif
        public static CvMat FromArray(double[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.F64C1, data);
        }
#if LANG_JP
        /// <summary>
        /// float[]からCvMatを初期化して返す. F32C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat</returns>
#else
        /// <summary>
        /// Creates CvMat from float liner array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (F32C1)</returns>
#endif
        public static CvMat FromArray(float[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.F32C1, data);
        }
#if LANG_JP
        /// <summary>
        /// int[]からCvMatを初期化して返す. S32C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat</returns>
#else
        /// <summary>
        /// Creates CvMat from int liner array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (S32C1)</returns>
#endif
        public static CvMat FromArray(int[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S32C1, data);
        }
#if LANG_JP
        /// <summary>
        /// short[]からCvMatを初期化して返す. S16C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat</returns>
#else
        /// <summary>
        /// Creates CvMat from short liner array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (S16C1)</returns>
#endif
        public static CvMat FromArray(short[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S16C1, data);
        }
#if LANG_JP
        /// <summary>
        /// byte[]からCvMatを初期化して返す. U8C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat</returns>
#else
        /// <summary>
        /// Creates CvMat from byte liner array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (U8C1)</returns>
#endif
        public static CvMat FromArray(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.U8C1, data);
        }
#if LANG_JP
        /// <summary>
        /// t[]からCvMatを初期化して返す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates CvMat from generic liner array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static CvMat FromArray<T>(T[] data, MatrixType type) where T : struct
        {
            if (data == null)
                throw new ArgumentNullException("data");
            
            return new CvMat(data.GetLength(0), data.GetLength(1), type, data);
        }
        #endregion
        #region From rectanguler array
#if LANG_JP
        /// <summary>
        /// double[,]からCvMatを初期化して返す. F64C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (F64C1)</returns>
#else
        /// <summary>
        /// Creates CvMat from double rectangular array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (F64C1)</returns>
#endif
        public static CvMat FromArray(double[,] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.F64C1, data);
        }
#if LANG_JP
        /// <summary>
        /// float[,]からCvMatを初期化して返す. F32C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (F32C1)</returns>
#else
        /// <summary>
        /// Creates CvMat from float rectangular array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (F32C1)</returns>
#endif
        public static CvMat FromArray(float[,] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.F32C1, data);
        }
#if LANG_JP
        /// <summary>
        /// int[,]からCvMatを初期化して返す. S32C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (S32C1)</returns>
#else
        /// <summary>
        /// Creates CvMat from int rectangular array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (S32C1)</returns>
#endif
        public static CvMat FromArray(int[,] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S32C1, data);
        }
#if LANG_JP
        /// <summary>
        /// short[,]からCvMatを初期化して返す. S16C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (S16C1)</returns>
#else
        /// <summary>
        /// Creates CvMat from short rectangular array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (S16C1)</returns>
#endif
        public static CvMat FromArray(short[,] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.S16C1, data);
        }
#if LANG_JP
        /// <summary>
        /// byte[,]からCvMatを初期化して返す. U8C1型として生成する。 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (U8C1)</returns>
#else
        /// <summary>
        /// Creates CvMat from byte rectangular array
        /// </summary>
        /// <param name="data"></param>
        /// <returns>CvMat (U8C1)</returns>
#endif
        public static CvMat FromArray(byte[,] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), MatrixType.U8C1, data);
        }
#if LANG_JP
        /// <summary>
        /// t[,]からCvMatを初期化して返す.  
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns>CvMat</returns>
#else
        /// <summary>
        /// Creates CvMat from generic rectangular array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
#endif
        public static CvMat FromArray<T>(T[,] data, MatrixType type) where T : struct
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return new CvMat(data.GetLength(0), data.GetLength(1), type, data);
        }
        /// <summary>
        /// 2次元のRectangular Arrayを1次元配列に変換する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        private static T[] ToLinearArtay<T>(T[,] array)
        {
            int row = array.GetLength(0);
            int col = array.GetLength(1);
            T[] result = new T[row * col];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    result[r * col + c] = array[r, c];
                }
            }
            return result;
        }
        #endregion
        #region FromFile
#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込み，その画像の参照をCvMat形式で返す
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <returns>画像への参照</returns>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image as CvMat. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public static CvMat FromFile(string filename)
        {
            return Cv.LoadImageM(filename);
        }
#if LANG_JP
        /// <summary>
        /// 指定されたファイルから画像を読み込み，その画像の参照をCvMat形式で返す
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="flags">読み込む画像がカラー/グレースケールのどちらか，とビット深度を指定する</param>
        /// <returns>画像への参照</returns>
#else
        /// <summary>
        /// Loads an image from the specified file and returns the reference to the loaded image as CvMat. 
        /// </summary>
        /// <param name="filename">Name of file to be loaded. </param>
        /// <param name="flags">Specifies colorness and Depth of the loaded image.</param>
        /// <returns>the reference to the loaded image. </returns>
#endif
        public static CvMat LoadImageM(string filename, LoadMode flags)
        {
            return Cv.LoadImageM(filename, flags);
        }
        #endregion
        #region FromImageData
#if LANG_JP
        /// <summary>
        /// 画像データ(JPEG等の画像をメモリに展開したもの)からIplImageを生成する (cvDecodeImageM)
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from image data (using cvDecodeImageM) 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static CvMat FromImageData(byte[] bytes, LoadMode mode)
        {
            if (bytes == null)
                throw new ArgumentNullException("bytes");

            using (CvMat mat = new CvMat(bytes.Length, 1, MatrixType.U8C1, bytes, false))
            {
                return Cv.DecodeImageM(mat, mode);
            }
        }
        #endregion
        #region FromStream
#if LANG_JP
        /// <summary>
        /// System.IO.StreamのインスタンスからIplImageを生成する (cvDecodeImageM)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the IplImage instance from System.IO.Stream (using cvDecodeImageM) 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
#endif
        public static CvMat FromStream(Stream stream, LoadMode mode)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            return FromImageData(bytes, mode);
        }
        #endregion
        #region OpenCV methods
#if LANG_JP
        /// <summary>
        /// 3点とそれぞれに対応する点からアフィン変換を計算する (2 x 3 のCV_32FC1型) [cvGetAffineTransform相当]. 
        /// </summary>
        /// <param name="src">入力（変換前）画像内に存在する三角形の3つの頂点座標を格納した配列</param>
        /// <param name="dst">出力（変換後）画像内に存在するsrcに対応した三角形の3つの頂点座標を格納した配列</param>
        /// <returns>求められた 2×3のアフィン変換行列</returns>
#else
        /// <summary>
        /// Calculates affine transform from 3 corresponding points (cvGetAffineTransform).
        /// </summary>
        /// <param name="src">Coordinates of 3 triangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 3 corresponding triangle vertices in the destination image. </param>
        /// <returns></returns>
#endif
        public static CvMat AffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst)
        {
            return Cv.GetAffineTransform(src, dst);
        }
#if LANG_JP
        /// <summary>
        /// 4点とそれぞれに対応する点を用いて透視変換行列を求める (3 x 3 のCV_32FC1型) [cvGetPerspectiveTransform相当]. 
        /// </summary>
        /// <param name="src">入力画像中の矩形の４頂点の座標</param>
        /// <param name="dst">出力画像中の対応する矩形の４頂点の座標</param>
        /// <returns>求められた 3×3の射影変換行列</returns>
#else
        /// <summary>
        /// Calculates perspective transform from 4 corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of 4 quadrangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 4 corresponding quadrangle vertices in the destination image. </param>
        /// <returns></returns>
#endif
        public static CvMat PerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst)
        {
            return Cv.GetPerspectiveTransform(src, dst);
        }
#if LANG_JP
        /// <summary>
        /// 単位行列を生成する
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
#else
        /// <summary>
        /// Initializes identity matrix
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
#endif
        public static CvMat Identity(int rows, int cols, MatrixType type)
        {
            return Identity(rows, cols, type, CvScalar.RealScalar(1));
        }
#if LANG_JP
        /// <summary>
        /// スカラー倍された単位行列を生成する
        /// </summary>
        /// <param name="rows">行列の行数</param>
        /// <param name="cols">行列の列数</param>
        /// <param name="type">行列要素の種類</param>
        /// <param name="value">対角成分の値</param>
#else
        /// <summary>
        /// Initializes scaled identity matrix
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements.</param>
        /// <param name="value">The value to assign to the diagonal elements. </param>
#endif
        public static CvMat Identity(int rows, int cols, MatrixType type, CvScalar value)
        {
            IntPtr ptr = CvInvoke.cvCreateMatHeader(rows, cols, type);
            CvInvoke.cvCreateData(ptr);
            CvInvoke.cvSetIdentity(ptr, value);
            return new CvMat(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 2次元回転のアフィン行列を計算する (2 x 3 のCV_32FC1型) (cv2DRotationMatrix相当).
        /// </summary>
        /// <param name="center">入力画像内の回転中心 </param>
        /// <param name="angle">度（degree）単位の回転角度．正の値は反時計方向の回転を意味する（座標原点は左上にあると仮定）．</param>
        /// <param name="scale">等方性スケーリング係数（x,y方向とも同じ係数 scale を使う） </param>
        /// <returns>2x3の2次元回転のアフィン行列</returns>
#else
        /// <summary>
        /// Calculates affine matrix of 2d rotation.
        /// </summary>
        /// <param name="center">Center of the rotation in the source image. </param>
        /// <param name="angle">The rotation angle in degrees. Positive values mean couter-clockwise rotation (the coordiate origin is assumed at top-left corner). </param>
        /// <param name="scale">Isotropic scale factor. </param>
        /// <returns></returns>
#endif
        public static CvMat RotationMatrix(CvPoint2D32f center, double angle, double scale)
        {
            return Cv._2DRotationMatrix(center, angle, scale);
        }
        #endregion
        #endregion

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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        CvInvoke.cvReleaseMat(ref ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvMat)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvMat));

#if LANG_JP
        /// <summary>
		/// CvMat シグネチャ (CV_MAT_MAGIC_VAL)．要素の型とフラグ 
		/// </summary>
#else
        /// <summary>
        /// CvMat signature (CV_MAT_MAGIC_VAL), element type and flags
        /// </summary>
#endif
        public int Type
        {
            get
            {
                unsafe
                {
                    return ((WCvMat*)ptr)->type;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->type = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 全行のバイト長
		/// </summary>
#else
        /// <summary>
        /// Full row length in bytes
        /// </summary>
#endif
        public int Step
        {
            get
            {
                unsafe
                {
                    return ((WCvMat*)ptr)->step;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->step = value;
                }
            }
        }

        #region Matrix Data
#if LANG_JP
        /// <summary>
		/// 行列データへのポインタ.
		/// 実際に格納しているデータ型に応じて適宜byte*やdouble*等にキャストして利用する。
        /// </summary>
#else
        /// <summary>
        /// Data pointer
        /// </summary>
#endif
        public IntPtr Data
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvMat*)ptr)->data);
                }
            }
            set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->data = value.ToPointer();
                }
            }
        }
#if LANG_JP
        /// <summary>
		/// 行列データへのByte型ポインタ.
		/// </summary>
#else
        /// <summary>
        /// Data pointer as byte*
        /// </summary>
#endif
        public unsafe byte* DataByte
        {
            get
            {
                return (byte*)(((WCvMat*)ptr)->data);
            }
            set
            {
                ((WCvMat*)ptr)->data = value;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt16(short)型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as short*
        /// </summary>
#endif
        public unsafe short* DataInt16
        {
            get
            {
                return (short*)(((WCvMat*)ptr)->data);
            }
            set
            {
                ((WCvMat*)ptr)->data = value;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt32(int)型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as int*
        /// </summary>
#endif
        public unsafe int* DataInt32
        {
            get
            {
                return (int*)(((WCvMat*)ptr)->data);
            }
            set
            {
                ((WCvMat*)ptr)->data = value;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのSingle(float)型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as float*
        /// </summary>
#endif
        public unsafe float* DataSingle
        {
            get
            {
                return (float*)(((WCvMat*)ptr)->data);
            }
            set
            {
                ((WCvMat*)ptr)->data = value;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのDouble型ポインタ.
        /// </summary>
#else
        /// <summary>
        /// Data pointer as double*
        /// </summary>
#endif
        public unsafe double* DataDouble
        {
            get
            {
                return (double*)(((WCvMat*)ptr)->data);
            }
            set
            {
                ((WCvMat*)ptr)->data = value;
            }
        }
#if LANG_JP
        /// <summary>
		/// 行列データへのByte型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(byte*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Byte DataArrayByte
        {
            get
            {
                if (dataArrayByte == null)
                {
                    unsafe
                    {
                        byte* p = (byte*)(((WCvMat*)ptr)->data);
                        dataArrayByte = new PointerAccessor1D_Byte(p);
                    }
                }
                return dataArrayByte;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt16(short)型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(short*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Int16 DataArrayInt16
        {
            get
            {
                if (dataArrayInt16 == null)
                {
                    unsafe
                    {
                        short* p = (short*)(((WCvMat*)ptr)->data);
                        dataArrayInt16 = new PointerAccessor1D_Int16(p);
                    }
                }
                return dataArrayInt16;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのInt32(int)型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(int*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Int32 DataArrayInt32
        {
            get
            {
                if (dataArrayInt32 == null)
                {
                    unsafe
                    {
                        int* p = (int*)(((WCvMat*)ptr)->data);
                        dataArrayInt32 = new PointerAccessor1D_Int32(p);
                    }
                }
                return dataArrayInt32;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのSingle(float)型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(float*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Single DataArraySingle
        {
            get
            {
                if (dataArraySingle == null)
                {
                    unsafe
                    {
                        float* p = (float*)(((WCvMat*)ptr)->data);
                        dataArraySingle = new PointerAccessor1D_Single(p);
                    }
                }
                return dataArraySingle;
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列データへのDouble型ポインタ. 配列のようにアクセス可能.
        /// </summary>
#else
        /// <summary>
        /// Data pointer(double*) which can be accessed without unsafe code.
        /// </summary>
#endif
        public PointerAccessor1D_Double DataArrayDouble
        {
            get
            {
                if (dataArrayDouble == null)
                {
                    unsafe
                    {
                        double* p = (double*)(((WCvMat*)ptr)->data);
                        dataArrayDouble = new PointerAccessor1D_Double(p);
                    }
                }
                return dataArrayDouble;
            }
        }
        #endregion

#if LANG_JP
        /// <summary>
		/// 行列の列数
		/// </summary>
#else
        /// <summary>
        /// number of columns
        /// </summary>
#endif
        public int Cols
        {
            get
            {
                unsafe
                {
                    return ((WCvMat*)ptr)->cols;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->cols = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列の列数
		/// </summary>
#else
        /// <summary>
        /// number of columns
        /// </summary>
#endif
        public int Height
        {
            get
            {
                unsafe
                {
                    return ((WCvMat*)ptr)->rows;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->rows = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列の行数
		/// </summary>
#else
        /// <summary>
        /// number of rows
        /// </summary>
#endif
        public int Rows
        {
            get
            {
                unsafe
                {
                    return ((WCvMat*)ptr)->rows;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->rows = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 行列の行数
		/// </summary>
#else
        /// <summary>
        /// number of rows
        /// </summary>
#endif
        public int Width
        {
            get
            {
                unsafe
                {
                    return ((WCvMat*)ptr)->cols;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->cols = value;
                }
            }
        }
#if LANG_JP
		/// <summary>
		/// 
		/// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr RefCount
        {
            get
            {
                unsafe
                {
                    return new IntPtr(((WCvMat*)ptr)->refcount);
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvMat*)ptr)->refcount =(int*)value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 配列の次元数を取得する (2固定)
        /// </summary>
#else
        /// <summary>
        /// Number of dimensions (=2)
        /// </summary>
#endif
        public override int Dims
        {
            get { return 2; }
        }

#if LANG_JP
        /// <summary>
		/// 特定の配列要素を取得・設定する (cvmGet, cvmSet相当). 
		/// </summary>
		/// <param name="row">要素インデックスの，0を基準とした第1成分．</param>
		/// <param name="col">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Gets/Sets the particular element of single-channel floating-point matrix (cvmGet/cvmSet)
        /// </summary>
        /// <param name="row">The zero-based index of row. </param>
        /// <param name="col">The zero-based index of column. </param>
        /// <returns>the particular element's value</returns>
#endif
        new public double this[int row, int col]
        {
            get
            {
                return Cv.mGet(this, row, col);
            }
            set
            {
                Cv.mSet(this, row, col, value);
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
        public static CvMat operator +(CvMat a)
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
        public static CvMat operator -(CvMat a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
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
        public static CvMat operator ~(CvMat a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
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
        public static CvMat operator +(CvMat a, CvMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMat result = a.Clone();
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
        public static CvMat operator +(CvMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
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
        public static CvMat operator -(CvMat a, CvMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMat result = a.Clone();
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
        public static CvMat operator -(CvMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
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
        public static CvMat operator *(CvMat a, CvMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            if (a.ElemType != b.ElemType)
                throw new ArgumentException("a.ElemType must equal to b.ElemType");
            if (a.Cols != b.Rows)
                throw new ArgumentException("a.Cols must equal to b.Rows");

            CvMat result = new CvMat(a.Rows, b.Cols, a.ElemType);
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
        public static CvMat operator *(CvMat a, double b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
            Cv.AddWeighted(a, b, a, 0, 0, result);
            return result;
        }
#if LANG_JP
        /// <summary>
        /// 行列とスカラーの乗算演算子。aの要素ごとにbをかけた結果をcvAddWeightedにより求める。
        /// </summary>
        /// <param name="a">スカラー</param>
        /// <param name="b">行列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Multiplicative operator (cvAddWeighted)
        /// </summary>
        /// <param name="a">scalar</param>
        /// <param name="b">matrix</param>
        /// <returns></returns>
#endif
        public static CvMat operator *(double a, CvMat b)
        {
            return b * a;
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
        public static CvMat operator /(CvMat a, double b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == 0)
                throw new DivideByZeroException();
            
            CvMat result = a.Clone();
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
        public static CvMat operator &(CvMat a, CvMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMat result = a.Clone();
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
        public static CvMat operator &(CvMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
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
        public static CvMat operator |(CvMat a, CvMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMat result = a.Clone();
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
        public static CvMat operator |(CvMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
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
        public static CvMat operator ^(CvMat a, CvMat b)
        {
            if (a == null)
                throw new ArgumentNullException("a");
            if (b == null)
                throw new ArgumentNullException("b");
            CvMat result = a.Clone();
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
        public static CvMat operator ^(CvMat a, CvScalar b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            CvMat result = a.Clone();
            Cv.XorS(a, b, result);
            return result;
        }
        #endregion

        #region Methods
        #region CalibrationMatrixValues
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="imageSize">画像のサイズ．ピクセル単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="imageSize">Image size in pixels </param>
#endif
        public void CalibrationMatrixValues(CvSize imageSize)
        {
            Cv.CalibrationMatrixValues(this, imageSize);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="imageSize">画像のサイズ．ピクセル単位.</param>
        /// <param name="apertureWidth">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="apertureHeight">アパーチャ高さ．実際の長さ単位．</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="imageSize">Image size in pixels </param>
        /// <param name="apertureWidth">Aperture width in realworld units</param>
        /// <param name="apertureHeight">Aperture width in realworld units</param>
#endif
        public void CalibrationMatrixValues(CvSize imageSize, double apertureWidth, double apertureHeight)
        {
            Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="imageSize">画像のサイズ．ピクセル単位.</param>
        /// <param name="apertureWidth">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="apertureHeight">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="imageSize">Image size in pixels </param>
        /// <param name="apertureWidth">Aperture width in realworld units</param>
        /// <param name="apertureHeight">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
#endif
        public void CalibrationMatrixValues(
            CvSize imageSize, double apertureWidth, double apertureHeight,
            out double fovx, out double fovy)
        {
            Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight, out fovx, out fovy);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="imageSize">画像のサイズ．ピクセル単位.</param>
        /// <param name="apertureWidth">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="apertureHeight">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
        /// <param name="focalLength">焦点距離．実際の長さ単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="imageSize">Image size in pixels </param>
        /// <param name="apertureWidth">Aperture width in realworld units</param>
        /// <param name="apertureHeight">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
        /// <param name="focalLength">Focal length in realworld units</param>
#endif
        public void CalibrationMatrixValues(
            CvSize imageSize, double apertureWidth, double apertureHeight,
            out double fovx, out double fovy, out double focalLength)
        {
            Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy, out focalLength);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="imageSize">画像のサイズ．ピクセル単位.</param>
        /// <param name="apertureWidth">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="apertureHeight">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
        /// <param name="focalLength">焦点距離．実際の長さ単位.</param>
        /// <param name="principalPoint">主点（光学中心）実際の長さ単位.</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="imageSize">Image size in pixels </param>
        /// <param name="apertureWidth">Aperture width in realworld units</param>
        /// <param name="apertureHeight">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
        /// <param name="focalLength">Focal length in realworld units</param>
        /// <param name="principalPoint">The principal point in realworld units</param>
#endif
        public void CalibrationMatrixValues(
            CvSize imageSize, double apertureWidth, double apertureHeight,
            out double fovx, out double fovy, out double focalLength, out CvPoint2D64f principalPoint)
        {
            Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy, out focalLength, out principalPoint);
        }
#if LANG_JP
        /// <summary>
        /// 様々なカメラ特性を計算する
        /// </summary>
        /// <param name="imageSize">画像のサイズ．ピクセル単位.</param>
        /// <param name="apertureWidth">アパーチャ幅．実際の長さ単位．</param>
        /// <param name="apertureHeight">アパーチャ高さ．実際の長さ単位．</param>
        /// <param name="fovx">x-方向の画角．degree単位.</param>
        /// <param name="fovy">y-方向の画角．degree単位.</param>
        /// <param name="focalLength">焦点距離．実際の長さ単位.</param>
        /// <param name="principalPoint">主点（光学中心）実際の長さ単位.</param>
        /// <param name="pixelAspectRatio">ピクセルのアスペクト比 fy/fx</param>
#else
        /// <summary>
        /// Finds intrinsic and extrinsic camera parameters using calibration pattern
        /// </summary>
        /// <param name="imageSize">Image size in pixels </param>
        /// <param name="apertureWidth">Aperture width in realworld units</param>
        /// <param name="apertureHeight">Aperture width in realworld units</param>
        /// <param name="fovx">Field of view angle in x direction in degrees</param>
        /// <param name="fovy">Field of view angle in y direction in degrees</param>
        /// <param name="focalLength">Focal length in realworld units</param>
        /// <param name="principalPoint">The principal point in realworld units</param>
        /// <param name="pixelAspectRatio">The pixel aspect ratio ~ fy/fx</param>
#endif
        public void CalibrationMatrixValues(
            CvSize imageSize, double apertureWidth, double apertureHeight,
            out double fovx, out double fovy, out double focalLength, out CvPoint2D64f principalPoint, out double pixelAspectRatio)
        {
            Cv.CalibrationMatrixValues(this, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy, out focalLength, out principalPoint, out pixelAspectRatio);
        }
        #endregion
        #region Clone
#if LANG_JP
        /// <summary>
        /// 行列のコピーを作成する (cvCloneMat)
        /// </summary>
        /// <returns>コピーされた行列</returns>
#else
        /// <summary>
        /// Creates matrix copy (cvCloneMat)
        /// </summary>
        /// <returns>a copy of input array</returns>
#endif
        public CvMat Clone()
        {
            return Cv.CloneMat(this);
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
        #region CompleteSymm
#if LANG_JP
        /// <summary>
        /// 行列を、その下三角行列を用いて対称行列として書き換える
        /// </summary>
#else
        /// <summary>
        /// Completes the symmetric matrix from the lower part
        /// </summary>
#endif
        public void CompleteSymm()
        {
            Cv.CompleteSymm(this);
        }
#if LANG_JP
        /// <summary>
        /// 行列を、その下三角行列 (LtoR=false) または上三角行列 (LtoR=true) を用いて対称行列として書き換える
        /// </summary>
        /// <param name="LtoR"></param>
#else
        /// <summary>
        /// Completes the symmetric matrix from the lower (LtoR=0) or from the upper (LtoR!=0) part
        /// </summary>
        /// <param name="LtoR"></param>
#endif
        public void CompleteSymm(bool LtoR)
        {
            Cv.CompleteSymm(this, LtoR);
        }
        #endregion
        #region ComputeCorrespondEpilines
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="whichImage">pointsを含む画像のインデックス（1 または 2）．</param>
        /// <param name="fundamentalMatrix">基礎行列</param>
        /// <param name="correspondentLines">計算されたエピポーラ線．大きさは3xN また Nx3 の配列．</param>
#else
        /// <summary>
        /// For points in one image of stereo pair computes the corresponding epilines in the other image
        /// </summary>
        /// <param name="whichImage">Index of the image (1 or 2) that contains the points</param>
        /// <param name="fundamentalMatrix">Fundamental matrix </param>
        /// <param name="correspondentLines">Computed epilines, 3xN or Nx3 array </param>
#endif
        public void ComputeCorrespondEpilines(int whichImage, CvMat fundamentalMatrix, out CvMat correspondentLines)
        {
            Cv.ComputeCorrespondEpilines(this, whichImage, fundamentalMatrix, out correspondentLines);
        }
        #endregion
        #region ConvertPointsHomogeneous
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="dst">出力点の配列．入力配列と同じ数の点が含まれる次元数は，同じ， あるいは入力より1少ないか1大きい．そして2..4の範囲内でなければならない． </param>
#else
        /// <summary>
        /// Convert points to/from homogeneous coordinates
        /// </summary>
        /// <param name="dst">The output point array, must contain the same number of points as the input; The dimensionality must be the same, 1 less or 1 more than the input, and also within 2..4. </param>
#endif
        public void ConvertPointsHomogenious(CvMat dst)
        {
            Cv.ConvertPointsHomogenious(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 2枚の画像間の点対応から基礎行列（F行列）を計算する
        /// </summary>
        /// <param name="dst">出力点の配列．入力配列と同じ数の点が含まれる次元数は，同じ， あるいは入力より1少ないか1大きい．そして2..4の範囲内でなければならない． </param>
#else
        /// <summary>
        /// Convert points to/from homogeneous coordinates
        /// </summary>
        /// <param name="dst">The output point array, must contain the same number of points as the input; The dimensionality must be the same, 1 less or 1 more than the input, and also within 2..4. </param>
#endif
        public void ConvertPointsHomogeneous(CvMat dst)
        {
            Cv.ConvertPointsHomogeneous(this, dst);
        }
        #endregion
        #region DecodeImage
#if LANG_JP
        /// <summary>
        /// 指定したバッファメモリから画像を読み込む
        /// </summary>
        /// <param name="iscolor">出力の色を指定するフラグ</param>
        /// <returns></returns>        
#else
        /// <summary>
        /// Decode image stored in the buffer
        /// </summary>
        /// <param name="iscolor">Specifies color type of the loaded image</param>
        /// <returns></returns>
#endif
        public IplImage DecodeImage(LoadMode iscolor)
        {
            return Cv.DecodeImage(this, iscolor);
        }
#if LANG_JP
        /// <summary>
        /// 指定したバッファメモリから画像をCvMatとして読み込む
        /// </summary>
        /// <param name="iscolor">出力の色を指定するフラグ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Decode image stored in the buffer
        /// </summary>
        /// <param name="iscolor">Specifies color type of the loaded image</param>
        /// <returns></returns>
#endif
        public CvMat DecodeImageM(LoadMode iscolor)
        {
            return Cv.DecodeImageM(this, iscolor);
        }
        #endregion
        #region DecomposeProjectionMatrix
#if LANG_JP
        /// <summary>
        /// 射影行列をキャリブレーション行列と回転行列とカメラの同次座標系での位置ベクトルに分解する
        /// </summary>
        /// <param name="calibMatr">出力の3x3の内部キャリブレーション行列 K</param>
        /// <param name="rotMatr">出力の3x3の外部回転行列 R</param>
        /// <param name="posVect">出力の4x1の同次座標系での外部位置ベクトル C</param>
#else
        /// <summary>
        /// Computes projection matrix decomposition
        /// </summary>
        /// <param name="calibMatr">The output 3x3 internal calibration matrix K</param>
        /// <param name="rotMatr">The output 3x3 external rotation matrix R</param>
        /// <param name="posVect">The output 4x1 external homogenious position vector C</param>
#endif
        public void DecomposeProjectionMatrix(CvMat calibMatr, CvMat rotMatr, CvMat posVect)
        {
            Cv.DecomposeProjectionMatrix(this, calibMatr, rotMatr, posVect);
        }
#if LANG_JP
        /// <summary>
        /// 射影行列をキャリブレーション行列と回転行列とカメラの同次座標系での位置ベクトルに分解する
        /// </summary>
        /// <param name="calibMatr">出力の3x3の内部キャリブレーション行列 K</param>
        /// <param name="rotMatr">出力の3x3の外部回転行列 R</param>
        /// <param name="posVect">出力の4x1の同次座標系での外部位置ベクトル C</param>
        /// <param name="rotMatrX">オプション出力の3x3のx軸周りでの回転行列</param>
        /// <param name="rotMatrY">オプション出力の3x3のy軸周りでの回転行列</param>
        /// <param name="rotMatrZ">オプション出力の3x3のz軸周りでの回転行列</param>
#else
        /// <summary>
        /// Computes projection matrix decomposition
        /// </summary>
        /// <param name="calibMatr">The output 3x3 internal calibration matrix K</param>
        /// <param name="rotMatr">The output 3x3 external rotation matrix R</param>
        /// <param name="posVect">The output 4x1 external homogenious position vector C</param>
        /// <param name="rotMatrX">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="rotMatrY">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="rotMatrZ">Optional 3x3 rotation matrix around z-axis</param>
#endif
        public void DecomposeProjectionMatrix(CvMat calibMatr, CvMat rotMatr, CvMat posVect, CvMat rotMatrX, CvMat rotMatrY, CvMat rotMatrZ)
        {
            Cv.DecomposeProjectionMatrix(this, calibMatr, rotMatr, posVect, rotMatrX, rotMatrY, rotMatrZ);
        }
#if LANG_JP
        /// <summary>
        /// 射影行列をキャリブレーション行列と回転行列とカメラの同次座標系での位置ベクトルに分解する
        /// </summary>
        /// <param name="calibMatr">出力の3x3の内部キャリブレーション行列 K</param>
        /// <param name="rotMatr">出力の3x3の外部回転行列 R</param>
        /// <param name="posVect">出力の4x1の同次座標系での外部位置ベクトル C</param>
        /// <param name="rotMatrX">オプション出力の3x3のx軸周りでの回転行列</param>
        /// <param name="rotMatrY">オプション出力の3x3のy軸周りでの回転行列</param>
        /// <param name="rotMatrZ">オプション出力の3x3のz軸周りでの回転行列</param>
        /// <param name="eulerAngles">オプション出力の回転のオイラー角</param>
#else
        /// <summary>
        /// Computes projection matrix decomposition
        /// </summary>
        /// <param name="calibMatr">The output 3x3 internal calibration matrix K</param>
        /// <param name="rotMatr">The output 3x3 external rotation matrix R</param>
        /// <param name="posVect">The output 4x1 external homogenious position vector C</param>
        /// <param name="rotMatrX">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="rotMatrY">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="rotMatrZ">Optional 3x3 rotation matrix around z-axis</param>
        /// <param name="eulerAngles">Optional 3 points containing the three Euler angles of rotation</param>
#endif
        public void DecomposeProjectionMatrix(CvMat calibMatr, CvMat rotMatr, CvMat posVect, CvMat rotMatrX, CvMat rotMatrY, CvMat rotMatrZ, out CvPoint3D64f eulerAngles)
        {
            Cv.DecomposeProjectionMatrix(this, calibMatr, rotMatr, posVect, rotMatrX, rotMatrY, rotMatrZ, out eulerAngles);
        }
        #endregion
        #region EncodeImage
#if LANG_JP
        /// <summary>
        /// 画像をエンコードしてバイト列として出力する
        /// </summary>
        /// <param name="ext">出力形式として定義されているファイル拡張子</param>
        /// <param name="prms">画像フォーマット固有の各種パラメータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Encode image and store the result as a byte vector (single-row 8uC1 matrix)
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="prms">The format-specific parameters</param>
        /// <returns></returns>
#endif
        public CvMat EncodeImage(string ext, int[] prms)
        {
            return Cv.EncodeImage(ext, this, prms);
        }
#if LANG_JP
        /// <summary>
        /// 画像をエンコードしてバイト列として出力する
        /// </summary>
        /// <param name="ext">出力形式として定義されているファイル拡張子</param>
        /// <param name="prms">画像フォーマット固有の各種パラメータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Encode image and store the result as a byte vector (single-row 8uC1 matrix)
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="prms">The format-specific parameters</param>
        /// <returns></returns>
#endif
        public CvMat EncodeImage(string ext, params ImageEncodingParam[] prms)
        {
            return Cv.EncodeImage(ext, this, prms);
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
                return new UnmanagedMemoryStream(DataByte, Rows*Cols);
            }
        }
        #endregion
        #region InitMatHeader
#if LANG_JP
        /// <summary>
        /// 既に確保された CvMat を初期化する．
        /// </summary>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header.
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements. </param>
        /// <returns></returns>
#endif
        public CvMat InitMatHeader(int rows, int cols, MatrixType type)
        {
            return Cv.InitMatHeader(this, rows, cols, type);
        }
#if LANG_JP
        /// <summary>
        /// 既に確保された CvMat を初期化する．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <param name="data">行列のヘッダで指定されるデータ配列. 長さがrows*cols*channelsの1次元配列を指定する.</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements. </param>
        /// <param name="data">Optional data pointer assigned to the matrix header. </param>
        /// <returns></returns>
#endif
        public CvMat InitMatHeader<T>(int rows, int cols, MatrixType type, T[] data) where T : struct
        {
            return Cv.InitMatHeader(this, rows, cols, type, data);
        }
#if LANG_JP
        /// <summary>
        /// 既に確保された CvMat を初期化する．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <param name="data">行列のヘッダで指定されるデータ配列. 長さがrows*cols*channelsの1次元配列を指定する.</param>
        /// <param name="step">割り当てられたデータの行長をバイト単位で表す．デフォルトでは，stepには可能な限り小さい値が用いられる．つまり，行列の連続する行間にギャップが存在しない．</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements. </param>
        /// <param name="data">Optional data pointer assigned to the matrix header. </param>
        /// <param name="step">Full row width in bytes of the data assigned. By default, the minimal possible step is used, r.e., no gaps is assumed between subsequent rows of the matrix. </param>
        /// <returns></returns>
#endif
        public CvMat InitMatHeader<T>(int rows, int cols, MatrixType type, T[] data, int step) where T : struct
        {
            return Cv.InitMatHeader(this, rows, cols, type, data, step);
        }
        #endregion
        #region mGet
#if LANG_JP
        /// <summary>
        /// シングルチャンネル浮動小数点型行列の特定の要素を返す. cvGetReal2Dの高速化版関数である．
        /// </summary>
        /// <param name="row">行の0を基準としたインデックス</param>
        /// <param name="col">列の0を基準としたインデックス</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel floating-point matrix
        /// </summary>
        /// <param name="row">The zero-based index of row. </param>
        /// <param name="col">The zero-based index of column. </param>
        /// <returns></returns>
#endif
        public double mGet(int row, int col)
        {
            return Cv.mGet(this, row, col);
        }
        #endregion
        #region mSet
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの浮動小数点型行列の特定の要素の値を変更する.cvSetReal2Dの高速化版関数である．
        /// </summary>
        /// <param name="row">行の0を基準としたインデックス</param>
        /// <param name="col">列の0を基準としたインデックス</param>
        /// <param name="value">行列の要素の新しい値</param>
#else
        /// <summary>
        /// Return the particular element of single-channel floating-point matrix
        /// </summary>
        /// <param name="row">The zero-based index of row. </param>
        /// <param name="col">The zero-based index of column. </param>
        /// <param name="value">The new value of the matrix element </param>
#endif
        public void mSet(int row, int col, double value)
        {
            Cv.mSet(this, row, col, value);
        }
        #endregion
        #region Rodrigues2
#if LANG_JP
        /// <summary>
        /// 回転ベクトルを回転行列に変換する．またはその逆も可能である．
        /// </summary>
        /// <param name="dst">各入力に対応した出力の回転行列（3x3），または回転ベクトル（3x1 あるいは 1x3）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts rotation matrix to rotation vector or vice versa
        /// </summary>
        /// <param name="dst">The output rotation matrix (3x3) or rotation vector (3x1 or 1x3), respectively. </param>
        /// <returns></returns>
#endif
        public int Rodrigues2(CvMat dst)
        {
            return Cv.Rodrigues2(this, dst);
        }
#if LANG_JP
        /// <summary>
        /// 回転ベクトルを回転行列に変換する．またはその逆も可能である．
        /// </summary>
        /// <param name="dst">各入力に対応した出力の回転行列（3x3），または回転ベクトル（3x1 あるいは 1x3）</param>
        /// <param name="jacobian">オプション出力の3x9または9x3のヤコビアン - 出力配列の各要素の，入力配列の各要素に関する偏微分係数．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts rotation matrix to rotation vector or vice versa
        /// </summary>
        /// <param name="dst">The output rotation matrix (3x3) or rotation vector (3x1 or 1x3), respectively. </param>
        /// <param name="jacobian">Optional output Jacobian matrix, 3x9 or 9x3 - partial derivatives of the output array components w.r.t the input array components. </param>
        /// <returns></returns>
#endif
        public int Rodrigues2(CvMat dst, CvMat jacobian)
        {
            return Cv.Rodrigues2(this, dst, jacobian);
        }
        #endregion
        #region RQDecomp3x3
#if LANG_JP
        /// <summary>
        /// 3x3行列のRQ分解を求める
        /// </summary>
        /// <param name="matrixR">出力の3x3の上三角行列 R</param>
        /// <param name="matrixQ">出力の3x3の直交行列</param>
#else
        /// <summary>
        /// Computes RQ decomposition for 3x3 matrices
        /// </summary>
        /// <param name="matrixR">The output 3x3 upper-triangular matrix R</param>
        /// <param name="matrixQ">The output 3x3 orthogonal matrix Q</param>
#endif
        public void RQDecomp3x3(CvMat matrixR, CvMat matrixQ)
        {
            Cv.RQDecomp3x3(this, matrixR, matrixQ);
        }
#if LANG_JP
        /// <summary>
        /// 3x3行列のRQ分解を求める
        /// </summary>        
        /// <param name="matrixR">出力の3x3の上三角行列 R</param>
        /// <param name="matrixQ">出力の3x3の直交行列</param>
        /// <param name="matrixQx">オプション出力の3x3のx軸を中心とする回転行列</param>
        /// <param name="matrixQy">オプション出力の3x3のy軸を中心とする回転行列</param>
        /// <param name="matrixQz">オプション出力の3x3のz軸を中心とする回転行列</param>
#else
        /// <summary>
        /// Computes RQ decomposition for 3x3 matrices
        /// </summary>
        /// <param name="matrixR">The output 3x3 upper-triangular matrix R</param>
        /// <param name="matrixQ">The output 3x3 orthogonal matrix Q</param>
        /// <param name="matrixQx">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="matrixQy">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="matrixQz">Optional 3x3 rotation matrix around z-axis</param>
#endif
        public void RQDecomp3x3(CvMat matrixR, CvMat matrixQ, CvMat matrixQx, CvMat matrixQy, CvMat matrixQz)
        {
            Cv.RQDecomp3x3(this, matrixR, matrixQ, matrixQx, matrixQy, matrixQz);
        }
#if LANG_JP
        /// <summary>
        /// 3x3行列のRQ分解を求める
        /// </summary>
        /// <param name="matrixR">出力の3x3の上三角行列 R</param>
        /// <param name="matrixQ">出力の3x3の直交行列</param>
        /// <param name="matrixQx">オプション出力の3x3のx軸を中心とする回転行列</param>
        /// <param name="matrixQy">オプション出力の3x3のy軸を中心とする回転行列</param>
        /// <param name="matrixQz">オプション出力の3x3のz軸を中心とする回転行列</param>
        /// <param name="eulerAngles">オプション出力の回転のオイラー角</param>
#else
        /// <summary>
        /// Computes RQ decomposition for 3x3 matrices
        /// </summary>
        /// <param name="matrixR">The output 3x3 upper-triangular matrix R</param>
        /// <param name="matrixQ">The output 3x3 orthogonal matrix Q</param>
        /// <param name="matrixQx">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="matrixQy">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="matrixQz">Optional 3x3 rotation matrix around z-axis</param>
        /// <param name="eulerAngles">Optional 3 points containing the three Euler angles of rotation</param>
#endif
        public void RQDecomp3x3(CvMat matrixR, CvMat matrixQ, CvMat matrixQx, CvMat matrixQy, CvMat matrixQz, out CvPoint3D64f eulerAngles)
        {
            Cv.RQDecomp3x3(this, matrixR, matrixQ, matrixQx, matrixQy, matrixQz, out eulerAngles);
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
        public CvMat Transpose()
        {
            CvMat result = new CvMat(Cols, Rows, ElemType);
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
        public CvMat T()
        {
            return Transpose();
        }
        #endregion
        #region UndistortPoints
#if LANG_JP
        /// <summary>
        /// 観測された点座標から理想的な点座標を計算する
        /// </summary>
        /// <param name="dst">歪み補正後に逆透視投影を行った理想的な点座標.</param>
        /// <param name="cameraMatrix">カメラ行列 A=[fx 0 cx; 0 fy cy; 0 0 1] </param>
        /// <param name="distCoeffs">歪み係数のベクトル，4x1, 1x4, 5x1, 1x5．</param>
        /// <param name="r">オブジェクト空間での平行化変換（3x3 行列）． cvStereoRectify で計算された値， R1 あるいは R2 が渡される．このパラメータが null の場合，単位行列が用いられる．</param>
        /// <param name="p">新しいカメラ行列（3x3），あるいは，新しい投影行列（3x4）． cvStereoRectify  で計算された値， P1 あるいは P2  が渡される． このパラメータが null の場合，単位行列が用いられる． </param>
#else
        /// <summary>
        /// Computes the ideal point coordinates from the observed point coordinates
        /// </summary>
        /// <param name="dst">The ideal point coordinates, after undistortion and reverse perspective transformation. </param>
        /// <param name="cameraMatrix">The camera matrix A=[fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distCoeffs">The vector of distortion coefficients, 4x1, 1x4, 5x1 or 1x5. </param>
        /// <param name="r">The rectification transformation in object space (3x3 matrix). R1 or R2, computed by cvStereoRectify can be passed here. If the parameter is null, the identity matrix is used. </param>
        /// <param name="p">The new camera matrix (3x3) or the new projection matrix (3x4). P1 or P2, computed by cvStereoRectify can be passed here. If the parameter is null, the identity matrix is used. </param>
#endif
        public void UndistortPoints(CvMat dst, CvMat cameraMatrix, CvMat distCoeffs, CvMat r, CvMat p)
        {
            Cv.UndistortPoints(this, dst, cameraMatrix, distCoeffs, r, p);
        }
        #endregion        

        #region ToArray
#if LANG_JP
        /// <summary>
        /// 1次元配列に変換する
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts this CvMat object to a managed linear array.
        /// </summary>
        /// <returns></returns>
#endif
        public CvScalar[] ToArray()
        {
            int rows = Rows;
            int cols = Cols;
            IntPtr p = CvPtr;
            CvScalar[] result = new CvScalar[cols * rows];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    result[r * cols + c] = CvInvoke.cvGet2D(p, r, c);
                }
            }

            return result;
        }
#if LANG_JP
        /// <summary>
        /// 2次元配列に変換する
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts this CvMat object to a managed rectangular array.
        /// </summary>
        /// <returns></returns>
#endif
        public CvScalar[,] ToRectangularArray()
        {
            int rows = Rows;
            int cols = Cols;   
            IntPtr p = CvPtr;
            CvScalar[,] result = new CvScalar[cols, rows];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    result[r, c] = CvInvoke.cvGet2D(p, r, c);
                }
            }  
          
            return result;
        }
        #endregion
        #region ToString
#if LANG_JP
        /// <summary>
        /// 文字列形式を返す. 1チャンネルの場合のみに対応している.
        /// </summary>
        /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
        public override string ToString()
        {
            if (ElemChannels == 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CvMat(Rows={0}, Cols={1})\n", Rows, Cols);
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        sb.Append(Cv.mGet(this, i, j));
                        sb.Append("\t");
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            return base.ToString();
        }
        #endregion
        #endregion

        #region IEnumerable<CvScalar> Members
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<CvScalar> GetEnumerator()
        {
            int rows = Rows;
            int cols = Cols;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    yield return CvInvoke.cvGet2D(ptr, r, c);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}