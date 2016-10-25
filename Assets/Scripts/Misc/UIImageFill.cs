using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIImageFill : MonoBehaviour {
    private Image _image;
    private float _startTime;
    private float _timeToFill;
    private bool _doFill;
     
    void Awake()
    {
        _image = GetComponent<Image>();
    }

	public void StartFill(float timeToFill)
    {
        _startTime = Time.time;
        _timeToFill = timeToFill;
        _doFill = true;
    }
	// Update is called once per frame
	void Update () {
        if (!_doFill) return;
        var ratio = (Time.time - _startTime) / _timeToFill;
        _image.fillAmount = ratio;
	}
}
