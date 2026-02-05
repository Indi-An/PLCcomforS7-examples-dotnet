# 03 – Symbolic Subscription Example (works with all licenses)

This example demonstrates **symbolic subscriptions** with PLCcom for S7.

A subscription is useful when you want to:
- monitor variables continuously
- get updates when values change
- avoid manual polling loops in your application

It shows:
- creating a symbolic device (`Tls13Device` or `LegacySymbolicDevice`)
- connecting to the PLC
- creating a subscription
- adding symbolic variables to the subscription
- receiving updates / reading the latest values
- stopping the subscription and disconnecting

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials (optional):
   - `authentication.User`
   - `authentication.Serial`
3. Set the PLC IP address
4. Ensure the target variables exist in your PLC project
5. Run the program and observe value updates

---

## Notes / Guidance

- Use subscriptions for UI dashboards, monitoring, alarms, and trend recording.
- Prefer subscriptions over tight polling loops if you need frequent updates.
- Always stop/dispose subscriptions before disconnecting to release resources cleanly.
- If you subscribe to many variables, keep update rates reasonable to reduce PLC and network load.
