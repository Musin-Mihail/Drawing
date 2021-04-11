using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Part : MonoBehaviour
{
    public GameObject _part;
    Image _color;
    void Start() 
    {
        _color = _part.GetComponent<Image>();
    }
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Global._permission = 1;
        Global._oldVector2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Global.Part = _part;
        if(Global._fill == 1)
        {
            Transform[] allChildren = _part.GetComponentsInChildren<Transform>();
            if(allChildren.Length >1)
            {
                for (int i = 1; i < allChildren.Length; i++)
                {
                    Destroy(allChildren[i].gameObject);
                }
            }
            _part.GetComponent<Image>().color = Global._color;
        }
    }
    void OnMouseUp()
    {
        Debug.Log("OnMouseUP");
        Global._permission = 0;
        Global.Part = null;
    }
}
