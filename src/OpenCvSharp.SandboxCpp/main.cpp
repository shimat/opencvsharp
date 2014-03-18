// Sansan.RD.SandboxCpp.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"
#include "AdaptiveBilateralTest.h"

using namespace System;

class MatOp_SetAll : public cv::MatOp
{
public:
    MatOp_SetAll() {}
    virtual ~MatOp_SetAll() {}

    //bool elementWise(const cv::MatExpr& /*expr*/) const { return true; }
    void assign(const cv::MatExpr& e, cv::Mat& m, int _type) const
	{
		m = cv::Mat(e.a.size(), e.a.type(), e.s);
	}
	static void makeExpr(cv::MatExpr& res, const cv::Mat &m, const cv::Scalar& s);
} g_MatOp_Scalar;

void MatOp_SetAll::makeExpr(cv::MatExpr& res, const cv::Mat &m, const cv::Scalar& s)
{
	res = cv::MatExpr(&g_MatOp_Scalar, 0, m, cv::Mat(), cv::Mat(), 1, 0, s);
}


cv::MatExpr setAll(cv::Mat &mat, cv::Scalar val)
{
	cv::MatExpr expr;
	MatOp_SetAll::makeExpr(expr, mat, val);
	return expr;
}


int main(array<System::String ^> ^args)
{
	cv::Mat m = cv::Mat::ones(2, 2, CV_8UC1);

	for (auto it = m.begin<uchar>(); it != m.end<uchar>(); it++)
	{
		std::cout << (int)(*it) << std::endl;
	}

	cv::Mat result = setAll(m, cv::Scalar::all(100)) * 2;

	std::cout << std::endl;
	for (auto it = result.begin<uchar>(); it != result.end<uchar>(); it++)
	{
		std::cout << (int)(*it) << std::endl;
	}

	getchar();
    return 0;
}
