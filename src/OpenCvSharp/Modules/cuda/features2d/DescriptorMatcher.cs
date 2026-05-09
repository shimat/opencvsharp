using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Cuda;


/// <summary>
/// Abstract base class for matching keypoint descriptors. 
/// </summary>
public class DescriptorMatcher : Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    protected DescriptorMatcher(IntPtr smartPtr, IntPtr rawPtr)
          : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_DescriptorMatcher_delete(p)))
    {
    }

    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.This descriptor matcher supports masking permissible matches of descriptor sets.
    /// </summary>
    public static DescriptorMatcher CreateBFMatcher(NormTypes normType = NormTypes.L2)
    {
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_create((int)normType, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_get(smartPtr, out var rawPtr));

        return new DescriptorMatcher(smartPtr, rawPtr);
    }

    /// <summary>
    /// Adds descriptors to train a descriptor collection. 
    /// If the collection is not empty, the new descriptors are added to existing train descriptors.
    /// </summary>
    public void Add(IEnumerable<GpuMat> descriptors)
    {
        ThrowIfDisposed();
        if (descriptors is null)
            throw new ArgumentNullException(nameof(descriptors));

        var descriptorsArray = descriptors.ToArray();
        if (descriptorsArray.Length == 0)
            return;

        var descriptorsPtrs = descriptorsArray.Select(x => x.CvPtr).ToArray();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_add(RawPtr, descriptorsPtrs, descriptorsPtrs.Length));
        GC.KeepAlive(this);
        GC.KeepAlive(descriptorsArray);
    }

    /// <summary>
    /// Clears the train descriptor collection. 
    /// </summary>
    public void Clear()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.cuda_DescriptorMatcher_clear(RawPtr));
        GC.KeepAlive(this);
    }



    /// <summary>
    /// Returns a constant link to the train descriptor collection. 
    /// </summary>
    public GpuMat[] GetTrainDescriptors()
    {
        ThrowIfDisposed();
        using var matVec = new VectorOfGpuMat();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_getTrainDescriptors(RawPtr, matVec.CvPtr));
        GC.KeepAlive(this);
        return matVec.ToArray();
    }

    /// <summary>
    /// Returns true if the descriptor matcher supports masking permissible matches. 
    /// </summary>
    public virtual bool IsMaskSupported()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.cuda_DescriptorMatcher_isMaskSupported(RawPtr, out int val));
        GC.KeepAlive(this);
        return val != 0;
    }

    /// <summary>
    /// Trains a descriptor matcher. 
    /// </summary>
    public void Train()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.cuda_DescriptorMatcher_train(RawPtr));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Find one best match for each query descriptor (if mask is empty).
    /// </summary>
    /// <param name="queryDescriptors"></param>
    /// <param name="trainDescriptors"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    public DMatch[] Match(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.InputArray trainDescriptors, 
        OpenCvSharp.Cuda.InputArray? mask = null)
    {
        ThrowIfDisposed();
        if (queryDescriptors is null)
            throw new ArgumentNullException(nameof(queryDescriptors));
        if (trainDescriptors is null)
            throw new ArgumentNullException(nameof(trainDescriptors));
        using var matchesVec = new VectorOfDMatch();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_match1(
                RawPtr, queryDescriptors.CvPtr, trainDescriptors.CvPtr,
                matchesVec.CvPtr, Cv2.ToPtr(mask)));
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
        GC.KeepAlive(mask);
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Find k best matches for each query descriptor (in increasing order of distances).
    /// compactResult is used when mask is not empty. If compactResult is false matches
    /// vector will have the same size as queryDescriptors rows. If compactResult is true
    /// matches vector will not contain matches for fully masked out query descriptors.
    /// </summary>
    /// <param name="queryDescriptors"></param>
    /// <param name="trainDescriptors"></param>
    /// <param name="k"></param>
    /// <param name="mask"></param>
    /// <param name="compactResult"></param>
    /// <returns></returns>
    public DMatch[][] KnnMatch(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.InputArray trainDescriptors,
        int k, OpenCvSharp.Cuda.InputArray? mask = null, bool compactResult = false)
    {
        ThrowIfDisposed();
        if (queryDescriptors is null)
            throw new ArgumentNullException(nameof(queryDescriptors));
        if (trainDescriptors is null)
            throw new ArgumentNullException(nameof(trainDescriptors));
        using var matchesVec = new VectorOfVectorDMatch();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_knnMatch1(
                RawPtr, queryDescriptors.CvPtr, trainDescriptors.CvPtr,
                matchesVec.CvPtr, k, Cv2.ToPtr(mask), compactResult ? 1 : 0));
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
        GC.KeepAlive(mask);
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Find best matches for each query descriptor which have distance less than
    /// maxDistance (in increasing order of distances).
    /// </summary>
    /// <param name="queryDescriptors"></param>
    /// <param name="trainDescriptors"></param>
    /// <param name="maxDistance"></param>
    /// <param name="mask"></param>
    /// <param name="compactResult"></param>
    /// <returns></returns>
    public DMatch[][] RadiusMatch(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.InputArray trainDescriptors,
        float maxDistance, OpenCvSharp.Cuda.InputArray? mask = null, bool compactResult = false)
    {
        ThrowIfDisposed();
        if (queryDescriptors is null)
            throw new ArgumentNullException(nameof(queryDescriptors));
        if (trainDescriptors is null)
            throw new ArgumentNullException(nameof(trainDescriptors));

        using var matchesVec = new VectorOfVectorDMatch();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_radiusMatch1(
                RawPtr, queryDescriptors.CvPtr, trainDescriptors.CvPtr,
                matchesVec.CvPtr, maxDistance, Cv2.ToPtr(mask), compactResult ? 1 : 0));
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
        GC.KeepAlive(mask);
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Find one best match for each query descriptor (if mask is empty).
    /// </summary>
    /// <param name="queryDescriptors"></param>
    /// <param name="masks"></param>
    /// <returns></returns>
    public DMatch[] Match(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.InputArray[]? masks = null)
    {
        ThrowIfDisposed();
        if (queryDescriptors is null)
            throw new ArgumentNullException(nameof(queryDescriptors));

        var masksPtrs = Array.Empty<IntPtr>();
        if (masks is not null)
        {
            masksPtrs = masks.Select(x => x.CvPtr).ToArray();
        }

        using var matchesVec = new VectorOfDMatch();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_match2(
                RawPtr, queryDescriptors.CvPtr, matchesVec.CvPtr, masksPtrs, masksPtrs.Length));
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(masks);
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Find k best matches for each query descriptor (in increasing order of distances).
    /// compactResult is used when mask is not empty. If compactResult is false matches
    /// vector will have the same size as queryDescriptors rows. If compactResult is true
    /// matches vector will not contain matches for fully masked out query descriptors.
    /// </summary>
    /// <param name="queryDescriptors"></param>
    /// <param name="k"></param>
    /// <param name="masks"></param>
    /// <param name="compactResult"></param>
    /// <returns></returns>
    public DMatch[][] KnnMatch(OpenCvSharp.Cuda.InputArray queryDescriptors, int k, OpenCvSharp.Cuda.InputArray[]? masks = null, bool compactResult = false)
    {
        ThrowIfDisposed();
        if (queryDescriptors is null)
            throw new ArgumentNullException(nameof(queryDescriptors));

        var masksPtrs = Array.Empty<IntPtr>();
        if (masks is not null)
        {
            masksPtrs = masks.Select(x => x.CvPtr).ToArray();
        }

        using var matchesVec = new VectorOfVectorDMatch();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_knnMatch2(
                RawPtr, queryDescriptors.CvPtr, matchesVec.CvPtr, k,
                masksPtrs, masksPtrs.Length, compactResult ? 1 : 0));
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(masks);
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Find best matches for each query descriptor which have distance less than
    /// maxDistance (in increasing order of distances).
    /// </summary>
    /// <param name="queryDescriptors"></param>
    /// <param name="maxDistance"></param>
    /// <param name="masks"></param>
    /// <param name="compactResult"></param>
    /// <returns></returns>
    public DMatch[][] RadiusMatch(OpenCvSharp.Cuda.InputArray queryDescriptors, float maxDistance, OpenCvSharp.Cuda.InputArray[]? masks = null, bool compactResult = false)
    {
        ThrowIfDisposed();
        if (queryDescriptors is null)
            throw new ArgumentNullException(nameof(queryDescriptors));

        var masksPtrs = Array.Empty<IntPtr>();
        if (masks is not null)
        {
            masksPtrs = masks.Select(x => x.CvPtr).ToArray();
        }

        using var matchesVec = new VectorOfVectorDMatch();
        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_radiusMatch2(
                RawPtr, queryDescriptors.CvPtr, matchesVec.CvPtr, maxDistance,
                masksPtrs, masksPtrs.Length, compactResult ? 1 : 0));
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(masks);
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Finds the best match for each descriptor from a query set (asynchronous version).
    /// </summary>
    public void MatchAsync(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.InputArray trainDescriptors,
        OpenCvSharp.Cuda.OutputArray matches, OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (queryDescriptors == null) throw new ArgumentNullException(nameof(queryDescriptors));
        if (trainDescriptors == null) throw new ArgumentNullException(nameof(trainDescriptors));
        if (matches == null) throw new ArgumentNullException(nameof(matches));
        queryDescriptors.ThrowIfDisposed();
        trainDescriptors.ThrowIfDisposed();
        matches.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_matchAsync1(RawPtr, queryDescriptors.CvPtr, trainDescriptors.CvPtr, matches.CvPtr, mask?.CvPtr ?? IntPtr.Zero, stream?.CvPtr ?? IntPtr.Zero));

        matches.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
    }

    /// <summary>
    /// Finds the best match for each descriptor from a query set (asynchronous version, internal collection).
    /// </summary>
    public void MatchAsync(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.OutputArray matches,
        GpuMat[]? masks = null, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (queryDescriptors == null) throw new ArgumentNullException(nameof(queryDescriptors));
        if (matches == null) throw new ArgumentNullException(nameof(matches));
        queryDescriptors.ThrowIfDisposed();
        matches.ThrowIfNotReady();

        var masksPtrs = Array.Empty<IntPtr>();
        if (masks is not null)
        {
            masksPtrs = masks.Select(x => x.CvPtr).ToArray();
        }

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_matchAsync2(RawPtr, queryDescriptors.CvPtr, matches.CvPtr, masksPtrs, masksPtrs.Length, stream?.CvPtr ?? IntPtr.Zero));

        matches.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        if (masks != null) foreach (var m in masks) GC.KeepAlive(m);
    }
    /// <summary>
    /// Finds the k best matches for each descriptor from a query set (asynchronous version).
    /// </summary>
    public void KnnMatchAsync(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.InputArray trainDescriptors,
        OpenCvSharp.Cuda.OutputArray matches, int k, OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (queryDescriptors == null) throw new ArgumentNullException(nameof(queryDescriptors));
        if (trainDescriptors == null) throw new ArgumentNullException(nameof(trainDescriptors));
        if (matches == null) throw new ArgumentNullException(nameof(matches));
        queryDescriptors.ThrowIfDisposed();
        trainDescriptors.ThrowIfDisposed();
        matches.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_knnMatchAsync1(RawPtr, queryDescriptors.CvPtr, trainDescriptors.CvPtr, matches.CvPtr, k, mask?.CvPtr ?? IntPtr.Zero, stream?.CvPtr?? IntPtr.Zero));

        matches.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
    }

    /// <summary>
    /// Finds the k best matches for each descriptor from a query set (asynchronous version, internal collection).
    /// </summary>
    public void KnnMatchAsync(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.OutputArray matches, int k, GpuMat[]? masks = null, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (queryDescriptors == null) throw new ArgumentNullException(nameof(queryDescriptors));
        if (matches == null) throw new ArgumentNullException(nameof(matches));
        queryDescriptors.ThrowIfDisposed();
        matches.ThrowIfNotReady();

        IntPtr[] masksPtrs = Array.Empty<IntPtr>();
        if (masks is not null)
        {
            masksPtrs = masks.Select(x => x.CvPtr).ToArray();
        }

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_knnMatchAsync2(RawPtr, queryDescriptors.CvPtr, matches.CvPtr, k, masksPtrs, masksPtrs.Length, stream?.CvPtr ?? IntPtr.Zero));

        matches.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        if (masks != null) foreach (var m in masks) GC.KeepAlive(m);
    }

    /// <summary>
    /// Finds the best matches within a specified radius (asynchronous version).
    /// </summary>
    public void RadiusMatchAsync(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.InputArray trainDescriptors, OpenCvSharp.Cuda.OutputArray matches, float maxDistance, OpenCvSharp.Cuda.InputArray? mask = null, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (queryDescriptors == null) throw new ArgumentNullException(nameof(queryDescriptors));
        if (trainDescriptors == null) throw new ArgumentNullException(nameof(trainDescriptors));
        if (matches == null) throw new ArgumentNullException(nameof(matches));
        queryDescriptors.ThrowIfDisposed();
        trainDescriptors.ThrowIfDisposed();
        matches.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_radiusMatchAsync1(RawPtr, queryDescriptors.CvPtr, trainDescriptors.CvPtr, matches.CvPtr, maxDistance, mask?.CvPtr ?? IntPtr.Zero, stream?.CvPtr ?? IntPtr.Zero));

        matches.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        GC.KeepAlive(trainDescriptors);
    }

    /// <summary>
    /// Finds the best matches within a specified radius (asynchronous version, internal collection).
    /// </summary>
    public void RadiusMatchAsync(OpenCvSharp.Cuda.InputArray queryDescriptors, OpenCvSharp.Cuda.OutputArray matches, float maxDistance, GpuMat[]? masks = null, OpenCvSharp.Cuda.Stream? stream = null)
    {
        if (queryDescriptors == null) throw new ArgumentNullException(nameof(queryDescriptors));
        if (matches == null) throw new ArgumentNullException(nameof(matches));
        queryDescriptors.ThrowIfDisposed();
        matches.ThrowIfNotReady();

        var masksPtrs = Array.Empty<IntPtr>();
        if (masks is not null)
        {
            masksPtrs = masks.Select(x => x.CvPtr).ToArray();
        }

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_radiusMatchAsync2(RawPtr, queryDescriptors.CvPtr, matches.CvPtr, maxDistance, masksPtrs, masksPtrs.Length, stream?.CvPtr ?? IntPtr.Zero));

        matches.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(queryDescriptors);
        if (masks != null) foreach (var m in masks) GC.KeepAlive(m);
    }

    /// <summary>
    /// Converts matches array from internal GPU representation to standard matches vector.
    /// </summary>
    /// <param name="gpuMatches">The raw matches buffer returned by MatchAsync.</param>
    /// <returns>An array of DMatch objects.</returns>
    public DMatch[] MatchConvert(OpenCvSharp.Cuda.InputArray gpuMatches)
    {
        if (gpuMatches == null) throw new ArgumentNullException(nameof(gpuMatches));
        gpuMatches.ThrowIfDisposed();
        ThrowIfDisposed();

        // VectorOfDMatch maps to std::vector<cv::DMatch>
        using var matchesVec = new VectorOfDMatch();

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_matchConvert(RawPtr, gpuMatches.CvPtr, matchesVec.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(gpuMatches);

        // Automatically converts the C++ vector to C# DMatch[]
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Converts matches array from internal GPU representation to standard matches vector.
    /// </summary>
    /// <param name="gpuMatches">The raw matches buffer returned by KnnMatchAsync.</param>
    /// <param name="compactResult">If true, removes empty matches from the result.</param>
    /// <returns>A jagged array of DMatch objects.</returns>
    public DMatch[][] KnnMatchConvert(OpenCvSharp.Cuda.InputArray gpuMatches, bool compactResult = false)
    {
        if (gpuMatches == null) throw new ArgumentNullException(nameof(gpuMatches));
        gpuMatches.ThrowIfDisposed();
        ThrowIfDisposed();

        using var matchesVec = new VectorOfVectorDMatch();

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_knnMatchConvert(RawPtr, gpuMatches.CvPtr, matchesVec.CvPtr, compactResult ? 1 : 0));

        GC.KeepAlive(this);
        GC.KeepAlive(gpuMatches);

        // Automatically converts the C++ nested vector to C# DMatch[][]
        return matchesVec.ToArray();
    }

    /// <summary>
    /// Converts matches array from internal GPU representation to standard matches vector.
    /// </summary>
    /// <param name="gpuMatches">The raw matches buffer returned by RadiusMatchAsync.</param>
    /// <param name="compactResult">If true, removes empty matches from the result.</param>
    /// <returns>A jagged array of DMatch objects.</returns>
    public DMatch[][] RadiusMatchConvert(OpenCvSharp.Cuda.InputArray gpuMatches, bool compactResult = false)
    {
        if (gpuMatches == null) throw new ArgumentNullException(nameof(gpuMatches));
        gpuMatches.ThrowIfDisposed();
        ThrowIfDisposed();

        using var matchesVec = new VectorOfVectorDMatch();

        NativeMethods.HandleException(
            NativeMethods.cuda_DescriptorMatcher_radiusMatchConvert(RawPtr, gpuMatches.CvPtr, matchesVec.CvPtr, compactResult ? 1 : 0));

        GC.KeepAlive(this);
        GC.KeepAlive(gpuMatches);

        return matchesVec.ToArray();
    }
}

