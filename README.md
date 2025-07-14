# PLCcom for S7 - Quick Start Examples

![PLCcom Logo](https://www.indi-an.com//wp-content/uploads/2023/10/indi.logo2021.1_rgb_PLCcom_300.png)

This repository provides quick-start examples for developers using the **PLCcom for S7** library. These examples demonstrate how easy it is to integrate PLCcom into your .NET applications, enabling seamless communication with Siemens S7 PLCs.

## Overview of PLCcom for S7

PLCcom for S7 is a high-performance SDK designed specifically for .NET developers, enabling comfortable and efficient communication with Siemens S7 PLCs. It supports various S7 controllers (200, 300, 400, 1200, 1500, SoftSPS WinAC RTX, Logo! series) and CPUs from other manufacturers (e.g., VIPA series).

### Key Features
- Symbolic and direct access to PLC data
- Support for a wide range of data types (Raw, Bit, Byte, Word, DWord, Real, LReal, String, S7_String, Date, Time, and more)
- High-performance optimized communication
- Simultaneous multi-PLC access
- Comprehensive error handling and diagnostics
- Extensive code examples included
- AutoConnect and asynchronous connection
- Subscription management for variables and alarms
- Reading system status, diagnostic data, and block management
- Start and stop CPU
- Reading and setting PLC time
- Backup, restore, and delete blocks
- Detailed block information output (code, creation language, author)
- Authentication via password or user/password

For a full list of supported features, detailed descriptions, and compatibility information, refer to the official documentation [here](https://docs.plccom.net/help_s7/net/help/html/R_Project_PLCCom_Documentation.htm).

## Requirements

- .NET Framework 4.7.2 or higher
- .NET 5.0
- .NET 6.0
- .NET 7.0
- .NET 8.0
- .NET 9.0
- Visual Studio 2019 or newer (recommended VS2022)

## Important Licensing Information

**Examples License:**
- All examples provided in this repository are released under the **MIT License**. You are free to use, modify, and distribute these examples according to the terms of the MIT license.

**PLCcom Library License:**
- **PLCcom for S7** itself is proprietary software and is **NOT** included under the MIT license. To use the PLCcom library in your own projects, you must acquire an appropriate license and accept the EULA for the PLCcom for S7 library. More information about purchasing a license can be found [here](https://www.indi-an.com/en/plccom/for-s7/fors7-overview/).

**Test License:**
- For execution, a test license is required. Without license information, the library will work for 15 minutes. If a longer test period is desired, users can request an extended test license by sending a brief email to [sales@indi-an.com](mailto:sales@indi-an.com).

## Getting Started

1. Clone this repository.
2. Install the PLCcom for S7 NuGet package into your project from the NuGet Package Manager:

```bash
Install-Package PLCcomForS7
```

## ⚠️ Important Safety Notice

The examples in this repository are **for demonstration purposes only** and **must _not_** be used in production, safety‑critical, or industrial environments.  
**Use at your own risk!** Deploying these examples in real systems may lead to personal injury, property damage, or environmental harm and is **strictly prohibited**.

> **EULA Requirement**  
> Use of the PLCcom for S7 library is permitted **only after you have read and explicitly accepted the End‑User License Agreement (EULA)**. If you do not accept the EULA, you must not install, compile, or otherwise use the library.

Indi.An GmbH disclaims all liability—direct, indirect, incidental, or consequential—arising from the use or misuse of these examples.


##### Trademark Information: #####
All product names, company names, and trademarks referenced in this repository are trademarks or registered trademarks of their respective owners. There is no affiliation between the mentioned trademarks or their owners and Indi.An GmbH. Any mention of trademarks is solely for reference purposes regarding usage and application.

