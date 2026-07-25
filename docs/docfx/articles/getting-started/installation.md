# Installation

This page creates a .NET console application and installs the packages selected in [Choose a Version and Package](package-selection.md). The commands require the [.NET 8 SDK or later](https://dotnet.microsoft.com/download).

## Create a project

```bash
dotnet new console -n OpenCvSharpExample
cd OpenCvSharpExample
```

## Windows x64

The all-in-one package is the simplest option for Windows x64:

```bash
dotnet add package OpenCvSharp5.Windows
```

For the reduced module set, use `OpenCvSharp5.Windows.Slim` instead.

## Windows ARM64

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.runtime.win-arm64
```

Use `OpenCvSharp5.runtime.win-arm64.slim` instead of the full runtime when the reduced module set is sufficient.

## Linux x64

For a desktop application that uses native OpenCV windows:

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.official.runtime.linux-x64
```

For a service or container that does not use `Cv2.ImShow`, `Cv2.WaitKey`, or other `highgui` APIs:

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.official.runtime.linux-x64.headless
```

The full runtime requires GTK3. On a minimal Ubuntu or Debian installation, install it with:

```bash
sudo apt-get update
sudo apt-get install libgtk-3-0
```

The official Linux x64 packages require glibc 2.28 or later.

## Linux ARM64

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.runtime.linux-arm64
```

## macOS

For Apple Silicon:

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.runtime.osx.arm64
```

For an Intel Mac:

```bash
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.runtime.osx.x64
```

## WebAssembly

WebAssembly uses static native linking and requires a Blazor WebAssembly project rather than the console project created above. Install the WebAssembly build tools and create a standalone Blazor WebAssembly application:

```bash
dotnet workload install wasm-tools
dotnet new blazorwasm -n OpenCvSharpWasmExample
cd OpenCvSharpWasmExample
dotnet add package OpenCvSharp5
dotnet add package OpenCvSharp5.runtime.wasm
```

Add the following properties to the project file:

```xml
<PropertyGroup>
  <WasmInitialHeapSize>268435456</WasmInitialHeapSize>
  <WasmAllowUndefinedSymbols>true</WasmAllowUndefinedSymbols>
</PropertyGroup>
```

The larger initial heap accommodates the statically linked OpenCV runtime. `WasmAllowUndefinedSymbols` is currently required because the managed assembly declares APIs for OpenCV modules that are not included in the WebAssembly build; calling one of those unavailable APIs will still fail at run time. The runtime package automatically supplies the native archive and its required exception-handling setting.

See the [OpenCvSharp Blazor sample](https://github.com/shimat/opencvsharp_blazor_sample) for a complete browser application.

## Verify the package references

```bash
dotnet list package
dotnet restore
dotnet build
```

The package list should contain `OpenCvSharp5` and exactly one runtime package for the deployment target, unless you selected a Windows convenience package.

## Next step

Continue to [Your First Application](first-application.md).
