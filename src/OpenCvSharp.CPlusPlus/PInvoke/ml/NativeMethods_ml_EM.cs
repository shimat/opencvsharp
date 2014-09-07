using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_EM_new(
            int nclusters, int covMatType, CvTermCriteria termCrit);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_EM_delete(IntPtr model);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_EM_clear(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_EM_train(
            IntPtr model, IntPtr samples, IntPtr logLikelihoods, IntPtr labels, 
            IntPtr probs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_EM_trainE(
            IntPtr model, IntPtr samples, IntPtr means0, IntPtr covs0, IntPtr weights0,
            IntPtr logLikelihoods, IntPtr labels, IntPtr probs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_EM_trainM(
            IntPtr model, IntPtr samples, IntPtr probs0, IntPtr logLikelihoods, 
            IntPtr labels, IntPtr probs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_EM_predict(
            IntPtr model, IntPtr sample, IntPtr probs, out Vec2d ret);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ml_EM_isTrained(IntPtr model);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_EM_info(IntPtr model);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_EM_read(IntPtr model, IntPtr fn);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ml_Ptr_EM_obj(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ml_Ptr_EM_delete(IntPtr ptr);

    }
}