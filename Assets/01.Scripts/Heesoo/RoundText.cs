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

    public void ChangeRoundText() => textMeshProUGUI.text = $"Round {RoundSystem.Instance.roundCount}";
}
