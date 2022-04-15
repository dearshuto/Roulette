using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaScript : MonoBehaviour
{
    private GameObject _themeText;
    private bool _isLoop;
    private int _index;
    private int _rouletteCount;
    private static readonly IReadOnlyList<string> s_ThemeText = new[]
    {
        "自分のなおしたい癖",
        "好きな映画館の席の位置",
"お墓まで持って行きたい秘密",
"自分のプチ自慢",
"今までにあった親の恥ずかしい行動",
"今まで買った1番高級なモノ",
"実は意味わからないで使ってる言葉",
"憧れの人",
"実は集めてるモノ",
"生まれ変わるなら何の動物になる？",
"占い信じる？",
"ローランドが言いそうな台詞",
"変えれるならなんて名前にする？",
"生まれ変わるなら性別は変わりたい？",
"自分って歳とったなと思う時",
"このメンバーの第一印象",
"あの時トガってたなーと思う自分の行動",
"人に言われて嬉しい褒め言葉",
"心に響いた言葉",
"忘れられない怒られた思い出",
"幼少期の嫌いだった服",
"変な実家ルール",
"早口で止まらずに何秒間喋れるかバトル",
"死ぬまで言い続けるなら、なんて語尾をつける？",
"大人に言われて腑に落ちてない言葉",
"「は」で始まる気持ち悪いモノを3秒で。3,2,1",
"「神妙な面持ち」ってどんな顔？",
"「メレンゲの気持ち」ってどんな気持ち？",
"子供の頃からずっと苦手なモノ",
"思い出せる最も古い記憶",
"好きだったのに売られなくなった味",
"これ要らないよなと思う社会人ルール",
"街で見かける許せない人の行為",
"みんな知ってるのに自分だけ知らないモノ",
"どっちの読みが正しいか分からなくなる言葉",
"友人の変な行動",
"どうでもいいなと思う論争ってありますか？",
"革命が起こったと感じたお菓子",
"「れ」で始まるかたいモノを3秒で。3,2,1",
"好きなCM",
"自分で言った名言",
"好きな曜日",
"聞かれたら面倒だなと思う質問",
"人にプレゼントしたいモノ",
"死ぬまでにこれだけはしたいと思うコト",
"友達は何人いる？",
"日々のルーティンワーク",
 };

    public void Run()
    {
        _isLoop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _themeText = GameObject.Find("ThemeText");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isLoop) { return; }
        if (!_themeText.TryGetComponent<Text>(out var text)) { return; }

        ++_rouletteCount;

        var nextText = s_ThemeText[_index++];
        text.text = nextText;

        if (s_ThemeText.Count <= _index)
        {
            _index = 0;
        }

        if (300 < _rouletteCount)
        {
            _rouletteCount = 0;
            _isLoop = false;
        }
    }
}
