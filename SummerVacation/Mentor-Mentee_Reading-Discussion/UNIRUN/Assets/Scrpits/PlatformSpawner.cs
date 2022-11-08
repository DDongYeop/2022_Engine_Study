using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private float _spawnTimeMin = 1.25f;
    private float _spawnTimeMax = 2.25f;
    private float _spawnTime;

    private float _yPosMin = -3.5f;
    private float _yPosMax = 1.5f;
    private float _yPos;

    private void Start()
    {
        StartCoroutine(SpawnCoroutime());
    }

    IEnumerator SpawnCoroutime()
    {
        while (!GameManager.instance.IsGameOver)
        {
            _spawnTime = Random.Range(_spawnTimeMin, _spawnTimeMax);
            _yPos = Random.Range(_yPosMin, _yPosMax);

            GameObject platform = PoolManager.Instance.Pop("Platform");
            platform.transform.position = new Vector3(20, _yPos, 0);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
