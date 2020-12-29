FROM amazonlinux:2.0.20200722.0

ENV OPENCV_VERSION=4.5.0

WORKDIR /

RUN yum update -y && \
    yum groupinstall -y "Development Tools" && \
    yum install -y \
        wget openssl-devel cmake3

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
    cmake3 \
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
    .. && make -j8 && make install

# Download OpenCvSharp
RUN wget https://github.com/shimat/opencvsharp/archive/master.zip && \
    unzip master.zip && rm master.zip && \
    mv opencvsharp-master opencvsharp && \
    cd opencvsharp 

# Install the Extern lib.
RUN mkdir /opencvsharp/make && cd /opencvsharp/make && \
    cmake3 -D CMAKE_INSTALL_PREFIX=/opencvsharp/make /opencvsharp/src && \
    make -j && make install && \
    rm -rf /opencv && \
    rm -rf /opencv_contrib && \
    mkdir /artifacts && \
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /artifacts/ && \
    cp /artifacts/libOpenCvSharpExtern.so /usr/lib64/
#RUN ldd /artifacts/libOpenCvSharpExtern.so

# Test OpenCvSharpExtern
RUN echo -e "\n\
int core_Mat_sizeof(); \n\
int main(){ \n\
  int i = core_Mat_sizeof(); \n\
  printf(\"sizeof(Mat) = %d\", i); \n\
  return 0; \n\
}" > /test.c && \
    gcc -I./ -L. test.c -o test -lOpenCvSharpExtern && \
    ./test && \
    rm -f /test*

RUN rm -rf /opencvsharp

# Simple console app test using NuGet
RUN rpm -Uvh https://packages.microsoft.com/config/centos/8/packages-microsoft-prod.rpm && \
yum install -y dotnet-sdk-3.1
RUN dotnet --info
RUN dotnet new console -f netcoreapp3.1 -o "ConsoleApp01" && cd /ConsoleApp01 && \
    echo -e "\n\
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
