using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public GameObject _lineColor;
    RectTransform _lineColorRect;
    Vector3 _vector3;
    public Image _colorBrash;
    public Image _colorFill;
    public SpriteRenderer _prefab;

    void Start() 
    {
        _lineColorRect = _lineColor.GetComponent<RectTransform>();
        _vector3 = new Vector3(0,0.5f,0);
        _colorBrash.color =  _prefab.color;
    }
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && _lineColorRect.localPosition.y < 540)
        {
            _lineColorRect.position += _vector3;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && _lineColorRect.localPosition.y > 0)
        {
            _lineColorRect.position -= _vector3;
        }
    }
    public void ColorTest(GameObject _color)
    {
        _prefab.color = _color.GetComponent<Image>().color;
        Global._color = _color.GetComponent<Image>().color;
        if(Global._brush == 1)
        {
            _colorBrash.color = _color.GetComponent<Image>().color;
        }
        else if(Global._fill == 1)
        {
            _colorFill.color = _color.GetComponent<Image>().color;
        }
    }
    public void Fill()
    {
        _prefab.color = _colorFill.color;
        Global._color = _colorFill.color;
        Global._fill = 1;
        Global._brush = 0;
    }
    public void Brush()
    {
        _prefab.color = _colorBrash.color;
        Global._color = _colorBrash.color;
        Global._brush = 1;
        Global._fill = 0;
    }
}