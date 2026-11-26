"""Enforce readable project boundaries, namespaces and one C# type per source file."""
from pathlib import Path
import re
import xml.etree.ElementTree as ET

repo = Path(__file__).resolve().parents[2]
projects = {
    "Reality.Core": (repo / "src/Reality.Core", set()),
    "Reality.Science": (repo / "src/Reality.Science", {"Reality.Core"}),
    "Reality.Philosophy": (repo / "src/Reality.Philosophy", {"Reality.Core"}),
    "Reality.Investigation": (repo / "src/Reality.Investigation", {"Reality.Core", "Reality.Science", "Reality.Philosophy"}),
    "Reality.Console": (repo / "src/Reality.Console", {"Reality.Core", "Reality.Science", "Reality.Philosophy", "Reality.Investigation"}),
    "Reality.Tests": (repo / "tests/Reality.Tests", {"Reality.Core", "Reality.Science", "Reality.Philosophy", "Reality.Investigation"}),
}
type_pattern = re.compile(r"^(?:public|internal|file)\s+(?:(?:sealed|abstract|static|partial|readonly)\s+)*(?:class|interface|record|enum|struct)\s+(\w+)", re.MULTILINE)
namespace_pattern = re.compile(r"^namespace\s+([A-Za-z_]\w*(?:\.[A-Za-z_]\w*)*)\s*;", re.MULTILINE)
failures = []

for name, (folder, required) in projects.items():
    csproj = folder / f"{name}.csproj"
    if not csproj.is_file():
        failures.append(f"{name}: missing project file")
        continue
    root = ET.parse(csproj).getroot()
    references = root.findall(".//ProjectReference")
    actual = set()
    for reference in references:
        path = (folder / reference.attrib["Include"].replace("\\", "/")).resolve()
        if not path.is_file():
            failures.append(f"{name}: missing referenced project {path}")
        else:
            actual.add(path.stem)
    if actual != required:
        failures.append(f"{name}: project references {sorted(actual)} do not match expected {sorted(required)}")

    for path in sorted(folder.rglob("*.cs")):
        rel = path.relative_to(folder)
        if rel == Path("Program.cs") and name in ("Reality.Console", "Reality.Tests"):
            continue
        if rel.parent == Path("."):
            failures.append(f"{name}/{rel}: source types belong in descriptive folders; only Program.cs may be at a project root")
            continue

        content = path.read_text(encoding="utf-8")
        types = type_pattern.findall(content)
        if len(types) != 1:
            failures.append(f"{name}/{rel}: expected one top-level type, found {types}")
            continue
        type_name = types[0]
        if rel.stem != type_name:
            failures.append(f"{name}/{rel}: expected filename {type_name}.cs")
        expected_namespace = name + "." + ".".join(rel.parent.parts)
        match = namespace_pattern.search(content)
        if match is None or match.group(1) != expected_namespace:
            failures.append(f"{name}/{rel}: expected namespace {expected_namespace}")
        is_interface = bool(re.search(r"\binterface\s+" + re.escape(type_name) + r"\b", content))
        if is_interface and rel.parent.name != "Interfaces":
            failures.append(f"{name}/{rel}: interfaces must be in an Interfaces folder")
        if rel.parent.name == "Interfaces" and not is_interface:
            failures.append(f"{name}/{rel}: Interfaces folders must contain only interfaces")

if list((repo / "src/Reality").rglob("*.csproj")) or list((repo / "src/Reality").rglob("*.cs")):
    failures.append("Legacy single-project sources remain under src/Reality/")
if not (repo / "Reality.sln").is_file():
    failures.append("Missing repository-root Reality.sln")
if failures:
    raise SystemExit("\n".join(failures))
print("Verified six project boundaries, references, namespaces, and one type per file.")
