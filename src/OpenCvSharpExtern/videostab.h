#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_VIDEOSTAB)
#include "include_opencv.h"
#include <opencv2/videostab/stabilizer.hpp>

class videostab_MemoryFrameSource final : public cv::videostab::IFrameSource
{
public:
    explicit videostab_MemoryFrameSource(const std::vector<cv::Mat>& frames) : frames_(frames) {}

    void reset() override { position_ = 0; }
    cv::Mat nextFrame() override
    {
        return position_ < frames_.size() ? frames_[position_++] : cv::Mat();
    }

private:
    std::vector<cv::Mat> frames_;
    size_t position_ = 0;
};

CVAPI(ExceptionStatus) videostab_stabilize(
    cv::Mat** frames, int count, int radius, float trimRatio, int motionModel,
    cv::Mat** stabilizedFrames)
{
    return cvTry([&] {
        CV_Assert(count >= 2 && radius > 0 && trimRatio >= 0.f && trimRatio < 0.5f);
        CV_Assert(motionModel >= cv::videostab::MM_TRANSLATION &&
                  motionModel <= cv::videostab::MM_HOMOGRAPHY);

        std::vector<cv::Mat> input;
        input.reserve(count);
        for (int i = 0; i < count; ++i)
        {
            CV_Assert(frames[i] && stabilizedFrames[i]);
            input.push_back(*frames[i]);
            CV_Assert(!input.back().empty() && input.back().size() == input.front().size() &&
                      input.back().type() == input.front().type());
            CV_Assert(input.back().type() == CV_8UC1 || input.back().type() == CV_8UC3);
        }

        const auto model = static_cast<cv::videostab::MotionModel>(motionModel);
        auto source = cv::makePtr<videostab_MemoryFrameSource>(input);
        auto estimator = cv::makePtr<cv::videostab::KeypointBasedMotionEstimator>(
            cv::makePtr<cv::videostab::MotionEstimatorRansacL2>(model));

        cv::videostab::OnePassStabilizer stabilizer;
        stabilizer.setLog(cv::makePtr<cv::videostab::NullLog>());
        stabilizer.setFrameSource(source);
        stabilizer.setMotionEstimator(estimator);
        stabilizer.setMotionFilter(cv::makePtr<cv::videostab::GaussianMotionFilter>(radius));
        stabilizer.setRadius(radius);
        stabilizer.setTrimRatio(trimRatio);

        for (int i = 0; i < count; ++i)
        {
            const cv::Mat frame = stabilizer.nextFrame();
            CV_Assert(!frame.empty());
            frame.copyTo(*stabilizedFrames[i]);
        }
        CV_Assert(stabilizer.nextFrame().empty());
    });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_VIDEOSTAB
