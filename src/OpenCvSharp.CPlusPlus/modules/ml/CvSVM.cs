/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// SVM model classifier
    /// </summary>
#else
	/// <summary>
    /// Support Vector Machines
    /// </summary>
#endif
    public class CvSVM : CvStatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Constants
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        // SVMの種類
		public const SVMType C_SVC		=	SVMType.CSvc; 
		public const SVMType NU_SVC		=	SVMType.NuSvc; 
		public const SVMType ONE_CLASS	=	SVMType.OneClass; 
		public const SVMType EPS_SVR		=	SVMType.EpsSvr; 
		public const SVMType NU_SVR		=	SVMType.NuSvr; 
		// SVMカーネルの種類
		public const SVMKernelType LINEAR	=	SVMKernelType.Linear; 
		public const SVMKernelType POLY		=	SVMKernelType.Poly;
		public const SVMKernelType RBF		=	SVMKernelType.Rbf;
		public const SVMKernelType SIGMOID	=	SVMKernelType.Sigmoid; 
		// SVMパラメータの種類
		public const SVMParamType C		    =	SVMParamType.C; 
		public const SVMParamType GAMMA	    =	SVMParamType.Gamma;
		public const SVMParamType P		    =	SVMParamType.P;
		public const SVMParamType NU			=	SVMParamType.Nu; 
		public const SVMParamType COEF	    =	SVMParamType.Coef; 
		public const SVMParamType DEGREE		=	SVMParamType.Degree;
// ReSharper restore InconsistentNaming
#pragma warning restore 1591
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvSVM()
        {
            ptr = NativeMethods.ml_CvSVM_new1();
        }

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
		/// <param name="train_data"></param>
		/// <param name="responses"></param>
		/// <param name="var_idx"></param>
		/// <param name="sample_idx"></param>
		/// <param name="params"></param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
		/// <param name="trainData"></param>
		/// <param name="responses"></param>
		/// <param name="varIdx"></param>
		/// <param name="sampleIdx"></param>
		/// <param name="param"></param>
#endif
		public CvSVM(
            CvMat trainData, 
            CvMat responses, 
            CvMat varIdx = null, 
            CvMat sampleIdx = null, 
            CvSVMParams param = null)
	    {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

			if(param == null)
				param = new CvSVMParams();
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            ptr = NativeMethods.ml_CvSVM_new2_CvMat(
				trainData.CvPtr, 
				responses.CvPtr, 
				Cv2.ToPtr(varIdx), 
				Cv2.ToPtr(sampleIdx), 
				param.NativeStruct
			);
        }

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
		/// <param name="train_data"></param>
		/// <param name="responses"></param>
		/// <param name="var_idx"></param>
		/// <param name="sample_idx"></param>
		/// <param name="params"></param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="param"></param>
#endif
        public CvSVM(
            Mat trainData,
            Mat responses,
            Mat varIdx = null,
            Mat sampleIdx = null,
            CvSVMParams param = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if (param == null)
                param = new CvSVMParams();

            ptr = NativeMethods.ml_CvSVM_new2_Mat(
                trainData.CvPtr,
                responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                param.NativeStruct
            );
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
                        NativeMethods.ml_CvSVM_delete(ptr);
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
	    /// SVM パラメータのためのグリッドを生成する
	    /// </summary>
	    /// <param name="param_id"></param>
	    /// <returns></returns>
#else
		/// <summary>
	    /// Generates a grid for SVM parameters
	    /// </summary>
	    /// <param name="paramId"></param>
	    /// <returns></returns>
#endif
	    public static CvParamGrid GetDefaultGrid(SVMParamType paramId)
	    {
            var grid = new CvParamGrid();
			NativeMethods.ml_CvSVM_get_default_grid(ref grid, (int)paramId);
            return grid;
	    }

#if LANG_JP
        /// <summary>
        /// サポートベクターの個数を返す
        /// </summary>
        /// <returns></returns>
#else
		/// <summary>
        /// Retrieves the number of support vectors
        /// </summary>
        /// <returns></returns>
#endif
        public int GetSupportVectorCount()
	    {
            return NativeMethods.ml_CvSVM_get_support_vector_count(ptr);
	    }

#if LANG_JP
        /// <summary>
        /// 特定のサポートベクターを取得する
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Retrieves the particular vector
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
#endif
		public PointerAccessor1D_Single GetSupportVector(int i)
        {
            unsafe
            {
                float* p = NativeMethods.ml_CvSVM_get_support_vector(ptr, i);
                return new PointerAccessor1D_Single(p);
            }
        }

#if LANG_JP
        /// <summary>
	    /// 現在の SVM パラメータを返す
	    /// </summary>
	    /// <returns></returns>
#else
		/// <summary>
	    /// Returns current SVM parameters
	    /// </summary>
	    /// <returns></returns>
#endif
	    public CvSVMParams GetParams()
	    {
            var p = new WCvSVMParams();
            NativeMethods.ml_CvSVM_get_params(ptr, ref p);
            return new CvSVMParams(p);
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
            return NativeMethods.ml_CvSVM_get_var_count(ptr);
        }
 
#if LANG_JP
	    /// <summary>
        /// SVMを学習する
	    /// </summary>
        /// <param name="train_data"></param>
        /// <param name="responses"></param>
        /// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="params"></param>
#else
		/// <summary>
        /// Trains SVM
	    /// </summary>
        /// <param name="trainData"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="param"></param>
#endif
        public virtual bool Train(
            CvMat trainData, 
            CvMat responses, 
            CvMat varIdx = null, 
            CvMat sampleIdx = null, 
            CvSVMParams param = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

			if(param == null)
				param = new CvSVMParams();

            return NativeMethods.ml_CvSVM_train_CvMat(
                ptr,
				trainData.CvPtr, 
				responses.CvPtr, 
				Cv2.ToPtr(varIdx), 
				Cv2.ToPtr(sampleIdx), 
				param.NativeStruct) != 0;
        }
#if LANG_JP
	    /// <summary>
        /// SVMを学習する
	    /// </summary>
        /// <param name="train_data"></param>
        /// <param name="responses"></param>
        /// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="params"></param>
#else
        /// <summary>
        /// Trains SVM
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="param"></param>
#endif
        public virtual bool Train(
            Mat trainData,
            Mat responses,
            Mat varIdx = null,
            Mat sampleIdx = null,
            CvSVMParams param = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if (param == null)
                param = new CvSVMParams();

            return NativeMethods.ml_CvSVM_train_Mat(
                ptr,
                trainData.CvPtr,
                responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                param.NativeStruct) != 0;
        }

#if LANG_JP
        /// <summary>
	    /// SVMを最適なパラメータで学習する
	    /// </summary>
	    /// <param name="train_data"></param>
	    /// <param name="responses"></param>
	    /// <param name="var_idx"></param>
	    /// <param name="sample_idx"></param>
	    /// <param name="params"></param>
	    /// <param name="k_fold">交差検定（Cross-validation）パラメータ．学習集合は，k_foldの部分集合に分割され，一つの部分集合がモデルの学習に用いられ，その他の部分集合はテスト集合となる．つまり，SVM アルゴリズムは，k_fold回実行される.</param>
	    /// <param name="C_grid"></param>
	    /// <param name="gamma_grid"></param>
	    /// <param name="p_grid"></param>
	    /// <param name="nu_grid"></param>
	    /// <param name="coef_grid"></param>
	    /// <param name="degree_grid"></param>
	    /// <returns></returns>
#else
	    /// <summary>
	    /// Trains SVM with optimal parameters
	    /// </summary>
	    /// <param name="trainData"></param>
	    /// <param name="responses"></param>
	    /// <param name="varIdx"></param>
	    /// <param name="sampleIdx"></param>
	    /// <param name="param"></param>
	    /// <param name="kFold">Cross-validation parameter. The training set is divided into k_fold subsets, one subset being used to train the model, the others forming the test set. So, the SVM algorithm is executed k_fold times. </param>
	    /// <param name="cGrid"></param>
	    /// <param name="gammaGrid"></param>
	    /// <param name="pGrid"></param>
	    /// <param name="nuGrid"></param>
	    /// <param name="coefGrid"></param>
	    /// <param name="degreeGrid"></param>
	    /// <param name="balanced"></param>
	    /// <returns></returns>
#endif
        public virtual bool TrainAuto(
            CvMat trainData, 
            CvMat responses, 
            CvMat varIdx, 
            CvMat sampleIdx, 
            CvSVMParams param, 
            int kFold = 10, 
            CvParamGrid? cGrid = null,
            CvParamGrid? gammaGrid = null,
            CvParamGrid? pGrid = null,
            CvParamGrid? nuGrid = null,
            CvParamGrid? coefGrid = null,
            CvParamGrid? degreeGrid = null,
            bool balanced = false)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            if (varIdx == null)
                throw new ArgumentNullException("varIdx");
            if (sampleIdx == null)
                throw new ArgumentNullException("sampleIdx");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();
            varIdx.ThrowIfDisposed();
            sampleIdx.ThrowIfDisposed();

			if(param == null)
				param = new CvSVMParams();
	        var cGrid0 = cGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var gammaGrid0 = gammaGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var pGrid0 = pGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var nuGrid0 = nuGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var coefGrid0 = coefGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var degreeGrid0 = degreeGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));

            return NativeMethods.ml_CvSVM_train_auto_CvMat(
                ptr,
                trainData.CvPtr,
                responses.CvPtr,
                varIdx.CvPtr,
                sampleIdx.CvPtr, 
				param.NativeStruct, 
				kFold, 
				cGrid0, 
				gammaGrid0,
				pGrid0,
				nuGrid0,
				coefGrid0,
				degreeGrid0,
                balanced ? 1 : 0) != 0;
        }

#if LANG_JP
        /// <summary>
	    /// SVMを最適なパラメータで学習する
	    /// </summary>
	    /// <param name="train_data"></param>
	    /// <param name="responses"></param>
	    /// <param name="var_idx"></param>
	    /// <param name="sample_idx"></param>
	    /// <param name="params"></param>
	    /// <param name="k_fold">交差検定（Cross-validation）パラメータ．学習集合は，k_foldの部分集合に分割され，一つの部分集合がモデルの学習に用いられ，その他の部分集合はテスト集合となる．つまり，SVM アルゴリズムは，k_fold回実行される.</param>
	    /// <param name="C_grid"></param>
	    /// <param name="gamma_grid"></param>
	    /// <param name="p_grid"></param>
	    /// <param name="nu_grid"></param>
	    /// <param name="coef_grid"></param>
	    /// <param name="degree_grid"></param>
	    /// <returns></returns>
#else
        /// <summary>
        /// Trains SVM with optimal parameters
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="param"></param>
        /// <param name="kFold">Cross-validation parameter. The training set is divided into k_fold subsets, one subset being used to train the model, the others forming the test set. So, the SVM algorithm is executed k_fold times. </param>
        /// <param name="cGrid"></param>
        /// <param name="gammaGrid"></param>
        /// <param name="pGrid"></param>
        /// <param name="nuGrid"></param>
        /// <param name="coefGrid"></param>
        /// <param name="degreeGrid"></param>
        /// <param name="balanced"></param>
        /// <returns></returns>
#endif
        public virtual bool TrainAuto(
            Mat trainData,
            Mat responses,
            Mat varIdx,
            Mat sampleIdx,
            CvSVMParams param,
            int kFold = 10,
            CvParamGrid? cGrid = null,
            CvParamGrid? gammaGrid = null,
            CvParamGrid? pGrid = null,
            CvParamGrid? nuGrid = null,
            CvParamGrid? coefGrid = null,
            CvParamGrid? degreeGrid = null,
            bool balanced = false)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            if (varIdx == null)
                throw new ArgumentNullException("varIdx");
            if (sampleIdx == null)
                throw new ArgumentNullException("sampleIdx");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();
            varIdx.ThrowIfDisposed();
            sampleIdx.ThrowIfDisposed();

            if (param == null)
                param = new CvSVMParams();
            var cGrid0 = cGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var gammaGrid0 = gammaGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var pGrid0 = pGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var nuGrid0 = nuGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var coefGrid0 = coefGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));
            var degreeGrid0 = degreeGrid.GetValueOrDefault(GetDefaultGrid(SVMParamType.C));

            return NativeMethods.ml_CvSVM_train_auto_CvMat(
                ptr,
                trainData.CvPtr,
                responses.CvPtr,
                varIdx.CvPtr,
                sampleIdx.CvPtr,
                param.NativeStruct,
                kFold,
                cGrid0,
                gammaGrid0,
                pGrid0,
                nuGrid0,
                coefGrid0,
                degreeGrid0,
                balanced ? 1 : 0) != 0;
        }

#if LANG_JP
        /// <summary>
	    /// サンプルに対する応答を予測する
	    /// </summary>
	    /// <param name="sample"></param>
	    /// <param name="returnDfVal"></param>
	    /// <returns></returns>
#else
        /// <summary>
	    /// Predicts the response for sample
	    /// </summary>
	    /// <param name="sample"></param>
        /// <param name="returnDfVal"></param>
	    /// <returns></returns>
#endif
        public virtual float Predict(CvMat sample, bool returnDfVal = false)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();
            return NativeMethods.ml_CvSVM_predict_CvMat1(ptr, sample.CvPtr, returnDfVal ? 1 : 0);
        }
#if LANG_JP
        /// <summary>
	    /// サンプルに対する応答を予測する
	    /// </summary>
	    /// <param name="sample"></param>
	    /// <param name="results"></param>
	    /// <returns></returns>
#else
        /// <summary>
        /// Predicts the response for sample
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="results"></param>
        /// <returns></returns>
#endif
        public virtual float Predict(CvMat sample, CvMat results)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            if (results == null)
                throw new ArgumentNullException("results");
            sample.ThrowIfDisposed();
            results.ThrowIfDisposed();
            return NativeMethods.ml_CvSVM_predict_CvMat2(ptr, sample.CvPtr, results.CvPtr);
        }
#if LANG_JP
        /// <summary>
	    /// サンプルに対する応答を予測する
	    /// </summary>
	    /// <param name="sample"></param>
	    /// <param name="returnDfVal"></param>
	    /// <returns></returns>
#else
        /// <summary>
        /// Predicts the response for sample
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="returnDfVal"></param>
        /// <returns></returns>
#endif
        public virtual float Predict(Mat sample, bool returnDfVal = false)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();
            return NativeMethods.ml_CvSVM_predict_CvMat1(ptr, sample.CvPtr, returnDfVal ? 1 : 0);
        }
#if LANG_JP
        /// <summary>
	    /// サンプルに対する応答を予測する
	    /// </summary>
	    /// <param name="sample"></param>
	    /// <param name="results"></param>
	    /// <returns></returns>
#else
        /// <summary>
        /// Predicts the response for sample
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="results"></param>
        /// <returns></returns>
#endif
        public virtual float Predict(InputArray sample, OutputArray results)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            if (results == null)
                throw new ArgumentNullException("results");
            sample.ThrowIfDisposed();
            results.ThrowIfNotReady();
            float ret = NativeMethods.ml_CvSVM_predict_CvMat2(ptr, sample.CvPtr, results.CvPtr);
            results.Fix();
            return ret;
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
            NativeMethods.ml_CvSVM_clear(ptr);
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
		public override void Write(CvFileStorage storage, String name) 
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
			if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            NativeMethods.ml_CvSVM_write(ptr, storage.CvPtr, name);
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

            NativeMethods.ml_CvSVM_read(ptr, storage.CvPtr, node.CvPtr);
        }
		#endregion
        #endregion
    }
}
