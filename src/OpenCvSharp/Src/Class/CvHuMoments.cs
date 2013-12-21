/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    /// <summary>
    /// Hu moments
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class CvHuMoments
    {
        public double Hu1, Hu2, Hu3, Hu4, Hu5, Hu6, Hu7; /* Hu invariants */

        /// <summary>
        /// Default constructor
        /// </summary>
        public CvHuMoments()
        {
            Hu1 = Hu2 = Hu3 = Hu4 = Hu5 = Hu6 = Hu7 = default(double);
        }

#if LANG_JP
        /// <summary>
        /// cvGetHuMomentsにより初期化
        /// </summary>
        /// <param name="moments">画像モーメント構造体への参照</param>
#else
        /// <summary>
        /// Initialize by cvGetHuMoments
        /// </summary>
        /// <param name="moments">Pointer to the moment state structure. </param>
#endif
        public CvHuMoments(CvMoments moments)
        {
            if (moments == null)
            {
                throw new ArgumentNullException("moments");
            }
            CvInvoke.cvGetHuMoments(moments, this);
        }
    }
}
