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

    public void ChangeRoundText()
    {
        Debug.Log(RoundSystem.Instance.roundCount);
        textMeshProUGUI.text = $"Round {RoundSystem.Instance.roundCount}";
    }
}
