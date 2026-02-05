# 03 – Optimized Reading and Writing (PUT/GET access) (Expert feature)

This example demonstrates **optimized** reading and writing using classic **PUT/GET access**.

Goal:
- reduce communication overhead by grouping multiple read/write items into fewer operations
- improve cycle time when reading/writing many values

---

## License note (important)

This example uses an **optimization mode**.  
The optimization mode **AUTO** is available **only with an Expert license**.

- With a Standard license:
  - AUTO is not available
  - use the non-optimized approach (or the specific non-AUTO mode shown in the sample)
- With an Expert license:
  - AUTO can be enabled to let PLCcom choose an efficient execution strategy

If AUTO is selected without an appropriate license, the operation may fail (depending on the example implementation).

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials (optional):
   - `authentication.User`
   - `authentication.Serial`
3. Set the PLC IP address
4. Ensure PUT/GET is enabled (depending on PLC model / security settings)
5. Run the program and compare behavior/performance with and without optimization

---

## Notes / Guidance

- Use optimized read/write when you handle **many** items per cycle.
- For debugging and initial setup, start with the simple examples:
  - `01_simple_read_example`
  - `02_simple_write_example`
- If you see unexpected behavior, verify:
  - PLC security settings (PUT/GET permission)
  - correct address ranges and data types
  - selected optimization mode and license availability
