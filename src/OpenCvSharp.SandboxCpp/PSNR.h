#pragma once

class PSNR
{
public:
	static double calcPSNR(const cv::Mat &src, const cv::Mat &dest)
	{
		cv::Mat ssrc;
		cv::Mat ddest;
		if (src.channels() == 1)
		{
			src.copyTo(ssrc);
			dest.copyTo(ddest);
		}
		else
		{
			cv::cvtColor(src, ssrc, CV_BGR2YUV);
			cv::cvtColor(dest, ddest, CV_BGR2YUV);
		}
		double sn = getPSNR(ssrc, ddest);
		return sn;
	}

private:
	static double getPSNR(const cv::Mat &src, const cv::Mat &dest)
	{
		int i, j;
		double sse, mse, psnr;
		sse = 0.0;

		for (j = 0; j<src.rows; j++)
		{
			const uchar* d = dest.ptr(j);
			const uchar* s = src.ptr(j);
			for (i = 0; i<src.cols; i++)
			{
				sse += ((d[i] - s[i])*(d[i] - s[i]));
			}
		}
		if (sse == 0.0)
		{
			return 0;
		}
		else
		{
			mse = sse / (double)(src.cols*src.rows);
			psnr = 10.0*log10((255 * 255) / mse);
			return psnr;
		}
	}
};

