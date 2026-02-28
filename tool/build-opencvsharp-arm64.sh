#!/usr/bin/env bash
set -e

ROOT_DIR=$(pwd)
INSTALL_PREFIX="$ROOT_DIR/opencv-install"
RUNTIME_DIR="$ROOT_DIR/runtimes/linux-arm64/native"

echo "=== Build OpenCV with contrib ==="

cd "$ROOT_DIR/opencv"
rm -rf build
mkdir build && cd build

cmake .. \
  -DCMAKE_BUILD_TYPE=Release \
  -DCMAKE_INSTALL_PREFIX="$INSTALL_PREFIX" \
  -DOPENCV_EXTRA_MODULES_PATH="$ROOT_DIR/opencv_contrib/modules" \
  -DBUILD_SHARED_LIBS=ON \
  -DBUILD_TESTS=OFF \
  -DBUILD_PERF_TESTS=OFF \
  -DBUILD_EXAMPLES=OFF \
  -DBUILD_opencv_apps=OFF \
  -DWITH_V4L=ON \
  -DWITH_GSTREAMER=ON \
  -DWITH_FFMPEG=ON

make -j$(nproc)
make install

echo "=== Build OpenCvSharpExtern ==="

cd "$ROOT_DIR/opencvsharp/src"
rm -rf build
mkdir build && cd build

cmake .. \
  -DCMAKE_BUILD_TYPE=Release \
  -DOpenCV_DIR="$INSTALL_PREFIX/lib/cmake/opencv4"

make -j$(nproc)

echo "=== Collect .so files ==="

mkdir -p "$RUNTIME_DIR"
rm -f "$RUNTIME_DIR"/*.so*

# Copy OpenCV libs
cp "$INSTALL_PREFIX/lib/libopencv_"*.so* "$RUNTIME_DIR/"

# Copy OpenCvSharpExtern
cp "$ROOT_DIR/opencvsharp/src/build/OpenCvSharpExtern/libOpenCvSharpExtern.so" "$RUNTIME_DIR/"

echo "=== Final contents ==="
ls -lh "$RUNTIME_DIR"

echo "=== Verify dependencies ==="
ldd "$RUNTIME_DIR/libOpenCvSharpExtern.so" | grep opencv

echo "DONE."
