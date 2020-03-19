using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_Plane : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Vector3 pos = transform.position;
        pos.z = transform.position.z + 99;
        transform.position = pos;
    }
}
