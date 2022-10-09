using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBlockSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _blockSpawnPoints;
    [SerializeField] private GameObject[] _blocksPrebas;
    [SerializeField] private Vector3 spawnGapAmount = new Vector3(10, 0, 0);

    private void Awake()
    {
        StartCoroutine(OnSpawnBlocks());
    }

    private IEnumerator OnSpawnBlocks()
    {
        for (int i = 0; i < _blocksPrebas.Length; ++i)
        {
            yield return new WaitForSeconds(.1f);

            int index = Random.Range(0, _blocksPrebas.Length);
            Vector3 spawnPosition = _blockSpawnPoints[i].position + spawnGapAmount;
            GameObject clone = Instantiate(_blocksPrebas[index], spawnPosition, Quaternion.identity, _blockSpawnPoints[i]);

            clone.GetComponent<DragBlock>().Setup(_blockSpawnPoints[i].position);
        }
    }
}
