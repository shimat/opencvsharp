########## Build arguments ##########
ARG OPENCV_VERSION=5.0.0

########## Build OpenCV ##########
FROM ubuntu:noble AS opencv-builder

ARG OPENCV_VERSION
ENV DEBIAN_FRONTEND=noninteractive
ENV OPENCV_VERSION=${OPENCV_VERSION}
ENV CCACHE_DIR=/root/.ccache
ENV CCACHE_MAXSIZE=2G

WORKDIR /

# Install build and OpenCV dependencies (with BuildKit cache for apt)
RUN --mount=type=cache,target=/var/cache/apt \
    --mount=type=cache,target=/var/lib/apt/lists \
    set -eux; \
    apt-get -o Acquire::Retries=3 update; \
    apt-get -y install --no-install-recommends \
      apt-transport-https \
      software-properties-common \
      wget \
      unzip \
      ca-certificates \
      build-essential \
      cmake \
      git \
      ccache \
      libtbb-dev \
      libatlas-base-dev \
      libgtk-3-dev \
      libavcodec-dev \
      libavformat-dev \
      libswscale-dev \
      libdc1394-dev \
      libxine2-dev \
      libv4l-dev \
      libtheora-dev \
      libvorbis-dev \
      libxvidcore-dev \
      libopencore-amrnb-dev \
      libopencore-amrwb-dev \
      x264 \
      libtesseract-dev \
      libgdiplus \
      pkg-config \
      libavutil-dev \
      ninja-build

# Copy cmake options (needed before OpenCV configure)
COPY cmake/opencv_build_options.cmake /opencv_build_options.cmake

# Fetch OpenCV and opencv_contrib sources
RUN set -eux; \
    wget -q https://github.com/opencv/opencv/archive/${OPENCV_VERSION}.zip; \
    unzip -q ${OPENCV_VERSION}.zip; \
    rm ${OPENCV_VERSION}.zip; \
    mv opencv-${OPENCV_VERSION} /opencv; \
    wget -q https://github.com/opencv/opencv_contrib/archive/${OPENCV_VERSION}.zip; \
    unzip -q ${OPENCV_VERSION}.zip; \
    rm ${OPENCV_VERSION}.zip; \
    mv opencv_contrib-${OPENCV_VERSION} /opencv_contrib

# Configure, build, and install OpenCV with ccache and parallel build
RUN --mount=type=cache,target=/root/.ccache \
    set -eux; \
    cmake -G Ninja \
      -C /opencv_build_options.cmake \
      -S /opencv -B /opencv/build \
      -D OPENCV_EXTRA_MODULES_PATH=/opencv_contrib/modules \
      -D CMAKE_BUILD_TYPE=RELEASE \
      -D CMAKE_C_COMPILER_LAUNCHER=ccache \
      -D CMAKE_CXX_COMPILER_LAUNCHER=ccache \
      -D CMAKE_INSTALL_PREFIX=/opencv_artifacts; \
    cmake --build /opencv/build --parallel "$(nproc)"; \
    cmake --install /opencv/build; \
    ldconfig

########## Build OpenCvSharp native extern ##########
FROM opencv-builder AS opencvsharp-builder

# Copy local OpenCvSharp sources
COPY src/ /opencvsharp/src/

# Build and install OpenCvSharp native extern with ccache
RUN --mount=type=cache,target=/root/.ccache \
    set -eux; \
    mkdir -p /opencvsharp/make; \
    cmake -G Ninja \
      -S /opencvsharp/src -B /opencvsharp/make \
      -D CMAKE_INSTALL_PREFIX=/opencvsharp/make \
      -D CMAKE_C_COMPILER_LAUNCHER=ccache \
      -D CMAKE_CXX_COMPILER_LAUNCHER=ccache \
      -D CMAKE_PREFIX_PATH=/opencv_artifacts; \
    cmake --build /opencvsharp/make --parallel "$(nproc)"; \
    cmake --install /opencvsharp/make; \
    rm -rf /opencv /opencv_contrib; \
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /usr/lib/; \
    mkdir -p /artifacts; \
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /artifacts/

########## Test native .so file ##########
FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS test-native
RUN apt-get update && apt-get -y install --no-install-recommends gcc && rm -rf /var/lib/apt/lists/*
COPY --from=opencvsharp-builder /usr/lib /usr/lib
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
FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS test-dotnet
COPY --from=opencvsharp-builder /usr/lib /usr/lib
COPY src/ /opencvsharp/src/
COPY test/ /opencvsharp/test/
RUN cd /opencvsharp/src/OpenCvSharp && \
    dotnet build -c Release -f net10.0 && \
    cd /opencvsharp/src/OpenCvSharp.Extensions && \
    dotnet build -c Release -f net10.0
RUN dotnet test /opencvsharp/test/OpenCvSharp.Tests/OpenCvSharp.Tests.csproj -c Release -f net10.0 --runtime linux-x64 --logger "trx;LogFileName=test-results.trx" < /dev/null

########## Final images ##########
FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS final-sdk
COPY --from=opencvsharp-builder /usr/lib /usr/lib
COPY --from=opencvsharp-builder /artifacts /artifacts

FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble AS final
COPY --from=opencvsharp-builder /usr/lib /usr/lib
COPY --from=opencvsharp-builder /artifacts /artifacts
