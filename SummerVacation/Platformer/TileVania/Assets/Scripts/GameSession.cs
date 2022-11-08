using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] TextMeshProUGUI scoreText;

    private int currentSceneNum;

    private ScenePersist  _scenePersist;

    private void Awake()
    {
        int numGameSeession = FindObjectsOfType<GameSession>().Length;

        if (numGameSeession > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

        _scenePersist = GameObject.Find("ScenePersist").GetComponent<ScenePersist>();

    }

    private void Start()
    {
        liveText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void PrecessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        playerLives--;
        liveText.text = playerLives.ToString();
        SceneManager.LoadScene(currentSceneNum);
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void CoinAcheive(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
