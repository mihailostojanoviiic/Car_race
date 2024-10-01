using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool timer;
    private float currentTime;
    private float bestTime;

    public GameObject TimeBox;
    public GameObject BestTimeBox;
    public GameObject ScoreBox;

    public GameObject effect;
    public GameObject effect1;

    public GameObject[] coins = new GameObject[13];
    private static int score;

    public AudioSource audioPlayer;

    void Start()
    {
        currentTime = 0;
        bestTime = float.MaxValue;
        BestTimeBox.GetComponent<TMP_Text>().text = "00:00.0";
    }

    public void StartTimer()
    {
        timer = true;
    }

    public void StopTimer()
    {
        timer = false;
    }

    public void ResetTimer()
    {
        if (timer == true)
        {
            if (currentTime < bestTime)
            {
                Debug.Log("aaa");
                bestTime = currentTime;
                BestTimeBox.GetComponent<TMP_Text>().text = FormatTime(bestTime);
            }

            currentTime = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            audioPlayer.Play();
            score++;
        }

        if (other.CompareTag("Start"))
        {
            StartTimer();
            var fireworks = Instantiate(effect);
            var fireworks1 = Instantiate(effect1);
            fireworks.transform.position = new Vector3(123, 8, 74);
            fireworks1.transform.position = new Vector3(117, 8, 77);
            Destroy(fireworks, 5);
            Destroy(fireworks1, 5);
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].SetActive(true);
            }
            score = 0;
        }

        if (other.CompareTag("Finish"))
        {
            ResetTimer();
        }
    }

    void Update()
    {
        if (timer)
        {
            currentTime += Time.deltaTime;
        }
        TimeBox.GetComponent<TMP_Text>().text = FormatTime(currentTime);
        ScoreBox.GetComponent<TMP_Text>().text = score.ToString();
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);
        return time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00") + "." + (time.Milliseconds / 10).ToString("00");
    }
}
