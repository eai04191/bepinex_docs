---
uid: installation_jp
---

## BepInExについて

BepInExはMono上で動作するUnityで制作されたゲームのためのフレームワークです。  
BepInExはゲームのアセンブリ（コンパイル済みの実行コード）にパッチを行ったり、カスタムMonoBehavioursを通してプラグインをロードする手段を提供します。

## 動作環境

BepInExはMonoランタイムを使用するUnityを使ったゲームを必要とします（つまり、`mono.dll`を含んでいるゲームです）。  
BepInExはUnityのバージョン5.4～2017.2で正常に動作するようにテストされています。

## 旧バージョンからのアップデート

アップデート方法については、[移行ガイド](<xref:migration_jp>)を参照して下さい。

## インストール

1. 最新のBepInExを[リリースページ](https://github.com/BepInEx/BepInEx/releases)からダウンロードします。
2. ダウンロードした圧縮ファイルを解凍し、中身をゲームのルートフォルダに入れて下さい。
3. もしゲームが32bit版であった場合には、`winhttp.dll`を`x86`フォルダの中のファイルで置き換えて下さい。
4. ゲームを一度起動し、BepInExに設定ファイルやフォルダを生成させて下さい（もし`BepInEx\config.ini`が生成されない場合は、ここまでの手順を見直すこと！）。
5. プラグインやパッチャーは、`BepInEx`フォルダの中に導入します。
6. BepInExの設定のため、`BepInEx\config.ini`を編集します。