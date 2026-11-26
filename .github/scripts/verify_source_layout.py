"""Enforce one C# top-level type per file and domain-local Interfaces folders.

This is a lightweight source convention check, not a replacement for the compiler.
"""
from pathlib import Path
import re

root = Path(__file__).resolve().parents[2] / "src" / "Reality"
pattern = re.compile(
    r"^(?:public|internal|file)\s+(?:(?:sealed|abstract|static|partial|readonly)\s+)*"
    r"(?:class|interface|record|enum|struct)\s+(\w+)",
    re.MULTILINE,
)
failures = []

for path in sorted(root.rglob("*.cs")):
    if path.name == "Program.cs":
        continue
    text = path.read_text(encoding="utf-8")
    types = pattern.findall(text)
    if len(types) != 1:
        failures.append(f"{path.relative_to(root)}: expected exactly one type, found {types}")
        continue
    name = types[0]
    if path.stem != name:
        failures.append(f"{path.relative_to(root)}: file must be named {name}.cs")
    if re.match(r"^I[A-Z]", name) and path.parent.name != "Interfaces":
        failures.append(f"{path.relative_to(root)}: interface must be in an Interfaces folder")
    if path.parent.name == "Interfaces" and not re.match(r"^I[A-Z]", name):
        failures.append(f"{path.relative_to(root)}: only interfaces belong in an Interfaces folder")

if failures:
    raise SystemExit("\n".join(failures))

print("Source layout verified: one type per file and separate Interfaces folders.")
