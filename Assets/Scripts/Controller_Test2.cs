using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Controller_Test2 : MonoBehaviour
{
    public Transform mainCamera;
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

    void FixedUpdate()
    {
        player.GetComponent<Rigidbody>().AddForce(0, 0, 3 * speedMultiplier);
        Vector3 pos = player.transform.position;
        pos.y = player.transform.position.y + 2;
        pos.z = player.transform.position.z - 6.5f;
        mainCamera.position = pos;

        time += Time.deltaTime;
        if(time >= spawnTime) {
            Instantiate(obstacle, new Vector3(Random.Range(-9.5f, 9.5f), Random.Range(0.5f, 4.5f), player.transform.position.z + 50), Quaternion.identity);
            time = 0;
            spawnTime = Random.Range(minTime, maxTime);
        }

        if (Input.GetMouseButton(0))
        {
            if(EventSystem.current.currentSelectedGameObject.name == "Tap Move Right")
                player.GetComponent<Rigidbody>().AddForce(3 * speedMultiplier, 0, 0);

            if(EventSystem.current.currentSelectedGameObject.name == "Tap Move Left")
                player.GetComponent<Rigidbody>().AddForce(-3 * speedMultiplier, 0, 0);
        }

        scoreText.text = GlobalController.newScore.ToString();
    }
    
    public void RestartLevel() {
        SceneManager.LoadScene("Scene_Test2");
    }

    public void GoBack() {
        SceneManager.LoadScene("Scene_TestMenu");
    }

    public void Jump() {
        if(player.transform.position.y < 0.6f)
            player.GetComponent<Rigidbody>().AddForce(0, 80, 0);
    }
}
