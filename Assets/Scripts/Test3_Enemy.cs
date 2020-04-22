using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3_Enemy : MonoBehaviour
{
    private float dirX;
    private float dirY;
    private float dirZ;
    void Start()
    {
        dirX =  Random.Range(1f, 3f);
        dirY =  Random.Range(1f, 3f);
        dirZ =  Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dirX, dirY, dirZ);
    }
}
