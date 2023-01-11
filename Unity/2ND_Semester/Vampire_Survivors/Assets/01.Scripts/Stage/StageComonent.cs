using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UniRx;
using UnityEngine;

public class StageComonent : Icomponent
{
    private Subject<Stage> stageStream = new();

    private Stage stage;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                Init();

                break;
            case GameState.RUNNING:
                stageStream.OnNext(stage);

                break;
        }
    }

    private void Init()
    {
        var paths = BetterStreamingAssets.GetFiles("/Data", "*.json", SearchOption.AllDirectories);

        stage = JsonUtility.FromJson<Stage>(BetterStreamingAssets.ReadAllText(paths[0]));

        stageStream.OnNext(stage);
    }

    public void Subscribe(Action<Stage> action)
    {
        stageStream.Subscribe(action);
    }
}
