using System;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerPhysicsComponent : IPlayerComponent
{
    private IObservable<int> levelUpStream;

    private Subject<PlayerData> playerDataStream = new();

    private Vector3 velocity;

    public PlayerPhysicsComponent(GameObject player, PlayerData playerData) : base(player, playerData)
    {

    }

    public override void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                Init();

                break;
            case GameState.STANDBY:
                playerData.hp = playerData.maxhp;
                playerData.level = 0;

                playerDataStream.OnNext(playerData);
                break;
        }
    }

    private void Init()
    {
        GameManager.Instance.GetGameComponent<PlayerComponent>().PlayerMoveSubscribe(playerPosition =>
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            direction *= Time.deltaTime * playerData.speed;
            direction += velocity * Time.deltaTime * 2;

            UpdateTranslate(direction);
        });

        GameManager.Instance.GetGameComponent<UIComponent>().GetScreen<LevelUpScreen>().SelectItemSubscribe(itemIndex => {
            switch(itemIndex){
                case 0:
                    playerData.speed += .5f;
                    break;
                case 1:
                    playerData.hp = playerData.maxhp;
                    break;
            }

            playerDataStream.OnNext(playerData);
        });

        levelUpStream = Observable.EveryUpdate().Select(stream => (int)playerData.level).DistinctUntilChanged();

        player.OnCollisionEnter2DAsObservable().Subscribe(col =>
        {
            if (!col.collider.tag.Equals("Enemy")) return;

            playerData.hp --;

            playerDataStream.OnNext(playerData);

            var normalized = (player.transform.position - col.transform.position).normalized;
            DOTween.To(() => normalized, x => velocity = x, Vector3.zero, 1);

            if (playerData.hp <= 0)
                GameManager.Instance.UpdateState(GameState.GAMEOVER);

        }).AddTo(GameManager.Instance);

        GameManager.Instance.GetGameComponent<EnemyComponent>().EnemyDestroySubscribe(enemy => {
            playerData.level += .1f;
            playerDataStream.OnNext(playerData);
        });
    }

    private void UpdateTranslate(Vector2 direction) { player.transform.Translate(direction); }


    public void PlayerDataSubscribe(Action<PlayerData> action) { playerDataStream.Subscribe(action); }

    public void PlayerLevelUpSubscribe(Action<int> action) { levelUpStream.Subscribe(action); }

}