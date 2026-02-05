# 04 – Simple Dataserver (PUT/GET access) (Expert feature)

This example demonstrates a **simple data server** built on classic **PUT/GET access**.

Goal:
- provide a small server/service that reads PLC data and makes it available to clients
  (e.g., for monitoring, integration tests, or data distribution within a network)

---

## License note (important)

This example is available **only with an Expert license**.

If the required license is not present, the example may fail at runtime (depending on the implementation).

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials:
   - `authentication.User`
   - `authentication.Serial`
3. Set the PLC IP address
4. Ensure PUT/GET is enabled (depending on PLC model / security settings)
5. Run the program and follow the console/UI output for server startup and data updates

---

## Notes / Guidance

- This is a demonstration of the general approach for a lightweight data server.
  The exact protocol and client access depend on the implementation in this sample.
- If you want to learn PUT/GET basics first, start with:
  - `01_simple_read_example`
  - `02_simple_write_example`
- If communication fails, verify:
  - PLC security settings (PUT/GET permission)
  - connection parameters (IP / rack / slot if applicable)
  - correct address ranges and data types
