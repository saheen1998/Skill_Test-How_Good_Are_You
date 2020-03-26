using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3_Obstacle : MonoBehaviour
{
    public GameObject particleSystem;
    void OnDestroy() {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
    }
}
