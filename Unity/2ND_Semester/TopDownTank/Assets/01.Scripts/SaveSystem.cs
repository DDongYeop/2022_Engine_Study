using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{
    public string playerHealthKey = "PlayerHealth", sceneKey = "SceneIndex", savePresentKey = "SavePresent";
    public LoadData LoadedData { get; private set; }

    public UnityEvent<bool> OnDataLoadedResult;

    private void Awake() 
    {
        DontDestroyOnLoad(this);
    }

    private void Start() 
    {
        var result = this.LoadData();
        OnDataLoadedResult?.Invoke(result);
    }

    public void ResetData() 
    {
        PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.DeleteKey(savePresentKey);
        LoadedData = null;
    }

    public void SaveData(int sceneIndex, int playerHealth)
    {
        if (LoadedData == null)
            LoadedData = new LoadData();

        LoadedData.sceneIndex = sceneIndex;
        LoadedData.playerHealth = playerHealth;
        
        PlayerPrefs.SetInt(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, sceneIndex);
        PlayerPrefs.SetInt(savePresentKey, 1);
    }

    public bool LoadData()
    {
        if (PlayerPrefs.GetInt(savePresentKey) == 1)
        {
            LoadedData = new LoadData();
            LoadedData.playerHealth = PlayerPrefs.GetInt(playerHealthKey);
            LoadedData.sceneIndex = PlayerPrefs.GetInt(sceneKey);
            return true;
        }
        return false;
    }
}

public class LoadData
{
    public int playerHealth = -1;
    public int sceneIndex = -1;
}
