using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
public class Part : MonoBehaviour
{
    int _idLayer;
    float _z;
    public GameObject blup;
    public GameObject _prefab;
    public Material _material;
    Vector3 _zero = new Vector3(0,0,-1);
    public Mesh mesh;
    public GameObject test;
    void Start() 
    {
        test.GetComponent<MeshFilter>().sharedMesh = GetComponent<PolygonCollider2D>().CreateMesh(false,false);
        // mesh = GetComponent<PolygonCollider2D>().CreateMesh(true,true);
        // AssetDatabase.CreateAsset(test.GetComponent<MeshFilter>().sharedMesh, "Assets/SavedMesh2.asset");
        _z = 0;
        _idLayer = GetComponent<SpriteMask>().frontSortingOrder;
    }
    void OnMouseDown()
    {
        // Vector3 newPosition2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // newPosition2.z = -1;  
        GameObject prefab =  Instantiate(_prefab,_zero,Quaternion.identity);
        prefab.GetComponent<MeshRenderer>().material.color = new Color32((byte)Random.Range(0,255),(byte)Random.Range(0,255),(byte)Random.Range(0,255), 255);
        Game3._staticPrefab = prefab;
        Global._countListObject = 0;
        _z -= 0.001f;
        Global._z = _z;
        Global._permission = 1;
        // Global._oldVector3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Global.Part = gameObject;
        // Global._idLayer = _idLayer;
        Global._idLayer = GetComponent<SpriteMask>().backSortingOrder;
        if(Global._fill == 1)
        {
            // Transform[] allChildren = gameObject.GetComponentsInChildren<Transform>();
            // if(allChildren.Length > 1)
            // {
            //     for (int i = 1; i < allChildren.Length; i++)
            //     {
            //         Destroy(allChildren[i].gameObject);
            //     }
            // }
            // Global._partMaterial.Add(GetComponent<SpriteRenderer>().material);
            // GetComponent<SpriteRenderer>().material = Global._material;


            Vector3 newPosition = new Vector3(0,0,0);
            newPosition.z = Global.Part.transform.position.z + Global._z;
            GameObject _point = Instantiate(blup,newPosition, Quaternion.identity);
            _point.transform.parent = Global.Part.transform;
            _point.GetComponent<SpriteRenderer>().sortingOrder = Global._idLayer;
            _point.transform.position = new Vector3(_point.transform.position.x, _point.transform.position.y, Global.Part.transform.position.z + Global._z );
            _point.transform.localScale = new Vector3 (300,300,1);
            Global._countListObject++;
            Global._countListBlup.Add(_point);
            Global._oldVector3 = newPosition;
        }
    }
    void OnMouseUp()
    {
        Game3._clear = 1;
        // if(Global._fill == 1)
        // {
        //     Global._countListPart.Add(gameObject);
        //     Global._countList.Add(12345);
        // }
        // else
        // {
            Global._countList.Add(Global._countListObject);
        // }
        // Global._oldVector3 = Vector3.zero;
        Global._permission = 0;
        Global.Part = null;
    }
}