using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private float _maxRotateSpeed = 500;
    [SerializeField] private Vector3 _rotateAngle = Vector3.forward;

    public void Stop()
    {
        _rotateSpeed = 0;
    }

    public void RotateFast()
    {
        _rotateSpeed = _maxRotateSpeed;
    }

    private void Update()
    {
        transform.Rotate(_rotateAngle * _rotateSpeed * Time.deltaTime);
    }
}
