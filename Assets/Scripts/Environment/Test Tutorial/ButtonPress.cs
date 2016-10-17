using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {

    public ButtonTrigger buttonTrigger;

    private bool _pressed = false;
    private Color _color;
    private Material _mat;

    void Start()
    {
        _mat = gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
        _color = _mat.color;
        Debug.Log(_color.r + "  " + _color.g);
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Character")
        {
            if (_pressed == false)
            {
                _pressed = true;
                _mat.color = Color.green;
                Debug.Log("button On!");
                buttonTrigger.PressButton(this);
            }
            else
            {
                _pressed = false;
                _mat.color = _color;
                Debug.Log("button Off!");
                buttonTrigger.PressButton(this);
            }
        }
    }

    public bool isPressed()
    {
        return _pressed;
    }
}
