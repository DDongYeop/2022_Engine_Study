using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyConpoment : MonoBehaviour, Icomponent
{
    [SerializeField] private GameObject enemyPrefab;

    private List<GameObject> enemies = new List<GameObject>();

    private int enemyCount = 10;

    private Subject<List<GameObject>> enemiesStream = new();

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                Init();
                break;
            case GameState.STANDBY:
                Reset();
               
                break;
            case GameState.RUNNING:
                Generate();

                break;
        }
    }
    
    private void Init()
    {
        //GameManager.Instance.GetGameComponent<PlayerComponent>().PlayerMoveSubscribe(PlayerMoveEvent);
    }

    private void PlayerMoveEvent(Vector3 playerPosition)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            var movePosition = UpdatePosition(enemies[i].transform.position, playerPosition);

            enemies[i].transform.position = movePosition;
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
            var enemy = ObjectPool.Instance.GetObject(PoolObjectType.Enemy);
            enemy.transform.position = GetRandomPosition();
            enemies.Add(enemy);
        }

        enemiesStream.OnNext(enemies);
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
            ObjectPool.Instance.ReturnObject(PoolObjectType.Enemy, enemies[i]);
        
        enemies.Clear();
    }

    public void EenemiesSubscribe(Action<List<GameObject>> action)
    {
        enemiesStream.Subscribe(action);
    }
}
