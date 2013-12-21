/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region DecRefData
#if LANG_JP
        /// <summary>
        /// 参照カウンタのポインタが null ではない場合に CvMat あるいは CvMatND のデータの参照カウンタをデクリメントし，さらにカウンタが 0 になった場合にはデータを解放する．
        /// </summary>
        /// <param name="arr">配列ヘッダ</param>
#else
        /// <summary>
        /// Decrements array data reference counter．
        /// </summary>
        /// <param name="arr">Input array. </param>
#endif
        public static void DecRefData(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            unsafe
            {
                if (arr is CvMat)
                {
                    CvMat mat = (CvMat)arr;
                    mat.Data = IntPtr.Zero;
                    if (mat.RefCount != IntPtr.Zero && --*(int*)mat.RefCount == 0)
                        CvInvoke.cvFree_(mat.RefCount);
                    mat.RefCount = IntPtr.Zero;
                }
                else if (arr is CvMatND)
                {
                    CvMatND mat = (CvMatND)arr;
                    mat.Data = IntPtr.Zero;
                    if (mat.RefCount != IntPtr.Zero && --*(int*)mat.RefCount == 0)
                        CvInvoke.cvFree_(mat.RefCount);
                    mat.RefCount = IntPtr.Zero;
                }
            }
        }
        #endregion
        #region Det
#if LANG_JP
        /// <summary>
        /// 行列式を返す
        /// </summary>
        /// <param name="mat">入力行列</param>
        /// <returns>行列式</returns>
#else
        /// <summary>
        /// Returns determinant of matrix
        /// </summary>
        /// <param name="mat">The source matrix. </param>
        /// <returns>determinant of the square matrix mat</returns>
#endif
        public static double Det(CvArr mat)
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            return CvInvoke.cvDet(mat.CvPtr);
        }
        #endregion
        #region DCT
#if LANG_JP
        /// <summary>
        /// 次元あるいは2次元浮動小数点型配列の順方向・逆方向離散コサイン変換を行う
        /// </summary>
        /// <param name="src">入力配列（実数の1次元あるいは2次元配列）</param>
        /// <param name="dst">入力と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Cosine transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="src">Source array, real 1D or 2D array. </param>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags.</param>
#endif
        public static void DCT(CvArr src, CvArr dst, DCTFlag flags)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvDCT(src.CvPtr, dst.CvPtr, flags);
        }
        #endregion
        #region DecodeImage
#if LANG_JP
        /// <summary>
        /// 指定したバッファメモリから画像を読み込む
        /// </summary>
        /// <param name="buf">入力のbyte配列</param>
        /// <param name="iscolor">出力の色を指定するフラグ</param>
        /// <returns></returns>        
#else
        /// <summary>
        /// Decode image stored in the buffer
        /// </summary>
        /// <param name="buf">The input array of vector of bytes</param>
        /// <param name="iscolor">Specifies color type of the loaded image</param>
        /// <returns></returns>
#endif
        public static IplImage DecodeImage(CvMat buf, LoadMode iscolor)
        {
            if (buf == null)
                throw new ArgumentNullException("buf");
            IntPtr ptr = CvInvoke.cvDecodeImage(buf.CvPtr, iscolor);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new IplImage(ptr, true);
        }
#if LANG_JP
        /// <summary>
        /// 指定したバッファメモリから画像をCvMatとして読み込む
        /// </summary>
        /// <param name="buf">入力のbyte配列</param>
        /// <param name="iscolor">出力の色を指定するフラグ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Decode image stored in the buffer
        /// </summary>
        /// <param name="buf">The input array of vector of bytes</param>
        /// <param name="iscolor">Specifies color type of the loaded image</param>
        /// <returns></returns>
#endif
        public static CvMat DecodeImageM(CvMat buf, LoadMode iscolor)
        {
            if (buf == null)
                throw new ArgumentNullException("buf");
            IntPtr ptr = CvInvoke.cvDecodeImageM(buf.CvPtr, iscolor);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMat(ptr, true);
        }
        #endregion
        #region DecomposeProjectionMatrix
#if LANG_JP
        /// <summary>
        /// 射影行列をキャリブレーション行列と回転行列とカメラの同次座標系での位置ベクトルに分解する
        /// </summary>
        /// <param name="projMatr">入力の3x4の射影行列 P</param>
        /// <param name="calibMatr">出力の3x3の内部キャリブレーション行列 K</param>
        /// <param name="rotMatr">出力の3x3の外部回転行列 R</param>
        /// <param name="posVect">出力の4x1の同次座標系での外部位置ベクトル C</param>
#else
        /// <summary>
        /// Computes projection matrix decomposition
        /// </summary>
        /// <param name="projMatr">The 3x4 input projection matrix P</param>
        /// <param name="calibMatr">The output 3x3 internal calibration matrix K</param>
        /// <param name="rotMatr">The output 3x3 external rotation matrix R</param>
        /// <param name="posVect">The output 4x1 external homogenious position vector C</param>
#endif
        public static void DecomposeProjectionMatrix(CvMat projMatr, CvMat calibMatr, CvMat rotMatr, CvMat posVect)
        {
            CvPoint3D64f eulerAngles;
            DecomposeProjectionMatrix(projMatr, calibMatr, rotMatr, posVect, null, null, null, out eulerAngles);
        }
#if LANG_JP
        /// <summary>
        /// 射影行列をキャリブレーション行列と回転行列とカメラの同次座標系での位置ベクトルに分解する
        /// </summary>
        /// <param name="projMatr">入力の3x4の射影行列 P</param>
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
        /// <param name="projMatr">The 3x4 input projection matrix P</param>
        /// <param name="calibMatr">The output 3x3 internal calibration matrix K</param>
        /// <param name="rotMatr">The output 3x3 external rotation matrix R</param>
        /// <param name="posVect">The output 4x1 external homogenious position vector C</param>
        /// <param name="rotMatrX">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="rotMatrY">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="rotMatrZ">Optional 3x3 rotation matrix around z-axis</param>
#endif
        public static void DecomposeProjectionMatrix(CvMat projMatr, CvMat calibMatr, CvMat rotMatr, CvMat posVect,
            CvMat rotMatrX, CvMat rotMatrY, CvMat rotMatrZ)
        {
            CvPoint3D64f eulerAngles;
            DecomposeProjectionMatrix(projMatr, calibMatr, rotMatr, posVect, rotMatrX, rotMatrY, rotMatrZ, out eulerAngles);
        }
#if LANG_JP
        /// <summary>
        /// 射影行列をキャリブレーション行列と回転行列とカメラの同次座標系での位置ベクトルに分解する
        /// </summary>
        /// <param name="projMatr">入力の3x4の射影行列 P</param>
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
        /// <param name="projMatr">The 3x4 input projection matrix P</param>
        /// <param name="calibMatr">The output 3x3 internal calibration matrix K</param>
        /// <param name="rotMatr">The output 3x3 external rotation matrix R</param>
        /// <param name="posVect">The output 4x1 external homogenious position vector C</param>
        /// <param name="rotMatrX">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="rotMatrY">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="rotMatrZ">Optional 3x3 rotation matrix around z-axis</param>
        /// <param name="eulerAngles">Optional 3 points containing the three Euler angles of rotation</param>
#endif
        public static void DecomposeProjectionMatrix(CvMat projMatr, CvMat calibMatr, CvMat rotMatr, CvMat posVect,
            CvMat rotMatrX, CvMat rotMatrY, CvMat rotMatrZ, out CvPoint3D64f eulerAngles)
        {
            if (projMatr == null)
                throw new ArgumentNullException("projMatr");
            if (calibMatr == null)
                throw new ArgumentNullException("calibMatr");
            if (rotMatr == null)
                throw new ArgumentNullException("rotMatr");
            if (posVect == null)
                throw new ArgumentNullException("posVect");

            IntPtr rotMatrXPtr = (rotMatrX == null) ? IntPtr.Zero : rotMatrX.CvPtr;
            IntPtr rotMatrYPtr = (rotMatrY == null) ? IntPtr.Zero : rotMatrY.CvPtr;
            IntPtr rotMatrZPtr = (rotMatrZ == null) ? IntPtr.Zero : rotMatrZ.CvPtr;
            eulerAngles = new CvPoint3D64f();

            CvInvoke.cvDecomposeProjectionMatrix(projMatr.CvPtr, calibMatr.CvPtr, rotMatr.CvPtr, posVect.CvPtr,
                rotMatrXPtr, rotMatrYPtr, rotMatrZPtr, ref eulerAngles);
        }
        #endregion
        #region DeleteMoire
#if LANG_JP
        /// <summary>
        /// 入力画像のモアレを削除する
        /// </summary>
        /// <param name="img">入力画像</param>
#else
        /// <summary>
        /// Deletes moire in given image
        /// </summary>
        /// <param name="img">Image. </param>
#endif
        public static void DeleteMoire(IplImage img)
        {
            CvInvoke.cvDeleteMoire(img.CvPtr);
        }
        #endregion
        #region DestroyAllWindows
#if LANG_JP
        /// <summary>
        /// オープンされている全ての HighGUI ウィンドウを破棄する
        /// </summary>
#else
        /// <summary>
        /// Destroys all the opened HighGUI windows. 
        /// </summary>
#endif
        public static void DestroyAllWindows()
        {
            //OpenCV.cvDestroyAllWindows();
            CvWindow.DestroyAllWindows();
        }
        #endregion
        #region DestroyWindow
#if LANG_JP
        /// <summary>
        /// 指定された名前のウィンドウを破棄する
        /// </summary>
        /// <param name="name">破棄するウィンドウの名前</param>
#else
        /// <summary>
        /// Destroys the window with a given name. 
        /// </summary>
        /// <param name="name">Name of the window to be destroyed. </param>
#endif
        public static void DestroyWindow(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            //CvInvoke.cvDestroyWindow(name);
            CvWindow window = CvWindow.GetWindowByName(name);
            if (window == null)
            {
                CvInvoke.cvDestroyWindow(name);
            }
            else
            {
                window.Dispose();
            }
        }
        #endregion
        #region DFT
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う.
        /// </summary>
        /// <param name="src">入力配列（実数または複素数）</param>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="src">Source array, real or complex. </param>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
#endif
        public static void DFT(CvArr src, CvArr dst, DFTFlag flags)
        {
            DFT(src, dst, flags, 0);
        }
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う.
        /// </summary>
        /// <param name="src">入力配列（実数または複素数）</param>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
        /// <param name="nonzeroRows">入力配列の非0である行の数（2次元順変換の場合），あるいは出力配列で注目する行の数（2次元逆変換の場合）．</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="src">Source array, real or complex. </param>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
        /// <param name="nonzeroRows">Number of nonzero rows to in the source array (in case of forward 2d transform), or a number of rows of interest in the destination array (in case of inverse 2d transform). If the value is negative, zero, or greater than the total number of rows, it is ignored. The parameter can be used to speed up 2d convolution/correlation when computing them via DFT.</param>
#endif
        public static void DFT(CvArr src, CvArr dst, DFTFlag flags, int nonzeroRows)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvDFT(src.CvPtr, dst.CvPtr, flags, nonzeroRows);
        }
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う. cvDFTのエイリアス.
        /// </summary>
        /// <param name="src">入力配列（実数または複素数）</param>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="src">Source array, real or complex. </param>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
#endif
        public static void FFT(CvArr src, CvArr dst, DFTFlag flags)
        {
            DFT(src, dst, flags);
        }
#if LANG_JP
        /// <summary>
        /// 1次元あるいは2次元浮動小数点型配列に対して離散フーリエ変換（DFT），逆離散フーリエ変換（IDFT）を行う.cvDFTのエイリアス.
        /// </summary>
        /// <param name="src">入力配列（実数または複素数）</param>
        /// <param name="dst">入力配列と同じサイズ・タイプの出力配列</param>
        /// <param name="flags">変換フラグ</param>
        /// <param name="nonzeroRows">入力配列の非0である行の数（2次元順変換の場合），あるいは出力配列で注目する行の数（2次元逆変換の場合）．</param>
#else
        /// <summary>
        /// Performs forward or inverse Discrete Fourier transform of 1D or 2D floating-point array
        /// </summary>
        /// <param name="src">Source array, real or complex. </param>
        /// <param name="dst">Destination array of the same size and same type as the source. </param>
        /// <param name="flags">Transformation flags</param>
        /// <param name="nonzeroRows">Number of nonzero rows to in the source array (in case of forward 2d transform), or a number of rows of interest in the destination array (in case of inverse 2d transform). If the value is negative, zero, or greater than the total number of rows, it is ignored. The parameter can be used to speed up 2d convolution/correlation when computing them via DFT.</param>
#endif
        public static void FFT(CvArr src, CvArr dst, DFTFlag flags, int nonzeroRows)
        {
            DFT(src, dst, flags, nonzeroRows);
        }
        #endregion
        #region Dilate
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を膨張する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．膨張は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Dilates image by using arbitrary structuring element.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
#endif
        public static void Dilate(CvArr src, CvArr dst)
        {
            Dilate(src, dst, null, 1);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を膨張する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．膨張は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="element">膨張に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
#else
        /// <summary>
        /// Dilates image by using arbitrary structuring element.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
#endif
        public static void Dilate(CvArr src, CvArr dst, IplConvKernel element)
        {
            Dilate(src, dst, element, 1);
        }
#if LANG_JP
        /// <summary>
        /// 隣接ピクセルの形状を決定する指定された構造要素を用いて，入力画像を膨張する. 
        /// この関数はインプレースモード（src=dstである入力）をサポートする．膨張は複数回 (iterations) 繰り返すことができる．
        /// カラー画像の場合は，それぞれのチャンネルが独立に処理される． 
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="element">膨張に用いる構造要素．nullの場合は, 3×3 の矩形形状の構造要素を用いる．</param>
        /// <param name="iterations">膨張の回数</param>
#else
        /// <summary>
        /// Dilates image by using arbitrary structuring element.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
        /// <param name="element">Structuring element used for erosion. If it is null, a 3x3 rectangular structuring element is used. </param>
        /// <param name="iterations">Number of times erosion is applied. </param>
#endif
        public static void Dilate(CvArr src, CvArr dst, IplConvKernel element, int iterations)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr elemPtr = (element == null) ? IntPtr.Zero : element.CvPtr;
            CvInvoke.cvDilate(src.CvPtr, dst.CvPtr, elemPtr, iterations);
        }
        #endregion
        #region DisplayOverlay
#if LANG_JP
        /// <summary>
        /// ウィンドウ画像上に，delay ミリ秒間だけテキストをオーバレイ表示します．これは，画像データを変更しません．テキストは画像の一番上に表示されます．
        /// </summary>
        /// <param name="name">ウィンドウの名前．</param>
        /// <param name="text">ウィンドウ画像上に描画される，オーバレイテキスト．</param>
        /// <param name="delayms">オーバレイテキストを表示する時間．直前のオーバレイテキストがタイムアウトするより前に，この関数が呼ばれると，タイマーは再起動されてテキストが更新されます．この値が0の場合，テキストは表示されません．</param>
#else
        /// <summary>
        /// Display text on the window's image as an overlay for delay milliseconds. This is not editing the image's data. The text is display on the top of the image.
        /// </summary>
        /// <param name="name">Name of the window</param>
        /// <param name="text">Overlay text to write on the window’s image</param>
        /// <param name="delayms">Delay to display the overlay text. If this function is called before the previous overlay text time out, the timer is restarted and the text updated. . If this value is zero, the text never disapers.</param>
#endif
        public static void DisplayOverlay(string name, string text, int delayms)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (text == null)
                throw new ArgumentNullException("text");
            CvInvoke.cvDisplayOverlay(name, text, delayms);
        }
        #endregion
        #region DisplayStatusBar
#if LANG_JP
        /// <summary>
        /// ウィンドウのステータスバーに，delay ミリ秒間だけテキストを表示します．
        /// </summary>
        /// <param name="name">ウィンドウの名前．</param>
        /// <param name="text">ウィンドウのステータスバー上に描画されるテキスト．</param>
        /// <param name="delayms">テキストが表示される時間．直前のテキストがタイムアウトするより前に，この関数が呼ばれると，タイマーは再起動されてテキストが更新されます．この値が0の場合，テキストは表示されません．</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of the window</param>
        /// <param name="text">Text to write on the window’s statusbar</param>
        /// <param name="delayms">Delay to display the text. If this function is called before the previous text time out, the timer is restarted and the text updated. If this value is zero, the text never disapers.</param>
#endif
        public static void DisplayStatusBar(string name, string text, int delayms)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (text == null)
                throw new ArgumentNullException("text");
            CvInvoke.cvDisplayStatusBar(name, text, delayms);
        }
        #endregion
        #region DistTransform
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="src">入力画像（8ビット，シングルチャンネル，2値画像）</param>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel (binary) image. </param>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
#endif
        public static void DistTransform(CvArr src, CvArr dst)
        {
            DistTransform(src, dst, DistanceType.L2, 3, null, null, DistTransformLabelType.CComp);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="src">入力画像（8ビット，シングルチャンネル，2値画像）</param>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel (binary) image. </param>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
#endif
        public static void DistTransform(CvArr src, CvArr dst, DistanceType distanceType)
        {
            DistTransform(src, dst, distanceType, 3, null, null, DistTransformLabelType.CComp);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="src">入力画像（8ビット，シングルチャンネル，2値画像）</param>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
        /// <param name="maskSize">距離変換マスクのサイズで，3，5，0 のいずれか． L1，C の場合，このパラメータ値は3に固定される．mask_size==0の場合，距離計算に別の近似無しアルゴリズムが用いられる．</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel (binary) image. </param>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
        /// <param name="maskSize">Size of distance transform mask; can be 3, 5 or 0. In case of CV_DIST_L1 or CV_DIST_C the parameter is forced to 3, because 3×3 mask gives the same result as 5x5 yet it is faster. When mask_size==0, a different non-approximate algorithm is used to calculate distances. </param>
#endif
        public static void DistTransform(CvArr src, CvArr dst, DistanceType distanceType, int maskSize)
        {
            DistTransform(src, dst, distanceType, maskSize, null, null, DistTransformLabelType.CComp);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="src">入力画像（8ビット，シングルチャンネル，2値画像）</param>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
        /// <param name="maskSize">距離変換マスクのサイズで，3，5，0 のいずれか． L1，C の場合，このパラメータ値は3に固定される．mask_size==0の場合，距離計算に別の近似無しアルゴリズムが用いられる．</param>
        /// <param name="mask">ユーザ定義の距離の場合はユーザ定義のマスク．3×3のマスクを用いる場合は2つの値（上下シフト値，斜めシフト値）を指定，5×5のマスクを用いる場合は3つの値（上下シフト値，斜めシフト値，ナイト移動シフト値（桂馬飛びのシフト値））を指定する．</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel (binary) image. </param>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
        /// <param name="maskSize">Size of distance transform mask; can be 3, 5 or 0. In case of CV_DIST_L1 or CV_DIST_C the parameter is forced to 3, because 3×3 mask gives the same result as 5x5 yet it is faster. When mask_size==0, a different non-approximate algorithm is used to calculate distances. </param>
        /// <param name="mask">User-defined mask in case of user-defined distance, it consists of 2 numbers (horizontal/vertical shift cost, diagonal shift cost) in case of 3x3 mask and 3 numbers (horizontal/vertical shift cost, diagonal shift cost, knight’s move cost) in case of 5x5 mask. </param>
#endif
        public static void DistTransform(CvArr src, CvArr dst, DistanceType distanceType, int maskSize, float[] mask)
        {
            DistTransform(src, dst, distanceType, maskSize, mask, null, DistTransformLabelType.CComp);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="src">入力画像（8ビット，シングルチャンネル，2値画像）</param>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
        /// <param name="maskSize">距離変換マスクのサイズで，3，5，0 のいずれか． L1，C の場合，このパラメータ値は3に固定される．mask_size==0の場合，距離計算に別の近似無しアルゴリズムが用いられる．</param>
        /// <param name="mask">ユーザ定義の距離の場合はユーザ定義のマスク．3×3のマスクを用いる場合は2つの値（上下シフト値，斜めシフト値）を指定，5×5のマスクを用いる場合は3つの値（上下シフト値，斜めシフト値，ナイト移動シフト値（桂馬飛びのシフト値））を指定する．</param>
        /// <param name="labels">オプション出力．整数ラベルに変換された2次元配列で，src ，dstと同じサイズ．現在は mask_size==3 あるいは 5 のときのみに使用される．</param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel (binary) image. </param>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
        /// <param name="maskSize">Size of distance transform mask; can be 3, 5 or 0. In case of CV_DIST_L1 or CV_DIST_C the parameter is forced to 3, because 3×3 mask gives the same result as 5x5 yet it is faster. When mask_size==0, a different non-approximate algorithm is used to calculate distances. </param>
        /// <param name="mask">User-defined mask in case of user-defined distance, it consists of 2 numbers (horizontal/vertical shift cost, diagonal shift cost) in case of 3x3 mask and 3 numbers (horizontal/vertical shift cost, diagonal shift cost, knight’s move cost) in case of 5x5 mask. </param>
        /// <param name="labels">The optional output 2d array of labels of integer type and the same size as src and dst, can now be used only with mask_size==3 or 5. </param>
#endif
        public static void DistTransform(CvArr src, CvArr dst, DistanceType distanceType, int maskSize, float[] mask, CvArr labels)
        {
            DistTransform(src, dst, distanceType, maskSize, mask, labels, DistTransformLabelType.CComp);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像中の値が0でないピクセルから，最も近い値が0のピクセルまでの距離を計算する
        /// </summary>
        /// <param name="src">入力画像（8ビット，シングルチャンネル，2値画像）</param>
        /// <param name="dst">距離計算結果をピクセル値として持つ出力画像 （32ビット浮動小数点型，シングルチャンネル）</param>
        /// <param name="distanceType">距離の種類．L1, L2, C か User</param>
        /// <param name="maskSize">距離変換マスクのサイズで，3，5，0 のいずれか． L1，C の場合，このパラメータ値は3に固定される．mask_size==0の場合，距離計算に別の近似無しアルゴリズムが用いられる．</param>
        /// <param name="mask">ユーザ定義の距離の場合はユーザ定義のマスク．3×3のマスクを用いる場合は2つの値（上下シフト値，斜めシフト値）を指定，5×5のマスクを用いる場合は3つの値（上下シフト値，斜めシフト値，ナイト移動シフト値（桂馬飛びのシフト値））を指定する．</param>
        /// <param name="labels">オプション出力．整数ラベルに変換された2次元配列で，src ，dstと同じサイズ．現在は mask_size==3 あるいは 5 のときのみに使用される．</param>
        /// <param name="labelType"></param>
#else
        /// <summary>
        /// Calculates distance to closest zero pixel for all non-zero pixels of source image.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel (binary) image. </param>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel). </param>
        /// <param name="distanceType">Type of distance. </param>
        /// <param name="maskSize">Size of distance transform mask; can be 3, 5 or 0. In case of CV_DIST_L1 or CV_DIST_C the parameter is forced to 3, because 3×3 mask gives the same result as 5x5 yet it is faster. When mask_size==0, a different non-approximate algorithm is used to calculate distances. </param>
        /// <param name="mask">User-defined mask in case of user-defined distance, it consists of 2 numbers (horizontal/vertical shift cost, diagonal shift cost) in case of 3x3 mask and 3 numbers (horizontal/vertical shift cost, diagonal shift cost, knight’s move cost) in case of 5x5 mask. </param>
        /// <param name="labels">The optional output 2d array of labels of integer type and the same size as src and dst, can now be used only with mask_size==3 or 5. </param>
        /// <param name="labelType"></param>
#endif
        public static void DistTransform(CvArr src, CvArr dst, DistanceType distanceType, int maskSize, float[] mask, CvArr labels, DistTransformLabelType labelType)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr labelsPtr = (labels == null) ? IntPtr.Zero : labels.CvPtr;
            CvInvoke.cvDistTransform(src.CvPtr, dst.CvPtr, distanceType, maskSize, mask, labelsPtr, labelType);
        }
        #endregion
        #region Div
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を除算する (scale=1).
        /// dst(I)=scale*src1(I)/src2(I) [src1!=nullの場合],  
        /// dst(I)=scale/src2(I) [src1=nullの場合]
        /// </summary>
        /// <param name="src1">1番目の入力配列. nullの場合は，すべての要素が 1であると仮定する．</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays
        /// </summary>
        /// <param name="src1">The first source array. If the pointer is NULL, the array is assumed to be all 1’s. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Div(CvArr src1, CvArr src2, CvArr dst)
        {
            Div(src1, src2, dst, 1);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を除算する.
        /// dst(I)=scale*src1(I)/src2(I) [src1!=nullの場合],  
        /// dst(I)=scale/src2(I) [src1=nullの場合]
        /// </summary>
        /// <param name="src1">1番目の入力配列. nullの場合は，すべての要素が 1であると仮定する．</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">任意のスケーリング係数</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays
        /// </summary>
        /// <param name="src1">The first source array. If the pointer is NULL, the array is assumed to be all 1’s. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="scale">Optional scale factor </param>
#endif
        public static void Div(CvArr src1, CvArr src2, CvArr dst, double scale)
        {
            IntPtr src1Ptr = (src1 == null) ? IntPtr.Zero : src1.CvPtr;
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvDiv(src1Ptr, src2.CvPtr, dst.CvPtr, scale);
        }
        #endregion
        #region DotProduct
#if LANG_JP
        /// <summary>
        /// ユークリッド距離に基づく2つの配列の内積を計算する.
        /// src1•src2 = sumI(src1(I)*src2(I))
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <returns>ユークリッド距離に基づく2つの配列の内積</returns>
#else
        /// <summary>
        /// Calculates dot product of two arrays in Euclidean metrics
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <returns></returns>
#endif
        public static double DotProduct(CvArr src1, CvArr src2)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            return CvInvoke.cvDotProduct(src1.CvPtr, src2.CvPtr);
        }
        #endregion
        #region DrawChessboardCorners
#if LANG_JP
        /// <summary>
        /// チェスボードからコーナーが完全に検出されていない場合（pattern_was_found=false）は，検出されたコーナーそれぞれに赤色の円を描く．
        /// また完全に検出されている場合（pattern_was_found=true）は，色付けされた各コーナを線分で接続して表示する． 
        /// </summary>
        /// <param name="image">コーナー点を表示する画像．8ビットカラー画像．</param>
        /// <param name="patternSize">チェスボードの各行と各列の内部コーナーの数．</param>
        /// <param name="corners">検出されたコーナーの配列．</param>
        /// <param name="patternWasFound">チェスボードからコーナーが完全に発見された(true)か，そうでない(false)かを示す．</param>
#else
        /// <summary>
        /// Draws the individual chessboard corners detected (as red circles) in case if the board was not found (pattern_was_found=0) or the colored corners connected with lines when the board was found (pattern_was_found≠0). 
        /// </summary>
        /// <param name="image">The destination image; it must be 8-bit color image. </param>
        /// <param name="patternSize">The number of inner corners per chessboard row and column. </param>
        /// <param name="corners">The array of corners detected. </param>
        /// <param name="patternWasFound">Indicates whether the complete board was found (≠0) or not (=0). One may just pass the return value cvFindChessboardCorners here. </param>
#endif
        public static void DrawChessboardCorners(CvArr image, CvSize patternSize, CvPoint2D32f[] corners, bool patternWasFound)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (corners == null)
                throw new ArgumentNullException("corners");
            CvInvoke.cvDrawChessboardCorners(image.CvPtr, patternSize, corners, corners.Length, patternWasFound);
        }
        #endregion
        #region DrawContours
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="img">輪郭を描画する元画像．輪郭はROIで切り取られる．</param>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="img">Image where the contours are to be drawn. Like in any other drawing function, the contours are clipped with the ROI. </param>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
#endif
        public static void DrawContours(CvArr img, CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel)
        {
            DrawContours(img, contour, externalColor, holeColor, maxLevel, 1, LineType.Link8, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="img">輪郭を描画する元画像．輪郭はROIで切り取られる．</param>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
        /// <param name="thickness">描画される輪郭線の太さ. 負(例えば=Cv.FILLED)にした場合には，内部を塗りつぶす．</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="img">Image where the contours are to be drawn. Like in any other drawing function, the contours are clipped with the ROI. </param>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (e.g. =CV_FILLED), the contour interiors are drawn. </param>
#endif
        public static void DrawContours(CvArr img, CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness)
        {
            DrawContours(img, contour, externalColor, holeColor, maxLevel, thickness, LineType.Link8, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="img">輪郭を描画する元画像．輪郭はROIで切り取られる．</param>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
        /// <param name="thickness">描画される輪郭線の太さ. 負(例えば=Cv.FILLED)にした場合には，内部を塗りつぶす．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="img">Image where the contours are to be drawn. Like in any other drawing function, the contours are clipped with the ROI. </param>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (e.g. =CV_FILLED), the contour interiors are drawn. </param>
        /// <param name="lineType">Type of the contour segments.</param>
#endif
        public static void DrawContours(CvArr img, CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness, LineType lineType)
        {
            DrawContours(img, contour, externalColor, holeColor, maxLevel, thickness, lineType, new CvPoint(0, 0));
        }
#if LANG_JP
        /// <summary>
        /// 画像の外側輪郭線，または内側輪郭線を描画する
        /// </summary>
        /// <param name="img">輪郭を描画する元画像．輪郭はROIで切り取られる．</param>
        /// <param name="contour">最初の輪郭へのポインタ</param>
        /// <param name="externalColor">外側輪郭線の色</param>
        /// <param name="holeColor">内側輪郭線（穴）の色</param>
        /// <param name="maxLevel">描画される輪郭の最大レベル． 0にした場合，contourのみが描画される． 1にした場合，先頭の輪郭と，同レベルのすべての輪郭が描画される． 2にした場合，先頭の輪郭と同レベルのすべての輪郭と，先頭の輪郭の一つ下のレベルのすべての輪郭が描画される．以下同様．</param>
        /// <param name="thickness">描画される輪郭線の太さ. 負(例えば=Cv.FILLED)にした場合には，内部を塗りつぶす．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="offset">全ての座標を指定した値だけシフトする</param>
#else
        /// <summary>
        /// Draws contour outlines or interiors in the image
        /// </summary>
        /// <param name="img">Image where the contours are to be drawn. Like in any other drawing function, the contours are clipped with the ROI. </param>
        /// <param name="contour">Reference to the first contour. </param>
        /// <param name="externalColor">Color of the external contours. </param>
        /// <param name="holeColor">Color of internal contours (holes). </param>
        /// <param name="maxLevel">Maximal level for drawn contours. If 0, only contour is drawn. If 1, the contour and all contours after it on the same level are drawn. If 2, all contours after and all contours one level below the contours are drawn, etc. If the value is negative, the function does not draw the contours following after contour but draws child contours of contour up to abs(max_level)-1 level. </param>
        /// <param name="thickness">Thickness of lines the contours are drawn with. If it is negative (e.g. =CV_FILLED), the contour interiors are drawn. </param>
        /// <param name="lineType">Type of the contour segments.</param>
        /// <param name="offset">Shift all the point coordinates by the specified value. It is useful in case if the contours retrieved in some image ROI and then the ROI offset needs to be taken into account during the rendering. </param>
#endif
        public static void DrawContours(CvArr img, CvSeq<CvPoint> contour, CvScalar externalColor, CvScalar holeColor, int maxLevel, int thickness, LineType lineType, CvPoint offset)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (contour == null)
                throw new ArgumentNullException("contour");
            CvInvoke.cvDrawContours(img.CvPtr, contour.CvPtr, externalColor, holeColor, maxLevel, thickness, lineType, offset);
        }
        #endregion
    }
}