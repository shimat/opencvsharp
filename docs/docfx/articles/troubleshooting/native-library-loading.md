# Native Library Loading

An OpenCvSharp application needs both the managed `OpenCvSharp5` assembly and the native `OpenCvSharpExtern` library for its operating system and process architecture. A project can compile successfully with only the managed package and then fail when the first OpenCvSharp API is called.

## Start with the package references

Run:

```bash
dotnet list package --include-transitive
```

Confirm that the application references either:

- a Windows convenience package such as `OpenCvSharp5.Windows`; or
- `OpenCvSharp5` and one runtime package that matches the deployment target.

Do not install multiple native runtime packages for the same deployment target. Review [Choose a Version and Package](../getting-started/package-selection.md) for the supported combinations.

## DllNotFoundException

`DllNotFoundException` mentioning `OpenCvSharpExtern` usually means that the native runtime package is missing, the wrong runtime identifier was selected, or a dependency of the native library cannot be loaded.

Clean and restore the application after correcting its package references:

```bash
dotnet clean
dotnet restore
dotnet build
```

Avoid copying `OpenCvSharpExtern` manually into the output directory when using an official runtime package. NuGet and the .NET runtime select native assets from the package's `runtimes/{rid}/native` layout.

## BadImageFormatException

`BadImageFormatException` commonly indicates an architecture mismatch, such as loading an x64 native library in an ARM64 process. Check the application architecture and use the corresponding runtime package.

```bash
dotnet --info
```

On Windows x64, use `OpenCvSharp5.Windows` or `OpenCvSharp5.runtime.win`. On Windows ARM64, use `OpenCvSharp5.runtime.win-arm64`. On macOS, select the x64 or arm64 package that matches the process architecture.

## Linux dependencies

The full official Linux x64 runtime uses GTK3 for `highgui`. On a minimal Ubuntu or Debian system, install:

```bash
sudo apt-get update
sudo apt-get install libgtk-3-0
```

Use `OpenCvSharp5.official.runtime.linux-x64.headless` when the application does not call native window APIs but still needs the full non-GUI module set. Use the slim package only when its reduced module set is sufficient.

To inspect unresolved shared-library dependencies, locate `libOpenCvSharpExtern.so` in the build output and run:

```bash
ldd libOpenCvSharpExtern.so
```

Lines ending in `not found` identify missing system libraries. The official Linux x64 packages require glibc 2.28 or later.

## Nonstandard native library locations

OpenCvSharp uses the .NET runtime's native library resolution. A host that does not process the application's `.deps.json`, such as some plugin systems, can register a resolver for the assembly that contains OpenCvSharp's P/Invoke declarations:

```csharp
using System.Reflection;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

Assembly openCvSharpAssembly = typeof(NativeMethods).Assembly;
string openCvSharpDirectory =
    Path.GetDirectoryName(openCvSharpAssembly.Location)
    ?? throw new InvalidOperationException(
        "Could not determine the OpenCvSharp assembly directory.");

string nativeFileName =
    OperatingSystem.IsWindows() ? "OpenCvSharpExtern.dll" :
    OperatingSystem.IsLinux() ? "libOpenCvSharpExtern.so" :
    OperatingSystem.IsMacOS() ? "libOpenCvSharpExtern.dylib" :
    throw new PlatformNotSupportedException();

string nativeLibraryPath = Path.Combine(
    openCvSharpDirectory,
    "native",
    nativeFileName);

NativeLibrary.SetDllImportResolver(
    openCvSharpAssembly,
    (libraryName, assembly, searchPath) =>
    {
        if (libraryName != NativeMethods.DllExtern)
        {
            return IntPtr.Zero;
        }

        return NativeLibrary.Load(nativeLibraryPath);
    });

NativeMethods.TryPInvoke();
```

This example expects the custom native library in a `native` directory beside `OpenCvSharp.dll`. Alternatively, obtain a fully qualified native-library path from the host's configuration. Do not derive it from the process current directory because a host can change that directory.

Register the resolver before the first call to any OpenCvSharp API. The resolver must target `typeof(NativeMethods).Assembly`, not the host or plugin assembly, because native resolution is scoped to the assembly containing the P/Invoke declaration.

Calling `NativeLibrary.Load` by itself only returns a native handle; returning that handle from the resolver connects it reliably to OpenCvSharp's `OpenCvSharpExtern` imports. `NativeMethods.TryPInvoke()` is an optional explicit pre-flight check after resolver registration and is not required for normal API calls.

Most applications should use an official runtime package instead of a custom resolver.

## Still failing

When opening an [issue](https://github.com/shimat/opencvsharp/issues), include:

- the `OpenCvSharp5` and runtime package versions;
- the target framework and runtime identifier from the project file;
- the operating system and CPU architecture;
- the complete exception, including inner exceptions;
- the output of `dotnet --info`; and
- on Linux, relevant `ldd` output.
