using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : UIScreen
{
    [SerializeField] private Button tapToResult;

    public override void Init()
    {
        tapToResult.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.STANDBY));
        base.Init();
    }
}
