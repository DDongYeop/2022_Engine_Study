using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    private int currentSceneNum;

    private void Awake()
    {
        int numGameSeession = FindObjectsOfType<GameSession>().Length;

        if (numGameSeession > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

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
        SceneManager.LoadScene(currentSceneNum);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
