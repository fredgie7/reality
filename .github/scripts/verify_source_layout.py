"""Check C# file, folder, and namespace conventions.

Only Program.cs may be a C# source file at the project root. All other
sources have one matching type and use a namespace derived from the folder.
"""
from pathlib import Path
import re

root = Path(__file__).resolve().parents[2] / "src" / "Reality"
type_pattern = re.compile(
    r"^(?:public|internal|file)\s+(?:(?:sealed|abstract|static|partial|readonly)\s+)*"
    r"(?:class|interface|record|enum|struct)\s+(\w+)",
    re.MULTILINE,
)
namespace_pattern = re.compile(r"^namespace\s+([A-Za-z_][\w.]*)\s*;", re.MULTILINE)
failures = []

for path in sorted(root.rglob("*.cs")):
    relative = path.relative_to(root)
    if relative == Path("Program.cs"):
        continue
    if relative.parent == Path("."):
        failures.append(f"{relative}: only Program.cs belongs directly under src/Reality/")
        continue

    contents = path.read_text(encoding="utf-8")
    names = type_pattern.findall(contents)
    if len(names) != 1:
        failures.append(f"{relative}: expected exactly one top-level type, found {names}")
        continue

    name = names[0]
    if path.stem != name:
        failures.append(f"{relative}: file must be named {name}.cs")

    namespace = namespace_pattern.search(contents)
    expected = "Reality." + ".".join(relative.parent.parts)
    if namespace is None or namespace.group(1) != expected:
        actual = namespace.group(1) if namespace else "(missing)"
        failures.append(f"{relative}: namespace should be {expected}, not {actual}")

    is_interface = bool(re.match(r"^I[A-Z]", name)) and bool(re.search(r"\binterface\s+" + re.escape(name) + r"\b", contents))
    if is_interface and path.parent.name != "Interfaces":
        failures.append(f"{relative}: interfaces must be under their domain's Interfaces/ folder")
    if path.parent.name == "Interfaces" and not is_interface:
        failures.append(f"{relative}: Interfaces/ folders should contain only interfaces")

if failures:
    raise SystemExit("\n".join(failures))
print("C# file layout and namespaces match domain folders.")
