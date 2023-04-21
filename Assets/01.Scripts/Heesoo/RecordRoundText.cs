using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordRoundText : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    private int round = 1;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        round = PlayerPrefs.GetInt("saveRound");
        ChangeRecordText();
    }

    public void SaveRecord()
    {
        if (RoundSystem.Instance.roundCount > round)
        {
            round = RoundSystem.Instance.roundCount;
            PlayerPrefs.SetInt("saveRound", round);
        }

        ChangeRecordText();
    }

    private void ChangeRecordText()
    {
        textMeshProUGUI.text = $"Record {round}";
    }
}
