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
<<<<<<< HEAD
            tapToResult.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.GAMEOVER));

            GameManager.Instance.GetComponent<PlayerComponent>().GetPlayerComponent<PlayerPhysicsComponent>().HpSubscribe(playerData =>
            {
                levelsSlider.value = playerData.level % 1;
            });
=======
            tapToResult.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.RESULT));
>>>>>>> parent of 02cc3201 (Vampire_Survivors - GameOver, StageClear)
        }
        
    }
}