using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public List<GameObject> _parts;
    public Material _while;
    void Start()
    {
        // _parts = new List<GameObject>();
    }

    public void DeleteColor()
    {
        foreach (var item in _parts)
        {
            Transform[] allChildren = item.GetComponentsInChildren<Transform>();
            for (int i = 1; i < allChildren.Length; i++)
            {
                Destroy(allChildren[i].gameObject);
            }
            item.GetComponent<SpriteRenderer>().material = _while;
        }
    }
}
