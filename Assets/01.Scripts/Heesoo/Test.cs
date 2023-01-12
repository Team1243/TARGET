using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.Instance.GameClear();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.GameOver();
        }
    }
}
