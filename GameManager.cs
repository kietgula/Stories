using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private bool isOver;
    float timer = 0f;

    private void Start()
    {
        isOver = false;
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (!isOver)
            UpdateScore();

        if (isOver && Input.GetKey(KeyCode.Space))
        {
            timer = 0f;
            SceneManager.LoadScene(1); 
        }
    }

    void UpdateScore()
    {
        scoreText.text = timer.ToString();
    }

    public void GameOver()
    {
        if (!isOver)
        {
            isOver = true;
            scoreText.text = "Game Over: " + scoreText.text + "Hit spacebar to try again";
        }
    }
}
