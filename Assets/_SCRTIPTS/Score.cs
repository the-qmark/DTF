using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreDisplay;
    [SerializeField] private TMP_Text bestScoreDisplay;

    const string BEST_SCORE = "BEST_SCORE";
    private int currentScore;

    private void OnEnable()
    {
        Game.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        Game.GameOver -= OnGameOver;
    }

    private void Start()
    {
        bestScoreDisplay.text = PlayerPrefs.GetInt(BEST_SCORE, 0).ToString("0000");
    }

    public void StartGame()
    {
        currentScore = 0;
        Time.timeScale = 1;
        StartCoroutine(Counter());
    }

    private void OnGameOver()
    {
        StopCoroutine(Counter());

        if (currentScore > PlayerPrefs.GetInt(BEST_SCORE))
        {
            PlayerPrefs.SetInt(BEST_SCORE, currentScore);
            bestScoreDisplay.text = currentScore.ToString("0000");
        }
    }

    private IEnumerator Counter()
    {
        WaitForSeconds halfSec = new WaitForSeconds(0.5f);

        while (true)
        {
            yield return halfSec;
            currentScore++;
            scoreDisplay.text = currentScore.ToString("0000");
        }
    }
}
