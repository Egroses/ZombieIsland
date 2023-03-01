using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(new Vector3(1475f,240,500f),Vector3.right,10f*Time.deltaTime);
    }
}
