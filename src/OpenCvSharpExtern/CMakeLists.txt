# Copyright (C) 2009 by Schima
# schimatk@gmail.com
#
# OpenCvSharp is free software: you can redistribute it and/or modify
# it under the terms of the Lesser GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# OpenCvSharp is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# Lesser GNU General Public License for more details.
#
# You should have received a copy of the Lesser GNU General Public License
# along with OpenCvSharp.  If not, see <http://www.gnu.org/licenses/>.

#find_package(OpenCV REQUIRED)

include_directories(${OpenCV_INCLUDE_DIR})
link_directories(${OpenCV_LIBRARY_DIR} ${OpenCV_LIBRARIES})

set(OPENCVSHARP_FILES  
	CvANN_MLP.cpp
	CvBlobWrapper.cpp
	CvBoost.cpp
	CvDTree.cpp
	CvEM.cpp
	CvERTrees.cpp
	CvKNearest.cpp
	CvMLData.cpp
	CvNormalBayesClassifier.cpp
	CvRTrees.cpp
	CvSVM.cpp
	CvStatModel.cpp
	CvTrainTestSplit.cpp
	WAlgorithm.cpp
	WCore.cpp
	WCv.cpp
	WCvAdaptiveSkinDetector.cpp
	WCvCamShiftTracker.cpp
	WCvaux.cpp
	WFlann.cpp
	WHOGDescriptor.cpp
	WHighgui.cpp
	WMat.cpp
	#WMatND.cpp
	WNonfree.cpp
	WStereoSGBM.cpp
	WVector.cpp
	WVideo.cpp
	cvaux.cpp
	cvblob.cpp
	cvcolor.cpp
	cvcontour.cpp
	cvlabel.cpp
	cvtrack.cpp
)

#set(OPENCVSHARP_FILES  cvblob.cpp
#                       cvlabel.cpp
#                       CvANN_MLP.cpp 
#                       CvBlobWrapper.cpp
#                       CvBoost.cpp 
#                       CvDTree.cpp 
#                       CvEM.cpp 
#                       CvKNearest.cpp 
#                       CvNormalBayesClassifier.cpp 
#                       CvRTrees.cpp 
#                       CvStatModel.cpp 
#                       CvSVM.cpp
#)

add_library(OpenCvSharpExtern SHARED ${OPENCVSHARP_FILES})

install(TARGETS OpenCvSharpExtern
        RUNTIME DESTINATION bin
        LIBRARY DESTINATION lib
        ARCHIVE DESTINATION lib/static
)
