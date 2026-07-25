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
# FFmpeg (LGPL v2.1+ — statically linked, no patented external codecs)
# Internal decoders cover H.264, H.265, VP8, VP9, MPEG-4, MPEG-2, and many others.
# Networking remains enabled so videoio can open RTSP and other network streams.
# External-library autodetection is disabled so the feature set and final ELF
# dependencies do not change when the manylinux image adds a development package.
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

CONFIGURE_FLAGS=(
    --prefix="${INSTALL_PREFIX}"
    --enable-static
    --disable-shared
    --enable-pic
    --disable-asm
    --disable-autodetect
    --disable-doc
    --disable-programs
    --disable-debug
    --enable-network
    --enable-iconv
    --disable-avdevice
    --disable-avfilter
    --disable-postproc
    --disable-swresample
    --enable-avcodec
    --enable-avformat
    --enable-avutil
    --enable-swscale
    --disable-vaapi
    --disable-vdpau
    --disable-v4l2-m2m
    --disable-libdrm
)

./configure "${CONFIGURE_FLAGS[@]}"
make -j"${NPROC}"
make install

INVENTORY_DIR="${INSTALL_PREFIX}/share/opencvsharp"
INVENTORY_PATH="${INVENTORY_DIR}/ffmpeg-feature-inventory.txt"
mkdir -p "${INVENTORY_DIR}"

{
    echo "FFmpeg ${FFMPEG_VERSION}"
    echo
    echo "[configure-flags]"
    printf '%s\n' "${CONFIGURE_FLAGS[@]}"

    for component in protocol demuxer muxer decoder encoder; do
        echo
        echo "[${component}s]"
        awk -v suffix="_${component^^}" '
            $1 == "#define" && $3 == "1" && index($2, "CONFIG_") == 1 &&
                substr($2, length($2) - length(suffix) + 1) == suffix {
                name = substr($2, length("CONFIG_") + 1)
                name = substr(name, 1, length(name) - length(suffix))
                print tolower(name)
            }
        ' config_components.h | sort
    done

    echo
    echo "[tls-backends]"
    for backend in gnutls libtls mbedtls openssl schannel securetransport; do
        value=$(awk -v macro="CONFIG_${backend^^}" '$1 == "#define" && $2 == macro { print $3 }' config.h)
        echo "${backend}=${value:-0}"
    done
} > "${INVENTORY_PATH}"

echo "FFmpeg feature inventory written to ${INVENTORY_PATH}"
echo "FFmpeg installed to ${INSTALL_PREFIX}"
