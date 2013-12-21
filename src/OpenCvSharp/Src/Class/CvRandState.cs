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
    /// <summary>
    /// CvRandState
    /// </summary>
    /// <remarks>
    /// typedef struct CvRandState
    /// {
    ///     CvRNG     _state;    /* RNG state (the current seed and carry)*/
    ///     int       _disttype; /* distribution type */
    ///     CvScalar  _param[2]; /* parameters of RNG */
    /// }
    /// CvRandState;
    /// </remarks>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class CvRandState
    {
        #region Fields
        private UInt64 _state;
        private int _disttype;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        private CvScalar[] _param;
        #endregion

        #region Properties
        /// <summary>
        /// RNG _state (the current seed and carry)
        /// </summary>
        public CvRNG State
        {
            get { return new CvRNG() { Seed = _state }; }
            set { _state = value.Seed; }
        }
        /// <summary>
        /// distribution type
        /// </summary>
        public DistributionType DistType
        {
            get { return (DistributionType)_disttype; }
            set { _disttype = (int)value; }
        }
        /// <summary>
        /// parameters of RNG
        /// </summary>
        public CvScalar[] Param
        {
            get { return _param; }
        }
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public CvRandState()
        {
            this._disttype = default(int);
            this._param = new CvScalar[2];
            this._state = default(ulong);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
#endif
        public CvRandState(double param1, double param2, int seed)
            : this()
        {
            Cv.RandInit(this, param1, param2, seed);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
        /// <param name="disttype"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
        /// <param name="disttype"></param>
#endif
        public CvRandState(double param1, double param2, int seed, DistributionType disttype)
            : this()
        {
            Cv.RandInit(this, param1, param2, seed, disttype);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvRandState(IntPtr ptr)
        {
            if (ptr == null)
            {
                throw new ArgumentNullException("ptr");
            }
            CvRandState s = (CvRandState)Marshal.PtrToStructure(ptr, typeof(CvRandState));
            this._disttype = s._disttype;
            this._param = s._param;
            this._state = s._state;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        internal void Set(CvRandState value)
        {
            this._disttype = value._disttype;
            this._param = value._param;
            this._state = value._state;
        }

        #region Methods
        #region Rand
#if LANG_JP
        /// <summary>
        /// 配列をランダムな値で埋める
        /// </summary>
        /// <param name="arr"></param>
#else
        /// <summary>
        /// Fills array with random numbers
        /// </summary>
        /// <param name="arr">The array to randomize</param>
#endif
        public void Rand(CvArr arr)
        {
            Cv.Rand(this, arr);
        }
        #endregion
        #region RandInit
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
#else
        /// <summary>
        /// Initialize CvRandState structure
        /// </summary>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
        /// <param name="seed">Seed value</param>
#endif
        public void RandInit(double param1, double param2, int seed)
        {
            Cv.RandInit(this, param1, param2, seed);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="seed"></param>
        /// <param name="disttype"></param>
#else
        /// <summary>
        /// Initialize CvRandState structure
        /// </summary>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
        /// <param name="seed">Seed value</param>
        /// <param name="disttype">Type of distribution</param>
#endif
        public void RandInit(double param1, double param2, int seed, DistributionType disttype)
        {
            Cv.RandInit(this, param1, param2, seed, disttype);
        }
        #endregion
        #region RandSetRange
#if LANG_JP
        /// <summary>
        /// Changes RNG range while preserving RNG state
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
#else
        /// <summary>
        /// Changes RNG range while preserving RNG _state
        /// </summary>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
#endif
        public void RandSetRange(double param1, double param2)
        {
            Cv.RandSetRange(this, param1, param2);
        }
#if LANG_JP
        /// <summary>
        /// Changes RNG range while preserving RNG state
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="index"></param>
#else
        /// <summary>
        /// Changes RNG range while preserving RNG _state
        /// </summary>
        /// <param name="param1">The first parameter of distribution. In case of uniform distribution it is the inclusive lower boundary of random numbers range. In case of normal distribution it is the mean value of random numbers. </param>
        /// <param name="param2">The second parameter of distribution. In case of uniform distribution it is the exclusive upper boundary of random numbers range. In case of normal distribution it is the standard deviation of random numbers. </param>
        /// <param name="index">Index dimension to initialize, -1 = all</param>
#endif
        public void RandSetRange(double param1, double param2, int index)
        {
            Cv.RandSetRange(this, param1, param2, index);
        }
        #endregion
        #endregion
    }
}
