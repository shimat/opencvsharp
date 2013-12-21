include(UsePkgConfig OPTIONAL)

if (WIN32)
find_path(OpenCV_cv_INCLUDE_DIR opencv/cv.h
	"c:/Program Files/OpenCV/cv/include"
	"c:/Platform/OpenCV/cv/include"
)

find_path(OpenCV_cxcore_INCLUDE_DIR opencv/cxcore.h
	"c:/Program Files/OpenCV/cxcore/include"
	"c:/Platform/OpenCV/cxcore/include"
)

find_path(OpenCV_highgui_INCLUDE_DIR opencv/highgui.h
	"c:/Program Files/OpenCV/otherlibs/highgui"
	"c:/Platform/OpenCV/otherlibs/highgui"
)

find_path(OpenCV_ml_INCLUDE_DIR opencv/ml.h
	"c:/Program Files/OpenCV/ml/include"
	"c:/Platform/OpenCV/ml/include"
)

set(OpenCV_INCLUDE_DIR $(OpenCV_cv_INCLUDE_DIR) $(OpenCV_cxcore_INCLUDE_DIR) $(OpenCV_highgui_INCLUDE_DIR)  $(OpenCV_ml_INCLUDE_DIR)) 

set(OpenCV_LIBRARY_DIR "c:/Program Files/OpenCV/lib" "c:/Platform/OpenCV/lib")

find_library(OpenCV_cv_LIBRARY
              NAMES cv
              PATH	"c:/Program Files/OpenCV/lib"
			"c:/Platform/OpenCV/lib"
)

find_library(OpenCV_cxcore_LIBRARY
              NAMES cxcore
              PATH	"c:/Program Files/OpenCV/lib"
			"c:/Platform/OpenCV/lib"
)

find_library(OpenCV_highgui_LIBRARY
              NAMES highgui
              PATH	"c:/Program Files/OpenCV/lib"
			"c:/Platform/OpenCV/lib"
)

find_library(OpenCV_ml_LIBRARY
              NAMES ml
              PATH	"c:/Program Files/OpenCV/lib"
			"c:/Platform/OpenCV/lib"
)

else (WIN32)
find_path(OpenCV_INCLUDE_DIR opencv/cv.h
          /usr/include
          /usr/local/include
)

set(OpenCV_LIBRARY_DIR /usr/lib /usr/local/lib)

find_library(OpenCV_cv_LIBRARY
              NAMES cv cv0.9.7 cv0.9.8 cv1.0.0 cv1.1.0 cv2.0.0
              PATH /usr/lib
                   /usr/local/lib
)

find_library(OpenCV_cxcore_LIBRARY
              NAMES cxcore cxcore0.9.7 cxcore0.9.8 cxcore1.0.0 cxcore1.1.0 cxcore2.0.0
              PATH /usr/lib
                   /usr/local/lib
)

find_library(OpenCV_highgui_LIBRARY
              NAMES highgui highgui0.9.7 highgui0.9.8 highgui1.0.0 highgui1.1.0 highgui2.0.0
              PATH /usr/lib
                   /usr/local/lib
)

find_library(OpenCV_ml_LIBRARY
              NAMES ml ml0.9.7 ml0.9.8 ml1.0.0 ml1.1.0 ml2.0.0
              PATH /usr/lib
                   /usr/local/lib
)
endif (WIN32)

if (OpenCV_cv_LIBRARY AND OpenCV_cxcore_LIBRARY AND OpenCV_highgui_LIBRARY AND OpenCV_ml_LIBRARY)
  set(OpenCV_LIBRARIES ${OpenCV_cv_LIBRARY} ${OpenCV_cxcore_LIBRARY} ${OpenCV_highgui_LIBRARY} ${OpenCV_ml_LIBRARY})
  set(OpenCV_FOUND TRUE)
endif (OpenCV_cv_LIBRARY AND OpenCV_cxcore_LIBRARY AND OpenCV_highgui_LIBRARY AND OpenCV_ml_LIBRARY)

if (OpenCV_FOUND)
  if (NOT OpenCV_FIND_QUIETLY)
    message(STATUS "OpenCV library found: ${OpenCV_LIBRARIES}")
  endif (NOT OpenCV_FIND_QUIETLY)
else (OpenCV_FOUND)
  if (OpenCV_FIND_REQUIRED)
    message(FATAL_ERROR "!!!No OpenCV library found!!!")
  endif (OpenCV_FIND_REQUIRED)
endif (OpenCV_FOUND)

if (OpenCV_INCLUDE_DIR)
  message(STATUS "OpenCV include directories found: ${OpenCV_INCLUDE_DIR}")
else (OpenCV_INCLUDE_DIR)
  message(FATAL_ERROR "!!!No OpenCV include directories found!!!")
endif (OpenCV_INCLUDE_DIR)