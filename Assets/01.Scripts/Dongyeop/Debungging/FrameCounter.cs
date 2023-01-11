using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCounter : MonoBehaviour
{
    [Range(1, 100)] [SerializeField] private int _fFont_Size;
    [Range(0, 1)]   [SerializeField] private float _red, _green, _blue;
    [SerializeField] private bool _isShow = false;

    private float _deltaTime = 0.0f;

    private void Start()
    {
        _fFont_Size = _fFont_Size == 0 ? 50 : _fFont_Size;
    }

    private void Update()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;

        if (Input.GetKeyDown(KeyCode.F1))
            _isShow = !_isShow;
    }

    private void OnGUI()
    {
        if (_isShow)
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 0.02f);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / _fFont_Size;
            style.normal.textColor = new Color(_red, _green, _blue, 1.0f);
            float msec = _deltaTime * 1000.0f;
            float fps = 1.0f / _deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);
        }
    }
}
