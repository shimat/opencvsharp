cmake_minimum_required(VERSION 3.0)

include_directories(${OpenCV_INCLUDE_DIR})
link_directories(${OpenCV_LIBRARY_DIR} ${OpenCV_LIBRARIES})

file(GLOB OPENCVSHARP_FILES *.cpp)

find_package(OpenCV REQUIRED)
include_directories(${OpenCV_INCLUDE_DIRS})
set(LIBS ${LIBS} ${OpenCV_LIBRARIES})

add_library(OpenCvSharpExtern STATIC ${OPENCVSHARP_FILES})

install(TARGETS OpenCvSharpExtern
        RUNTIME DESTINATION bin
        LIBRARY DESTINATION lib
        ARCHIVE DESTINATION lib/static
)
