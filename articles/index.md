Welcome to the BepInEx wiki!

Here you can find guides on installation, upgrading and developing plug-ins for BepInEx.

## About BepInEx

**Bep**is **In**jector **Ex**tensible is a patcher/plug-in framework for Unity games that use C#/Mono as their scripting backend.

Currently, BepInEx provides the following features:

* *Drop-in installation*: Just drop the files in the game's directory and run the game as you usually would
* *Plug-in framework*: Write custom MonoBehaviours to modify the game
* *Harmony included*: Includes [Harmony](https://github.com/pardeike/Harmony) to enable runtime method injection
* *In-memory assembly patching*: Allows to patch game's assemblies with [Mono.Cecil](https://github.com/jbevain/cecil) in memory
* *Open source*: All parts of BepInEx are fully open and are licensed under highly permissive licences (MIT, CC0)

## Getting started

To start, check out the following pages:

* [The installation guide](<xref:installation>) for those who just want to install BepInEx
* [BepisPlugins](https://github.com/bbepis/BepisPlugins) -- a collection of some plug-ins that you might be interested in
* [BepInEx project listing](https://github.com/BepInEx) -- a list of tools and plug-ins officially maintained by the BepInEx developers

If you are a developer, you might be also interested in
 
* [How to develop plug-ins](<xref:writing_plugins>)
* [How to develop in-memory Mono.Cecil patches](<xref:preloader_patches>)