using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStoryPlayer : MonoBehaviour {

    public Image Image;
    public Sprite[] images;
    public GameObject mainMenu, subMenu; 

    private int _Hight;
    private int _width;
    private int _currImage;

    private bool _flipping;

	// Use this for initialization
	void Start () {
        _Hight = Screen.height;
        _width = _Hight * 786 / 1024;
        Image.rectTransform.sizeDelta = new Vector2(_width * 2, 0);
	}

    void OnEnable()
    {
        Image.sprite = images[0];
        _currImage = 0;
        _flipping = false;
    }
	
    void Update()
    {
        _Hight = Screen.height;
        _width = _Hight * 786 / 1024;
        Image.rectTransform.sizeDelta = new Vector2(_width * 2, 0);

        if (Input.GetMouseButtonDown(0))
        {
            if (_currImage <= 8 && !_flipping)
            {
                _flipping = true;
                Image.sprite = images[_currImage + 1];
                _currImage++;
            }
            else quitGameStory();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(_currImage > 0 && !_flipping)
            {
                _flipping = true;
                Image.sprite = images[_currImage - 1];
                _currImage--;
            }

        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            _flipping = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitGameStory();
        }
    }

    void quitGameStory()
    {
        mainMenu.SetActive(true);
        subMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
