using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header ("GameStart UI")]
    [SerializeField] private FadeEffect[] _fadeGameStart;
    [SerializeField] private GameObject _panelGameStart;
    [SerializeField] private TextMeshProUGUI _textGameStartBestScore;

    [Header("InGae UI")]
    [SerializeField] private TextMeshProUGUI _textInGameScore;

    [Header("GmaeOver UI")]
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private TextMeshProUGUI _textGameOverScore;
    [SerializeField] private TextMeshProUGUI _textGameOverBestScore;
    [SerializeField] private float _timeStopTime;

    private int _currentScore = 0;

    public bool isGameStart { get; private set; } = false;
    public bool isGameOver { get; private set; }

    private IEnumerator Start()
    {
        Time.timeScale = 1;

        int bestScore = PlayerPrefs.GetInt("BestScore");
        _textGameStartBestScore.text = bestScore.ToString();

        for (int i = 0; i < _fadeGameStart.Length; ++i)
        {
            _fadeGameStart[i].FadeIn();
        }

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                isGameStart = true;
                yield return null;
            }

            yield return null;
        }
    }

    public void GameStart()
    {
        _panelGameStart.SetActive(false);

        _textInGameScore.gameObject.SetActive(true);
    }

    public void IncreseScore(int score = 1)
    {
        _currentScore += score;
        _textInGameScore.text = _currentScore.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        _textGameOverScore.text = _currentScore.ToString();
        _panelGameOver.SetActive(true);

        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (_currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", _currentScore);
            _textGameOverBestScore.text = _currentScore.ToString();
        }
        else
            _textGameOverBestScore.text = bestScore.ToString();

        StartCoroutine(SlowAndStopTime());
    }

    private IEnumerator SlowAndStopTime()
    {
        float current = 0;
        float percent = 0;

        Time.timeScale = .5f;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / _timeStopTime;

            yield return null;
        }

        Time.timeScale = 0;
    }
}
