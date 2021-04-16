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
    public Image _colorPencil;
    public Image _colorMarker;
    public Image _colorFill;
    public Image _texture;
    public SpriteRenderer _prefab;
    public SpriteRenderer _prefab2;
    float _maxPosition;
    public GameObject _tileColors;
    public GameObject _tileColorsTexture;

    void Start() 
    {
        Vector2 _screenResolution = (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        var _height = ((float)Screen.height/2)/_screenResolution.y;
        _maxPosition = 540;
        _maxPosition *= _height/108;
        _lineColorRect = _lineColor.GetComponent<RectTransform>();
        _vector3 = new Vector3(0,0.5f,0);
        _colorBrash.color =  _prefab.color;
        Brush();
    }
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && _lineColorRect.localPosition.y < _maxPosition)
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
        if(Global._eraser == 0)
        {
            _prefab.material = _color.GetComponent<Image>().material;
            _prefab2.material = _color.GetComponent<Image>().material;
            Global._material = _color.GetComponent<Image>().material;
        }
        if(Global._brush == 1)
        {
            _colorBrash.material = _color.GetComponent<Image>().material;
        }
        else if(Global._fill == 1)
        {
            _colorFill.material = _color.GetComponent<Image>().material;
        }
        else if(Global._texture == 1)
        {
            _texture.material = _color.GetComponent<Image>().material;
        }
        else if(Global._pencil == 1)
        {
            _colorPencil.material = _color.GetComponent<Image>().material;
        }
        else if(Global._marker == 1)
        {
            _colorMarker.material = _color.GetComponent<Image>().material;
        }
    }
    public void Fill()
    {
        _prefab.material = _colorFill.material;
        _prefab2.material = _colorFill.material;
        Global._material = _colorFill.material;
        Global._brush = 0;
        Global._pencil = 0;
        Global._fill = 1;
        Global._texture = 0;
        Global._eraser = 0;
        _tileColors.SetActive(true);
        _tileColorsTexture.SetActive(false);
    }
    public void Brush()
    {
        _prefab.material = _colorBrash.material;
        _prefab.transform.localScale = new Vector3(10,10,1);
        _prefab2.material = _colorBrash.material;
        _prefab2.transform.localScale = new Vector3(10,10,1);
        Global._material = _colorBrash.material;
        Global._brush = 1;
        Global._pencil = 0;
        Global._marker = 0;
        Global._fill = 0;
        Global._texture = 0;
        Global._eraser = 0;
        _tileColors.SetActive(true);
        _tileColorsTexture.SetActive(false);
    }
    public void Texture()
    {
        _prefab.material = _texture.material;
        _prefab.transform.localScale = new Vector3(10,10,1);
        _prefab2.material = _texture.material;
        _prefab2.transform.localScale = new Vector3(10,10,1);
        Global._material = _texture.material;
        Global._brush = 0;
        Global._pencil = 0;
        Global._marker = 0;
        Global._fill = 0;
        Global._texture = 1;
        Global._eraser = 0;
        _tileColors.SetActive(false);
        _tileColorsTexture.SetActive(true);
    }
    public void Eraser(GameObject _color)
    {
        _prefab.material = _color.GetComponent<Image>().material;
        _prefab.transform.localScale = new Vector3(10,10,1);
        _prefab2.material = _color.GetComponent<Image>().material;
        _prefab2.transform.localScale = new Vector3(10,10,1);
        Global._brush = 0;
        Global._pencil = 0;
        Global._marker = 0;
        Global._fill = 0;
        Global._texture = 0;
        Global._eraser = 1;
    }
    public void Pencil()
    {
        _prefab.material = _colorPencil.material;
        _prefab.transform.localScale = new Vector3(2,2,2);
        _prefab2.material = _colorPencil.material;
        _prefab2.transform.localScale = new Vector3(2,2,2);
        Global._material = _colorPencil.material;
        Global._brush = 0;
        Global._pencil = 1;
        Global._marker = 0;
        Global._fill = 0;
        Global._texture = 0;
        Global._eraser = 0;
        _tileColors.SetActive(true);
        _tileColorsTexture.SetActive(false);
    }
    public void Marker()
    {
        _prefab.material = _colorMarker.material;
        _prefab.transform.localScale = new Vector3(5,5,5);
        _prefab2.material = _colorMarker.material;
        _prefab2.transform.localScale = new Vector3(5,5,5);
        Global._material = _colorMarker.material;
        Global._brush = 0;
        Global._pencil = 0;
        Global._marker = 1;
        Global._fill = 0;
        Global._texture = 0;
        Global._eraser = 0;
        _tileColors.SetActive(true);
        _tileColorsTexture.SetActive(false);
    }
    public void Back()
    {
        if(Global._countList.Count > 0)
        {
            if(Global._countList[Global._countList.Count-1] != 12345)
            {
                for (int i = 0; i < Global._countList[Global._countList.Count-1]; i++)
                {
                    Destroy(Global._countListBlup[Global._countListBlup.Count-1]);
                    Global._countListBlup.RemoveAt(Global._countListBlup.Count-1);
                }
            }
            else
            {
                Global._countListPart[Global._countListPart.Count-1].GetComponent<SpriteRenderer>().material = Global._partMaterial[Global._partMaterial.Count-1];
                Global._countListPart.RemoveAt(Global._countListPart.Count-1);
                Global._partMaterial.RemoveAt(Global._partMaterial.Count-1);
            }
            Global._countList.RemoveAt(Global._countList.Count-1);
        }
    }
}