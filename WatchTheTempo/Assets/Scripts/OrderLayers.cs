using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OrderLayers : MonoBehaviour
{
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = -(int)(transform.position.y * 100);
    }
}
