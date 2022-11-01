using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour
{
    [SerializeField] private bool _runOnce;
    [SerializeField] private float _positionOffesetY;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        float precisionMultiplier = 5f;
        _spriteRenderer.sortingOrder = -(int) (-(transform.position.y + _positionOffesetY) * precisionMultiplier);

        if (_runOnce)
            Destroy(this);
    }
}
