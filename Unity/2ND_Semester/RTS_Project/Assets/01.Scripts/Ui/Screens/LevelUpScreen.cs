using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : UIScreen
{
    [SerializeField] private Button cancelButton;

    [SerializeField] private Button[] itemButtons;

    private Subject<int> selectItemStream = new Subject<int>();

    public override void UpdateScreenState(bool open)
    {
        
    }

    public override void Init()
    {
        for(int i = 0; i < itemButtons.Length; i++){
            var index = i;

            itemButtons[i].onClick.AddListener(() => {
                Time.timeScale = 1;
                base.UpdateScreenState(false);
                selectItemStream.OnNext(index);
            });
        }

        GameManager.Instance.GetGameComponent<PlayerComponent>().GetPlayerComponent<PlayerPhysicsComponent>().PlayerLevelUpSubscribe(level => {
            if(level == 0) return;

            base.UpdateScreenState(true);
            Time.timeScale = 0;
        });

        cancelButton.onClick.AddListener(() => {
            Time.timeScale = 1;
            base.UpdateScreenState(false);
        });
    }

    public void SelectItemSubscribe(Action<int> action){
        selectItemStream.Subscribe(action);
    }
}