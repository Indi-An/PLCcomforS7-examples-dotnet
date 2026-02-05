# 04 – Browse PLC Address Space (works with all licenses)

This example demonstrates how to **browse the PLC address space** (symbolic namespace) with PLCcom for S7.

Typical use cases:
- explore available DataBlocks, structs, arrays and variables
- find full symbolic variable names for read/write requests
- build variable lists for your application (HMI/SCADA, diagnostics tools, etc.)

It shows:
- connecting to the PLC with a symbolic device
- importing/loading the PLC project information (symbolic metadata)
- browsing / searching the symbolic namespace
- displaying the results (e.g., in a UI)

---

## How to run

1. Open the project and build it (this example may use a UI such as WinForms).
2. Enter your license credentials (optional):
   - `authentication.User`
   - `authentication.Serial`
3. Set the PLC IP address.
4. Run the program and browse/search the address space.

---

## Notes / Guidance

- Browsing depends on the symbolic metadata of the PLC project.
  For large projects, the initial import can take some time.
- Use the returned full symbolic variable names directly with:
  - `ReadSymbolicRequest.AddFullVariableName(...)`
  - write requests / subscriptions
- If you only need a few variables, it is usually better to request them directly
  instead of browsing the whole address space repeatedly.
