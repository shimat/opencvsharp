#include <opencv2/core.hpp>
#include <opencv2/core/ocl.hpp>
#include <opencv2/imgproc.hpp>

#include <algorithm>
#include <chrono>
#include <functional>
#include <iomanip>
#include <iostream>
#include <vector>

double medianTime(const std::function<void()>& operation)
{
    for (int i = 0; i < 5; ++i)
        operation();
    std::vector<double> samples;
    for (int round = 0; round < 7; ++round)
    {
        const auto start = std::chrono::steady_clock::now();
        for (int i = 0; i < 20; ++i)
            operation();
        const auto end = std::chrono::steady_clock::now();
        samples.push_back(std::chrono::duration<double, std::milli>(end - start).count() / 20);
    }
    std::sort(samples.begin(), samples.end());
    return samples[samples.size() / 2];
}

int main()
{
    cv::setNumThreads(1);
    cv::ocl::setUseOpenCL(false);
    cv::ipp::setUseIPP_NotExact(false);
    std::cout << "IPP version," << cv::ipp::getIppVersion() << '\n';
    std::cout << "CPU," << cv::getCPUFeaturesLine() << '\n';
    std::cout << "operation,width,height,ipp_enabled,median_ms\n";
    cv::RNG random(20261121);
    for (const auto size : {cv::Size(640, 480), cv::Size(1920, 1080)})
    {
        cv::Mat color(size, CV_8UC3), gray(size, CV_8UC1), floats(size, CV_32FC1);
        random.fill(color, cv::RNG::UNIFORM, 0, 256);
        random.fill(gray, cv::RNG::UNIFORM, 0, 256);
        random.fill(floats, cv::RNG::UNIFORM, 0.0, 1.0);
        cv::Mat output;
        const std::vector<std::pair<const char*, std::function<void()>>> operations = {
            {"cvtColor", [&] { cv::cvtColor(color, output, cv::COLOR_BGR2GRAY); }},
            {"resizeLinear", [&] { cv::resize(color, output, cv::Size(), 0.5, 0.5, cv::INTER_LINEAR); }},
            {"resizeCubic", [&] { cv::resize(color, output, cv::Size(), 0.5, 0.5, cv::INTER_CUBIC); }},
            {"gaussianBlur", [&] { cv::GaussianBlur(gray, output, cv::Size(7, 7), 1.5); }},
            {"sobel", [&] { cv::Sobel(gray, output, CV_16S, 1, 0); }},
            {"threshold", [&] { cv::threshold(gray, output, 127, 255, cv::THRESH_BINARY); }},
            {"dft", [&] { cv::dft(floats, output, cv::DFT_COMPLEX_OUTPUT); }},
        };
        for (const auto& operation : operations)
        {
            // Alternate the order across image sizes to reduce ordering bias.
            for (const bool enable : (size.width == 640 ? std::vector<bool>{false, true}
                                                        : std::vector<bool>{true, false}))
            {
                cv::ipp::setUseIPP(enable);
                const auto milliseconds = medianTime(operation.second);
                if (!cv::checkRange(output))
                    return 1;
                std::cout << operation.first << ',' << size.width << ',' << size.height << ','
                          << cv::ipp::useIPP() << ',' << std::fixed << std::setprecision(6)
                          << milliseconds << '\n';
            }
        }
    }
}
