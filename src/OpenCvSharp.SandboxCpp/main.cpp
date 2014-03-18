// Sansan.RD.SandboxCpp.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"
#include "AdaptiveBilateralTest.h"

using namespace System;

class MatOp_Scalar : public cv::MatOp
{
public:
    MatOp_Scalar() {}
    virtual ~MatOp_Scalar() {}

    bool elementWise(const cv::MatExpr& /*expr*/) const { return true; }
    void assign(const cv::MatExpr& e, cv::Mat& m, int _type) const
	{
		m.setTo(e.s);
	}

    static void makeExpr(cv::MatExpr& res, const cv::Scalar& s)
	{
		MatOp_Scalar op;
		res = cv::MatExpr(&op, 0, cv::Mat(), cv::Mat(), cv::Mat(), 1, 0, s);
	}
};

cv::MatExpr setAll(cv::Mat &mat, cv::Scalar val)
{
	cv::MatExpr expr;
	MatOp_Scalar::makeExpr(expr, val);
	return expr;
}

int main(array<System::String ^> ^args)
{
	cv::Mat m = cv::Mat::ones(2, 2, CV_8UC1);

	for (auto it = m.begin<uchar>(); it != m.end<uchar>(); it++)
	{
		std::cout << (int)(*it) << std::endl;
	}

	cv::Mat result = setAll(m, cv::Scalar::all(100));

	std::cout << std::endl;
	for (auto it = result.begin<uchar>(); it != result.end<uchar>(); it++)
	{
		std::cout << (int)(*it) << std::endl;
	}

	getchar();
    return 0;
}
