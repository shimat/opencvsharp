# A failed download can leave OpenCV configured without the requested built-in CJK font.
if(WITH_UNIFONT AND (NOT HAVE_HARFBUZZ OR NOT HAVE_UNIFONT))
  message(FATAL_ERROR "The requested OpenCV built-in 'uni' font is unavailable. Check HarfBuzz support and the OpenCV download log.")
endif()
