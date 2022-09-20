using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [Header("Commons")]
    [SerializeField] private GameObject _pinPrefab;

    [Header("Stuck Pin")]
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _targetPosition = Vector3.up * 2;
    [SerializeField] private float _targetRadius = 0.8f;
    [SerializeField] private float _pinLegth = 1.5f;

    public void SpawnThrowbblePin(Vector3 position)
    {
        Instantiate(_pinPrefab, position, Quaternion.identity);
    }

    public void SpawnStuckPin(float angle)
    {
        GameObject clone = Instantiate(_pinPrefab);
        SetInPinStruckToTarget(clone.transform, angle);
    }

    private void SetInPinStruckToTarget(Transform pin, float angle)
    {
        pin.position = Utils.GetPositionFromAngle(_targetRadius + _pinLegth, angle) + _targetPosition;
        pin.rotation = Quaternion.Euler(0, 0, angle);
        pin.SetParent(_targetTransform);
        pin.GetComponent<Pin>().SetInPinStuckToTarget();
    }
}
