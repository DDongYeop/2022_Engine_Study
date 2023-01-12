using System;
using System.IO;
using UniRx;
using UnityEngine;

public class StageComponent : IComponent
{

    private Subject<Stage> stageStream = new ();

    private Stage stage;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.RUNNING:
                Parsing();
                break;
        }
    }
    
    private void Parsing()
    {
        var paths = BetterStreamingAssets.GetFiles("/Data", "NormalStage.json", SearchOption.AllDirectories);

        stage = JsonUtility.FromJson<Stage>(BetterStreamingAssets.ReadAllText(paths[0]));

        stageStream.OnNext(stage);
    }

    public void StageSubscribe(Action<Stage> action)
    {
        stageStream.Subscribe(action);
    }

}