using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Controller_Test2 : MonoBehaviour
{
    public Transform mainCamera;
    public Transform groundPlane;
    public Text scoreText;
    public GameObject player;
    public GameObject plane1;
    public GameObject plane2;
    public GameObject obstacle;

    public float maxTime = 3;
    public float minTime = 1;
    public float speedMultiplier = 1;
    private float time;
    private float spawnTime;

    void Start() {
        GlobalController.newScore = 0;
        spawnTime = Random.Range(minTime, maxTime);
        time = 0;
    }

    void Update() {

        Vector3 pos = player.transform.position;
        pos.y = player.transform.position.y + 2;
        pos.z = player.transform.position.z - 6.5f;
        mainCamera.position = pos;
        groundPlane.position = new Vector3(0, 0, player.transform.position.z + 20);

        if (Input.GetMouseButtonDown(0))
            if(player.transform.position.y < 0.6f && EventSystem.current.currentSelectedGameObject.name == "Tap Jump")
                player.GetComponent<Rigidbody>().AddForce(0, 650, 0);

        GlobalController.newScore = (int)player.transform.position.z;
        float change = Time.deltaTime / 10;//player.transform.position.z / 1000000;
        minTime -= change;
        minTime = Mathf.Clamp(minTime, 0.05f, 10);
        maxTime -= change;
        maxTime = Mathf.Clamp(maxTime, 0.3f, 10);
        speedMultiplier += change;
        speedMultiplier = Mathf.Clamp(speedMultiplier, 1, 6);

        scoreText.text = GlobalController.newScore.ToString();
    }

    void FixedUpdate()
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 14 * speedMultiplier));
        

        time += Time.deltaTime;
        if(time >= spawnTime) {
            Instantiate(obstacle, new Vector3(Random.Range(-9.5f, 9.5f), Random.Range(0.5f, 2.5f), player.transform.position.z + 50), Quaternion.identity);
            time = 0;
            spawnTime = Random.Range(minTime, maxTime);
        }
        
        if (Input.GetMouseButton(0))
        {
            if(EventSystem.current.currentSelectedGameObject.name == "Tap Move Right")
                player.GetComponent<Rigidbody>().AddForce(20 * speedMultiplier, 0, 0);

            if(EventSystem.current.currentSelectedGameObject.name == "Tap Move Left")
                player.GetComponent<Rigidbody>().AddForce(-20 * speedMultiplier, 0, 0);
        }
    }
    
    public void RestartLevel() {
        SceneManager.LoadScene("Scene_Test2");
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }
}
