using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    float _width; 
    float _height; 
    void Start()
    {
        Vector2 width = (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        _width = ((float)Screen.width/2)/width.x;
        _height = ((float)Screen.height/2)/width.y;
        Vector2 newVector2 = GetComponent<RectTransform>().sizeDelta;
        newVector2.x *= _width/108;
        newVector2.y *= _height/108;
        GetComponent<RectTransform>().sizeDelta = newVector2;
    }
}
