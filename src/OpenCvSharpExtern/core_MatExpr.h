#ifndef _CPP_CORE_MATEXPR_H_
#define _CPP_CORE_MATEXPR_H_

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_MatExpr_new1(cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::MatExpr;
    END_WRAP
}
CVAPI(ExceptionStatus) core_MatExpr_new2(cv::Mat *mat, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::MatExpr(*mat);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_delete(cv::MatExpr *self)
{
    BEGIN_WRAP
    delete self;
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_toMat(cv::MatExpr *self, cv::Mat *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*self);
    END_WRAP
}

#pragma region Functions

CVAPI(ExceptionStatus) core_MatExpr_row(cv::MatExpr *self, int y, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->row(y);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_MatExpr_col(cv::MatExpr *self, int x, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->col(x);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_diag(cv::MatExpr *self, int d, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->diag(d);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_submat(cv::MatExpr *self, int rowStart, int rowEnd, int colStart, int colEnd, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const cv::Range rowRange(rowStart, rowEnd);
    const cv::Range colRange(colStart, colEnd);
    const auto ret = (*self)(rowRange, colRange);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_t(cv::MatExpr *self, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = self->t();
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_inv(cv::MatExpr *self, int method, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = self->inv(method);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_mul_toMatExpr(cv::MatExpr *self, cv::MatExpr *e, double scale, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = self->mul(*e, scale);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_MatExpr_mul_toMat(cv::MatExpr *self, cv::Mat *m, double scale, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = self->mul(*m, scale);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_cross(cv::MatExpr *self, cv::Mat *m, cv::Mat **returnValue) 
{
    BEGIN_WRAP
    const auto ret = self->cross(*m);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_dot(cv::MatExpr *self, cv::Mat *m, double *returnValue) 
{
    BEGIN_WRAP
    *returnValue = self->dot(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_size(cv::MatExpr *self, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(self->size());
    END_WRAP
}

CVAPI(ExceptionStatus) core_MatExpr_type(cv::MatExpr *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->type();
    END_WRAP
}

#pragma endregion

#pragma region Operators

CVAPI(ExceptionStatus) core_operatorUnaryMinus_MatExpr(cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = -(*e);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorUnaryNot_MatExpr(cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = ~(*e);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_operatorAdd_MatExprMat(cv::MatExpr *e, cv:: Mat *m, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*e) + (*m);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorAdd_MatMatExpr(cv::Mat *m, cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*m) + (*e);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorAdd_MatExprScalar(cv::MatExpr *e, MyCvScalar s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*e) + cpp(s);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorAdd_ScalarMatExpr(MyCvScalar s, cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = cpp(s) + (*e);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorAdd_MatExprMatExpr(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*e1) + (*e2);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_operatorSubtract_MatExprMat(cv::MatExpr *e, cv::Mat *m, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*e) - (*m);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorSubtract_MatMatExpr(cv::Mat *m, cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*m) - (*e);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorSubtract_MatExprScalar(cv::MatExpr *e, MyCvScalar s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*e) - cpp(s);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorSubtract_ScalarMatExpr(MyCvScalar s, cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = cpp(s) - (*e);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorSubtract_MatExprMatExpr(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*e1) - (*e2);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_operatorMultiply_MatExprMat(cv::MatExpr *e, cv::Mat *m, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = (*e) * (*m);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorMultiply_MatMatExpr(cv::Mat *m, cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = (*m) * (*e);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorMultiply_MatExprDouble(cv::MatExpr *e, double s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = (*e) * s;
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorMultiply_DoubleMatExpr(double s, cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = s * (*e);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorMultiply_MatExprMatExpr(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = (*e1) * (*e2);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_operatorDivide_MatExprMat(cv::MatExpr *e, cv::Mat *m, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = (*e) / (*m);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorDivide_MatMatExpr(cv::Mat *m, cv::MatExpr *e, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = (*m) / (*e);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorDivide_MatExprDouble(cv::MatExpr *e, double s, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = (*e) / s;
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorDivide_DoubleMatExpr(double s, cv::MatExpr *e, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = s / (*e);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_operatorDivide_MatExprMatExpr(cv::MatExpr *e1, cv::MatExpr *e2, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto ret = (*e1) / (*e2);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
#pragma endregion

CVAPI(ExceptionStatus) core_abs_MatExpr(cv::MatExpr *e, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::abs(*e);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

#endif