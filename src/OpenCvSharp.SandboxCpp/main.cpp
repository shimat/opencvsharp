// Sansan.RD.SandboxCpp.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"

using namespace System;

int main(array<System::String ^> ^args)
{
    cv::CascadeClassifier cascade("C:\\lbpcascade_frontalface.xml");
    cv::Mat src = cv::imread("C:\\yalta.jpg", cv::IMREAD_COLOR);
    cv::Mat gray = cv::imread("C:\\yalta.jpg", cv::IMREAD_GRAYSCALE);

    std::vector<cv::Rect> objects;
    cascade.detectMultiScale(gray, objects, 1.08, 2);

    for (auto it = objects.begin(); it != objects.end(); it++)
    {
        cv::rectangle(src, *it, cv::Scalar(0,0,255), 1);
    }
    cv::imshow("faces", src);
    cv::waitKey();

    return 0;
}
