#!/usr/bin/env bash

set -euo pipefail

# --target only applies to a new tag. Check an existing tag before using it.
if tag_commit=$(git rev-parse --verify --quiet "refs/tags/${RELEASE_VERSION}^{commit}"); then
  if [[ "$tag_commit" != "$GITHUB_SHA" ]]; then
    echo "Tag $RELEASE_VERSION points to $tag_commit, expected $GITHUB_SHA"
    exit 1
  fi
  if is_draft=$(gh release view "$RELEASE_VERSION" --json isDraft --jq .isDraft); then
    if [[ "$is_draft" == false ]]; then
      echo "GitHub Release $RELEASE_VERSION already exists"
      exit 0
    fi
    echo "A draft already exists for $RELEASE_VERSION. Review and publish it on GitHub."
    exit 1
  fi
fi

# Stay on this commit's history and use the highest older stable 5.x tag.
tags=$(git tag --merged "$GITHUB_SHA" --sort=-version:refname --list '5.*')
previous_tag=''
while IFS= read -r tag; do
  if [[ "$tag" =~ ^5\.[0-9]+\.[0-9]+\.[0-9]{8}$ && "$tag" != "$RELEASE_VERSION" ]] &&
     printf '%s\n' "$tag" "$RELEASE_VERSION" | sort -V -C; then
    previous_tag=$tag
    break
  fi
done <<< "$tags"
if [[ -z "$previous_tag" ]]; then
  echo "No previous stable 5.x tag found in the history of $GITHUB_SHA"
  exit 1
fi

gh release create "$RELEASE_VERSION" \
  --target "$GITHUB_SHA" \
  --generate-notes \
  --notes-start-tag "$previous_tag"
