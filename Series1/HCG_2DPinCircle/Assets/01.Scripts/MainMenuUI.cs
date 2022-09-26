using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private StageController _stageController;
    [SerializeField] private RectTransformMover _menuPanel;
    [SerializeField] private TextMeshProUGUI _textLevelInMenu;
    [SerializeField] private TextMeshProUGUI _textLevelInGame;

    private Vector3 _inativePosition = Vector3.left * 1080;
    private Vector3 _activePosition = Vector3.zero;

    private void Awake()
    {
        int index = PlayerPrefs.GetInt("StageLevel");
        _textLevelInMenu.text = $"Level {index+1}";
    }

    public void ButtonClickEventStart()
    {
        _menuPanel.MoveTo(AfterStartEvent, _inativePosition);
    }

    private void AfterStartEvent()
    {
        _stageController.isGameStart = true;
    }

    public void ButtonClickEventReset()
    {
        PlayerPrefs.SetInt("StageLevel", 0);
    }

    public void ButtonClickEventExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void StageExit()
    {
        int index = PlayerPrefs.GetInt("StageLevel");
        _textLevelInMenu.text = $"Level {index+1}";

        _menuPanel.MoveTo(AfterStageExitEvnet, _activePosition);
    }

    private void AfterStageExitEvnet()
    {
        int index = PlayerPrefs.GetInt("StageLevel");

        if (index == SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("StageLevel", 0);
            SceneManager.LoadScene(0);
            return;
        }

        SceneManager.LoadScene(index);
    }
}
