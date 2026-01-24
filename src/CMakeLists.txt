cmake_minimum_required(VERSION 3.0)

project(OpenCvSharpExtern)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")

#set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} "${CMAKE_SOURCE_DIR}/cmake/Modules/")

# remove MinSizeRel & RelWithDebInfo
SET(CMAKE_CONFIGURATION_TYPES "Debug;Release" CACHE STRING "limited configs" FORCE)

add_subdirectory(OpenCvSharpExtern) 

option(NO_CONTRIB "Disable all contrib features" OFF)
option(NO_STITCHING "Disable stitching bindings" OFF)
option(NO_CALIB3D "Disable 3D calibration bindings" OFF)
option(NO_VIDEO "Disable video bindings" OFF)
option(NO_FEATURES2D "Disable 2D feature bindings" OFF)
option(NO_FLANN "Disable FLANN bindings" OFF)
option(NO_DNN "Disable DNN bindings" OFF)
option(NO_ML "Disable ML bindings" OFF)
option(NO_OBJDETECT "Disable object detection bindings" OFF)
option(NO_PHOTO "Disable photo bindings" OFF)
option(NO_BARCODE "Disable barcode bindings" OFF)
