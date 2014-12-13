cmake_minimum_required(VERSION 2.8)

project(OpenCvSharpExtern)

set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} "${CMAKE_SOURCE_DIR}/cmake/Modules/")

add_definitions(-DCVAPI_EXPORTS)
set(CMAKE_CONFIGURATION_TYPES "Release" CACHE STRING "" FORCE)

add_subdirectory(OpenCvSharpExtern) 

