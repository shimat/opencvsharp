# OpenCvSharp Build Instructions

## Windows

### Prerequisites
- Visual Studio 2022 / 2026, or the corresponding Build Tools, with the **Desktop development with C++** workload
- CMake 3.20+ in PATH (`winget install Kitware.CMake`)
- Git in PATH
- [vcpkg](https://github.com/microsoft/vcpkg) in PATH or `VCPKG_INSTALLATION_ROOT` set
  ```powershell
  git clone https://github.com/microsoft/vcpkg C:\vcpkg
  C:\vcpkg\bootstrap-vcpkg.bat
  # Add C:\vcpkg to PATH, or set $env:VCPKG_INSTALLATION_ROOT = 'C:\vcpkg'
  ```

### Steps
1. Clone the repository with submodules (opencv + opencv_contrib are included as submodules):
   ```powershell
   git clone --recursive https://github.com/shimat/opencvsharp.git
   cd opencvsharp
   ```
   If you already cloned without submodules:
   ```powershell
   git submodule update --init --recursive
   ```

2. Build OpenCV from source (Tesseract and other native dependencies are automatically installed via vcpkg):
   ```powershell
   # Install vcpkg dependencies (only needed once, or after vcpkg.json changes)
   C:\vcpkg\vcpkg.exe install --triplet x64-windows-static --overlay-triplets cmake\triplets --x-install-root vcpkg_installed
   ```
   ```powershell
   .\scripts\build_opencv_windows.ps1
   # Use -Jobs N to control parallel build (default: 4)
   .\scripts\build_opencv_windows.ps1 -Jobs 8
   ```
   Output is installed to `opencv_artifacts/`.

3. Build the native wrapper `OpenCvSharpExtern`:
   ```powershell
   # Use "Visual Studio 17 2022" for VS 2022, or "Visual Studio 18 2026" for VS 2026
   cmake -S src -B src\build -G "Visual Studio 18 2026" -A x64 `
         -D "CMAKE_PREFIX_PATH=$PWD\opencv_artifacts" `
         -D CMAKE_TOOLCHAIN_FILE="C:\vcpkg\scripts\buildsystems\vcpkg.cmake" `
         -D VCPKG_TARGET_TRIPLET=x64-windows-static `
         -D "VCPKG_INSTALLED_DIR=$PWD\vcpkg_installed" `
         -D "VCPKG_OVERLAY_TRIPLETS=$PWD\cmake\triplets"
   cmake --build src\build --config Release
   ```

4. Build the managed OpenCvSharp library:
   - Open `OpenCvSharp.slnx` and build, or:
   ```powershell
   dotnet build src/OpenCvSharp/OpenCvSharp.csproj -c Release
   ```
   > **Note on the native DLL:** Step 3 automatically copies `OpenCvSharpExtern.dll` into `test/OpenCvSharp.Tests/` as a post-build step, so `dotnet test` works out of the box.
   > For your own application, either add `src\build\OpenCvSharpExtern\Release` to `PATH`, or copy `OpenCvSharpExtern.dll` alongside your app's output directory.

## Ubuntu

Tesseract and image libraries (libjpeg-turbo, libpng, libtiff, libwebp) can be managed either via **vcpkg** (recommended, consistent with Windows) or via the system package manager.

### Option A: vcpkg (recommended)

Prerequisites: `cmake`, `git`, `g++`, vcpkg installed.

```bash
git clone --recursive https://github.com/shimat/opencvsharp.git
cd opencvsharp
git submodule update --init --recursive
```

```bash
# Install dependencies via vcpkg
/path/to/vcpkg/vcpkg install \
  --triplet x64-linux-static \
  --overlay-triplets cmake/triplets
```

Build OpenCV and OpenCvSharpExtern pointing to vcpkg:
```bash
cmake -C cmake/opencv_build_options.cmake \
      -S opencv -B opencv/build \
      -D OPENCV_EXTRA_MODULES_PATH=$PWD/opencv_contrib/modules \
      -D CMAKE_INSTALL_PREFIX=$PWD/opencv_artifacts \
      -D CMAKE_TOOLCHAIN_FILE=/path/to/vcpkg/scripts/buildsystems/vcpkg.cmake \
      -D VCPKG_TARGET_TRIPLET=x64-linux-static
cmake --build opencv/build -j$(nproc)
cmake --install opencv/build

cmake -S src -B src/build \
      -D CMAKE_BUILD_TYPE=Release \
      -D CMAKE_PREFIX_PATH=$PWD/opencv_artifacts \
      -D CMAKE_TOOLCHAIN_FILE=/path/to/vcpkg/scripts/buildsystems/vcpkg.cmake \
      -D VCPKG_TARGET_TRIPLET=x64-linux-static
cmake --build src/build -j$(nproc)
```

### Option B: system packages (apt)

```bash
sudo apt-get install -y g++ cmake libtesseract-dev \
  libjpeg-dev libpng-dev libtiff-dev libwebp-dev \
  libavcodec-dev libavformat-dev libswscale-dev
```

Build OpenCV from source: https://docs.opencv.org/4.x/d7/d9f/tutorial_linux_install.html

Then build the native wrapper:
```bash
cmake -S src -B src/build \
      -D CMAKE_BUILD_TYPE=Release \
      -D CMAKE_PREFIX_PATH=${YOUR_OPENCV_INSTALL_PATH}
cmake --build src/build -j$(nproc)
```

Add a reference to the built shared library:
```bash
export LD_LIBRARY_PATH="${LD_LIBRARY_PATH}:/path/to/opencvsharp/src/build/OpenCvSharpExtern"
```

### Build managed library (both options)
```bash
dotnet build src/OpenCvSharp/OpenCvSharp.csproj -c Release
```

## Customizing OpenCV and OpenCvSharp for embedded (ARM) Platforms

If you want to use OpenCV and OpenCvSharp on an embedded platform like a Raspberry Pi with a 64-bit OS, you have to build both libraries manually, and it's easiest to build it right on your target hardware to avoid cross-compiler toolchain challenges. [The instructions for this build and install are here](embedded-builds.md).
