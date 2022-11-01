using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private GameObject _textTitle;
    [SerializeField] private GameObject _textTapToPlay;

    [SerializeField] private TextMeshProUGUI _textCurrentScore;
    [SerializeField] private TextMeshProUGUI _textBestScore;

    [SerializeField] private GameObject _buttonContinue;
    [SerializeField] private GameObject _textScoreText;

    private int _currentScore = 0;
    private int _bestScore = 0;

    public bool isGameOver { private set; get; }

    private IEnumerator Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        _textBestScore.text = $"<size=50>BEST</size>\n<size=100>{bestScore}</size>";

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        _textTitle.SetActive(false);
        _textTapToPlay.SetActive(false);

        _textCurrentScore.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        ShakeCamera.Instance.OnShakeCamera(.5f, .1f);

        isGameOver = true;

        StartCoroutine(OnGameOver());
    }

    private IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(1);

        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (_currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", _currentScore);
        }

        _buttonContinue.SetActive(true);
        _textScoreText.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        _currentScore += score;

        _textCurrentScore.text = _currentScore.ToString();

        if (_bestScore < _currentScore)
        {
            _bestScore = _currentScore;
            _textBestScore.text = $"<size=50>BEST</size>\n<size=100>{_bestScore}</size>";
        }

        _cameraController.ChageBackGroundColor();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
