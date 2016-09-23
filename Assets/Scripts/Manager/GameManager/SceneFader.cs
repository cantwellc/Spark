using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int _drawDepth = -1000;
    private float _alpha = 1.0f;
    private int _fadeDir = -1;

    void OnGUI()
    {
        _alpha += _fadeDir * fadeSpeed * Time.deltaTime;
        _alpha = Mathf.Clamp01(_alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, _alpha);
        GUI.depth = _drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int dir)
    {
        _fadeDir = dir;
        return (fadeSpeed);
    }

    void OnLevelWasLoad()
    {
        _alpha = 1;
        BeginFade(-1);
    }

}
