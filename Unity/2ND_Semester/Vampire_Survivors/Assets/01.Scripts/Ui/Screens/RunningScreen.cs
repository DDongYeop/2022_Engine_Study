using UnityEngine;
using UnityEngine.UI;

namespace Ui.Screens
{
    public class RunningScreen : UIScreen
    {
               
        [SerializeField] private Button tapToResult;
        [SerializeField] private Slider levelsSlider;

        public override void Init()
        {
            tapToResult.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.GAMEOVER));

            GameManager.Instance.GetComponent<PlayerComponent>().GetPlayerComponent<PlayerPhysicsComponent>().HpSubscribe(playerData =>
            {
                levelsSlider.value = playerData.level % 1;
            });
        }
        
    }
}