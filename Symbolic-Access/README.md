# Symbolic Access – Examples

This folder contains step-by-step examples for **symbolic access** with PLCcom for S7.
Each subfolder is a standalone sample project.

If you are new to PLCcom: start with **01_basic_symbolic_read** and then continue in order.

---

## ✅ Recommended order

### 01_basic_symbolic_read (works with all licenses)
A minimal “hello world” for symbolic reads:
- connect to the PLC
- read a few variables by full symbolic name
- print values and disconnect

---

### 02_symbolic_write_example (works with all licenses)
A minimal example for symbolic writes:
- write one or more values by full symbolic name
- check returned quality and messages

---

### 03_symbolic_subscription_example (works with all licenses)
Demonstrates subscriptions for continuous monitoring:
- subscribe to variables
- receive updates / check latest values
- stop subscription cleanly

---

### 04_browse_plc_address_space (works with all licenses)
Browse and search the symbolic namespace:
- explore DBs/structs/arrays/variables
- find full symbolic variable names for read/write/subscription

---

### 05_validate_server_certificate (works with all licenses)
TLS security example:
- validate the server/PLC certificate when using `Tls13Device`
- recommended validation strategies for production use

---

### 06_alarms (works with all licenses)
Alarm handling example:
- read alarm states
- detect alarm changes
- optionally acknowledge alarms (depending on PLC program/config)

---

### 07_symbolic_read_optimization_modes (advanced / performance)
Demonstrates symbolic read optimization modes:
- `NONE`
- `OBJECT_BASED`
- `CROSS_OBJECT`
- `SMART` (TLS device only)

Use this once basic reads work and you want to optimize cycle time.

---

### 08_symbolic_read_result_hierarchy_scope (advanced / Expert feature)
Demonstrates result hierarchy scope:
- request only a container/root (e.g., a DB)
- access child members by full variable name via `TryGetVariableByFullVariableName(...)`
- uses `eResultHierarchyScope.Auto` (resolved based on license)

Without an appropriate license, PLCcom falls back to `RequestedOnly` and child member lookup returns false/null.

---

## 🔧 Common prerequisites for all examples

1. Enter license credentials (optional)
   - Without credentials the runtime is limited to **10 minutes**.
2. Configure the PLC IP address
   - examples typically use `192.168.1.100`
3. Choose the correct device type
   - `Tls13Device` for modern TLS symbolic access (TIA V17+)
   - `LegacySymbolicDevice` for older firmware / older TIA versions
4. Check your PLC project
   - the referenced symbolic variable names must exist in your PLC program

---

## Notes / Guidance

- For troubleshooting and first tests, start with:
  - read optimization = `NONE`
  - scope = `RequestedOnly`
- For best performance with many variables, see:
  - `07_symbolic_read_optimization_modes`
- For container/root reads with member lookup, see:
  - `08_symbolic_read_result_hierarchy_scope`
