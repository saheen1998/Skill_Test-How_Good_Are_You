using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3_SelfDestruct : MonoBehaviour
{
    public float timeLeft = 1;
    void Update() {
          timeLeft -= Time.deltaTime;
          if (timeLeft <= 0.0f) {
              Destroy(this.gameObject);
          }
     }
}
