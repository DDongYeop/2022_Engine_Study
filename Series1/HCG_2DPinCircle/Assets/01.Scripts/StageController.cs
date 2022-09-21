using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private PinSpawner _pinSpawner;
    [SerializeField] private int _throwablePinCount;
    [SerializeField] private int _stuckPinCount;

    private Vector3 _firstTPinPosition = Vector3.down * 2;
    public float TPinDistance { private set; get; } = 1;

    private void Awake()
    {
        _pinSpawner.Setup();

        for (int i = 0; i < _throwablePinCount; ++i)
            _pinSpawner.SpawnThrowbblePin(_firstTPinPosition + Vector3.down * TPinDistance * i, _throwablePinCount-i);

        for (int i = 0; i < _stuckPinCount; ++i)
        {
            float angle = (360 / _stuckPinCount) * i;
            _pinSpawner.SpawnStuckPin(angle, _stuckPinCount + 1 + i);
        }
    }
}
