/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public enum LevMarqState : int
    {
        Done = 0, 
        Started = 1, 
        CalcJ = 2, 
        CheckErr = 3
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
    public class CvLevMarq : DisposableObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;

        #region Init and Disposal
        public CvLevMarq()
        {
            Mask = PrevParam = Param = J = Err = JtJ = JtJN = JtErr = JtJV = JtJW = null;
            LambdaLg10 = 0; 
            State = LevMarqState.Done;
            Criteria = new CvTermCriteria(0, 0);
            Iters = 0;
            CompleteSymmFlag = false;
        }
        public CvLevMarq(int nparams, int nerrs)
            : this(nparams, nerrs, new CvTermCriteria(30, double.Epsilon), false)
        {
        }
        public CvLevMarq(int nparams, int nerrs, CvTermCriteria criteria)
            : this(nparams, nerrs, criteria, false)
        {
        }
        public CvLevMarq(int nparams, int nerrs, CvTermCriteria criteria, bool completeSymmFlag)
        {
            Mask = PrevParam = Param = J = Err = JtJ = JtJN = JtErr = JtJV = JtJW = null;
            Init(nparams, nerrs, criteria, completeSymmFlag);
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
                        Clear();
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

        #region Properties
        public CvMat Mask;
        public CvMat PrevParam;
        public CvMat Param;
        public CvMat J;
        public CvMat Err;
        public CvMat JtJ;
        public CvMat JtJN;
        public CvMat JtErr;
        public CvMat JtJV;
        public CvMat JtJW;
        public double PrevErrNorm, ErrNorm;
        public int LambdaLg10;
        public CvTermCriteria Criteria;
        public LevMarqState State;
        public int Iters;
        public bool CompleteSymmFlag;
        #endregion

        #region Methods
        public void Init(int nparams, int nerrs)
        {
            Init(nparams, nerrs, new CvTermCriteria(30, double.Epsilon), false);
        }
        public void Init(int nparams, int nerrs, CvTermCriteria criteria)
        {
            Init(nparams, nerrs, criteria, false);
        }
        public void Init(int nparams, int nerrs, CvTermCriteria criteria, bool completeSymmFlag)
        {
            if (Param != null || /*Param.Rows != nparams ||*/ nerrs != ((Err != null) ? Err.Rows : 0))
                Clear();

            Mask = new CvMat(nparams, 1, MatrixType.U8C1);
            Cv.Set(Mask, CvScalar.ScalarAll(1));
            PrevParam = new CvMat(nparams, 1, MatrixType.F64C1);
            Param = new CvMat(nparams, 1, MatrixType.F64C1);
            JtJ = new CvMat(nparams, nparams, MatrixType.F64C1);
            JtJN = new CvMat(nparams, nparams, MatrixType.F64C1);
            JtJV = new CvMat(nparams, nparams, MatrixType.F64C1);
            JtJW = new CvMat(nparams, 1, MatrixType.F64C1);
            JtErr = new CvMat(nparams, 1, MatrixType.F64C1);
            if (nerrs > 0)
            {
                J = new CvMat(nerrs, nparams, MatrixType.F64C1);
                Err = new CvMat(nerrs, 1, MatrixType.F64C1);
            }
            PrevErrNorm = double.MaxValue;
            LambdaLg10 = -3;
            Criteria = criteria;
            if ((criteria.Type & CriteriaType.Iteration) == CriteriaType.Iteration)
                criteria.MaxIter = Math.Min(Math.Max(criteria.MaxIter, 1), 1000);
            else
                criteria.MaxIter = 30;
            if ((criteria.Type & CriteriaType.Epsilon) == CriteriaType.Epsilon)
                criteria.Epsilon = Math.Max(criteria.Epsilon, 0);
            else
                criteria.Epsilon = double.Epsilon;
            State = LevMarqState.Started;
            Iters = 0;
            CompleteSymmFlag = completeSymmFlag;
        }


        public bool Update(out CvMat param, out CvMat matJ, out CvMat err)
        {
            double change;

            matJ = err = null;

            if (State == LevMarqState.Done)
            {
                param = Param;
                return false;
            }

            if (State == LevMarqState.Started)
            {
                param = Param;
                Cv.Zero(J);
                Cv.Zero(Err);
                matJ = J;
                err = Err;
                State = LevMarqState.CalcJ;
                return true;
            }

            if (State == LevMarqState.CalcJ)
            {
                Cv.MulTransposed(J, JtJ, true);
                Cv.GEMM(J, Err, 1, null, 0, JtErr, GemmOperation.A_T);
                Cv.Copy(Param, PrevParam);
                Step();
                if (Iters == 0)
                    PrevErrNorm = Cv.Norm(Err, null, NormType.L2);
                param = Param;
                Cv.Zero(Err);
                err = Err;
                State = LevMarqState.CheckErr;
                return true;
            }

            if (State != LevMarqState.CheckErr)
            {
                throw new OpenCvSharpException();
            }
            ErrNorm = Cv.Norm(Err, null, NormType.L2);
            if (ErrNorm > PrevErrNorm)
            {
                LambdaLg10++;
                Step();
                param = Param;
                Cv.Zero(Err);
                err = Err;
                State = LevMarqState.CalcJ;
                return true;
            }

            LambdaLg10 = Math.Max(LambdaLg10 - 1, -16);
            if (++Iters >= Criteria.MaxIter ||
                (change = Cv.Norm(Param, PrevParam, NormType.RelativeL2)) < Criteria.Epsilon)
            {
                param = Param;
                State = LevMarqState.Done;
                return true;
            }

            PrevErrNorm = ErrNorm;
            param = Param;
            Cv.Zero(J);
            matJ = J;
            err = Err;
            State = LevMarqState.CalcJ;
            return true;
        }


        public unsafe bool UpdateAlt(out CvMat _param, out CvMat _JtJ, out CvMat _JtErr, out double _errNorm)
        {
            _JtJ = null;
            _JtErr = null;
            _errNorm = 0;

            double change;

            if (State == LevMarqState.Done)
            {
                _param = Param;
                return false;
            }

            if (State == LevMarqState.Started)
            {
                _param = Param;
                Cv.Zero(JtJ);
                Cv.Zero(JtErr);
                _errNorm = 0;
                _JtJ = JtJ;
                _JtErr = JtErr;
                _errNorm = ErrNorm;
                State = LevMarqState.CalcJ;
                return true;
            }

            if (State == LevMarqState.CalcJ)
            {
                Cv.Copy(Param, PrevParam);
                Step();
                _param = Param;
                PrevErrNorm = ErrNorm;
                ErrNorm = 0;
                _errNorm = ErrNorm;
                State = LevMarqState.CheckErr;
                return true;
            }

            Debug.Assert(State == LevMarqState.CheckErr);
            if (ErrNorm > PrevErrNorm)
            {
                LambdaLg10++;
                Step();
                _param = Param;
                ErrNorm = 0;
                _errNorm = ErrNorm;
                State = LevMarqState.CheckErr;
                return true;
            }

            LambdaLg10 = Math.Max(LambdaLg10 - 1, -16);
            if (++Iters >= Criteria.MaxIter ||
                (change = Cv.Norm(Param, PrevParam, NormType.RelativeL2)) < Criteria.Epsilon)
            {
                _param = Param;
                State = LevMarqState.Done;
                return false;
            }

            PrevErrNorm = ErrNorm;
            Cv.Zero(JtJ);
            Cv.Zero(JtErr);
            _param = Param;
            _JtJ = JtJ;
            _JtErr = JtErr;
            State = LevMarqState.CalcJ;
            return true;
        }


        public void Clear()
        {
            if (Mask != null)
            {
                Mask.Dispose(); Mask = null;
            }
            if (PrevParam != null)
            {
                PrevParam.Dispose(); PrevParam = null;
            }
            if (Param != null)
            {
                Param.Dispose(); Param = null;
            }
            if (J != null)
            {
                J.Dispose(); J = null;
            }
            if (Err != null)
            {
                Err.Dispose(); Err = null;
            }
            if (JtJ != null)
            {
                JtJ.Dispose(); JtJ = null;
            }
            if (JtJN != null)
            {
                JtJN.Dispose(); JtJN = null;
            }
            if (JtErr != null)
            {
                JtErr.Dispose(); JtErr = null;
            }
            if (JtJV != null)
            {
                JtJV.Dispose(); JtJV = null;
            }
            if (JtJW != null)
            {
                JtJW.Dispose(); JtJW = null;
            }
        }


        public void Step()
        {
            double LOG10 = Math.Log(10.0);
            double lambda = Math.Exp(LambdaLg10 * LOG10);
            int nparams = Param.Rows;

            unsafe
            {
                for (int i = 0; i < nparams; i++)
                    if (Mask.DataByte[i] == 0)
                    {
                        double* row = JtJ.DataDouble + i * nparams;
                        double* col = JtJ.DataDouble + i;
                        for (int j = 0; j < nparams; j++)
                            row[j] = col[j * nparams] = 0;
                        JtErr.DataDouble[i] = 0;
                    }

                if (Err == null)
                    Cv.CompleteSymm(JtJ, CompleteSymmFlag);

                Cv.Copy(JtJ, JtJN);
                for (int i = 0; i < nparams; i++)
                    JtJN.DataDouble[(nparams + 1) * i] *= 1.0 + lambda;

                Cv.SVD(JtJN, JtJW, null, JtJV, SVDFlag.ModifyA | SVDFlag.U_T | SVDFlag.V_T);
                Cv.SVBkSb(JtJW, JtJV, JtJV, JtErr, Param, SVDFlag.U_T | SVDFlag.V_T);
                for (int i = 0; i < nparams; i++)
                    Param.DataDouble[i] = PrevParam.DataDouble[i] - ((Mask.DataByte[i] != 0) ? Param.DataDouble[i] : 0);
            }
        }
        #endregion
    }
}