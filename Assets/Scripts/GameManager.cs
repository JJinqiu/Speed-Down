using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public Text timeScore;
    public GameObject gameOverUI;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        _instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void GameOver(bool isDead)
    {
        if (isDead)
        {
            _instance.gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}