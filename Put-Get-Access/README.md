# PUT/GET Access – Examples

This folder contains examples for classic **PUT/GET access**.
Each subfolder is a standalone sample project.

If you are new to PUT/GET: start with **01_simple_read_example** and continue in order.

---

## ✅ Recommended order

### 01_simple_read_example (works with all licenses)
A minimal “hello world” read example using PUT/GET access:
- connect to the PLC
- read a value (or a small set of values)
- print results and disconnect

---

### 02_simple_write_example (works with all licenses)
A minimal write example using PUT/GET access:
- connect to the PLC
- write one or more values
- check returned quality/message

---

### 03_optimized_reading_and_writing (Expert feature)
Demonstrates optimized reading and writing with PUT/GET access:
- grouping read/write items to reduce overhead
- improving cycle time for larger item sets

**Important:** Optimization mode **AUTO** is available **only with an Expert license**.

---

### 04_simple_dataserver (Expert feature)
Demonstrates a simple data server built on PUT/GET access:
- read PLC data and provide it via a small server/service concept
- useful as a starting point for integration tools or monitoring solutions

This example is available **only with an Expert license**.

---

## 🔧 Common prerequisites for all examples

1. Enter license credentials (optional)
   - Without credentials the runtime is limited to **10 minutes**
2. Configure the PLC connection
   - set PLC IP address
   - rack/slot if applicable (depending on PLC model and your device configuration)
3. Ensure PUT/GET is enabled
   - PUT/GET access may be restricted by PLC security/protection settings

---

## Notes / Guidance

- If read/write operations fail, verify:
  - PLC protection/security settings (PUT/GET permission)
  - correct addresses, data types and lengths
  - correct connection parameters (IP / rack / slot if applicable)
- For modern symbolic access (TIA project / symbolic names), see:
  - `Symbolic-Access/`
