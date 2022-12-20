using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public List<GameObject> poolingList = new List<GameObject>();

    private bool _isGameOver = false;
    public bool IsGameOver
    {
        set
        {
            _isGameOver = value;
        }
        get
        {
            return _isGameOver;
        }
    }
    public Text scoreText;
    public GameObject gameOverObject;
    private float _score = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("두개의 게임 매니저가 존재하고 있어요 ! ㅜㅅㅜ");
        }
        instance = this;

        PoolManager.Instance = gameObject.AddComponent<PoolManager>();
        foreach (GameObject item in poolingList)
        {
            PoolManager.Instance.CreatePool(item, transform, 10);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _isGameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (_isGameOver == false)
        {
            _score += newScore;
            scoreText.text = "Score : " + _score;
        }
    }

    public void OnPlayerDead()
    {
        _isGameOver = true;
        gameOverObject.SetActive(true);
    }
}
