#!/usr/bin/env bash
set -euo pipefail

readonly mediamtx_version="$1"
readonly expected_checksum="$2"
readonly archive_name="mediamtx_v${mediamtx_version}_darwin_arm64.tar.gz"
readonly download_base="https://github.com/bluenviron/mediamtx/releases/download/v${mediamtx_version}"
readonly server_dir="${RUNNER_TEMP}/mediamtx"
readonly archive_path="${RUNNER_TEMP}/${archive_name}"
readonly log_path="${RUNNER_TEMP}/mediamtx.log"
server_pid=""

cleanup() {
  local status=$?
  trap - EXIT

  if [[ "${status}" -ne 0 && -f "${log_path}" ]]; then
    cat "${log_path}"
  fi
  if [[ -n "${server_pid}" ]] && kill -0 "${server_pid}" 2>/dev/null; then
    kill "${server_pid}" 2>/dev/null || true
    wait "${server_pid}" 2>/dev/null || true
  fi

  exit "${status}"
}
trap cleanup EXIT

curl -fL --retry 5 "${download_base}/${archive_name}" -o "${archive_path}"

actual_checksum="$(shasum -a 256 "${archive_path}" | awk '{print $1}')"
if [[ "${actual_checksum}" != "${expected_checksum}" ]]; then
  echo "Checksum mismatch for ${archive_name}: expected ${expected_checksum}, got ${actual_checksum}"
  exit 1
fi

mkdir -p "${server_dir}"
tar -xzf "${archive_path}" -C "${server_dir}"
"${server_dir}/mediamtx" "${GITHUB_WORKSPACE}/test/rtsp/mediamtx.yml" >"${log_path}" 2>&1 &
server_pid=$!

ready=false
for attempt in $(seq 1 30); do
  if ! kill -0 "${server_pid}" 2>/dev/null; then
    echo "MediaMTX exited before the stream became available"
    exit 1
  fi
  if grep -q "stream is available" "${log_path}"; then
    ready=true
    break
  fi
  sleep 1
done

if [[ "${ready}" != true ]]; then
  echo "Timed out waiting for MediaMTX"
  exit 1
fi

export OPENCVSHARP_TEST_RTSP_URL="rtsp://127.0.0.1:8554/test"
export DYLD_LIBRARY_PATH="/usr/local/lib:${GITHUB_WORKSPACE}/test/OpenCvSharp.Tests${DYLD_LIBRARY_PATH:+:${DYLD_LIBRARY_PATH}}"
dotnet test --project "${GITHUB_WORKSPACE}/test/OpenCvSharp.Tests/OpenCvSharp.Tests.csproj" \
  -c Release \
  -f net10.0 \
  --runtime osx-arm64 \
  --no-build \
  --no-restore \
  --filter-method OpenCvSharp.Tests.VideoIO.VideoCaptureTest.ReadRtspStreamWithFFmpeg \
  < /dev/null
