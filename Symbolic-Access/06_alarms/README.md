# 06 – Alarms (works with all licenses)

This example demonstrates how to work with **alarms** using PLCcom for S7.

Typical use cases:
- display active alarms in an HMI/SCADA application
- log alarms for diagnostics and traceability
- acknowledge/reset alarms (if supported by your PLC program and configuration)

It shows:
- connecting to the PLC with a symbolic device
- reading current alarm states (active/inactive)
- detecting changes (new alarms, cleared alarms)
- optionally acknowledging alarms (depending on the example implementation)

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials (optional):
   - `authentication.User`
   - `authentication.Serial`
3. Set the PLC IP address
4. Run the program and trigger alarms in your PLC program to see changes

---

## Notes / Guidance

- The exact alarm behavior depends on your PLC project and how alarms are implemented/configured.
- If you need frequent updates, consider combining alarm handling with subscriptions
  (see `03_symbolic_subscription_example`) instead of polling.
- Always check the returned `Quality` and `Message` values to handle partial reads and errors robustly.
