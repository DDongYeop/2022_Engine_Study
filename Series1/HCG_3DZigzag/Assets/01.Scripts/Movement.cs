using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Vector3 moveDirection;

    public Vector3 MoveDirection => moveDirection;

    private void Update()
    {
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
