---
uid: building
---

## Building BepInEx from source
While base BepInEx is periodically built from master automatically (available on [BepisBuilds](http://bepisbuilds.dyn.mk/bepinex_be)), sometimes you might want to build BepInEx manually from source.

### Requirements
To build BepInEx from source code, you will need

* Visual Studio 2015 or newer ([Community version is free](https://visualstudio.microsoft.com/vs/community/))
* core `UnityEngine.dll` (shipped with the game you build for)
* [UnityDoorstop](https://github.com/NeighTools/UnityDoorstop) (only needed when injecting BepInEx into a game)

### Downloading
There are two primary ways to obtain the source code
1. *Via [GIT](https://git-scm.com/)* with the following command:  
    ```bash
    git clone https://github.com/BepInEx/BepInEx.git BepInEx_src
    ```
    This will clone BepInEx into `BepInEx_src` folder.
2. *Via GitHub* by downloading [zipped master](https://github.com/BepInEx/BepInEx/archive/master.zip).

### Building the project
After you have downloaded the source, place `UnityEngine.dll` into `lib` folder.  
Next, open the solution in Visual Studio, select the right build configuration (depending on Unity version) and build type.
Finally, select the projects you want and build them (e.g. by selecting the project and using `Build > Build Project`).  
Alternatively, you can build everything by using `Build` > `Build Solution`.