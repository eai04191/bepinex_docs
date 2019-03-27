---
uid: installation
---

# Installing BepInEx

## Requirements

BepInEx requires a game using Unity that uses Mono runtime (i.e. has `mono.dll`). BepInEx has been successfully tested to be working on Unity versions 5.4 - 2017.2.

## Upgrading from previous versions

For upgrading guide, refer to the [migration guide](./Migration).

## Installation

1. Download the latest BepInEx from [releases page](https://github.com/BepInEx/BepInEx/releases).
2. Extract the contents of the archive into the game's root folder
3. If the game's executable is 32-bit version, replace `winhttp.dll` with the one in `x86` folder.
4. Run the game once to let BepInEx create configuration files and folders
5. Install plug-ins and patchers into `BepInEx` folder
6. Configure BepInEx with `BepInEx/config.ini`



