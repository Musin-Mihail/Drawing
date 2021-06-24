using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public int _int = 3001;
    void Update() 
    {
        GetComponent<MeshRenderer>().material.renderQueue = _int;
    }
}
