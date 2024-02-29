using OpenCvSharp.Internal;

namespace OpenCvSharp.Aruco;

/// <summary>
/// Dictionary/Set of markers. It contains the inner codification
/// </summary>
public class Dictionary : DisposableCvObject
{
    /// <summary>
    /// 
    /// </summary>
    internal Dictionary(IntPtr ptr)
    {
        this.ptr = ptr;
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        if (ptr != IntPtr.Zero && IsEnabledDispose)
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_delete(ptr));
        base.DisposeUnmanaged();
    }
    
    /// <summary>
    /// Marker code information
    /// </summary>
    public Mat BytesList
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_getBytesList(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret);
        }
    }

    /// <summary>
    /// Number of bits per dimension.
    /// </summary>
    public int MarkerSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_getMarkerSize(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_setMarkerSize(ptr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Maximum number of bits that can be corrected.
    /// </summary>
    public int MaxCorrectionBits
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_getMaxCorrectionBits(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_setMaxCorrectionBits(ptr, value));
            GC.KeepAlive(this);
        }
    }
    
    /// <summary>
    /// Given a matrix of bits. Returns whether if marker is identified or not.
    /// It returns by reference the correct id (if any) and the correct rotation
    /// </summary>
    /// <param name="onlyBits"></param>
    /// <param name="idx"></param>
    /// <param name="rotation"></param>
    /// <param name="maxCorrectionRate"></param>
    /// <returns></returns>
    public bool Identify(Mat onlyBits, out int idx, out int rotation, double maxCorrectionRate)
    {
        if (onlyBits is null)
            throw new ArgumentNullException(nameof(onlyBits));
        onlyBits.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_identify(ptr, onlyBits.CvPtr, out idx, out rotation, maxCorrectionRate, out var ret));
        
        GC.KeepAlive(this);
        return ret != 0;
    }
    
    /// <summary>
    /// Returns the distance of the input bits to the specific id.
    /// If allRotations is true, the four possible bits rotation are considered
    /// </summary>
    /// <param name="bits"></param>
    /// <param name="id"></param>
    /// <param name="allRotations"></param>
    /// <returns></returns>
    public int GetDistanceToId(InputArray bits, int id, bool allRotations = true)
    {
        if (bits is null)
            throw new ArgumentNullException(nameof(bits));
        bits.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_getDistanceToId(ptr, bits.CvPtr, id, allRotations ? 1 : 0, out var ret));
        
        GC.KeepAlive(this);
        return ret;
    }
    
    /// <summary>
    /// Generate a canonical marker image
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sidePixels"></param>
    /// <param name="img"></param>
    /// <param name="borderBits"></param>
    public void GenerateImageMarker(int id, int sidePixels, OutputArray img, int borderBits = 1)
    {
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        img.ThrowIfNotReady();
        ThrowIfDisposed();
        
        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_generateImageMarker(ptr, id, sidePixels, img.CvPtr, borderBits));
        
        GC.KeepAlive(this);
    }
    
    /// <summary>
    /// Transform matrix of bits to list of bytes in the 4 rotations
    /// </summary>
    /// <param name="bits"></param>
    /// <returns></returns>
    public static Mat GetByteListFromBits(Mat bits)
    {
        if (bits is null)
            throw new ArgumentNullException(nameof(bits));
        bits.ThrowIfDisposed();

        var ret = new Mat();
        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_getByteListFromBits(bits.CvPtr, ret.CvPtr));
        return ret;
    }
    
    /// <summary>
    /// Transform list of bytes to matrix of bits
    /// </summary>
    /// <param name="byteList"></param>
    /// <param name="markerSize"></param>
    /// <returns></returns>
    public static Mat GetBitsFromByteList(Mat byteList, int markerSize)
    {
        if (byteList is null)
            throw new ArgumentNullException(nameof(byteList));
        byteList.ThrowIfDisposed();
        
        var ret = new Mat();
        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_getBitsFromByteList(byteList.CvPtr, markerSize, ret.CvPtr));
        return ret;
    }
}
