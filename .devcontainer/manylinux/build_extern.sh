#!/usr/bin/env bash
# build_extern.sh — first-time setup inside the manylinux_2_28 devcontainer.
# Called automatically by postCreateCommand when the container is first created.
# Safe to re-run manually; each step is skipped if its output already exists.
#
# Steps:
#   1. vcpkg install (x64-linux-static)
#   2. Static FFmpeg
#   3. OpenCV (full, static, with contrib)
#
# OpenCvSharpExtern is intentionally NOT built here — run the VS Code task
# "Build OpenCvSharpExtern" (Ctrl+Shift+B) or build_opencvsharpextern.sh manually.

set -euxo pipefail

# ---------------------------------------------------------------------------
# 1. vcpkg packages
# ---------------------------------------------------------------------------
/opt/vcpkg/vcpkg install \
    --triplet x64-linux-static \
    --overlay-triplets=/work/cmake/triplets \
    --x-install-root=/opt/vcpkg-installed

# ---------------------------------------------------------------------------
# 2. Static FFmpeg (skipped if already built)
# ---------------------------------------------------------------------------
bash /work/docker/manylinux/build_static_deps.sh

# ---------------------------------------------------------------------------
# 3. OpenCV (full, static)
# ---------------------------------------------------------------------------
if [[ ! -f /opt/opencv_artifacts/lib64/pkgconfig/opencv4.pc ]] && \
   [[ ! -f /opt/opencv_artifacts/lib/pkgconfig/opencv4.pc ]]; then
    cmake \
        -G Ninja \
        -C /work/cmake/opencv_build_options.cmake \
        -S /work/opencv \
        -B /tmp/opencv-build \
        -D OPENCV_EXTRA_MODULES_PATH=/work/opencv_contrib/modules \
        -D CMAKE_INSTALL_PREFIX=/opt/opencv_artifacts \
        -D CMAKE_TOOLCHAIN_FILE=/opt/vcpkg/scripts/buildsystems/vcpkg.cmake \
        -D VCPKG_TARGET_TRIPLET=x64-linux-static \
        -D VCPKG_INSTALLED_DIR=/opt/vcpkg-installed \
        -D CMAKE_FIND_PACKAGE_PREFER_CONFIG=ON \
        -D CMAKE_PREFIX_PATH="/opt/vcpkg-installed/x64-linux-static;/opt/ffmpeg" \
        -D BUILD_JPEG=OFF \
        -D BUILD_PNG=OFF \
        -D BUILD_TIFF=OFF \
        -D BUILD_WEBP=OFF \
        -D BUILD_ZLIB=OFF \
        -D WITH_TBB=OFF \
        -D WITH_OPENEXR=OFF \
        -D WITH_JASPER=OFF
    cmake --build /tmp/opencv-build -j4
    cmake --install /tmp/opencv-build
    rm -rf /tmp/opencv-build
fi
