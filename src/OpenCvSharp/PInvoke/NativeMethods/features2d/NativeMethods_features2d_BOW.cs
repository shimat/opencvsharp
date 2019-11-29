using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        // BOWTrainer

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWTrainer_add(IntPtr obj, IntPtr descriptors);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWTrainer_getDescriptors(IntPtr obj, IntPtr descriptors);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_BOWTrainer_descriptorsCount(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWTrainer_clear(IntPtr obj);


        // BOWKMeansTrainer

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWKMeansTrainer_new(
            int clusterCount, TermCriteria termcrit, int attempts, int flags);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWKMeansTrainer_delete(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWKMeansTrainer_cluster1(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWKMeansTrainer_cluster2(IntPtr obj, IntPtr descriptors);


        // BOWImgDescriptorExtractor

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWImgDescriptorExtractor_new1_Ptr(IntPtr dextractor, IntPtr dmatcher);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWImgDescriptorExtractor_new2_Ptr(IntPtr dmatcher);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWImgDescriptorExtractor_new1_RawPtr(IntPtr dextractor, IntPtr dmatcher);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWImgDescriptorExtractor_new2_RawPtr(IntPtr dmatcher);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWImgDescriptorExtractor_delete(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWImgDescriptorExtractor_setVocabulary(IntPtr obj, IntPtr vocabulary);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BOWImgDescriptorExtractor_getVocabulary(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWImgDescriptorExtractor_compute11(
            IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr imgDescriptor,
            IntPtr pointIdxsOfClusters, IntPtr descriptors);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWImgDescriptorExtractor_compute12(
            IntPtr obj, IntPtr keypointDescriptors,
            IntPtr imgDescriptor, IntPtr pointIdxsOfClusters);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BOWImgDescriptorExtractor_compute2(
            IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr imgDescriptor);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_BOWImgDescriptorExtractor_descriptorSize(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_BOWImgDescriptorExtractor_descriptorType(IntPtr obj);
    }
}
