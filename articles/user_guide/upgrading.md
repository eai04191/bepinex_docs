---
uid: migration
---

## Migration from previous versions of BepInEx

To migrate from a previous version of BepInEx, do the following:

1. Delete `UnityEngine.dll`, `0Harmony.dll` and `BepInEx.dll` from the `*_Data\Managed` folder for your game
  - **IMPORTANT:** Check **all** game folders for their respective `Managed` folders. BepInEx 3 creates the aforementioned files for each valid Unity executable it finds, which means that you may have to repeat this process multiple times.
2. Rename `UnityEngine.dll.bak` to `UnityEngine.dll`
3. **Delete `BepInEx.Patcher.exe` from the game's root folder.**
4. Delete your `config.ini` file in your BepInEx folder
5. [Install BepInEx 4 normally](<xref:installation>)

## Migrating from Sybaris 2.x

1. Delete **all occurences** of the following DLLs in the game's folder:
    * `ExIni.dll`
    * `UnityInjector.dll`
    * `Mono.Cecil.dll`
    * `Sybaris.Loader.dll`
    * `COM3D2.UnityInjector.Patcher` (and other UnityInjector patchers)
    * `opengl32.dll`  
  Use Windows' search tool if you cannot find those.
2. [Install BepInEx 4 normally](<xref:installation>)
3. Download and install [UnityInjectorLoader](https://github.com/BepInEx/BepInEx.UnityInjectorLoader/releases) and [SybarisLoader](https://github.com/BepInEx/BepInEx.SybarisLoader.Patcher/releases) to enable UnityInjector and Sybaris compatibility