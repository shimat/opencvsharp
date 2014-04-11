// Sansan.RD.SandboxCpp.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"

using namespace System;

int main(array<System::String ^> ^args)
{
    cv::initModule_features2d();
    cv::initModule_video();
    cv::initModule_nonfree();

    cv::Ptr<cv::SIFT> algo = cv::Algorithm::create<cv::SIFT>("Feature2D.SIFT");
    std::cout << algo->descriptorSize() << std::endl;
    std::cout << algo->name() << std::endl;

	getchar();
    return 0;
}
