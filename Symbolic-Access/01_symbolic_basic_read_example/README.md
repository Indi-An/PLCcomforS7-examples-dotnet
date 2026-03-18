# 01 – Basic Symbolic Read (works with all licenses)

This example is the minimal starting point for PLCcom symbolic reads.

It demonstrates:
- creating a symbolic device (`Tls13Device` or `LegacySymbolicDevice`)
- `Connect()`
- creating a `ReadSymbolicRequest`
- adding variables using `AddFullVariableName(...)`
- reading values with `ReadData(...)`
- printing results and disconnecting

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials:
   - `authentication.User`
   - `authentication.Serial`
   - For execution, a (test) license is required. Users can request a trial license themselves via the PLCcom for S7 [download website](https://www.indi-an.com/en/plccom/for-s7/fors7-overview/)
3. Set your PLC IP address
4. Run the program

---

## Notes

- This example keeps configuration simple:
  - optimization mode is `NONE`
  - only explicitly requested variables are read and printed
- After this works, continue with:
  - `07_symbolic_read_optimization_modes` for performance tuning
