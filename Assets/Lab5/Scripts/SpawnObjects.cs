using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{

    public Transform playerPosition;
    public float timeLeft = 30;
    public Text countDownTimerText;
    public int objectGenerationNumber = 10;
    public GameObject object0;
    public GameObject object1;
    public GameObject object2;

    private float lastTime;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameOver();
        }
        else
        {
            if (Time.time > lastTime+3f && objectGenerationNumber > 0)
            {
                lastTime = Time.time;
                Instantiate(object0, new Vector3(UnityEngine.Random.Range(-7.0f, 7.0f), 7.0f, 9.5f), Quaternion.identity);
                Instantiate(object1, new Vector3(UnityEngine.Random.Range(-7.0f, 7.0f), 7.0f, 9.5f), Quaternion.identity);
                Instantiate(object2, new Vector3(UnityEngine.Random.Range(-7.0f, 7.0f), 7.0f, 9.5f), Quaternion.identity);
                objectGenerationNumber--;
            }

            countDownTimerText.text = timeLeft.ToString("00s");
        }

        
    }

    void GameOver()
    {
        SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
    }
}
