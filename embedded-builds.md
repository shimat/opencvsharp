# Building OpenCV and OpenCvSharpExtern for your Embedded Platform

Using a Raspberry Pi with a 64-bit build of Debian Trixie (Lite is fine)

If you want a build of OpenCV that minimizes the on-disk footprint, you can turn off features (i.e. omit them from the build) for a custom OpenCV build.  If you do this, you must also build a custom OpenCvSharpExtern library that matches your configuration.

## Feature Sets

The following table shows the available OpenCV modules and their corresponding OpenCvSharpExtern exclusion flags:

| OpenCV Module | OpenCV CMake Flag | OpenCvSharpExtern Flag | Description |
|---------------|-------------------|------------------------|-------------|
| core | (always included) | (always included) | Core functionality (Mat, basic operations) |
| imgproc | BUILD_opencv_imgproc | (always included) | Image processing (resize, filters, color conversion) |
| imgcodecs | BUILD_opencv_imgcodecs | (always included) | Image file reading/writing |
| videoio | BUILD_opencv_videoio | NO_VIDEOIO | Video capture and writing |
| highgui | BUILD_opencv_highgui | NO_HIGHGUI | GUI windows and trackbars |
| video | BUILD_opencv_video | NO_VIDEO | Video analysis (optical flow, background subtraction) |
| calib3d | BUILD_opencv_calib3d | NO_CALIB3D | Camera calibration, 3D reconstruction |
| features2d | BUILD_opencv_features2d | NO_FEATURES2D | 2D feature detection (ORB, SIFT, etc.) |
| flann | BUILD_opencv_flann | NO_FLANN | Fast approximate nearest neighbor searches |
| dnn | BUILD_opencv_dnn | NO_DNN | Deep neural network inference |
| ml | BUILD_opencv_ml | NO_ML | Machine learning (SVM, decision trees, etc.) |
| objdetect | BUILD_opencv_objdetect | NO_OBJDETECT | Object detection (cascade classifiers, QR codes) |
| photo | BUILD_opencv_photo | NO_PHOTO | Computational photography (inpainting, HDR) |
| stitching | BUILD_opencv_stitching | NO_STITCHING | Image stitching and panorama creation |
| shape | BUILD_opencv_shape | NO_CONTRIB | Shape matching |
| superres | BUILD_opencv_superres | NO_CONTRIB | Super resolution |
| contrib modules | OPENCV_EXTRA_MODULES_PATH | NO_CONTRIB | All opencv_contrib modules (aruco, face, tracking, etc.) |
| barcode | (part of contrib) | NO_BARCODE | Barcode detection |

## Example: USB Camera Frame Capture

Let's say your app needs to connect to a USB camera and simply capture frames from it. You'll need these features:

- **core** - Basic Mat operations
- **imgproc** - Image processing (color conversion, resizing)
- **imgcodecs** - Saving captured frames to disk
- **videoio** - Camera capture via V4L2/FFMPEG
- **highgui** - Optional, for displaying frames in a window

You do NOT need: video, calib3d, features2d, flann, dnn, ml, objdetect, photo, stitching, or any contrib modules.

So you'll need to build a custom set of OpenCV libraries first. Directly on your Raspberry Pi, do the following (Recommend a Pi 5 for compiling speed, but earlier versions work just fine as well).

## Build Scripts

Two build scripts are provided for convenience:

| Script | Description | Output Size |
|--------|-------------|-------------|
| [build-opencvsharp-arm64.sh](tool/build-opencvsharp-arm64.sh) | Full build with all features and contrib modules | ~140MB |
| [build-opencvsharp-minimal-arm64.sh](tool/build-opencvsharp-minimal-arm64.sh) | Minimal build for basic camera capture | ~25MB |

To use either script:
```bash
cd ~
git clone https://github.com/opencv/opencv.git
git clone https://github.com/opencv/opencv_contrib.git  # only needed for full build
git clone https://github.com/shimat/opencvsharp.git

cd ~/opencv
git fetch --tags
git checkout 4.10.0

# Only for full build:
cd ~/opencv_contrib
git fetch --tags
git checkout 4.10.0

# Run the desired build script
cd ~
chmod +x ~/opencvsharp/tool/build-opencvsharp-minimal-arm64.sh
~/opencvsharp/tool/build-opencvsharp-minimal-arm64.sh
```

## Building a full OpenCV feature set - large (~140MB) output

First, you can run with a full-featured set of binaries. It's large, and contains probably things you don't need, but it works.

[A script to do the full-up build for linux-arm64 is available here](tool/build-opencvsharp-arm64.sh), but below are the manual instructions.

```bash
cd ~
git clone https://github.com/opencv/opencv.git
git clone https://github.com/opencv/opencv_contrib.git

cd ~/opencv
git fetch --tags
git checkout 4.10.0
cd ~/opencv_contrib
git fetch --tags
git checkout 4.10.0
```

## Building a subset

You can build a subset, but it takes some work. The way Linux libraries link, you have to handle all of the dependencies. You can't simply rebuild OpenCV with fewer features and have it work. OpenCvSharpExtern is linked to the endpoints of all of the features in OpenCV, so if some of them are missing, loading `libOpenCvSharpExtern.so` will fail even if you aren't using the missing features. You must rebuild both, and the original OpenCVSharpExtern is not created to make this friendly.

This repository attempts to address that by providing better support for minimal, configurable builds.

[A script to do a minimal build for linux-arm64 is available here](tool/build-opencvsharp-minimal-arm64.sh), but below are the manual instructions.

### Building OpenCV from Source

First, you have to clone and build OpenCV with your desired features. This is supported and fairly well documented for OpenCV.

Make sure you have all of the dev tools installed:
```bash
sudo apt update
sudo apt install -y \
  build-essential \
  cmake \
  git \
  pkg-config \
  libgtk-3-dev \
  libavcodec-dev \
  libavformat-dev \
  libswscale-dev \
  libv4l-dev
```

Now clone the OpenCV code:

```bash
cd ~
git clone https://github.com/opencv/opencv.git

cd ~/opencv
git fetch --tags
git checkout 4.10.0
```

Now you need to configure the cmake build for your desired feature set:
```bash
cd ~/opencv
mkdir build
cd build
cmake .. \
  -DCMAKE_BUILD_TYPE=Release \
  -DCMAKE_INSTALL_PREFIX=/opt/opencv-nocontrib \
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
```

And now build the libraries. This will take a while. Note that the config above puts the output into `/opt/opencv-nocontrib`. You can adjust that as you see fit, but you will need it for the config process for `OpenCvSharpExtern`.
```bash
make -j$(nproc)
sudo make install
```

### Building OpenCvSharpExtern from Source

Here we continue the build process from above. You must have already built OpenCV above and you will need the install path from above if you adjusted it.

First, clone the OpenCvSharp repository that contains the matching build configuration.

```bash
cd ~
git clone https://github.com/shimat/opencvsharp.git
cd opencvsharp/src
```

Now configure this build to match the features you included in OpenCV. This is absolutely a manual process, so the list below only matches the build from above. Refer to the earlier feature table for your specific needs.

```bash
mkdir ~/opencvsharp/src/build
cd ~/opencvsharp/src/build

cmake .. \
  -DCMAKE_BUILD_TYPE=Release \
  -DOpenCV_DIR=/opt/opencv-nocontrib/lib/cmake/opencv4 \
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
```

And now build the libOpenCvSharpExtern binary:

```bash
make -j$(nproc)
```

### Collecting the Output

After building, you'll find:
- OpenCV libraries in `/opt/opencv-nocontrib/lib/`
- OpenCvSharpExtern in `~/opencvsharp/src/build/OpenCvSharpExtern/libOpenCvSharpExtern.so`

Copy all required `.so` files to your application's runtime directory:

```bash
mkdir -p ~/myapp/runtimes/linux-arm64/native
cp /opt/opencv-nocontrib/lib/libopencv_*.so* ~/myapp/runtimes/linux-arm64/native/
cp ~/opencvsharp/src/build/OpenCvSharpExtern/libOpenCvSharpExtern.so ~/myapp/runtimes/linux-arm64/native/
```

Verify the dependencies are satisfied:
```bash
ldd ~/myapp/runtimes/linux-arm64/native/libOpenCvSharpExtern.so | grep "not found"
```

If no output, all dependencies are satisfied.
