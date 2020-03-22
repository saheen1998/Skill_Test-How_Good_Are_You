using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller_Test1 : MonoBehaviour
{
    public Rigidbody player;
    public float playerSpeed = 10;
    public GameObject holePrefab;
    public Text timeText;
    public Text scoreText;

    public int currScore = 0;
    
    void Start()
    {
        for(int i = 0; i < 30; i++)
            Instantiate(holePrefab, new Vector3(Random.Range(-8.5f, 8.5f), 0.5f, Random.Range(-16.5f, 15f)), Quaternion.identity);
    }

    void Update()
    {

        currScore = (int)Mathf.Clamp(100 - Time.timeSinceLevelLoad*5, 0, 100);
        scoreText.text = GlobalController.newScore.ToString();
        timeText.text = currScore.ToString();
        //Debug.Log(Input.GetAxis("Horizontal")*Time.deltaTime + ", " + Input.GetAxis("Vertical")*Time.deltaTime);
    }

    void FixedUpdate() {
        if (Application.isEditor)
            player.AddForce(Input.GetAxis("Horizontal")*playerSpeed, 0 , Input.GetAxis("Vertical")*playerSpeed);
        else
            player.AddForce(Input.acceleration.x*playerSpeed*10, 0 , Input.acceleration.y*playerSpeed*10);
    }

    public void RestartLevel() {
        GlobalController.newScore = 0;
        SceneManager.LoadScene("Scene_Test1");
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    void OnTriggerEnter() {
        GlobalController.newScore += currScore;
        SceneManager.LoadScene("Scene_Test1");
    }
}
