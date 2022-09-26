using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header ("Horizontal Movement")]
    [SerializeField] private float _xMoveSpeed = 2.5f;
    [SerializeField] private float _xDelta = 2;
    private float _xStartPosition;

    [Header("Vertical Movement")]
    [SerializeField] private float _yMoveSpeed = .2f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _xStartPosition = transform.position.x;
    }

    public void MoveToX()
    {
        float x = _xStartPosition + _xDelta * Mathf.Sin(Time.time * _xMoveSpeed);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveToY()
    {
        _rigidbody2D.AddForce(transform.up * _yMoveSpeed, ForceMode2D.Impulse);
    }
}
