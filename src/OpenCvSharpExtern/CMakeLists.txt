cmake_minimum_required(VERSION 3.15)

include_directories(${OpenCV_INCLUDE_DIR})
IF(!EMSCRIPTEN)
	link_directories(${OpenCV_LIBRARY_DIR} ${OpenCV_LIBRARIES})
ENDIF()
IF(APPLE)
    # Fix linking on 10.14+. See https://stackoverflow.com/questions/54068035
    link_directories(/usr/local/lib)
ENDIF()

file(GLOB OPENCVSHARP_FILES *.cpp)

# Resolve Protobuf target before OpenCV config is loaded.
if(APPLE)
	find_package(Protobuf REQUIRED)
endif()

find_package(OpenCV REQUIRED)

# iconv support isn't automatic on some systems
find_package(Iconv QUIET)
if(Iconv_FOUND)
  ocv_target_link_libraries(${the_module} Iconv::Iconv)
else()
  ocv_target_compile_definitions(${the_module} PRIVATE "NO_ICONV=1")
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

	# Link Tesseract on Windows (using vcpkg-style prefix via CMAKE_PREFIX_PATH)
	if(WIN32 AND NOT EMSCRIPTEN)
		find_package(Tesseract QUIET)
		if(Tesseract_FOUND)
			target_link_libraries(OpenCvSharpExtern Tesseract::libtesseract)
		endif()
	endif()

	install(TARGETS OpenCvSharpExtern
        RUNTIME DESTINATION bin
        LIBRARY DESTINATION lib
        ARCHIVE DESTINATION lib/static
	)

	# On Windows: copy DLL and the OpenCV FFmpeg plugin DLL to the test project directory.
	# Disabled for slim builds (NO_INSTALL_TO_TEST=ON) to avoid overwriting the full DLL.
	if(WIN32 AND NOT EMSCRIPTEN AND NOT NO_INSTALL_TO_TEST)
		set(TEST_OUTPUT_DIR "${CMAKE_SOURCE_DIR}/../test/OpenCvSharp.Tests")

		add_custom_command(TARGET OpenCvSharpExtern POST_BUILD
			COMMAND ${CMAKE_COMMAND} -E copy_if_different
				$<TARGET_FILE:OpenCvSharpExtern>
				"${TEST_OUTPUT_DIR}/OpenCvSharpExtern.dll"
			COMMENT "Copying OpenCvSharpExtern.dll to test project"
		)

		# Derive the OpenCV install root from the cmake config path (lib/cmake/opencv4 → root)
		get_filename_component(OPENCV_INSTALL_PREFIX "${OpenCV_DIR}/../../.." ABSOLUTE)
		set(OPENCV_VER_STR "${OpenCV_VERSION_MAJOR}${OpenCV_VERSION_MINOR}${OpenCV_VERSION_PATCH}")
		set(OPENCV_FFMPEG_DLL "${OPENCV_INSTALL_PREFIX}/bin/opencv_videoio_ffmpeg${OPENCV_VER_STR}_64.dll")

		if(EXISTS "${OPENCV_FFMPEG_DLL}")
			add_custom_command(TARGET OpenCvSharpExtern POST_BUILD
				COMMAND ${CMAKE_COMMAND} -E copy_if_different
					"${OPENCV_FFMPEG_DLL}"
					"${TEST_OUTPUT_DIR}/opencv_videoio_ffmpeg${OPENCV_VER_STR}_64.dll"
				COMMENT "Copying opencv_videoio_ffmpeg DLL to test project"
			)
		endif()
	endif()
endif(OpenCV_FOUND)
