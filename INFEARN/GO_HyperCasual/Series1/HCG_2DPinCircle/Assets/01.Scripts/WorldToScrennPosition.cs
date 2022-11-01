using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToScrennPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _distance = Vector3.zero;
    private Transform _targetTransform;
    private RectTransform _rectTransform;

    public void Setup(Transform target)
    {
        _targetTransform = target;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if (_targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPostion = Camera.main.WorldToScreenPoint(_targetTransform.position);
        _rectTransform.position = screenPostion + _distance;
    }
}
