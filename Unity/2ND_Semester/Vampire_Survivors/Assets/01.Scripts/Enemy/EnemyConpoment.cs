using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyConpoment : MonoBehaviour, Icomponent
{
    private List<Enemy> enemies = new ();

    private int enemyCount = 10;

    private Subject<List<Enemy>> enemiesStream = new();

    private IDisposable spawner;

    private Stage stage;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                GameManager.Instance.GetGameComponent<StageComonent>().Subscribe(SpawnRoutine);

                Init();
                break;
            case GameState.STANDBY:
                Reset();
               
                break;
            case GameState.RUNNING:
                break;
            case GameState.RESULT:
                spawner.Dispose();
                break;
        }
    }

    private void SpawnRoutine(Stage stage)
    {
        var spawn = stage.spawns[0];

        stage.spawns.RemoveAt(0);

        spawner = Observable
            .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromMilliseconds(spawn.frequency))
            .Select(x => (int)(spawn.frequencyTime - x))
            .TakeWhile(x => x > 0)
            .Subscribe(time =>
            {
                var count = spawn.minimum - enemies.Count;

                if (count > 0)
                    Generate(count);
            }, () =>
            {
                if (stage.spawns.Count == 0) return;

                spawner.Dispose();

                SpawnRoutine(stage);
            });
    }

    private void Generate(int count)
    {
        for (var i = 0; i < count; i++)
        {
            enemies.Add(Enemy.EnemyBuilder.Build(PoolObjectType.Enemy));

            enemies[^1].Position = GetRandomPosition();

            enemies[^1].DestroySubscribe(EnemyDestroyEvent);
        }

        enemiesStream.OnNext(enemies);
    }

    private void Init()
    {
        GameManager.Instance.GetGameComponent<PlayerComponent>().PlayerMoveSubscribe(PlayerMoveEvent);
    }

    private void PlayerMoveEvent(Vector3 playerPosition)
    {
        foreach (var enemy in enemies)
        {
            var movePosition = UpdatePosition(enemy.Position, playerPosition);

            enemy.Position = movePosition;
        }
    }

    private Vector3 UpdatePosition(Vector3 enemyPosition, Vector3 playerPosition)
    {
        var normal = (playerPosition - enemyPosition).normalized;
        enemyPosition += normal * Time.deltaTime * 0.16f;

        return enemyPosition;
    }

    private void Generate()
    {
        for (var i = 0; i < enemyCount; i++)
        {
            enemies.Add(Enemy.EnemyBuilder.Build(PoolObjectType.Enemy));

            enemies[^1].Position = GetRandomPosition();

            enemies[^1].DestroySubscribe(EnemyDestroyEvent);
        }

        enemiesStream.OnNext(enemies);
    }

    private void EnemyDestroyEvent(Enemy target)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].Equals(target))
            {
                enemies.RemoveAt(i);
                return;
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        var angle = Random.Range(0, 361) * Mathf.Rad2Deg;

        var position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 2;

        return position;
    }

    private void Reset() 
    {
        Debug.Log(enemies.Count);

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].ReturnObject();
        }
        
        enemies.Clear();
    }

    public void EenemiesSubscribe(Action<List<Enemy>> action)
    {
        enemiesStream.Subscribe(action);
    }
}
