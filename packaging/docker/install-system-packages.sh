#!/bin/sh
set -eu

# The .NET images have a CA bundle and can use HTTPS for mirrors that have
# intermittently rejected HTTP requests from hosted CI runners. Bare Ubuntu
# needs its initial package installation to supply ca-certificates first.
if [ -s /etc/ssl/certs/ca-certificates.crt ]; then
    sed -i 's|http://|https://|g' /etc/apt/sources.list.d/ubuntu.sources
fi
apt-get -o Acquire::Retries=3 -o APT::Update::Error-Mode=any update
apt-get -o Acquire::Retries=3 install -y --no-install-recommends "$@"
rm -rf /var/lib/apt/lists/*
