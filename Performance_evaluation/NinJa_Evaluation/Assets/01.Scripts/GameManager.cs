using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private SaveSystem _saveSystem;

    public UnityEvent<bool> OnResultData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(Instance);

        OnResultData?.Invoke(File.Exists(Application.dataPath + "/SaveData/SaveFIle.txt"));
    }

    public void ClickStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ClickLoad()
    {
        StartCoroutine(LoadRoutine());
    }

    private IEnumerator LoadRoutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);

        while (!operation.isDone) //다 될떄까지 기다려라 
            yield return null;

        _saveSystem = FindObjectOfType<SaveSystem>();
        _saveSystem.Load();
    }
}
