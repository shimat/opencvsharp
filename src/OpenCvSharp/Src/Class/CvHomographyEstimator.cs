/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp
{
    public abstract class CvModelEstimator2 : DisposableObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_modelPoints"></param>
        /// <param name="_modelSize"></param>
        /// <param name="_maxBasicSolutions"></param>
        public CvModelEstimator2(int _modelPoints, CvSize _modelSize, int _maxBasicSolutions)
        {
            modelPoints = _modelPoints;
            modelSize = _modelSize;
            maxBasicSolutions = _maxBasicSolutions;
            checkPartialSubsets = true;
            rng = new CvRNG(-1);
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
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {

                    }
                    if (IsEnabledDispose)
                    {
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public abstract int RunKernel(CvMat m1, CvMat m2, CvMat model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="model"></param>
        /// <param name="maxIters"></param>
        /// <returns></returns>
        public abstract bool Refine( CvMat m1, CvMat m2, CvMat model, int maxIters );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seed"></param>
        public virtual void SetSeed(long seed)
        {
            rng = new CvRNG(seed);
        }

        public CvRNG rng;
        public int modelPoints;
        public CvSize modelSize;
        public int maxBasicSolutions;
        public bool checkPartialSubsets;
    }

#if LANG_JP
    /// <summary>
    /// CvLevMarq
    /// </summary>
#else
    /// <summary>
    /// CvLevMarq
    /// </summary>
#endif
    public class CvHomographyEstimator : CvModelEstimator2
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and Disposal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_modelPoints"></param>
        public CvHomographyEstimator(int _modelPoints)
            : base(_modelPoints, new CvSize(3, 3), 1)
        {
            if (_modelPoints != 4 && _modelPoints != 5)
            {
                throw new ArgumentOutOfRangeException("_modelPoints");
            }            
            checkPartialSubsets = false;
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
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                        
                    }
                    if (IsEnabledDispose)
                    {                        
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override unsafe int RunKernel(CvMat m1, CvMat m2, CvMat model)
        {
            int count = m1.Rows * m1.Cols;
            CvPoint2D64f* M = (CvPoint2D64f*)m1.DataByte;
            CvPoint2D64f* m = (CvPoint2D64f*)m2.DataByte;

            double* LtL = stackalloc double[9 * 9],
                     W = stackalloc double[9 * 9],
                      V = stackalloc double[9 * 9];
            CvMat _LtL = new CvMat(9, 9, MatrixType.F64C1, new IntPtr(LtL));
            CvMat matW = new CvMat(9, 9, MatrixType.F64C1, new IntPtr(W));
            CvMat matV = new CvMat(9, 9, MatrixType.F64C1, new IntPtr(V));
            CvMat _H0 = new CvMat(3, 3, MatrixType.F64C1, new IntPtr(V + (9 * 8)));
            CvMat _Htemp = new CvMat(3, 3, MatrixType.F64C1, new IntPtr(V + (9 * 7)));
            CvPoint2D64f cM = new CvPoint2D64f(0, 0),
                cm = new CvPoint2D64f(0, 0),
                sM = new CvPoint2D64f(0, 0),
                sm = new CvPoint2D64f(0, 0);

            for (int i = 0; i < count; i++)
            {
                cm.X += m[i].X; cm.Y += m[i].Y;
                cM.X += M[i].X; cM.Y += M[i].Y;
            }

            cm.X /= count; cm.Y /= count;
            cM.X /= count; cM.Y /= count;

            for (int i = 0; i < count; i++)
            {
                sm.X += Math.Abs(m[i].X - cm.X);
                sm.Y += Math.Abs(m[i].Y - cm.Y);
                sM.X += Math.Abs(M[i].X - cM.X);
                sM.Y += Math.Abs(M[i].Y - cM.Y);
            }

            if (Math.Abs(sm.X) < double.Epsilon || Math.Abs(sm.Y) < double.Epsilon ||
                Math.Abs(sM.X) < double.Epsilon || Math.Abs(sM.Y) < double.Epsilon)
                return 0;
            sm.X = count / sm.X; sm.Y = count / sm.Y;
            sM.X = count / sM.X; sM.Y = count / sM.Y;

            double[] invHnorm = new double[9] { 1.0 / sm.X, 0, cm.X, 0, 1.0 / sm.Y, cm.Y, 0, 0, 1 };
            double[] Hnorm2 = new double[9] { sM.X, 0, -cM.X * sM.X, 0, sM.Y, -cM.Y * sM.Y, 0, 0, 1 };
            CvMat _invHnorm = new CvMat(3, 3, MatrixType.F64C1, invHnorm);
            CvMat _Hnorm2 = new CvMat(3, 3, MatrixType.F64C1, Hnorm2);

            Cv.Zero(_LtL);
            for (int i = 0; i < count; i++)
            {
                double x = (m[i].X - cm.X) * sm.X, y = (m[i].Y - cm.Y) * sm.Y;
                double X = (M[i].X - cM.X) * sM.X, Y = (M[i].Y - cM.Y) * sM.Y;
                double[] Lx = { X, Y, 1, 0, 0, 0, -x * X, -x * Y, -x };
                double[] Ly = { 0, 0, 0, X, Y, 1, -y * X, -y * Y, -y };
                int j, k;
                for (j = 0; j < 9; j++)
                    for (k = j; k < 9; k++)
                        LtL[j * 9 + k] += Lx[j] * Lx[k] + Ly[j] * Ly[k];
            }
            Cv.CompleteSymm(_LtL);

            //cvSVD( &_LtL, &matW, 0, &matV, CV_SVD_MODIFY_A + CV_SVD_V_T );
            Cv.EigenVV(_LtL, matV, matW);
            Cv.MatMul(_invHnorm, _H0, _Htemp);
            Cv.MatMul(_Htemp, _Hnorm2, _H0);
            Cv.ConvertScale(_H0, model, 1.0 / _H0.DataDouble[8]);

            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <param name="model"></param>
        /// <param name="maxIters"></param>
        /// <returns></returns>
        public override unsafe bool Refine(CvMat m1, CvMat m2, CvMat model, int maxIters)
        {
            CvLevMarq solver = new CvLevMarq(8, 0, new CvTermCriteria(maxIters, double.Epsilon));
            int count = m1.Rows * m1.Cols;
            CvPoint2D64f* M = (CvPoint2D64f*)m1.DataByte;
            CvPoint2D64f* m = (CvPoint2D64f*)m2.DataByte;
            CvMat modelPart = new CvMat(solver.Param.Rows, solver.Param.Cols, model.ElemType, model.Data);
            Cv.Copy(modelPart, solver.Param);

            for (; ; )
            {
                CvMat _param = null;
                CvMat _JtJ = null, _JtErr = null;
                double _errNorm = 0;

                if (!solver.UpdateAlt(out _param, out _JtJ, out _JtErr, out _errNorm))
                    break;

                for (int i = 0; i < count; i++)
                {
                    double* h = _param.DataDouble;
                    double Mx = M[i].X, My = M[i].Y;
                    double ww = 1.0 / (h[6] * Mx + h[7] * My + 1.0);
                    double _xi = (h[0] * Mx + h[1] * My + h[2]) * ww;
                    double _yi = (h[3] * Mx + h[4] * My + h[5]) * ww;
                    double[] err = { _xi - m[i].X, _yi - m[i].Y };
                    if (_JtJ != null || _JtErr != null)
                    {
                        double[,] J = new double[2, 8]
                        {
                            { Mx*ww, My*ww, ww, 0, 0, 0, -Mx*ww*_xi, -My*ww*_xi },
                            { 0, 0, 0, Mx*ww, My*ww, ww, -Mx*ww*_yi, -My*ww*_yi }
                        };

                        for (int j = 0; j < 8; j++)
                        {
                            for (int k = j; k < 8; k++)
                                _JtJ.DataDouble[j * 8 + k] += J[0, j] * J[0, k] + J[1, j] * J[1, k];
                            _JtErr.DataDouble[j] += J[0, j] * err[0] + J[1, j] * err[1];
                        }
                    }
                    if (_errNorm != 0)
                        solver.ErrNorm += err[0] * err[0] + err[1] * err[1];
                }
            }

            Cv.Copy(solver.Param, modelPart);
            return true;
        }
        #endregion
    }
}