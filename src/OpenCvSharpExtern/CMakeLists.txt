
set(OPENCV_VERSION "2410")
set(OPENCV_INCLUDE_DIR "" CACHE PATH "OpenCV include path")
set(OPENCV_LIBRARY_DIR "" CACHE PATH "OpenCV library path")

include_directories(${OPENCV_INCLUDE_DIR})
link_directories(${OPENCV_LIBRARY_DIR})

file(GLOB SOURCE_FILES "*.cpp")
file(GLOB HEADER_FILES "*.h")
add_library(OpenCvSharpExtern SHARED ${SOURCE_FILES})

# linking all OpenCV lib files
if(WIN32)
file(GLOB OPENCV_LIB_FILES "${OPENCV_LIBRARY_DIR}/*${OPENCV_VERSION}.lib")
file(GLOB OPENCV_A_FILES "${OPENCV_LIBRARY_DIR}/*${OPENCV_VERSION}.a")
file(GLOB OPENCV_DYLIB_FILES "${OPENCV_LIBRARY_DIR}/*${OPENCV_VERSION}.dylib")
target_link_libraries(OpenCvSharpExtern PRIVATE ${OPENCV_LIB_FILES})
target_link_libraries(OpenCvSharpExtern PRIVATE ${OPENCV_A_FILES})
target_link_libraries(OpenCvSharpExtern PRIVATE ${OPENCV_DYLIB_FILES})
endif()

if(UNIX)
install(TARGETS OpenCvSharpExtern
#        RUNTIME DESTINATION bin
        LIBRARY DESTINATION lib
#        ARCHIVE DESTINATION lib/static
)
endif()
