#ifndef _CPP_STRINGWRAPPER_H_
#define _CPP_STRINGWRAPPER_H_

#include "include_opencv.h"

CVAPI(std::string*) string_new1()
{
    return new std::string;
}
CVAPI(std::string*) string_new2(const char *str)
{
    return new std::string(str);
}

CVAPI(void) string_delete(std::string *s)
{
    delete s;
}

CVAPI(const char*) string_c_str(std::string *s)
{
    return s->c_str();
}

CVAPI(size_t) string_size(std::string *s)
{
    return s->size();
}

#endif
