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
# Hwaccel autodetection (vaapi/vdpau/v4l2-m2m) is disabled explicitly: this build
# never uses hardware acceleration, but if libva happens to be present in the
# build container, FFmpeg's configure would auto-enable vaapi and silently add
# libdrm.so.2 as a runtime dependency of the final .so. See issue #2065.
# libdrm itself is a separate autodetected component (not gated by the vaapi/
# vdpau/v4l2-m2m flags above): manylinux_2_28_x86_64 ships libdrm-devel out of
# the box, so configure enables CONFIG_LIBDRM unless disabled explicitly here,
# which still pulls in libdrm.so.2 via hwcontext_drm even with every hwaccel
# backend above turned off. See issue #2071.
# ---------------------------------------------------------------------------
curl -fL --retry 5 --retry-delay 2 \
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
    --enable-swresample \
    --disable-vaapi \
    --disable-vdpau \
    --disable-v4l2-m2m \
    --disable-libdrm
make -j"${NPROC}"
make install

echo "FFmpeg installed to ${INSTALL_PREFIX}"
