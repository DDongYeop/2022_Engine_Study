using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 180f;

    private Rigidbody _rb;
    private Animator _animator;

    private int moveHash = Animator.StringToHash("Move");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetRotate(float angle)
    {
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
