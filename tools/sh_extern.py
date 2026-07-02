"""Phase 1b helper: change the object handle param (first `IntPtr <name>`) of a module's base
P/Invoke entry points to OpenCvSafeHandle, so callers can pass Handle.

Usage: python sh_extern.py <NativeMethods_file.cs> <prefix> [extra-excludes...]

Acts on `public static partial ... <name>(...)` whose <name> starts with <prefix> and is NOT a
factory/lifetime function (name containing _new/_create/_delete/_get/_Ptr_). Replaces the FIRST
`IntPtr <ident>` in the parameter list with `OpenCvSafeHandle <ident>` (skips `IntPtr[]`). Any
mistake surfaces as a compile-time type mismatch, so the build is the oracle.
"""
import re
import sys
import pathlib

path = pathlib.Path(sys.argv[1]).resolve()
prefix = sys.argv[2]
# Note: do NOT exclude "_get" broadly -- it would skip legitimate getters (getVarCount, ...).
# The factory get-pointer functions are named *_Ptr_*_get and are covered by "_Ptr_".
EXCLUDE = ("_new", "_create", "_delete", "_Ptr_") + tuple(sys.argv[3:])

text = path.read_text(encoding="utf-8-sig")
nl = "\r\n" if "\r\n" in text else "\n"
lines = text.replace("\r\n", "\n").split("\n")

decl_re = re.compile(r"public static (?:unsafe )?partial ExceptionStatus (" + re.escape(prefix) + r"\w*)\s*\(")
out = []
i = 0
changed = 0
while i < len(lines):
    m = decl_re.search(lines[i])
    if not m or any(x in m.group(1) for x in EXCLUDE):
        out.append(lines[i])
        i += 1
        continue
    # collect the declaration up to the first ';'
    j = i
    while ";" not in lines[j]:
        j += 1
    block = "\n".join(lines[i:j + 1])
    # Only the (in) object handle param; never an out/ref param such as `out IntPtr returnValue`.
    new_block, n = re.subn(r"(?<!out )(?<!ref )\bIntPtr (?=[A-Za-z_])", "OpenCvSafeHandle ", block, count=1)
    if n:
        changed += 1
    out.extend(new_block.split("\n"))
    i = j + 1

path.write_text(nl.join(out), encoding="utf-8", newline="")
print(f"{path.name}: converted {changed} entry points (prefix {prefix})")
