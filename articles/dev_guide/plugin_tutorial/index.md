---
uid: plugin_dev_index
---

## Plugin development

Assuming you already know your way around Visual Studio and C#, this is the basics of making a plugin.

1. You need to create a .NET framework class library. You need to select .NET 3.5, or change it to that after you've created the project.
2. Then you need to reference the main BepInEx library. This is where your helper classes are (`Logger` and `Config`), and most importantly your base class.
3. In your new plugin class, you want to inherit `BepInEx.BaseUnityPlugin` (and specify the `[BepInPlugin]` attribute), so the injector can detect your plugin. This behaves exactly the same as a MonoBehaviour except with some extra fields for plugin management, so if you want to subscribe to an event, you have to declare the method manually. [Unity reference material](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)
4. Then, your plugin gets loaded on game launch if it's placed in the `BepInEx` folder in your main game folder.

---
### BaseUnityPlugin
NOTE: From v3 onwards, abstract properties in `BaseUnityPlugin` got shifted to an attribute labeled `[BepInPlugin()]` to help issues with metadata.

BaseUnityPlugin doesn't have anything you can override by itself, but you need to create a `[BepInPlugin()]` attribute on the class you're creating, to give additional metadata to the plugin loader. Here are what the parameters mean:
- `GUID` - This is the unique identifier for your plugin, which is expected to never change. This is used by the framework mainly for dependency stuff.
- `Name` - This is the user-friendly name of the plugin. Mainly used for visuals, so the user knows what is being loaded.
- `Version` - This is the version of the plugin. Other than for displaying to the user, you can also use this to check if a dependency is a certain version (or a range of).


### Additional attributes
- `[BepInDependency(string GUID)]` - Add this attribute to your class to specify that it relies on another plugin, so the plugin loader can re-arrange load order to accommodate for you, and to gracefully handle if the plugin you require doesn't exist. 
  - Pass in the `GUID` of the plugin that your plugin has a dependency, as the parameter.
  - You can specify this attribute multiple times, to indicate multiple dependencies.

---
### Helper classes
- `BepInLogger` - This class handles all logging, either debug or not. By default, the Developer Console is the only plugin that is a dedicated output for this, showing all visible logs to the user as a message popup, and all non-visible logs hidden away in the console (F12).
  - `Logger.Log(LogLevel level, object message)` is what you use to log something. The level indicates the severity of the logged event, while the message is what textual content will be logged. Internally it gets converted to string via `message.ToString()` so you can use that to your advantage when logging things like exceptions.
  - `Logger.EntryLogged` is the event for a message being logged. You can add your own subscriber here, if you need to monitor the log.

- `Config` - This class handles persistent data, which can also be edited by the user manually. Currently subject to change, so please keep this in mind. The current standard is a global configuration file, where the keys are prefaced with an ID, such as `colorcorrector-saturationenabled`.
  - `Config.SaveOnConfigSet` is a property that determines if the config file should be saved on an entry being set, for convenience. The default is true. If you're about to write a large amount of values to the config, it may be the best option to disable this, write all your values, re-enable this and save manually.
  - `Config.ReloadConfig()` reloads all config values from disk. You will lose all unwritten changes, so be careful with this.
  - `Config.SaveConfig()` writes the config to disk.
  - `Config.GetEntry(string key, string defaultValue) returns the value of the key if the entry in the config is found, otherwise returns the default value.
  - `Config.SetEntry(string key, string value) sets the key to the specified value in the config.

---
### Tips

- It is generally better to use `void Awake()` or `void Start()` as your entry point, as using the constructor could potentially cause adverse effects (such as if an exception occurs), since the constructor is in a `grey zone` as it's not handled by Unity. However, it's fine for things that need to be done as early as possible and have very little chance of causing exceptions (such as installing hooks).
- Make sure to disable `Copy Local` in your references for certain references to avoid clutter.
  - You would want to disable it for references to assemblies that are already included in the base game (Assembly-CSharp.dll, UnityEngine.dll etc.) and for references that are already are part of the plugin (BepInEx.dll, 0Harmony.dll [unless you need a certain version, that's another issue of it's own]).