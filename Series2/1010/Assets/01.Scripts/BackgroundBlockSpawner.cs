using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private int _orderInLayer;

    private Vector2Int _blockCount = new Vector2Int(10, 10);
    private Vector2 _blockHalf = new Vector2(.5f, .5f);

    private void Awake()
    {
        for (int y = 0; y < _blockCount.y; ++y)
        {
            for (int x = 0; x < _blockCount.y; ++x)
            {
                float px = -_blockCount.x * .5f + _blockHalf.x + x;
                float py = _blockCount.y * .5f - _blockHalf.y - y;
                Vector3 position = new Vector3(px, py, 0);

                GameObject clone = Instantiate(_blockPrefab, position, Quaternion.identity, transform);
                clone.GetComponent<SpriteRenderer>().sortingOrder = _orderInLayer;
            }
        }
    }
}
