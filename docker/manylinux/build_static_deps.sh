#!/usr/bin/env bash
# build_static_deps.sh — builds FFmpeg as a static library inside the
# quay.io/pypa/manylinux_2_28_x86_64 container for the portable Linux NuGet package.
#
# Other third-party libraries (libjpeg-turbo, libpng, libtiff, libwebp, Tesseract,
# Leptonica) are now managed by vcpkg (vcpkg.json + cmake/triplets/x64-linux-static.cmake).
#
# After this script runs, /opt/ffmpeg contains a static FFmpeg build.
# The resulting libOpenCvSharpExtern.so depends only on glibc / libstdc++.
#
# FFmpeg is LGPL v2.1+, statically linked.  See https://ffmpeg.org/legal.html

set -euxo pipefail

INSTALL_PREFIX=/opt/ffmpeg
NPROC=$(nproc)
BUILD_DIR=/tmp/ffmpeg-build

FFMPEG_VERSION=7.1.1

mkdir -p "${BUILD_DIR}" "${INSTALL_PREFIX}"
cd "${BUILD_DIR}"

# Reuse an existing FFmpeg installation in mounted cache to avoid network flakiness.
if [[ -f "${INSTALL_PREFIX}/lib/pkgconfig/libavcodec.pc" ]]; then
    echo "FFmpeg already installed at ${INSTALL_PREFIX}; skipping rebuild"
    exit 0
fi

# ---------------------------------------------------------------------------
# System build tools (nasm/yasm required by FFmpeg's assembly optimisations)
# ---------------------------------------------------------------------------
dnf install -y nasm yasm

# ---------------------------------------------------------------------------
# FFmpeg (LGPL v2.1+ — statically linked, no patented external codecs)
# Internal decoders cover H.264, H.265, VP8, VP9, MPEG-4, MPEG-2, and many others.
# ---------------------------------------------------------------------------
curl -fL --retry 5 --retry-delay 2 --retry-all-errors \
    "https://ffmpeg.org/releases/ffmpeg-${FFMPEG_VERSION}.tar.xz" \
    -o ffmpeg.tar.xz
tar xf ffmpeg.tar.xz
cd "ffmpeg-${FFMPEG_VERSION}"
./configure \
    --prefix="${INSTALL_PREFIX}" \
    --enable-static \
    --disable-shared \
    --enable-pic \
    --disable-asm \
    --disable-doc \
    --disable-programs \
    --disable-debug \
    --disable-network \
    --disable-avdevice \
    --disable-postproc \
    --enable-avcodec \
    --enable-avformat \
    --enable-avutil \
    --enable-swscale \
    --enable-swresample
make -j"${NPROC}"
make install

echo "FFmpeg installed to ${INSTALL_PREFIX}"
