using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Test3 : MonoBehaviour
{
    void Start() {
        gameObject.GetComponent<Rigidbody>().maxAngularVelocity = 100;
    }

    void OnTriggerEnter(Collider col) {
        if(col.tag == "Obstacle") {
            GlobalController.newScore += 1;
            Destroy(col.gameObject);
        }
        if(col.tag == "ObstacleEnemy") {
            GlobalController.fromTest = 3;
            Destroy(col.gameObject);
            SceneManager.LoadScene("Scene_PassTest");
        }
    }
}
