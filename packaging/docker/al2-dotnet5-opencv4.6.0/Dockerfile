FROM public.ecr.aws/lambda/dotnet:5.0

ENV OPENCV_VERSION=4.6.0

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
    -D OPENCV_ENABLE_NONFREE=ON \
    .. && make -j$(nproc) && make install

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
    cp /opencvsharp/make/OpenCvSharpExtern/libOpenCvSharpExtern.so /usr/lib64/
#RUN ldd /artifacts/libOpenCvSharpExtern.so

# Test OpenCvSharpExtern
#RUN echo -e "\n\
#int core_Mat_sizeof(); \n\
#int main(){ \n\
#  int i = core_Mat_sizeof(); \n\
#  printf(\"sizeof(Mat) = %d\", i); \n\
#  return 0; \n\
#}" > /test.c && \
#    gcc -I./ -L. test.c -o test -lOpenCvSharpExtern && \
#    ./test && \
#    rm -f /test*

RUN rm -rf /opencvsharp
