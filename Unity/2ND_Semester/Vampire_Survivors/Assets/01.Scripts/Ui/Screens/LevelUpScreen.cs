using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : UIScreen
{
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button[] itamButtons;

    private Subject<int> selecteItemStream = new();

    public override void UpdateScreenState(bool open)
    {

    }

    public override void Init()
    {
        GameManager.Instance.GetGameComponent<PlayerComponent>().GetPlayerComponent<PlayerPhysicsComponent>().PlayerLevelUpSubscribe(level =>
        {
            if (level == 0)
                return;

            base.UpdateScreenState(true);
            Time.timeScale = 0;
        });

        cancelButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            base.UpdateScreenState(false);
        });
    }

    public void SelectItemSubscribe(Action<int> action)
    {
        selecteItemStream.Subscribe(action);
    }
}
