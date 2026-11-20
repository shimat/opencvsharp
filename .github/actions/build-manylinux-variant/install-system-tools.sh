#!/usr/bin/env bash
set -euo pipefail

# A transient mirror response can leave invalid metadata cached by DNF.
for attempt in 1 2 3; do
    if dnf install -y "$@"; then
        exit 0
    else
        result=$?
    fi

    if [ "$attempt" -eq 3 ]; then
        exit "$result"
    fi

    echo "DNF install failed (attempt $attempt/3). Refreshing metadata before retry."
    dnf clean metadata
    sleep "$((attempt * 5))"
done
