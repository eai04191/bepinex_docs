---
uid: migration_jp
---

## 以前のバージョンのBepInExからの移行

以前のバージョンのBepInExからの移行のためには、以下を行って下さい:

1. ファイルの削除 `UnityEngine.dll`、`0Harmony.dll`、`BepInEx.dll`（`\*_Data\Managed`フォルダから）
2. ファイル名の変更 `UnityEngine.dll.bak`を`UnityEngine.dll`にリネーム
3. **ファイルの削除 `BepInEx.Patcher.exe`（ゲームのルートフォルダから）**
4. [BepInEx 4を通常の方法でインストール](<xref:installation_jp>)

**注意:** ゲームフォルダに含まれる **全ての** `\*_Data\Managed`フォルダをチェックすること. BepInEx 3は有効なUnityの実行ファイル毎に前述のファイルを生成しており、そのため何度か同様の作業を行わなければならないかもしれません。

## Sybaris 2.xからの移行

1. 以下のDLLファイルで **存在するもの全て** をゲームフォルダ内から削除します（Sybarisフォルダもチェックすること）:
    * `ExIni.dll`
    * `UnityInjector.dll`
    * `Mono.Cecil.dll`
    * `Sybaris.Loader.dll`
    * `COM3D2.UnityInjector.Patcher.dll` (またはSybaris.UnityInjector.Patcher等の他のUnityInjectorパッチャーを使っている場合)
    * `opengl32.dll`（ゲームのルートフォルダから）
2. [BepInEx 4を通常の方法でインストール](<xref:installation_jp>)
3. 互換のためのプラグイン2つをダウンロードしてインストール [UnityInjectorLoader](https://github.com/BepInEx/BepInEx.UnityInjectorLoader/releases)、[SybarisLoader](https://github.com/BepInEx/BepInEx.SybarisLoader.Patcher/releases)（UnityInjectorが有効になり、Sybaris用のプラグインが使用可能になります）

