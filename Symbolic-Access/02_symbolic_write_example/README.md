# 02 – Symbolic Write Example (works with all licenses)

This example demonstrates how to **write** values to a PLC using **symbolic addresses**.

It shows:
- creating a symbolic device (`Tls13Device` or `LegacySymbolicDevice`)
- connecting to the PLC
- creating a symbolic write request
- writing one or more variables by full variable name
- checking the result quality and message

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials (optional):
   - `authentication.User`
   - `authentication.Serial`
   - For execution, a (test) license is required. Users can request a trial license themselves via the PLCcom for S7 [download website](https://www.indi-an.com/de/plccom/for-s7/fuers7-download/)
3. Set the PLC IP address
4. Make sure the target variables exist in your PLC project and are writable
5. Run the program

---

## Notes / Guidance

- Symbolic writes are most reliable if the target variables are simple leaf variables
  (e.g., BOOL, INT, REAL, etc.).
- Always check the returned `Quality` and `Message`.
- If you need to write multiple values cyclically, keep the connection open and reuse the device object.
