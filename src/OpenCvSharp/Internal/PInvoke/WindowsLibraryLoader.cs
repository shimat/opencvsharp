using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.Internal;

/// <summary>
/// Handles loading embedded dlls into memory, based on http://stackoverflow.com/questions/666799/embedding-unmanaged-dll-into-a-managed-c-sharp-dll.
/// </summary>
/// <remarks>This code is based on https://github.com/charlesw/tesseract </remarks>
public sealed class WindowsLibraryLoader
{
    public static WindowsLibraryLoader Instance { get; } = new();

    /// <summary>
    /// The default base directory name to copy the assemblies too.
    /// </summary>
    private const string ProcessorArchitecture = "PROCESSOR_ARCHITECTURE";
    private const string DllFileExtension = ".dll";
    private const string DllDirectory = "dll";

    private readonly List<string> loadedAssemblies = [];

    /// <summary>
    /// Map processor 
    /// </summary>
    private readonly Dictionary<string, string> processorArchitecturePlatforms =
        new (StringComparer.OrdinalIgnoreCase)
        {
            {"x86", "x86"},
            {"AMD64", "x64"},
            {"IA64", "Itanium"},
            {"ARM", "WinCE"}
        };

    /// <summary>
    /// Used as a sanity check for the returned processor architecture to double check the returned value.
    /// </summary>
    private readonly Dictionary<string, int> processorArchitectureAddressWidthPlatforms =
        new(StringComparer.OrdinalIgnoreCase)
        {
            {"x86", 4},
            {"AMD64", 8},
            {"IA64", 8},
            {"ARM", 4}
        };

    /// <summary>
    /// Additional user-defined DLL paths 
    /// </summary>
#pragma warning disable CA1002 // Do not expose generic lists
    public List<string> AdditionalPaths { get; }
#pragma warning restore CA1002 

    private readonly object syncLock = new();

    /// <summary>
    /// constructor
    /// </summary>
    private WindowsLibraryLoader()
    {
        AdditionalPaths = [];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dllName"></param>
    /// <returns></returns>
    public bool IsLibraryLoaded(string dllName)
    {
        lock (syncLock)
        {
            return loadedAssemblies.Contains(dllName);
        }
    }

    /// <summary>
    /// Determine if the OS is Windows
    /// </summary>
    /// <returns></returns>
    public static bool IsCurrentPlatformSupported()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }

    /// <summary>
    /// Determine if the runtime is .NET Core
    /// </summary>
    /// <returns></returns>
    public static bool IsDotNetCore()
    {
        // https://github.com/dotnet/corefx/blob/v2.1-preview1/src/CoreFx.Private.TestUtilities/src/System/PlatformDetection.cs
        return Environment.Version.Major >= 5 || 
               RuntimeInformation.FrameworkDescription.StartsWith(".NET Core", StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dllName"></param>
    /// <param name="additionalPaths"></param>
    public void LoadLibrary(string dllName, IEnumerable<string>? additionalPaths = null)
    {
        // Windows only
        if (!IsCurrentPlatformSupported())
            return;

        var additionalPathsArray = additionalPaths?.ToArray() ?? [];

        // In .NET Core, process only when additional paths are specified.
        if (IsDotNetCore() && additionalPathsArray.Length == 0)
            return;

        try
        {
            lock (syncLock)
            {
                if (loadedAssemblies.Contains(dllName))
                {
                    return;
                }

                var processArch = GetProcessArchitecture();
                IntPtr dllHandle;

                // Try loading from user-defined paths
                foreach (var path in additionalPathsArray)
                {
                    // baseDirectory = Path.GetFullPath(path);
                    dllHandle = LoadLibraryRaw(dllName, path);
                    if (dllHandle != IntPtr.Zero) return;
                }

                // Try loading from executing assembly domain
                var executingAssembly = GetType().GetTypeInfo().Assembly;
                var baseDirectory = Path.GetDirectoryName(executingAssembly.Location) ?? "";
                dllHandle = LoadLibraryInternal(dllName, baseDirectory, processArch);
                if (dllHandle != IntPtr.Zero) return;

                // Gets the pathname of the base directory that the assembly resolver uses to probe for assemblies.
                // https://github.com/dotnet/corefx/issues/2221
#if !NET40
                baseDirectory = AppContext.BaseDirectory;
                dllHandle = LoadLibraryInternal(dllName, baseDirectory, processArch);
                if (dllHandle != IntPtr.Zero) return;
#endif

                // Finally try the working directory
                baseDirectory = Path.GetFullPath(Directory.GetCurrentDirectory());
                dllHandle = LoadLibraryInternal(dllName, baseDirectory, processArch);
                if (dllHandle != IntPtr.Zero) return;

                var errorMessage = new StringBuilder();
                errorMessage.AppendFormat(CultureInfo.InvariantCulture, $"Failed to find dll \"{dllName}\", for processor architecture {processArch.Architecture}.");
                if (processArch.HasWarnings)
                {
                    // include process detection warnings
                    errorMessage.AppendLine().Append("Warnings: ").AppendLine().Append("{processArch.WarningText()}");
                }

                throw new OpenCvSharpException(errorMessage.ToString());
            }
        }
#pragma warning disable CA1031 // Do not catch general exception types
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
#pragma warning restore CA1031 // Do not catch general exception types
    }

    /// <summary>
    /// Gets the current process architecture while keeping track of any assumptions or possible errors.
    /// </summary>
    /// <returns></returns>
    private ProcessArchitectureInfo GetProcessArchitecture()
    {
        // BUGBUG: Will this always be reliable?
        var processArchitecture = Environment.GetEnvironmentVariable(ProcessorArchitecture);

        var processInfo = new ProcessArchitectureInfo();
        if (!string.IsNullOrEmpty(processArchitecture))
        {
            // Sanity check
            processInfo.Architecture = processArchitecture;
        }
        else
        {
            processInfo.AddWarning("Failed to detect processor architecture, falling back to x86.");
            processInfo.Architecture = (IntPtr.Size == 8) ? "x64" : "x86";
        }

        var addressWidth = processorArchitectureAddressWidthPlatforms[processInfo.Architecture];
        if (addressWidth != IntPtr.Size)
        {
            if (string.Equals(processInfo.Architecture, "AMD64", StringComparison.OrdinalIgnoreCase) && IntPtr.Size == 4)
            {
                // fall back to x86 if detected x64 but has an address width of 32 bits.
                processInfo.Architecture = "x86";
                processInfo.AddWarning("Expected the detected processing architecture of {0} to have an address width of {1} Bytes but was {2} Bytes, falling back to x86.", processInfo.Architecture, addressWidth, IntPtr.Size);
            }
            else
            {
                // no fallback possible
                processInfo.AddWarning("Expected the detected processing architecture of {0} to have an address width of {1} Bytes but was {2} Bytes.", processInfo.Architecture, addressWidth, IntPtr.Size);
            }
        }

        return processInfo;
    }

    private IntPtr LoadLibraryInternal(string dllName, string baseDirectory, ProcessArchitectureInfo processArchInfo)
    {
        //IntPtr libraryHandle = IntPtr.Zero;
        var platformName = GetPlatformName(processArchInfo.Architecture) ?? "";
        var expectedDllDirectory = Path.Combine(
            Path.Combine(baseDirectory, DllDirectory), platformName);
        //var fileName = FixUpDllFileName(Path.Combine(expectedDllDirectory, dllName));

        return LoadLibraryRaw(dllName, expectedDllDirectory);
    }

    private IntPtr LoadLibraryRaw(string dllName, string baseDirectory)
    {
        var libraryHandle = IntPtr.Zero;
        var fileName = FixUpDllFileName(Path.Combine(baseDirectory, dllName));

#if WINRT && false
            // MP! Note: This is a hack, needs refinement. We don't need to carry payload of both binaries for WinRT because the appx is platform specific.
            ProcessArchitectureInfo processInfo = GetProcessArchitecture();

            string cpu = "x86";
            if (processInfo.Architecture == "AMD64")
                cpu = "x64";

            string dllpath = baseDirectory.Replace($"dll\\{cpu}", "");
            fileName = $"{dllpath}{dllName}.dll";

            // Show where we're trying to load the file from
            Debug.WriteLine($"Trying to load native library \"{fileName}\"...");
#endif

        if (File.Exists(fileName))
        {
            // Attempt to load dll
            try
            {
                libraryHandle = Win32Api.LoadLibrary(fileName);
                if (libraryHandle != IntPtr.Zero)
                {
                    // library has been loaded
                    Debug.WriteLine($"Successfully loaded native library \"{fileName}\".");
                    loadedAssemblies.Add(dllName);
                }
                else
                {
                    Debug.WriteLine($"Failed to load native library \"{fileName}\".\r\nCheck windows event log.");
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception e)
            {
                // ReSharper disable once RedundantAssignment
                var lastError = Marshal.GetLastWin32Error();
                Debug.WriteLine(
                    $"Failed to load native library \"{fileName}\".\r\nLast Error:{lastError}\r\nCheck inner exception and\\or windows event log.\r\nInner Exception: {e}");
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }
        else
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture,
                "The native library \"{0}\" does not exist.",
                fileName));
        }

        return libraryHandle;
    }

    /// <summary>
    /// Determines if the dynamic link library file name requires a suffix
    /// and adds it if necessary.
    /// </summary>
    private static string FixUpDllFileName(string fileName)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (!fileName.EndsWith(DllFileExtension,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return fileName + DllFileExtension;
                }
            }
        }

        return fileName;
    }

    /// <summary>
    /// Given the processor architecture, returns the name of the platform.
    /// </summary>
    private string? GetPlatformName(string processorArchitecture)
    {
        if (string.IsNullOrEmpty(processorArchitecture))
            return null;

        if (processorArchitecturePlatforms.TryGetValue(processorArchitecture, out var platformName))
            return platformName;

        return null;
    }

    private sealed class ProcessArchitectureInfo
    {
        public string Architecture { get; set; }
        private List<string> Warnings { get; }

        public ProcessArchitectureInfo()
        {
            Architecture = "";
            Warnings = [];
        }

        public bool HasWarnings => Warnings.Count > 0;

        public void AddWarning(string format, params object[] args)
        {
            Warnings.Add(string.Format(CultureInfo.InvariantCulture, format, args));
        }

        public string WarningText()
        {
            return string.Join("\r\n", Warnings);
        }
    }

}
