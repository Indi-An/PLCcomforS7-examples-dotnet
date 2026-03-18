# Full-Test-App – PLCcom Feature Test Application (WinForms)

This project is a **C# WinForms test application** that bundles many PLCcom features in one place.
It is intended as a **hands-on toolbox** for evaluation, troubleshooting and quick experiments.

Typical use cases:
- verify connectivity and basic settings (IP / device type / credentials)
- explore and test symbolic access
- try reads, writes, subscriptions, browsing, alarms, etc.
- reproduce issues for support (with logs / screenshots)

---

## What this app provides

Depending on the current implementation, the app can include modules such as:
- Connect / Disconnect
- Symbolic Read / Write
- Subscriptions (continuous monitoring)
- Browse PLC address space (symbolic namespace)
- TLS certificate validation / connection security
- Alarms (read/monitor/acknowledge depending on PLC program)
- Logging / diagnostics

---

## How to run

1. Open the solution in Visual Studio and select the **Full-Test-App** as startup project.
2. Build and run.
3. Configure:
   - PLC IP address
   - device type (`Tls13Device` for modern TLS access / `LegacySymbolicDevice` for older firmware)
   - optional: username/password (if configured on the PLC)
   - optional: license credentials (`authentication.User` / `authentication.Serial`)
4. Use the UI modules to execute read/write/browse/subscription actions.

---

## License note
- For execution, a (test) license is required. Users can request a trial license themselves via the PLCcom for S7 [download website](https://www.indi-an.com/de/plccom/for-s7/fuers7-download/).


---

## Notes / Guidance

- This application is a **demo/test tool**. It is not meant to be a production-ready HMI/SCADA runtime.
- If you are looking for minimal, focused samples, see the projects in:
  `Symbolic-Access/`
- For support requests, please include:
  - the selected device type and PLC firmware/TIA version
  - the exact symbolic variable names used
  - screenshots and/or logs from the app
