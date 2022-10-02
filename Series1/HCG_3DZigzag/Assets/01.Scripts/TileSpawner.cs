using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _currentTile;

    [SerializeField] private int _spawnTileCountAtStart = 100;

    private void Awake()
    {
        for (int i = 0; i < _spawnTileCountAtStart; i++)
        {
            CreateTile();
        }
    }

    private void CreateTile()
    {
        GameObject clone = Instantiate(_tilePrefab);
        clone.transform.SetParent(transform);

        SpawnTile(clone.transform);
    }

    private void SpawnTile(Transform tile)
    {
        tile.gameObject.SetActive(true);

        int index = Random.Range(0, 2);
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;
        tile.position = _currentTile.position + addPosition;

        _currentTile = tile;
    }
}
