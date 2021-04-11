using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Global : MonoBehaviour
{
    static public GameObject Part;
    static public int _permission;
    static public int _fill;
    static public int _brush;
    static public Color _color;
    static public Vector2 _oldVector2;
    void Start() 
    {
        _permission = 0;
        _brush = 1;
        _color = Color.blue;
    }
}
