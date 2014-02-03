/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
    /// 正規分布データに対するベイズ分類器クラス
    /// </summary>
#else
	/// <summary>
    /// Bayes classifier for normally distributed data
    /// </summary>
#endif
    public class CvNormalBayesClassifier : CvStatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Constants
        /// <summary>
        /// sizeof(CvNormalBayesClassifier)
        /// </summary>
		public static readonly int SizeOf = MLInvoke.CvNormalBayesClassifier_sizeof();
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
        public CvNormalBayesClassifier()
        {
            ptr = MLInvoke.CvNormalBayesClassifier_construct_default();
			NotifyMemoryPressure(SizeOf);
        }
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="train_data">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Bayes classifier for normally distributed data
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <returns></returns>
#endif
		public CvNormalBayesClassifier(CvMat trainData, CvMat responses, CvMat varIdx, CvMat sampleIdx)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;
            IntPtr varIdxPtr = (varIdx == null) ? IntPtr.Zero : varIdx.CvPtr;

            ptr = MLInvoke.CvNormalBayesClassifier_construct_training(trainData.CvPtr, responses.CvPtr, varIdxPtr, sampleIdxPtr);
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
                        MLInvoke.CvNormalBayesClassifier_destruct(ptr);
                        //ML.CvNormalBayesClassifier_clear(_ptr);
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

        # region Methods
#if LANG_JP
        /// <summary>
        /// サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">未知のサンプル (l*n)</param>
        /// <param name="results">既知のサンプルのクラス (l*1)</param>
#else
		/// <summary>
        /// Predicts the response for sample(s)
        /// </summary>
        /// <param name="sample">Unkown samples (l*n)</param>
        /// <param name="results">Classes for known samples (l*1)</param>
#endif
        public virtual float Predict(CvMat sample, CvMat results)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");

            IntPtr resultsPtr = (results == null) ? IntPtr.Zero : results.CvPtr;
            return MLInvoke.CvNormalBayesClassifier_predict(ptr, sample.CvPtr, resultsPtr);
        }

#if LANG_JP
		/// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="train_data">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, CvMat responses)
        {
			return Train(trainData, responses, null, null, false);
		}
#if LANG_JP
		/// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="train_data">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="var_idx"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, CvMat responses, CvMat varIdx)
        {
			return Train(trainData, responses, varIdx, null, false);
		}
#if LANG_JP
		/// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="train_data">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, CvMat responses, CvMat varIdx, CvMat sampleIdx)
        {
			return Train(trainData, responses, varIdx, sampleIdx, false);
		}
#if LANG_JP
		/// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="train_data">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="update">モデルを最初から学習する（false）か，新しい学習データを用いて更新する（true）か</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="update">Adds known samples to model(true) or makes a new one(false)</param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, CvMat responses, CvMat varIdx, CvMat sampleIdx, bool update)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;
            IntPtr varIdxPtr = (varIdx == null) ? IntPtr.Zero : varIdx.CvPtr;

            return MLInvoke.CvNormalBayesClassifier_train(ptr, trainData.CvPtr, responses.CvPtr, varIdxPtr, sampleIdxPtr, update);
        }

		# region CvStatModel methods
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
            MLInvoke.CvNormalBayesClassifier_clear(ptr);
        }

#if LANG_JP
        /// <summary>
        /// モデルをファイルに書き込む
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="name"></param>
#else
		/// <summary>
        /// Writes the model to file storage
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="name"></param>
#endif
		public override void Write(CvFileStorage storage, string name)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
			if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
			
            MLInvoke.CvNormalBayesClassifier_write(ptr, storage.CvPtr, name);
        }

#if LANG_JP
        /// <summary>
        /// ファイルストレージからモデルを読み込む
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="node"></param>
#else
		/// <summary>
        /// Reads the model from file storage
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="node"></param>
#endif
		public override void Read(CvFileStorage storage, CvFileNode node)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
            if (node == null)
                throw new ArgumentNullException("node");

            MLInvoke.CvNormalBayesClassifier_read(ptr, storage.CvPtr, node.CvPtr);
        }
		# endregion
        # endregion
    }
}
