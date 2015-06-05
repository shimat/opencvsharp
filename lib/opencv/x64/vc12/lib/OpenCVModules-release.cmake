#----------------------------------------------------------------
# Generated CMake target import file for configuration "Release".
#----------------------------------------------------------------

# Commands may need to know the format version.
set(CMAKE_IMPORT_FILE_VERSION 1)

# Import target "opencv_world" for configuration "Release"
set_property(TARGET opencv_world APPEND PROPERTY IMPORTED_CONFIGURATIONS RELEASE)
set_target_properties(opencv_world PROPERTIES
  IMPORTED_IMPLIB_RELEASE "${_IMPORT_PREFIX}/x86/vc12/lib/opencv_world300.lib"
  IMPORTED_LINK_INTERFACE_LIBRARIES_RELEASE ""
  IMPORTED_LOCATION_RELEASE "${_IMPORT_PREFIX}/x86/vc12/bin/opencv_world300.dll"
  )

list(APPEND _IMPORT_CHECK_TARGETS opencv_world )
list(APPEND _IMPORT_CHECK_FILES_FOR_opencv_world "${_IMPORT_PREFIX}/x86/vc12/lib/opencv_world300.lib" "${_IMPORT_PREFIX}/x86/vc12/bin/opencv_world300.dll" )

# Import target "opencv_ts" for configuration "Release"
set_property(TARGET opencv_ts APPEND PROPERTY IMPORTED_CONFIGURATIONS RELEASE)
set_target_properties(opencv_ts PROPERTIES
  IMPORTED_LINK_INTERFACE_LANGUAGES_RELEASE "CXX"
  IMPORTED_LINK_INTERFACE_LIBRARIES_RELEASE "opencv_world;ippicv"
  IMPORTED_LOCATION_RELEASE "${_IMPORT_PREFIX}/x86/vc12/lib/opencv_ts300.lib"
  )

list(APPEND _IMPORT_CHECK_TARGETS opencv_ts )
list(APPEND _IMPORT_CHECK_FILES_FOR_opencv_ts "${_IMPORT_PREFIX}/x86/vc12/lib/opencv_ts300.lib" )

# Commands beyond this point should not need to know the version.
set(CMAKE_IMPORT_FILE_VERSION)
