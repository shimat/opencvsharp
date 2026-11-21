"""Group repeated archive platform warnings while CI retains the full linker log."""

from collections import Counter
import re
import sys


def main():
    warnings = Counter()
    pattern = re.compile(
        r"ld: warning: no platform load command found in '(.+\.a)"
        r"(?:\[[^\]]+\])?\[\d+\]\([^']+\)', assuming: macOS"
    )
    for line in sys.stdin:
        match = pattern.fullmatch(line.rstrip("\r\n"))
        if match:
            warnings[match.group(1)] += 1
        else:
            print(line, end="", flush=True)

    for archive, count in warnings.items():
        print(
            f"ld: warning: {archive}: {count} linked objects omit macOS platform metadata. "
            "See the full Extern linker-log artifact for individual diagnostics."
        )


if __name__ == "__main__":
    main()
