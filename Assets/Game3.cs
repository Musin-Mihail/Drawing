using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3 : MonoBehaviour
{
    public GameObject blup;
    public GameObject blupLine;
    float _distance;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Global.Part != null && Global._fill == 0 && Global._permission == 1)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = Global.Part.transform.position.z + Global._z;
            GameObject _point = Instantiate(blup,newPosition, Quaternion.identity);
            _point.transform.parent = Global.Part.transform;
            _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
            _point.transform.position = new Vector3(_point.transform.position.x, _point.transform.position.y, Global.Part.transform.position.z + Global._z );
            Global._countListObject++;
            Global._countListBlup.Add(_point);
            Global._oldVector3 = newPosition;
        }
        // if(Input.touchCount > 0 && Global.Part != null && Global._fill == 0 && Global._permission == 1)
        if(Input.GetMouseButton(0) && Global.Part != null && Global._fill == 0 && Global._permission == 1)
        {
            // Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // newPosition.z = Global._z;
            // if(Global._oldVector3 == Vector3.zero)
            // {
            //     GameObject _point = Instantiate(blup,newPosition, Quaternion.identity);
            //     _point.transform.parent = Global.Part.transform;
            //     _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
            //     Global._oldVector3 = newPosition;
            // }
            // else
            // {
                _distance = Vector2.Distance(Global._oldVector3, newPosition);
                if(_distance > 0.1f)
                {        
                    newPosition.z = Global.Part.transform.position.z + Global._z;
                    GameObject _point1 = Instantiate(blupLine,Global._oldVector3, Quaternion.identity);
                    _point1.transform.rotation = Quaternion.LookRotation(Vector3.forward, newPosition - _point1.transform.position);
                    _point1.transform.Rotate(0, 0, 90);
                    _point1.transform.localScale = new Vector3(_distance*10, _point1.transform.localScale.y, _point1.transform.localScale.z);
                    GameObject _point2 = Instantiate(blup,newPosition, Quaternion.identity);
                    Global._oldVector3 = newPosition;
                    Global._countListBlup.Add(_point1);
                    Global._countListBlup.Add(_point2);
                    Global._countListObject +=2;
                    _point1.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                    _point2.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                    _point1.transform.parent = Global.Part.transform;
                    _point2.transform.parent = Global.Part.transform;

                    // if(_distance < 10.0f)
                    // {
                        // newPosition.z = Global.Part.transform.position.z + Global._z;
                        // GameObject _point = Instantiate(blup,newPosition, Quaternion.identity);
                        // Global._countListObject++;
                        // Global._countListBlup.Add(_point);
                        // _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                        // _point.transform.parent = Global.Part.transform;
                    // }
                    // else
                    // if(_distance > 1.0f)
                    // {
                        // Debug.Log(_distance);
                        // Vector3 _tempPosition = Global._oldVector3;
                        // _tempPosition.z = Global._z;
                        // while(_tempPosition != newPosition)
                        // {
                        //     _tempPosition = Vector3.MoveTowards(_tempPosition,newPosition, 4.0f);
                        //     GameObject _point2 = Instantiate(blup,_tempPosition, Quaternion.identity);
                        //     Global._countListObject++;
                        //     Global._countListBlup.Add(_point2);
                        //     // _point2.GetComponent<SpriteRenderer>().color = Color.blue;
                        //     _point2.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                        //     _point2.transform.parent = Global.Part.transform;
                        //     _point2.transform.position = new Vector3(_point2.transform.position.x, _point2.transform.position.y, Global.Part.transform.position.z + Global._z );
                        // }
                        // Global._oldVector3 = newPosition;
                    // }
                    // Global._oldVector3 = newPosition;
                }
                
            // }
        }  
    }
}