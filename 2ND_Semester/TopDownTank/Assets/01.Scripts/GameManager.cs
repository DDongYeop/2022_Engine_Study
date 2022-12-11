using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;

    private void Awake() 
    {
        SceneManager.sceneLoaded += Initalize;
        DontDestroyOnLoad(gameObject);
    }

    private void Initalize(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GM");
        var playerInput = FindObjectOfType<PlayInput>();
        if(playerInput != null)
            player = playerInput.gameObject;
        
        saveSystem = FindObjectOfType<SaveSystem>();

        if (player != null && saveSystem.LoadedData != null)
        {
            var damagable = player.GetComponent<Damagable>();
            damagable.Health = saveSystem.LoadedData.playerHealth;
        }
    }

    public void LoadLevel()
    {
        if (saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        if (player != null)
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex +1, player.GetComponentInChildren<Damagable>().Health);
    }
}
