#!/usr/bin/env bash

set -euo pipefail

INVENTORY_PATH=${1:-/opt/ffmpeg/share/opencvsharp/ffmpeg-feature-inventory.txt}

if [[ ! -f "${INVENTORY_PATH}" ]]; then
    echo "ERROR: FFmpeg feature inventory not found: ${INVENTORY_PATH}"
    exit 1
fi

feature_enabled()
{
    local section=$1
    local feature=$2
    awk -v section="[${section}]" -v feature="${feature}" '
        $0 == section { in_section = 1; next }
        /^\[/ { in_section = 0 }
        in_section && $0 == feature { found = 1 }
        END { exit found ? 0 : 1 }
    ' "${INVENTORY_PATH}"
}

require_feature()
{
    local section=$1
    local feature=$2
    if feature_enabled "${section}" "${feature}"; then
        echo "OK: ${section}/${feature}"
    else
        echo "ERROR: required FFmpeg feature is disabled: ${section}/${feature}"
        return 1
    fi
}

for protocol in file pipe tcp udp; do
    require_feature protocols "${protocol}"
done

for demuxer in matroska mov rtsp; do
    require_feature demuxers "${demuxer}"
done

for muxer in avi matroska mov; do
    require_feature muxers "${muxer}"
done

for decoder in h264 hevc mjpeg mpeg4 vp8 vp9; do
    require_feature decoders "${decoder}"
done

for encoder in ffv1 mjpeg mpeg4 rawvideo; do
    require_feature encoders "${encoder}"
done

for protocol in https tls; do
    if feature_enabled protocols "${protocol}"; then
        echo "ERROR: secure protocol is enabled without an approved TLS dependency policy: ${protocol}"
        exit 1
    fi
done

if ! grep -qx -- '--disable-autodetect' "${INVENTORY_PATH}"; then
    echo "ERROR: FFmpeg was built without --disable-autodetect"
    exit 1
fi

if grep -Eq '^(gnutls|libtls|mbedtls|openssl|schannel|securetransport)=1$' "${INVENTORY_PATH}"; then
    echo "ERROR: an unapproved TLS backend was enabled"
    grep -E '^(gnutls|libtls|mbedtls|openssl|schannel|securetransport)=' "${INVENTORY_PATH}"
    exit 1
fi

echo
for section in protocols demuxers muxers decoders encoders; do
    count=$(awk -v section="[${section}]" '
        $0 == section { in_section = 1; next }
        /^\[/ { in_section = 0 }
        in_section && NF { count++ }
        END { print count + 0 }
    ' "${INVENTORY_PATH}")
    echo "${section}: ${count} enabled"
done
echo "Full inventory: ${INVENTORY_PATH}"
