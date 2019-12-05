---
uid: configuration
---

## Configuration file

On its first launch, BepInEx creates `config.ini` file into `BepInEx` folder. This file is used to configure various aspects of BepInEx and the plug-ins.

> **NOTE TO DEVELOPERS**  
> BepInEx provides only the most basic single-file configuration capability via `Config` class.  
> If you want a separate configuration file for your own plug-in, make your own configuration file parser.


Below is the listing of all BepInEx configuration options.

## Quicklinks

- [Configuration file](#configuration-file)
- [Quicklinks](#quicklinks)
  - [`BepInEx` section](#bepinex-section)
    - [`console`](#console)
    - [`console-shiftjis`](#console-shiftjis)
    - [`preloader-logconsole`](#preloader-logconsole)
    - [`logger-displayed-levels`](#logger-displayed-levels)
    - [`chainloader-log-unity-messages`](#chainloader-log-unity-messages)
- [`Preloader` section](#preloader-section)
    - [`entrypoint-assembly`](#entrypoint-assembly)
    - [`entrypoint-type`](#entrypoint-type)
    - [`entrypoint-method`](#entrypoint-method)
    - [`dump-assemblies`](#dump-assemblies)

### `BepInEx` section

This section contains options related to logging.

#### `console`
**Default:** `false`  

Specifies whether to open the console on game start. BepInEx (and some Unity games) writes all log messages into the console. Recommended to enable.

#### `console-shiftjis`
**Default:** `false`

If enabled, changes the codepage of the console to that of Shift-JIS. This is useful if the game outputs messages with Japanese characters into the console.

If disabled, the codepage will be UTF-8.

#### `preloader-logconsole`
**Default:** `false`

If enabled, BepInEx will create `preloader_xxx_xxx.log` on every game launch. The log will contain debug information from the preloader phase.

If disabled, BepInEx will create the log only when an error occurs during preloader phase.

#### `logger-displayed-levels`
**Default:** `Info`

Specifies the maximum severity of the log message to be displayed in BepInEx's console.

Possible values:

| Value | Level | Purpose |
| --- | --- | --- |
| `None` | 0 | Disables all log messages |
| `Fatal` | 1 | Errors which cannot be recovered from; the game cannot continue to run |
| `Error` | 2 | Errors are recoverable from; the game can be run, albeit with further errors |
| `Warning` | 4 |  Messages that signify an anomaly that is not an error |
| `Message` | 8 | Important messages that should be displayed |
| `Info` | 16 | Messages of low importance |
| `Debug` | 32 | Messages intended for developers |

Setting value with a higher level will also display messages with a lower level. 

#### `chainloader-log-unity-messages`
**Default:** `false`

If enabled, BepInEx will display log messages coming from Unity's own logger. This is useful if the game uses the Unity logger a lot.

## `Preloader` section

This section controls how BepInEx preloader functions. This section is intended mainly for developers or for those who want to setup BepInEx to work with a particular game.

For more information, refer to [porting guide](<xref:porting_bepinex>)

#### `entrypoint-assembly`
**Default:** `UnityEngine.dll`

Specifies the name of the assembly found in `Managed` folder into which BepInEx should insert its entrypoint.

#### `entrypoint-type`
**Default:** `Application`

Specifies the type found within `entrypoint-assembly` where BepInEx should insert its entrypoint.

Note that you only need to specify type's basic name; no fully qualified name is needed.

#### `entrypoint-method`
**Default:** `.cctor`

Specifies the method to patch BepInEx entrypoint into.

#### `dump-assemblies`
**Default:** `false`

If enabled, BepInEx will save patched assemblies into `BepInEx/DumpedAssemblies`.  
This can be used by developers to inspect and debug preloader patchers.