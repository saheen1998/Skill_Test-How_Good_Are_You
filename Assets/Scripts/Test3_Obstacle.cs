using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3_Obstacle : MonoBehaviour
{
    public GameObject particleSystem;

    void Update() {
        transform.Rotate(0, 1, 0);
    }

    void OnDestroy() {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
    }
}
