---
uid: dev_tools
title: List of useful development plugins
---

# List of useful development plugins

This page contains a list of useful plugins and tools you can use 
to make development of plugins with BepInEx easier.

## BepInEx.Debug tools

**Link**: [GitHub](https://github.com/BepInEx/BepInEx.Debug)

**Description**: This is a pack of useful plugins to ease development. 
Below is a description of each debug plugin. You can find more specific 
usage guide in [repository README](https://github.com/BepInEx/BepInEx.Debug/blob/master/README.md).

### ScriptEngine

Allows to reload plugins without restarting the game. Simply put your 
plugins into `BepInEx/scripts` folder and press `F6` in-game whenever you 
want to reload a plugin.

Note that to support this your plugin needs to clean up its resources in 
your plugin by creating [`OnDestroy`](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDestroy.html)
method and unpatching any Harmony patches along with cleaning up other resources.

### Startup profiler

Logs load times for each of the plugins.

### Mono Profiler

A profiler for Unity games. Logs all called methods, call counts and call times.  
Outputs all data as `.csv` files.

### Demystify Exceptions

Formats stack traces into a more human-friendly formats and attempts to properly 
resolve `IEnumerable`s, lambdas and `async` state machines.

## Runtime Unity Editor

![RuntimeUnityEditor GUI](https://user-images.githubusercontent.com/39247311/64476158-ce1a4c00-d18b-11e9-97d6-084452cdbf0a.PNG)

**Link**: [GitHub](https://github.com/ManlyMarco/RuntimeUnityEditor)

**Description**: Brings an extensive Unity Editor -like hierarchy explorer 
directly into a game. Allows you to inspect any game object and component. 
Additionally comes with a C# REPL and support for rotation/translation gizmos 
via Vectrocity.

Refer to the [README](https://github.com/ManlyMarco/RuntimeUnityEditor/blob/master/README.md) for installation 
and usage info.

## Configuration Manager

![ConfigurationManager GUI](https://github.com/BepInEx/BepInEx.ConfigurationManager/raw/master/Screenshot.PNG)

**Link**: [GitHub](https://github.com/BepInEx/BepInEx.ConfigurationManager)

**Description**: Allows to edit all configuration files via an in-game GUI. 
Default hotkey is `F1`. Refer to [README](https://github.com/BepInEx/BepInEx.ConfigurationManager/blob/master/README.md) for more info on how to use and 
how to integrate into your plugin.

## C# Script Loader

**Link**: [GitHub](https://github.com/denikson/BepInEx.ScriptLoader)

**Description**: Allows to write C# scripts without compiling them. Useful for small (under 200 LOC) 
Harmony patches and tools. Supports live code reloading and comes with a custom 
version of MCS compiler that allows you to access private methods/fields 
without any reflection.

Refer to the [README](https://github.com/denikson/BepInEx.ScriptLoader/blob/master/README.md) 
for info on how to write scripts and current limitations.

## ThunderKit (make plugins in Unity Editor)

**Link**: [GitHub](https://github.com/PassivePicasso/ThunderKit)

**Description**: Allows you to create plugins directly in Unity Editor. With it 
you can easily create new assets and link them to existing or new components. 
Great for integrating new items, maps and whatnot into any Unity game.

The tool is being actively developed and documentation is being created. 
Refer to [README](https://github.com/PassivePicasso/ThunderKit/blob/master/README.md) 
for more information about the tool and how to install it.