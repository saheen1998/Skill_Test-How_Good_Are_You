using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_ScoreTrigger : MonoBehaviour
{
    public Controller_Test2 ctrlTest2Scr;
    void OnTriggerEnter(Collider col) {
        if(col.tag == "Obstacle") {
            GlobalController.newScore += 1;

            ctrlTest2Scr.minTime -= 0.05f;
            ctrlTest2Scr.minTime = Mathf.Clamp(ctrlTest2Scr.minTime, 0.05f, 1);
            ctrlTest2Scr.maxTime -= 0.05f;
            ctrlTest2Scr.maxTime = Mathf.Clamp(ctrlTest2Scr.maxTime, 0.2f, 3);
            ctrlTest2Scr.speedMultiplier += 0.05f;
            ctrlTest2Scr.speedMultiplier = Mathf.Clamp(ctrlTest2Scr.speedMultiplier, 1, 4);
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.tag == "Obstacle")
            Destroy(col.gameObject);
    }
}
