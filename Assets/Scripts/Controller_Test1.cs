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
    public static int numHoles = 30;
    public static float timeMultiplier = 1; 
    
    void Start()
    {
        for(int i = 0; i < numHoles; i++)
            Instantiate(holePrefab, new Vector3(Random.Range(-8.5f, 8.5f), 0, Random.Range(-16.5f, 15f)), Quaternion.identity);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBack();
        }
        
        currScore = (int)Mathf.Clamp(100 - Time.timeSinceLevelLoad * 5 * timeMultiplier, 0, 100);
        scoreText.text = GlobalController.newScore.ToString();
        timeText.text = currScore.ToString();
        //Debug.Log(Input.GetAxis("Horizontal")*Time.deltaTime + ", " + Input.GetAxis("Vertical")*Time.deltaTime);
    }

    void FixedUpdate() {
        if (Application.isEditor)
            player.AddForce(Input.GetAxis("Horizontal")*playerSpeed, 0 , Input.GetAxis("Vertical")*playerSpeed);
        else
            player.AddForce(Input.acceleration.x*playerSpeed*8, 0 , Input.acceleration.y*playerSpeed*8);
    }

    public void RestartLevel() {
        GlobalController.newScore = 0;
        numHoles = 30;
        SceneManager.LoadScene("Scene_Test1");
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    void OnTriggerEnter() {
        GlobalController.newScore += currScore;
        numHoles += 3;
        numHoles = Mathf.Clamp(numHoles, 30, 70);
        timeMultiplier -= 0.05f;
        timeMultiplier = Mathf.Clamp(timeMultiplier, 0.2f, 1);
        SceneManager.LoadScene("Scene_Test1");
    }
}
