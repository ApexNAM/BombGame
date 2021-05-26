using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public Text scoreText;
    public GameObject gameOverUI;
    private int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("DesertScene_mobile");
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        if(score < 0)
        {
            OnPlayerDead();
        }
        scoreText.text = "Score : " + score;
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }
}
