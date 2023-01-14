using System;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerPhysicsComponent : IPlayerComponent
{
    private Subject<PlayerData> playerDataStream = new();

    private IObservable<int> levelUpStream;

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

        GameManager.Instance.GetGameComponent<EnemyComponent>().EnemyDestroySubject(enemy =>
        {
            playerData.level += .1f;
        });

        levelUpStream = Observable.EveryUpdate().Select(stream => (int)playerData.level).DistinctUntilChanged();

        player.OnCollisionEnter2DAsObservable().Subscribe(col =>
        {
            if (!col.collider.tag.Equals("Enemy")) return;

            playerData.hp --;

            playerDataStream.OnNext(playerData);

            var normalized = (player.transform.position - col.transform.position).normalized;
            DOTween.To(() => normalized, x => velocity = x, Vector3.zero, 1);

<<<<<<< HEAD
            if (playerData.hp <= 0)
                GameManager.Instance.UpdateState(GameState.GAMEOVER);
=======
            if (hp <= 0)
                GameManager.Instance.UpdateState(GameState.RESULT);
>>>>>>> parent of 02cc3201 (Vampire_Survivors - GameOver, StageClear)

        }).AddTo(GameManager.Instance);
    }

    private void UpdateTranslate(Vector2 direction) { player.transform.Translate(direction); }


    public void HpSubscribe(Action<PlayerData> action) { playerDataStream.Subscribe(action); }

    public void PlayerLevelUpSubscribe(Action<int> action)
    {
        levelUpStream.Subscribe(action);
    }

}