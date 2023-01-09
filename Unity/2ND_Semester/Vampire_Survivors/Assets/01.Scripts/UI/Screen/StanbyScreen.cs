using UnityEngine;
using UnityEngine.UI;

public class StanbyScreen : UIScreen
{
    [SerializeField] private Button tapToRunning; 

    public override void Init()
    {
        tapToRunning.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.RUNNING));
    }
}
