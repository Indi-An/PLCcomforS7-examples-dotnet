# 05 – Validate Server Certificate (TLS) (works with all licenses)

This example demonstrates how to **validate the PLC/server certificate** when using TLS-based symbolic access
(e.g., `Tls13Device`).

Why this matters:
- TLS protects the connection against tampering and man-in-the-middle attacks.
- Proper certificate validation ensures you are really talking to the expected PLC/device.

It shows:
- creating a TLS-based symbolic device (`Tls13Device`)
- registering a certificate validation callback / handler
- deciding whether to accept or reject the server certificate
- connecting with TLS and handling validation failures

---

## How to run

1. Open `Program.cs`
2. Enter your license credentials:
   - `authentication.User`
   - `authentication.Serial`
   - For execution, a (test) license is required. Users can request a trial license themselves via the PLCcom for S7 [download website](https://www.indi-an.com/en/plccom/for-s7/fors7-overview/)
3. Set the PLC IP address
4. Run the program and observe the certificate validation behavior

---

## Notes / Guidance

- For production systems, do not blindly accept every certificate.
  Prefer a verification strategy such as:
  - certificate thumbprint / fingerprint pinning
  - a trusted CA chain (if applicable)
  - comparing subject/issuer + validity period
- During development you may temporarily accept unknown certificates,
  but make sure to switch to strict validation before deployment.
- If certificate validation fails, `Connect()` will not succeed.
