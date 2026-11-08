#!/usr/bin/env bash

set -euo pipefail
shopt -s nullglob

for f in *.nupkg *.snupkg; do
  case "$f" in
    *-beta*) ;;
    *) continue ;;
  esac

  if ! [[ "$f" =~ ^OpenCvSharp5\..*[0-9]{8}-beta[0-9]*\.s?nupkg$ ]]; then
    echo "ERROR: Unexpected -beta package file name: $f"
    exit 1
  fi

  tmpdir=$(mktemp -d)
  nuspec_entry=$(unzip -Z1 "$f" | grep '\.nuspec$' || true)
  if [ -n "$nuspec_entry" ]; then
    nuspec_local="$tmpdir/$(basename "$nuspec_entry")"
    unzip -p "$f" "$nuspec_entry" > "$nuspec_local"

    # Strip -beta / -betaN from the package's own <version>
    sed -i -E 's/-beta-?[0-9]*(<\/version>)/\1/' "$nuspec_local"

    # Strip -beta / -betaN from dependency version references (meta-packages), except ubuntu/manylinux ones
    case "$f" in
      *ubuntu*) ;;
      *) sed -i -E 's/(version="[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{8})-beta-?[0-9]*/\1/g' "$nuspec_local" ;;
    esac

    # Replace the existing .nuspec entry in place without touching the rest of the archive
    zip -q -d "$f" "$nuspec_entry"
    zip -q -j "$f" "$nuspec_local"
  fi
  rm -rf "$tmpdir"

  newname=$(echo "$f" | sed -E 's/-beta-?[0-9]*//')
  mv "$f" "$newname"
done
