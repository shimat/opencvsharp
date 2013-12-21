/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region Rand
#if LANG_JP
        /// <summary>
        /// 配列をランダムな値で埋める
        /// </summary>
        /// <param name="state"></param>
        /// <param name="arr"></param>
#else
        /// <summary>
        /// Fills array with random numbers
        /// </summary>
        /// <param name="state">CvRandState Structure</param>
        /// <param name="arr">The array to randomize</param>
#endif
        public static void Rand(CvRandState state, CvArr arr)
        {
            if (state == null)
                throw new ArgumentNullException("state", "Null pointer to RNG state");
            if (arr == null)
                throw new ArgumentNullException("arr");

            RandArr(state.State, arr, state.DistType, state.Param[0], state.Param[1]);
        }
        #endregion
        #region RandArr
#if LANG_JP
        /// <summary>
        /// 一様または正規分布の乱数で出力配列を埋める 
        /// </summary>
        /// <param name="rng">cvRNGによって初期化されたRNGの状態</param>
        /// <param name="arr">出力配列</param>
        /// <param name="distType">分布のタイプ</param>
        /// <param name="param1">分布の第一パラメータ．一様分布では，発生する乱数の下限値（この値を含む）である． 正規分布では，乱数の平均値である．</param>
        /// <param name="param2">分布の第二パラメータ．一様分布では，発生する乱数の上限値（この値は含まない）である． 正規分布では，乱数の標準偏差である．</param>
#else
        /// <summary>
        /// Fills array with random numbers and updates the RNG state
        /// </summary>
        /// <param name="rng">RNG state initialized by cvRNG. </param>
        /// <param name="arr">The destination array. </param>
        /// <param name="distType">Distribution type.</param>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
#endif
        public static void RandArr(CvRNG rng, CvArr arr, DistributionType distType, CvScalar param1, CvScalar param2)
        {
            if (rng == null)
                throw new ArgumentNullException("rng");
            if (arr == null)
                throw new ArgumentNullException("arr");
            UInt64 rngVal = rng.Seed;
            CvInvoke.cvRandArr(ref rngVal, arr.CvPtr, distType, param1, param2);
            rng.Seed = rngVal;
        }
        #endregion
        #region RandInit
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
#else
        /// <summary>
        /// Initialize CvRandState structure
        /// </summary>
        /// <param name="state">CvRandState structure to initialize</param>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
        /// <param name="seed">Seed value</param>
#endif
        public static void RandInit(CvRandState state, double param1, double param2, int seed)
        {
            RandInit(state, param1, param2, seed, DistributionType.Uniform);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
        /// <param name="disttype"></param>
#else
        /// <summary>
        /// Initialize CvRandState structure
        /// </summary>
        /// <param name="state">CvRandState structure to initialize</param>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
        /// <param name="seed">Seed value</param>
        /// <param name="disttype">Type of distribution</param>
#endif
        public static void RandInit(CvRandState state, double param1, double param2, int seed, DistributionType disttype)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state", "Null pointer to RNG state");
            }
            if (disttype != DistributionType.Uniform && disttype != DistributionType.Normal)
            {
                throw new ArgumentOutOfRangeException("disttype", "Unknown distribution type");
            }

            state.State = new CvRNG((UInt64)(seed != 0 ? seed : -1));
            state.DistType = disttype;
            RandSetRange(state, param1, param2, -1);
        }
        #endregion
        #region RandInt
#if RANG_JP
        /// <summary>
        /// 一様分布した32ビット符号なし整数型の乱数を返し，RNGの状態を更新する．
        /// </summary>
        /// <param name="rng">RandInitによって初期化され，オプションでRandSetRangeによってカスタマイズされたRNGの状態（後者の関数は，この関数の結果に影響を及ぼさない）</param>
        /// <returns>32ビット符号なし整数</returns>
#else
        /// <summary>
        /// Returns 32-bit unsigned integer and updates RNG
        /// </summary>
        /// <param name="rng">RNG state initialized by RandInit and, optionally, customized by RandSetRange (though, the latter function does not affect on the discussed function outcome). </param>
        /// <returns>uniformly-distributed random 32-bit unsigned integer</returns>
#endif
        public static uint RandInt(CvRNG rng)
        {
            if (rng == null)
            {
                throw new ArgumentNullException("rng");
            }
            UInt64 temp = rng.Seed;
            temp = (UInt64)(UInt32)temp * 1554115554 + (temp >> 32);
            rng.Seed = temp;
            return (UInt32)temp;
        }
        #endregion
        #region RandReal
#if RANG_JP
        /// <summary>
        /// 0から1（1は含まれない）の範囲に一様分布する浮動小数点型の乱数を返す．
        /// </summary>
        /// <param name="rng">cvRNGによって初期化された，RNGの状態</param>
        /// <returns>0から1（1は含まれない）の範囲に一様分布する浮動小数点型</returns>
#else
        /// <summary>
        /// Returns floating-point random number and updates RNG
        /// </summary>
        /// <param name="rng">RNG state initialized by cvRNG. </param>
        /// <returns>uniformly-distributed random floating-point number from 0..1 range (1 is not included).</returns>
#endif
        public static double RandReal(CvRNG rng)
        {
            if (rng == null)
            {
                throw new ArgumentNullException("rng");
            }
            return RandInt(rng) * 2.3283064365386962890625e-10;
        }
        #endregion
        #region RANSACUpdateNumIters
#if LANG_JP
        /// <summary>
        /// updates the number of RANSAC iterations
        /// </summary>
        /// <param name="p"></param>
        /// <param name="errProb"></param>
        /// <param name="modelPoints"></param>
        /// <param name="maxIters"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// updates the number of RANSAC iterations
        /// </summary>
        /// <param name="p"></param>
        /// <param name="errProb"></param>
        /// <param name="modelPoints"></param>
        /// <param name="maxIters"></param>
        /// <returns></returns>
#endif
        public static int RANSACUpdateNumIters(double p, double errProb, int modelPoints, int maxIters)
        {
            return CvInvoke.cvRANSACUpdateNumIters(p, errProb, modelPoints, maxIters);
        }
        #endregion
        #region RandSetRange
#if LANG_JP
        /// <summary>
        /// Changes RNG range while preserving RNG state
        /// </summary>
        /// <param name="state"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
#else
        /// <summary>
        /// Changes RNG range while preserving RNG state
        /// </summary>
        /// <param name="state">CvRandState structure to be opdated</param>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
#endif
        public static void RandSetRange(CvRandState state, double param1, double param2)
        {
            RandSetRange(state, param1, param2, -1);
        }
#if LANG_JP
        /// <summary>
        /// Changes RNG range while preserving RNG state
        /// </summary>
        /// <param name="state"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="index"></param>
#else
        /// <summary>
        /// Changes RNG range while preserving RNG state
        /// </summary>
        /// <param name="state">CvRandState structure to be opdated</param>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
        /// <param name="index">Index dimension to initialize, -1 = all</param>
#endif
        public static void RandSetRange(CvRandState state, double param1, double param2, int index)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state", "Null pointer to RNG state");
            }

            if ((uint)(index + 1) > 4)
            {
                throw new ArgumentOutOfRangeException("index", "index is not in -1..3");
            }

            if (index < 0)
            {
                state.Param[0] = CvScalar.ScalarAll(param1);
                state.Param[1] = CvScalar.ScalarAll(param2);
            }
            else
            {
                CvScalar p1 = state.Param[0];
                CvScalar p2 = state.Param[0];
                p1[index] = param1;
                p2[index] = param2;
                state.Param[0] = p1;
                state.Param[1] = p2;
            }
        }
        #endregion
        #region RandShuffle
#if LANG_JP
        /// <summary>
        /// ランダムに選ばれた配列要素ペアの入れ替えを反復することにより行列をシャッフルする（マルチチャンネル配列の場合，それぞれの要素は複数の成分を含む）．
        /// </summary>
        /// <param name="mat">入力/出力行列．インプレースモードでシャッフルされる．</param>
#else
        /// <summary>
        /// Randomly shuffles the array elements
        /// </summary>
        /// <param name="mat">The input/output matrix. It is shuffled in-place. </param>
#endif
        public static void RandShuffle(CvArr mat)
        {
            RandShuffle(mat, null);
        }
#if LANG_JP
        /// <summary>
        /// ランダムに選ばれた配列要素ペアの入れ替えを反復することにより行列をシャッフルする（マルチチャンネル配列の場合，それぞれの要素は複数の成分を含む）．
        /// </summary>
        /// <param name="mat">入力/出力行列．インプレースモードでシャッフルされる．</param>
        /// <param name="rng">要素のシャッフルで用いられる Random Number Generator．ポインタがnullの場合，一時的なRNGが生成され，利用される．</param>
#else
        /// <summary>
        /// Randomly shuffles the array elements
        /// </summary>
        /// <param name="mat">The input/output matrix. It is shuffled in-place. </param>
        /// <param name="rng">The Random Number Generator  used to shuffle the elements. When the pointer is null, a temporary RNG will be created and used. </param>
#endif
        public static void RandShuffle(CvArr mat, CvRNG rng)
        {
            RandShuffle(mat, rng, 1);
        }
#if LANG_JP
        /// <summary>
        /// ランダムに選ばれた配列要素ペアの入れ替えを反復することにより行列をシャッフルする（マルチチャンネル配列の場合，それぞれの要素は複数の成分を含む）．
        /// </summary>
        /// <param name="mat">入力/出力行列．インプレースモードでシャッフルされる．</param>
        /// <param name="rng">要素のシャッフルで用いられる Random Number Generator．ポインタがnullの場合，一時的なRNGが生成され，利用される．</param>
        /// <param name="iterFactor">シャッフルの強さを指定するパラメータ.</param>
#else
        /// <summary>
        /// Randomly shuffles the array elements
        /// </summary>
        /// <param name="mat">The input/output matrix. It is shuffled in-place. </param>
        /// <param name="rng">The Random Number Generator  used to shuffle the elements. When the pointer is null, a temporary RNG will be created and used. </param>
        /// <param name="iterFactor">The relative parameter that characterizes intensity of the shuffling performed. </param>
#endif
        public static void RandShuffle(CvArr mat, CvRNG rng, double iterFactor)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            
            if (rng == null)
            {
                UInt64 rngVal = 0;
                CvInvoke.cvRandShuffle(mat.CvPtr, ref rngVal, iterFactor);
            }
            else
            {
                UInt64 rngVal = rng.Seed;
                CvInvoke.cvRandShuffle(mat.CvPtr, ref rngVal, iterFactor);
                rng.Seed = rngVal;
            }
        }
        #endregion
        #region Range
#if LANG_JP
        /// <summary>
        /// 与えられた範囲の数で行列を埋める．次のように行列を初期化する．
        /// arr(i,j) = (End-Start) * (i*cols(arr)+j) / (cols(arr)*rows(arr)) 
        /// </summary>
        /// <param name="mat">初期化される行列．これは，整数型あるいは浮動小数点型 32 ビットシングルチャンネルでなくてはならない．</param>
        /// <param name="start">範囲の下限（範囲に含まれる）</param>
        /// <param name="end">範囲の上限（範囲に含まれない）</param>
#else
        /// <summary>
        /// Fills matrix with given range of numbers as following:
        /// arr(i,j) = (end-start) * (i*cols(arr)+j) / (cols(arr)*rows(arr))
        /// </summary>
        /// <param name="mat">The matrix to initialize. It should be single-channel 32-bit, integer or floating-point. </param>
        /// <param name="start">The lower inclusive boundary of the range. </param>
        /// <param name="end">The upper exclusive boundary of the range. </param>
#endif
        public static void Range(CvArr mat, double start, double end)
        {
            if (mat == null)
            {
                throw new ArgumentNullException("mat");
            }
            CvInvoke.cvRange(mat.CvPtr, start, end);
        }
        #endregion
        #region Read
#if LANG_JP
        /// <summary>
        /// オブジェクトをデコードし，その参照を返す.
        /// </summary>
        /// <typeparam name="T">返却値の型(CvArr派生型)</typeparam>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="node">ルートオブジェクトノード</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Decodes object and returns pointer to it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fs">File storage. </param>
        /// <param name="node">The root object node. </param>
        /// <returns></returns>
#endif
        public static T Read<T>(CvFileStorage fs, CvFileNode node) where T : CvArr
        {
            if (fs == null)
            {
                throw new ArgumentNullException("fs");
            }
            IntPtr nodePtr = (node == null) ? IntPtr.Zero : node.CvPtr;
            IntPtr result = CvInvoke.cvRead(fs.CvPtr, nodePtr, IntPtr.Zero);

            Type t = typeof(T);
            if (t == typeof(IplImage))
                return (T)(object)(new IplImage(result));
            if (t == typeof(CvMat))
                return (T)(object)(new CvMat(result));
            if (t == typeof(CvMatND))
                return (T)(object)(new CvMatND(result));
            if (t == typeof(CvSparseMat))
                return (T)(object)(new CvSparseMat(result));
            if (t == typeof(CvSeq))
                return (T)(object)(new CvSeq(result));

            ConstructorInfo info = t.GetConstructor(new Type[] { typeof(IntPtr) });
            if (info != null)
            {
                return (T)info.Invoke(BindingFlags.CreateInstance, null, new object[] { result }, null);
            }
            throw new NotSupportedException();
        }
        #endregion
        #region ReadByName
#if LANG_JP
        /// <summary>
        /// オブジェクトをデコードし，デコードする.
        /// cvGetFileNodeByName とcvReadの単純な合成である．
        /// </summary>
        /// <typeparam name="T">返却値の型(CvArr派生型)</typeparam>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する．</param>
        /// <param name="name">ノード名</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds object and decodes it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public static T ReadByName<T>(CvFileStorage fs, CvFileNode map, string name) where T : CvArr
        {
            if (fs == null)
            {
                throw new ArgumentNullException("fs");
            }
            IntPtr mapPtr = (map == null) ? IntPtr.Zero : map.CvPtr;
            IntPtr result = CvInvoke.cvRead(fs.CvPtr, CvInvoke.cvGetFileNodeByName(fs.CvPtr, mapPtr, name), IntPtr.Zero);

            Type t = typeof(T);
            if (t == typeof(IplImage))
                return (T)(object)(new IplImage(result));
            if (t == typeof (CvMat))
                return (T)(object)(new CvMat(result));
            if (t == typeof (CvMatND))
                return (T)(object)(new CvMatND(result));
            if (t == typeof (CvSparseMat))
                return (T)(object)(new CvSparseMat(result));
            if (t == typeof (CvSeq))
                return (T)(object)(new CvSeq(result));

            ConstructorInfo info = t.GetConstructor(new Type[] {typeof (IntPtr)});
            if (info != null)
            {
                return (T) info.Invoke(BindingFlags.CreateInstance, null, new object[] {result}, null);
            }
            throw new NotSupportedException();
        }

        #endregion
        #region ReadChainPoint
#if LANG_JP
        /// <summary>
        /// チェーン上の次の点を得る
        /// </summary>
        /// <param name="reader">チェーンリーダの状態</param>
        /// <returns>現在のチェーン上の点</returns>
#else
        /// <summary>
        /// Gets next chain point
        /// </summary>
        /// <param name="reader">Chain reader state.</param>
        /// <returns>Current chain point.</returns>
#endif
        public static CvPoint ReadChainPoint(CvChainPtReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            return CvInvoke.cvReadChainPoint(reader.CvPtr);
        }
        #endregion      
        #region ReadInt
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された整数値を返す．
        /// </summary>
        /// <param name="node">ファイルノード</param>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Retrieves integer value from file node
        /// </summary>
        /// <param name="node">File node. </param>
        /// <returns>integer that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public static int ReadInt(CvFileNode node)
        {
            return ReadInt(node, 0);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された整数値を返す．
        /// </summary>
        /// <param name="node">ファイルノード</param>
        /// <param name="defaultValue">nodeがnullの場合の戻り値</param>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Retrieves integer value from file node
        /// </summary>
        /// <param name="node">File node. </param>
        /// <param name="defaultValue">The value that is returned if node is null. </param>
        /// <returns>integer that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public static int ReadInt(CvFileNode node, int defaultValue)
        {
            return (node == null) ? defaultValue 
                : NODE_IS_INT(node.Tag) ? node.DataI 
                : NODE_IS_REAL(node.Tag) ? Round(node.DataF) 
                : 0x7fffffff;
        }
        #endregion
        #region ReadIntByName
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadIntの単純な合成である．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public static int ReadIntByName(CvFileStorage fs, CvFileNode map, string name)
        {
            return ReadIntByName(fs, map, name, 0);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadIntの単純な合成である．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <param name="defaultValue">ファイルノードが見つからない場合の戻り値</param>
        /// <returns>ファイルノードで表現された整数値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <param name="defaultValue">The value that is returned if the file node is not found. </param>
        /// <returns></returns>
#endif
        public static int ReadIntByName(CvFileStorage fs, CvFileNode map, string name, int defaultValue)
        {
            if (fs == null)
            {
                throw new ArgumentNullException("fs");
            }
            return ReadInt(GetFileNodeByName(fs, map, name), defaultValue);
        }
        #endregion
        #region ReadRawData
#if LANG_JP
        /// <summary>
        /// 複数の数値を読み込む
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="src">数値を読み込むファイルノード(シーケンス)</param>
        /// <param name="dst">書き込み先の配列へのポインタ．</param>
        /// <param name="dt">配列の個々の要素の仕様．</param>
#else
        /// <summary>
        /// Reads multiple numbers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fs">File storage. </param>
        /// <param name="src">The file node (a sequence) to read numbers from. </param>
        /// <param name="dst">Reference to the destination array. </param>
        /// <param name="dt">Specification of each array element. It has the same format as in cvWriteRawData. </param>
#endif
        public static void ReadRawData<T>(CvFileStorage fs, CvFileNode src, ref T[] dst, string dt)
            where T : struct
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (string.IsNullOrEmpty(dt))
                throw new ArgumentNullException("dt");

            using (var dstPtr = new ArrayAddress1<T>(dst))
            {
                CvInvoke.cvReadRawData(fs.CvPtr, src.CvPtr, dstPtr.Pointer, dt);
            }
        }
        #endregion
        #region ReadRawDataSlice
#if LANG_JP
        /// <summary>
        /// 複数の数値のシーケンスを読み込む
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="reader">シーケンスリーダ</param>
        /// <param name="count">読み込む要素数</param>
        /// <param name="dst">出力配列</param>
        /// <param name="dt">各配列要素の仕様</param>
#else
        /// <summary>
        /// Initializes file node sequence reader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fs">File storage. </param>
        /// <param name="reader">The sequence reader. Initialize it with cvStartReadRawData. </param>
        /// <param name="count">The number of elements to read. </param>
        /// <param name="dst">Destination array. </param>
        /// <param name="dt">Specification of each array element. It has the same format as in cvWriteRawData. </param>
#endif
        public static void ReadRawDataSlice<T>(CvFileStorage fs, CvSeqReader reader, int count, out T[] dst, string dt)
            where T : struct
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (string.IsNullOrEmpty(dt))
                throw new ArgumentNullException("dt");
            
            dst = new T[count];
            using (var dstPtr = new ArrayAddress1<T>(dst))
            {
                CvInvoke.cvReadRawDataSlice(fs.CvPtr, reader.CvPtr, count, dstPtr, dt);
            }
        }
        #endregion
        #region ReadReal
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された浮動小数点型の値を返す．
        /// </summary>
        /// <param name="node">ファイルノード</param>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Retrieves floating-point value from file node
        /// </summary>
        /// <param name="node">File node. </param>
        /// <returns>returns floating-point value that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public static double ReadReal(CvFileNode node)
        {
            return ReadReal(node, 0);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された浮動小数点型の値を返す．
        /// </summary>
        /// <param name="node">ファイルノード</param>
        /// <param name="defaultValue">nodeがnullの場合の戻り値</param>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Retrieves floating-point value from file node
        /// </summary>
        /// <param name="node">File node. </param>
        /// <param name="defaultValue">The value that is returned if node is null. </param>
        /// <returns>returns floating-point value that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public static double ReadReal(CvFileNode node, double defaultValue)
        {
            return (node == null) ? defaultValue 
                : NODE_IS_INT(node.Tag) ? (double)node.DataI 
                : NODE_IS_REAL(node.Tag) ? node.DataF 
                : 1e300;
        }
        #endregion
        #region ReadRealByName
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadRealの単純な合成である．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public static double ReadRealByName(CvFileStorage fs, CvFileNode map, string name)
        {
            return ReadRealByName(fs, map, name, 0);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadRealの単純な合成である．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <param name="defaultValue">ファイルノードが見つからない場合の戻り値</param>
        /// <returns>ファイルノードで表現された浮動小数点型の値</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <param name="defaultValue">The value that is returned if the file node is not found. </param>
        /// <returns></returns>
#endif
        public static double ReadRealByName(CvFileStorage fs, CvFileNode map, string name, double defaultValue)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            
            return ReadReal(GetFileNodeByName(fs, map, name), defaultValue);
        }
        #endregion
        #region ReadString
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された文字列を返す．
        /// </summary>
        /// <param name="node">ファイルノード</param>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Retrieves text string from file node
        /// </summary>
        /// <param name="node">File node. </param>
        /// <returns>returns text string that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public static string ReadString(CvFileNode node)
        {
            return ReadString(node, null);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードで表現された文字列を返す．
        /// </summary>
        /// <param name="node">ファイルノード</param>
        /// <param name="defaultValue">nodeがnullの場合の戻り値</param>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Retrieves text string from file node
        /// </summary>
        /// <param name="node">File node. </param>
        /// <param name="defaultValue">The value that is returned if node is null. </param>
        /// <returns>returns text string that is represented by the file node. If the file node is null, default_value is returned.</returns>
#endif
        public static string ReadString(CvFileNode node, string defaultValue)
        {
            return (node == null) ? defaultValue
                : NODE_IS_STRING(node.Tag) ? node.DataStr.ToString() 
                : null;
        }
        #endregion
        #region ReadStringByName
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadStringの単純な合成である．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <returns></returns>
#endif
        public static string ReadStringByName(CvFileStorage fs, CvFileNode map, string name)
        {
            return ReadStringByName(fs, map, name, null);
        }
#if LANG_JP
        /// <summary>
        /// ファイルノードを探索し，その値を返す.
        /// cvGetFileNodeByName とcvReadStringの単純な合成である．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探索する.</param>
        /// <param name="name">ノード名</param>
        /// <param name="defaultValue">ファイルノードが見つからない場合の戻り値</param>
        /// <returns>ファイルノードで表現された文字列</returns>
#else
        /// <summary>
        /// Finds file node and returns its value
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. </param>
        /// <param name="name">The node name. </param>
        /// <param name="defaultValue">The value that is returned if the file node is not found. </param>
        /// <returns></returns>
#endif
        public static string ReadStringByName(CvFileStorage fs, CvFileNode map, string name, string defaultValue)
        {
            if (fs == null)
            {
                throw new ArgumentNullException("fs");
            }
            return ReadString(GetFileNodeByName(fs, map, name), defaultValue);
        }
        #endregion
        #region RealScalar
#if LANG_JP
        /// <summary>
        /// 指定した値を先頭要素とし、残りを0で初期化し、返す
        /// </summary>
        /// <param name="val0"></param>
#else
        /// <summary>
        /// Initializes val[0] with val0, val[1]...val[3] with zeros
        /// </summary>
        /// <param name="val0"></param>
        /// <returns></returns>
#endif
        public static CvScalar RealScalar(double val0)
        {
            return new CvScalar(val0, 0, 0, 0);
        }
        #endregion
        #region Rectangle
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public static void Rectangle(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public static void Rectangle(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public static void Rectangle(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void Rectangle(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public static void Rectangle(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Rectangle(img, pt1, pt2, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public static void Rectangle(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Rectangle(img, pt1, pt2, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public static void Rectangle(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Rectangle(img, pt1, pt2, color, thickness, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void Rectangle(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            if (img == null)
            {
                throw new ArgumentNullException("img");
            }
            CvInvoke.cvRectangle(img.CvPtr, pt1, pt2, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public static void Rectangle(CvArr img, CvRect rect, CvScalar color)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public static void Rectangle(CvArr img, CvRect rect, CvScalar color, int thickness)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public static void Rectangle(CvArr img, CvRect rect, CvScalar color, int thickness, LineType lineType)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void Rectangle(CvArr img, CvRect rect, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public static void DrawRect(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public static void DrawRect(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public static void DrawRect(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">矩形の一つの頂点のx座標</param>
        /// <param name="pt1Y">矩形の一つの頂点のy座標</param>
        /// <param name="pt2X">矩形の反対側の頂点のx座標</param>
        /// <param name="pt2Y">矩形の反対側の頂点のy座標</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1X">X-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt1Y">Y-coordinate of the one of the rectangle vertices. </param>
        /// <param name="pt2X">X-coordinate of the opposite rectangle vertex. </param>
        /// <param name="pt2Y">Y-coordinate of the opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void DrawRect(CvArr img, int pt1X, int pt1Y, int pt2X, int pt2Y, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Rectangle(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public static void DrawRect(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color)
        {
            Rectangle(img, pt1, pt2, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public static void DrawRect(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness)
        {
            Rectangle(img, pt1, pt2, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる.</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public static void DrawRect(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType)
        {
            Rectangle(img, pt1, pt2, color, thickness, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void DrawRect(CvArr img, CvPoint pt1, CvPoint pt2, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Rectangle(img, pt1, pt2, color, thickness, lineType, shift);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
#endif
        public static void DrawRect(CvArr img, CvRect rect, CvScalar color)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
#endif
        public static void DrawRect(CvArr img, CvRect rect, CvScalar color, int thickness)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color, thickness);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
#endif
        public static void DrawRect(CvArr img, CvRect rect, CvScalar color, int thickness, LineType lineType)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color, thickness, lineType);
        }
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値，例えばCV_FILLEDを指定した場合は塗りつぶされる．</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values, e.g. CV_FILLED, make the function to draw a filled rectangle. </param>
        /// <param name="lineType">Type of the line, see cvLine description. </param>
        /// <param name="shift">Number of fractional bits in the point coordinates. </param>
#endif
        public static void DrawRect(CvArr img, CvRect rect, CvScalar color, int thickness, LineType lineType, int shift)
        {
            Rectangle(img, new CvPoint(rect.X, rect.Y), new CvPoint(rect.X + rect.Width, rect.Y + rect.Height), color, thickness, lineType, shift);
        }
        #endregion
        #region RedirectError
#if LANG_JP
        /// <summary>
        /// 新しいエラーハンドラをセットする
        /// </summary>
        /// <param name="error_handler">新しいエラーハンドラ</param>
        /// <returns>現在のエラーハンドラ</returns>
#else
        /// <summary>
        /// Sets a new error handler
        /// </summary>
        /// <param name="error_handler">The new error_handler</param>
        /// <returns>Current error handler</returns>
#endif
        public static CvErrorCallback RedirectError(CvErrorCallback error_handler)
        {
            IntPtr zero = IntPtr.Zero;
            return RedirectError(error_handler, zero, ref zero);
        }
#if LANG_JP
        /// <summary>
        /// 新しいエラーハンドラをセットする
        /// </summary>
        /// <param name="error_handler">新しいエラーハンドラ</param>
        /// <param name="userdata">エラーハンドラへの引数として渡される任意のポインタ</param>
        /// <param name="prev_userdata">あらかじめ割り当てられているユーザデータへのポインタのポインタ</param>
        /// <returns>現在のエラーハンドラ</returns>
#else
        /// <summary>
        /// Sets a new error handler
        /// </summary>
        /// <param name="error_handler">The new error_handler</param>
        /// <param name="userdata">Arbitrary pointer that is transparently passed to the error handler</param>
        /// <param name="prev_userdata">Pointer to the previously assigned user data pointer</param>
        /// <returns>Current error handler</returns>
#endif
        public static CvErrorCallback RedirectError(CvErrorCallback error_handler, IntPtr userdata, ref IntPtr prev_userdata)
        {
            IntPtr handler = CvInvoke.cvRedirectError(error_handler, userdata, ref prev_userdata);
            if (handler == IntPtr.Zero)
                return null;
            else
                return (CvErrorCallback)Marshal.GetDelegateForFunctionPointer(handler, typeof(CvErrorCallback));
        }
#if LANG_JP
        /// <summary>
        /// 新しいエラーハンドラをセットする
        /// </summary>
        /// <param name="error_handler">新しいエラーハンドラ</param>
        /// <returns>現在のエラーハンドラ</returns>
#else
        /// <summary>
        /// Sets a new error handler
        /// </summary>
        /// <param name="error_handler">The new error_handler</param>
        /// <returns>Current error handler</returns>
#endif
        public static IntPtr RedirectError(IntPtr error_handler)
        {
            IntPtr zero = IntPtr.Zero;
            return CvInvoke.cvRedirectError(error_handler, zero, ref zero);
        }
#if LANG_JP
        /// <summary>
        /// 新しいエラーハンドラをセットする
        /// </summary>
        /// <param name="error_handler">新しいエラーハンドラ</param>
        /// <param name="userdata">エラーハンドラへの引数として渡される任意のポインタ</param>
        /// <param name="prev_userdata">あらかじめ割り当てられているユーザデータへのポインタのポインタ</param>
        /// <returns>現在のエラーハンドラ</returns>
#else
        /// <summary>
        /// Sets a new error handler
        /// </summary>
        /// <param name="error_handler">The new error_handler</param>
        /// <param name="userdata">Arbitrary pointer that is transparently passed to the error handler</param>
        /// <param name="prev_userdata">Pointer to the previously assigned user data pointer</param>
        /// <returns>Current error handler</returns>
#endif
        public static IntPtr RedirectError(IntPtr error_handler, IntPtr userdata, ref IntPtr prev_userdata)
        {
            return CvInvoke.cvRedirectError(error_handler, userdata, ref prev_userdata);
        }
        #endregion
        #region Reduce
#if LANG_JP
        /// <summary>
        /// 行列をベクトルへ縮小する
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">行（または1列）の出力ベクトル（すべての行/列から指定された方法で計算される）</param>
#else
        /// <summary>
        /// Reduces matrix to a vector
        /// </summary>
        /// <param name="src">The input matrix. </param>
        /// <param name="dst">The output single-row/single-column vector that accumulates somehow all the matrix rows/columns. </param>
#endif
        public static void Reduce(CvArr src, CvArr dst)
        {
            Reduce(src, dst, ReduceDimension.Auto, ReduceOperation.Sum);
        }
#if LANG_JP
        /// <summary>
        /// 行列をベクトルへ縮小する
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">行（または1列）の出力ベクトル（すべての行/列から指定された方法で計算される）</param>
        /// <param name="dim">配列をどのように縮小するかを示すインデックス</param>
#else
        /// <summary>
        /// Reduces matrix to a vector
        /// </summary>
        /// <param name="src">The input matrix. </param>
        /// <param name="dst">The output single-row/single-column vector that accumulates somehow all the matrix rows/columns. </param>
        /// <param name="dim">The dimension index along which the matrix is reduce. 0 means that the matrix is reduced to a single row, 1 means that the matrix is reduced to a single column. -1 means that the dimension is chosen automatically by analysing the dst size. </param>
#endif
        public static void Reduce(CvArr src, CvArr dst, ReduceDimension dim)
        {
            Reduce(src, dst, dim, ReduceOperation.Sum);
        }
#if LANG_JP
        /// <summary>
        /// 行列をベクトルへ縮小する
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">行（または1列）の出力ベクトル（すべての行/列から指定された方法で計算される）</param>
        /// <param name="dim">配列をどのように縮小するかを示すインデックス</param>
        /// <param name="type">縮小処理の種類</param>
#else
        /// <summary>
        /// Reduces matrix to a vector
        /// </summary>
        /// <param name="src">The input matrix. </param>
        /// <param name="dst">The output single-row/single-column vector that accumulates somehow all the matrix rows/columns. </param>
        /// <param name="dim">The dimension index along which the matrix is reduce. 0 means that the matrix is reduced to a single row, 1 means that the matrix is reduced to a single column. -1 means that the dimension is chosen automatically by analysing the dst size. </param>
        /// <param name="type">The reduction operation.</param>
#endif
        public static void Reduce(CvArr src, CvArr dst, ReduceDimension dim, ReduceOperation type)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvReduce(src.CvPtr, dst.CvPtr, dim, type);
        }
        #endregion
        #region RegisterType
#if LANG_JP
        /// <summary>
        /// 新しい型を登録する
        /// </summary>
        /// <param name="info">型情報構造体</param>
#else
        /// <summary>
        /// Registers new type
        /// </summary>
        /// <param name="info">Type info structure. </param>
#endif
        public static void RegisterType(CvTypeInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            CvInvoke.cvRegisterType(info.CvPtr);
        }
        #endregion
        #region Release
#if LANG_JP
        /// <summary>
        /// オブジェクトを解放する
        /// </summary>
        /// <param name="struct_ptr">オブジェクトのポインタのポインタ．</param>
#else
        /// <summary>
        /// Releases the object
        /// </summary>
        /// <param name="struct_ptr">Double pointer to the object. </param>
#endif
        public static void Release(ref IntPtr struct_ptr)
        {
            CvInvoke.cvRelease(ref struct_ptr);
        }
#if LANG_JP
        /// <summary>
        /// オブジェクトを解放する
        /// </summary>
        /// <param name="struct_ptr">オブジェクトのポインタのポインタ．</param>
#else
        /// <summary>
        /// Releases the object
        /// </summary>
        /// <param name="struct_ptr">Double pointer to the object. </param>
#endif
        public static void Release(ref ICvPtrHolder struct_ptr)
        {
            if (struct_ptr != null)
            {
                IntPtr ptr = struct_ptr.CvPtr;
                CvInvoke.cvRelease(ref ptr);
                struct_ptr = null;
            }
        }
        #endregion
        #region ReleaseBGCodeBookModel
#if LANG_JP
        /// <summary>
        /// BGCodeBookModel 構造体を解放する
        /// </summary>
        /// <param name="model">解放する構造体への参照</param>
#else
        /// <summary>
        /// Deallocates BGCodeBookModel structure
        /// </summary>
        /// <param name="model">Structure to be released. </param>
#endif
        public static void ReleaseBGCodeBookModel(CvBGCodeBookModel model)
        {
            if (model != null)
            {
                model.Dispose();
            }
        }
        #endregion
        #region ReleaseCapture
#if LANG_JP
        /// <summary>
        /// CvCapture 構造体を解放する
        /// </summary>
        /// <param name="capture">キャプチャ構造体への参照</param>
#else
        /// <summary>
        /// Releases the CvCapture structure allocated by cvCreateFileCapture or cvCreateCameraCapture. 
        /// </summary>
        /// <param name="capture">Reference to video capturing structure. </param>
#endif
        public static void ReleaseCapture(CvCapture capture)
        {
            if (capture != null)
            {
                capture.Dispose();
            }
        }
        #endregion
        #region ReleaseConDensation
#if LANG_JP
        /// <summary>
        /// ConDensation フィルタ構造体を解放する
        /// </summary>
        /// <param name="condens">解放する構造体への参照</param>
#else
        /// <summary>
        /// Deallocates ConDensation filter structure
        /// </summary>
        /// <param name="condens">Structure to be released. </param>
#endif
        public static void ReleaseConDensation(CvConDensation condens )
        {
            if (condens != null)
            {
                condens.Dispose();
            }
        }
        #endregion
        #region ReleaseData
#if LANG_JP
        /// <summary>
        /// 配列データを解放する． 
        /// </summary>
        /// <param name="arr">配列ヘッダ</param>
#else
        /// <summary>
        /// Releases array data.
        /// </summary>
        /// <param name="arr">Array header.</param>
#endif
        public static void ReleaseData(CvArr arr)
        {
            if (arr != null)
            {
                CvInvoke.cvReleaseData(arr.CvPtr);
            }
        }
        #endregion
        #region ReleaseFaceTracker
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ppFaceTracker"></param>
        public static void ReleaseFaceTracker(CvFaceTracker ppFaceTracker)
        {
            if (ppFaceTracker != null)
            {
                ppFaceTracker.Dispose();
            }
        }
        #endregion
        #region ReleaseFeatureTree
#if LANG_JP
        /// <summary>
        /// 特徴ベクトルのツリーを解放する
        /// </summary>
        /// <param name="tr">解放されるツリーへのポインタ．</param>
#else
        /// <summary>
        /// Destroys a tree of feature vectors
        /// </summary>
        /// <param name="tr">pointer to tree being destroyed. </param>
#endif
        public static void ReleaseFeatureTree(CvFeatureTree tr)
        {
            if (tr != null)
            {
                tr.Dispose();
            }
        }
        #endregion
        #region ReleaseFileStorage
#if LANG_JP
        /// <summary>
        /// ファイルを閉じて，一時的な構造体をすべて解放する．
        /// この関数は，すべての入出力操作が終了した後に実行されなければならない． 
        /// </summary>
        /// <param name="fs">解放するファイルへの参照</param>
#else
        /// <summary>
        /// Releases file storage
        /// </summary>
        /// <param name="fs">Reference to the released file storage. </param>
#endif
        public static void ReleaseFileStorage(CvFileStorage fs)
        {
            if (fs != null)
            {
                fs.Dispose();
            }
        }
        #endregion
        #region ReleaseGraphScanner
#if LANG_JP
        /// <summary>
        /// グラフの走査処理を終了する
        /// </summary>
        /// <param name="scanner">スキャナへの参照</param>
#else
        /// <summary>
        /// Finishes graph traversal procedure
        /// </summary>
        /// <param name="scanner">Reference to graph traverser. </param>
#endif
        public static void ReleaseGraphScanner(CvGraphScanner scanner)
        {
            if (scanner != null)
            {
                scanner.Dispose();
            }
        }
        #endregion
        #region ReleaseHaarClassifierCascade
#if LANG_JP
        /// <summary>
        /// Haar分類器カスケードを解放する 
        /// </summary>
        /// <param name="cascade">解放するカスケード分類器への参照</param>
#else
        /// <summary>
        /// Releases haar classifier cascade
        /// </summary>
        /// <param name="cascade">Double pointer to the released cascade. </param>
#endif
        public static void ReleaseHaarClassifierCascade(CvHaarClassifierCascade cascade)
        {
            if (cascade != null)
            {
                cascade.Dispose();
            }
        }
        #endregion
        #region ReleaseHist
#if LANG_JP
        /// <summary>
        /// ヒストグラム（ヘッダ・データ）を解放する． 
        /// ヒストグラムへのポインタは，この関数でクリアされる． 
        /// </summary>
        /// <param name="hist">解放するヒストグラムへの参照</param>
#else
        /// <summary>
        /// Releases the histogram (header and the data).
        /// </summary>
        /// <param name="hist">Double pointer to the released histogram. </param>
#endif
        public static void ReleaseHist(CvHistogram hist)
        {
            if (hist != null)
            {
                hist.Dispose();
            }
        }
        #endregion
        #region ReleaseImage
#if LANG_JP
        /// <summary>
        /// ヘッダと画像データを解放する
        /// </summary>
        /// <param name="image">確保した画像ヘッダへの参照</param>
#else
        /// <summary>
        /// Releases header and image data
        /// </summary>
        /// <param name="image">Reference to the header of the deallocated image. </param>
#endif
        public static void ReleaseImage(IplImage image)
        {
            if (image != null)
            {
                image.Dispose();
            }
        }
        #endregion
        #region ReleaseImageHeader
#if LANG_JP
        /// <summary>
        /// 画像のヘッダを解放する
        /// </summary>
        /// <param name="image">確保したヘッダへの参照</param>
#else
        /// <summary>
        /// Releases IplImage header
        /// </summary>
        /// <param name="image">Reference to the deallocated header. </param>
#endif
        public static void ReleaseImageHeader(IplImage image)
        {
            if (image != null)
            {
                IntPtr ptr = image.CvPtr;
                CvInvoke.cvReleaseImageHeader(ref ptr);
            }
        }
        #endregion
        #region ReleaseKalman
#if LANG_JP
        /// <summary>
        /// カルマンフィルタ構造体を解放する
        /// </summary>
        /// <param name="kalman">カルマンフィルタクラス</param>
#else
        /// <summary>
        /// Deallocates Kalman filter structure
        /// </summary>
        /// <param name="kalman">Kalman filter structure. </param>
#endif
        public static void ReleaseKalman(CvKalman kalman)
        {
            if (kalman != null)
            {
                kalman.Dispose();
            }
        }
        #endregion
        #region ReleaseLatentSvmDetector
#if LANG_JP
        /// <summary>
        /// release memory allocated for CvLatentSvmDetector structure
        /// </summary>
        /// <param name="detector"></param>
#else
        /// <summary>
        /// release memory allocated for CvLatentSvmDetector structure
        /// </summary>
        /// <param name="detector"></param>
#endif
        public static void ReleaseLatentSvmDetector(CvLatentSvmDetector detector)
        {
            if (detector != null)
            {
                detector.Dispose();
            }
        }
        #endregion
        #region ReleaseLSH
#if LANG_JP
        /// <summary>
        /// Free the given LSH structure.
        /// </summary>
        /// <param name="lsh"></param>
#else
        /// <summary>
        /// Free the given LSH structure.
        /// </summary>
        /// <param name="lsh"></param>
#endif
        public static void ReleaseLSH(CvLSH lsh)
        {
            if (lsh != null)
            {
                lsh.Dispose();
            }
        }
        #endregion
        #region ReleaseMat
#if LANG_JP
        /// <summary>
        /// 行列を解放する
        /// </summary>
        /// <param name="mat">行列への参照</param>
#else
        /// <summary>
        /// Deallocates matrix.
        /// </summary>
        /// <param name="mat">Reference to the matrix.</param>
#endif
        public static void ReleaseMat(CvMat mat)
        {
            if (mat != null)
            {
                mat.Dispose();
            }
        }
        #endregion
        #region ReleaseMatND
#if LANG_JP
        /// <summary>
        /// CvMatNDを解放する
        /// </summary>
        /// <param name="mat">行列への参照</param>
#else
        /// <summary>
        /// Deallocates multi-dimensional array
        /// </summary>
        /// <param name="mat">Reference to the array. </param>
#endif
        public static void ReleaseMatND(CvMatND mat)
        {
            if (mat != null)
            {
                mat.Dispose();
            }
        }
        #endregion
        #region ReleaseMemStorage
#if LANG_JP
        /// <summary>
        /// メモリストレージを解放する
        /// </summary>
        /// <param name="storage">解放するストレージの参照</param>
#else
        /// <summary>
        /// Releases memory storage
        /// </summary>
        /// <param name="storage">Pointer to the released storage. </param>
#endif
        public static void ReleaseMemStorage(CvMemStorage storage)
        {
            if (storage != null)
            {
                storage.Dispose();
            }
        }
        #endregion
        #region ReleasePOSITObject
#if LANG_JP
        /// <summary>
        /// 3次元オブジェクト構造体のメモリを解放する
        /// </summary>
        /// <param name="positObject">構造体 CvPOSIT への参照</param>
#else
        /// <summary>
        /// Deallocates 3D object structure
        /// </summary>
        /// <param name="positObject">Reference to CvPOSIT structure.</param>
#endif
        public static void ReleasePOSITObject(CvPOSITObject positObject)
        {
            if (positObject != null)
            {
                positObject.Dispose();
            }
        }
        #endregion
        #region ReleasePyramid
#if LANG_JP
        /// <summary>
        /// Releases pyramid
        /// </summary>
        /// <param name="pyramid"></param>
        /// <param name="extra_layers"></param>
#else
        /// <summary>
        /// Releases pyramid
        /// </summary>
        /// <param name="pyramid"></param>
        /// <param name="extra_layers"></param>
#endif
        public static void ReleasePyramid(CvMat[] pyramid, int extra_layers)
        {
            if (pyramid != null && pyramid[0] != null)
            {
                IntPtr ptr = pyramid[0].CvPtr;
                CvInvoke.cvReleasePyramid(ref ptr, extra_layers);
            }
        }
        #endregion
        #region ReleaseSparseMat
#if LANG_JP
        /// <summary>
        /// 疎な配列を解放する
        /// </summary>
        /// <param name="mat">配列への参照</param>
#else
        /// <summary>
        /// Deallocates sparse array
        /// </summary>
        /// <param name="mat">Reference to the array. </param>
#endif
        public static void ReleaseMatND(CvSparseMat mat)
        {
            if (mat != null)
            {
                mat.Dispose();
            }
        }
        #endregion
        #region ReleaseStereoBMState
#if LANG_JP
        /// <summary>
        /// ステレオブロックマッチング構造体を解放する
        /// </summary>
        /// <param name="state">解放される構造体への参照</param>
#else
        /// <summary>
        /// Releases block matching stereo correspondence structure
        /// </summary>
        /// <param name="state">Reference to the released structure</param>
#endif
        public static void ReleaseStereoBMState(CvStereoBMState state)
        {
            if (state != null)
            {
                state.Dispose();
            }
        }
        #endregion
        #region ReleaseStereoGCState
#if LANG_JP
        /// <summary>
        /// グラフカットアルゴリズムに基づくステレオマッチング構造体を解放する
        /// </summary>
        /// <param name="state">解放される構造体への参照</param>
#else
        /// <summary>
        /// Releases the state structure of the graph cut-based stereo correspondence algorithm
        /// </summary>
        /// <param name="state">Reference to the released structure</param>
#endif
        public static void ReleaseStereoGCState(CvStereoGCState state)
        {
            if (state != null)
            {
                state.Dispose();
            }
        }
        #endregion
        #region ReleaseStructuringElement
#if LANG_JP
        /// <summary>
        /// cvDilate, cvErodeで用いる構造要素を解放する
        /// </summary>
        /// <param name="element">構造要素</param>
#else
        /// <summary>
        /// Releases the structure IplConvKernel that is no longer needed. 
        /// If *element is NULL, the function has no effect.
        /// </summary>
        /// <param name="element">Pointer to the deleted structuring element. </param>
#endif
        public static void ReleaseStructuringElement(IplConvKernel element)
        {
            if (element != null)
            {
                element.Dispose();
            }
        }
        #endregion
        #region ReleaseVideoWriter
#if LANG_JP
        /// <summary>
        /// ビデオファイルライタを解放する
        /// </summary>
        /// <param name="writer">ビデオライタ構造体への参照</param>
#else
        /// <summary>
        /// Finishes writing to video file and releases the structure. 
        /// </summary>
        /// <param name="writer">Reference to video file writer structure. </param>
#endif
        public static void ReleaseVideoWriter(CvVideoWriter writer)
        {
            if (writer != null)
            {
                writer.Dispose();
            }
        }
        #endregion
        #region Remap
#if LANG_JP
        /// <summary>
        /// 画像に対して幾何変換を行う. 指定されたマップを用いて入力画像を以下のように変換する．
        /// dst(x,y)&lt;-src(mapx(x,y),mapy(x,y)) .
        /// 他の幾何変換と同様，非整数座標値を持つピクセルを抽出するために，ユーザによって指定された補間方法が用いられる．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapx">x座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="mapy">y座標マップ (32FC1 フォーマットの画像)</param>
#else
        /// <summary>
        /// Applies generic geometrical transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapx">The map of x-coordinates (32fC1 image). </param>
        /// <param name="mapy">The map of y-coordinates (32fC1 image). </param>
#endif
        public static void Remap(CvArr src, CvArr dst, CvArr mapx, CvArr mapy)
        {
            Remap(src, dst, mapx, mapy, Interpolation.Linear | Interpolation.FillOutliers, CvScalar.ScalarAll(0));
        }
#if LANG_JP
        /// <summary>
        /// 画像に対して幾何変換を行う. 指定されたマップを用いて入力画像を以下のように変換する．
        /// dst(x,y)&lt;-src(mapx(x,y),mapy(x,y)) .
        /// 他の幾何変換と同様，非整数座標値を持つピクセルを抽出するために，ユーザによって指定された補間方法が用いられる．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapx">x座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="mapy">y座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="flags">補間方法</param>
#else
        /// <summary>
        /// Applies generic geometrical transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapx">The map of x-coordinates (32fC1 image). </param>
        /// <param name="mapy">The map of y-coordinates (32fC1 image). </param>
        /// <param name="flags">A combination of interpolation method and the optional flag(s).</param>
#endif
        public static void Remap(CvArr src, CvArr dst, CvArr mapx, CvArr mapy, Interpolation flags)
        {
            Remap(src, dst, mapx, mapy, flags, CvScalar.ScalarAll(0));
        }
#if LANG_JP
        /// <summary>
        /// 画像に対して幾何変換を行う. 指定されたマップを用いて入力画像を以下のように変換する．
        /// dst(x,y)&lt;-src(mapx(x,y),mapy(x,y)) .
        /// 他の幾何変換と同様，非整数座標値を持つピクセルを抽出するために，ユーザによって指定された補間方法が用いられる．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="mapx">x座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="mapy">y座標マップ (32FC1 フォーマットの画像)</param>
        /// <param name="flags">補間方法</param>
        /// <param name="fillval">対応の取れない点に対して与える値</param>
#else
        /// <summary>
        /// Applies generic geometrical transformation to the image.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="mapx">The map of x-coordinates (32fC1 image). </param>
        /// <param name="mapy">The map of y-coordinates (32fC1 image). </param>
        /// <param name="flags">A combination of interpolation method and the optional flag(s).</param>
        /// <param name="fillval">A value used to fill outliers. </param>
#endif
        public static void Remap(CvArr src, CvArr dst, CvArr mapx, CvArr mapy, Interpolation flags, CvScalar fillval)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (mapx == null)
                throw new ArgumentNullException("mapx");
            if (mapy == null)
                throw new ArgumentNullException("mapy");
            CvInvoke.cvRemap(src.CvPtr, dst.CvPtr, mapx.CvPtr, mapy.CvPtr, flags, fillval);
        }
        #endregion
        #region RemoveNodeFromTree
#if LANG_JP
        /// <summary>
        /// ツリーからノードを削除する
        /// </summary>
        /// <param name="node">削除されるノード．</param>
        /// <param name="frame">トップレベルノード．node->v_prev = null かつ node->h_prev = null （つまり，node が frameの最初の子ノードである）である場合， 
        /// frame->v_next は node->h_next にセットされる (つまり，最初の子ノードかframeが変更される）．</param>
#else
        /// <summary>
        /// Removes node from tree
        /// </summary>
        /// <param name="node">The removed node. </param>
        /// <param name="frame">The top level node. If node->v_prev = null and node->h_prev is null (i.e. if node is the first child of frame), 
        /// frame->v_next is set to node->h_next (i.e. the first child or frame is changed). </param>
#endif
        public static void RemoveNodeFromTree<T>(CvTreeNode<T> node, CvTreeNode<T> frame)
            where T : CvTreeNode<T>
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (frame == null)
                throw new ArgumentNullException("frame");
            CvInvoke.cvRemoveNodeFromTree(node.CvPtr, frame.CvPtr);
        }
        #endregion
        #region Repeat
#if LANG_JP
        /// <summary>
        /// 出力配列を入力配列でタイル状に埋める
        /// </summary>
        /// <param name="src">入力配列，画像または行列．</param>
        /// <param name="dst">出力配列，画像または行列．</param>
#else
        /// <summary>
        /// Fill destination array with tiled source array
        /// </summary>
        /// <param name="src">Source array, image or matrix. </param>
        /// <param name="dst">Destination array, image or matrix. </param>
#endif
        public static void Repeat(CvArr src, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvRepeat(src.CvPtr, dst.CvPtr);
        }
        #endregion
        #region ReprojectImageTo3D
#if LANG_JP
        /// <summary>
        /// 視差画像を三次元空間に再投影する
        /// </summary>
        /// <param name="disparityImage">視差画像</param>
        /// <param name="_3dImage">3 チャンネル，16ビット あるいは 32ビットの浮動小数点型画像． 出力は，三次元点の集合になる．</param>
        /// <param name="Q">4×4 の再投影行列</param>
#else
        /// <summary>
        /// Reprojects disparity image to 3D space
        /// </summary>
        /// <param name="disparityImage">Disparity map. </param>
        /// <param name="_3dImage">3-channel, 16-bit integer or 32-bit floating-point image - the output map of 3D points. </param>
        /// <param name="Q">The reprojection 4x4 matrix. </param>
#endif
        public static void ReprojectImageTo3D(CvArr disparityImage, CvArr _3dImage, CvMat Q)
        {
            if (disparityImage == null)
                throw new ArgumentNullException("disparityImage");
            if (_3dImage == null)
                throw new ArgumentNullException("_3dImage");
            if (Q == null)
                throw new ArgumentNullException("Q");
            CvInvoke.cvReprojectImageTo3D(disparityImage.CvPtr, _3dImage.CvPtr, Q.CvPtr);
        }
        #endregion
        #region ResetImageROI
#if LANG_JP
        /// <summary>
        /// 画像の ROI を解放する．解放後は全画像が選択されている状態と同じになる．
        /// </summary>
        /// <param name="image">画像ヘッダ</param>
#else
        /// <summary>
        /// Releases image ROI. After that the whole image is considered selected. 
        /// </summary>
        /// <param name="image">Image header. </param>
#endif
        public static void ResetImageROI(IplImage image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            CvInvoke.cvResetImageROI(image.CvPtr);
        }
        #endregion
        #region Reshape
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="new_cn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="new_cn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <returns></returns>
#endif
        public static CvMat Reshape(CvArr arr, out CvMat header, int new_cn)
        {
            return Reshape(arr, out header, new_cn, 0);
        }
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="new_cn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="new_rows">新しい行数． new_rows = 0は，行数がnew_cnの値に応じて変更する必要があるのにも関わらず，変更されないままであることを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="new_cn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="new_rows">New number of rows. new_rows = 0 means that number of rows remains unchanged unless it needs to be changed according to new_cn value. destination array to be changed. </param>
        /// <returns></returns>
#endif
        public static CvMat Reshape(CvArr arr, out CvMat header, int new_cn, int new_rows)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            header = new CvMat(false);
            return Reshape(arr, header, new_cn, new_rows);
        }
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="new_cn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="new_cn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <returns></returns>
#endif
        public static CvMat Reshape(CvArr arr, CvMat header, int new_cn)
        {
            return Reshape(arr, header, new_cn, 0);
        }
#if LANG_JP
        /// <summary>
        /// オリジナルの配列と同じデータだが，異なる形状（異なるチャンネル数，異なる行数，またその両方）を持つCvMatのヘッダを初期化する．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="new_cn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="new_rows">新しい行数． new_rows = 0は，行数がnew_cnの値に応じて変更する必要があるのにも関わらず，変更されないままであることを意味する．</param>
        /// <returns>行列データ</returns>
#else
        /// <summary>
        /// Changes shape of matrix/image without copying data
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="new_cn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="new_rows">New number of rows. new_rows = 0 means that number of rows remains unchanged unless it needs to be changed according to new_cn value. destination array to be changed. </param>
        /// <returns></returns>
#endif
        public static CvMat Reshape(CvArr arr, CvMat header, int new_cn, int new_rows)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if(header == null)
                throw new ArgumentNullException("header");

            IntPtr result = CvInvoke.cvReshape(arr.CvPtr, header.CvPtr, new_cn, new_rows);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvMat(result, false);
        }
        #endregion
        #region ReshapeMatND
#if LANG_JP
        /// <summary>
        /// cvReshape の拡張バージョン．
        /// これは多次元配列を扱うことが可能（普通の画像と行列に対しても使用することが可能）で，さらに次元の変更も可能である．
        /// </summary>
        /// <typeparam name="T">出力ヘッダの型</typeparam>
        /// <param name="arr">入力配列</param>
        /// <param name="sizeof_header">IplImageとCvMat，CvMatNDそれぞれの出力ヘッダを区別するための出力ヘッダのサイズ．</param>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="new_cn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="new_dims">新しい次元数． new_dims = 0は，次元数が同じままであることを意味する．</param>
        /// <param name="new_sizes">新しい次元サイズの配列．要素の総数は変化してはいけないので，new_dims-1の値のみ使用される．従って，new_dims = 1であればnew_sizesは使用されない．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Changes shape of multi-dimensional array w/o copying data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">Input array. </param>
        /// <param name="sizeof_header">Size of output header to distinguish between IplImage, CvMat and CvMatND output headers. </param>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="new_cn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="new_dims">New number of dimensions. new_dims = 0 means that number of dimensions remains the same. </param>
        /// <param name="new_sizes">Array of new dimension sizes. Only new_dims-1 values are used, because the total number of elements must remain the same. Thus, if new_dims = 1, new_sizes array is not used </param>
        /// <returns></returns>
#endif
        public static T ReshapeMatND<T>(CvArr arr, int sizeof_header, T header, int new_cn, int new_dims, int[] new_sizes) where T : CvArr
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (header == null)
                throw new ArgumentNullException("header");
            if (new_sizes == null)
                throw new ArgumentNullException("new_sizes");

            IntPtr result = CvInvoke.cvReshapeMatND(arr.CvPtr, sizeof_header, header.CvPtr, new_cn, new_dims, new_sizes);

            Type t = typeof(T);
            if (t == typeof(IplImage))
            {
                return (T)(object)new IplImage(result, false);
            }
            else if (t == typeof(CvMat))
            {
                return (T)(object)new CvMat(result, false);
            }
            else if (t == typeof(CvMatND))
            {
                return (T)(object)new CvMatND(result, false);
            }
            else
            {
                throw new InvalidCastException();
            }
        }
#if LANG_JP
        /// <summary>
        /// cvReshape の拡張バージョン．
        /// これは多次元配列を扱うことが可能（普通の画像と行列に対しても使用することが可能）で，さらに次元の変更も可能である．
        /// </summary>
        /// <typeparam name="T">出力ヘッダの型</typeparam>
        /// <param name="arr">入力配列</param>
        /// <param name="header">書き込まれる出力ヘッダ</param>
        /// <param name="new_cn">新しいチャンネル数 ．new_cn = 0はチャンネル数が変更されていないことを意味する．</param>
        /// <param name="new_dims">新しい次元数． new_dims = 0は，次元数が同じままであることを意味する．</param>
        /// <param name="new_sizes">新しい次元サイズの配列．要素の総数は変化してはいけないので，new_dims-1の値のみ使用される．従って，new_dims = 1であればnew_sizesは使用されない．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Changes shape of multi-dimensional array w/o copying data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Output header to be filled. </param>
        /// <param name="new_cn">New number of channels. new_cn = 0 means that number of channels remains unchanged. </param>
        /// <param name="new_dims">New number of dimensions. new_dims = 0 means that number of dimensions remains the same. </param>
        /// <param name="new_sizes">Array of new dimension sizes. Only new_dims-1 values are used, because the total number of elements must remain the same. Thus, if new_dims = 1, new_sizes array is not used </param>
        /// <returns></returns>
#endif
        public static T ReshapeND<T>(CvArr arr, T header, int new_cn, int new_dims, int[] new_sizes) where T : CvArr
        {
            FieldInfo info = typeof(T).GetField("SizeOf");
            if (info != null)
            {
                int size = (int)info.GetRawConstantValue();
                return ReshapeMatND<T>(arr, size, header, new_cn, new_dims, new_sizes);
            }
            else
            {
                throw new OpenCvSharpException();
            }
        }
        #endregion
        #region Resize
#if LANG_JP
        /// <summary>
        /// 画像のサイズ変更を行う (バイリニア補間)
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Resizes image src so that it fits exactly to dst. 
        /// If ROI is set, the function consideres the ROI as supported as usual.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
#endif
        public static void Resize(CvArr src, CvArr dst)
        {
            Resize(src, dst, Interpolation.Linear);
        }
#if LANG_JP
        /// <summary>
        /// 画像のサイズ変更を行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="interpolation">補間方法</param>
#else
        /// <summary>
        /// Resizes image src so that it fits exactly to dst. 
        /// If ROI is set, the function consideres the ROI as supported as usual.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="interpolation">Interpolation method.</param>
#endif
        public static void Resize(CvArr src, CvArr dst, Interpolation interpolation)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvResize(src.CvPtr, dst.CvPtr, interpolation);
        }
        #endregion
        #region ResizeWindow
#if LANG_JP
        /// <summary>
        /// ウィンドウサイズを変更する
        /// </summary>
        /// <param name="name">サイズ変更するウィンドウの名前</param>
        /// <param name="width">新しい幅</param>
        /// <param name="height">新しい高さ</param>
#else
        /// <summary>
        /// Changes size of the window. 
        /// </summary>
        /// <param name="name">Name of the window to be resized. </param>
        /// <param name="width">New width.</param>
        /// <param name="height">New height.</param>
#endif
        public static void ResizeWindow(string name, int width, int height)
        {
            CvInvoke.cvResizeWindow(name, width, height);
        }
        #endregion
        #region RestoreMemStoragePos
#if LANG_JP
        /// <summary>
        /// メモリストレージの位置を復元する
        /// </summary>
        /// <param name="storage">メモリストレージ</param>
        /// <param name="pos">新しいストレージの先頭位置</param>
#else
        /// <summary>
        /// Restores memory storage position
        /// </summary>
        /// <param name="storage">Memory storage</param>
        /// <param name="pos">New storage top position</param>
#endif
        public static void RestoreMemStoragePos(CvMemStorage storage, CvMemStoragePos pos)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
            if (pos == null)
                throw new ArgumentNullException("pos");
            CvInvoke.cvRestoreMemStoragePos(storage.CvPtr, pos.CvPtr);
        }
        #endregion
        #region RetrieveFrame
#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Returns the pointer to the image grabbed with cvGrabFrame function. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <returns></returns>
#endif
        public static IplImage RetrieveFrame(CvCapture capture)
        {
            return RetrieveFrame(capture, 0);
        }
#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Returns the pointer to the image grabbed with cvGrabFrame function. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
#endif
        public static IplImage RetrieveFrame(CvCapture capture, int streamIdx)
        {
            if (capture == null)
            {
                throw new ArgumentNullException("capture");
            }
            IntPtr ptr = CvInvoke.cvRetrieveFrame(capture.CvPtr, streamIdx);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                return new IplImage(ptr, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// GrabFrame 関数によって取り出された画像への参照を返す．
        /// 返された画像は，ユーザが解放したり，変更したりするべきではない．
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns>1フレームの画像 (GC禁止フラグが立っている). キャプチャできなかった場合はnull.</returns>
#else
        /// <summary>
        /// Returns the pointer to the image grabbed with cvGrabFrame function. 
        /// The returned image should not be released or modified by user. 
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <param name="streamIdx">non-zero streamIdx is only valid for multi-head camera live streams</param>
        /// <returns></returns>
#endif
        public static IplImage RetrieveFrame(CvCapture capture, CameraChannels streamIdx)
        {
            return RetrieveFrame(capture, (int)streamIdx);
        }
        #endregion
        #region RNG
#if LANG_JP
        /// <summary>
        /// 乱数生成器の状態を初期化する
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes random number generator state
        /// </summary>
        /// <returns></returns>
#endif
        public static CvRNG RNG()
        {
            return new CvRNG();
        }
#if LANG_JP
        /// <summary>
        /// 乱数生成器の状態を初期化する
        /// </summary>
        /// <param name="seed">ランダムシーケンスを開始するために使用される64ビットの数値</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Initializes random number generator state
        /// </summary>
        /// <param name="seed">64-bit value used to initiate a random sequence. </param>
        /// <returns></returns>
#endif
        public static CvRNG RNG(ulong seed)
        {
            return new CvRNG(seed);
        }
        #endregion
        #region Rodrigues2
#if LANG_JP
        /// <summary>
        /// 回転ベクトルを回転行列に変換する．またはその逆も可能である．
        /// </summary>
        /// <param name="src">入力の回転ベクトル（3x1 あるいは 1x3），または回転行列（3x3）</param>
        /// <param name="dst">各入力に対応した出力の回転行列（3x3），または回転ベクトル（3x1 あるいは 1x3）</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts rotation matrix to rotation vector or vice versa
        /// </summary>
        /// <param name="src">The input rotation vector (3x1 or 1x3) or rotation matrix (3x3). </param>
        /// <param name="dst">The output rotation matrix (3x3) or rotation vector (3x1 or 1x3), respectively. </param>
        /// <returns></returns>
#endif
        public static int Rodrigues2(CvMat src, CvMat dst)
        {
            return Rodrigues2(src, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 回転ベクトルを回転行列に変換する．またはその逆も可能である．
        /// </summary>
        /// <param name="src">入力の回転ベクトル（3x1 あるいは 1x3），または回転行列（3x3）</param>
        /// <param name="dst">各入力に対応した出力の回転行列（3x3），または回転ベクトル（3x1 あるいは 1x3）</param>
        /// <param name="jacobian">オプション出力の3x9または9x3のヤコビアン - 出力配列の各要素の，入力配列の各要素に関する偏微分係数．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Converts rotation matrix to rotation vector or vice versa
        /// </summary>
        /// <param name="src">The input rotation vector (3x1 or 1x3) or rotation matrix (3x3). </param>
        /// <param name="dst">The output rotation matrix (3x3) or rotation vector (3x1 or 1x3), respectively. </param>
        /// <param name="jacobian">Optional output Jacobian matrix, 3x9 or 9x3 - partial derivatives of the output array components w.r.t the input array components. </param>
        /// <returns></returns>
#endif
        public static int Rodrigues2(CvMat src, CvMat dst, CvMat jacobian)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr jacobianPtr = (jacobian == null) ? IntPtr.Zero : jacobian.CvPtr;
            return CvInvoke.cvRodrigues2(src.CvPtr, dst.CvPtr, jacobianPtr);
        }
        #endregion
        #region Round
#if LANG_JP
        /// <summary>
        /// 引数に最も近い整数値を返す.
        /// </summary>
        /// <param name="value">浮動小数点型の入力値</param>
        /// <returns>引数に最も近い整数値</returns>
#else
        /// <summary>
        /// Returns the nearest integer value to the argument.
        /// </summary>
        /// <param name="value">The input floating-point value </param>
        /// <returns></returns>
#endif
        public static int Round(double value)
        {
            return (int)Math.Round(value);
        }
        #endregion
        #region RQDecomp3x3
#if LANG_JP
        /// <summary>
        /// 3x3行列のRQ分解を求める
        /// </summary>
        /// <param name="matrixM">入力の3x3行列 M</param>
        /// <param name="matrixR">出力の3x3の上三角行列 R</param>
        /// <param name="matrixQ">出力の3x3の直交行列</param>
#else
        /// <summary>
        /// Computes RQ decomposition for 3x3 matrices
        /// </summary>
        /// <param name="matrixM">The 3x3 input matrix M</param>
        /// <param name="matrixR">The output 3x3 upper-triangular matrix R</param>
        /// <param name="matrixQ">The output 3x3 orthogonal matrix Q</param>
#endif
        public static void RQDecomp3x3(CvMat matrixM, CvMat matrixR, CvMat matrixQ)
        {
            CvPoint3D64f eulerAngles;
            RQDecomp3x3(matrixM, matrixR, matrixQ, null, null, null, out eulerAngles);
        }
#if LANG_JP        
        /// <summary>
        /// 3x3行列のRQ分解を求める
        /// </summary>
        /// <param name="matrixM">入力の3x3行列 M</param>
        /// <param name="matrixR">出力の3x3の上三角行列 R</param>
        /// <param name="matrixQ">出力の3x3の直交行列</param>
        /// <param name="matrixQx">オプション出力の3x3のx軸を中心とする回転行列</param>
        /// <param name="matrixQy">オプション出力の3x3のy軸を中心とする回転行列</param>
        /// <param name="matrixQz">オプション出力の3x3のz軸を中心とする回転行列</param>
#else
        /// <summary>
        /// Computes RQ decomposition for 3x3 matrices
        /// </summary>
        /// <param name="matrixM">The 3x3 input matrix M</param>
        /// <param name="matrixR">The output 3x3 upper-triangular matrix R</param>
        /// <param name="matrixQ">The output 3x3 orthogonal matrix Q</param>
        /// <param name="matrixQx">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="matrixQy">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="matrixQz">Optional 3x3 rotation matrix around z-axis</param>
#endif
        public static void RQDecomp3x3(CvMat matrixM, CvMat matrixR, CvMat matrixQ,
                   CvMat matrixQx, CvMat matrixQy, CvMat matrixQz)
        {
            CvPoint3D64f eulerAngles;
            RQDecomp3x3(matrixM, matrixR, matrixQ, matrixQx, matrixQy, matrixQz, out eulerAngles);
        }
#if LANG_JP
        /// <summary>
        /// 3x3行列のRQ分解を求める
        /// </summary>
        /// <param name="matrixM">入力の3x3行列 M</param>
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
        /// <param name="matrixM">The 3x3 input matrix M</param>
        /// <param name="matrixR">The output 3x3 upper-triangular matrix R</param>
        /// <param name="matrixQ">The output 3x3 orthogonal matrix Q</param>
        /// <param name="matrixQx">Optional 3x3 rotation matrix around x-axis</param>
        /// <param name="matrixQy">Optional 3x3 rotation matrix around y-axis</param>
        /// <param name="matrixQz">Optional 3x3 rotation matrix around z-axis</param>
        /// <param name="eulerAngles">Optional 3 points containing the three Euler angles of rotation</param>
#endif
        public static void RQDecomp3x3(CvMat matrixM, CvMat matrixR, CvMat matrixQ,
                   CvMat matrixQx, CvMat matrixQy, CvMat matrixQz, out CvPoint3D64f eulerAngles)
        {
            if (matrixM == null)
                throw new ArgumentNullException("matrixM");
            if (matrixR == null)
                throw new ArgumentNullException("matrixR");
            if (matrixQ == null)
                throw new ArgumentNullException("matrixQ");

            IntPtr matrixQxPtr = (matrixQx == null) ? IntPtr.Zero : matrixQx.CvPtr;
            IntPtr matrixQyPtr = (matrixQy == null) ? IntPtr.Zero : matrixQy.CvPtr;
            IntPtr matrixQzPtr = (matrixQz == null) ? IntPtr.Zero : matrixQz.CvPtr;
            eulerAngles = new CvPoint3D64f();

            CvInvoke.cvRQDecomp3x3(matrixM.CvPtr, matrixR.CvPtr, matrixQ.CvPtr, matrixQxPtr, matrixQyPtr, matrixQzPtr, ref eulerAngles);
        }
        #endregion
        #region RunHaarClassifierCascade
#if LANG_JP
        /// <summary>
        /// ブーストされた分類器のカスケードを，与えられた画像位置で実行する
        /// </summary>
        /// <param name="cascade">Haar分類器カスケード</param>
        /// <param name="pt">解析する領域の左上の角</param>
        /// <returns>分析対象の領域が全ての分類器ステージを通過した場合（これは候補の一つになる）はtrue，そうでなければfalse．</returns>
#else
        /// <summary>
        /// Runs cascade of boosted classifier at given image location
        /// </summary>
        /// <param name="cascade">Haar classifier cascade. </param>
        /// <param name="pt">Top-left corner of the analyzed region. Size of the region is a original window size scaled by the currenly set scale. The current window size may be retrieved using  cvGetHaarClassifierCascadeWindowSize function. </param>
        /// <returns>positive value if the analyzed rectangle passed all the classifier stages (it is a candidate) and zero or negative value otherwise. </returns>
#endif
        public static bool RunHaarClassifierCascade(CvHaarClassifierCascade cascade, CvPoint pt)
        {
            return RunHaarClassifierCascade(cascade, pt, false);
        }
#if LANG_JP
        /// <summary>
        /// ブーストされた分類器のカスケードを，与えられた画像位置で実行する
        /// </summary>
        /// <param name="cascade">Haar分類器カスケード</param>
        /// <param name="pt">解析する領域の左上の角</param>
        /// <param name="start_stage">0から始まるインデックスで，カスケードステージをどこ から開始するかを決定する</param>
        /// <returns>分析対象の領域が全ての分類器ステージを通過した場合（これは候補の一つになる）はtrue，そうでなければfalse．</returns>
#else
        /// <summary>
        /// Runs cascade of boosted classifier at given image location
        /// </summary>
        /// <param name="cascade">Haar classifier cascade. </param>
        /// <param name="pt">Top-left corner of the analyzed region. Size of the region is a original window size scaled by the currenly set scale. The current window size may be retrieved using  cvGetHaarClassifierCascadeWindowSize function. </param>
        /// <param name="start_stage">Initial zero-based index of the cascade stage to start from. The function assumes that all the previous stages are passed. This feature is used internally by  cvHaarDetectObjects for better processor cache utilization. </param>
        /// <returns>positive value if the analyzed rectangle passed all the classifier stages (it is a candidate) and zero or negative value otherwise. </returns>
#endif
        public static bool RunHaarClassifierCascade(CvHaarClassifierCascade cascade, CvPoint pt, bool start_stage)
        {
            if (cascade == null)
            {
                throw new ArgumentNullException("cascade");
            }
            return CvInvoke.cvRunHaarClassifierCascade(cascade.CvPtr, pt, start_stage) > 0;
        }
        #endregion
        #region RunningAvg
#if LANG_JP
        /// <summary>
        /// 入力画像 image と アキュムレータ acc の重み付き和を計算し，その結果 acc がフレーム列の現在の平均値になる.
        /// mask(x,y)!=0の場合，acc(x,y)=(1-α)•acc(x,y) + α•image(x,y) 
        /// </summary>
        /// <param name="image">入力画像，1 または 3 チャンネル，8 ビットあるいは 32 ビッ ト浮動小数点型．（マルチチャンネル画像の各チャンネルは，個別に処理される）.</param>
        /// <param name="acc">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型．</param>
        /// <param name="alpha">入力画像の重み．</param>
#else
        /// <summary>
        /// Calculates weighted sum of input image image and the accumulator acc so that acc becomes a running average of frame sequence:
        /// acc(x,y)=(1-α)•acc(x,y) + α•image(x,y) if mask(x,y)!=null
        /// </summary>
        /// <param name="image">Input image, 1- or 3-channel, 8-bit or 32-bit floating point (each channel of multi-channel image is processed independently). </param>
        /// <param name="acc">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
        /// <param name="alpha">Weight of input image. </param>
#endif
        public static void RunningAvg(CvArr image, CvArr acc, double alpha)
        {
            RunningAvg(image, acc, alpha, null);
        }
#if LANG_JP
        /// <summary>
        /// 入力画像 image と アキュムレータ acc の重み付き和を計算し，その結果 acc がフレーム列の現在の平均値になる.
        /// mask(x,y)!=0の場合，acc(x,y)=(1-α)•acc(x,y) + α•image(x,y) 
        /// </summary>
        /// <param name="image">入力画像，1 または 3 チャンネル，8 ビットあるいは 32 ビッ ト浮動小数点型．（マルチチャンネル画像の各チャンネルは，個別に処理される）.</param>
        /// <param name="acc">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型．</param>
        /// <param name="alpha">入力画像の重み．</param>
        /// <param name="mask">オプションの処理マスク．</param>
#else
        /// <summary>
        /// Calculates weighted sum of input image image and the accumulator acc so that acc becomes a running average of frame sequence:
        /// acc(x,y)=(1-α)•acc(x,y) + α•image(x,y) if mask(x,y)!=null
        /// </summary>
        /// <param name="image">Input image, 1- or 3-channel, 8-bit or 32-bit floating point (each channel of multi-channel image is processed independently). </param>
        /// <param name="acc">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
        /// <param name="alpha">Weight of input image. </param>
        /// <param name="mask">Optional operation mask. </param>
#endif
        public static void RunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (acc == null)
                throw new ArgumentNullException("acc");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvRunningAvg(image.CvPtr, acc.CvPtr, alpha, maskPtr);
        }
        #endregion
    }
}