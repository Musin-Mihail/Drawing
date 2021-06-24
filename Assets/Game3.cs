using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Game3 : MonoBehaviour
{
    public GameObject qwe;
    
    public GameObject blup;
    public GameObject blupLine;
    float _distance;
    int count = 0;
    Vector3 _oldVector3;
    public List<GameObject> _mainGameObjects;
    public List<GameObject> _firstGameObjects;
    public List<Vector3> Vertox;
    public List<int> Tringle;
    public List<Vector3> Normals;
    public static GameObject _staticPrefab;
    public static int _clear;
    float _distant = 0;
    public SpriteRenderer _spriteRenderer;
    Mesh _mesh;
    void Start() 
    {
        _mesh = new Mesh();
        _mesh.name = "Test Mesh2";
        _clear = 0;
        // foreach (var item in _mainGameObjects)
        // {
        //     Vertox.Add(item.transform.position);
        //     Normals.Add(-Vector3.down);
        // }
    }
    void Update()
    {
        if(_clear == 1)
        {
            _clear = 0;
            count = 0;
            Vertox.Clear();
            Normals.Clear();
            Tringle.Clear();
            // AssetDatabase.CreateAsset(_mesh, "Assets/SavedMesh.asset");
            _mesh = new Mesh();
            _mesh.name = "Test Mesh2";
        }
        // if(Input.GetMouseButtonDown(0) && Global.Part != null && Global._fill == 0 && Global._permission == 1)
        // {
        //     Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     newPosition.z = Global.Part.transform.position.z + Global._z;
        //     GameObject _point = Instantiate(blup,newPosition, Quaternion.identity);
        //     _point.transform.parent = Global.Part.transform;
        //     _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
        //     _point.transform.position = new Vector3(_point.transform.position.x, _point.transform.position.y, Global.Part.transform.position.z + Global._z );
        //     Global._countListObject++;
        //     Global._countListBlup.Add(_point);
        //     Global._oldVector3 = newPosition;
        // }
        if(Input.GetMouseButton(0) && Global.Part != null && Global._fill == 0 && Global._permission == 1)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _distance = Vector2.Distance(_oldVector3, newPosition);
            if(_distance > 0.1f)
            {    
                _distant -= 0.00001f;
                newPosition.z = _distant;
                qwe.transform.rotation = Quaternion.LookRotation(Vector3.forward, newPosition - qwe.transform.position);
                qwe.transform.position = newPosition;
                _oldVector3 = newPosition;
                if(count == 1)
                {
                    foreach (var item in _firstGameObjects)
                    {
                        Vertox.Add(item.transform.position);
                        Normals.Add(-Vector3.down);
                    }
                }
                else
                {
                    foreach (var item in _mainGameObjects)
                    {
                        Vertox.Add(item.transform.position);
                        Normals.Add(-Vector3.down);
                    }
                }
                for (int t = 0; t < _mainGameObjects.Count-1; t++)
                {
                    for (int i = 1; i < count; i++)
                    {
                        int Index1 = i * _mainGameObjects.Count + t;
                        int Index2 = Index1 + _mainGameObjects.Count;
                        int Index3 = Index2 + 1;
                        int Index4 = Index1;
                        int Index5 = Index3;
                        int Index6 = Index1 + 1;
                        Tringle.Add(Index1);
                        Tringle.Add(Index2);
                        Tringle.Add(Index3);
                        Tringle.Add(Index4);
                        Tringle.Add(Index5);
                        Tringle.Add(Index6);
                    } 
                }
                _mesh.SetVertices(Vertox);
                _mesh.SetTriangles(Tringle, 0);
                _mesh.SetNormals(Normals);
                _mesh.RecalculateNormals();
                _staticPrefab.GetComponent<MeshFilter>().sharedMesh = _mesh; 
                count++;
                // newPosition.z = Global.Part.transform.position.z + Global._z;
                // GameObject _point1 = Instantiate(blupLine,Global._oldVector3, Quaternion.identity);
                // _point1.transform.rotation = Quaternion.LookRotation(Vector3.forward, newPosition - _point1.transform.position);
                // _point1.transform.Rotate(0, 0, 90);
                // _point1.transform.localScale = new Vector3(_distance*10, _point1.transform.localScale.y, _point1.transform.localScale.z);
                // GameObject _point2 = Instantiate(blup,newPosition, Quaternion.identity);
                // Global._oldVector3 = newPosition;
                // Global._countListBlup.Add(_point1);
                // Global._countListBlup.Add(_point2);
                // Global._countListObject +=2;
                // _point1.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                // _point2.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
                // _point1.transform.parent = Global.Part.transform;
                // _point2.transform.parent = Global.Part.transform;
            }
        }  
    }
}