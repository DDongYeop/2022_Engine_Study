using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _areaPrefabs;
    [SerializeField] private Transform _player;
    [SerializeField] private int _spawnAreaAtAtStart = 2;
    [SerializeField] private float _distanceToNext = 30;

    private int _areaIndex = 0;

    private void Awake()
    {
        for (int i = 0; i < _spawnAreaAtAtStart; ++i)
            SpawnArea();
    }

    private void Update()
    {
        int playerIndex = (int)(_player.position.y / _distanceToNext);

        if (playerIndex == _areaIndex - 1)
            SpawnArea();
    }

    private void SpawnArea()
    {
        int index = Random.Range(0, _areaPrefabs.Length);
        GameObject clone = Instantiate(_areaPrefabs[index]);
        clone.transform.position = Vector3.up * _distanceToNext * _areaIndex;
        _areaIndex++;
    }
}
