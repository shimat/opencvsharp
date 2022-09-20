cmake_minimum_required(VERSION 3.0)

include_directories(${OpenCV_INCLUDE_DIR})
IF(!EMSCRIPTEN)
	link_directories(${OpenCV_LIBRARY_DIR} ${OpenCV_LIBRARIES})
ENDIF()
IF(APPLE)
    # Fix linking on 10.14+. See https://stackoverflow.com/questions/54068035
    link_directories(/usr/local/lib)
ENDIF()

file(GLOB OPENCVSHARP_FILES *.cpp)

find_package(OpenCV REQUIRED)

# iconv support isn't automatic on some systems
if(CMAKE_VERSION VERSION_GREATER "3.11")
  find_package(Iconv QUIET)
  if(Iconv_FOUND)
    ocv_target_link_libraries(${the_module} Iconv::Iconv)
  else()
    ocv_target_compile_definitions(${the_module} PRIVATE "NO_ICONV=1")
  endif()
endif()

if(OpenCV_FOUND)
	include_directories(${OpenCV_INCLUDE_DIRS})
	#set(LIBS ${LIBS} ${OpenCV_LIBRARIES})

	if(CMAKE_GENERATOR MATCHES "Visual Studio")
		set(CMAKE_CXX_FLAGS_RELEASE "${CMAKE_CXX_FLAGS_RELEASE} /MT")
		set(CMAKE_CXX_FLAGS_DEBUG "${CMAKE_CXX_FLAGS_DEBUG} /MTd")
		
		set(CMAKE_CXX_STANDARD_LIBRARIES "${CMAKE_CXX_STANDARD_LIBRARIES} kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib")
	endif()

	if(EMSCRIPTEN)
		# TODO: replace path
		add_library(OpenCvSharpExtern STATIC ${OPENCVSHARP_FILES} ${WASM_LIB})
	else()
		add_library(OpenCvSharpExtern SHARED ${OPENCVSHARP_FILES})
		target_link_libraries(OpenCvSharpExtern ${OpenCV_LIBRARIES})
	endif()

	install(TARGETS OpenCvSharpExtern
        RUNTIME DESTINATION bin
        LIBRARY DESTINATION lib
        ARCHIVE DESTINATION lib/static
	)
endif(OpenCV_FOUND)
