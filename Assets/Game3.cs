using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3 : MonoBehaviour
{
    public GameObject point;
    // public GameObject mask;
    // public Vector2 oldPosition;
    // public Vector2 newPosition;
    // float _width; 
    // float _height; 
    float _distance;

    // private void Start() 
    // {
        // point.GetComponent<Image>().color = Color.blue;
        // Vector2 width = (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        // _width = ((float)Screen.width/2)/width.x;
        // _height = ((float)Screen.height/2)/width.y;
        // width.x *= _width;
        // width.y *= _height;
        // var _point = Instantiate(point,width, Quaternion.identity);
        // _point.transform.SetParent(mask.transform, false);
    // }
    void Update()
    {
        if(Input.GetMouseButton(0) && Global.Part != null && Global._fill == 0 && Global._permission == 1)
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _distance = Vector2.Distance(Global._oldVector2, newPosition);
            if(_distance > 0.05f)
            {
                var _tempPosition = Global._oldVector2;
                Global._oldVector2 = newPosition;
                // newPosition.x *= _width;
                // newPosition.x += 47*(_width/108);
                // newPosition.y *= _height;
                // _tempPosition.x *= _width;
                // _tempPosition.x += 47*(_width/108);
                // _tempPosition.y *= _height;
                if(_distance < 0.1f)
                {
                    var _point = Instantiate(point,newPosition, Quaternion.identity);
                    _point.transform.SetParent(Global.Part.transform, false);
                }
                else
                {
                    while(_tempPosition != newPosition)
                    {
                        _tempPosition = Vector2.MoveTowards(_tempPosition,newPosition, 20);
                        var _point = Instantiate(point,_tempPosition, Quaternion.identity);
                        _point.transform.SetParent(Global.Part.transform, false);
                    }
                }
            }
        }  
    }
}