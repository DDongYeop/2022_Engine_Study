using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _yOffset = 8;
    [SerializeField] private float _smoothTime = .3f;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPosition = _target.TransformPoint(new Vector3(0, _yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, _smoothTime); //SmoothDamp는 목표위치까지 부드럽게 이동할 때 사용하는 메서드
    }
}
