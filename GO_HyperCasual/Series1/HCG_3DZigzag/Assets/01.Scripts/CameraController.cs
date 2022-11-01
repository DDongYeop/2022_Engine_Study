using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _distance;

    private void Awake()
    {
        _distance = Vector3.Distance(transform.position, _target.position);
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        transform.position = _target.position + transform.rotation * new Vector3(0, 0, -_distance);
    }
}
