# Aktiva-V2
Aktiva-V2の本体用リポジトリです。

## 必要環境
* Unity 5.6.1
* UnityYAMLMerge
* Visual Studio
* editorconfig plugin
* Artistic Style 3.0

### Unity 5.6.1
[ここ](https://unity3d.com/jp/get-unity/download/archive)からUnity 5.6.1を選択しインストールを行う。

### UnityYAMLMerge
`.git/config` に以下を追記する。Unityのインストールを標準と異なる場所にしている場合は、パスを適切に変更するように。

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
[ここ](https://www.visualstudio.com/ja/downloads/)からダウンロード及びインストールを行うこと。
また、UnityのPreferenceメニューから、External Toolsを選択し、External Script Editorから使用するエディタを登録すること。

### Editorconfig Plugin
Visual Studio 2017であれば自動的にインストールされている。
その他のエディタを使用する場合は[ここ](http://editorconfig.org/#download)から自分が使用してるエディタにあわせてプラグインを導入すること。

### Artistic Style 3.0
[ここ](https://sourceforge.net/projects/astyle/files/astyle/astyle%203.0/)からダウンロード及びインストールを行う。

もしくは、brewでインストールを行う。
```sh
brew install astyle
```

gitのpre-commitに以下を設定する。
`.git/hooks/pre-commit` という名前で以下の内容を記述する。
```sh
OPTIONS="--options=./.astyle"

RETURN=0
ASTYLE=$(which astyle)
if [ $? -ne 0 ]; then
	echo "[!] astyle not installed. Unable to check source file format policy." >&2
	exit 1
fi

FILES=`git diff --cached --name-only --diff-filter=ACMR | grep -E "\.(cs)$"`
for FILE in $FILES; do
	$ASTYLE $OPTIONS $FILE
	git add $FILE
done

exit $RETURN
```

実行権限を追加する。
```sh
chmod 755 .git/hooks/pre-commit
```

## セットアップ
1. 次のコマンドを実行する。
```sh
git clone git@github.com:cyder-akashi/Aktiva-V2.git
cd Aktiva-V2
```
2. Unityでフォルダを開く。

## 著者
* [森 篤史](@Mori-Atsushi)
