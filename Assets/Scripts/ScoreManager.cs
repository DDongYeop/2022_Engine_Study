using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreTxt;
    private int currentScore;
    public Text bestScoreTxt;
    public int bestScore;

    public void SetScore(int value)
    {
        if (value >= 0) currentScore = value;
        currentScore = value;
        currentScoreTxt.text = "Score : " + currentScore;

        PlayerPrefs.SetInt("Current Score", currentScore);

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreTxt.text = "Best Score : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }
    public int GetScore()
    {
        return currentScore;
    }
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreTxt.text = "Best Score : " + bestScore;
    }
}
