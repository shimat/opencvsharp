#include "stdafx.h"

using namespace System;

void captureTest()
{
    /*
    cv::VideoCapture capture("C:\\temp\\stitching\\%03d.png");

    if(!capture.isOpened())
        throw cv::Exception(0, "not opened", "hoge", "fuga", __LINE__);

    cv::namedWindow("window");
    while(true)
    {
        cv::Mat frame;
        capture >> frame;
        if(frame.empty())
            break;

        cv::imshow("window", frame);
        cv::waitKey();
    }*/

    auto capture = cvCreateFileCapture("C:\\temp\\stitching\\%03d.png");
    if(capture == nullptr)
        throw cv::Exception(0, "not opened", "hoge", "fuga", __LINE__);
    
    cvNamedWindow("window");
    while(true)
    {
        IplImage *frame = cvQueryFrame(capture);
        cvShowImage("window", frame);
        cvWaitKey();
    }
}

void part(const cv::Mat &src, std::vector<cv::Mat> &parts, int partsCount, cv::Size partSize)
{
    parts.resize(partsCount);

    cv::Mat disp = src.clone();

    cv::RNG rng(std::time(nullptr));
    for (int i = 0; i < partsCount; i++)
    {
        int x = rng.uniform(0, src.cols - partSize.width);
        int y = rng.uniform(0, src.rows - partSize.height);
        cv::Rect rect(x, y, partSize.width, partSize.height);

        cv::Mat m = src(rect);
        parts[i] = m.clone();

        cv::rectangle(disp, rect, cv::Scalar(0, 0, 255));
    }

    cv::imwrite("C:\\temp\\disp.png", disp);
    cv::imshow("disp", disp);
    cv::waitKey();
    cv::destroyAllWindows();
}

int main(int argc, char *argv[])
{
    ///*
    cv::Mat src = cv::imread("C:\\test.png", cv::IMREAD_COLOR);

	cv::imshow("src", src);
    cv::waitKey();
    cv::destroyAllWindows();
    //*/

    //captureTest();

    return 0;
}




