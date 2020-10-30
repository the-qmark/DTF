using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static event UnityAction GameOver;

    [SerializeField] private GameObject menu;

    private void OnEnable()
    {
        GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameOver -= OnGameOver;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
    }

    public static void GameIsOver()
    {
        GameOver?.Invoke();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void RestartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
