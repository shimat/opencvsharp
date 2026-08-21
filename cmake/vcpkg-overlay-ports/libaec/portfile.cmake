# The builtin port downloads from gitlab.dkrz.de, which rate-limits GitHub-hosted macOS runners.
# Use the upstream project's official GitHub release archive instead.
vcpkg_download_distfile(ARCHIVE
    URLS "https://github.com/Deutsches-Klimarechenzentrum/libaec/releases/download/v${VERSION}/libaec-${VERSION}.tar.gz"
    FILENAME "libaec-${VERSION}.tar.gz"
    SHA512 97f05f6c80c32a9378e7bf8698053c1ee57d852ba988df9f052f3ac66b2f698b7cf7a0ea490c3ee6a5f4b0decac75b5f4fa11ea7a80c477aae5ef28e0a8b9b08
)

vcpkg_extract_source_archive(SOURCE_PATH
    ARCHIVE "${ARCHIVE}"
)

string(COMPARE EQUAL "${VCPKG_LIBRARY_LINKAGE}" "static" BUILD_STATIC)

vcpkg_cmake_configure(
    SOURCE_PATH "${SOURCE_PATH}"
    OPTIONS
        -DBUILD_STATIC_LIBS=${BUILD_STATIC}
        -Dlibaec_INSTALL_CMAKEDIR=share/${PORT}
)
vcpkg_cmake_install()
vcpkg_copy_pdbs()
vcpkg_cmake_config_fixup()
vcpkg_replace_string("${CURRENT_PACKAGES_DIR}/share/libaec/libaec-config.cmake"
    "if(libaec_USE_STATIC_LIBS)"
    "if(\"${BUILD_STATIC}\") # forced by vcpkg"
)

# Compatibility with user's CMake < 3.18 (vcpkg claims support for >= 3.16):
# Make imported targets global so that libaec-config.cmake can create ALIAS targets.
set(_target_file "libaec_shared-targets")
if(BUILD_STATIC)
    set(_target_file "libaec_static-targets")
endif()
file(READ "${CURRENT_PACKAGES_DIR}/share/libaec/${_target_file}.cmake" libaec_targets)
string(REGEX REPLACE " (SHARED|STATIC) IMPORTED" " \\1 IMPORTED \${libaec_maybe_global}" libaec_targets "${libaec_targets}")
file(WRITE "${CURRENT_PACKAGES_DIR}/share/libaec/${_target_file}.cmake" "set(libaec_maybe_global \"\")
if(CMAKE_VERSION VERSION_LESS 3.18)
    set(libaec_maybe_global \"GLOBAL\")
endif()
${libaec_targets}
")

file(REMOVE_RECURSE "${CURRENT_PACKAGES_DIR}/debug/include")

file(INSTALL "${CURRENT_PORT_DIR}/usage" DESTINATION "${CURRENT_PACKAGES_DIR}/share/${PORT}")
vcpkg_install_copyright(FILE_LIST "${SOURCE_PATH}/LICENSE.txt")
