using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    public static partial class Cuda
    {
        #region DrawColorDisp
        /// <summary>
        /// Colors a disparity image.
        /// </summary>
        /// <param name="srcDisp">Source disparity image (1-channel).</param>
        /// <param name="dstDisp">Destination colored disparity image (4-channel, CV_8UC4).</param>
        /// <param name="ndisp">Number of disparities.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void DrawColorDisp(OpenCvSharp.Cuda.InputArray srcDisp, OpenCvSharp.Cuda.OutputArray dstDisp, int ndisp, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (srcDisp is null) 
                throw new ArgumentNullException(nameof(srcDisp));
            if (dstDisp is null) 
                throw new ArgumentNullException(nameof(dstDisp));

            srcDisp.ThrowIfDisposed();
            dstDisp.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_drawColorDisp(srcDisp.CvPtr, dstDisp.CvPtr, ndisp, ToPtr(stream)));

            GC.KeepAlive(srcDisp);
            dstDisp.Fix();
         
        }

        #endregion

        #region reprojectImageto3D
                /// <summary>
                /// Reprojects a disparity image to 3D space.
                /// </summary>
                /// <param name="disp">Input single-channel 8-bit or 16-bit signed disparity image.</param>
                /// <param name="xyzw">Output 3- or 4-channel floating-point image of the same size as disp.</param>
                /// <param name="Q">4x4 perspective transformation matrix (CPU Mat or GpuMat).</param>
                /// <param name="dstCn">Output channels. 3 or 4.</param>
                /// <param name="stream">Stream for the asynchronous version.</param>
                public static void ReprojectImageTo3D( OpenCvSharp.Cuda.InputArray disp, OpenCvSharp.Cuda.OutputArray xyzw,  InputArray Q, int dstCn = 4, OpenCvSharp.Cuda.Stream? stream = null)
                {
                    if (disp is null)
                        throw new ArgumentNullException(nameof(disp));
                    if (xyzw is null) 
                        throw new ArgumentNullException(nameof(xyzw));
                    if (Q is null) 
                        throw new ArgumentNullException(nameof(Q));

                    disp.ThrowIfDisposed();
                    Q.ThrowIfDisposed();
                    xyzw.ThrowIfNotReady();

                    NativeMethods.HandleException(
                        NativeMethods.cuda_reprojectImageTo3D(
                            disp.CvPtr, xyzw.CvPtr, Q.CvPtr, dstCn, ToPtr(stream)));

                    GC.KeepAlive(disp);
                    GC.KeepAlive(Q);
                    xyzw.Fix();
         
                }

                #endregion
    }
}
