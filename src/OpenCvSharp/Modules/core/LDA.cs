using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

/// <inheritdoc />
/// <summary>
/// Linear Discriminant Analysis
/// </summary>
// ReSharper disable once InconsistentNaming
public class LDA : CvObject
{
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="numComponents"></param>
    public LDA(int numComponents = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_LDA_new1(numComponents, out var p));
        InitSafeHandle(p);
    }

    /// <summary>
    /// Initializes and performs a Discriminant Analysis with Fisher's 
    /// Optimization Criterion on given data in src and corresponding labels 
    /// in labels.If 0 (or less) number of components are given, they are 
    /// automatically determined for given data in computation.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="labels"></param>
    /// <param name="numComponents"></param>
    public LDA(InputArray src, InputArray labels, int numComponents = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_LDA_new2(src.Proxy, labels.Proxy, numComponents, out var p));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(labels.Source);
        InitSafeHandle(p);
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.core_LDA_delete(h))));
    }

    /// <summary>
    /// Returns the eigenvectors of this LDA.
    /// </summary>
    public Mat Eigenvectors()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_LDA_eigenvectors(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the eigenvalues of this LDA.
    /// </summary>
    public Mat Eigenvalues()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_LDA_eigenvalues(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Serializes this object to a given filename.
    /// </summary>
    /// <param name="fileName"></param>
    public void Save(string fileName)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fileName);
        NativeMethods.HandleException(
            NativeMethods.core_LDA_save_String(Handle, fileName));
    }

    /// <summary>
    /// Deserializes this object from a given filename.
    /// </summary>
    /// <param name="fileName"></param>
    public void Load(string fileName)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fileName);
        NativeMethods.HandleException(
            NativeMethods.core_LDA_load_String(Handle, fileName));
    }

    /// <summary>
    /// Serializes this object to a given cv::FileStorage.
    /// </summary>
    /// <param name="fs"></param>
    public void Save(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);
        fs.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_LDA_save_FileStorage(Handle, fs.CvPtr));
            
        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Deserializes this object from a given cv::FileStorage.
    /// </summary>
    /// <param name="node"></param>
    public void Load(FileStorage node)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(node);
        node.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_LDA_load_FileStorage(Handle, node.CvPtr));

        GC.KeepAlive(node);
    }

    /// <summary>
    /// Compute the discriminants for data in src (row aligned) and labels.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="labels"></param>
    public void Compute(InputArray src, InputArray labels)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_LDA_compute(Handle, src.Proxy, labels.Proxy));

        GC.KeepAlive(src.Source);
        GC.KeepAlive(labels.Source);
    }

    /// <summary>
    /// Projects samples into the LDA subspace.
    /// src may be one or more row aligned samples.
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public Mat Project(InputArray src)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_LDA_project(Handle, src.Proxy, out var ret));

        GC.KeepAlive(src.Source);

        return new Mat(ret);
    }

    /// <summary>
    /// Reconstructs projections from the LDA subspace.
    /// src may be one or more row aligned projections.
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public Mat Reconstruct(InputArray src)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_LDA_reconstruct(Handle, src.Proxy, out var ret));

        GC.KeepAlive(src.Source);

        return new Mat(ret);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="w"></param>
    /// <param name="mean"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Mat SubspaceProject(InputArray w, InputArray mean, InputArray src)
    {
        NativeMethods.HandleException(
            NativeMethods.core_LDA_subspaceProject(w.Proxy, mean.Proxy, src.Proxy, out var ret));

        GC.KeepAlive(w.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(src.Source);

        return new Mat(ret);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="w"></param>
    /// <param name="mean"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Mat SubspaceReconstruct(InputArray w, InputArray mean, InputArray src)
    {
        NativeMethods.HandleException(
            NativeMethods.core_LDA_subspaceReconstruct(w.Proxy, mean.Proxy, src.Proxy, out var ret));

        GC.KeepAlive(w.Source);
        GC.KeepAlive(mean.Source);
        GC.KeepAlive(src.Source);

        return new Mat(ret);
    }
}
