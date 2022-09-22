using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private StageController _stageController;
    [SerializeField] private RectTransformMover _menuPanel;

    private Vector3 _inativePosition = Vector3.left * 1080;
    private Vector3 _activePosition = Vector3.zero;

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
        _menuPanel.MoveTo(AfterStageExitEvnet, _activePosition);
    }

    private void AfterStageExitEvnet()
    {
        SceneManager.LoadScene(0);
    }
}
