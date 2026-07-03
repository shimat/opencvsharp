########## Build arguments ##########
ARG OPENCV_VERSION=4.13.0

########## Build OpenCV (slim) ##########
FROM ubuntu:noble AS opencv-builder

ARG OPENCV_VERSION
ENV DEBIAN_FRONTEND=noninteractive
ENV OPENCV_VERSION=${OPENCV_VERSION}
ENV CCACHE_DIR=/root/.ccache
ENV CCACHE_MAXSIZE=2G

WORKDIR /

# Install build dependencies (with BuildKit cache for apt)
RUN --mount=type=cache,target=/var/cache/apt \
    --mount=type=cache,target=/var/lib/apt/lists \
    set -eux; \
    apt-get -o Acquire::Retries=3 update; \
    apt-get -y install --no-install-recommends \
      build-essential \
      cmake \
      ninja-build \
      git \
      wget \
      unzip \
      ca-certificates \
      ccache \
      libjpeg-dev \
      libpng-dev \
      libtiff-dev \
      libopenjp2-7-dev \
      zlib1g-dev \
      pkg-config

# Copy cmake options (needed before OpenCV configure)
COPY cmake/opencv_build_options_slim.cmake /opencv_build_options_slim.cmake

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

# Configure, build, and install OpenCV (slim profile)
RUN --mount=type=cache,target=/root/.ccache \
    set -eux; \
    cmake -G Ninja \
      -C /opencv_build_options_slim.cmake \
      -S /opencv -B /opencv/build \
      -D OPENCV_EXTRA_MODULES_PATH=/opencv_contrib/modules \
      -D CMAKE_BUILD_TYPE=RELEASE \
      -D CMAKE_C_COMPILER_LAUNCHER=ccache \
      -D CMAKE_CXX_COMPILER_LAUNCHER=ccache \
      -D CMAKE_INSTALL_PREFIX=/opencv_artifacts; \
    cmake --build /opencv/build --parallel "$(nproc)"; \
    cmake --install /opencv/build; \
    ldconfig

########## Build OpenCvSharp native extern (slim) ##########
FROM opencv-builder AS opencvsharp-builder

COPY src/ /opencvsharp/src/

RUN --mount=type=cache,target=/root/.ccache \
    set -eux; \
    mkdir -p /opencvsharp/make; \
    cmake -G Ninja \
      -S /opencvsharp/src -B /opencvsharp/make \
      -D CMAKE_INSTALL_PREFIX=/opencvsharp/make \
      -D CMAKE_C_COMPILER_LAUNCHER=ccache \
      -D CMAKE_CXX_COMPILER_LAUNCHER=ccache \
      -D CMAKE_PREFIX_PATH=/opencv_artifacts \
      -D NO_CONTRIB=ON \
      -D NO_VIDEOIO=ON \
      -D NO_HIGHGUI=ON \
      -D NO_DNN=ON; \
    cmake --build /opencvsharp/make --parallel "$(nproc)"; \
    cmake --install /opencvsharp/make; \
    rm -rf /opencv /opencv_contrib; \
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /usr/lib/; \
    mkdir -p /artifacts; \
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /artifacts/

########## Smoke test native .so file ##########
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

########## Final images ##########
FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS final-sdk
COPY --from=opencvsharp-builder /usr/lib /usr/lib
COPY --from=opencvsharp-builder /artifacts /artifacts

FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble AS final
COPY --from=opencvsharp-builder /usr/lib /usr/lib
COPY --from=opencvsharp-builder /artifacts /artifacts
