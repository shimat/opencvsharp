set(VCPKG_TARGET_ARCHITECTURE x64)
set(VCPKG_CMAKE_SYSTEM_NAME Linux)
set(VCPKG_LIBRARY_LINKAGE static)

# Release-only build: skip debug libraries to reduce build time and artifact size.
set(VCPKG_BUILD_TYPE release)
