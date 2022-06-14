FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as builder

ENV DEBIAN_FRONTEND=noninteractive
ENV OPENCV_VERSION=4.6.0

WORKDIR /

# Install opencv dependencies
RUN apt-get update && apt-get -y install --no-install-recommends \
      apt-transport-https \
      software-properties-common \
      wget \
      unzip \
      ca-certificates \
      build-essential \
      cmake \
      git \
      libtbb-dev \
      libatlas-base-dev \
      libgtk2.0-dev \
      libavcodec-dev \
      libavformat-dev \
      libswscale-dev \
      libdc1394-22-dev \
      libxine2-dev \
      libv4l-dev \
      libtheora-dev \
      libvorbis-dev \
      libxvidcore-dev \
      libopencore-amrnb-dev \
      libopencore-amrwb-dev \
      libavresample-dev \
      x264 \
      libtesseract-dev \
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
    -D BUILD_opencv_barcode=OFF \
    -D BUILD_opencv_java_bindings_generator=OFF \
    -D BUILD_opencv_js_bindings_generator=OFF \
    -D BUILD_opencv_python_bindings_generator=OFF \
    -D BUILD_opencv_python_tests=OFF \
    -D BUILD_opencv_ts=OFF \
    -D BUILD_opencv_js=OFF \
    -D BUILD_opencv_bioinspired=OFF \
    -D BUILD_opencv_ccalib=OFF \
    -D BUILD_opencv_datasets=OFF \
    -D BUILD_opencv_dnn_objdetect=OFF \
    -D BUILD_opencv_dpm=OFF \
    -D BUILD_opencv_fuzzy=OFF \
    -D BUILD_opencv_gapi=OFF \
    -D BUILD_opencv_intensity_transform=OFF \
    -D BUILD_opencv_mcc=OFF \
    -D BUILD_opencv_objc_bindings_generator=OFF \
    -D BUILD_opencv_rapid=OFF \
    -D BUILD_opencv_reg=OFF \
    -D BUILD_opencv_stereo=OFF \
    -D BUILD_opencv_structured_light=OFF \
    -D BUILD_opencv_surface_matching=OFF \
    -D BUILD_opencv_videostab=OFF \
    -D BUILD_opencv_wechat_qrcode=ON \
    -D WITH_GSTREAMER=OFF \
    -D WITH_ADE=OFF \
    -D OPENCV_ENABLE_NONFREE=ON \
    .. && make -j$(nproc) && make install && ldconfig

# Download OpenCvSharp
RUN git clone https://github.com/shimat/opencvsharp.git && cd opencvsharp

# Install the Extern lib.
RUN mkdir /opencvsharp/make && cd /opencvsharp/make && \
    cmake -D CMAKE_INSTALL_PREFIX=/opencvsharp/make /opencvsharp/src && \
    make -j$(nproc) && make install && \
    rm -rf /opencv && \
    rm -rf /opencv_contrib && \
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /usr/lib/


########## Test native .so file ##########

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
RUN apt-get update && apt-get -y install --no-install-recommends gcc
# /usr/lib/libOpenCvSharpExtern.so
# /usr/local/lib/libopencv_*.a
COPY --from=builder /usr/lib /usr/lib
#COPY --from=builder /usr/local/lib /usr/local/lib

RUN echo "\n\
#include <stdio.h> \n\
int core_Mat_sizeof(); \n\
int main(){ \n\
  int i = core_Mat_sizeof(); \n\
  printf(\"sizeof(Mat) = %d\", i); \n\
  return 0; \n\
}" > /test.c && \
    gcc -I./ -L./ test.c -o test -lOpenCvSharpExtern && \
    LD_LIBRARY_PATH=. ./test 


########## Test .NET class libraries ##########

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
COPY --from=builder /usr/lib /usr/lib
# Install Build the C# part of OpenCvSharp
RUN git clone https://github.com/shimat/opencvsharp.git && cd opencvsharp
RUN cd /opencvsharp/src/OpenCvSharp && \
    dotnet build -c Release -f net6.0 && \
    cd /opencvsharp/src/OpenCvSharp.Extensions && \
    dotnet build -c Release -f net6.0

RUN dotnet test /opencvsharp/test/OpenCvSharp.Tests/OpenCvSharp.Tests.csproj -c Release -f net6.0 --runtime ubuntu.20.04-x64 --logger "trx;LogFileName=test-results.trx" < /dev/null

# Simple console app test using NuGet
# RUN dotnet new console -f net6.0 -o "ConsoleApp01" && cd /ConsoleApp01 && \
#     echo "\n\
# using System; \n\
# using OpenCvSharp; \n\
# class Program{ \n\
#   static void Main(){ \n\
#     Console.WriteLine(Cv2.GetTickCount()); \n\
#     using var mat = new Mat(1, 1, MatType.CV_8UC1); \n\
#     Console.WriteLine(mat.CvPtr); \n\
#   } \n\
# }" > Program.cs && \
#     dotnet add package OpenCvSharp4 && \
#     dotnet run && \
#     rm -rf /ConsoleApp01

#RUN ldd /artifacts/libOpenCvSharpExtern.so



########## Final image ##########

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as final
COPY --from=builder /usr/lib /usr/lib
