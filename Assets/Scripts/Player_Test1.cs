using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Test1 : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if(col.tag == "Hole") {
            if(GlobalController.newScore > 0) {
                GlobalController.fromTest = 1;
                SceneManager.LoadScene("Scene_PassTest");
            } else {
                GlobalController.fromTest = -1;
                SceneManager.LoadScene("Scene_FailTest");
            }
        }
    }
}
