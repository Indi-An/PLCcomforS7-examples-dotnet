# 02 – Simple Write Example (PUT/GET access) (works with all licenses)

This example demonstrates a **basic write** using classic **PUT/GET access**.

It shows:
- creating a device for PUT/GET communication
- connecting to the PLC
- writing one or more values
- verifying the operation result (quality/message)
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

- PUT/GET writes usually require the PLC to allow external write access (security setting).
- Always check the returned quality/status and handle errors (e.g., access denied, wrong address, wrong data type).
- If the write fails, verify:
  - connection parameters (IP / rack / slot if applicable)
  - PLC protection/security settings (PUT/GET permission)
  - the addressed memory area and correct data type/length
- For modern symbolic writes (TIA project / symbolic names), see:
  `Symbolic-Access/02_symbolic_write_example`
