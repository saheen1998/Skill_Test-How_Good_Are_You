using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_ScoreTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider col) {
        if(col.tag == "Obstacle" || col.tag == "ObstacleEnemy")
            Destroy(col.gameObject);
    }
}
