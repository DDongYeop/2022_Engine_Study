using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConpoment : MonoBehaviour, Icomponent
{
    [SerializeField] private GameObject enemyPrefab;

    private List<GameObject> enemies = new List<GameObject>();

    private int enemyCount = 10;

    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.STANDBY:
                Reset();
                Generate();
                break;
        }
    }

    private void Generate()
    {
        for (var i = 0; i < enemyCount; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = GetRandomPosition();
            enemies.Add(enemy);
        }
}

    private Vector3 GetRandomPosition()
    {
        var angle
         = Random.Range(0, 361) * Mathf.Rad2Deg;

        var position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 2;

        return position;
    }

    private void Reset() 
    {
        for (int i = 0; i < enemies.Count; i++)
            Destroy(enemies[i]);
        
        enemies.Clear();
    }
}
