"""Check the minimum macOS versions recorded in static archives and dylibs."""

import argparse
from pathlib import Path
import re
import subprocess
import sys


def version_tuple(version):
    parts = tuple(int(part) for part in version.split("."))
    return parts + (0,) * (3 - len(parts))


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("deployment_target", type=version_tuple)
    parser.add_argument("paths", nargs="+", type=Path)
    args = parser.parse_args()

    files = []
    for path in args.paths:
        if path.is_dir():
            archives = sorted(path.rglob("*.a"))
            if not archives:
                parser.error(f"No static archives found in {path}")
            files.extend(archives)
        elif path.is_file():
            files.append(path)
        else:
            parser.error(f"Missing library path: {path}")

    failed = False
    for path in files:
        result = subprocess.run(
            ["otool", "-l", str(path)], capture_output=True, text=True, check=True
        )
        # Assembly objects can omit version commands. Check every recorded
        # version, including the legacy command used by older dependencies.
        versions = re.findall(
            r"\bcmd LC_(?:BUILD_VERSION|VERSION_MIN_MACOSX)\n"
            r"\s+cmdsize \d+\n(?:\s+platform \S+\n)?"
            r"\s+(?:minos|version) ([\d.]+)",
            result.stdout,
        )
        if not versions and path.name == "libippicv.a":
            # OpenCV's prebuilt macOS IPP 2021.9.1 archive has no version
            # commands in any of its 15,958 objects. Tracked in issue #2213.
            print(f"{path}: prebuilt IPP archive has no deployment-version commands")
            continue

        if not versions:
            print(f"ERROR: No macOS deployment version found in {path}", file=sys.stderr)
            failed = True
            continue

        newest = max(versions, key=version_tuple)
        print(f"{path}: {len(versions)} version commands, maximum macOS {newest}")
        if version_tuple(newest) > args.deployment_target:
            print(f"ERROR: {path} exceeds the macOS deployment target", file=sys.stderr)
            failed = True

    return 1 if failed else 0


if __name__ == "__main__":
    sys.exit(main())
