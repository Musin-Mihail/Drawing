using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Global : MonoBehaviour
{
    static public GameObject Part;
    static public int _permission;
    static public int _fill;
    static public int _brush;
    static public int _eraser;
    static public int _texture;
    static public int _pencil;
    static public int _marker;
    static public Color _color;
    static public Material _material;
    static public Vector3 _oldVector3;
    static public int _idLayer;
    static public float _z;
    static public List<int> _countList;
    static public int _countListObject;
    static public List<GameObject> _countListBlup;
    static public List<GameObject> _countListPart;
    static public List<Material> _partMaterial;
    void Start() 
    {
        _countListPart = new List<GameObject>();
        _countListBlup = new List<GameObject>();
        _partMaterial = new List<Material>();
        _countList = new List<int>();
        
        _countListObject = 0;
        _permission = 0;
        _brush = 1;
        _pencil = 0;
        _marker = 1;
        _eraser = 0;
        _color = Color.blue;
    }
}
