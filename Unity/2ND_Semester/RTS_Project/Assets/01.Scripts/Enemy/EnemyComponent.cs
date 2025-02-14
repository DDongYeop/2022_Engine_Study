﻿using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyComponent : MonoBehaviour, IComponent
{
    private List<Enemy> enemies = new ();

    private Subject<List<Enemy>> enemiesStream = new();

    private Subject<Enemy> enemyDestroyStream = new Subject<Enemy>();

    private IDisposable spawner;

    private Vector3 spawnPoint;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                GameManager.Instance.GetGameComponent<PlayerComponent>().PlayerMoveSubscribe(PlayerMoveEvent);

                GameManager.Instance.GetGameComponent<StageComponent>().StageSubscribe(SpawnRoutine);
                break;
            case GameState.STANDBY:
                Reset();
                
                break;
            case GameState.RUNNING:
                
                break;
            case GameState.GAMEOVER or GameState.STAGECOMPLETE:
                spawner.Dispose();
                break;
        }
    }

    private void SpawnRoutine(Stage stage)
    {
        var spawn = stage.spawns[0];

        stage.spawns.RemoveAt(0);

        spawner = Observable.
            Timer(TimeSpan.FromSeconds(0), TimeSpan.FromMilliseconds(spawn.frequency))
            .Select(stream => (int)spawn.frequencyTime - stream)
            .TakeWhile(time => time > 0)
            .Subscribe(time =>
            {
                Debug.Log(time);

                var count = spawn.minimum - enemies.Count;

                if (count <= 0)
                    return;

                for(var i = 0; i < count; i++){
                    var type = (PoolObjectType)spawn.enemies[Random.Range(0, spawn.enemies.Length)];

                    Generate(type);
                }
            }, 
            () =>
            {
                if (stage.spawns.Count == 0)
                {
                    GameManager.Instance.UpdateState(GameState.STAGECOMPLETE);
                }
                else
                {
                    spawner.Dispose();

                    SpawnRoutine(stage);
                }
            }).AddTo(GameManager.Instance);
    }

    private void PlayerMoveEvent(Vector3 playerPosition)
    {
        spawnPoint = playerPosition;

        foreach (var enemy in enemies)
        {
            var movePosition = UpdatePosition(enemy.Position, playerPosition);

            enemy.Position = movePosition;
        }
    }
    
    private Vector3 UpdatePosition(Vector3 enemyPosition, Vector3 playerPosition)
    {
        var normalized = (playerPosition - enemyPosition).normalized;
        enemyPosition += normalized * (.25f * Time.deltaTime);

        return enemyPosition;
    }

    private void Generate(PoolObjectType type)
    {
        for (var i = 0; i < 1; i++)
        {
            var enemyPos = GetRandomCircleEdgeVector3();

            if(!GameManager.Instance.GetGameComponent<TileComponent>().IsCollision(enemyPos, out var returnPosition)){
                enemies.Add(Enemy.EnemyBuilder.Build(type));

                enemies[^1].Position = enemyPos;

                enemies[^1].DestroySubscribe(EnemyDestroyEvent);
            }
            else{
                i--;
            }
        }

        enemiesStream.OnNext(enemies);
    }
    
    private void EnemyDestroyEvent(Enemy target)
    {
        enemyDestroyStream.OnNext(target);

        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].Equals(target))
            {
                enemies.RemoveAt(i);

                return;
            }
        }
    }


    private void Reset()
    {
        for (var i = 0; i < enemies.Count; i++)
        {
            enemies[i].ReturnObject();  
        }
        
        enemies.Clear();
    }
    
    private Vector3 GetRandomCircleEdgeVector3()
    {
        var angle = Random.Range(0, 361) * Mathf.Rad2Deg;

        var result = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) + spawnPoint;
        
        return result;
    }

    public void EnemiesSubscribe(Action<List<Enemy>> action)
    {
        enemiesStream.Subscribe(action);
    }
    
    public void EnemyDestroySubscribe(Action<Enemy> action){
        enemyDestroyStream.Subscribe(action);
    }
}