namespace OpenCvSharp;

/// <summary>
/// A read-only snapshot of an OpenCL platform.
/// </summary>
/// <param name="Name">Platform name.</param>
/// <param name="Vendor">Platform vendor.</param>
/// <param name="Version">Platform version string.</param>
/// <param name="VersionMajor">Parsed platform major version.</param>
/// <param name="VersionMinor">Parsed platform minor version.</param>
/// <param name="Devices">Devices exposed by the platform.</param>
public sealed record OclPlatformInfo(
    string Name,
    string Vendor,
    string Version,
    int VersionMajor,
    int VersionMinor,
    IReadOnlyList<OclDeviceInfo> Devices);

/// <summary>
/// A read-only snapshot of an OpenCL device.
/// </summary>
/// <param name="Name">Device name.</param>
/// <param name="VendorName">Device vendor name.</param>
/// <param name="Version">OpenCV's device version string.</param>
/// <param name="OpenCLVersion">OpenCL device version string.</param>
/// <param name="OpenCLCVersion">OpenCL C version string.</param>
/// <param name="DriverVersion">OpenCL driver version.</param>
/// <param name="Type">Device type.</param>
/// <param name="AddressBits">Device address width in bits.</param>
/// <param name="Available">Whether the device is available.</param>
/// <param name="CompilerAvailable">Whether the OpenCL compiler is available.</param>
/// <param name="LinkerAvailable">Whether the OpenCL linker is available.</param>
/// <param name="MaxClockFrequency">Maximum clock frequency in MHz.</param>
/// <param name="MaxComputeUnits">Maximum number of parallel compute units.</param>
/// <param name="GlobalMemorySize">Global memory size in bytes.</param>
/// <param name="LocalMemorySize">Local memory size in bytes.</param>
/// <param name="HostUnifiedMemory">Whether the device and host share unified memory.</param>
/// <param name="ImageSupport">Whether OpenCL image objects are supported.</param>
public sealed record OclDeviceInfo(
    string Name,
    string VendorName,
    string Version,
    string OpenCLVersion,
    string OpenCLCVersion,
    string DriverVersion,
    OclDeviceTypes Type,
    int AddressBits,
    bool Available,
    bool CompilerAvailable,
    bool LinkerAvailable,
    int MaxClockFrequency,
    int MaxComputeUnits,
    ulong GlobalMemorySize,
    ulong LocalMemorySize,
    bool HostUnifiedMemory,
    bool ImageSupport);
