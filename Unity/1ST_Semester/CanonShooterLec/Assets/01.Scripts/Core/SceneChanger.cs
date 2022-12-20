using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

    public int maxClearStage = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(Instance != null)
        {
            Debug.Log("Multiple SceneManager is running");
            return;
        }

        Instance = this;

        maxClearStage = PlayerPrefs.GetInt("MaxStage", 0);
    }

    public void LoadGameScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
