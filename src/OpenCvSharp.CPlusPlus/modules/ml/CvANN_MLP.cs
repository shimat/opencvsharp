using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// MLPモデルクラス
    /// </summary>
#else
	/// <summary>
    /// MLP model
    /// </summary>
#endif
	public class CvANN_MLP : CvStatModel
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

		#region Constants
#pragma warning disable 1591
        // Possible activation functions
		public const MLPActivationFunc IDENTITY    = MLPActivationFunc.Identity;
		public const MLPActivationFunc SIGMOID_SYM = MLPActivationFunc.SigmoidSym;
		public const MLPActivationFunc GAUSSIAN    = MLPActivationFunc.Gaussian;		
		// Splitting criteria
		public const MLPTrainingFlag UPDATE_WEIGHTS  = MLPTrainingFlag.UpdateWeights;
		public const MLPTrainingFlag NO_INPUT_SCALE  = MLPTrainingFlag.NoInputScale;
		public const MLPTrainingFlag NO_OUTPUT_SCALE = MLPTrainingFlag.NoOutputScale;
#pragma warning restore 1591
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定のコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
		public CvANN_MLP()
		{
			ptr = NativeMethods.ml_CvANN_MLP_new1();
		}

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="layerSizes">入出力層を含む各層のニューロン数を指定する整数のベクトル</param>
        /// <param name="activFunc">各ニューロンの活性化関数</param>
        /// <param name="fParam1">活性化関数のフリーパラメータα</param>
        /// <param name="fParam2">活性化関数のフリーパラメータβ</param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="layerSizes">The integer vector specifies the number of neurons in each layer including the input and output layers. </param>
        /// <param name="activFunc">Specifies the activation function for each neuron</param>
        /// <param name="fParam1">Free parameter α of the activation function</param>
		/// <param name="fParam2">Free parameter β of the activation function</param>
#endif
		public CvANN_MLP(
            CvMat layerSizes, 
            MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym, 
            double fParam1 = 0, double fParam2 = 0)
		{
            if (layerSizes == null)
                throw new ArgumentNullException("layerSizes");

            ptr = NativeMethods.ml_CvANN_MLP_new2_CvMat(
                layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
		}

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="layerSizes">入出力層を含む各層のニューロン数を指定する整数のベクトル</param>
        /// <param name="activFunc">各ニューロンの活性化関数</param>
        /// <param name="fParam1">活性化関数のフリーパラメータα</param>
        /// <param name="fParam2">活性化関数のフリーパラメータβ</param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="layerSizes">The integer vector specifies the number of neurons in each layer including the input and output layers. </param>
        /// <param name="activFunc">Specifies the activation function for each neuron</param>
        /// <param name="fParam1">Free parameter α of the activation function</param>
        /// <param name="fParam2">Free parameter β of the activation function</param>
#endif
        public CvANN_MLP(
            Mat layerSizes,
            MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym,
            double fParam1 = 0, double fParam2 = 0)
        {
            if (layerSizes == null)
                throw new ArgumentNullException("layerSizes");

            ptr = NativeMethods.ml_CvANN_MLP_new2_Mat(
                layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
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
                        NativeMethods.ml_CvANN_MLP_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
		#endregion

		#region Methods

		#region Create
#if LANG_JP
        /// <summary>
        /// 指定したトポロジーでMLPを構築する
        /// </summary>
        /// <param name="layerSizes">入出力層を含む各層のニューロン数を指定する整数のベクトル</param>
        /// <param name="activFunc">各ニューロンの活性化関数</param>
        /// <param name="fParam1">活性化関数のフリーパラメータα</param>
        /// <param name="fParam2">活性化関数のフリーパラメータβ</param>
#else
		/// <summary>
        /// Constructs the MLP with the specified topology
        /// </summary>
        /// <param name="layerSizes">The integer vector specifies the number of neurons in each layer including the input and output layers. </param>
		/// <param name="activFunc">Specifies the activation function for each neuron</param>
        /// <param name="fParam1">Free parameter α of the activation function</param>
		/// <param name="fParam2">Free parameter β of the activation function</param>
#endif
		public void Create(
            CvMat layerSizes, 
            MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym, 
            double fParam1 = 0, double fParam2 = 0)
		{
            if (disposed)
                throw new ObjectDisposedException("StatModel");
			if (layerSizes == null)
                throw new ArgumentNullException("layerSizes");
            layerSizes.ThrowIfDisposed();

            NativeMethods.ml_CvANN_MLP_create_CvMat(
                ptr, layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
		}
#if LANG_JP
        /// <summary>
        /// 指定したトポロジーでMLPを構築する
        /// </summary>
        /// <param name="layerSizes">入出力層を含む各層のニューロン数を指定する整数のベクトル</param>
        /// <param name="activFunc">各ニューロンの活性化関数</param>
        /// <param name="fParam1">活性化関数のフリーパラメータα</param>
        /// <param name="fParam2">活性化関数のフリーパラメータβ</param>
#else
        /// <summary>
        /// Constructs the MLP with the specified topology
        /// </summary>
        /// <param name="layerSizes">The integer vector specifies the number of neurons in each layer including the input and output layers. </param>
        /// <param name="activFunc">Specifies the activation function for each neuron</param>
        /// <param name="fParam1">Free parameter α of the activation function</param>
        /// <param name="fParam2">Free parameter β of the activation function</param>
#endif
        public void Create(
            Mat layerSizes,
            MLPActivationFunc activFunc = MLPActivationFunc.SigmoidSym,
            double fParam1 = 0, double fParam2 = 0)
        {
            if (disposed)
                throw new ObjectDisposedException("StatModel");
            if (layerSizes == null)
                throw new ArgumentNullException("layerSizes");
            layerSizes.ThrowIfDisposed();

            NativeMethods.ml_CvANN_MLP_create_Mat(
                ptr, layerSizes.CvPtr, (int)activFunc, fParam1, fParam2);
        }
		#endregion

		#region Train
#if LANG_JP
        /// <summary>
        /// MLPの学習と更新
        /// </summary>
        /// <param name="inputs">入力ベクトルの浮動小数点の行列で，1行で1ベクトル．</param>
		/// <param name="outputs">対応する出力ベクトルの浮動小数点の行列で，1行で1ベクトル．</param>
        /// <param name="sampleWeights">（RPROPのみ）各サンプルの重みを指定する浮動小数点のベクトル．オプション． 学習において，幾つかのサンプルは他のものより重要な場合がある． 例えば検出率と誤検出率間の適切なバランスを探すために，あるクラスの重みを増加させたい場合など．</param>
        /// <param name="sampleIdx">用いるサンプルを表す整数のベクトル（すなわち_inputsと_outputsの行）．</param>
        /// <param name="param">学習パラメータ</param>
		/// <param name="flags">学習アルゴリズムを制御する様々なパラメータ</param>
		/// <returns>ネットワークの重みを計算/調整した繰り返し回数．</returns>
#else
		/// <summary>
        /// Trains/updates MLP
        /// </summary>
        /// <param name="inputs">A floating-point matrix of input vectors, one vector per row. </param>
		/// <param name="outputs">A floating-point matrix of the corresponding output vectors, one vector per row. </param>
        /// <param name="sampleWeights">(RPROP only) The optional floating-point vector of weights for each sample. Some samples may be more important than others for training, e.g. user may want to gain the weight of certain classes to find the right balance between hit-rate and false-alarm rate etc. </param>
        /// <param name="sampleIdx">The optional integer vector indicating the samples (i.e. rows of _inputs and _outputs) that are taken into account. </param>
        /// <param name="param">The training params.</param>
        /// <param name="flags">The various parameters to control the training algorithm.</param>
		/// <returns>the number of done iterations.</returns>
#endif
		public virtual int Train(CvMat inputs, CvMat outputs, CvMat sampleWeights, 
			CvMat sampleIdx = null, 
            CvANN_MLP_TrainParams param = null, 
            MLPTrainingFlag flags = MLPTrainingFlag.Zero )
		{    
			if (inputs == null)
                throw new ArgumentNullException("inputs");
            if (outputs == null)
                throw new ArgumentNullException("outputs");
            inputs.ThrowIfDisposed();
            outputs.ThrowIfDisposed();

			if(param == null)
				param = new CvANN_MLP_TrainParams();

			return NativeMethods.ml_CvANN_MLP_train_CvMat(
                ptr,
				inputs.CvPtr, 
				outputs.CvPtr,
                Cv2.ToPtr(sampleWeights), 
				Cv2.ToPtr(sampleIdx),
				param.NativeStruct,
				(int)flags
			);
		}

#if LANG_JP
        /// <summary>
        /// MLPの学習と更新
        /// </summary>
        /// <param name="inputs">入力ベクトルの浮動小数点の行列で，1行で1ベクトル．</param>
		/// <param name="outputs">対応する出力ベクトルの浮動小数点の行列で，1行で1ベクトル．</param>
        /// <param name="sampleWeights">（RPROPのみ）各サンプルの重みを指定する浮動小数点のベクトル．オプション． 学習において，幾つかのサンプルは他のものより重要な場合がある． 例えば検出率と誤検出率間の適切なバランスを探すために，あるクラスの重みを増加させたい場合など．</param>
        /// <param name="sampleIdx">用いるサンプルを表す整数のベクトル（すなわち_inputsと_outputsの行）．</param>
        /// <param name="param">学習パラメータ</param>
		/// <param name="flags">学習アルゴリズムを制御する様々なパラメータ</param>
		/// <returns>ネットワークの重みを計算/調整した繰り返し回数．</returns>
#else
        /// <summary>
        /// Trains/updates MLP
        /// </summary>
        /// <param name="inputs">A floating-point matrix of input vectors, one vector per row. </param>
        /// <param name="outputs">A floating-point matrix of the corresponding output vectors, one vector per row. </param>
        /// <param name="sampleWeights">(RPROP only) The optional floating-point vector of weights for each sample. Some samples may be more important than others for training, e.g. user may want to gain the weight of certain classes to find the right balance between hit-rate and false-alarm rate etc. </param>
        /// <param name="sampleIdx">The optional integer vector indicating the samples (i.e. rows of _inputs and _outputs) that are taken into account. </param>
        /// <param name="param">The training params.</param>
        /// <param name="flags">The various parameters to control the training algorithm.</param>
        /// <returns>the number of done iterations.</returns>
#endif
        public virtual int Train(Mat inputs, Mat outputs, Mat sampleWeights,
            Mat sampleIdx = null,
            CvANN_MLP_TrainParams param = null,
            MLPTrainingFlag flags = MLPTrainingFlag.Zero)
        {
            if (inputs == null)
                throw new ArgumentNullException("inputs");
            if (outputs == null)
                throw new ArgumentNullException("outputs");
            inputs.ThrowIfDisposed();
            outputs.ThrowIfDisposed();

            if (param == null)
                param = new CvANN_MLP_TrainParams();

            return NativeMethods.ml_CvANN_MLP_train_CvMat(
                ptr,
                inputs.CvPtr,
                outputs.CvPtr,
                Cv2.ToPtr(sampleWeights),
                Cv2.ToPtr(sampleIdx),
                param.NativeStruct,
                (int)flags
            );
        }
		#endregion

		#region Predict
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="inputs">入力サンプル</param>
		/// <param name="outputs"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Predicts response for the input sample
        /// </summary>
        /// <param name="inputs">The input sample. </param>
		/// <param name="outputs"></param>
        /// <returns></returns>
#endif
		public float Predict(CvMat inputs, CvMat outputs)
		{
			if (inputs == null)
                throw new ArgumentNullException("inputs");
			if (outputs == null)
                throw new ArgumentNullException("outputs");
            inputs.ThrowIfDisposed();
            outputs.ThrowIfDisposed();

			return NativeMethods.ml_CvANN_MLP_predict_CvMat(ptr, inputs.CvPtr, outputs.CvPtr);
		}
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="inputs">入力サンプル</param>
		/// <param name="outputs"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Predicts response for the input sample
        /// </summary>
        /// <param name="inputs">The input sample. </param>
        /// <param name="outputs"></param>
        /// <returns></returns>
#endif
        public float Predict(Mat inputs, Mat outputs)
        {
            if (inputs == null)
                throw new ArgumentNullException("inputs");
            if (outputs == null)
                throw new ArgumentNullException("outputs");
            inputs.ThrowIfDisposed();
            outputs.ThrowIfDisposed();

            return NativeMethods.ml_CvANN_MLP_predict_CvMat(ptr, inputs.CvPtr, outputs.CvPtr);
        }
		#endregion

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
		public int GetLayerCount()
		{
            return NativeMethods.ml_CvANN_MLP_get_layer_count(ptr);
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
		public CvMat GetLayerSizes()
		{
            IntPtr p = NativeMethods.ml_CvANN_MLP_get_layer_sizes(ptr);
            if(p == IntPtr.Zero)
                return null;
            return new CvMat(p, false);
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
            NativeMethods.ml_CvANN_MLP_clear(ptr);
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

            NativeMethods.ml_CvANN_MLP_write(ptr, storage.CvPtr, name);
        }

#if LANG_JP
        /// <summary>
        /// ファイルストレージからモデルを読み込む
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
#else
		/// <summary>
        /// Reads the model from file storage
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
#endif
		public override void Read(CvFileStorage fs, CvFileNode node)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (node == null)
                throw new ArgumentNullException("node");

            NativeMethods.ml_CvANN_MLP_read(ptr, fs.CvPtr, node.CvPtr);
        }
		#endregion
        #endregion
	}
}