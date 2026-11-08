#!/usr/bin/env bash

set -euo pipefail

failed=0
check_package() {
  local pattern="$1"
  local count
  count=$(find "$PWD" -maxdepth 4 -type f -name "${pattern}" | wc -l)
  if [ "$count" -eq 0 ]; then
    echo "MISSING: $pattern"
    failed=$((failed + 1))
  else
    echo "OK: $pattern"
  fi
}

skip_has() {
  case ",${SKIP_PLATFORMS}," in
    *",$1,"*) return 0 ;;
    *) return 1 ;;
  esac
}

check_package "OpenCvSharp5.5.*.nupkg"
check_package "OpenCvSharp5.GdipExtensions.*.nupkg"
check_package "OpenCvSharp5.WpfExtensions.*.nupkg"
check_package "OpenCvSharp5.AvaloniaExtensions.*.nupkg"
check_package "OpenCvSharp5.runtime.win.[0-9]*.nupkg"
check_package "OpenCvSharp5.runtime.win-arm64.[0-9]*.nupkg"
check_package "OpenCvSharp5.runtime.win-arm64.slim.*.nupkg"
check_package "OpenCvSharp5.runtime.win.slim.*.nupkg"
check_package "OpenCvSharp5.Windows.[0-9]*.nupkg"
check_package "OpenCvSharp5.Windows.Slim.*.nupkg"

if skip_has linux-arm64; then
  echo "skip_platforms: skipping linux-arm64 package checks"
else
  check_package "OpenCvSharp5.runtime.linux-arm.*.nupkg"
  check_package "OpenCvSharp5.runtime.linux-arm64.*.nupkg"
fi

if skip_has wasm; then
  echo "skip_platforms: skipping wasm package checks"
else
  check_package "OpenCvSharp5.runtime.wasm.*.nupkg"
fi

if skip_has manylinux; then
  echo "skip_platforms: skipping manylinux package checks"
else
  check_package "OpenCvSharp5.official.runtime.linux-x64.[0-9]*.nupkg"
  check_package "OpenCvSharp5.official.runtime.linux-x64.headless.*.nupkg"
  check_package "OpenCvSharp5.official.runtime.linux-x64.slim.*.nupkg"
  check_package "OpenCvSharp5.official.runtime.linux-arm64.[0-9]*.nupkg"
  check_package "OpenCvSharp5.official.runtime.linux-arm64.headless.*.nupkg"
  check_package "OpenCvSharp5.official.runtime.linux-arm64.slim.*.nupkg"
fi

if skip_has macos; then
  echo "skip_platforms: skipping macos package checks"
else
  check_package "OpenCvSharp5.runtime.osx.x64.*.nupkg"
  check_package "OpenCvSharp5.runtime.osx.arm64.*.nupkg"
fi

if [ "$failed" -gt 0 ]; then
  echo ""
  echo "ERROR: $failed package validation issue(s). Detected .nupkg files:"
  find "$PWD" -maxdepth 4 -type f -name "*.nupkg" -print
  exit 1
fi
