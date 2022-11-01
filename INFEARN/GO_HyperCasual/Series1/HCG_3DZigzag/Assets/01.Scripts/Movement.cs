using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _increaseAmount;
    [SerializeField] private float _increaseCycleTime;

    private Vector3 moveDirection;

    public Vector3 MoveDirection => moveDirection;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(_increaseCycleTime);
            _moveSpeed += _increaseAmount;
        }
    }

    private void Update()
    {
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
