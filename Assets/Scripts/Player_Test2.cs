using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Test2 : MonoBehaviour
{
    void Start() {
        gameObject.GetComponent<Rigidbody>().maxAngularVelocity = 100;
    }

    void OnTriggerEnter(Collider col) {
        if(col.tag == "Hole") {
            GlobalController.fromTest = 2;
            SceneManager.LoadScene("Scene_PassTest");
        }
    }
}
