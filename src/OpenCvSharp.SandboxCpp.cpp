#include "stdafx.h"

using namespace System;

struct U8C3
{
	uchar b, g, r;
};

// For researching native OpenCV behaviour
int main(array<System::String ^> ^args)
{
	cv::Mat mat1 = cv::imread("C:\\Lenna.png", CV_LOAD_IMAGE_COLOR);
	cv::Mat mat2 = cv::imread("C:\\Lenna.png", CV_LOAD_IMAGE_COLOR);

	for (auto it = mat1.begin<U8C3>(); it != mat1.end<U8C3>(); it++)
	{
		U8C3 elem = *it;
		std::swap(elem.b, elem.r);
		*it = elem;
	}

	cv::Mat eql = (mat1 == mat2);
	cv::Mat channels[3];
	cv::split(eql, channels);
	
	//std::cout << "b: " << cv::countNonZero(channels[0]) << std::endl;
	//std::cout << "g: " << cv::countNonZero(channels[1]) << std::endl;
	//std::cout << "r: " << cv::countNonZero(channels[2]) << std::endl;
	std::cout << "sum: " << cv::sum(eql) << std::endl;
	std::cout << "total: " << eql.total() * 255 << std::endl;
	std::cout << "equals: " << (cv::sum(eql)[0] == (eql.total() * 255)) << std::endl;

	cv::Scalar sc;
	std::cout << "abs: " << cv::trace(mat1 - mat2) << std::endl;

	//cv::imshow("window", abs);
	//cv::waitKey();

	getchar();
    return 0;
}
