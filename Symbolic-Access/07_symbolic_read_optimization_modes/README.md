# 07 – Symbolic Read Optimization Modes (advanced)

This example explains **symbolic read optimization** and demonstrates how different modes can reduce
the number of PLC read operations when reading many variables.

It covers:
- why optimization matters (latency / throughput)
- the available optimization modes (from transparent to more aggressive)
- the SMART restriction (TLS devices only)

---

## Optimization modes

- `NONE`
  - no optimization
  - best for debugging because the read behavior is most transparent

- `OBJECT_BASED`
  - PLCcom may group variables within one root object (e.g., same DB / struct / array)

- `CROSS_OBJECT`
  - PLCcom may group variables across multiple root objects

- `SMART`
  - smart execution plan (TLS device only)

---

## How to run

1. Open `Program.cs`
2. Select the optimization mode in the code
3. Run and compare behavior and performance

---

## Guidance / Best practice

- Start with `NONE` while developing/debugging.
- Switch to `OBJECT_BASED` or `CROSS_OBJECT` for better cycle time once everything works.
- Use `SMART` only with `Tls13Device`.
