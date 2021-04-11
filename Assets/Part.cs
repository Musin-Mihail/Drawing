using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Part : MonoBehaviour
{
    int _idLayer;
    float _z;
    void Start() 
    {
        _z = 0;
        _idLayer = GetComponent<SpriteMask>().frontSortingOrder;
    }
    void OnMouseDown()
    {
        Global._z = _z;
        Global._permission = 1;
        Global._oldVector3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Global.Part = gameObject;
        Global._idLayer = _idLayer;
        if(Global._fill == 1)
        {
            Transform[] allChildren = gameObject.GetComponentsInChildren<Transform>();
            if(allChildren.Length > 1)
            {
                for (int i = 1; i < allChildren.Length; i++)
                {
                    Destroy(allChildren[i].gameObject);
                }
            }
            GetComponent<SpriteRenderer>().color = Global._color;
        }
    }
    void OnMouseUp()
    {
        _z -= 0.001f;
        Global._oldVector3 = Vector3.zero;
        Global._permission = 0;
        Global.Part = null;
    }
}