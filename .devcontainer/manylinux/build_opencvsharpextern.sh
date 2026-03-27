#!/usr/bin/env bash
# build_opencvsharpextern.sh — configure & build OpenCvSharpExtern inside the
# manylinux_2_28 devcontainer.  Run directly or via the VS Code task
# "Build OpenCvSharpExtern" (Ctrl+Shift+B).
#
# Output: /work/src/build/OpenCvSharpExtern/libOpenCvSharpExtern.so

set -euxo pipefail

cmake \
    -G Ninja \
    -S /work/src \
    -B /work/src/build \
    -D CMAKE_BUILD_TYPE=Release \
    -D CMAKE_TOOLCHAIN_FILE=/opt/vcpkg/scripts/buildsystems/vcpkg.cmake \
    -D VCPKG_TARGET_TRIPLET=x64-linux-static \
    -D VCPKG_INSTALLED_DIR=/opt/vcpkg-installed \
    -D OpenCV_DIR=/opt/opencv_artifacts/lib64/cmake/opencv4 \
    -D CMAKE_FIND_PACKAGE_PREFER_CONFIG=ON \
    "-D CMAKE_PREFIX_PATH=/opt/opencv_artifacts;/opt/ffmpeg;/opt/vcpkg-installed/x64-linux-static" \
    "-D ZLIB_LIBRARY=/opt/vcpkg-installed/x64-linux-static/lib/libz.a" \
    "-D ZLIB_INCLUDE_DIR=/opt/vcpkg-installed/x64-linux-static/include" \
    "-D CMAKE_SHARED_LINKER_FLAGS=-L/opt/vcpkg-installed/x64-linux-static/lib"

cmake --build /work/src/build -j4
