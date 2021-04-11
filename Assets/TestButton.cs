using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    public GameObject Test;
    void Start()
    {
        Debug.Log(GetComponent<Graphic>());
    }

    void Update()
    {
        
    }

}
