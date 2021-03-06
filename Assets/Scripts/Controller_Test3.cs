﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller_Test3 : MonoBehaviour
{
    public Transform cameraLeft;
    public Transform cameraRight;
    public Transform groundPlaneLeft;
    public Transform groundPlaneRight;
    public Text scoreText;
    public GameObject playerLeft;
    public GameObject playerRight;
    public GameObject obstacleLeft;
    public GameObject obstacleRight;
    public GameObject obstacleEnemy;

    public List<GameObject> leftWalls;
    public List<GameObject> rightWalls;
    public float scroll;

    public float maxTime = 3;
    public float minTime = 1;
    public float maxEnemyTime = 10;
    public float minEnemyTime = 8;
    public float speedMultiplier = 1;
    private float time;
    private float enemyTime;
    private float spawnTime;
    private float spawnEnemyTime;

    private int leftTouch = 99;
    private Vector2 leftStartPt;
    private int rightTouch = 99;
    private Vector2 rightStartPt;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
        GlobalController.newScore = 0;
        spawnTime = Random.Range(minTime, maxTime);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBack();
        }
        
        //Left Player
        groundPlaneLeft.position = new Vector3(0, 0, playerLeft.transform.position.z + 20);

        //Right Player
        groundPlaneRight.position = new Vector3(0, 10, playerRight.transform.position.z + 20);

        float change = Time.deltaTime / 10;//player.transform.position.z / 1000000;
        minTime -= change;
        minTime = Mathf.Clamp(minTime, 0.05f, 10);
        maxTime -= change;
        maxTime = Mathf.Clamp(maxTime, 0.3f, 10);
        speedMultiplier += change;
        speedMultiplier = Mathf.Clamp(speedMultiplier, 1, 3);

        scoreText.text = GlobalController.newScore.ToString();


        //Spawning Enemy
        minEnemyTime -= change;
        minEnemyTime = Mathf.Clamp(minEnemyTime, 0.5f, 3);
        maxEnemyTime -= change;
        maxEnemyTime = Mathf.Clamp(maxEnemyTime, 2, 5);
        enemyTime += Time.deltaTime;
        if(enemyTime >= spawnEnemyTime) {
            Instantiate(obstacleEnemy, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(0.5f, 7), playerLeft.transform.position.z + 50), Quaternion.identity);
            Instantiate(obstacleEnemy, new Vector3(Random.Range(-4.5f, 4.5f), 10 + Random.Range(0.5f, 7), playerRight.transform.position.z + 50), Quaternion.identity);
            enemyTime = 0;
            spawnEnemyTime = Random.Range(minEnemyTime, maxEnemyTime);
        }


        //Movement////////////////
        for(int i = 0; i < Input.touchCount; ++i) {
            Touch t = Input.GetTouch(i);

            if(t.phase == TouchPhase.Began) {
                
                if(t.position.x > Screen.width/2) {
                    rightTouch = t.fingerId;
                }
                else if(t.position.x < Screen.width/2) {
                    leftTouch = t.fingerId;
                }
            }
            else if(t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary) {
                if(rightTouch == t.fingerId) {
                    Vector2 offset = t.position - new Vector2(Screen.width*3/4, 0);
                    movePlayerRight(offset);
                }
                else if(leftTouch == t.fingerId) {
                    Vector2 offset = t.position - new Vector2(Screen.width*1/4, 0);
                    movePlayerLeft(offset);
                }
            }
            else if(t.phase == TouchPhase.Ended){
                if(rightTouch == t.fingerId) {
                    rightTouch = 99;
                }
                else if(leftTouch == t.fingerId) {
                    leftTouch = 99;
                }
            }
        }

        //Wall Texture Scrolling
        float velLeft = playerLeft.GetComponent<Rigidbody>().velocity.z;
        leftWalls[0].GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.timeSinceLevelLoad / 10 * velLeft, 0);
        leftWalls[1].GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-Time.timeSinceLevelLoad / 10 * velLeft, 0);
        float velRight = playerLeft.GetComponent<Rigidbody>().velocity.z;
        rightWalls[0].GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.timeSinceLevelLoad / 10 * velRight, 0);
        rightWalls[1].GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-Time.timeSinceLevelLoad / 10 * velRight, 0);
    }

    void movePlayerLeft(Vector2 dir) {
        /*dir.x = Mathf.Clamp(dir.x, -100, 100);
        playerLeft.GetComponent<Rigidbody>().AddForce(new Vector3(dir.x * Time.deltaTime * 10, 0, 0));*/

        Vector3 pos = new Vector3(Mathf.Clamp(dir.x / Screen.width * 20, -4.45f, 4.45f), (dir.y / Screen.height * 7), playerLeft.transform.position.z);
        playerLeft.transform.position = pos;
    }

    void movePlayerRight(Vector2 dir) {
        Vector3 pos = new Vector3(Mathf.Clamp(dir.x / Screen.width * 20, -4.45f, 4.45f), 10 + (dir.y / Screen.height * 7), playerLeft.transform.position.z);
        playerRight.transform.position = pos;
    }

    void FixedUpdate()
    {
        //Left Camera
        Vector3 smoothPos1 = Vector3.Lerp(cameraLeft.position, new Vector3(playerLeft.transform.position.x, 4, playerLeft.transform.position.z - 8), 0.05f);
        smoothPos1.z = playerLeft.transform.position.z - 8;
        cameraLeft.position = smoothPos1;
        //Right Camera
        Vector3 smoothPos2 = Vector3.Lerp(cameraRight.position, new Vector3(playerRight.transform.position.x, 14, playerRight.transform.position.z - 8), 0.05f);
        smoothPos2.z = playerRight.transform.position.z - 8;
        cameraRight.position = smoothPos2;

        playerRight.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 14 * speedMultiplier));
        playerLeft.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 14 * speedMultiplier));
    
        //Spawn obstacles
        time += Time.deltaTime;
        if(time >= spawnTime) {
            Instantiate(obstacleLeft, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(0.5f, 7), playerLeft.transform.position.z + 50), Quaternion.identity);
            Instantiate(obstacleRight, new Vector3(Random.Range(-4.5f, 4.5f), 10 + Random.Range(0.5f, 7), playerRight.transform.position.z + 50), Quaternion.identity);
            time = 0;
            spawnTime = Random.Range(minTime, maxTime);
        }
    }
    
    public void RestartLevel() {
        SceneManager.LoadScene("Scene_Test3");
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }
}
