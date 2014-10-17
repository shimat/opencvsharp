
include_directories(${OpenCV_INCLUDE_DIR})
link_directories(${OpenCV_LIBRARY_DIR} ${OpenCV_LIBRARIES})

set(OPENCVSHARP_FILES 
	calib3d.cpp
	contrib.cpp
	core.cpp
	features2d.cpp
	flann.cpp
	gpu.cpp
	highgui.cpp
	imgproc.cpp
	legacy.cpp
	ml.cpp
	nonfree.cpp
	objdetect.cpp
	photo.cpp
	std_vector.cpp
	stitching.cpp
	superres.cpp
	video.cpp
)

add_library(OpenCvSharpExtern SHARED ${OPENCVSHARP_FILES})

install(TARGETS OpenCvSharpExtern
        RUNTIME DESTINATION bin
        LIBRARY DESTINATION lib
        ARCHIVE DESTINATION lib/static
)
