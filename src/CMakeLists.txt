cmake_minimum_required(VERSION 3.0)

project(OpenCvSharpExtern)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")

#set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} "${CMAKE_SOURCE_DIR}/cmake/Modules/")

# remove MinSizeRel & RelWithDebInfo
SET(CMAKE_CONFIGURATION_TYPES "Debug;Release" CACHE STRING "limited configs" FORCE)

add_subdirectory(OpenCvSharpExtern) 
