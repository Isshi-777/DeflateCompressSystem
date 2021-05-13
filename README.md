# DeflateCompressSystem

デフレートアルゴリズムによる圧縮・展開処理を行うクラス

## 使用例
```cs
void Start()
{
    string str = "あいうえお";

    //圧縮
    var comp = DeflateCompressSystem.CompressFromString(str);

    // 展開
    var decomp = DeflateCompressSystem.DecompressToString(comp);
}
```
