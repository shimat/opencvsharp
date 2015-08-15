#define Net20

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Util
{
    /// <summary>
    /// Handles loading embedded dlls into memory, based on http://stackoverflow.com/questions/666799/embedding-unmanaged-dll-into-a-managed-c-sharp-dll.
    /// </summary>
    /// <remarks>This code is based on https://github.com/charlesw/tesseract </remarks>
    public sealed class WindowsLibraryLoader
    {
        #region Singleton pattern

        private static readonly WindowsLibraryLoader instance = new WindowsLibraryLoader();

        /// <summary>
        /// 
        /// </summary>
        public static WindowsLibraryLoader Instance { get { return instance; } }

        #endregion

        /// <summary>
        /// The default base directory name to copy the assemblies too.
        /// </summary>
        private const string ProcessorArchitecture = "PROCESSOR_ARCHITECTURE";
        private const string DllFileExtension = ".dll";
        private const string DllDirectory = "dll";

        private readonly List<string> loadedAssemblies = new List<string>();

        /// <summary>
        /// Map processor 
        /// </summary>
        private readonly Dictionary<string, string> processorArchitecturePlatforms =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
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
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                {
                    {"x86", 4},
                    {"AMD64", 8},
                    {"IA64", 8},
                    {"ARM", 4}
                };

        /// <summary>
        /// Additional user-defined DLL paths 
        /// </summary>
        public List<string> AdditionalPaths { get; private set; }

        private readonly object syncLock = new object();

        /// <summary>
        /// constructor
        /// </summary>
        private WindowsLibraryLoader()
        {
            AdditionalPaths = new List<string>();
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsCurrentPlatformSupported()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT ||
                Environment.OSVersion.Platform == PlatformID.Win32Windows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="additionalPaths"></param>
        public void LoadLibrary(string dllName, IEnumerable<string> additionalPaths = null)
        {
            if (!IsCurrentPlatformSupported())
            {
                return;
            }

            if (additionalPaths == null)
                additionalPaths = new string[0];

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
                    string baseDirectory;

                    // Try loading from user-defined paths
                    foreach (string path in additionalPaths)
                    {
                        // baseDirectory = Path.GetFullPath(path);
                        dllHandle = LoadLibraryRaw(dllName, path);
                        if (dllHandle != IntPtr.Zero) return;
                    }

                    // Try loading from executing assembly domain
                    var executingAssembly = Assembly.GetExecutingAssembly();
                    baseDirectory = Path.GetDirectoryName(executingAssembly.Location);
                    dllHandle = LoadLibraryInternal(dllName, baseDirectory, processArch);
                    if (dllHandle != IntPtr.Zero) return;

                    // Fallback to current app domain
                    baseDirectory = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
                    dllHandle = LoadLibraryInternal(dllName, baseDirectory, processArch);
                    if (dllHandle != IntPtr.Zero) return;

                    // Finally try the working directory
                    baseDirectory = Path.GetFullPath(Environment.CurrentDirectory);
                    dllHandle = LoadLibraryInternal(dllName, baseDirectory, processArch);
                    if (dllHandle != IntPtr.Zero) return;

                    // ASP.NET hack, requires an active context
#if false
                    if (HttpContext.Current != null)
                    {
                        var server = HttpContext.Current.Server;
                        baseDirectory = Path.GetFullPath(server.MapPath("bin"));
                        dllHandle = LoadLibraryInternal(dllName, baseDirectory, processArch);
                        if (dllHandle != IntPtr.Zero) return;
                    }
#endif
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.AppendFormat("Failed to find dll \"{0}\", for processor architecture {1}.", dllName,
                                              processArch.Architecture);
                    if (processArch.HasWarnings)
                    {
                        // include process detection warnings
                        errorMessage.AppendFormat("\r\nWarnings: \r\n{0}", processArch.WarningText());
                    }
                    throw new Exception(errorMessage.ToString());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Get's the current process architecture while keeping track of any assumptions or possible errors.
        /// </summary>
        /// <returns></returns>
        private ProcessArchitectureInfo GetProcessArchitecture()
        {
            // BUGBUG: Will this always be reliable?
            string processArchitecture = Environment.GetEnvironmentVariable(ProcessorArchitecture);
            var processInfo = new ProcessArchitectureInfo();
            if (!String.IsNullOrEmpty(processArchitecture))
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
                if (String.Equals(processInfo.Architecture, "AMD64", StringComparison.OrdinalIgnoreCase) && IntPtr.Size == 4)
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
            var platformName = GetPlatformName(processArchInfo.Architecture);
            var expectedDllDirectory = Path.Combine(
                Path.Combine(baseDirectory, DllDirectory), platformName);
            //var fileName = FixUpDllFileName(Path.Combine(expectedDllDirectory, dllName));

            return LoadLibraryRaw(dllName, expectedDllDirectory);
        }

        private IntPtr LoadLibraryRaw(string dllName, string baseDirectory)
        {
            IntPtr libraryHandle = IntPtr.Zero;
            var fileName = FixUpDllFileName(Path.Combine(baseDirectory, dllName));

            if (File.Exists(fileName))
            {
                // Attempt to load dll
                try
                {
                    // Show where we're trying to load the file from
                    Debug.WriteLine(String.Format(
                          "Trying to load native library \"{0}\"...",
                          fileName));

                    libraryHandle = Win32LoadLibrary(fileName);
                    if (libraryHandle != IntPtr.Zero)
                    {
                        // library has been loaded
                        Debug.WriteLine(String.Format(
                          "Successfully loaded native library \"{0}\".",
                          fileName));
                        loadedAssemblies.Add(dllName);
                    }
                    else
                    {
                        Debug.WriteLine(String.Format(
                            "Failed to load native library \"{0}\".\r\nCheck windows event log.",
                            fileName));
                    }
                }
                catch (Exception e)
                {
                    var lastError = Marshal.GetLastWin32Error();
                    Debug.WriteLine(String.Format(
                        "Failed to load native library \"{0}\".\r\nLast Error:{1}\r\nCheck inner exception and\\or windows event log.\r\nInner Exception: {2}",
                        fileName, lastError, e));
                }
            }
            else
            {
                Debug.WriteLine(String.Format(CultureInfo.CurrentCulture,
                          "The native library \"{0}\" does not exist.",
                          fileName));
            }

            return libraryHandle;
        }

        /// <summary>
        /// Determines if the dynamic link library file name requires a suffix
        /// and adds it if necessary.
        /// </summary>
        private string FixUpDllFileName(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                PlatformID platformId = Environment.OSVersion.Platform;

                if ((platformId == PlatformID.Win32S) ||
                    (platformId == PlatformID.Win32Windows) ||
                    (platformId == PlatformID.Win32NT) ||
                    (platformId == PlatformID.WinCE))
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
        private string GetPlatformName(string processorArchitecture)
        {
            if (String.IsNullOrEmpty(processorArchitecture))
                return null;

            string platformName;
            if (processorArchitecturePlatforms.TryGetValue(processorArchitecture, out platformName))
            {
                return platformName;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        private class ProcessArchitectureInfo
        {
            public ProcessArchitectureInfo()
            {
                Warnings = new List<string>();
            }

            public string Architecture { get; set; }
            private List<string> Warnings { get; set; }

            public bool HasWarnings
            {
                get { return Warnings.Count > 0; }
            }

            public void AddWarning(string format, params object[] args)
            {
                Warnings.Add(String.Format(format, args));
            }

            public string WarningText()
            {
                return String.Join("\r\n", Warnings.ToArray());
            }
        }

        [DllImport("kernel32", EntryPoint = "LoadLibrary", CallingConvention = CallingConvention.Winapi,
            SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern IntPtr Win32LoadLibrary(string dllPath);
    }
}
