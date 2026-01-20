# Building OpenCV and OpenCvSharpExtern for your Embedded Platform

Using a Raspberry Pi with a 64-bit build of Debian Trixie (Lite is fine)

If you want a build of OpenCV that minimizes the on-disk footprint, you can turn off features (i.e. omit them from the build) for a custom OpenCV build.  If you do this, you must also build a custom OpenCvExtern library that matches your configuration

## Feature Sets

[TODO: create a feature table]

## Example

Let's say your app needs to connect to a USB camera and simply capture frames from it.  You'll want these features:

[TBD]

So you'll need to build a custom set of OpenCV libraries first.  Directly on your Raspberry Pi, do the following (Recommend a Pi 5 for compiling speed, but earier versions work just fine as well).

### Building OpenCV from Source
First, you have to clone and build OpenCV with your features

Make sure you have all of the dev tools installed
```
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

Now clone the OpenCV code

```
cd ~
git clone --branch 4.10.0 https://github.com/opencv/opencv.git
``
Now we need to configure the cmake build for your desired feature set
```
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
And now we'll build the libraries.  Not that the config above puts the output into `/opt/opencv-nocontrib`.  You can adjust that as you see fit, but you will need it for the config process for `OpenCvSharpExtern`.
```
make -j$(nproc)
sudo make install
```
### Building OpenCvSharpExtern from Source

Here we continue the build process from above.  You must have already built OpenCV above and you will need the install path from above if you adjusted it.

First, clone the code

```
cd ~
git clone https://github.com/ctacke/opencvsharp.git
cd opencvsharp/src
```

Now configure this build to match the features you included in OpenCV.  This is absolutely a manual process, so the list below only matches the build from above.  Refer to the earlier feature table for your specific needs.

```
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
  -DNO_PHOTO=ON
```