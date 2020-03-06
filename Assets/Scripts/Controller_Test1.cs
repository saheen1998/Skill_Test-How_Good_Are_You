using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller_Test1 : MonoBehaviour
{
    public Rigidbody player;
    public float playerSpeed = 1;
    public GameObject holePrefab;
    public Text timeText;

    private int currScore = 0;
    
    void Start()
    {
        for(int i = 0; i < 30; i++)
            Instantiate(holePrefab, new Vector3(Random.Range(-8.5f, 8.5f), 0.5f, Random.Range(-16.5f, 15f)), Quaternion.identity);
    }

    void Update()
    {
        
        if (Application.isEditor)
            player.AddForce(Input.GetAxis("Horizontal")*Time.deltaTime*playerSpeed*10, 0 , Input.GetAxis("Vertical")*Time.deltaTime*playerSpeed*10);
        else
            player.AddForce(Input.acceleration.x*playerSpeed, 0 , Input.acceleration.y*playerSpeed);

        currScore = (int)Mathf.Clamp(100 - Time.timeSinceLevelLoad*5, 0, 100);
        timeText.text = currScore.ToString();
        //Debug.Log(Input.GetAxis("Horizontal")*Time.deltaTime + ", " + Input.GetAxis("Vertical")*Time.deltaTime);
    }

    public void RestartLevel() {
        SceneManager.LoadScene("Scene_Test1");
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    void OnTriggerEnter() {
        GlobalController.fromTest = 1;
        GlobalController.newScore = currScore;
        SceneManager.LoadScene("Scene_PassTest");
    }
}
