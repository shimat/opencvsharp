"""Phase 1b helper: in a wrapper class file, pass the SafeHandle and drop GC.KeepAlive(this).

Usage: python sh_classfile.py <file.cs> [accessor]
  - replaces the this-handle accessor (default 'RawPtr', word-boundary) with 'Handle'
  - removes lines that are exactly 'GC.KeepAlive(this);' (any indentation)

ONLY safe for methods that do NOT return an interior pointer dereferenced after the call
(data / c_str / getPointer / etc.) -- the caller must confirm the file has no such method.
"""
import re
import sys
import pathlib

path = pathlib.Path(sys.argv[1]).resolve()
accessor = sys.argv[2] if len(sys.argv) > 2 else "RawPtr"

text = path.read_text(encoding="utf-8-sig")
nl = "\r\n" if "\r\n" in text else "\n"
lines = text.replace("\r\n", "\n").split("\n")

out = []
removed = 0
for line in lines:
    if line.strip() == "GC.KeepAlive(this);":
        removed += 1
        continue
    # Only the bare this-handle accessor (e.g. `CvPtr`), never `other.CvPtr`.
    out.append(re.sub(rf"(?<!\.)\b{re.escape(accessor)}\b", "Handle", line))

new = nl.join(out)
path.write_text(new, encoding="utf-8", newline="")
print(f"{path.name}: accessor {accessor}->Handle, removed {removed} KeepAlive(this)")
