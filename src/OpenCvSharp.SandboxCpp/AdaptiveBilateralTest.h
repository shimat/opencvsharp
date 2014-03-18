#pragma once

#include "Noise.h"

class AdaptiveBilateralTest
{
public:
	AdaptiveBilateralTest()
	{
		//(1) Reading image and add noise(standart deviation = 15)
		const double noise_sigma = 35.0;
		cv::Mat src = cv::imread("C:\\___z.jpg", 1);
		cv::Mat snoise = src;//cv::imread("C:\\yokosuka-001.jpg", 1);
		//Noise::addNoise(src, snoise, noise_sigma);
		//snoise = src;
		cv::Mat gaussian, median, bilateral, adaptive;

		//(2) preview conventional method with PSNR
		//(2-1) RAW
		std::cout << "RAW: " << cv::PSNR(src, snoise) << std::endl << std::endl;
		cv::imwrite("C:\\temp\\noise.png", snoise);

		//(2-2) Gaussian Filter (7x7) sigma = 5
		int64 pre = cv::getTickCount();
		cv::GaussianBlur(snoise, gaussian, cv::Size(7, 7), 5);
		std::cout << "time: " << 1000.0*(cv::getTickCount() - pre) / (cv::getTickFrequency()) << " ms" << std::endl;
		std::cout << "gaussian: " << cv::PSNR(src, gaussian) << std::endl << std::endl;
		cv::imwrite("C:\\temp\\gaussian.png", gaussian);

		//(2-3) median Filter (3x3)
		pre = cv::getTickCount();
		cv::medianBlur(snoise, median, 3);
		std::cout << "time: " << 1000.0*(cv::getTickCount() - pre) / (cv::getTickFrequency()) << " ms" << std::endl;
		std::cout << "median: " << cv::PSNR(src, median) << std::endl << std::endl;
		cv::imwrite("C:\\temp\\median.png", median);

		//(2-4) Bilateral Filter (7x7) color sigma = 35, space sigma = 5
		pre = cv::getTickCount();
		cv::bilateralFilter(snoise, bilateral, 7, 35, 5);
		std::cout << "time: " << 1000.0*(cv::getTickCount() - pre) / (cv::getTickFrequency()) << " ms" << std::endl;
		std::cout << "bilateral: " << cv::PSNR(src, bilateral) << std::endl << std::endl;
		cv::imwrite("C:\\temp\\bilateral.png", bilateral);

		//(3) tests adaptiveBilateralFilter
		pre = cv::getTickCount();
		cv::adaptiveBilateralFilter(snoise, adaptive, cv::Size(7, 7), 5);
		std::cout << "time: " << 1000.0*(cv::getTickCount() - pre) / (cv::getTickFrequency()) << " ms" << std::endl;
		std::cout << "adaptiveBilateral: " << cv::PSNR(src, adaptive) << std::endl << std::endl;
		cv::imwrite("C:\\temp\\adaptiveBilateral.png", adaptive);

		//cv::imshow("noise", snoise);
		cv::imshow("Bilateral Filter", bilateral);
		cv::imshow("Adaptive Bilateral Filter", adaptive);
		cv::waitKey();
	}
private:
	
};

