using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3 : MonoBehaviour
{
    public GameObject blup;
    float _distance;
    void Update()
    {
        if(Input.GetMouseButton(0) && Global.Part != null && Global._fill == 0 && Global._permission == 1)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = Global._z;
            if(Global._oldVector3 == Vector3.zero)
            {
                GameObject _point = Instantiate(blup,newPosition, Quaternion.identity);
                _point.transform.parent = Global.Part.transform;
                _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                Global._oldVector3 = newPosition;
            }
            else
            {
                _distance = Vector2.Distance(Global._oldVector3, newPosition);
                if(_distance > 0.01f)
                {
                    if(_distance < 0.1f)
                    {
                        GameObject _point = Instantiate(blup,newPosition, Quaternion.identity);
                        _point.transform.parent = Global.Part.transform;
                        _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                    }
                    else
                    {
                        Vector3 _tempPosition = Global._oldVector3;
                        _tempPosition.z = Global._z;
                        while(_tempPosition != newPosition)
                        {
                            _tempPosition = Vector3.MoveTowards(_tempPosition,newPosition, 0.05f);
                            GameObject _point = Instantiate(blup,_tempPosition, Quaternion.identity);
                            _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                            _point.transform.parent = Global.Part.transform;
                        }
                    }
                }
                Global._oldVector3 = newPosition;
            }
        }  
    }
}