# 08 – Result Hierarchy Scope (Expert feature)

This example demonstrates **Result Hierarchy Scope** using `eResultHierarchyScope.Auto`.

Goal:
- request only a container/root (e.g., `DataBlock_1`)
- then access child members by full variable name via `TryGetVariableByFullVariableName(...)`,
  e.g. `DataBlock_1.ByteValue`

---

## License behavior (important)

- With an Expert license:
  - `Auto` is resolved to `RequestedAndChildMembers`
  - child member lookup works

- With a Standard license:
  - `Auto` is resolved to `RequestedOnly`
  - child member lookup is NOT available
  - `TryGet...` returns false (and `Get...` returns null)

If you explicitly request `RequestedAndChildMembers` without an appropriate license,
`ReadData(...)` throws an exception (license restriction).

---

## Technical note

Result hierarchy scope does NOT change what is read from the PLC.
It only changes what the result may expose via Get/TryGet and internal indexing.

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials (optional)
3. Set the PLC IP address
4. Run the example and watch the child lookup output
