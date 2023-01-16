using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundText : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // 여기 수정 필요
        // 처음 타이틀 화면에서 안 나오게 해주는거
        // 나중에 UI 수정 가능성 있으니 추후 변경

        if (GameManager.Instance.gameState == GameState.Title)
        {
            textMeshProUGUI.enabled = false;
        }
        else
        {
            textMeshProUGUI.enabled = true;
            ChangeRoundText();
        }
    }

    public void ChangeRoundText()
    {
        if (GameManager.Instance.gameState == GameState.GameOver) return;

        textMeshProUGUI.text = $"Round {RoundSystem.Instance.roundCount}";
    }
}
