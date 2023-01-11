using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextAlpha : MonoBehaviour // 텍스트의 Alpha값을 변경하는 스크립트
{
    [SerializeField] private float _fadeTime;
    private TextMeshProUGUI _text;

    private void Awake() 
    {
        _text = GetComponent<TextMeshProUGUI>();
        UIDisolove();
    }

    private void UIDisolove()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_text.DOColor(new Color(1,1,1,0), _fadeTime).SetLoops(2, LoopType.Yoyo));
        sequence.AppendCallback(() => UIDisolove());
    }

}
