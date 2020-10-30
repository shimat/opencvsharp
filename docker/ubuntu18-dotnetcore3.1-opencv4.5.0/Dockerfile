FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-native-env

ENV OPENCV_VERSION=4.5.0

WORKDIR /

RUN apt-get update && apt-get -y install --no-install-recommends \
    apt-transport-https \
    software-properties-common \
    wget \
    unzip \
    curl \
    ca-certificates
    #bzip2 \
    #grep sed dpkg 

# Install opencv dependencies
RUN apt-get update && apt-get -y install --no-install-recommends \
      build-essential \
      cmake \
      git \
      gfortran \
      libjpeg8-dev \
      libpng-dev \
      software-properties-common
RUN add-apt-repository "deb http://security.ubuntu.com/ubuntu xenial-security main" && apt-get update && apt-get -y install --no-install-recommends \
      libjasper1 \
      libtiff-dev \
      libavcodec-dev \
      libavformat-dev \
      libswscale-dev \
      libdc1394-22-dev \
      libxine2-dev \
      libv4l-dev

RUN cd /usr/include/linux && \
    ln -s -f ../libv4l1-videodev.h videodev.h && \
    cd ~ 
RUN apt-get update && apt-get -y install --no-install-recommends \
      libgtk2.0-dev \
      libtbb-dev \
      qt5-default \
      libatlas-base-dev \
      libfaac-dev \
      libmp3lame-dev \
      libtheora-dev \
      libvorbis-dev \
      libxvidcore-dev \
      libopencore-amrnb-dev \
      libopencore-amrwb-dev \
      libavresample-dev \
      x264 \
      v4l-utils \
      libwebp-dev 
RUN apt-get update && apt-get -y install --no-install-recommends \
      tesseract-ocr libtesseract-dev libleptonica-dev \
      libgdiplus \
    && apt-get -y clean \
    && rm -rf /var/lib/apt/lists/*

# Setup opencv and opencv-contrib source
RUN wget https://github.com/opencv/opencv/archive/${OPENCV_VERSION}.zip && \
    unzip ${OPENCV_VERSION}.zip && \
    rm ${OPENCV_VERSION}.zip && \
    mv opencv-${OPENCV_VERSION} opencv && \
    wget https://github.com/opencv/opencv_contrib/archive/${OPENCV_VERSION}.zip && \
    unzip ${OPENCV_VERSION}.zip && \
    rm ${OPENCV_VERSION}.zip && \
    mv opencv_contrib-${OPENCV_VERSION} opencv_contrib

# Build OpenCV
RUN cd opencv && mkdir build && cd build && \
    cmake \
    -D OPENCV_EXTRA_MODULES_PATH=/opencv_contrib/modules \
    -D CMAKE_BUILD_TYPE=RELEASE \
    -D BUILD_SHARED_LIBS=OFF \
    -D ENABLE_CXX11=ON \
    -D BUILD_EXAMPLES=OFF \
    -D BUILD_DOCS=OFF \
    -D BUILD_PERF_TESTS=OFF \
    -D BUILD_TESTS=OFF \
    -D BUILD_JAVA=OFF \
    -D BUILD_opencv_app=OFF \
    -D BUILD_opencv_java_bindings_generator=OFF \
    -D BUILD_opencv_python_bindings_generator=OFF \
    -D BUILD_opencv_python_tests=OFF \
    -D BUILD_opencv_ts=OFF \
    -D BUILD_opencv_js=OFF \ 
    -D BUILD_opencv_bioinspired=OFF \
    -D BUILD_opencv_ccalib=OFF \
    -D BUILD_opencv_datasets=OFF \
    -D BUILD_opencv_dnn_objdetect=OFF \
    -D BUILD_opencv_dnn_superres=OFF \
    -D BUILD_opencv_dpm=OFF \
    -D BUILD_opencv_fuzzy=OFF \
    -D BUILD_opencv_gapi=OFF \
    -D BUILD_opencv_intensity_transform=OFF \
    -D BUILD_opencv_mcc=OFF \
    -D BUILD_opencv_rapid=OFF \
    -D BUILD_opencv_reg=OFF \
    -D BUILD_opencv_stereo=OFF \
    -D BUILD_opencv_structured_light=OFF \
    -D BUILD_opencv_surface_matching=OFF \
    -D BUILD_opencv_videostab=OFF \
    -D WITH_GSTREAMER=OFF \ 
    -D OPENCV_ENABLE_NONFREE=ON \
    .. && make -j6 && make install && ldconfig

# Download OpenCvSharp
RUN git clone https://github.com/shimat/opencvsharp.git && cd opencvsharp

# Install the Extern lib.
RUN mkdir /opencvsharp/make && cd /opencvsharp/make && \
    cmake -D CMAKE_INSTALL_PREFIX=/opencvsharp/make /opencvsharp/src && \
    make -j && make install && \
    rm -rf /opencv && \
    rm -rf /opencv_contrib && \
    mkdir /artifacts && \
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /artifacts/

# Install Build the C# part of OpenCvSharp
#RUN cd /opencvsharp/src/OpenCvSharp && \
#    dotnet build -c Release -f netstandard2.1 && \
#    cd /opencvsharp/src/OpenCvSharp.Blob && \
#    dotnet build -c Release -f netstandard2.1 && \
#    cd /opencvsharp/src/OpenCvSharp.Extensions && \
#    dotnet build -c Release -f netstandard2.1 && \
#    cp /opencvsharp/src/OpenCvSharp/bin/Release/netstandard2.1/* artifacts/ && \
#    cp /opencvsharp/src/OpenCvSharp.Blob/bin/Release/netstandard2.1/* artifacts/ && \
#    cp /opencvsharp/src/OpenCvSharp.Extensions/bin/Release/netstandard2.1/* artifacts/ 

# Test OpenCvSharpExtern
RUN cp artifacts/libOpenCvSharpExtern.so /usr/lib/ && \
    echo "\n\
#include <stdio.h> \n\
int core_Mat_sizeof(); \n\
int main(){ \n\
  int i = core_Mat_sizeof(); \n\
  printf(\"sizeof(Mat) = %d\", i); \n\
  return 0; \n\
}" > /test.c && \
    gcc -I./ -L./ test.c -o test -lOpenCvSharpExtern && \
    LD_LIBRARY_PATH=. ./test && \
    rm -f /test*

# Test OpenCvSharp
#RUN dotnet test /opencvsharp/test/OpenCvSharp.Tests/OpenCvSharp.Tests.csproj -c Release -f netcoreapp3.1 --runtime ubuntu.18.04-x64 --logger "trx;LogFileName=test-results.trx" < /dev/null


RUN rm -rf /opencvsharp

# Simple console app test using NuGet
RUN dotnet new console -f netcoreapp3.1 -o "ConsoleApp01" && cd /ConsoleApp01 && \
    echo "\n\
using System; \n\
using OpenCvSharp; \n\
class Program{ \n\
  static void Main(){ \n\
    Console.WriteLine(Cv2.GetTickCount()); \n\
    using var mat = new Mat(1, 1, MatType.CV_8UC1); \n\
    Console.WriteLine(mat.CvPtr); \n\
  } \n\
}" > Program.cs && \
    dotnet add package OpenCvSharp4 && \
    dotnet run && \
    rm -rf /ConsoleApp01
