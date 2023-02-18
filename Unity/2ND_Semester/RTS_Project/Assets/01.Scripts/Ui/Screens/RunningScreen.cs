using UnityEngine;
using UnityEngine.UI;

namespace Ui.Screens
{
    public class RunningScreen : UIScreen
    {
        [SerializeField] private Button tapToResult;
        [SerializeField] private Slider levelSlider;

        public override void Init()
        {
            tapToResult.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.GAMEOVER));

            GameManager.Instance.GetGameComponent<PlayerComponent>().GetPlayerComponent<PlayerPhysicsComponent>().PlayerDataSubscribe(data => {
                levelSlider.value = data.level % 1;
            });
        }
        
    }
}