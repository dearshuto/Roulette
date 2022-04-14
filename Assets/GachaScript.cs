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
        "Theme1",
        "Theme2",
        "Theme3",
        "Theme4",
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
