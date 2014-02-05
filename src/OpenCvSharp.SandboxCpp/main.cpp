// Sansan.RD.SandboxCpp.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"

using namespace System;

int main(array<System::String ^> ^args)
{
    cv::Mat src = cv::imread("C:\\1232756901-0.png", 1);
	cv::Mat gray;
	cv::cvtColor(src, gray, cv::COLOR_BGR2GRAY);

	std::cout << "src depth:" << src.depth() << ", ch:" << src.channels() << std::endl;
	std::cout << "gray depth:" << gray.depth() << ", ch:" << gray.channels() << std::endl;

	cv::imshow("src", src);
	cv::imshow("gray", gray);
	cv::waitKey();

    return 0;
}
