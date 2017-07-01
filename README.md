# Aktiva-V2
Aktiva-V2の本体用リポジトリです。

## 必要環境
* Unity 5.6.2
* UnityYAMLMerge
* Visual Studio
* editorconfig plugin

### Unity 5.6.2
[ここ](https://unity3d.com/jp/get-unity/update)からダウンロードしてインストールを行う。

### UnityYAMLMerge
`.git/config` に以下を追記する。Unityのインストールを標準と異なる場所にしている場合は、パスを適切に変更するように。

#### Windows
```
[merge]
  tool = unityyamlmerge
[mergetool "unityyamlmerge"]
  rustExitCode = false
  cmd = "C:\Program Files\Unity\Editor\Data\Tools\UnityYAMLMerge.exe" merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

#### MacOS
```
[merge]
  tool = unityyamlmerge
[mergetool "unityyamlmerge"]
  rustExitCode = false
  cmd = "/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge" merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

また、必要に応じて `./auto` 等を設定すること。([参考](http://qiita.com/Shaula/items/ebe778c232c30aff46fd))

### Visual Studio
エディタはVisual Studioを推奨する。
[ここ](https://www.visualstudio.com/ja/downloads/)からダウンロード及びインストールを行うこと。
また、UnityのPreferenceメニューから、External Toolsを選択し、External Script Editorから使用するエディタを登録すること。

### Editorconfig Plugin
Visual Studio 2017であれば自動的にインストールされている。
その他のエディタを使用する場合は[ここ](http://editorconfig.org/#download)から自分が使用してるエディタにあわせてプラグインを導入すること。

## セットアップ
1. 次のコマンドを実行する。
```sh
git clone git@github.com:cyder-akashi/Aktiva-V2.git
cd Aktiva-V2
```
2. Unityでフォルダを開く。

## 著者
* [森 篤史](@Mori-Atsushi)
