# manylinux FFmpeg feature policy

The full and headless `linux-x64` packages statically link the same FFmpeg build. The slim package does not include FFmpeg or OpenCV video I/O.

The FFmpeg build provides OpenCV's required libraries (`avcodec`, `avformat`, `avutil`, and `swscale`), its built-in decoders, encoders, demuxers, and muxers, and non-secure local and network protocols. RTSP, TCP, UDP, HTTP, local files, and pipes are intended to work. CI exercises H.264-over-RTSP through OpenCV and checks a representative baseline of file formats and codecs in the generated feature inventory.

External-library autodetection is disabled. FFmpeg must not silently acquire a dependency merely because the manylinux container adds a development package. The glibc-provided iconv implementation is explicitly enabled and introduces no additional ELF dependency. Hardware acceleration, `libdrm`, `avdevice`, `avfilter`, post-processing, and `swresample` are intentionally excluded because the packaged OpenCV backend does not require them.

x86-64 assembly optimizations are enabled. FFmpeg's assembly objects contain direct PC-relative references to global constants that cannot be interposed when their static archives are linked into `libOpenCvSharpExtern.so`. The Linux linker therefore hides symbols from the four private FFmpeg archives with `--exclude-libs`; this resolves those references without exporting FFmpeg's private implementation from the OpenCvSharp native binding.

TLS is not currently included, so HTTPS and RTSPS are outside the supported feature surface. Adding a TLS backend requires an explicit decision covering license compatibility, CA certificate discovery, binary size, transitive dependencies, manylinux portability, and regression tests.

`build_static_deps.sh` writes the exact configure flags and all enabled protocols, demuxers, muxers, decoders, and encoders to `/opt/ffmpeg/share/opencvsharp/ffmpeg-feature-inventory.txt`. CI uploads that file as the `ffmpeg-feature-inventory` artifact. `verify_ffmpeg_features.sh` reports section counts and fails if the expected baseline disappears, host autodetection is restored, or a TLS backend appears unexpectedly. The final full and headless shared libraries have their ELF `NEEDED` entries printed and validated with `readelf`.
