# 01 – Simple Read Example (PUT/GET access) (works with all licenses)

This example demonstrates a **basic read** using classic **PUT/GET access**.

It shows:
- creating a device for PUT/GET communication
- connecting to the PLC
- reading one or more values
- checking result quality and printing values
- disconnecting cleanly

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials:
   - `authentication.User`
   - `authentication.Serial`
   - For execution, a (test) license is required. Users can request a trial license themselves via the PLCcom for S7 [download website](https://www.indi-an.com/en/plccom/for-s7/fors7-overview/).
3. Set the PLC IP address
4. Ensure PUT/GET is enabled (depending on PLC model / security settings)
5. Run the program

---

## Notes / Guidance

- PUT/GET access typically uses absolute addressing (depending on your API usage in the sample).
- If a read fails, verify:
  - connection parameters (IP / rack / slot if applicable)
  - PLC security settings (PUT/GET permission)
  - the addressed memory area and data type
- For modern symbolic access (TIA project / symbolic names), see the examples in:
  `Symbolic-Access/`
