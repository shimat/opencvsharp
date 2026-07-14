using OpenCvSharp.Internal;

namespace OpenCvSharp.Aruco;

/// <summary>
/// Dictionary/Set of markers. It contains the inner codification
/// </summary>
public class Dictionary : CvObject
{
    /// <summary>
    /// Creates an empty dictionary.
    /// </summary>
    public Dictionary()
    {
        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_new_default(out var p));
        InitSafeHandle(p);
    }

    /// <summary>
    /// Basic ArUco dictionary constructor
    /// </summary>
    /// <param name="bytesList">bits for all ArUco markers in dictionary. See class description for the memory layout.</param>
    /// <param name="markerSize">ArUco marker size in units</param>
    /// <param name="maxCorrectionBits">maximum number of bits that can be corrected</param>
    public Dictionary(Mat bytesList, int markerSize, int maxCorrectionBits = 0)
    {
        ArgumentNullException.ThrowIfNull(bytesList);
        bytesList.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_new(bytesList.CvPtr, markerSize, maxCorrectionBits, out var p));
        InitSafeHandle(p);

        GC.KeepAlive(bytesList);
    }

    /// <summary>
    ///
    /// </summary>
    internal Dictionary(IntPtr ptr)
    {
        InitSafeHandle(ptr);
    }

    /// <summary>
    /// Creates from native pointer with ownership control.
    /// </summary>
    internal Dictionary(IntPtr ptr, bool ownsHandle)
    {
        InitSafeHandle(ptr, ownsHandle);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.aruco_Dictionary_delete(h))));
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
                NativeMethods.aruco_Dictionary_getBytesList(Handle, out var ret));
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
                NativeMethods.aruco_Dictionary_getMarkerSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_setMarkerSize(Handle, value));
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
                NativeMethods.aruco_Dictionary_getMaxCorrectionBits(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.aruco_Dictionary_setMaxCorrectionBits(Handle, value));
        }
    }
    
    /// <summary>
    /// Read a new dictionary from FileNode.
    /// </summary>
    /// <param name="fn">the FileNode to read the dictionary from.</param>
    /// <returns></returns>
    public bool ReadDictionary(FileNode fn)
    {
        ArgumentNullException.ThrowIfNull(fn);
        fn.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_readDictionary(Handle, fn.CvPtr, out var ret));

        GC.KeepAlive(fn);
        return ret != 0;
    }

    /// <summary>
    /// Write a dictionary to FileStorage, format is the same as in ReadDictionary().
    /// </summary>
    /// <param name="fs">the FileStorage to write the dictionary to.</param>
    /// <param name="name">name of the node to write.</param>
    public void WriteDictionary(FileStorage fs, string name = "")
    {
        ArgumentNullException.ThrowIfNull(fs);
        ArgumentNullException.ThrowIfNull(name);
        fs.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_writeDictionary(Handle, fs.CvPtr, name));

        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Given a matrix of bits. Returns whether if marker is identified or not.
    /// It returns by reference the correct id (if any) and the correct rotation
    /// </summary>
    /// <param name="onlyBits"></param>
    /// <param name="idx">The identified marker id, or -1 if the marker was not identified.</param>
    /// <param name="rotation">The identified marker rotation, or -1 if the marker was not identified.</param>
    /// <param name="maxCorrectionRate"></param>
    /// <returns></returns>
    public bool Identify(Mat onlyBits, out int idx, out int rotation, double maxCorrectionRate)
    {
        ArgumentNullException.ThrowIfNull(onlyBits);
        onlyBits.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_identify(Handle, onlyBits.CvPtr, out idx, out rotation, maxCorrectionRate, out var ret));

        var identified = ret != 0;
        if (!identified)
            rotation = -1;
        return identified;
    }

    /// <summary>
    /// Given a matrix of pixel ratio ranging from 0 to 1. Returns whether if marker is identified or not.
    /// It returns by reference the correct id (if any) and the correct rotation
    /// </summary>
    /// <param name="onlyCellPixelRatio"></param>
    /// <param name="idx">The identified marker id, or -1 if the marker was not identified.</param>
    /// <param name="rotation">The identified marker rotation, or -1 if the marker was not identified.</param>
    /// <param name="maxCorrectionRate"></param>
    /// <param name="validBitIdThreshold">acceptable threshold when comparing the detected marker to the dictionary during marker identification.</param>
    /// <returns></returns>
    public bool Identify(Mat onlyCellPixelRatio, out int idx, out int rotation, double maxCorrectionRate, float validBitIdThreshold)
    {
        ArgumentNullException.ThrowIfNull(onlyCellPixelRatio);
        onlyCellPixelRatio.ThrowIfDisposed();
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_identify_withThreshold(
                Handle, onlyCellPixelRatio.CvPtr, out idx, out rotation, maxCorrectionRate, validBitIdThreshold, out var ret));

        var identified = ret != 0;
        if (!identified)
            rotation = -1;
        return identified;
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
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_getDistanceToId(Handle, bits.Proxy, id, allRotations ? 1 : 0, out var ret));
        
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
        ThrowIfDisposed();
        
        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_generateImageMarker(Handle, id, sidePixels, img.Proxy, borderBits));
        
    }
    
    /// <summary>
    /// Transform matrix of bits to list of bytes in the 4 rotations
    /// </summary>
    /// <param name="bits"></param>
    /// <returns></returns>
    public static Mat GetByteListFromBits(Mat bits)
    {
        ArgumentNullException.ThrowIfNull(bits);
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
    /// <param name="rotationId"></param>
    /// <returns></returns>
    public static Mat GetBitsFromByteList(Mat byteList, int markerSize, int rotationId = 0)
    {
        ArgumentNullException.ThrowIfNull(byteList);
        byteList.ThrowIfDisposed();

        var ret = new Mat();
        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_getBitsFromByteList(byteList.CvPtr, markerSize, rotationId, ret.CvPtr));
        return ret;
    }

    /// <summary>
    /// Get ground truth bits float
    /// </summary>
    /// <param name="markerId"></param>
    /// <param name="rotationId"></param>
    /// <returns></returns>
    public Mat GetMarkerBits(int markerId, int rotationId = 0)
    {
        ThrowIfDisposed();

        var ret = new Mat();
        NativeMethods.HandleException(
            NativeMethods.aruco_Dictionary_getMarkerBits(Handle, markerId, rotationId, ret.CvPtr));
        return ret;
    }
}
