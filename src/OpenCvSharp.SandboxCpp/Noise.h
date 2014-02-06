#pragma once

class Noise
{
public:
	static void addNoise(const cv::Mat &src, cv::Mat &dest, double sigma, double sprate = 0.0)
	{
		if (src.channels() == 1)
		{
			addNoiseMono(src, dest, sigma);
			if (sprate != 0)addNoiseSoltPepperMono(dest, dest, sprate);
			return;
		}
		else
		{
			std::vector<cv::Mat> s;
			std::vector<cv::Mat> d(src.channels());
			split(src, s);
			for (int i = 0; i<src.channels(); i++)
			{
				addNoiseMono(s[i], d[i], sigma);
				if (sprate != 0)addNoiseSoltPepperMono(d[i], d[i], sprate);
			}
			cv::merge(d, dest);
		}
	}
	static void addNoiseMono(const cv::Mat &src, cv::Mat &dest, double sigma)
	{
		cv::Mat s;
		src.convertTo(s, CV_16S);
		cv::Mat n(s.size(), CV_16S);
		cv::randn(n, 0, sigma);
		cv::Mat temp = s + n;
		temp.convertTo(dest, CV_8U);
	}
	static void addNoiseSoltPepperMono(const cv::Mat &src, cv::Mat &dest, double per)
	{
		cv::RNG rng;
#pragma omp parallel for
		for (int j = 0; j<src.rows; j++)
		{
			const uchar* s = src.ptr(j);
			uchar* d = dest.ptr(j);
			for (int i = 0; i<src.cols; i++)
			{
				double a1 = rng.uniform((double)0, (double)1);

				if (a1>per)
					d[i] = s[i];
				else
				{
					double a2 = rng.uniform((double)0, (double)1);
					if (a2>0.5)d[i] = 0;
					else d[i] = 255;
				}
			}
		}
	}
};

