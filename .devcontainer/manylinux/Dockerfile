FROM quay.io/pypa/manylinux_2_28_x86_64

USER root

# Same tools as CI workflow (manylinux.yml) + GitHub CLI
RUN dnf install -y \
    git \
    zip \
    unzip \
    nasm \
    yasm \
    pkg-config \
    ninja-build \
    kernel-headers \
    perl-IPC-Cmd \
    perl-Time-Piece \
    gtk3-devel \
    && dnf config-manager --add-repo https://cli.github.com/packages/rpm/gh-cli.repo \
    && dnf install -y gh \
    && dnf clean all

# vcpkg bootstrap (package install is done later via postCreateCommand
# using /work/vcpkg.json from the mounted workspace)
RUN git clone --filter=blob:none --depth=1 https://github.com/microsoft/vcpkg.git /opt/vcpkg \
    && /opt/vcpkg/bootstrap-vcpkg.sh -disableMetrics

# .NET SDK 10 — builds and runs net8.0 targets (SDK cross-targeting)
RUN curl -fsSL https://dot.net/v1/dotnet-install.sh \
    | bash -s -- --channel 10.0 --install-dir /usr/local/dotnet
ENV PATH="${PATH}:/usr/local/dotnet"
ENV DOTNET_ROOT=/usr/local/dotnet
