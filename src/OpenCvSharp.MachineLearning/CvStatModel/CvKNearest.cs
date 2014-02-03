/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
    /// K近傍法モデルクラス
    /// </summary>
#else
	/// <summary>
    /// K nearest neighbors classifier
    /// </summary>
#endif
    public class CvKNearest : CvStatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Constants
        /// <summary>
        /// sizeof(CvKNearest)
        /// </summary>
		public static readonly int SizeOf = MLInvoke.CvKNearest_sizeof();
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
		/// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvKNearest()
        {
			ptr = MLInvoke.CvKNearest_construct_default();
			NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="train_data">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="sample_idx"></param>
        /// <param name="is_regression"></param>
        /// <param name="max_k">FindNearestに渡される近傍の最大値</param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">Maximum number of neighbors to return</param>
#endif
		public CvKNearest(CvMat trainData, CvMat responses, CvMat sampleIdx, bool isRegression, int maxK)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;

            ptr = MLInvoke.CvKNearest_construct_training(
                trainData.CvPtr, 
                responses.CvPtr,
                sampleIdxPtr, 
                isRegression, 
                maxK
            );

            NotifyMemoryPressure(SizeOf);
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        MLInvoke.CvKNearest_destruct(ptr);
                        //ML.CvKNearest_clear(_ptr);
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
        #endregion

        #region Methods
#if LANG_JP
        /// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="train_data">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="sample_idx"></param>
        /// <param name="is_regression"></param>
        /// <param name="max_k">FindNearestに渡される近傍の最大数</param>
        /// <param name="update_base">モデルを始めから作り直す（false）か，新しい教師データを使って更新する（true）か</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">Maximum number of neighbors to return</param>
        /// <param name="updateBase">Adds known samples to model(true) or makes a new one(false)</param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, CvMat responses, CvMat sampleIdx, bool isRegression, int maxK, bool updateBase)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            
            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;

            return MLInvoke.CvKNearest_train(
                ptr,
                trainData.CvPtr,
                responses.CvPtr,
                sampleIdxPtr,
                isRegression,
                maxK, 
                updateBase
            );
        }

#if LANG_JP
        /// <summary>
        /// 入力ベクトルの近傍を探す
        /// </summary>
        /// <param name="samples">既知のサンプル (l*n)</param>
        /// <param name="k">探索する近傍の数の最大数</param>
        /// <param name="results"></param>
        /// <param name="neighbors"></param>
        /// <param name="neighbor_responses">それぞれのサンプルの近傍 (l*k)</param>
        /// <param name="dist">サンプルから近傍までの距離</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Finds the K nearest neighbors of samples
        /// </summary>
        /// <param name="samples">Known samples (l*n)</param>
        /// <param name="k">max neighbors to find</param>
        /// <param name="results"></param>
        /// <param name="neighbors"></param>
        /// <param name="neighborResponses">Neighbors for each samples (l*k)</param>
        /// <param name="dist">Distance from each sample to neighbors</param>
        /// <returns></returns>
#endif
        public virtual float FindNearest(CvMat samples, int k, CvMat results, float[][] neighbors, CvMat neighborResponses, CvMat dist)
        {
            if (samples == null)
			{
                throw new ArgumentNullException("samples");
			}
                        
            IntPtr resultsPtr = (results == null) ? IntPtr.Zero : results.CvPtr;
            IntPtr neighborResponsesPtr = (neighborResponses == null) ? IntPtr.Zero : neighborResponses.CvPtr;
            IntPtr distPtr = (dist == null) ? IntPtr.Zero : dist.CvPtr;

            if (neighbors == null)
            {
                return MLInvoke.CvKNearest_find_nearest(
                    ptr,
                    samples.CvPtr, 
                    k, 
                    resultsPtr, 
                    IntPtr.Zero, 
                    neighborResponsesPtr,
                    distPtr
                );
            }
            else
            {
                ArrayAddress2<Single> aa = new ArrayAddress2<Single>(neighbors);
				return MLInvoke.CvKNearest_find_nearest(
                    ptr,
                    samples.CvPtr, 
                    k, 
                    resultsPtr, 
                    aa.Pointer, 
                    neighborResponsesPtr,
                    distPtr
				);
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int GetMaxK()
        {
            return MLInvoke.CvKNearest_get_max_k(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int GetVarCount() 
        {
            return MLInvoke.CvKNearest_get_var_count(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int GetSampleCount()
        {
            return MLInvoke.CvKNearest_get_sample_count(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public bool IsRegression()
        {
            return MLInvoke.CvKNearest_is_regression(ptr);
        }

		#region CvStatModel methods
#if LANG_JP
        /// <summary>
        /// メモリを解放し，モデルの状態をリセットする
        /// </summary>
#else
		/// <summary>
        /// Deallocates memory and resets the model state
        /// </summary>
#endif
        public override void Clear() 
        {
            MLInvoke.CvKNearest_clear(ptr);
        }
		#endregion
        #endregion
    }
}
