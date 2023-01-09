using UniRx;
using System;
using UnityEngine;

public class PlayerComponent : Icomponent
{
    private GameObject player;

    private IObservable<Vector3> playerMoveStream;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                Init();
                break;
        }
    }

    private void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerMoveStream = Observable.EveryUpdate().Select(steam => player.transform.position);
    }

    public void PlayerMoveSubscribe(Action<Vector3> action)
    {
        playerMoveStream.Subscribe(action); 
    }
}
