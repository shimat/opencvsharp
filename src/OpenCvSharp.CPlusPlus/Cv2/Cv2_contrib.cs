using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    static partial class Cv2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool InitModule_Contrib()
        {
            return NativeMethods.contrib_initModule_contrib() != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="templ"></param>
        /// <param name="results"></param>
        /// <param name="cost"></param>
        /// <param name="templScale"></param>
        /// <param name="maxMatches"></param>
        /// <param name="minMatchDistance"></param>
        /// <param name="padX"></param>
        /// <param name="padY"></param>
        /// <param name="scales"></param>
        /// <param name="minScale"></param>
        /// <param name="maxScale"></param>
        /// <param name="orientationWeight"></param>
        /// <param name="truncate"></param>
        /// <returns></returns>
        public static int ChamferMatching(
            Mat img, Mat templ,
                                  out Point[][] results, out float[] cost,
                                  double templScale=1, int maxMatches = 20,
                                  double minMatchDistance = 1.0, int padX = 3,
                                  int padY = 3, int scales = 5, double minScale = 0.6, double maxScale = 1.6,
                                  double orientationWeight = 0.5, double truncate = 20)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (templ == null)
                throw new ArgumentNullException("templ");
            img.ThrowIfDisposed();
            templ.ThrowIfDisposed();
            
            using (var resultsVec = new VectorOfVectorPoint())
            using (var costVec = new VectorOfFloat())
            {
                int ret = NativeMethods.contrib_chamerMatching(
                    img.CvPtr, templ.CvPtr, resultsVec.CvPtr, costVec.CvPtr, 
                    templScale, maxMatches, minMatchDistance,
                    padX, padY, scales, minScale, maxScale, orientationWeight, truncate);
                GC.KeepAlive(img);
                GC.KeepAlive(templ);

                results = resultsVec.ToArray();
                cost = costVec.ToArray();

                return ret;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="colormap"></param>
        public static void ApplyColorMap(InputArray src, OutputArray dst, ColorMapMode colormap)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.contrib_applyColorMap(src.CvPtr, dst.CvPtr, (int)colormap);
            dst.Fix();
            GC.KeepAlive(src);
        }
    }
}
