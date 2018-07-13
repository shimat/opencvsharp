FROM ubuntu:17.10

ENV OPENCV_VERSION=3.4.1
ENV OPENCVSHARP_VERSION=3.4.1.20180605
#ENV OPENCVSHARP_VERSION=3.4.1.20180320
ENV DOTNETCORE_SDK=2.1.104

RUN apt-get update && apt-get install -y apt-transport-https software-properties-common \
wget unzip curl nano git bzip2 ca-certificates grep sed dpkg libicu57

#install DotNetCore
RUN cd ~
RUN curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
RUN mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
RUN sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-artful-prod artful main" > /etc/apt/sources.list.d/dotnetdev.list'
RUN apt-get update
RUN apt-cache madison dotnet-host
RUN apt-get -y install dotnet-host=2.0.6-1 dotnet-sdk-${DOTNETCORE_SDK}

# Install opencv dependencies
RUN apt-get install -y build-essential cmake \
libgtkglext1-dev libvtk6-dev \
zlib1g-dev libjpeg-dev libwebp-dev libpng-dev libtiff5-dev libopenexr-dev libgdal-dev && \
add-apt-repository "deb http://security.ubuntu.com/ubuntu xenial-security main" && apt update && apt install libjasper1 libjasper-dev && \
apt-get install -y libdc1394-22-dev libavcodec-dev libavformat-dev libswscale-dev libtheora-dev libvorbis-dev libxvidcore-dev libx264-dev yasm libopencore-amrnb-dev libopencore-amrwb-dev libv4l-dev libxine2-dev \
libtbb-dev libeigen3-dev \
python-dev python-tk python-numpy python3-dev python3-tk python3-numpy

# Setup OpenCV Source
RUN wget https://github.com/opencv/opencv/archive/${OPENCV_VERSION}.zip && unzip ${OPENCV_VERSION}.zip && rm ${OPENCV_VERSION}.zip && mv opencv-${OPENCV_VERSION} OpenCV

# Setup opencv-contrib Source
RUN wget https://github.com/opencv/opencv_contrib/archive/${OPENCV_VERSION}.zip && unzip ${OPENCV_VERSION}.zip && rm ${OPENCV_VERSION}.zip && mv opencv_contrib-${OPENCV_VERSION} OpenCV_contrib

# Build OpenCV
RUN cd OpenCV && mkdir build && cd build && \
cmake \
-D OPENCV_EXTRA_MODULES_PATH=/OpenCV_contrib/modules \
-D CMAKE_BUILD_TYPE=RELEASE \
-D BUILD_EXAMPLES=OFF \
-D BUILD_DOCS=OFF \
-D BUILD_PERF_TESTS=OFF \
-D BUILD_TESTS=OFF \
-D BUILD_opencv_java=OFF \
-D BUILD_opencv_python=OFF \
.. && make -j4 && make install && ldconfig

WORKDIR /

# Download OpenCvSharp
RUN git clone https://github.com/shimat/opencvsharp.git
RUN cd opencvsharp && git fetch --all --tags --prune && git checkout ${OPENCVSHARP_VERSION}

# Install the Extern lib.
WORKDIR /opencvsharp/src
RUN mkdir /opencvsharp/make
#RUN cd /opencvsharp/make
RUN cd /opencvsharp/make && cmake -D CMAKE_INSTALL_PREFIX=/opencvsharp/make /opencvsharp/src && make -j 4 && make install

# Install Build the C# part of OpenCvSharp
WORKDIR /opencvsharp/src/OpenCvSharp
RUN dotnet restore
RUN dotnet build -c Release -f netstandard2.0 

WORKDIR /opencvsharp/src/OpenCvSharp.Blob
RUN dotnet restore
RUN dotnet build -c Release -f netstandard2.0 

WORKDIR /opencvsharp/src/OpenCvSharp.Extensions
RUN dotnet restore
RUN dotnet build -c Release -f netstandard2.0 

RUN mkdir /opencvsharp/build
WORKDIR /opencvsharp/build
RUN cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so .
RUN cp /opencvsharp/src/OpenCvSharp/bin/Release/netstandard2.0/* .
RUN cp /opencvsharp/src/OpenCvSharp.Blob/bin/Release/netstandard2.0/* .
RUN cp /opencvsharp/src/OpenCvSharp.Extensions/bin/Release/netstandard2.0/* .
