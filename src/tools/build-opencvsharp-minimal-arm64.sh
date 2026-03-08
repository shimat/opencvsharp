#!/usr/bin/env bash
set -e

# Minimal OpenCV + OpenCvSharpExtern build for linux-arm64
# This build excludes: contrib, stitching, calib3d, video, features2d, flann,
#                      dnn, ml, objdetect, photo, barcode, shape, superres, xphoto
# Includes: core, imgproc, imgcodecs, videoio, highgui

ROOT_DIR=$(pwd)
INSTALL_PREFIX="/opt/opencv-nocontrib"
RUNTIME_DIR="$ROOT_DIR/runtimes/linux-arm64/native"

echo "=== Build OpenCV (minimal feature set) ==="

cd "$ROOT_DIR/opencv"
rm -rf build
mkdir build && cd build

cmake .. \
  -DCMAKE_BUILD_TYPE=Release \
  -DCMAKE_INSTALL_PREFIX="$INSTALL_PREFIX" \
  -DBUILD_SHARED_LIBS=ON \
  -DBUILD_TESTS=OFF \
  -DBUILD_PERF_TESTS=OFF \
  -DBUILD_EXAMPLES=OFF \
  -DBUILD_opencv_apps=OFF \
  -DBUILD_opencv_dnn=OFF \
  -DBUILD_opencv_ml=OFF \
  -DBUILD_opencv_objdetect=OFF \
  -DBUILD_opencv_photo=OFF \
  -DBUILD_opencv_stitching=OFF \
  -DBUILD_opencv_video=OFF \
  -DBUILD_opencv_calib3d=OFF \
  -DBUILD_opencv_features2d=OFF \
  -DBUILD_opencv_flann=OFF \
  -DBUILD_opencv_shape=OFF \
  -DBUILD_opencv_superres=OFF \
  -DBUILD_opencv_xphoto=OFF \
  -DBUILD_opencv_highgui=ON \
  -DBUILD_opencv_imgproc=ON \
  -DBUILD_opencv_imgcodecs=ON \
  -DBUILD_opencv_videoio=ON \
  -DWITH_GSTREAMER=ON \
  -DWITH_FFMPEG=ON \
  -DWITH_V4L=ON

make -j$(nproc)
sudo make install

echo "=== Build OpenCvSharpExtern (minimal feature set) ==="

cd "$ROOT_DIR/opencvsharp/src"
rm -rf build
mkdir build && cd build

cmake .. \
  -DCMAKE_BUILD_TYPE=Release \
  -DOpenCV_DIR="$INSTALL_PREFIX/lib/cmake/opencv4" \
  -DNO_CONTRIB=ON \
  -DNO_STITCHING=ON \
  -DNO_CALIB3D=ON \
  -DNO_VIDEO=ON \
  -DNO_FEATURES2D=ON \
  -DNO_FLANN=ON \
  -DNO_DNN=ON \
  -DNO_ML=ON \
  -DNO_OBJDETECT=ON \
  -DNO_PHOTO=ON \
  -DNO_BARCODE=ON

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
ldd "$RUNTIME_DIR/libOpenCvSharpExtern.so" | grep opencv || true

echo "DONE."
