using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private PinSpawner _pinSpawner;
    [SerializeField] private int _throwablePinCount;
    [SerializeField] private int[] _stuckPinCount;

    private Vector3 _firstTPinPosition = Vector3.down * 2;
    public float TPinDistance { private set; get; } = 1;

    private void Awake()
    {
        for (int i = 0; i < _throwablePinCount; ++i)
            _pinSpawner.SpawnThrowbblePin(_firstTPinPosition + Vector3.down * TPinDistance * i);

        for (int i = 0; i < _stuckPinCount.Length; ++i)
            _pinSpawner.SpawnStuckPin(_stuckPinCount[i]);
    }
}
