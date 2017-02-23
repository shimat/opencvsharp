using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region Algorithm

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_Algorithm_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_Algorithm_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void core_Algorithm_name(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_Ptr_Algorithm_new(IntPtr rawPtr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_Ptr_Algorithm_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_Ptr_Algorithm_get(IntPtr ptr);

        #endregion

        #region InputArray / OutputArray
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byMatExpr(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byScalar(Scalar val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byDouble(double val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byGpuMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byVectorOfMat(IntPtr vector);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_delete(IntPtr ia);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_OutputArray_new_byMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_OutputArray_new_byGpuMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_OutputArray_new_byScalar(Scalar val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_OutputArray_new_byVectorOfMat(IntPtr vector);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_OutputArray_delete(IntPtr oa);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_kind(IntPtr ia);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_OutputArray_getMat(IntPtr oa);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Scalar core_OutputArray_getScalar(IntPtr oa);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_OutputArray_getVectorOfMat(IntPtr oa, IntPtr vector);
        
        #endregion

        #region FileStorage

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_new2(
            [MarshalAs(UnmanagedType.LPStr)] string source, 
            int flags, [MarshalAs(UnmanagedType.LPStr)] string encoding);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_newFromLegacy(IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileStorage_open(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, 
            int flags, [MarshalAs(UnmanagedType.LPStr)] string encoding);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileStorage_isOpened(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_release(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_releaseAndGetString(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_getFirstTopLevelNode(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_root(IntPtr obj, int streamIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_indexer(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string nodeName);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_toLegacy(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeRaw(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr vec, IntPtr len);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeObj(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_getDefaultObjectName(
            [MarshalAs(UnmanagedType.LPStr)] string filename, 
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe sbyte* core_FileStorage_elname(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_structs(IntPtr obj, out IntPtr resultLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileStorage_state(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_int(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_float(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_double(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_String(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_Mat(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_SparseMat(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_vectorOfKeyPoint(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_vectorOfDMatch(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_int(IntPtr fs, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_float(IntPtr fs, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_double(IntPtr fs, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_String(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string value);

        #endregion

        #region FileNode

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileNode_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileNode_new2(IntPtr fs, IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileNode_new3(IntPtr node);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_delete(IntPtr node);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileNode_operatorThis_byString(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string nodeName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileNode_operatorThis_byInt(IntPtr obj, int i);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_type(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_isNone(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_isSeq(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_isMap(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_isInt(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_isReal(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_isString(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_isNamed(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_name(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileNode_size(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileNode_toInt(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float core_FileNode_toFloat(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double core_FileNode_toDouble(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_toString(
            IntPtr obj, StringBuilder buf, int bufLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_toMat(IntPtr obj, IntPtr m);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_readRaw(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr vec, IntPtr len);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileNode_readObj(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_int(IntPtr node, out int value, int defaultValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_float(IntPtr node, out float value, float defaultValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_double(IntPtr node, out double value, double defaultValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_String(
            IntPtr node, [MarshalAs(UnmanagedType.LPStr)] StringBuilder value, int valueCapacity,
            [MarshalAs(UnmanagedType.LPStr)] string defaultValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_Mat(IntPtr node, IntPtr mat, IntPtr defaultMat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_SparseMat(IntPtr node, IntPtr mat, IntPtr defaultMat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_vectorOfKeyPoint(IntPtr node, IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileNode_read_vectorOfDMatch(IntPtr node, IntPtr matches);

        #endregion

        #region PCA
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_new2(IntPtr data, IntPtr mean, int flags,
            int maxComponents);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_new3(IntPtr data, IntPtr mean, int flags,
            double retainedVariance);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_operatorThis(IntPtr obj, IntPtr data, IntPtr mean,
            int flags, int maxComponents);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_computeVar(IntPtr obj, IntPtr data, IntPtr mean,
            int flags, double retainedVariance);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_project1(IntPtr obj, IntPtr vec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_project2(IntPtr obj, IntPtr vec, IntPtr result);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_backProject1(IntPtr obj, IntPtr vec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_backProject2(IntPtr obj, IntPtr vec, IntPtr result);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_eigenvectors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_eigenvalues(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_mean(IntPtr obj);
        #endregion

        #region RNG
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_RNG_fill(ref ulong state, IntPtr mat, int distType, IntPtr a, IntPtr b, int saturateRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double core_RNG_gaussian(ref ulong state, double sigma);
        #endregion

        #region SVD
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_new2(IntPtr src, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_operatorThis(IntPtr obj, IntPtr src, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_backSubst(IntPtr obj, IntPtr rhs, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_compute1(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_compute2(IntPtr src, IntPtr w, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_backSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_solveZ(IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_u(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_w(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_vt(IntPtr obj);
        #endregion
    }
}