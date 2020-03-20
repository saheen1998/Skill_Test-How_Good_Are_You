using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_Obstacle : MonoBehaviour
{
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
